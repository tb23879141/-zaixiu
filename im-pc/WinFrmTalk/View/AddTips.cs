using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.View
{
    public partial class AddTips : FrmBase
    {
        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            this.Text = LanguageXmlUtils.GetValue("issue_group_notice", this.Text);
            btnOK.Text = LanguageXmlUtils.GetValue("btn_ok", btnOK.Text);
        }

        public AddTips()
        {
            InitializeComponent();
            LoadLanguageText();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (txtTips.Text.Length > 500)
            {
                ShowTip("文字超过限制");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtTips_TextChanged(object sender, EventArgs e)
        {
            int txtLength = txtTips.Text.Length;
            lblScacle.Text = txtLength + @"/500";
            if (txtLength > 500)
            {
                lblScacle.ForeColor = Color.Red;
            }
            else
            {
                lblScacle.ForeColor = Color.Gray;
            }
        }
    }
}
