using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;
using WinFrmTalk.socket;
using WinFrmTalk.View;

namespace WinFrmTalk
{

    public partial class FrmFriendsBasic : FrmSuspension
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

        public string FromAddType;//允许添加我的方式

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            lblSex_text.Text = LanguageXmlUtils.GetValue("sex", lblSex_text.Text);
            lblRemarkName_text.Text = LanguageXmlUtils.GetValue("remark_name", lblRemarkName_text.Text);
            lblAddress_text.Text = LanguageXmlUtils.GetValue("address", lblAddress_text.Text);
            lblBirthday_text.Text = LanguageXmlUtils.GetValue("birthday", lblBirthday_text.Text);
            lblAccountIM_text.Text = LanguageXmlUtils.GetValue("account_IM", lblAccountIM_text.Text);
        }

        public FrmFriendsBasic()
        {
            InitializeComponent();
            LoadLanguageText();
            if (Applicate.URLDATA.data.isOpenPositionService == 1)
            {
                lblRemarkName_text.Location = lblAddress_text.Location;
                lblRemarks.Location = lblLocation.Location;
                txtRemarks.Location = lblLocation.Location;
                lblAddress_text.Visible = false;
                lblLocation.Visible = false;
            }

            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
                                                                          //Control.CheckForIllegalCrossThreadCalls = false;
            picQRCode.Visible = false;
            picCard.Visible = false;
            picSendMsg.Visible = false;
            picAddFirend.Visible = false;
        }


        public FrmSMPGroupSet frmSMP { get; set; }
        public Friend friend { get; set; }//朋友类

        #region 修改备注

        /// <summary>
        /// 点击备注切换到可修改状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRemarks_Click(object sender, EventArgs e)
        {
            txtRemarks.Text = "";
            if (lblRemarks.Text != "点击添加备注")
            {
                txtRemarks.Text = lblRemarks.Text;
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
        /// 按回车提交修改的备注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtRemarks_Leave(sender, e);
            }
        }

        /// <summary>
        /// 修改好友备注
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
                                friend.UpdateRemarkName();
                                lblNickname.Text = friend.NickName;
                                Messenger.Default.Send(friend, MessageActions.UPDATE_FRIEND_REMARKS);
                                lblRemarks.Text = (txtRemarks.Text == "" ? "点击添加备注" : txtRemarks.Text);
                                LogUtils.Log("修改备注状态：" + suss);
                                txtRemarks.Text = "";
                            }
                        });
                }
                txtRemarks.Visible = false;
            }
        }

        #endregion


        // 显示一个用户的信息通过id
        public void ShowUserInfoById(string userId)
        {
            FromAddType = "2";
            ChangeFormLocation();

            if (Applicate.MyAccount.userId.Equals(userId))
            {
                RequestSelfInfo();
            }
            else
            {
                Friend lacal = new Friend() { UserId = userId }.GetByUserId();
                if (!UIUtils.IsNull(lacal.NickName))
                {
                    friend = lacal;
                    FillDataByView(friend);
                    Show();
                }
                RequestUserInfo(userId);
            }
        }


        // 显示一个群成员信息
        internal void ShowUserInfoByRoom(string userid, string roomjid, int role)
        {
            FromAddType = "3";
            ChangeFormLocation();

            if (Applicate.MyAccount.userId.Equals(userid))
            {
                RequestSelfInfo();
            }
            else
            {
                Friend grouop = new Friend { UserId = roomjid, IsGroup = 1, AllowSendCard = 1 }.GetByUserId();//获取群

                RequestUserInfo(userid, grouop.AllowSendCard, role);
            }
        }

        // 显示一个公众号的信息
        public void ShowOAInfoById(string userId)
        {
            FromAddType = "6";
            ChangeFormLocation();

            if (Applicate.MyAccount.userId.Equals(userId))
            {
                RequestSelfInfo();
            }
            else
            {
                Friend lacal = new Friend() { UserId = userId }.GetByUserId();
                if (!UIUtils.IsNull(lacal.NickName))
                {
                    friend = lacal;
                    FillDataByView(friend);
                    Show();
                }
                RequestUserInfo(userId);
            }
        }

        private void RequestUserInfo(string userId, int allsendCard = -1, int role = -1)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/get")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", userId)
                .Build().Execute((suus, data) =>
                {
                    if (suus)
                    {
                        //使用Friend解析出来
                        Friend jsonFriend = JsonConvert.DeserializeObject<Friend>(JsonConvert.SerializeObject(data));

                        bool isneedupdate = false;
                        if (data.ContainsKey("friends"))
                        {
                            //使用字典解析出来
                            Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(UIUtils.DecodeString(data, "friends"));
                            jsonFriend.RemarkName = UIUtils.DecodeString(dic, "remarkName");

                            if (UIUtils.DecodeInt(dic, "isBeenBlack") == 1)
                            {
                                jsonFriend.Status = Friend.STATUS_19;
                            }
                            else
                            {
                                jsonFriend.Status = UIUtils.DecodeInt(dic, "status");
                            }

                            if (friend != null && !string.Equals(jsonFriend.RemarkName, friend.RemarkName))
                            {
                                friend.RemarkName = jsonFriend.RemarkName;
                                friend.UpdateRemarkName();
                                isneedupdate = true;
                            }
                        }

                        if (friend != null)
                        {
                            if (!jsonFriend.NickName.Equals(friend.NickName))
                            {
                                isneedupdate = true;
                                friend.NickName = jsonFriend.NickName;
                                friend.UpdateNickName();
                            }
                        }

                        if (isneedupdate)
                        {
                            Messenger.Default.Send(friend, MessageActions.UPDATE_FRIEND_REMARKS);
                        }

                        jsonFriend.AccountId = UIUtils.DecodeString(data, "account");
                        jsonFriend.IsOnLine = UIUtils.DecodeInt(data, "onlinestate");

                        bool isShow = friend == null;
                        friend = jsonFriend;

                        //好友在线状态
                        //好友在线状态
                        ChangeXmppState(friend.IsOnLine == 1 ? SocketConnectionState.Authenticated : SocketConnectionState.Disconnected);
                        //绑定数据到控件上
                        FillDataByView(jsonFriend, allsendCard, role, true);
                        if (isShow)
                        {
                            this.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("数据获取失败");
                    }
                });
        }


        private void RequestSelfInfo()
        {
            if (IsDisposed)
            {
                return;
            }

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/get")
                .AddParams("access_token", Applicate.Access_Token)
                .Build().Execute((suus, data) =>
                {
                    if (IsDisposed)
                    {
                        return;
                    }

                    if (suus)
                    {
                        //使用Friend解析出来
                        Friend jsonFriend = JsonConvert.DeserializeObject<Friend>(JsonConvert.SerializeObject(data));
                        Applicate.MyAccount.nickname = jsonFriend.NickName;
                        if (data.ContainsKey("friends"))
                        {
                            //使用字典解析出来
                            Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(UIUtils.DecodeString(data, "friends"));
                            jsonFriend.RemarkName = UIUtils.DecodeString(dic, "remarkName");
                            jsonFriend.Status = UIUtils.DecodeInt(dic, "status");
                        }

                        jsonFriend.AccountId = UIUtils.DecodeString(data, "account");
                        bool isShow = friend == null;
                        friend = jsonFriend;

                        //好友在线状态
                        var state = ShiKuManager.GetXmppState();
                        ChangeXmppState(state);

                        FillDataByView(jsonFriend, -1, -1, true);//绑定数据到控件上

                        if (isShow && !this.IsDisposed)
                        {
                            this.Show();
                        }
                        if (!UIUtils.IsNull(friend.AccountId))
                        {
                            friend.UpdateAccountId(this.friend.AccountId);
                        }


                    }
                    else
                    {
                        MessageBox.Show("数据获取失败");
                    }
                });
        }


        private void FillDataByView(Friend friend, int allsendCard = -1, int role = -1, bool refreshHead = false)
        {

            if (string.Equals(friend.UserId, "10000"))
            {
                // 系统号
                Bitmap image = Resources.avatar_notice;
                picHead.BackgroundImage = image;

            }
            else
            {
                // 显示头像
                string headUrl = ImageLoader.Instance.GetHeadUrl(friend.UserId);

                //设置头像
                ImageLoader.Instance.DisplayAvatar(friend.UserId, null, true, (bitmap) =>
                {
                    //发送刷新头像通知
                    if (refreshHead)
                    {
                        Messenger.Default.Send(friend.UserId, MessageActions.UPDATE_HEAD);
                    }
                    picHead.Image = bitmap;

                }, friend.GetRemarkName());
            }


            //跟该用户的关系
            if (friend.UserType == 2)   //公众号
            {
                OfficalAccountState(friend);
            }
            else if (allsendCard == -1 && role == -1)
            {
                FriendState(friend);
            }
            else
            {
                FriendState(friend, allsendCard, role);
            }


            // 昵称
            if (!UIUtils.IsNull(friend.NickName))
            {
                lblNickname.Text = friend.NickName;
            }

            // 备注
            if (!UIUtils.IsNull(friend.RemarkName))
            {
                lblRemarks.Text = UIUtils.LimitTextLength(friend.RemarkName, 10, false);
            }
            else
            {
                lblRemarks.Text = "点击添加备注";
            }

            // 性别
            lblSex.Text = friend.Sex == 1 ? "男" : "女";

            // 生日
            lblBirthday.Text = TimeUtils.FromatTime(friend.Birthday, "yyyy/MM/dd");

            // 所在地
            string address = string.Empty;
            Areas areas = new Areas();
            areas.id = friend.CityId;
            areas = areas.GetModel();
            address = areas.name;
            areas.id = areas.parent_id;
            areas = areas.GetModel();
            address = areas.name + address;

            if (UIUtils.IsNull(address))
            {
                lblLocation.Text = "未知";
            }
            else
            {
                lblLocation.Text = address;
            }

            // 通讯号
            lblAccount.Text = friend.AccountId;
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

        }

        /// <summary>
        /// 判断跟该公众号的关系
        /// </summary>
        /// <param name="user"></param>
        public void OfficalAccountState(Friend user)
        {
            Friend f = new Friend();
            f.UserId = Applicate.MyAccount.userId;
            f = f.GetByUserId();

            f.UpdateAccountId(Applicate.MyAccount.userId);

            //1.user与当前用户是好友关系 2.user与当前用户是非好友关系（是否在黑名单里面）

            this.SuspendLayout();
            //群内是否允许好友私聊
            if (user.Status == 2)//好友关系
            {
                picQRCode.Visible = true;
                picCard.Visible = true;
                picSendMsg.Visible = true;
                picAddFirend.Visible = false;//加好友

            }
            else//非好友关系
            {
                if (user.Status == 18 || user.Status == 19 || user.Status == -1)
                {
                    picQRCode.Visible = false;
                    picCard.Visible = false;
                    picSendMsg.Visible = false;
                    picAddFirend.Visible = false;
                }

                else
                {
                    picQRCode.Visible = true;
                    picCard.Visible = true;
                    picSendMsg.Visible = false;
                    picAddFirend.Visible = true;

                }

                lblAccountIM_text.Location = lblBirthday_text.Location;
                lblAccount.Location = lblBirthday.Location;
                lblBirthday_text.Location = lblAddress_text.Location;
                lblBirthday.Location = lblLocation.Location;
                lblAddress_text.Location = lblRemarkName_text.Location;
                lblLocation.Location = lblRemarks.Location;
                lblRemarkName_text.Visible = false;
                lblRemarks.Visible = false;
                txtRemarks.Visible = false;
                this.Size = new Size(320, 270);
            }
            if (user.Status == 2 || user.Status == 4 && user.IsBlackUser(user.UserId) == 0 && user.Status != -1)//是好友关系
            {
                picAddFirend.Visible = false;
            }
            this.ResumeLayout();
        }

        /// <summary>
        /// 判断跟该用户的关系
        /// </summary>
        /// <param name="user"></param>
        public void FriendState(Friend user)
        {
            if (user.UserId.Equals(Applicate.MyAccount.userId))
            {
                lblRemarks.Enabled = false;
                lblRemarks.Visible = false;
                lblRemarkName_text.Visible = false;
                lblAccountIM_text.Location = lblBirthday_text.Location;
                lblAccount.Location = lblBirthday.Location;
                lblBirthday_text.Location = lblAddress_text.Location;
                lblBirthday.Location = lblLocation.Location;
                lblAddress_text.Location = lblRemarkName_text.Location;
                lblLocation.Location = lblRemarks.Location;
                picSendMsg.Visible = false;
                picAddFirend.Visible = false;
                this.Size = new System.Drawing.Size(320, 270);
                return;
            }


            Console.WriteLine("Status " + user.Status);
            if (user.Status == 2 || user.Status == 4 && user.IsBlackUser(user.UserId) == 0)//是好友关系
            {
                picQRCode.Visible = true;
                picCard.Visible = true;
                picSendMsg.Visible = true;
                picAddFirend.Visible = false;
                return;
            }

            if (user.IsBlackUser(user.UserId) != 0)
            {
                picQRCode.Visible = false;
                picCard.Visible = false;
                picSendMsg.Visible = false;
                picAddFirend.Visible = false;
            }
            else//非好友关系
            {
                picQRCode.Visible = false;
                picCard.Visible = false;
                picSendMsg.Visible = false;
                lblAccountIM_text.Location = lblBirthday_text.Location;
                lblAccount.Location = lblBirthday.Location;
                lblBirthday_text.Location = lblAddress_text.Location;
                lblBirthday.Location = lblLocation.Location;
                lblAddress_text.Location = lblRemarkName_text.Location;
                lblLocation.Location = lblRemarks.Location;
                lblRemarkName_text.Visible = false;
                lblRemarks.Visible = false;
                txtRemarks.Visible = false;
                this.Size = new Size(320, 270);
            }
        }

        public void FriendState(Friend user, int sendtocard, int role)
        {
            Friend f = new Friend();
            f.UserId = Applicate.MyAccount.userId;
            f = f.GetByUserId();

            f.UpdateAccountId(Applicate.MyAccount.userId);

            //1.user与当前用户是好友关系 2.user与当前用户是非好友关系（是否在黑名单里面）


            //群内是否允许好友私聊
            if (user.ExistsFriend() && user.Status != -1)//好友关系
            {

                if (sendtocard == 0 && role != 1)//不允许私聊
                {
                    picQRCode.Visible = false;
                    picCard.Visible = false;
                    picSendMsg.Visible = false;
                    picAddFirend.Visible = false;
                }
                else//允许私聊
                {
                    picQRCode.Visible = true;
                    picCard.Visible = true;
                    picSendMsg.Visible = true;
                    picAddFirend.Visible = false;//加好友
                }

            }
            else//非好友关系
            {
                if (sendtocard == 0 && role != 1)
                {
                    picQRCode.Visible = false;
                    picCard.Visible = false;
                    picSendMsg.Visible = false;
                    picAddFirend.Visible = false;
                }
                else
                {
                    if (user.Status == 18 || user.Status == 19 || user.Status == -1)
                    {
                        picQRCode.Visible = false;
                        picCard.Visible = false;
                        picSendMsg.Visible = false;
                        picAddFirend.Visible = false;
                    }

                    else
                    {
                        picQRCode.Visible = true;
                        picCard.Visible = false; // 非好友关系不允许发名片
                        picSendMsg.Visible = false;
                        picAddFirend.Visible = true;

                    }


                }

                lblAccountIM_text.Location = lblBirthday_text.Location;
                lblAccount.Location = lblBirthday.Location;
                lblBirthday_text.Location = lblAddress_text.Location;
                lblBirthday.Location = lblLocation.Location;
                lblAddress_text.Location = lblRemarkName_text.Location;
                lblLocation.Location = lblRemarks.Location;
                lblRemarkName_text.Visible = false;
                lblRemarks.Visible = false;
                txtRemarks.Visible = false;
                this.Size = new Size(320, 270);
            }

            if (user.Status == 2 || user.Status == 4 && user.IsBlackUser(user.UserId) == 0 && user.Status != -1)//是好友关系
            {
                picAddFirend.Visible = false;
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
            string str = string.Empty;
            switch (view.Name)
            {
                case "picQRCode":
                    str = LanguageXmlUtils.GetValue("QR_code", "二维码");
                    break;
                case "picCard":
                    str = LanguageXmlUtils.GetValue("send_card", "发送名片");
                    break;
                case "picSendMsg":
                    str = LanguageXmlUtils.GetValue("send_msg", "发消息");
                    break;
                case "picAddFirend":
                    if (FromAddType.Equals("6"))
                    {
                        str = LanguageXmlUtils.GetValue("add_offical_account", "添加公众号");
                    }
                    else
                    {
                        str = LanguageXmlUtils.GetValue("add_friend", "加好友");
                    }

                    break;
                default:
                    str = "";
                    break;
            }

            toolTip1.SetToolTip(view, str);
        }

        // 四个按钮鼠标离开颜色
        private void picQRCode_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.White;
        }




        /// <summary>
        /// 打开二维码图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picQRCode_Click(object sender, EventArgs e)
        {
            FrmQRCode frm = new FrmQRCode();
            Control parent = HttpUtils.Instance.GetControl();
            if (parent.Name == "useGroupSet1")
            {

                frm.Location = this.frmSMP.Location;

            }
            else
            {
                frm.Location = frm.Location = new Point(parent.Location.X + (parent.Width - frm.Width) / 2, parent.Location.Y + (parent.Height - frm.Height) / 2);//居中

            }
            frm.FriendShow(this.friend.UserId, this.friend.GetFriendInfoId());
            frm.IsClose = true;
            this.IsClose = true;
            this.Close();
        }



        // 发送名片
        private void picCard_Click(object sender, EventArgs e)
        {
            var friend = new FrmFriendSelect();
            friend.LoadFriendsData(1);
            friend.AddConfrmListener((UserFriends) =>
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

                    MessageObject card_msg = ShiKuManager.SendCardMessage(userFriend.Value, this.friend);
                    LogUtils.Log("发送名片给：" + userFriend.Value.UserId);
                    //添加气泡到当前的聊天对象
                    Messenger.Default.Send(card_msg, MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);
                }
            });

        }


        // 添加好友
        private void picAddFirend_Click(object sender, EventArgs e)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + ApplicateConst.AddFriend)
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("fromAddType", FromAddType)
                .NoErrorTip()
                .AddParams("toUserId", friend.UserId).Build()
                .AddErrorListener((sta, code) =>
                {
                    HttpUtils.Instance.FindFrm(typeof(FrmMain)).ShowTip(code);
                })
                .ExecuteJson<Attention>((isSuccessed, result) =>
                {
                    if (isSuccessed)
                    {
                        var y = friend.InsertAuto();

                        // 类型为2或4时均可直接成为好友
                        if (result.type == 2 || result.type == 4)
                        {
                            // 发送508成为好友消息,,在此之后，需要设置按钮禁用并显示"已和xxx成为好友"
                            ShiKuManager.SendBecomeFriendMsg(friend);
                            // 成为好友后刷新名片页面
                            this.Size = new Size(320, 312);
                            picQRCode.Visible = true;
                            picCard.Visible = true;
                            picSendMsg.Visible = true;
                            lblRemarkName_text.Location = lblAddress_text.Location;
                            lblRemarkName_text.Visible = true;
                            lblRemarks.Visible = false;
                            lblRemarks.Text = "点击添加备注";
                            txtRemarks.Visible = false;
                            lblAddress_text.Location = lblBirthday_text.Location;
                            lblBirthday_text.Location = lblAccountIM_text.Location;
                            lblAccountIM_text.Location = new Point(39, 208);
                            picAddFirend.Visible = false;
                        }
                        else
                        {
                            // 发送好友请求消息
                            ShiKuManager.SendHelloFriendMsg(friend);
                            // 等待验证
                            HttpUtils.Instance.ShowPromptBox("等待验证");
                        }
                    }
                });
        }


        // 发消息
        private void picSendMsg_Click(object sender, EventArgs e)
        {
            if (frmSMP != null)
            {
                frmSMP.Close();
            }
            this.Close();
            Messenger.Default.Send(friend, FrmMain.START_NEW_CHAT);
        }



        public Color Statebrg = Color.Gray;


        /// <summary>
        /// 个人在线状态
        /// </summary>
        /// <param name="state"></param>
        private void ChangeXmppState(SocketConnectionState state)
        {
            LogUtils.Log("ChangeXmppState" + state);
            switch (state)
            {
                case SocketConnectionState.Authenticated:
                    Statebrg = ColorTranslator.FromHtml("#0AD007");// 变绿色 - 在线
                    this.picHead.Refresh();
                    break;
                case SocketConnectionState.Disconnected:
                    Statebrg = ColorTranslator.FromHtml("#BBBBBB"); // 变灰色 - 离线
                    this.picHead.Refresh();
                    break;
                default:
                    Statebrg = Color.Yellow;// 变黄色 - 连接中
                    this.picHead.Refresh();
                    break;

            }
        }

        // 绘制头像在线状态
        private void picHead_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawEllipse(new Pen(Statebrg), new Rectangle(40, 40, 14, 14));
            Brush b = new SolidBrush(Statebrg);
            g.FillEllipse(b, new Rectangle(40, 40, 14, 14));
        }


        // 头像点击
        private void picHead_Click(object sender, EventArgs e)
        {
            string headUrl = ImageLoader.Instance.GetHeadUrl(friend.UserId, false);

            if (!friend.IsNormalUser())
            {
                headUrl = friend.UserId;
            }

            var lookImage = Applicate.GetWindow<FrmLookImage>();
            if (lookImage == null)
            {
                FrmLookImage frm = new FrmLookImage();
                frm.ShowImage(headUrl);
            }
            else
            {
                lookImage.Activate();
                lookImage.WindowState = FormWindowState.Normal;
                lookImage.ShowImage(headUrl);
            }

        }


    }
}
