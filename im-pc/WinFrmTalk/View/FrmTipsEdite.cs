﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.View
{
    public partial class FrmTipsEdite : FrmBase
    {
        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            this.Text = LanguageXmlUtils.GetValue("edit", this.Text);
            btnsure.Text = LanguageXmlUtils.GetValue("btn_ok", btnsure.Text);
        }

        public FrmTipsEdite()
        {
            InitializeComponent();
            LoadLanguageText();
        }

        public Action<bool, string> sucerss;
        private string roomId;//roomid
        private Friend frienddata;
        private string noticeid;
        /// <summary>
        /// 传值
        /// </summary>
        /// <param name="mfriend"></param>
        /// <param name="editext">原先的公告内容</param>
        /// <param name="noticeId">公告id</param>
        public void SetData(Friend mfriend, string editext, string noticeId)
        {
            frienddata = mfriend;
            roomId = mfriend.RoomId;
            textEdite.Text = editext;
            noticeid = noticeId;
            TxtTips_TextChanged(null, null);
        }
        /// <summary>
        /// 编辑完成发布公告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsure_Click(object sender, EventArgs e)
        {
            if (textEdite.Text.Length > 500)
            {
                ShowTip("文字超过限制");
                return;
            }

            string a = roomId;
            string b = noticeid;
            string notice = textEdite.Text;//公告的内容
            HttpUtils.Instance.InitHttp(this);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/updateNotice") //编辑公告
          .AddParams("access_token", Applicate.Access_Token)
          .AddParams("roomId", roomId)
            .AddParams("noticeId", noticeid)
          .AddParams("noticeContent", notice)
           .Build().Execute((sccess, room) =>
           {
               if (sccess)
               {
                   sucerss?.Invoke(true, notice);
                   this.Close();
               }
           });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 粘贴禁止图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textEdite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                //检查是否黏贴文件
                //if (Clipboard.GetFileDropList().Count > 0)
                //{
                //    var strCollection = Clipboard.GetFileDropList();
                //    foreach (string item in strCollection)
                //        fileCollect.Add(item);
                //}

                IDataObject IData = Clipboard.GetDataObject();
                if (IData.GetDataPresent(DataFormats.Text))//
                {
                    this.textEdite.Text = (string)IData.GetData(DataFormats.Text);
                }
                else
                {
                    this.textEdite.Text = "";
                }
            }
        }

        private void TxtTips_TextChanged(object sender, EventArgs e)
        {
            int txtLength = textEdite.Text.Length;
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
