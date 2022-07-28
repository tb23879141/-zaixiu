using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.Helper.MVVM;
using WinFrmTalk.Helper;
using WinFrmTalk.View;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class MultiSelectCollectPanel : UserControl
    {
        private List<Collections> _msgs;
        /// <summary>
        /// 多选的集合
        /// </summary>
        public List<Collections> List_Msgs
        {
            get { return _msgs; }
            set { _msgs = value; }
        }
        /// <summary>
        /// 当前的聊天对象
        /// </summary>
        public Friend FdTalking { get; set; }
        /// <summary>
        /// 消息列表面板
        /// </summary>
        public TableLayoutPanel showInfo_panel { get; set; }

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            lblOneRelay.Text = LanguageXmlUtils.GetValue("one_forward", lblOneRelay.Text);
            lblCombineRelay.Text = LanguageXmlUtils.GetValue("merge_forward", lblCombineRelay.Text);
            lblDelete.Text = LanguageXmlUtils.GetValue("delete", lblDelete.Text);
            lblCollect.Text = LanguageXmlUtils.GetValue("collect", lblCollect.Text);
        }

        public MultiSelectCollectPanel()
        {
            InitializeComponent();
            LoadLanguageText();
        }

        #region 合并转发
        private void picCombineRelay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && List_Msgs.Count > 0)
            {

                //List_Msgs = msglist;
                ////重新排序
                //List_Msgs.Sort((x, y) =>
                //{
                //    if (x.timeSend < y.timeSend)
                //        return -1;
                //    else if (x.timeSend > y.timeSend)
                //        return 1;
                //    else
                //        return 0;
                //});

                //选择转发的好友
                var frmFriendSelect = new FrmSortSelect();
                frmFriendSelect.LoadFriendsData(true, true, true, true, true);
                frmFriendSelect.Show();
                frmFriendSelect.AddConfrmListener((UserFriends) =>
                {
                    Invoke(new Action(() =>
                    {
                        var frmSchedule = new FrmSchedule(UserFriends, (friend) =>
                        {
                            if (friend.IsSecretGroup == 1)
                            {
                                if (UIUtils.IsNull(friend.ChatKeyGroup))
                                {
                                    // 没有密钥
                                    HttpUtils.Instance.ShowTip("不能转发消息到密钥丢失群");
                                    return;
                                }

                                if (friend.IsLostKeyGroup == 1)
                                {
                                    // 没有密钥
                                    HttpUtils.Instance.ShowTip("不能转发消息到密钥丢失群");
                                    return;
                                }
                            }
                            //禁言群，被隐身不能转发#10166

                            if (CollectUtils.EnableForward(friend))
                            {
                                return;
                            }

                            List<MessageObject> msglist = new List<MessageObject>();
                            foreach (Collections collectItem in List_Msgs)
                            {
                                MessageObject msgObj = new MessageObject();
                                msgObj.type = CollectUtils.GetMsgTypeBySaveType(collectItem.type);
                                msgObj.timeSend = TimeUtils.CurrentTimeDouble();
                                msgObj.messageId = Guid.NewGuid().ToString("N");//生成Guid
                                msgObj.FromId = Applicate.MyAccount.userId;
                                msgObj.ToId = friend.UserId;
                                msgObj.toUserId = friend.UserId;//接收者
                                msgObj.toUserName = friend.NickName;
                                msgObj.fromUserId = Applicate.MyAccount.userId;
                                msgObj.fromUserName = Applicate.MyAccount.nickname;
                                msgObj.content = collectItem.msg;
                                msgObj.fileName = collectItem.Filename;
                                //if (msg.type != kWCMessageType.History)
                                //{
                                msglist.Add(msgObj);
                                //}
                            }
                            MessageObject msg = ShiKuManager.SendForwardMessage(friend, msglist);
                            if (msg == null)
                                return;

                            ////如果转发对象包括当前聊天对象，给UI添加消息气泡
                            //if (friend.UserId == FdTalking.UserId)
                            //{
                            //    //添加消息气泡通知
                            //    Messenger.Default.Send(msg, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);
                            //}
                        }, false);
                        //if (UserFriends.Keys.Count > 0)
                        //    //关闭多选界面
                        //    Messenger.Default.Send(FdTalking, token: EQFrmInteraction.MultiSelectEnd);
                        frmSchedule.Show();

                    }));

                });
            }
        }
        #endregion

        #region 逐条转发
        private void picOneRelay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && List_Msgs.Count > 0)
            {
                ////重新排序
                //List_Msgs.Sort((x, y) =>
                //{
                //    if (x.timeSend < y.timeSend)
                //        return -1;
                //    else if (x.timeSend > y.timeSend)
                //        return 1;
                //    else
                //        return 0;
                //});
                var frmFriendSelect = new FrmSortSelect();
                frmFriendSelect.LoadFriendsData(true, true, true, true, true);
                frmFriendSelect.Show();
                frmFriendSelect.AddConfrmListener((UserFriends) =>
                {
                    Invoke(new Action(() =>
                    {
                        var frmSchedule = new FrmSchedule(UserFriends, (friend) =>
                        {
                            if (friend.IsSecretGroup == 1)
                            {
                                if (UIUtils.IsNull(friend.ChatKeyGroup))
                                {
                                    // 没有密钥
                                    HttpUtils.Instance.ShowTip("不能转发消息到密钥丢失群");
                                    return;
                                }

                                if (friend.IsLostKeyGroup == 1)
                                {
                                    // 没有密钥
                                    HttpUtils.Instance.ShowTip("不能转发消息到密钥丢失群");
                                    return;
                                }
                            }


                            foreach (Collections collectItem in List_Msgs)
                            {
                                MessageObject messageObjects = new MessageObject();                
                                messageObjects.type = CollectUtils.GetMsgTypeBySaveType(collectItem.type);
                                messageObjects.timeSend = TimeUtils.CurrentTimeDouble();
                                messageObjects.messageId = Guid.NewGuid().ToString("N");//生成Guid
                                messageObjects.FromId = Applicate.MyAccount.userId;
                                messageObjects.ToId = friend.UserId;
                                messageObjects.toUserId = friend.UserId;//接收者
                                messageObjects.toUserName = friend.NickName;
                                messageObjects.fromUserId = Applicate.MyAccount.userId;
                                messageObjects.fromUserName = Applicate.MyAccount.nickname;
                                messageObjects.content = collectItem.msg;
                                messageObjects.fileName = collectItem.Filename;
                                switch (collectItem.type)
                                {
                                    //图片
                                    case "1":

                                        string[] conString = collectItem.msg.Split(',');
                                        foreach (var msgStr in conString)
                                        {
                                            messageObjects = new MessageObject() { content = msgStr, type = kWCMessageType.Image };
                                            messageObjects.timeSend = TimeUtils.CurrentTimeDouble();
                                            messageObjects.messageId = Guid.NewGuid().ToString("N");//生成Guid
                                            messageObjects.FromId = Applicate.MyAccount.userId;
                                            messageObjects.ToId = friend.UserId;
                                            messageObjects.toUserId = friend.UserId;//接收者
                                            messageObjects.toUserName = friend.NickName;
                                            messageObjects.fromUserId = Applicate.MyAccount.userId;
                                            messageObjects.fromUserName = Applicate.MyAccount.nickname;
                                            //messageObjects.content = msg;
                                            //messageObjects.type = kWCMessageType.Image;
                                            ShiKuManager.SendForwardMessage(friend, messageObjects);

                                            Messenger.Default.Send(messageObjects, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);

                                            HttpUtils.Instance.ShowTip("转发成功");
                                        }


                                        if (!string.IsNullOrEmpty(collectItem.collectContent))
                                        {
                                            messageObjects = new MessageObject() { content = collectItem.collectContent, type = kWCMessageType.Image };
                                            ShiKuManager.SendForwardMessage(friend, messageObjects);

                                            Messenger.Default.Send(messageObjects, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);

                                            HttpUtils.Instance.ShowTip("转发成功");
                                        }

                                        return;
                                    //视频
                                    case "2":
                                        messageObjects = new MessageObject() { content = collectItem.url, fileName = FileUtils.GetFileName(collectItem.url), type = kWCMessageType.Video, fileSize = collectItem.fileSize };

                                        break;
                                    //文件
                                    case "3":
                                        messageObjects = new MessageObject() { content = collectItem.url, fileName = FileUtils.GetFileName(collectItem.Filename), type = kWCMessageType.File, fileSize = collectItem.fileSize };
                                        break;

                                    //文本表情
                                    case "5":
                                        messageObjects = new MessageObject() { content = collectItem.collectContent.ToString(), type = kWCMessageType.Text };
                                        break;

                                    case "4":    //语音
                                        messageObjects = new MessageObject() { content = collectItem.url, fileName = collectItem.Filename, type = kWCMessageType.Voice, fileSize = collectItem.fileSize, timeLen = Convert.ToInt32(collectItem.fileLength) };
                                        break;
                                    case "6":       //表情
                                    case "7":         //SDK分享链接
                                        break;
                                }

                                //if (msg.type != kWCMessageType.History)
                                //{
                                //msglist.Add(msgObj);
                                //}
                                MessageObject msg = ShiKuManager.SendForwardMessage(friend, messageObjects);
                            }

                            //foreach (MessageObject oMsg in List_Msgs)
                            //{



                            //if (oMsg.isReadDel == 1)
                            //{
                            //    HttpUtils.Instance.ShowTip("不能转发阅后即焚消息");
                            //    continue;
                            //}
                            ////禁言群，被隐身不能转发#10166

                            //if (CollectUtils.EnableForward(friend))
                            //{
                            //    return;
                            //}


                            //MessageObject msg = ShiKuManager.SendForwardMessage(friend, oMsg);



                            ////如果转发对象包括当前聊天对象，给UI添加消息气泡
                            //if (friend.UserId == FdTalking.UserId)
                            //{
                            //    //添加消息气泡通知
                            //    Messenger.Default.Send(msg, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);
                            //}
                            //}
                        }, false);
                        //if (UserFriends.Keys.Count > 0)
                        //    //关闭多选界面
                        //    Messenger.Default.Send(FdTalking, token: EQFrmInteraction.MultiSelectEnd);
                        frmSchedule.Show();
                    }));

                });
            }
        }
        #endregion

        private void picDelete_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void picCollect_Click(object sender, EventArgs e)
        {
            //if (List_Msgs.Count > 0)
            //{
            //    //重新排序
            //    List_Msgs.Sort((x, y) =>
            //    {
            //        if (x.timeSend < y.timeSend)
            //            return -1;
            //        else if (x.timeSend > y.timeSend)
            //            return 1;
            //        else
            //            return 0;
            //    });
            //    //调用收藏
            //    //foreach (MessageObject msg in List_Msgs)
            //    //    CollectUtils.getHttpData(msg);
            //    //批量收藏
            //    CollectUtils.CollectMessage(List_Msgs);

            //    //关闭多选界面
            //    Messenger.Default.Send(FdTalking, token: EQFrmInteraction.MultiSelectEnd);
            //}

            ////重新排序
            //List_Msgs.Sort((x, y) =>
            //{
            //    if (x.timeSend < y.timeSend)
            //        return -1;
            //    else if (x.timeSend > y.timeSend)
            //        return 1;
            //    else
            //        return 0;
            //});

            //批量删除
            Messenger.Default.Send(true, token: EQFrmInteraction.BatchDeleteCollect);

            //if (List_Msgs.Count > 0)
            //    //关闭多选界面
            //    Messenger.Default.Send(FdTalking, token: EQFrmInteraction.MultiSelectEnd);
        }
        bool isChecked = false;
        private void picDelete_Click(object sender, EventArgs e)
        {
            isChecked = !isChecked;
            if (isChecked)
            {
                picDelete.BackgroundImage = global::WinFrmTalk.Properties.Resources.ic_radio_check;
            }
            else
            {
                picDelete.BackgroundImage = global::WinFrmTalk.Properties.Resources.ic_radio_normal;
            }
            //批量选择
            Messenger.Default.Send(isChecked, token: EQFrmInteraction.BatchSelectCollect);
        }
    }
}
