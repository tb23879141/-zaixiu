﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinFrmTalk
{
    public partial class FrmServerSwit : FrmBase
    {
        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            this.Text = LanguageXmlUtils.GetValue("frmServerSwit_title", this.Text);
            label1.Text = LanguageXmlUtils.GetValue("collect", label1.Text, true);
            btnReset.Text = LanguageXmlUtils.GetValue("btn_reset", btnReset.Text);
            btnSet.Text = LanguageXmlUtils.GetValue("btn_ok", btnSet.Text);
        }

        public FrmServerSwit()
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            txtAddress.Text = UIUtils.GetServer();
        }
        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            HttpUtils.Instance.Get().Url(txtAddress.Text).Build()
                .AddErrorListener((code, msg) => { ShowTip("服务器设置错误，请重新设置"); })
                .ExecuteJson<ConfigData>((resultstatu, config) =>
                {
                    if (resultstatu)
                    {
                        UIUtils.SetServer(txtAddress.Text);
                        Messenger.Default.Send("666", MessageActions.UPDATE_CONFIG);
                        ShowTip("设置成功");
                        this.Close();
                    }
                });
        }
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {



            UIUtils.SetServer(Applicate.APP_CONFIG);
            txtAddress.Text = UIUtils.GetServer(); ;
            ShowTip("重置成功");
        }
    }
}
