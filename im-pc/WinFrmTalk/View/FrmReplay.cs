using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;

namespace WinFrmTalk.View
{
    public partial class FrmReplay : FrmSuspension
    {
        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            lblTitle.Text = LanguageXmlUtils.GetValue("frmReplay_title", lblTitle.Text);
            btnadd.Text = LanguageXmlUtils.GetValue("btn_add", btnadd.Text);
        }

        public FrmReplay()
        {
            InitializeComponent();
            LoadLanguageText();
        }

        public Usertext mSelectItem;
        public Action<string> Sometimetext;
        public List<CommonText> commonTextlst = new List<CommonText>();
        private void FrmReplay_Load(object sender, EventArgs e)
        {

        }
        internal void loadData(MouseEventArgs e)
        {
            //获取鼠标点击表情时的坐标
            Point ms = Control.MousePosition;
            CommonText commonText = new CommonText();
            palcommonTex.HorizontalScroll.Maximum = 0;
            commonTextlst = commonText.GetListByCreateid();
            for (int i = 0; i < commonTextlst.Count; i++)
            {
                Usertext usertext = new Usertext();
                usertext.Width = 250;
                //   usertext.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                usertext.MouseDown += onmousedown;
                usertext.chatText = commonTextlst[i].content;
                usertext.sometext = commonTextlst[i].content;
                //if (this.Height <= 260)
                //{
                //    palcommonTex.Height += 45;
                //    this.Height += 45;
                //}

                palcommonTex.Controls.Add(usertext);
                palcommonTex.Controls.SetChildIndex(usertext, 0);

            }
    
            palcommonTex.AutoScroll = true;
            this.StartPosition = FormStartPosition.Manual;

            //设置弹出窗起始坐标
            int location_x = ms.X - e.X - 8;
            int location_y = ms.Y - this.Height - e.Y - 5;
            this.Location = new Point(location_x, location_y);
            this.Show();//显示的位置

        }



        private void onmousedown(object sender, MouseEventArgs e)
        {
            Usertext item = (Usertext)sender;

            if (item == mSelectItem)
            {
                return;
            }
            mSelectItem = item;

            Sometimetext?.Invoke(mSelectItem.chatText);
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            //FrmChatsometimes frmChatsometimes = new FrmChatsometimes();
            //frmChatsometimes.getdata();
            //frmChatsometimes.Show();




            var tmpset = Applicate.GetWindow<FrmShortcutEdit>();
            //var parent = Applicate.GetWindow<FrmMain>();
            if (tmpset == null)
            {
                var frmShortcut = new FrmShortcutEdit();

                //var con = Applicate.GetWindow<FrmMain>();

                //int centx = con.Location.X + ((con.Width - frmShortcut.Width) / 2);
                //int centy = con.Location.Y + ((con.Height - frmShortcut.Height) / 2);

                //frmShortcut.Location = new Point(centx, centy);//居中
                frmShortcut.Show();
                frmShortcut.LoadData();
            }
            else
            {
                tmpset.Activate();
                tmpset.WindowState = FormWindowState.Normal;
            }



            //FrmShortcutEdit frmShortcut = new FrmShortcutEdit();
            //frmShortcut.LoadData();


            //var con = Applicate.GetWindow<FrmMain>();

            //int centx = con.Location.X + ((con.Width - frmShortcut.Width) / 2);
            //int centy = con.Location.Y + ((con.Height - frmShortcut.Height) / 2);

            //frmShortcut.Location = new Point(centx, centy);//居中
            //frmShortcut.Show();


        }
    }
}
