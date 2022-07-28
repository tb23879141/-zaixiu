using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Base;
using WinFrmTalk.Model;
using WinFrmTalk.View;

namespace WinFrmTalk.Live.Controls
{
    public partial class FrmGiftTip : FrmTransBase
    {
        private const int WM_ACTIVATE = 6;

        private const int WM_ACTIVATEAPP = 28;

        private const int WM_NCACTIVATE = 134;

        private const int WA_INACTIVE = 0;

        private const int WM_MOUSEACTIVATE = 33;

        private const int MA_NOACTIVATE = 3;
        const int WS_EX_NOACTIVATE = 0x08000000;

        //重载Form的CreateParams属性，添加不获取焦点属性值。
        public FrmLive frmLive { get; set; }


        public FrmTransBase frmchild
        {
            get;
            set;
        }
        public FrmGiftTip()
        {
            InitializeComponent();
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);

            MethodInfo method = base.GetType().GetMethod("SetStyle", System.Reflection.BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
            method.Invoke(this, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, new object[]
            {
                ControlStyles.Selectable,
                false
            }, Application.CurrentCulture);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            base.ShowInTaskbar = false;
            base.ShowIcon = true;
        }
        [DllImport("user32.dll")]
        private static extern IntPtr SetActiveWindow(IntPtr handle);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 33)
            {
                m.Result = new IntPtr(3);
            }
            else
            {
                if (m.Msg == 134)
                {
                    if (((int)m.WParam & 65535) != 0)
                    {
                        if (m.LParam != IntPtr.Zero)
                        {
                            FrmGiftTip.SetActiveWindow(m.LParam);
                        }
                        else
                        {
                            FrmGiftTip.SetActiveWindow(IntPtr.Zero);
                        }
                    }
                }
                else if (m.Msg == 2000)
                {
                }
                base.WndProc(ref m);
            }
        }



        #region 变量
        public Dictionary<string, int> count = new Dictionary<string, int>();//保存礼物的数量
        public bool isshow = true;//此窗体是否已经显示
        #endregion
        /// <summary>
        /// 传参
        /// </summary>
        /// <param name="message"></param>
        /// <param name="url">礼物的url</param>
        public void ShowGift(MessageObject message, Gift _gift)
        {
            time = 0;//每送一次礼物重置一次计时
            lblname.Text = message.fromUserName;
            lbl_giftname.Text = " 送出：" + _gift.name;
            ImageLoader.Instance.DisplayImage(_gift.photo, picgift);
            ImageLoader.Instance.DisplayAvatar(message.fromUserId, pic_head, false);
            string key = _gift.photo + message.fromUserId;
            if (count.ContainsKey(key))
            {
                int num = count[key];
                count[key] = num + 1;
                lblcount.Text = "x" + (num + 1);
            }
            else
            {
                count.Add(key, 1);
                lblcount.Text = "x1";
            }

            //this.BringToFront();
            timer1.Start();

        }
        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGiftTip_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmLive != null)
            {
                frmLive.openGifeFrm.Remove(lblname.Text);
            }
            isshow = true;
            timer1.Stop();
            count.Clear();
        }

        private void FrmGiftTip_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            if (frmchild != null)
            {
                frmchild.IsShowMaskDialog = false;
                var dia = frmchild.ShowDialog(this);
                this.DialogResult = dia;
            }

        }
        int time = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            time += 1;
            if (time == 5)
            {
                timer1.Stop();
                this.Close();

            }
        }
    }
}
