﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk
{
    public partial class FrmPromptBox : FrmBase
    {
        private Action<bool> state;

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            btnConfirm.Text = LanguageXmlUtils.GetValue("btn_ok", btnConfirm.Text);
            btnCancel.Text = LanguageXmlUtils.GetValue("btn_cancel", btnCancel.Text);
        }

        public FrmPromptBox()
        {
            Stacked = false;
            InitializeComponent();
            LoadLanguageText();
        }

        public string Content
        {
            get { return lblContent.Text; }
            set { lblContent.Text = value; }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void ResuState(Action<bool> p)
        {
            state = p;
        }
    }
}
