using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.Model.dao;
using WinFrmTalk.View;

namespace WinFrmTalk
{

    /// <summary>
    /// 群信息项
    /// </summary>
    public partial class FrmGroupBasic : FrmSuspension
    {
        #region 双缓冲
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        public bool isMember;
        public bool isOfficial;
        public string RoomId;//
        public double ChargeMoney;//

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;
        }

        public FrmGroupBasic()
        {
            InitializeComponent();
            LoadLanguageText();

            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);
        }

        // 改变窗口位置
        private void ChangeFormLocation()
        {
            int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
            int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;

            int currtx = Control.MousePosition.X;
            int currty = Control.MousePosition.Y;


            if (currtx + this.Width >= iActulaWidth)
            {
                currtx = currtx - this.Width;// (currtx + this.Width - iActulaWidth + 5);

            }

            if (currty + this.Height >= iActulaHeight)
            {
                currty = currty - this.Height + 40;// (currty + this.Height - iActulaHeight + 40);
            }
            this.Location = new Point(currtx, currty);
            this.Show();

        }

        // 显示一个用户的信息通过id
        public void ShowGroupInfoById(string roomId)
        {
            this.RoomId = roomId;
            ChangeFormLocation();

            //将数据保存
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/getRoom") //获取群详情
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", roomId)
                .Build()
                .Execute((success, result) =>
                {
                    if (success)
                    {
                        // 数据解析
                        var jid = UIUtils.DecodeString(result, "jid");
                        var name = UIUtils.DecodeString(result, "name");
                        var groupId = UIUtils.DecodeString(result, "groupId");
                        var userSize = UIUtils.DecodeInt(result, "userSize");
                        var type = UIUtils.DecodeInt(result, "type");
                        var desc = UIUtils.DecodeString(result, "desc");
                        isMember = result.ContainsKey("member");
                        isOfficial = type == 2;
                        ChargeMoney = UIUtils.DecodeDouble(result, "chargeMoney");

                        this.lblNickname.Text = name;
                        this.tvCount.Text = String.Concat(userSize, "人");
                        this.tvNumber.Text = groupId;
                        this.tvDescript.Text = desc;
                        ImageLoader.Instance.DisplayGroupAvatar(jid, roomId, picHead);

                        // 设置按钮功能
                        ChangeButton(isMember, isOfficial);

                        var friend = FriendDao.Instance.GetFriendByRoomId(roomId);
                        if (friend == null)
                        {
                            friend = new Friend();
                            friend.UserId = jid;
                            friend.RoomId = roomId;
                            friend.NickName = name;

                            friend.TransToMember(result);
                            if (isMember)
                            {
                                friend.Status = 2;
                            }
                            friend.InsertData();
                        }

                    }
                });
        }

        /// <summary>
        /// 判断跟该用户的关系
        /// </summary>
        /// <param name="user"></param>
        public void ChangeButton(bool isMember, bool isOfficial)
        {
            // 是群成员
            if (isMember)
            {
                toolTip1.SetToolTip(btnJoin, "发送消息");
                btnJoin.Image = WinFrmTalk.Properties.Resources.sendmsg;
            }
            else
            {
                toolTip1.SetToolTip(btnJoin, "加入群组");
                btnJoin.Image = WinFrmTalk.Properties.Resources.ic_basic_group_add;
            }


            if (isOfficial)
            {
                btnJoin.Visible = false;
                btnEqcode.Visible = false;
            }
        }



        public bool isDeactivate;

        private void FrmFriendsBasic_Deactivate(object sender, EventArgs e)
        {
            if (isDeactivate)
            {
                this.Dispose();
                this.Close();
            }
            isDeactivate = true;
        }


        // 四个按钮鼠标悬浮颜色
        private void picQRCode_MouseEnter(object sender, EventArgs e)
        {
            var view = sender as Control;
            view.BackColor = Color.WhiteSmoke;
        }

        // 四个按钮鼠标离开颜色
        private void picQRCode_MouseLeave(object sender, EventArgs e)
        {
            var view = sender as Control;
            view.BackColor = Color.White;
        }


        /// <summary>
        /// 打开二维码图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picQRCode_Click(object sender, EventArgs e)
        {
            FrmQRCode frm = new FrmQRCode();
            var parent = Applicate.GetWindow<FrmMain>();
            frm.Location = frm.Location = new Point(parent.Location.X + (parent.Width - frm.Width) / 2, parent.Location.Y + (parent.Height - frm.Height) / 2);//居中
            frm.RoomShow(this.RoomId);
            frm.IsClose = true;
            this.IsClose = true;
            this.Close();
        }



        // 发送名片
        private void picCard_Click(object sender, EventArgs e)
        {
            return;
            var frm = new FrmFriendSelect();
            frm.LoadFriendsData(1);
            frm.AddConfrmListener((UserFriends) =>
            {
                foreach (var userFriend in UserFriends)
                {

                    if (userFriend.Value.IsGroup == 1)
                    {
                        if (ShiKuManager.SendRoomMsgVerify(userFriend.Value))
                        {
                            HttpUtils.Instance.ShowTip(userFriend.Value.NickName + " 禁言状态,不能发名片");
                            continue;
                        }

                        if (userFriend.Value.AllowSendCard == 0)
                        {
                            HttpUtils.Instance.ShowTip(userFriend.Value.NickName + " 不允许群成员私聊,不能发名片");
                            continue;
                        }
                    }

                    Friend friend1 = FriendDao.Instance.GetFriendByRoomId(this.RoomId);

                    MessageObject card_msg = ShiKuManager.SendCardMessage(userFriend.Value, friend1);
                    LogUtils.Log("发送名片给：" + userFriend.Value.UserId);
                    //添加气泡到当前的聊天对象
                    Messenger.Default.Send(card_msg, MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);
                }
            });

        }


        // 添加好友
        private void picAddFirend_Click(object sender, EventArgs e)
        {
            Friend friend = FriendDao.Instance.GetFriendByRoomId(this.RoomId);

            if (isMember)
            {
                SendMessage(friend);
            }
            else
            {
                JoinRoom(friend);
            }
        }


        // 发消息
        private void SendMessage(Friend friend)
        {
            this.Close();

            Messenger.Default.Send(friend, FrmMain.START_NEW_CHAT);
        }

        // 加入群组
        private void JoinRoom(Friend friend)
        {
            if (ChargeMoney > 0)
            {
                HttpUtils.Instance.ShowPromptBox("此群为收费群，请前往APP操作");
                return;
            }

            // 是否需要群主验证
            if (friend.IsNeedVerify == 1)
            {
                // 先去获取群主，然后给群主发加群验证消息
                RequestRoomCreate(friend.RoomId);
            }
            else
            {
                RequestJoinRoom(friend);
            }
        }

        #region 获取群主

        public void RequestJoinRoom(Friend friend)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/join")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", friend.RoomId)
                .AddParams("type", "2")
                .Build().Execute((sucess, result) =>
                {
                    if (sucess)
                    {
                        this.isMember = true;
                        ChangeButton(isMember, isOfficial);

                        var frm = Applicate.GetWindow<FrmMain>();
                        frm.ShowTip("加入成功");
                    }
                });
        }

        public void RequestRoomCreate(string roomId)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/getRoom") //获取群详情
               .AddParams("access_token", Applicate.Access_Token)
               .AddParams("roomId", roomId)
               .AddParams("pageSize", "5")
               .Build()
               .Execute((sccess, roomlst) =>
               {
                   if (sccess)
                   {
                       string admins = UIUtils.DecodeString(roomlst, "members");
                       string roomJid = UIUtils.DecodeString(roomlst, "jid");

                       List<Member> members = JsonConvert.DeserializeObject<List<Member>>(admins);

                       foreach (var mem in members)
                       {
                           if (mem.role == 1)
                           {
                               SendJoinVerifyMessage(mem.ToFriend(), roomJid);
                               return;
                           }
                       }
                   }
               });
        }

        // 发送验证消息
        private void SendJoinVerifyMessage(Friend roomCreate, string roomJid)
        {
            var frmROOMVerify = new FrmROOMVerify();
            frmROOMVerify.ShowDialog();

            if (frmROOMVerify.DialogResult == DialogResult.OK)
            {
                string Reson = frmROOMVerify.textReson.Text;//邀请好友的原因
                Friend friend = new Friend { UserId = Applicate.MyAccount.userId, NickName = Applicate.MyAccount.nickname };//邀请的好友
                friend = friend.GetByUserId();

                List<Friend> friendlst = new List<Friend>();//添加好友的集合
                friendlst.Add(friend);

                //获取群主
                ShiKuManager.SendRoomverification(roomCreate, friendlst, Reson, roomJid);//发消息

                this.Close();

                var frm = Applicate.GetWindow<FrmMain>();
                frm.ShowTip("已发送入群申请，请等待群组确认");
            }
        }
        #endregion
    }
}
