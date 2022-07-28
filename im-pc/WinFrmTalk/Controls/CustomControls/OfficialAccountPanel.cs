using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class OfficialAccountPanel : UserControl
    {
        /// <summary>
        /// 查询时文本框的内容
        /// </summary>
        public string query_key { get => txtKeyWord.Text.Trim(); private set => txtKeyWord.Text = value; }

        public Action QueryAct = null;

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            btnQuery.Text = LanguageXmlUtils.GetValue("btn_check", btnQuery.Text);
        }

        public OfficialAccountPanel()
        {
            InitializeComponent();
            LoadLanguageText();
        }

        private void BtnQuery_MouseClick(object sender, MouseEventArgs e)
        {
            txtKeyWord.Focus();
            if (e.Button != MouseButtons.Left)
                return;

            QueryAct?.Invoke();
        }

        // 按下回车后去查询
        private void TxtKeyWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                MouseEventArgs ev = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0);
                BtnQuery_MouseClick(sender, ev);
            }
        }
    }
}
