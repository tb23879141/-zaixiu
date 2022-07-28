using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using WinFrmTalk.Model;
using WinFrmTalk.Dictionarys;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class RequestChatkeyPanel : UserControl
    {

        /// <summary>
        /// 事件的传递
        /// </summary>
        public event EventHandler SendRequestClick;


        public string CurrentUserId { get; set; }

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            lblUnReadNum.Text = LanguageXmlUtils.GetValue("request_group_key", lblUnReadNum.Text);
        }


        public RequestChatkeyPanel()
        {
            InitializeComponent();
            LoadLanguageText();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        public void IsShowView(string roomJid, bool show)
        {
            CurrentUserId = roomJid;
            //this.Visible = show;

            if (show)
            {
                this.BringToFront();
            }
            else
            {
                this.SendToBack();
            }
       
        }

        private void UnReadNumPanel_Paint(object sender, PaintEventArgs e)
        {
            //绘制边框
            Pen pen1 = new Pen(Color.FromArgb(225, 225, 225), 1);
            e.Graphics.DrawRectangle(pen1, 0, 0, this.Width - 1, this.Height - 1);
        }

        private void panUp_Click(object sender, EventArgs e)
        {
            SendRequestClick?.Invoke(this, e);
        }

        private void UnReadNumPanel_Load(object sender, EventArgs e)
        {
            //子控件继承点击事件
            foreach (Control crl in panUp.Controls)
                crl.Click += (s, ev) =>
                {
                    panUp_Click(s, ev);
                };
        }

    }
}
