using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Helper;
using WinFrmTalk.Helper.MVVM;
using WinFrmTalk.Model;
using static TestListView.XListView;

namespace WinFrmTalk.View
{
    public partial class FrmSchedule : FrmBase
    {
        List<string> FriendFromLst = new List<string>();

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

        public FrmSchedule()
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标

            var parea = Applicate.GetWindow<FrmMain>();
            this.Location = new Point(parea.Location.X + (parea.Width - this.Width) / 2, parea.Location.Y + (parea.Height - this.Height) / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mStop = true;
            this.Close();
            if (!this.IsDisposed)
            {
                this.Dispose();
            }
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

        public void ClearAllMsgRecord()
        {
            this.Text = LanguageXmlUtils.GetValue("clear_all_record", "清除聊天记录");
            CenterOpen();

            mTask = TASK_CLEAR_ALL_MSG_RECORD;

            RefreshScheduleUi();

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(600);

                List<Friend> listfriend = new Friend().QueryFriendAndRoom();

                for (int i = 0; i < listfriend.Count; i++)
                {

                    var item = listfriend[i];
                    Thread.Sleep(200);
                    if (mStop)
                    {
                        return;
                    }

                    string content = LanguageXmlUtils.GetValue("clearing_record", "正在清除 " + item.NickName + " 的聊天记录").Replace("%s", item.NickName);
                    UpdateProgress(i, listfriend.Count, content);

                    item.UpdateClearMsg();
                    item.IsOnLine = -2;
                    var msg = new MessageObject() { FromId = Applicate.MyAccount.userId, ToId = item.UserId };
                    msg.DeleteTable();

                    if (Applicate.IsChatFriend(item.UserId))
                    {
                        Messenger.Default.Send(item.UserId, token: EQFrmInteraction.ClearFdMsgsSingle);
                    }
                    else
                    {
                        Messenger.Default.Send(item, token: MessageActions.UPDATE_CHATLIST_CLEAR_FRIEND);
                    }
                }

                if (Compte != null)
                {
                    Invoke(Compte);
                    button1_Click(null, null);
                }

            });
        }
        private void UpdateExportProgress(int currt, int max, string text)
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
                this.viewProgress1.SetProgress(currt, max);
                this.label2.Text = text;
                this.label1.Text = LanguageXmlUtils.GetValue("exporting", "导出中") + " " + (currt + 1) + " / " + max;

            }));
        }
        private void RefreshExportScheduleUi()
        {
            this.viewProgress1.SetProgress(0);
            if (mTask == TASK_CLEAR_ALL_MSG_RECORD)
            {
                this.label1.Text = LanguageXmlUtils.GetValue("exporting", "导出中");
                this.label2.Text = LanguageXmlUtils.GetValue("exporting", "导出中");
            }
        }

        public void Exportmessage(string personImgPath, Friend friends)
        {
            this.Text = LanguageXmlUtils.GetValue("export_record", "导出聊天记录");
            CenterOpen();

            mTask = TASK_CLEAR_ALL_MSG_RECORD;


            RefreshExportScheduleUi();

            Task.Factory.StartNew(() =>
            {
                string fielename = friends.NickName + "与" + Applicate.MyAccount.nickname + "的聊天记录" + (friends.UserId).Substring(friends.UserId.Length - 4, 4);
                string filepath = personImgPath + "\\" + fielename + ".xlsx"; //文件路径
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                DataTable dt = new DataTable();
                List<MessageObject> Alllist = new List<MessageObject>();
                Alllist = InputFileUtils.ShowAllMsgList(friends.UserId);
                dt.Columns.Add(LanguageXmlUtils.GetValue("sender", "发送者"));//列

                dt.Columns.Add(LanguageXmlUtils.GetValue("content", "内容"));
                dt.Columns.Add(LanguageXmlUtils.GetValue("time", "时间"));
                dt.Columns.Add(LanguageXmlUtils.GetValue("type", "类型"));
                for (int i = 0; i < Alllist.Count; i++)
                {
                    var item = Alllist[i];
                    Thread.Sleep(200);
                    if (mStop)
                    {
                        return;
                    }
                    string content = LanguageXmlUtils.GetValue("exporting_record", "正在导出第 " + i + " 条聊天记录").Replace("%s", i.ToString());
                    UpdateExportProgress(i, Alllist.Count, content);

                    DataRow dr2 = dt.NewRow();//行
                    dr2[0] = Alllist[i].fromUserName;

                    if (Alllist[i].content == null)
                    {
                        Alllist[i].content = "";
                    }
                    dr2[1] = Alllist[i].content;
                    dr2[2] = TimeUtils.FromatTime(Convert.ToInt64(Alllist[i].timeSend), "yyyy / MM / dd HH: mm:ss");
                    dr2[3] = UIUtils.NewstypeTostring(Alllist[i].type);
                    dt.Rows.Add(dr2);
                }
                //DataSetToExcel()
                InputFileUtils.DataTableToExcel(filepath, dt, false);//保存exele,
                if (Compte != null)
                {
                    Invoke(Compte);
                    button1_Click(null, null);
                }

            });

        }


        public void ExportTxtmessage(string personImgPath, Friend friends)
        {
            this.Text = LanguageXmlUtils.GetValue("export_record", "导出聊天记录");
            CenterOpen();

            mTask = TASK_CLEAR_ALL_MSG_RECORD;


            RefreshExportScheduleUi();

            Task.Factory.StartNew(() =>
            {

                string filepath = personImgPath + "\\" + friends.NickName + "与" + Applicate.MyAccount.nickname + "的聊天记录" + (friends.UserId).Substring(friends.UserId.Length - 4, 4) + ".txt"; //文件路径
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                List<MessageObject> Alllist = new List<MessageObject>();
                Alllist = InputFileUtils.ShowAllMsgList(friends.UserId);

                ArrayList list = new ArrayList();
                for (int i = 0; i < Alllist.Count; i++)
                {
                    var item = Alllist[i];
                    Thread.Sleep(200);
                    if (mStop)
                    {
                        return;
                    }
                    string content = LanguageXmlUtils.GetValue("exporting_record", "正在导出第 " + i + " 条聊天记录").Replace("%s", i.ToString());
                    UpdateExportProgress(i, Alllist.Count, content);
                    list.Add(Alllist[i].fromUserName + "(" + Alllist[i].fromUserId + ")" + " " + TimeUtils.FromatTime(Convert.ToInt64(Alllist[i].timeSend), "yyyy / MM / dd HH: mm:ss"));
                    if (Alllist[i].content == null)
                    {
                        Alllist[i].content = "";
                    }
                    list.Add(Alllist[i].content);
                    list.Add("");
                }
                using (FileStream fs = File.Open(filepath, FileMode.Create))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    foreach (var v in list)
                    {
                        // 一个元素占文件的一行
                        sw.WriteLine(v.ToString());
                    }
                    sw.Flush();
                    sw.Close();
                }
                if (Compte != null)
                {
                    Invoke(Compte);
                    button1_Click(null, null);
                }
            });

        }
        private void RefreshScheduleUi()
        {
            this.viewProgress1.SetProgress(0);
            if (mTask == TASK_CLEAR_ALL_MSG_RECORD)
            {
                this.label1.Text = LanguageXmlUtils.GetValue("clearing", "清除中");
                this.label2.Text = LanguageXmlUtils.GetValue("clearing", "清除中");
            }
        }


        private void UpdateProgress(int currt, int max, string text)
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
                this.viewProgress1.SetProgress(currt, max);
                this.label2.Text = text;
                this.label1.Text = LanguageXmlUtils.GetValue("clearing", "清除中") + " " + (currt + 1) + " / " + max;

            }));
        }




        private void FrmSchedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            mStop = true;
        }

        private void FrmSchedule_Load(object sender, EventArgs e)
        {
            if (sendMsg != null)
            {
                MassSending();
            }
            if (TransSendMsg != null)
            {
                transmitNews();
            }
        }

        #region 群发消息
        Dictionary<string, Friend> addressees = null;
        Action<Friend> sendMsg = null;
        public FrmSchedule(Dictionary<string, Friend> addressees, Action<Friend> sendMsg, bool isMass = true)
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            this.isMass = isMass;
            var parea = Applicate.GetWindow<FrmMain>();
            this.Location = new Point(parea.Location.X + (parea.Width - this.Width) / 2, parea.Location.Y + (parea.Height - this.Height) / 2);
            mStop = false;
            if (isMass)
            {
                this.addressees = addressees;
                this.sendMsg = sendMsg;
            }
            else
            {
                this.UserFriends = addressees;
                this.TransSendMsg = sendMsg;
            }

        }

        private void MassSending()
        {
            this.Text = "群发消息";
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
                        content = string.IsNullOrEmpty(content) ? "以下好友群发消息失败，原因：" : content;
                        switch (result)
                        {
                            case -1:
                                content += "好友 " + fd.NickName + " 的数据异常，";
                                break;
                            case -2:
                                content += "缺少 " + fd.NickName + " 的群密钥";
                                break;
                            case -3:
                                content += "您在群 " + fd.NickName + " 的身份为隐身人";
                                break;
                            case -4:
                                content += "您在群 " + fd.NickName + " 已被禁言";
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
                    UpdateProgress_Mass(i, addressees.Count(), "正在给 " + name + " 发送消息");
                    i++;
                }

                if (string.IsNullOrEmpty(content))
                    ShowTipBox("群发消息完成");
                else
                    ShowTipBox(content);
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
                this.label2.Text = "消息群发中，请稍等。。";
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
                this.viewProgress1.SetProgress(currt, max);
                this.label2.Text = text;
                this.label1.Text = LanguageXmlUtils.GetValue("sending_msg", "发送中 ") + (currt + 1) + " / " + max;

            }));
        }
        #endregion
        #region 转发消息
        public Dictionary<string, Friend> UserFriends = null;
        public Action<Friend> TransSendMsg = null;
        bool isMass = true;
        private void transmitNews()
        {
            this.Text = LanguageXmlUtils.GetValue("forward_msg", "转发消息");
            CenterOpen();

            mTask = TASK_CLEAR_ALL_MSG_RECORD;
            RefreshTransUi();
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(600);
                int i = 0;
                foreach (var item in UserFriends.Values)
                {
                    TransSendMsg(item);
                    Thread.Sleep(200);
                    if (mStop)
                    {
                        return;
                    }
                    string name = string.IsNullOrWhiteSpace(item.RemarkName) ? item.NickName : item.RemarkName;
                    string content = LanguageXmlUtils.GetValue("forwarding_msg", "正在给 " + name + " 发送消息").Replace("%s", name);
                    UpdateProgress_Mass(i, UserFriends.Count, content);
                    i++;
                }
                //ShowTip("转发消息完成");
                button1_Click(null, null);
            });
        }
        public void RefreshTransUi()
        {
            this.viewProgress1.SetProgress(0);
            if (mTask == TASK_CLEAR_ALL_MSG_RECORD)
            {
                this.label1.Text = "";
                this.label2.Text = LanguageXmlUtils.GetValue("forwarding", "转发中，请稍等。。");
            }
        }
        #endregion

    }
}
