using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmTalk.View
{
    public partial class FrmTipBox : FrmBase
    {
        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            btnConfirm.Text = LanguageXmlUtils.GetValue("btn_ok", btnConfirm.Text);
        }

        public FrmTipBox()
        {
            InitializeComponent();
            LoadLanguageText();
        }

        public string Content
        {
            get { return lblContent.Text; }
            set { lblContent.Text = value; }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
