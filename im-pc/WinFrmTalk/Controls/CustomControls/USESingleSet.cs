using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Helper.MVVM;
using WinFrmTalk.Model;
using WinFrmTalk.Model.dao;
using WinFrmTalk.View;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class USESingleSet : UserControl
    {
        private string nickname = string.Empty;

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            lblAdd.Text = LanguageXmlUtils.GetValue("add", lblAdd.Text);
            lblRemarkName.Text = LanguageXmlUtils.GetValue("remark_name", lblRemarkName.Text);
            lblAccountIM.Text = LanguageXmlUtils.GetValue("account_IM", lblAccountIM.Text);
            lblClear.Text = LanguageXmlUtils.GetValue("both-way_clear_chat_history", lblClear.Text);
            lblNoDisturbing.Text = LanguageXmlUtils.GetValue("no_disturbing", lblNoDisturbing.Text);
            lblOverdueTime.Text = LanguageXmlUtils.GetValue("msg_overdue_time", lblOverdueTime.Text);
            lblLabelText.Text = LanguageXmlUtils.GetValue("label", lblLabelText.Text);
            lblTransmitWay.Text = LanguageXmlUtils.GetValue("msg_transmit_way", lblTransmitWay.Text);
            lblnewsSend.Text = LanguageXmlUtils.GetValue("plaintext_transmit", lblnewsSend.Text);
            tspmDocuments.Text = LanguageXmlUtils.GetValue("plaintext_transmit", tspmDocuments.Text);
            tspm3des.Text = LanguageXmlUtils.GetValue("3DES_encrypt_transmit", tspm3des.Text);
            tspmAES.Text = LanguageXmlUtils.GetValue("AES_encrypt_transmit", tspmAES.Text);
            tspmPTP.Text = LanguageXmlUtils.GetValue("port_to_port", tspmPTP.Text);
            lblTop.Text = LanguageXmlUtils.GetValue("top_chat", lblTop.Text);
            lblNoDisturbing.Text = LanguageXmlUtils.GetValue("no_disturbing", lblNoDisturbing.Text);
            lblReadDel.Text = LanguageXmlUtils.GetValue("read_delete", btnClearRecord.Text);
            btnClearRecord.Text = LanguageXmlUtils.GetValue("btn_clear_chat_history", btnClearRecord.Text);
            btnblack.Text = LanguageXmlUtils.GetValue("btn_blacklist", btnblack.Text);
            btndeleatefriend.Text = LanguageXmlUtils.GetValue("btn_delete_fd", btndeleatefriend.Text);
            tsmHour.Text = LanguageXmlUtils.GetValue("one_hour", tsmHour.Text);
            tsmDay.Text = LanguageXmlUtils.GetValue("one_day", tsmDay.Text);
            tsmWeek.Text = LanguageXmlUtils.GetValue("one_week", tsmWeek.Text);
            tsmMonth.Text = LanguageXmlUtils.GetValue("one_month", tsmMonth.Text);
            tsmSeason.Text = LanguageXmlUtils.GetValue("one_season", tsmSeason.Text);
            tsmYear.Text = LanguageXmlUtils.GetValue("one_year", tsmYear.Text);
            tsmForever.Text = LanguageXmlUtils.GetValue("permanent", tsmForever.Text);
        }

        public USESingleSet()
        {
            InitializeComponent();
            LoadLanguageText();
            label9.BringToFront();
        }
        public Friend friend;
        private FrmSingleSet SingleSet;


        //  private bool closeState = true;
        /// <summary>
        /// 绑定数据到控件上
        /// </summary>
        /// <param name="msg"></param>
        public void BindViewData(Friend toFriend)
        {
            //如果是我的设备就不需要调取接口

            friend = toFriend.GetByUserId();

            // 刷新阅后即焚等 按钮状态
            RefreshCheckBtnState(friend);


            //我的设备
            if (friend.IsDevice())
            {
                panel1.Visible = false;
                lblRemarks.Visible = false;
                txtRemarks.Visible = false;
                lblOverdueDate.Visible = false;
                picOverdueDate.Visible = false;

                btnblack.Click -= lblAddBlacklist_Click;
                btndeleatefriend.Click -= lblDeleteFriend_Click;
                btnblack.Visible = false;
                btndeleatefriend.Visible = false;
                lblLabel.Visible = false;
                picLabel.Visible = false;
            }
            else//好友
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/get")
               .AddParams("access_token", Applicate.Access_Token)
               .AddParams("userId", toFriend.UserId)
               .Build().Execute((suus, data) =>
               {
                   if (suus)
                   {
                       bool isRefreRecent = false;
                       Friend jsonFriend = JsonConvert.DeserializeObject<Friend>(JsonConvert.SerializeObject(data)); //使用Friend解析出来
                       if (data.ContainsKey("friends"))
                       {
                           // 解析服务器数据
                           AttentionFriend attention = JsonConvert.DeserializeObject<AttentionFriend>(data["friends"].ToString());
                           jsonFriend.Status = attention.ToFriendStatus();
                           jsonFriend.RemarkName = attention.remarkName;
                           jsonFriend.RemarkPhone = attention.phoneRemark;
                           jsonFriend.Description = attention.describe;
                           RemarkPhone = attention.phoneRemark;
                           if (UIUtils.IsNull(RemarkPhone))
                           {
                               lblRemarkPhone.Text = "点击添加";
                           }
                           else
                           {
                               //string[] phones = RemarkPhone.Split(';');
                               //lblRemarkPhone.Text = RemarkPhone;
                               lblRemarkPhone.Text = "点击查看";
                           }

                           if (!string.Equals(friend.RemarkPhone, attention.phoneRemark))
                           {
                               friend.RemarkPhone = attention.phoneRemark;
                               friend.UpdateRemarkPhone(friend.RemarkPhone);
                           }

                           if (!string.Equals(friend.Description, attention.describe))
                           {
                               friend.Description = attention.describe;
                               friend.UpdateDescription(friend.Description);
                           }

                           OverdueDate(attention.chatRecordTimeOut.ToString());

                           // 端到端加密
                           if (!UIUtils.IsNull(attention.dhMsgPublicKey) && !attention.dhMsgPublicKey.Equals(friend.DhPublicKey))
                           {
                               friend.DhPublicKey = attention.dhMsgPublicKey;
                               friend.UpdateDhPublicKey(friend.RsaPublicKey);
                               isRefreRecent = true;
                           }

                           if (!UIUtils.IsNull(attention.rsaMsgPublicKey) && !attention.rsaMsgPublicKey.Equals(friend.RsaPublicKey))
                           {
                               friend.RsaPublicKey = attention.rsaMsgPublicKey;
                               friend.UpdateRsaPublicKey(friend.RsaPublicKey);
                               isRefreRecent = true;
                           }

                           // 端到端加密方式
                           if (attention.encryptType != friend.IsEncrypt)
                           {
                               friend.IsEncrypt = attention.encryptType;
                               friend.UpdateEncrypt(friend.IsEncrypt);
                               isRefreRecent = true;
                           }

                           // 置顶时间
                           if (attention.openTopChatTime == 1)
                           {
                               if (friend.TopTime > 0)
                               {
                                   attention.openTopChatTime = friend.TopTime;
                               }
                               else
                               {
                                   attention.openTopChatTime = TimeUtils.CurrentIntTime();
                               }
                           }

                           // 置顶
                           if (attention.openTopChatTime != friend.TopTime)
                           {
                               friend.TopTime = attention.openTopChatTime;
                               friend.UpdateTopTime(friend.TopTime);
                               isRefreRecent = true;
                           }

                           // 阅后即焚
                           if (attention.isOpenSnapchat != friend.IsOpenReadDel)
                           {
                               jsonFriend.IsOpenReadDel = attention.isOpenSnapchat;
                               jsonFriend.UpdateReadDel();
                               isRefreRecent = true;
                           }

                           // 消息免打扰
                           if (attention.offlineNoPushMsg != friend.Nodisturb)
                           {
                               jsonFriend.Nodisturb = attention.offlineNoPushMsg;
                               jsonFriend.UpdateNodisturb();
                               isRefreRecent = true;
                           }

                           if (jsonFriend.Status == 0)
                           {
                               btnblack.Visible = false;
                           }
                       }
                       else
                       {
                           btnblack.Visible = false;
                       }


                       if (!string.Equals(jsonFriend.NickName, friend.NickName))
                       {
                           friend.NickName = jsonFriend.NickName;
                           Messenger.Default.Send(friend, MessageActions.UPDATE_FRIEND_REMARKS);
                       }

                       jsonFriend.LastMsgTime = friend.LastMsgTime;
                       jsonFriend.MsgNum = friend.MsgNum;
                       jsonFriend.Content = friend.Content;
                       jsonFriend.TopTime = friend.TopTime;


                       // 刷新头像
                       ImageLoader.Instance.DisplayAvatar(friend, picHead);

                       // 刷新昵称
                       lblNickname.Text = UIUtils.LimitTextLength(friend.NickName, 4, false);
                       if (!string.IsNullOrEmpty(friend.RemarkName))
                           nickname = friend.RemarkName;
                       lblRemarks.Text = string.IsNullOrEmpty(friend.RemarkName) ?
                           LanguageXmlUtils.GetValue("add_remarks", "点击添加备注") :
                           UIUtils.LimitTextLength(friend.RemarkName, 7, false);
                       lblAccount.Text = UIUtils.DecodeString(data, "account");

                       // 刷新标签
                       bindLable();
                       // 刷新 阅后即焚按钮状态
                       RefreshCheckBtnState(friend);

                       if (isRefreRecent)
                       {
                           Messenger.Default.Send(friend, MessageActions.UPDATE_FRIEND_TOP);
                       }
                   }
               });
            }
        }


        /// <summary>
        /// 绑定标签数据到控件上
        /// </summary>
        private void bindLable()
        {
            var labelList = FriendLabelDao.Instance.GetFriendLabelByUserId(friend.UserId);

            if (UIUtils.IsNull(labelList))
            {
                lblLabel.Text = string.Empty;
            }
            else
            {
                string lableText = string.Empty;
                foreach (var friendLabel in labelList)
                {
                    lableText += friendLabel.groupName + ",";
                }
                lblLabel.Text = lableText;
            }
        }
        private string RemarkPhone;
        private void bindRemarkPhone()
        {
            if (!UIUtils.IsNull(RemarkPhone))
            {
                string[] remarkphones = RemarkPhone.Split(';');
                for (int i = 0; i < remarkphones.Length; i++)
                {
                    cmsRemarkPhone.Items.Add(remarkphones[i]);

                }
            }
        }

        /// <summary>
        /// 清除聊天记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClearRecord_Click(object sender, EventArgs e)
        {
            FrmSingleSet frm = (FrmSingleSet)this.Parent;
            frm.IsClose = false;
            if (Applicate.GetWindow<FrmMain>().ShowPromptBox("确认删除聊天记录？此操作将会清空本地和服务器的聊天记录!"))
            {
                MessageObject messageObject = new MessageObject()
                { FromId = Applicate.MyAccount.userId, ToId = friend.UserId };
                if (messageObject.DeleteTable() > 0)
                {
                    Messenger.Default.Send(friend.UserId, token: EQFrmInteraction.ClearFdMsgsSingle);
                    LogUtils.Log("删除成功");
                }
                else
                {
                    LogUtils.Log("删除失败或者没有该好友聊天记录");
                }
            }

            frm.IsClose = true;
        }

        /// <summary>
        /// 删除好友
        /// </summary>
        private void lblDeleteFriend_Click(object sender, EventArgs e)
        {
            FrmSingleSet frm = new FrmSingleSet();
            frm = (FrmSingleSet)this.Parent;
            frm.IsClose = false;
            if (HttpUtils.Instance.ShowPromptBox("确认删除该好友？"))
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friends/delete")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("toUserId", friend.UserId)
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            ShiKuManager.SendDelFriendMsg(friend);
                            LogUtils.Log("删除好友成功");
                        }
                        else
                        {
                            LogUtils.Log("删除好友失败");
                        }
                    });
            }
            frm.IsClose = true;
        }

        /// <summary>
        /// 添加到黑名单
        /// </summary>
        private void lblAddBlacklist_Click(object sender, EventArgs e)
        {
            FrmSingleSet frm = new FrmSingleSet();
            frm = (FrmSingleSet)this.Parent;
            frm.IsClose = false;
            if (HttpUtils.Instance.ShowPromptBox("确认将该好友加入黑名单？"))
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friends/blacklist/add")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("toUserId", friend.UserId)
                    .Build().Execute(
                        (suss, data) =>
                        {
                            if (suss)
                            {
                                ShiKuManager.SendBlockfriend(friend);
                                Applicate.GetWindow<FrmSingleSet>().Close();
                                LogUtils.Log("加入黑名单成功");
                            }
                            else
                            {
                                LogUtils.Log("加入黑名单失败");
                            }
                        });
            }
            frm.IsClose = true;
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtRemarks_Leave(sender, e);
            }
        }
        private void txtRemarks_KeyPress(object sender, EventArgs e)
        {
            if (friend.IsDevice())
            {
                Applicate.GetWindow<FrmMain>().ShowTip("我的设备无法使用此功能");
                return;
            }


            FrmFriendDescribe frmFriend = Applicate.GetWindow<FrmFriendDescribe>();
            if (frmFriend == null)
            {
                frmFriend = new FrmFriendDescribe();
                frmFriend.ShowFriend(friend);
                frmFriend.Show();
            }
            else
            {
                frmFriend.Activate();
                frmFriend.ShowFriend(friend);
            }

            return;
        }

        /// <summary>
        /// 点击备注切换到可修改状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRemarks_Click(object sender, EventArgs e)
        {
            txtRemarks.Text = "";
            if (lblRemarks.Text != LanguageXmlUtils.GetValue("add_remarks", "点击添加备注"))
            {
                txtRemarks.Text = nickname;
                txtRemarks.Visible = true;
                txtRemarks.Focus();
            }
            else
            {
                txtRemarks.Visible = true;
                txtRemarks.Focus();
            }
        }


        /// <summary>
        /// 修改备注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRemarks_Leave(object sender, EventArgs e)
        {
            if (friend != null)
            {
                if (friend.RemarkName != txtRemarks.Text && txtRemarks.Visible)
                {
                    string url = Applicate.URLDATA.data.apiUrl + "friends/remark";
                    HttpUtils.Instance.Get().Url(url)
                        .AddParams("access_token", Applicate.Access_Token)
                        .AddParams("toUserId", friend.UserId)
                        .AddParams("remarkName", txtRemarks.Text)
                        .Build().Execute((suss, data) =>
                        {
                            if (suss)
                            {
                                friend.RemarkName = txtRemarks.Text;
                                nickname = txtRemarks.Text;
                                friend.UpdateRemarkName();
                                Messenger.Default.Send(friend, MessageActions.UPDATE_FRIEND_REMARKS);
                                lblRemarks.Text = (txtRemarks.Text == "" ? LanguageXmlUtils.GetValue("add_remarks", "点击添加备注") : txtRemarks.Text);
                                txtRemarks.Text = "";
                                lblAccount.Focus();
                            }
                        });
                }
                txtRemarks.Visible = false;
            }
        }


        /// <summary>
        /// 点+建群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmFriendSelect create = new FrmFriendSelect();
            var tmpset = Applicate.GetWindow<FrmMain>();
            create.Location = new Point(tmpset.Location.X + (tmpset.Width - create.Width) / 2, tmpset.Location.Y + (tmpset.Height - create.Height) / 2);//居中
            create.LoadFriendsData(new List<RoomMember>() { new RoomMember() { userId = friend.UserId } }, false);
            create.AddConfrmListener((dis) =>
            {
                List<string> datas = new List<string>();
                datas.Add(friend.UserId);
                string nickName = friend.NickName + ",";
                foreach (var item in dis)
                {
                    datas.Add(item.Value.UserId);
                    nickName += item.Value.NickName + ",";
                }
                dis.Add(friend.UserId, friend);
                nickName = nickName.Remove(nickName.Length - 1, 1);
                string ss = JsonConvert.SerializeObject(datas);
                // xmpp 建群
                string jid = ShiKuManager.mSocketCore.CreateGroup(friend.NickName, friend.Description);
                if (!string.IsNullOrEmpty(jid))
                {
                    friend.UserId = jid;
                    HttpCreateRoom(friend, ss, dis, nickName);
                }
            });

        }



        /// <summary>
        /// http建群
        /// </summary>
        /// <param name="friend"></param>
        /// <param name="userIds"></param>
        /// <param name="select"></param>
        private void HttpCreateRoom(Friend friend, string userIds, Dictionary<string, Friend> select, string name)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/add")//新建群组
            .AddParams("jid", friend.UserId)
            .AddParams("access_token", Applicate.Access_Token)
            .AddParams("desc", friend.Description)
            .AddParams("name", name)
            //.AddParams("text", userIds) 先建群在去邀请，否则会丢失一些群成员进群的消息
            .AddParams("showRead", "0")
            .AddParams("cityId", "440300")
            .AddParams("countryId", "1")
            .AddParams("provinceId", "440000")
            .AddParams("areaId", "440307")
            .AddParams("longitude", "114.066307")
            .AddParams("latitude", "22.609084")
            .AddParams("type", "4") // 建立出来的都是临时群
             .Build().Execute((sccess, data) =>
             {
                 if (sccess)
                 {
                     string roomId = UIUtils.DecodeString(data, "id");
                     //Friend room = ToFriend(data);
                     HttpUtils.Instance.ShowTip("创建成功");
                     InviteToGroup(roomId, userIds);
                     //SaveRoomUsers(roomId, select);
                 }
                 else
                 {
                     MessageBox.Show(data.ToString());
                 }
             });
        }

        private void lblOverdueDate_Click(object sender, EventArgs e)
        {
            cmsOverdueDate.Show(lblOverdueDate, lblOverdueDate.Width - cmsOverdueDate.Width, lblOverdueDate.Height);
        }


        private void HttpSubDate(string date)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friends/update")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("chatRecordTimeOut", date)
                .AddParams("toUserId", friend.UserId)
                .Build().Execute((suu, data) =>
                {
                    if (suu)
                    {
                        OverdueDate(date);
                        LogUtils.Log("修改成功");
                    }
                });
        }
        /// <summary>
        /// 设置消息过期内容
        /// </summary>
        /// <param name="date"></param>
        private void OverdueDate(string date)
        {
            string save = date;
            switch (date)
            {
                case "-1":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("permanent", "永不");
                    save = "0";
                    break;
                case "0":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("permanent", "永不");
                    break;
                case "0.04":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_hour", "1小时");
                    break;
                case "1":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_day", "1天");
                    break;
                case "7":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_week", "1周");
                    break;
                case "30":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_week", "1月"); ;
                    break;
                case "90":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_season", "1季");
                    break;
                case "365":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_year", "1年");
                    break;
                default:
                    HttpUtils.Instance.ShowTip("修改失败");
                    save = "0";
                    break;
            }

            LocalDataUtils.SetStringData(friend.UserId + "chatRecordTimeOut" + Applicate.MyAccount.userId, save);
        }

        /// <summary>
        /// 永久
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmForever_Click(object sender, EventArgs e)
        {
            HttpSubDate("-1");
        }
        /// <summary>
        /// 一小时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmHour_Click(object sender, EventArgs e)
        {
            HttpSubDate("0.04");
        }
        /// <summary>
        /// 一天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDay_Click(object sender, EventArgs e)
        {
            HttpSubDate("1");
        }
        /// <summary>
        /// 一周
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmWeek_Click(object sender, EventArgs e)
        {
            HttpSubDate("7");
        }
        /// <summary>
        /// 一月
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmMonth_Click(object sender, EventArgs e)
        {
            HttpSubDate("30");
        }
        /// <summary>
        /// 一季
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmSeason_Click(object sender, EventArgs e)
        {
            HttpSubDate("90");

        }
        /// <summary>
        /// 一年
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmYear_Click(object sender, EventArgs e)
        {
            HttpSubDate("365");
        }

        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool state = false;
        private void chkUppermost_CheckedChanged(object sender, EventArgs e)
        {
            if (state)
            {

                if (friend.UserType == 3)
                {
                    chkUppermost.Checked = false;
                    Applicate.GetWindow<FrmMain>().ShowTip("不能置顶我的设备");
                    return;
                }

                int time = chkUppermost.Checked ? TimeUtils.CurrentIntTime() : 0;
                friend.TopTime = time;
                friend.UpdateTopTime(time);
                Messenger.Default.Send(friend, MessageActions.UPDATE_FRIEND_TOP);
                RequestFriendSetting(friend, 2, chkUppermost.Checked);
                return;
            }
        }



        /// <summary>
        /// 免打扰
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkDisturb_CheckedChanged(object sender, EventArgs e)
        {
            if (state)
            {
                friend.Nodisturb = chkDisturb.Checked ? 1 : 0;
                friend.UpdateNodisturb();
                Messenger.Default.Send(friend, MessageActions.UPDATE_FRIEND_DISTURB);
                RequestFriendSetting(friend, 0, chkDisturb.Checked);
            }
        }

        /// <summary>
        /// 阅后即焚
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBurn_CheckedChanged(object sender, EventArgs e)
        {
            if (state)
            {
                friend.IsOpenReadDel = chkBurn.Checked ? 1 : 0;
                friend.UpdateReadDel();
                Messenger.Default.Send(friend, MessageActions.UPDATE_FRIEND_READDEL);//刷新列表
                RequestFriendSetting(friend, 1, chkBurn.Checked);
            }
        }

        private void RefreshCheckBtnState(Friend friend)
        {
            // 避免触发 Onchecked事件
            state = false;
            chkUppermost.Checked = friend.TopTime != 0;//置顶聊天
            chkDisturb.Checked = friend.Nodisturb == 1; // 消息免打扰
            chkBurn.Checked = friend.IsOpenReadDel == 1; // 阅后即焚
            state = true;


            ChangeEncryptUI(friend.IsEncrypt);



        }

        private void lblLabel_Click(object sender, EventArgs e)
        {
            if (friend.Status == 0)
            {
                HttpUtils.Instance.ShowTip("非好友不能设置好友标签");
                return;
            }

            cmsLabel.Items.Clear();
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friendGroup/list")
                .AddParams("access_token", Applicate.Access_Token)
                .Build().Execute((suss, data) =>
                {
                    if (suss)
                    {
                        JArray array = JArray.Parse(UIUtils.DecodeString(data, "data"));
                        if (array.Count > 0)
                        {
                            foreach (var item in array)
                            {
                                ToolStripMenuItem tool = new ToolStripMenuItem();
                                tool.Name = UIUtils.DecodeString(item, "groupId");
                                tool.Text = UIUtils.LimitTextLength(UIUtils.DecodeString(item, "groupName"), 5, true);
                                if (UIUtils.DecodeString(item, "userIdList").Contains(friend.UserId))
                                {
                                    tool.Checked = true;
                                }
                                List<string> list = new List<string>();
                                JArray useridArray = JArray.Parse(UIUtils.DecodeString(item, "userIdList"));
                                foreach (var userid in useridArray)
                                {
                                    list.Add(userid.ToString());
                                }

                                tool.Tag = list;
                                tool.Click += (sen, eve) =>
                                {
                                    tool.Checked = !tool.Checked;
                                    if (!tool.Checked)
                                    {
                                        list.Remove(friend.UserId);
                                    }
                                    if (tool.Checked)
                                    {
                                        list.Add(friend.UserId);
                                    }
                                    string userIdList = String.Empty;
                                    if (list.Count >= 1)
                                    {
                                        foreach (var userid in list)
                                        {
                                            userIdList += userid + ",";
                                        }

                                        userIdList = userIdList.Remove(userIdList.Length - 1, 1);
                                    }

                                    HttpUtils.Instance.Get()
                                        .Url(Applicate.URLDATA.data.apiUrl + "friendGroup/updateGroupUserList")
                                        .AddParams("access_token", Applicate.Access_Token)
                                        .AddParams("groupId", tool.Name)
                                        .AddParams("userIdListStr", userIdList)
                                        .Build().Execute((susee, datalist) =>
                                        {
                                            if (susee)
                                            {
                                                // 修改禅道9126
                                                if (friend.Status == 0)
                                                {
                                                    friend.InsertData();
                                                }

                                                string ids = "[" + userIdList + "]";
                                                // 修改本地数据库
                                                FriendLabelDao.Instance.UpdateFriendIdListById(tool.Name, ids);

                                                //重新绑定标签数据到控件
                                                bindLable();

                                                // 更新标签页
                                                Messenger.Default.Send("1", MessageActions.UPDATE_LABLE_LIST);

                                                HttpUtils.Instance.ShowTip("设置标签成功");
                                            }
                                        });
                                };
                                cmsLabel.Items.Add(tool);
                            }
                            cmsLabel.Show(lblLabel, lblLabel.Width - cmsLabel.Width, lblLabel.Height);
                        }
                        else
                        {


                            FrmSingleSet frm = new FrmSingleSet();
                            frm = (FrmSingleSet)this.Parent;
                            SingleSet = frm;
                            frm.IsClose = false;
                            FrmMyColleagueEidt frmEidt = new FrmMyColleagueEidt();
                            frmEidt.FormClosed += FrmEidt_FormClosed;
                            frmEidt.ColleagueName((groupName) =>
                            {
                                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friendGroup/add")
                                    .AddParams("access_token", Applicate.Access_Token)
                                    .AddParams("groupName", groupName)
                                    .Build().Execute((suss2, data2) =>
                                    {
                                        if (suss)
                                        {
                                            // 刷新标签页，刷新标签页时会自动去更新数据库的这里就不用了
                                            Messenger.Default.Send("1", MessageActions.UPDATE_LABLE_LIST);

                                            frmEidt.Close();
                                            FrmFriendSelect select = new FrmFriendSelect();
                                            select.LoadFriendsData(new List<RoomMember>() { new RoomMember() { userId = friend.UserId } }, false);
                                            select.TopMost = true;
                                            select.AddConfrmListener((disc) =>
                                            {
                                                string listUserID = friend.UserId + ",";
                                                foreach (var f in disc.Values)
                                                {
                                                    listUserID += f.UserId + ",";
                                                }

                                                listUserID = listUserID.Remove(listUserID.Length - 1, 1);
                                                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friendGroup/updateGroupUserList")
                                                    .AddParams("access_token", Applicate.Access_Token)
                                                    .AddParams("groupId", UIUtils.DecodeString(data2, "groupId"))
                                                    .AddParams("userIdListStr", listUserID)
                                                    .Build().Execute((susee, datalist) =>
                                                    {
                                                        if (susee)
                                                        {
                                                            HttpUtils.Instance.ShowTip("创建成功");
                                                        }
                                                    });
                                            });
                                        }
                                        frm.IsClose = true;
                                    });

                            });

                            string title = LanguageXmlUtils.GetValue("title_create_label", "创建标签");
                            string name = LanguageXmlUtils.GetValue("name_label_name", "标签名称", true);
                            frmEidt.ShowThis(title, name);
                        }

                    }
                });
        }

        private void FrmEidt_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingleSet.IsClose = true;
        }

        private void InviteToGroup(string roomId, string userids)
        {
            HttpUtils.Instance.InitHttp(this);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/member/update")
            .AddParams("access_token", Applicate.Access_Token)
            .AddParams("roomId", roomId)
            .AddParams("text", userids)
            .Build().Execute(null);
        }

        /// <summary>
        /// 保存群成员
        /// </summary>
        /// <param name="_roomId"></param>
        /// <param name="select"></param>
        private void SaveRoomUsers(string _roomId, Dictionary<string, Friend> select)
        {
            List<RoomMember> memberList = new List<RoomMember>();
            foreach (KeyValuePair<string, Friend> a in select)
            {
                RoomMember roomMembers = new RoomMember();
                roomMembers.roomId = _roomId;
                roomMembers.userId = a.Key;
                roomMembers.nickName = a.Value.NickName;
                roomMembers.role = 3;
                roomMembers.talkTime = 0;
                roomMembers.sub = 1;
                roomMembers.offlineNoPushMsg = 0;
                roomMembers.remarkName = a.Value.NickName;

                memberList.Add(roomMembers);
            }

            RoomMember roomMember = new RoomMember() { roomId = _roomId };
            roomMember.AutoInsertOrUpdate(memberList);
        }

        private void picOverdueDate_Click(object sender, EventArgs e)
        {
            lblOverdueDate_Click(sender, e);
        }

        private void picLabel_Click(object sender, EventArgs e)
        {
            lblLabel_Click(sender, e);

        }

        private void lblTwoWay_Click(object sender, EventArgs e)
        {
            FrmSingleSet frm = (FrmSingleSet)this.Parent;
            frm.IsClose = false;
            if (HttpUtils.Instance.ShowPromptBox("确认删除？"))
            {
                ShiKuManager.SendClearFriendMsg(friend);
            }
            frm.IsClose = true;
        }

        /// <summary>
        /// 保存消息免打扰-阅后即焚-置顶状态到服务器
        /// </summary>
        /// <param name="friend"></param>
        /// <param name="type">0== 免打扰 1== 阅后即焚 2== 置顶  </param>
        private void RequestFriendSetting(Friend friend, int type, bool isOpen)
        {
            string topvalue = isOpen ? "1" : "0";

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friends/update/OfflineNoPushMsg")
                   .AddParams("access_token", Applicate.Access_Token)
                   .AddParams("userId", Applicate.MyAccount.userId)
                   .AddParams("toUserId", friend.UserId)
                   .AddParams("type", type.ToString())
                   .AddParams("offlineNoPushMsg", topvalue)
                   .NoErrorTip()
                   .Build().Execute(null);
        }

        private void lblnewsSend_Click(object sender, EventArgs e)
        {

            if (!Applicate.ENABLE_ASY_ENCRYPT)
            {
                cmsnewssendway.Items.RemoveByKey("tspmAES");
                cmsnewssendway.Items.RemoveByKey("tspmPTP");
            }

            cmsnewssendway.Show(lblnewsSend, lblnewsSend.Width - cmsnewssendway.Width, lblnewsSend.Height);
        }


        private void SelectEncryptType(object sender, System.EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            Console.WriteLine("SelectEncryptType:" + item.Name);

            int encryptType = 0;
            switch (item.Name)
            {
                case "tspmDocuments":
                    // 明文传输
                    encryptType = 0;
                    break;
                case "tspmPTP":
                    // 端到端
                    encryptType = 3;
                    break;
                case "tspm3des":
                    // des
                    encryptType = 1;
                    break;
                case "tspmAES":
                    // aes
                    encryptType = 2;
                    break;
                default:
                    break;
            }

            if (!Applicate.ENABLE_ASY_ENCRYPT && encryptType > 1)
            {
                HttpUtils.Instance.ShowTip("当前软件版本不支持此加密方式");
                return;
            }

            // #8464
            if (UIUtils.IsNull(friend.DhPublicKey) || UIUtils.IsNull(friend.RsaPublicKey))
            {
                if (encryptType > 1)
                {
                    HttpUtils.Instance.ShowTip("此好友不能选择该加密方式");
                    return;
                }
            }

            if (UIUtils.IsNull(Applicate.MyAccount.rsaPrivateKey) || UIUtils.IsNull(Applicate.MyAccount.dhPublicKey))
            {
                if (encryptType > 1)
                {
                    HttpUtils.Instance.ShowTip("此好友不能选择该加密方式");
                    return;
                }
            }

            ChangeEncryptUI(encryptType);
            RequestUpdateEncryptType(friend.UserId, encryptType);
        }

        private void ChangeEncryptUI(int isEncrypt)
        {
            if (!Applicate.ENABLE_ASY_ENCRYPT && isEncrypt > 0)
            {
                lblnewsSend.Text = tspm3des.Text;
                return;
            }

            switch (isEncrypt)
            {
                case 0:
                    //lblnewsSend.Text = "明文传输";
                    lblnewsSend.Text = tspmDocuments.Text;
                    break;
                case 1:
                    //lblnewsSend.Text = "3DES加密";
                    lblnewsSend.Text = tspm3des.Text;
                    break;
                case 2:
                    //lblnewsSend.Text = "AES加密";
                    lblnewsSend.Text = tspmAES.Text;
                    break;
                case 3:
                    //lblnewsSend.Text = "端到端加密";
                    lblnewsSend.Text = tspmPTP.Text;
                    break;
                default:
                    break;
            }
        }


        // 修改好友的加密方式
        private void RequestUpdateEncryptType(string userId, int isEncrypt)
        {
            FrmSingleSet frm = (FrmSingleSet)this.Parent;
            frm.IsClose = false;

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friends/modify/encryptType")
             .AddParams("toUserId", userId)
             .AddParams("encryptType", isEncrypt.ToString())
             .NoErrorTip()
             .Build().Execute((state, data) =>
             {
                 frm.IsClose = true;

                 if (state)
                 {
                     friend.IsEncrypt = isEncrypt;
                     friend.UpdateEncrypt(isEncrypt);

                     if (isEncrypt == 3)
                     {
                         MessageObject msg = ShiKuManager.GetMessageObject(friend);
                         msg.type = kWCMessageType.Remind;
                         msg.content = "消息已开启端到端加密";
                         Messenger.Default.Send(msg, MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);
                     }

                 }
             });
        }

        private void lblRemarkPhone_Click(object sender, EventArgs e)
        {

            if (friend.IsDevice())
            {
                Applicate.GetWindow<FrmMain>().ShowTip("我的设备无法使用此功能");
                return;
            }


            FrmFriendDescribe frmFriend = Applicate.GetWindow<FrmFriendDescribe>();
            if (frmFriend == null)
            {
                frmFriend = new FrmFriendDescribe();
                frmFriend.ShowFriend(friend);
                frmFriend.Show();
            }
            else
            {
                frmFriend.Activate();
                frmFriend.ShowFriend(friend);
            }

            //FrmFriendDescribe frmFriend = new FrmFriendDescribe();
            //frmFriend.ShowFriend(friend);
            //frmFriend.Show();
            return;


            FrmSingleSet frm = (FrmSingleSet)this.Parent;
            frm.IsClose = false;
            FrmRemarkPhone frmRemarkPhone = new FrmRemarkPhone();
            frmRemarkPhone.setData(RemarkPhone, friend);
            Point ms = Control.MousePosition;
            //设置弹出窗起始坐标

            frmRemarkPhone.Location = new Point(Control.MousePosition.X, Control.MousePosition.Y);

            frmRemarkPhone.Show();
            frmRemarkPhone.FormClosed += (sen, eve) =>
            {
                frm.IsClose = true;
            };

        }
        public void modifyphone()
        {

            string url = Applicate.URLDATA.data.apiUrl + "friends/modify/phoneRemark";
            HttpUtils.Instance.Get().Url(url)
                            .AddParams("access_token", Applicate.Access_Token)
                            .AddParams("toUserId", friend.UserId)
                            .AddParams("remarkName", lblRemarkPhone.Text)
                            .Build().Execute((suss, data) =>
                            {
                                if (suss)
                                {

                                }
                            });
        }

        private void lblAccount_Click(object sender, EventArgs e)
        {
            //Clipboard.SetText(lblAccount.Text.Trim());
            //Clipboard.SetData( DataFormats.Text,lblAccount.Text.Trim());
            System.Windows.Clipboard.SetText(lblAccount.Text.Trim());
            System.Windows.Clipboard.SetData(DataFormats.Text, lblAccount.Text.Trim());
            Applicate.GetWindow<FrmMain>().ShowTip("在秀号 " + lblAccount.Text.Trim() + " 复制成功");
        }

        private void labelcopy_Click(object sender, EventArgs e)
        {
            System.Windows.Clipboard.SetText(lblAccount.Text.Trim());
            System.Windows.Clipboard.SetData(DataFormats.Text, lblAccount.Text.Trim());
            Applicate.GetWindow<FrmMain>().ShowTip("在秀号 " + lblAccount.Text.Trim() + " 复制成功");
        }

        private void pictureBoxCopy_Click(object sender, EventArgs e)
        {
            System.Windows.Clipboard.SetText(lblAccount.Text.Trim());
            System.Windows.Clipboard.SetData(DataFormats.Text, lblAccount.Text.Trim());
            Applicate.GetWindow<FrmMain>().ShowTip("在秀号 " + lblAccount.Text.Trim() + " 复制成功");
        }
    }
}
