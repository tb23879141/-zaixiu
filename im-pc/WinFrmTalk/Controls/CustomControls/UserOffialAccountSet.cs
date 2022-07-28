using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.Helper.MVVM;
using WinFrmTalk.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WinFrmTalk.Model.dao;


namespace WinFrmTalk.Controls.CustomControls
{
    public partial class UserOffialAccountSet : UserControl
    {
        private string nickname = string.Empty;

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            lblOverdueTime.Text = LanguageXmlUtils.GetValue("msg_overdue_time", lblOverdueDate.Text);
            lblClear.Text = LanguageXmlUtils.GetValue("both-way_clear_chat_history", lblClear.Text);
            lblTop.Text = LanguageXmlUtils.GetValue("top_chat", lblTop.Text);
            lblNoDisturbing.Text = LanguageXmlUtils.GetValue("no_disturbing", lblNoDisturbing.Text);
            lblReadDel.Text = LanguageXmlUtils.GetValue("read_delete", lblReadDel.Text);
            btnClearRecord.Text = LanguageXmlUtils.GetValue("btn_clear_chat_history", btnClearRecord.Text);
            btndeleatefriend.Text = LanguageXmlUtils.GetValue("btn_unfollowing", btndeleatefriend.Text);
            tsmHour.Text = LanguageXmlUtils.GetValue("one_hour", tsmHour.Text); 
            tsmDay.Text = LanguageXmlUtils.GetValue("one_day", tsmDay.Text);
            tsmWeek.Text = LanguageXmlUtils.GetValue("one_week", tsmWeek.Text);
            tsmMonth.Text = LanguageXmlUtils.GetValue("one_month", tsmMonth.Text);
            tsmSeason.Text = LanguageXmlUtils.GetValue("one_season", tsmSeason.Text);
            tsmYear.Text = LanguageXmlUtils.GetValue("one_year", tsmYear.Text);
            tsmForever.Text = LanguageXmlUtils.GetValue("permanent", tsmForever.Text);
        }

        public UserOffialAccountSet()
        {
            InitializeComponent();
            LoadLanguageText();
        }
        public Friend friend;
        FrmOfficalAccountSet SingleSet;


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

            if(friend.UserId == "10000")
            {
                btndeleatefriend.Visible = false;
            }
            //我的设备
            if (friend.IsDevice())
            {
                panel1.Visible = false;
              
                lblOverdueDate.Visible = false;
                picOverdueDate.Visible = false;

               
                btndeleatefriend.Click -= lblDeleteFriend_Click;
               
                btndeleatefriend.Visible = false;
               
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
                       ImageLoader.Instance.DisplayAvatar(friend.UserId, picHead);
                       lblNickname.Text = friend.NickName;
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
        /// 清除聊天记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClearRecord_Click(object sender, EventArgs e)
        {
            FrmOfficalAccountSet frm = (FrmOfficalAccountSet)this.Parent;
            frm.IsClose = false;
            if (HttpUtils.Instance.ShowPromptBox("确认删除聊天记录？"))
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
            FrmOfficalAccountSet frm = new FrmOfficalAccountSet();
            frm = (FrmOfficalAccountSet)this.Parent;
            frm.IsClose = false;
            if (HttpUtils.Instance.ShowPromptBox("确认不再关注该公众号？"))
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friends/delete")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("toUserId", friend.UserId)
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            ShiKuManager.SendDelFriendMsg(friend);
                            LogUtils.Log("取消关注成功");
                        }
                        else
                        {
                            LogUtils.Log("取消关注失败");
                        }
                    });
            }
            frm.IsClose = true;
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
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("permanent", tsmForever.Text);
                    save = "0";
                    break;
                case "0":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("permanent", tsmForever.Text);
                    break;
                case "0.04":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_hour", tsmHour.Text);
                    break;
                case "1":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_day", tsmDay.Text);
                    break;
                case "7":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_week", tsmWeek.Text);
                    break;
                case "30":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_month", tsmMonth.Text);
                    break;
                case "90":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_season", tsmSeason.Text);
                    break;
                case "365":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_year", tsmYear.Text);
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
            
        }
        private void picOverdueDate_Click(object sender, EventArgs e)
        {
            lblOverdueDate_Click(sender, e);
        }
        private void lblTwoWay_Click(object sender, EventArgs e)
        {
            var frm = (FrmOfficalAccountSet)this.Parent;
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
        
    }
}
