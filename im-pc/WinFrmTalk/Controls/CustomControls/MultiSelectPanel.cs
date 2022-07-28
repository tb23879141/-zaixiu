using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFrmTalk.Helper;
using WinFrmTalk.Helper.MVVM;
using WinFrmTalk.Model;
using WinFrmTalk.View;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class MultiSelectPanel : UserControl
    {
        private List<MessageObject> _msgs;
        /// <summary>
        /// 多选的集合
        /// </summary>
        public List<MessageObject> List_Msgs
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

        public MultiSelectPanel()
        {
            InitializeComponent();
            LoadLanguageText();
        }

        #region 合并转发
        private void picCombineRelay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && List_Msgs.Count > 0)
            {
                List<MessageObject> msglist = new List<MessageObject>();
                foreach (MessageObject msg in List_Msgs)
                {
                    //if (msg.type != kWCMessageType.History)
                    //{
                    msglist.Add(msg);
                    //}
                }
                List_Msgs = msglist;
                //重新排序
                List_Msgs.Sort((x, y) =>
                {
                    if (x.timeSend < y.timeSend)
                        return -1;
                    else if (x.timeSend > y.timeSend)
                        return 1;
                    else
                        return 0;
                });

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


                            MessageObject msg = ShiKuManager.SendForwardMessage(friend, List_Msgs);
                            if (msg == null)
                                return;

                            //如果转发对象包括当前聊天对象，给UI添加消息气泡
                            if (friend.UserId == FdTalking.UserId)
                            {
                                //添加消息气泡通知
                                Messenger.Default.Send(msg, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);
                            }
                        }, false);
                        if (UserFriends.Keys.Count > 0)
                            //关闭多选界面
                            Messenger.Default.Send(FdTalking, token: EQFrmInteraction.MultiSelectEnd);
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
                //重新排序
                List_Msgs.Sort((x, y) =>
                {
                    if (x.timeSend < y.timeSend)
                        return -1;
                    else if (x.timeSend > y.timeSend)
                        return 1;
                    else
                        return 0;
                });
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




                            foreach (MessageObject oMsg in List_Msgs)
                            {



                                if (oMsg.isReadDel == 1)
                                {
                                    HttpUtils.Instance.ShowTip("不能转发阅后即焚消息");
                                    continue;
                                }
                                //禁言群，被隐身不能转发#10166

                                if (CollectUtils.EnableForward(friend))
                                {
                                    return;
                                }


                                MessageObject msg = ShiKuManager.SendForwardMessage(friend, oMsg);



                                //如果转发对象包括当前聊天对象，给UI添加消息气泡
                                if (friend.UserId == FdTalking.UserId)
                                {
                                    //添加消息气泡通知
                                    Messenger.Default.Send(msg, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);
                                }
                            }
                        }, false);
                        if (UserFriends.Keys.Count > 0)
                            //关闭多选界面
                            Messenger.Default.Send(FdTalking, token: EQFrmInteraction.MultiSelectEnd);
                        frmSchedule.Show();
                    }));

                });
            }
        }
        #endregion

        private void picDelete_MouseDown(object sender, MouseEventArgs e)
        {
            //重新排序
            List_Msgs.Sort((x, y) =>
            {
                if (x.timeSend < y.timeSend)
                    return -1;
                else if (x.timeSend > y.timeSend)
                    return 1;
                else
                    return 0;
            });

            //批量删除
            Messenger.Default.Send(List_Msgs, token: EQFrmInteraction.BatchDeleteMsg);

            if (List_Msgs.Count > 0)
                //关闭多选界面
                Messenger.Default.Send(FdTalking, token: EQFrmInteraction.MultiSelectEnd);
        }

        private void picCollect_Click(object sender, EventArgs e)
        {
            if (List_Msgs.Count > 0)
            {
                //重新排序
                List_Msgs.Sort((x, y) =>
                {
                    if (x.timeSend < y.timeSend)
                        return -1;
                    else if (x.timeSend > y.timeSend)
                        return 1;
                    else
                        return 0;
                });
                //调用收藏
                //foreach (MessageObject msg in List_Msgs)
                //    CollectUtils.getHttpData(msg);
                //批量收藏
                CollectUtils.CollectMessage(List_Msgs);

                //关闭多选界面
                Messenger.Default.Send(FdTalking, token: EQFrmInteraction.MultiSelectEnd);
            }
        }
    }
}
