using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Helper;
using WinFrmTalk.Model;
using static TestListView.XListView;

namespace WinFrmTalk.View
{
    public partial class FrmProgressBar : FrmBase
    {
        const int TASK_CLEAR_ALL_MSG_RECORD = 1;
        int mTask = 0;
        bool mStop = false;
        public EventScrollHandler Compte { get; set; }

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            btnCancel.Text = LanguageXmlUtils.GetValue("btn_cancel", btnCancel.Text);
        }

        public FrmProgressBar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mStop = true;
            this.Close();
            //if (!this.IsDisposed)
            //{
            //    this.Dispose();
            //}
        }

        /// <summary>
        /// 窗体居中打开
        /// </summary>
        private void CenterOpen()
        {
            mStop = false;
            var parea = Applicate.GetWindow<FrmMain>();
            this.Location = new Point(parea.Location.X + (parea.Width - this.Width) / 2, parea.Location.Y + (parea.Height - this.Height) / 2);
            this.Show();
        }


        #region 群发消息
        Dictionary<string, Friend> addressees = null;
        Action<Friend> sendMsg = null;

        public FrmProgressBar(Dictionary<string, Friend> addressees, Action<Friend> sendMsg, bool isMass = true)
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            //this.isMass = isMass;
            var parea = Applicate.GetWindow<FrmMain>();
            this.Location = new Point(parea.Location.X + (parea.Width - this.Width) / 2, parea.Location.Y + (parea.Height - this.Height) / 2);
            mStop = false;
            if (isMass)
            {
                this.addressees = addressees;
                this.sendMsg = sendMsg;
            }

        }

        private void FrmProgress_Load(object sender, EventArgs e)
        {
            if (sendMsg != null)
            {
                MassSending();
            }
        }

        private void MassSending()
        {
            this.Text = LanguageXmlUtils.GetValue("frmProgressBar_title", "群发消息");
            mTask = TASK_CLEAR_ALL_MSG_RECORD;
            RefreshMassSending();

            Task.Factory.StartNew(() =>
            {
                int i = 0;
                string content = string.Empty;
                foreach (Friend fd in addressees.Values)
                {
                    // -1=friend null;-2=没有群密钥;-3=隐身人;-4=禁言
                    int result = CollectUtils.EnableForward_NotTip(fd);
                    if (result < 0)
                    {
                        if (string.IsNullOrEmpty(content))
                            content = LanguageXmlUtils.GetValue("frmProgressBar_error", "以下好友群发消息失败，原因：", true) + "\n";
                        switch (result)
                        {
                            case -1:
                                //content += "好友 " + fd.NickName + " 的数据异常，";
                                content += LanguageXmlUtils.GetValue("frmProgressBar_error1", "好友 " + fd.NickName + " 的数据异常，").Replace("%s", fd.NickName);
                                break;
                            case -2:
                                //content += "缺少 " + fd.NickName + " 的群密钥，";
                                content += LanguageXmlUtils.GetValue("frmProgressBar_error2", "缺少 " + fd.NickName + " 的群密钥，").Replace("%s", fd.NickName);
                                break;
                            case -3:
                                //content += "您在群 " + fd.NickName + " 的身份为隐身人，";
                                content += LanguageXmlUtils.GetValue("frmProgressBar_error3", "您在群 " + fd.NickName + " 的身份为隐身人，").Replace("%s", fd.NickName);
                                break;
                            case -4:
                                //content += "您在群 " + fd.NickName + " 已被禁言，";
                                content += LanguageXmlUtils.GetValue("frmProgressBar_error4", "您在群 " + fd.NickName + " 已被禁言，").Replace("%s", fd.NickName);
                                break;
                        }
                        continue;
                    }

                    sendMsg(fd);
                    Thread.Sleep(200);
                    if (mStop)
                    {
                        return;
                    }
                    string name = string.IsNullOrWhiteSpace(fd.RemarkName) ? fd.NickName : fd.RemarkName;
                    string text = LanguageXmlUtils.GetValue("frmProgressBar_progress", "正在给 " + name + " 发送消息").Replace("%s", name);
                    UpdateProgress_Mass(i, addressees.Count(), text);
                    i++;
                }

                if (string.IsNullOrEmpty(content))
                    ShowTipBox("群发消息完成");
                else
                {
                    content = content.Remove(content.Length - 1);   //去掉最后一个逗号
                    ShowTipBox(content);
                }
                //ShowTip("群发消息完成");
                button1_Click(null, null);
            });
        }

        private void RefreshMassSending()
        {
            this.viewProgress1.SetProgress(0);
            if (mTask == TASK_CLEAR_ALL_MSG_RECORD)
            {
                this.label1.Text = "";
                this.label2.Text = LanguageXmlUtils.GetValue("frmProgressBar_tips", "消息群发中，请稍等。。");
            }
        }


        private void UpdateProgress_Mass(int currt, int max, string text)
        {
            if (mStop)
            {
                return;
            }

            Invoke(new Action(() =>
            {
                if (mStop)
                {
                    return;
                }
                this.viewProgress1.SetProgress(currt + 1, max);
                this.label2.Text = text;
                this.label1.Text = LanguageXmlUtils.GetValue("frmProgressBar_sending", "发送中 ") + (currt + 1) + " / " + max;

            }));
        }
        #endregion
    }
}
