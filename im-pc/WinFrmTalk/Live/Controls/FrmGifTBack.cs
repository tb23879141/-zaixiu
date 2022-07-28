using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.View;

namespace WinFrmTalk.Live.Controls
{
    public partial class FrmGifTBack : FrmBase
    {
        public FrmGifTBack()
        {
            InitializeComponent();
        }
        public void Show(Form frmTop, Form frmBackOwner, Color frmBackColor, double frmBackOpacity, FrmLive frmLive)
        {
            // 背景窗体设置
            var frmBack = new FrmBarrage();
            //frmBack.FormBorderStyle = FormBorderStyle.None;
            //frmBack.StartPosition = FormStartPosition.Manual;
            frmBack.ShowIcon = false;
            frmBack.ShowInTaskbar = false;
            frmBack.Opacity = frmBackOpacity;
            frmBack.BackColor = frmBackColor;
            frmBack.Owner = frmBackOwner;
            frmBack.Size = frmTop.Size;
            frmBack.Location = frmTop.Location;

            // 顶部窗体设置
            frmTop.Owner = frmBack;
            frmTop.StartPosition = FormStartPosition.Manual;
            frmTop.LocationChanged += (o, args) => { frmBack.Location = frmTop.Location; };
            // 显示窗体
            frmTop.Show(frmLive);
            frmBack.Show();

            timer1.Enabled = true;
            timer1.Start();
            //time = 0;//没送一次礼物重置一次计时
        }
        //private int time = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FrmGiftTip"];
            if (form == null)
            {
                this.Close();
            }
            //time += 1;
            //if (time == 5)
            //{
            //    timer1.Stop();
            //    this.Close();
            //}
        }

        private void FrmGifTBack_Load(object sender, EventArgs e)
        {

        }

        private void FrmGifTBack_FormClosed(object sender, FormClosedEventArgs e)
        {
            //timer1.Stop();
            //time = 0;
        }
    }
}
