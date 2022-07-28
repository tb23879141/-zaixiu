using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Helper;
using WinFrmTalk.Model;
using WinFrmTalk.View.list;

namespace WinFrmTalk.View
{

    public partial class FrmMagent : FrmBase
    {
        #region 变量
        /// <summary>
        /// 当前选中的项
        /// </summary>
        private USEMange SelectItems;
        /// <summary>
        /// 上次选中的项
        /// </summary>
        private USEMange BeforeItem;

        /// <summary>
        /// 当前账号的角色
        /// </summary>
        public int Role;
        /// <summary>
        /// 等待符
        /// </summary>
        private LodingUtils loding;

        /// <summary>
        /// 禁言时间
        /// </summary>
        private long TalkTime = 0;

        /// <summary>
        /// friend类
        /// </summary>
        private Friend mfriend;

        /// <summary>
        /// 群成员list集合
        /// </summary>
        private List<RoomMember> memberLst = new List<RoomMember>();

        /// <summary>
        /// 群成员列表适配器
        /// </summary>
        private MemberMangeListAdapter mAdapter;

        #endregion

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            this.Text = LanguageXmlUtils.GetValue("frmMagent_title", this.Text);
            lblMember.Text = LanguageXmlUtils.GetValue("member", lblMember.Text);
            lblGroupCard.Text = LanguageXmlUtils.GetValue("group_card", lblGroupCard.Text);
            lblMemberTable.Text = LanguageXmlUtils.GetValue("group_member_table", lblMemberTable.Text);
            lblpublic.Text = LanguageXmlUtils.GetValue("public_group", lblpublic.Text);
            lblSilence.Text = LanguageXmlUtils.GetValue("all_silence", lblSilence.Text);
            lblReadPerson.Text = LanguageXmlUtils.GetValue("show_read_person", lblReadPerson.Text);
            lblInviteVerification.Text = LanguageXmlUtils.GetValue("group_invite_verification", lblInviteVerification.Text);
            lblReduce.Text = LanguageXmlUtils.GetValue("group_reduce", lblReduce.Text);
            lblPrivateChat.Text = LanguageXmlUtils.GetValue("can_private_chat", lblPrivateChat.Text);
            lblCanInviteFd.Text = LanguageXmlUtils.GetValue("can_invite_fd", lblCanInviteFd.Text);
            lblCanShowMember.Text = LanguageXmlUtils.GetValue("can_show_member", lblCanShowMember.Text);
            lblCanUpload.Text = LanguageXmlUtils.GetValue("can_member_upload", lblCanUpload.Text);
            lblCanMeeting.Text = LanguageXmlUtils.GetValue("can_launch_meeting", lblCanMeeting.Text);
            lblCanCourseware.Text = LanguageXmlUtils.GetValue("can_launch_courseware", lblCanCourseware.Text);
            lblTransmitWay.Text = LanguageXmlUtils.GetValue("msg_transmit_way", lblTransmitWay.Text);
            lblnewsSend.Text = LanguageXmlUtils.GetValue("plaintext_transmit", lblnewsSend.Text);
            tspmDocuments.Text = LanguageXmlUtils.GetValue("plaintext_transmit", tspmDocuments.Text);
            tspm3des.Text = LanguageXmlUtils.GetValue("3DES_encrypt_transmit", tspm3des.Text);
            tspmAES.Text = LanguageXmlUtils.GetValue("AES_encrypt_transmit", tspmAES.Text);
            tspmPTP.Text = LanguageXmlUtils.GetValue("port_to_port", tspmPTP.Text);
            lblcopy.Text = LanguageXmlUtils.GetValue("a_key_to_copy", lblcopy.Text);
            MenuItemInfo.Text = LanguageXmlUtils.GetValue("view_details", MenuItemInfo.Text);
            MenuItemTran.Text = LanguageXmlUtils.GetValue("transfer_group_owner", MenuItemTran.Text);
            MenuItemMeange.Text = LanguageXmlUtils.GetValue("appoint_admin", MenuItemMeange.Text);
            MenuItemTalk.Text = LanguageXmlUtils.GetValue("silence", MenuItemTalk.Text);
            MenuItemNoTalk.Text = LanguageXmlUtils.GetValue("do_not_silence", MenuItemNoTalk.Text);
            MenuItemTalk30.Text = LanguageXmlUtils.GetValue("silence_thirty_minutes", MenuItemTalk30.Text);
            MenuItemTalkhour.Text = LanguageXmlUtils.GetValue("silence_one_hour", MenuItemTalkhour.Text);
            MenuItemTalkDay.Text = LanguageXmlUtils.GetValue("silence_one_day", MenuItemTalkDay.Text);
            MenuItemTalk3Day.Text = LanguageXmlUtils.GetValue("silence_three_days", MenuItemTalk3Day.Text);
            MenuItemRemove.Text = LanguageXmlUtils.GetValue("from_the_group_remove", MenuItemRemove.Text);
            menuiteminvisible.Text = LanguageXmlUtils.GetValue("appoint_invisible_man", menuiteminvisible.Text);
            menuitemGroupnickname.Text = LanguageXmlUtils.GetValue("nickname_in_group", menuitemGroupnickname.Text);
        }

        public FrmMagent()
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            mAdapter = new MemberMangeListAdapter();
        }

        #region 由外界调用 触发加载数据
        /// <summary>
        /// 设置friend
        /// </summary>
        /// <param name="friend"></param>
        public void SetRoomData(Friend friend)
        {
            mfriend = friend;
        }

        /// <summary>
        /// 由外界触发加载数据
        /// </summary>
        public void LoadData()
        {
            ShowLodingDialog(palMember);
            RegistNotiy();
            MeangeLoadData(true, false);
            this.Show();
        }

        /// <summary>
        /// 注册广播监听事件
        /// </summary>
        private void RegistNotiy()
        {
            //按回执更新已读消息状态
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_ROOM_CHANGE_MESSAGE, item => Getmonitor(item));
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_ROOM_DELETE, XmppDeleteGroup);
        }

        private void XmppDeleteGroup(MessageObject obj)
        {
            Applicate.userlst.Remove(mfriend.UserId);
            this.Close();
        }

        #endregion

        #region 监听新消息刷新界面

        /// <summary>
        /// 监听
        /// </summary>
        /// <param name="msg"></param>
        public void Getmonitor(MessageObject msg)
        {
            if (this.IsHandleCreated)
            {
                Invoke(new Action(() =>
                {
                    MainNotiyUi(msg);
                }));
            }
        }

        /// <summary>
        /// 监听到有新消息时
        /// </summary>
        /// <param name="msg"></param>
        public void MainNotiyUi(MessageObject msg)
        {
            // 非此群组的控制消息不处理 2020-2-26 11:37:32
            if (!string.Equals(mfriend.RoomId, msg.objectId))
            {
                return;
            }

            bool readed = "1".Equals(msg.content);
            bool islook = "0".Equals(msg.content);
            int show = (readed == true) ? 1 : 0;
            USEMange use = new USEMange();
            switch (msg.type)
            {
                case kWCMessageType.RoomReadVisiblity://显示阅读人数
                                                      //更新界面的选中按钮
                    checkReaded.Checked = readed;
                    mfriend.UserId = msg.objectId;
                    mfriend.ShowRead = show;
                    mfriend.UpdateShowRead();
                    break;
                case kWCMessageType.RoomIsVerify://群验证

                    checkInviteSure.Checked = readed;//更新数据库
                    mfriend.UserId = msg.objectId;//设置RoomJid

                    mfriend.IsNeedVerify = show;
                    mfriend.UpdateNeedVerify();//群邀请确认
                    break;
                case kWCMessageType.RoomAdmin://管理员
                    //1.设置和取消管理员（当前账号）
                    //2.某个成员被取消设置成了管理员
                    if (msg.content == "0")//取消管理员
                    {
                        if (msg.toUserId.Equals(msg.myUserId))//自己被取消
                        {
                            Role = 3;
                            Applicate.userlst.Remove(mfriend.UserId);
                            this.Close();
                            this.Dispose();
                        }
                        else//别人被取消管理员
                        {
                            int i = mAdapter.GetIndexByFriendId(msg.toUserId);
                            if (i > -1)
                            {

                                //判断是否被创建
                                if (palMember.DataCreated(i))
                                {
                                    use = palMember.GetItemControl(i) as USEMange;
                                    use.Tag = 3.ToString();//刷新ui
                                }
                                else
                                {
                                    mAdapter.GetDatas(i).role = 3;//更新数据源
                                }
                            }

                        }
                    }
                    else
                    {
                        if (msg.toUserId.Equals(msg.myUserId))//
                        {
                            Role = 2;
                        }
                        else//别人被设置为管理员
                        {
                            int i = mAdapter.GetIndexByFriendId(msg.toUserId);
                            if (i > -1)
                            {

                                //判断是否被创建
                                if (palMember.DataCreated(i))
                                {
                                    use = palMember.GetItemControl(i) as USEMange;
                                    use.Tag = 2.ToString();//刷新ui
                                }
                                else
                                {
                                    mAdapter.GetDatas(i).role = 2;//更新数据源
                                }
                            }
                        }
                    }
                    break;
                case kWCMessageType.RoomIsPublic://公开群
                    if (string.Equals(msg.ChatJid, mfriend.UserId))
                    {
                        checkRoomPublic.Checked = islook;
                    }

                    break;
                case kWCMessageType.RoomInsideVisiblity://显示群内成员

                    checkShowMember.Checked = readed;
                    mfriend.UpdateShowMember(show);//更新数据库

                    break;
                case kWCMessageType.RoomUserRecommend://是否允许发送名片
                    checkPrive.Checked = readed;
                    //  mfriend.updatere(show);//更新数据库
                    break;
                case kWCMessageType.RoomMemberBan://禁言成员
                    break;
                case kWCMessageType.RoomDismiss://解散
                    Applicate.userlst.Remove(mfriend.UserId);
                    this.Close();
                    break;
                case kWCMessageType.RoomAllBanned://群组全员禁言 
                    checktalktime.Checked = readed;
                    break;
                case kWCMessageType.RoomAllowMemberInvite://是否允许群内普通成员邀请陌生人
                    checkAllowmembertoInvi.Checked = readed;
                    break;

                case kWCMessageType.RoomManagerTransfer://转让群主

                    //   msg.content = UIUtils.QuotationName(msg.toUserName) + "已成为新群主";
                    if (msg.content == "0")//
                    {
                        if (msg.toUserId.Equals(msg.myUserId))//自己成为群主
                        {
                            Role = 1;

                        }
                        else//别人成为群主
                        {

                            int i = mAdapter.GetIndexByFriendId(msg.toUserId);
                            if (i > -1)
                            {

                                //判断是否被创建
                                if (palMember.DataCreated(i))
                                {
                                    use = palMember.GetItemControl(i) as USEMange;
                                    use.Tag = 1.ToString();//刷新ui
                                }
                                else
                                {
                                    mAdapter.GetDatas(i).role = 1;//更新数据源
                                }
                            }

                        }
                    }
                    RoomMember oldgroomhoste = new RoomMember { roomId = mfriend.RoomId, userId = msg.fromUserId };//旧群主
                    oldgroomhoste = oldgroomhoste.GetRoomMember();
                    oldgroomhoste.role = 3;
                    oldgroomhoste.UpdateRole();
                    RoomMember newgroomhoste = new RoomMember { roomId = mfriend.RoomId, userId = msg.toUserId };//新群主
                    newgroomhoste = newgroomhoste.GetRoomMember();
                    newgroomhoste.role = 1;
                    newgroomhoste.UpdateRole();
                    break;

                case kWCMessageType.RoomAllowConference://是否允许群会议
                    checkConference.Checked = readed;
                    mfriend.UpdateAllowConference(show);
                    break;
                case kWCMessageType.RoomAllowSpeakCourse://是否允许群成员开课

                    checkclass.Checked = readed;
                    mfriend.UpdateAllowSpeakCourse(show);
                    break;
                case kWCMessageType.RoomAllowUploadFile://是否允许普通成员上传文件

                    checkupload.Checked = readed;

                    mfriend.UpdateAllowUploadFile(show);
                    break;
                case kWCMessageType.RoomExit://退群
                    if (msg.toUserId == Applicate.MyAccount.userId)
                    {

                    }
                    else
                    { //某群员退出了群聊
                      // msg.type = kWCMessageType.Remind;

                        // LoadGroupData();
                        //谁退出了群
                        string ExiteUserid = msg.toUserId;//退群者的userid
                        for (int i = 0; i < memberLst.Count; i++)
                        {
                            //从列表中移除
                            if (memberLst[i].userId == ExiteUserid)
                            {
                                palMember.RemoveItem(i);
                                mAdapter.RemoveData(i);
                                //member.Remove(member[i]);
                                memberLst.Remove(memberLst[i]);
                                break;
                            }
                        }
                    }
                    break;

                    break;
                case kWCMessageType.RoomInvite:
                    //在管理界面时有人加进来了
                    string addMemberUserid = msg.toUserId;//加入者userid
                    USEMange men = new USEMange();
                    men.friendData = new Friend();
                    men.friendData.UserId = addMemberUserid;


                    Friend f = new Friend
                    {
                        //  nickName = memberLst[i].nickName,
                        UserId = men.friendData.UserId
                    };
                    bool a = f.ExistsFriend();//判断是否为好友
                    if (!a)
                    {
                        f.NickName = msg.toUserName;
                        men.friendData = f;
                    }
                    else
                    {
                        men.friendData = f.GetByUserId();
                    }

                    // men.friendItem1.friendData = men.friendItem1.friendData.GetByUserId();//获取friend对象

                    if (msg.toUserName == men.friendData.NickName)
                    {
                        men.lblName.Text = null;
                    }
                    else
                    {
                        men.lblName.Text = msg.toUserName;
                    }
                    if (men.friendData.NickName.Length > 5)
                    {
                        men.friendData.NickName = men.friendData.NickName.Substring(0, 4) + "...";
                    }
                    ImageLoader.Instance.DisplayAvatar(f.UserId, men.pic_head);

                    men.MouseDown += USEGrouops_MouseDown;

                    men.Click += FriendItem1_Click;
                    men.Tag = 3;

                    RoomMember roomMember = new RoomMember();
                    roomMember.userId = men.friendData.UserId;
                    roomMember.nickName = men.friendData.NickName;
                    roomMember.role = 3;
                    // member.Add(men);
                    memberLst.Add(roomMember);
                    palMember.InsertItem(memberLst.Count);
                    break;
                //修改昵称
                case kWCMessageType.RoomMemberNameChange:
                    //先移除再添加

                    int index = mAdapter.GetIndexByFriendId(msg.toUserId);
                    if (index > -1)
                    {

                        //判断是否被创建
                        if (palMember.DataCreated(index))
                        {
                            use = palMember.GetItemControl(index) as USEMange;
                            use.lblName.Text = msg.content;//刷新ui
                        }
                        else
                        {
                            mAdapter.GetDatas(index).nickName = msg.content;//更新数据源
                        }
                    }
                    //  use = (USEMange)mAdapter.OnCreateControl(mAdapter.GetIndexByFriendId(msg.toUserId))
                    //  use.lblName.Text = msg.content;
                    break;
                case kWCMessageType.RoomNameChange://修改群名称
                    string groupname = msg.content;
                    lblName.Text = groupname;
                    break;
            }
        }
        #endregion

        #region 群成员列表项 鼠标事件
        USEMange use = new USEMange();

        /// <summary>
        /// 鼠标悬停事件
        /// </summary>
        public void USEMange_MouseEnter(object sender, EventArgs e)
        {
            USEMange usemange = (USEMange)sender;

            if (!usemange.IsSelected)
            {
                if (use != null)
                {
                    use.BackColor = Color.Transparent;
                }
                usemange.BackColor = ColorTranslator.FromHtml("#D8D8D9");//悬浮颜色
                use = usemange;
            }
        }

        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Use_MouseLeave(object sender, EventArgs e)
        {
            USEMange usemange = (USEMange)sender;
            if (!usemange.IsSelected)
            {
                usemange.BackColor = Color.Transparent;
            }
        }

        //清除右键选中
        public void FriendItem1_Click(object sender, EventArgs e)
        {
            if (BeforeItem != null)
            {
                BeforeItem.IsSelected = false;
            }
        }

        #endregion

        #region 显示等待符
        /// <summary>
        /// 等待符
        /// </summary>
        private void ShowLodingDialog(Control con)
        {
            loding = new LodingUtils();
            loding.parent = con;
            loding.Title = LanguageXmlUtils.GetValue("loading", "加载中");
            loding.start();
        }
        #endregion

        #region 从接口获取群组数据
        /// <summary>
        /// 从接口获取数据
        /// </summary>
        /// <param name="first">是否是此界面第一次从接口获取数据</param>
        /// <param name="isfill"></param>
        private void MeangeLoadData(bool first, bool isfill)
        {
            HttpUtils.Instance.InitHttp(this);

            //获取群详情
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/get")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .Build().AddErrorListener((code, err) =>
                {
                    loding.stop();
                })
               .Execute((sccess, room) =>
               {
                   if (sccess)
                   {
                       FillListData(room, first, isfill);
                       loding.stop();
                   }
               });
        }
        #endregion

        #region  根据接口数据 回显群控制开关状态
        /// <summary>
        /// 
        /// </summary>
        /// <param name = "keys" ></ param >
        /// < param name="first">是否是第一次加载</param>
        /// <param name = "isfill" > 是否需要显示刷新等待符 </ param >
        private void FillListData(Dictionary<string, object> keys, bool first, bool isfill)
        {
            RoomMember roomMember = new RoomMember();
            mfriend.TransToMember(keys);
            memberLst = roomMember.TransToMember(keys, mfriend.RoomId);

            //member.Clear();
            for (int i = 0; i < memberLst.Count; i++)
            {
                if (Applicate.MyAccount.userId.Equals(memberLst[i].userId))
                {
                    Role = memberLst[i].role;
                    break;
                }
            }

            if (first)
            {
                if ((TimeUtils.CurrentIntTime() - roomMember.talkTime) >= 0)
                {
                    checktalktime.Checked = false;
                }
                else
                {
                    checktalktime.Checked = true;
                }
                if (mfriend.IsSecretGroup == 1)//私密群组
                {
                    lblcopy.Visible = false;
                    picGroupCoppy.Visible = false;
                    label10.Size = new Size(label10.Width, 609);
                }

                //允许普通群成员邀请好友
                if (mfriend.AllowInviteFriend == 0)
                {
                    checkAllowmembertoInvi.Checked = false;
                }
                else
                {
                    checkAllowmembertoInvi.Checked = true;
                }
                //允许普通群成员召开会议
                if (mfriend.AllowConference == 0)
                {
                    checkConference.Checked = false;
                }
                else
                {
                    checkConference.Checked = true;
                }
                //允许显示群成员
                if (mfriend.ShowMember == 0)
                {
                    checkShowMember.Checked = false;
                }
                else
                {
                    checkShowMember.Checked = true; ;
                }
                //允许普通群成员私聊
                if (mfriend.AllowSendCard == 0)
                {
                    checkPrive.Checked = false;
                }
                else
                {
                    checkPrive.Checked = true;
                }
                //群组成员通知
                if (roomMember.isAttritionNotice == 0)
                {
                    checkMemberNotice.Checked = false;
                }
                else
                {
                    checkMemberNotice.Checked = true;
                }
                //公开群
                if (roomMember.isLook == 0)
                {
                    checkRoomPublic.Checked = true;
                }
                else
                {
                    checkRoomPublic.Checked = false;
                }
                //允许普通成员发起讲课
                if (mfriend.AllowSpeakCourse == 0)
                {
                    checkclass.Checked = false;
                }
                else
                {
                    checkclass.Checked = true;
                }
                //允许普通成员上传文件
                if (mfriend.AllowUploadFile == 0)
                {
                    checkupload.Checked = false;
                }
                else
                {
                    checkupload.Checked = true;
                }
                //显示已读
                if (mfriend.ShowRead == 0)
                {
                    checkReaded.Checked = false;
                }
                else
                {
                    checkReaded.Checked = true;
                }
                //群验证
                if (mfriend.IsNeedVerify == 0)
                {
                    checkInviteSure.Checked = false;
                }
                else
                {
                    checkInviteSure.Checked = true;

                }

                ImageLoader.Instance.DisplayGroupAvatar(mfriend.UserId, mfriend.RoomId, c);

                // 群名称
                lblName.Text = mfriend.NickName.ToString();
            }

            BindRoomMemberList(memberLst, isfill);

            int entype = UIUtils.DecodeInt(keys, "encryptType");
            ChangeEncryptUI(entype);

            if (Role == 1)
            {
                menuiteminvisible.Visible = true;
                lblcopy.Visible = true;
                palcopy.Visible = true;
                picGroupCoppy.Visible = true;
                label10.Size = new Size(1, 649);


            }
            else
            {
                MenuItemTran.Visible = false;
                MenuItemMeange.Visible = false;
                menuiteminvisible.Visible = false;

                lblcopy.Visible = false;
                palcopy.Visible = false;
                picGroupCoppy.Visible = false;
                label10.Size = new Size(1, 618);
            }
            if (Role == 2 || Role == 1)
            {
                menuitemGroupnickname.Visible = true;
            }

            checkReaded.Click += OnCheckChangeListener;//已读
            checkInviteSure.Click += OnCheckChangeListener;//群验证
            checkPrive.Click += OnCheckChangeListener;//普通成员邀请好友
            checkMemberNotice.Click += OnCheckChangeListener;//减员通知
            checkConference.Click += OnCheckChangeListener;//发起会议
            checkShowMember.Click += OnCheckChangeListener;//显示群成员
            checkRoomPublic.Click += OnCheckChangeListener;//私密群
            checkupload.Click += OnCheckChangeListener;//普通成员上传文件
            checkclass.Click += OnCheckChangeListener;//讲课
            checkAllowmembertoInvi.Click += OnCheckChangeListener;//普通成员邀请好友
            checktalktime.Click += Checktalktime_CheckedChanged;//全体禁言

            this.Show();
        }

        #endregion

        #region 绑定列表数据

        /// <summary>
        ///  成员信息显示在面板中
        /// </summary>
        /// <param name="memberLst">群成员列表</param>
        /// <param name="isfill">是否需要显示刷新等待符</param>
        private void BindRoomMemberList(List<RoomMember> memberLst, bool isfill)
        {
            mAdapter.SetMaengForm(this);
            mAdapter.BindDatas(memberLst);
            palMember.SetAdapter(mAdapter);
        }
        #endregion

        #region 绑定右键菜单
        /// <summary>
        /// 绑定右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void USEGrouops_MouseDown(object sender, MouseEventArgs e)
        {
            USEMange uSEMange = (USEMange)sender;

            if (BeforeItem != null)
            {
                BeforeItem.IsSelected = false;
            }
            if (e.Button == MouseButtons.Right)
            {

                uSEMange.ContextMenuStrip = menuDel;


                uSEMange.IsSelected = true;
                SelectItems = uSEMange;

                BeforeItem = uSEMange;


                //1.群主,管理员不能被禁言
                //2.管理员不能对自己指定管理员
                //3.管理员可以被取消
                //4.取消禁言
                //群主被取消之后就是普通成员
                if (Role == 1)
                {
                    if (SelectItems.Tag.ToString() == "1")
                    {
                        MenuItemMeange.Visible = false;
                        MenuItemTalk.Visible = false;
                        MenuItemRemove.Visible = false;
                        menuiteminvisible.Visible = false;
                        MenuItemTran.Visible = false;
                        menuitemGroupnickname.Visible = false;
                    }

                    else
                    {
                        MenuItemMeange.Visible = true;
                        MenuItemTalk.Visible = true;
                        MenuItemRemove.Visible = true;
                        menuiteminvisible.Visible = true;
                        MenuItemTran.Visible = true;
                        menuitemGroupnickname.Visible = true;

                        if (SelectItems.Tag.ToString() == "2")
                        {
                            MenuItemTalk.Visible = false;

                            MenuItemMeange.Text = LanguageXmlUtils.GetValue("revoke_admin", "取消管理员");
                            menuiteminvisible.Visible = false;
                        }
                        else if (SelectItems.Tag.ToString() == "4")
                        {
                            MenuItemTalk.Visible = false;
                            menuiteminvisible.Text = LanguageXmlUtils.GetValue("revoke_invisible_man", "取消指定隐身人");
                        }
                        else
                        {

                            MenuItemMeange.Text = LanguageXmlUtils.GetValue("appoint_admin", "指定管理员");
                            menuiteminvisible.Visible = true;
                            menuiteminvisible.Text = LanguageXmlUtils.GetValue("appoint_invisible_man", "指定隐身人");
                        }
                    }

                }
                else
                {
                    if (SelectItems.Tag.ToString() == "1")
                    {
                        MenuItemTran.Visible = false;
                    }
                    else
                    {
                        MenuItemTran.Visible = true;
                    }
                    if (Role == 2)
                    {
                        MenuItemTran.Visible = false;
                        MenuItemMeange.Visible = false;
                        if (SelectItems.Tag.ToString() == "1" || SelectItems.Tag.ToString() == "2")
                        {
                            MenuItemTalk.Visible = false;
                            MenuItemRemove.Visible = false;

                        }
                        else
                        {
                            MenuItemTalk.Visible = true;
                            MenuItemRemove.Visible = true; ;
                        }
                    }
                    else
                    {
                        MenuItemTran.Visible = false;
                        MenuItemMeange.Visible = false;
                        MenuItemInfo.Visible = true;
                        MenuItemTalk.Visible = false;
                        MenuItemRemove.Visible = false; ;
                    }
                }

            }
            if (e.Button == MouseButtons.Left)
            {
                uSEMange.ContextMenuStrip = null;

            }
        }
        #endregion

        #region 群成员列表右键菜单事件

        #region 移除成员
        /// <summary>
        /// 移除成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmFromTomove(object sender, EventArgs e)
        {
            ShowLodingDialog(palMember);//显示等待符

            // 从服务器移除群成员
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/member/delete")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("userId", SelectItems.friendData.UserId)
                .Build().Execute((sccess, room) =>
                {
                    loding.stop();

                    if (sccess)
                    {
                        //通知管理员变更或者指定
                        // Messenger.Default.Send(SelectItems.friendItem1, MessageActions.Room_UPDATE_ROOM_DELETE);
                        for (int i = 0; i < memberLst.Count; i++)
                        {
                            if (memberLst[i].userId == SelectItems.friendData.UserId)
                            {
                                palMember.RemoveItem(i);

                                //   member.Remove(member[i]);
                                memberLst.Remove(memberLst[i]);
                                break;
                            }
                        }
                    }
                });
        }
        #endregion

        #region 查看群成员详情
        /// <summary>
        ///   查看详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMseeinfo_Click(object sender, EventArgs e)
        {
            FrmFriendsBasic frmFriendsBasic = new FrmFriendsBasic();
            string userid = SelectItems.friendData.UserId;
            frmFriendsBasic.ShowUserInfoById(userid);
        }
        #endregion

        #region  转让群主
        //转让群主
        //群主转让之后，这时我的角色

        /// <summary>
        /// 1.转让群主成功之后我的身份变为普通成员，此时的右键菜单只能查看成员信息
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMtransfer_Click(object sender, EventArgs e)
        {
            string beforeRole = SelectItems.Tag.ToString(); //选中时的角色

            if (string.Equals("4", beforeRole))
            {
                ShowTip("不能转让群主给隐身人");
                return;
            }

            ShowLodingDialog(palMember);
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/transfer")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("toUserId", SelectItems.friendData.UserId)
                .Build().AddErrorListener((code, err) =>
                {
                    loding.stop();
                    //MessageBox.Show(err);
                    //角色保持不变
                    Role = 1;
                    SelectItems.Tag = beforeRole;
                })
                .Execute((sccess, data) =>
                {
                    if (sccess)
                    {
                        //通知群主转让
                        toolStripMenuItem.Visible = false;
                        SelectItems.Tag = "1";
                        Role = 3;
                        //更新群主的角色
                        RoomMember oldgroomhoste = new RoomMember { roomId = mfriend.RoomId, userId = Applicate.MyAccount.userId };//旧群主
                        oldgroomhoste = oldgroomhoste.GetRoomMember();
                        oldgroomhoste.role = 3;
                        oldgroomhoste.UpdateRole();
                        RoomMember newgroomhoste = new RoomMember { roomId = mfriend.RoomId, userId = SelectItems.friendData.UserId };//新群主
                        newgroomhoste = newgroomhoste.GetRoomMember();
                        newgroomhoste.role = 1;
                        newgroomhoste.UpdateRole();

                        Applicate.userlst.Remove(mfriend.UserId);
                        loding.stop();
                        this.Dispose();
                        this.Close();
                        //Messenger.Default.Send(SelectItems.friendItem1, MessageActions.Room_UPDATE_ROOM_DELETE);
                    }
                });
        }

        #endregion

        #region 设置管理员(指定/取消)
        /// <summary>
        ///1.如果当前的成员不是管理员为指定管理员，反之取消管理员
        ///2.管理员可以多次设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMAdmin_Click(object sender, EventArgs e)
        {
            string beforeRole = SelectItems.Tag.ToString(); //选中时的角色


            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            string type = "0";
            string menultemtext = toolStripMenuItem.Text;
            //刷新当前的角色
            if (toolStripMenuItem.Text == LanguageXmlUtils.GetValue("appoint_admin", "指定管理员"))
            {
                toolStripMenuItem.Text = LanguageXmlUtils.GetValue("revoke_admin", "取消管理员");
                SelectItems.Tag = "2";
                type = "2";

                // MenuItemMeange

            }
            else if (toolStripMenuItem.Text == LanguageXmlUtils.GetValue("revoke_admin", "取消管理员"))
            {
                toolStripMenuItem.Text = LanguageXmlUtils.GetValue("appoint_admin", "指定管理员");
                SelectItems.Tag = "3";
                type = "3";

            }


            ShowLodingDialog(palMember);

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/set/admin")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("touserId", SelectItems.friendData.UserId)
                .AddParams("type", type)
                .Build().Execute((sccess, room) =>
                {
                    loding.stop();
                    if (!sccess)
                    {
                        SelectItems.Tag = beforeRole;
                        toolStripMenuItem.Text = menultemtext;
                    }
                });
        }
        #endregion

        #region 成员禁言
        /// <summary>
        /// 成员禁言（禁言的时间）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MemberNoTalk(object sender, EventArgs e)
        {

            ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
            string tag = menuitem.Tag.ToString();
            double SettalkTime = 0;//设置禁言时间
            int daysends = 24 * 60 * 60;
            switch (tag)
            {
                case "1":
                    SettalkTime = 0;//不禁言
                    break;
                case "2":
                    SettalkTime = daysends / 48;//禁言30分钟
                    break;
                case "3":
                    SettalkTime = daysends / 24;//禁言1小时
                    break;
                case "4":
                    SettalkTime = daysends;//禁言1天
                    break;
                case "5":
                    SettalkTime = daysends * 3;//禁言3天
                    break;

            }

            //禁言结束的时间
            long talkTime = Convert.ToInt64(TimeUtils.CurrentTimeDouble() + SettalkTime);
            ShowLodingDialog(palMember);//显示等待符

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/member/update")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("userId", SelectItems.friendData.UserId)
                .AddParams("talkTime", talkTime.ToString())
                .Build().Execute((sccess, data) =>
                {
                    loding.stop();
                });
        }
        #endregion

        #region 设置隐身人
        /// <summary>
        /// 指定隐身人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuiteminvisible_Click(object sender, EventArgs e)
        {
            string beforeRole = SelectItems.Tag.ToString(); //选中时的角色

            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            string type = "0";
            string menultemtext = toolStripMenuItem.Text;
            //刷新当前的角色
            if (toolStripMenuItem.Text == LanguageXmlUtils.GetValue("appoint_invisible_man", "指定隐身人"))
            {
                toolStripMenuItem.Text = LanguageXmlUtils.GetValue("revoke_invisible_man", "取消指定隐身人");
                SelectItems.Tag = "4";
                type = "4";

            }
            else if (toolStripMenuItem.Text == LanguageXmlUtils.GetValue("revoke_invisible_man", "取消指定隐身人"))
            {
                toolStripMenuItem.Text = LanguageXmlUtils.GetValue("appoint_invisible_man", "指定隐身人");
                SelectItems.Tag = "-1";
                type = "-1";

            }

            ShowLodingDialog(panel2);

            //设置隐身人
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/setInvisibleGuardian")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("touserId", SelectItems.friendData.UserId)
                .AddParams("type", type)
                .Build().Execute((sccess, room) =>
                {
                    loding.stop();

                    if (sccess)
                    {
                        //通知管理员变更或者指定
                        RoomMember roomMember = new RoomMember { roomId = mfriend.RoomId, userId = SelectItems.friendData.UserId };
                        roomMember = roomMember.GetRoomMember();
                        if (type == "4")
                        {
                            roomMember.role = 4;
                        }
                        else if (type == "-1")
                        {
                            roomMember.role = 3;
                        }
                        roomMember.UpdateRole();

                    }
                });
        }
        #endregion

        #endregion

        #region 更新群设置信息
        /// <summary>
        ///   更新群设置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCheckChangeListener(object sender, EventArgs e)
        {
            USEToggle SelectInfo = (USEToggle)sender; string tag = SelectInfo.Tag.ToString();
            int dataValue = SelectInfo.Checked ? 1 : 0;
            int islock = SelectInfo.Checked ? 0 : 1;

            switch (tag)
            {
                case "1"://显示已读人数
                    updateReaded(dataValue);
                    break;
                case "2"://群组邀请确认
                    UpdateinviteSure(dataValue);
                    break;
                case "3"://群组成员通知
                    updateMemberNotic(dataValue);
                    break;
                case "4"://允许私聊
                    updateallowSendCard(dataValue);
                    break;
                case "5"://允许显示群成员
                    updateshowmember(dataValue);
                    break;
                case "6":
                    updateConfence(dataValue);//会议
                    break;
                case "7":
                    TalkTime = Convert.ToInt32(TimeUtils.CurrentTimeDouble() + 24 * 60 * 60 * 15);
                    break;
                case "8":
                    updateRoomLook(islock);
                    break;
                case "9"://音视频
                    string userid = Applicate.MyAccount.userId;
                    LocalDataUtils.SetBoolData(mfriend.RoomId + "autio_video" + userid, SelectInfo.Checked);
                    break;
                case "10"://上传群文件
                    updateuploadFile(dataValue);
                    break;
                case "11"://讲课
                    updateSpeakCourse(dataValue);
                    break;
                case "12"://群成员邀请好友
                    updateAllowInvite(dataValue);
                    break;
            }

        }


        #region 全体禁言开关
        /// <summary>
        /// 全体禁言开关改变事件
        /// </summary>
        private void Checktalktime_CheckedChanged(object sender, EventArgs e)
        {
            if (checktalktime.Checked)
            {
                TalkTime = Convert.ToInt64(TimeUtils.CurrentTimeDouble() + 24 * 60 * 60 * 15);
            }
            else
            {
                TalkTime = 0;
            }

            // 更新群禁言时间到服务器
            ShowLodingDialog(panel2);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/update")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("talkTime", TalkTime.ToString())
                .Build().ExecuteJson<object>((sccess, data) =>
                {
                    loding.stop();
                });
        }

        #endregion

        #region 显示消息已读
        /// <summary>
        /// 显示消息已读
        /// </summary>
        /// <param name="Readed">是否显示消息已读 1.显示 0.不显示</param>
        public void updateReaded(int Readed)
        {
            ShowLodingDialog(panel2);

            //获取群详情
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/update")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("showRead", Readed.ToString())
                .Build().Execute((sccess, data) =>
                {
                    loding.stop();
                    if (sccess)
                    {
                        mfriend.ShowRead = Readed;
                        mfriend.UpdateShowRead();
                    }
                });
        }
        #endregion

        #region 进群验证
        /// <summary>
        ///  群验证
        /// </summary>
        /// <param name="isNeedVerify">是否开启群验证</param>
        private void UpdateinviteSure(int isNeedVerify)
        {
            // 显示等待符
            ShowLodingDialog(panel2);

            //更新群
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/update")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("isNeedVerify", isNeedVerify.ToString())
                .Build().Execute((sccess, data) =>
                {
                    loding.stop();
                    if (sccess)
                    {
                        mfriend.IsNeedVerify = isNeedVerify;
                        mfriend.UpdateNeedVerify();
                    }
                });

        }
        #endregion

        #region 是否开启讲课 
        /// <summary>
        ///   讲课
        /// </summary>
        /// <param name="allowSpeakCourse">是否开启讲课 1.允许 0.不允许</param>
        private void updateSpeakCourse(int allowSpeakCourse)
        {
            ShowLodingDialog(panel2);

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/update")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("allowSpeakCourse", allowSpeakCourse.ToString())
                .Build().Execute((sccess, data) =>
                {
                    loding.stop();
                    if (sccess)
                    {
                        mfriend.UpdateAllowSpeakCourse(allowSpeakCourse);
                    }
                });
        }
        #endregion

        #region 允许普通成员上传文件
        /// <summary>
        ///   允许普通成员上传文件
        /// </summary>
        /// <param name="allowUploadFile">允许普通成员上传文件 1.允许 0.不允许</param>
        private void updateuploadFile(int allowUploadFile)
        {
            ShowLodingDialog(panel2);

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/update")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("allowUploadFile", allowUploadFile.ToString())
                .Build().Execute((sccess, data) =>
                {
                    loding.stop();
                    if (sccess)
                    {
                        mfriend.UpdateAllowUploadFile(allowUploadFile);
                    }
                });
        }
        #endregion

        #region 允许成员召开会议
        /// <summary>
        ///  允许成员召开会议
        /// </summary>
        /// <param name="allowConference">是否允许召开会议 1.允许 0.不允许</param>
        public void updateConfence(int allowConference)
        {
            ShowLodingDialog(panel2);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/update")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("allowConference", allowConference.ToString())
                .Build().Execute((sccess, data) =>
                {
                    loding.stop();
                    if (sccess)
                    {
                        mfriend.UpdateAllowConference(allowConference);
                    }
                });
        }
        #endregion

        #region 允许成员邀请好友
        /// <summary>
        /// 允许成员邀请好友
        /// </summary>
        /// <param name="allowInviteFriend">是否允许邀请好友 1.允许 0.不允许</param>
        public void updateAllowInvite(int allowInviteFriend)
        {
            ShowLodingDialog(panel2);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/update") //获取群详情
     .AddParams("access_token", Applicate.Access_Token)
     .AddParams("roomId", mfriend.RoomId)
   .AddParams("allowInviteFriend", allowInviteFriend.ToString())
    .Build().AddErrorListener((code, err) =>
    {
        loding.stop();
    })
     .Execute((sccess, data) =>
     {
         if (sccess)
         {
             loding.stop();
             mfriend.UpdateAllowInviteFriend(allowInviteFriend);
         }
         else
         {

         }

     });
        }
        #endregion

        #region 允许私聊
        /// <summary>
        ///   允许私聊
        /// </summary>
        /// <param name="allowSendCard">是否允许好友私聊 1.允许 0.不允许</param>
        public void updateallowSendCard(int allowSendCard)
        {
            ShowLodingDialog(panel2);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/update") //获取群详情
     .AddParams("access_token", Applicate.Access_Token)
     .AddParams("roomId", mfriend.RoomId)
   .AddParams("allowSendCard", allowSendCard.ToString())
    .Build().AddErrorListener((code, err) =>
    {
        loding.stop();

        // MessageBox.Show("设置允许私聊失败");
        //  checkPrive.CheckedChanged -= checkchange;
        // checkPrive.Checked = checkState(Readed);
        // checkPrive.CheckedChanged += checkchange;

    })
     .Execute((sccess, data) =>
     {
         if (sccess)
         {
             mfriend.UpdateAllowSendCard(allowSendCard);
             loding.stop();
         }
         else
         {

         }

     });
        }
        #endregion

        #region 群是否公开
        /// <summary>
        ///   群是否公开
        /// </summary>
        /// <param name="isLook">是否公开群1.公开0.不公开</param>
        public void updateRoomLook(int isLook)
        {

            if (mfriend.IsSecretGroup == 1)
            {
                checkRoomPublic.Checked = false;
                HttpUtils.Instance.ShowTip("私密群组不能设为公开群");
                return;
            }

            ShowLodingDialog(panel2);

            // 修改服务器公开群
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/update")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("isLook", isLook.ToString())
                .Build().Execute((sccess, data) =>
                {
                    loding.stop();
                    if (sccess)
                    {
                        mfriend.UpdateAllowSendCard(isLook);
                    }
                });
        }
        #endregion

        #region 显示群成员
        /// <summary>
        /// 显示群成员
        /// </summary>
        /// <param name="showMember">是否显示群成员1.显示0.不显示</param>
        private void updateshowmember(int showMember)
        {
            ShowLodingDialog(panel2);

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/update")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("showMember", showMember.ToString())
                .Build().Execute((sccess, data) =>
                {
                    loding.stop();
                    if (sccess)
                    {
                        mfriend.UpdateShowMember(showMember);
                    }
                });
        }

        #endregion

        #region 减员通知
        /// <summary>
        /// 减员通知
        /// </summary>
        /// <param name="isAttritionNotice"></param>
        private void updateMemberNotic(int isAttritionNotice)
        {
            ShowLodingDialog(panel2);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/update")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", mfriend.RoomId)
                .AddParams("isAttritionNotice", isAttritionNotice.ToString())
                .Build().Execute((sccess, data) =>
                {
                    loding.stop();
                });
        }

        #endregion

        #region 消息传输方式

        /// <summary>
        /// 控制开关点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblnewsSend_Click(object sender, EventArgs e)
        {

            if (mfriend.IsSecretGroup == 1)
            {
                ShowTip("私密群组不能选择其他消息加密方式");
            }
            else
            {
                if (!Applicate.ENABLE_ASY_ENCRYPT)
                {
                    cmsnewssendway.Items.RemoveByKey("tspmAES");
                    cmsnewssendway.Items.RemoveByKey("tspmPTP");
                }
                cmsnewssendway.Show(lblnewsSend, lblnewsSend.Width - cmsnewssendway.Width, lblnewsSend.Height);
            }
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


            if (mfriend.IsSecretGroup == 0)
            {
                if (encryptType > 1)
                {
                    ShowTip("普通群组不能选择该加密方式");
                    return;
                }
            }

            ChangeEncryptUI(encryptType);
            RequestUpdateEncryptType(mfriend.RoomId, encryptType);
        }

        // 修改好友的加密方式
        private void RequestUpdateEncryptType(string roomId, int isEncrypt)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/updateEncryptType")
             .AddParams("roomId", roomId)
             .AddParams("encryptType", isEncrypt.ToString())
             .NoErrorTip()
             .Build().Execute((state, data) =>
             {
                 if (state)
                 {
                     // 明文传输
                     ChangeEncryptUI(isEncrypt);
                     mfriend.UpdateEncrypt(isEncrypt);
                 }
             });
        }

        private void ChangeEncryptUI(int isEncrypt)
        {
            if (!Applicate.ENABLE_ASY_ENCRYPT && isEncrypt > 0)
            {
                //lblnewsSend.Text = "3DES加密";
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

        #endregion

        #endregion

        #region 关闭窗口反注册
        private void FrmMagent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Applicate.userlst.Remove(mfriend.UserId);
            Messenger.Default.Unregister(this);
        }



        #endregion

        private void menuitemGroupnickname_Click(object sender, EventArgs e)
        {
            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();

            frm.ColleagueName((remarkName) =>
            {

                ShowLodingDialog(palMember);

                //获取群详情
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/member/update")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("roomId", mfriend.RoomId)
                    .AddParams("userId", SelectItems.friendData.UserId)
                    .AddParams("remarkName", remarkName)
                    .Build().Execute((sccess, data) =>
                    {
                        frm.Close();
                        loding.stop();
                        if (sccess)
                        {
                            RoomMember roomMember = new RoomMember { roomId = mfriend.RoomId, userId = SelectItems.friendData.UserId };
                            roomMember.remarkName = remarkName;
                            roomMember.UpdateRemarkName();//更新群主备注
                            SelectItems.lab_name.Text = remarkName;
                            RoomMemberUtils rm_utils = new RoomMemberUtils();
                            rm_utils.UpdateRoomMemberName_Remark(SelectItems.friendData.UserId, remarkName);
                        }
                    });

            });

            string title = LanguageXmlUtils.GetValue("title_modify_remark", "修改备注");
            string name = LanguageXmlUtils.GetValue("name_remark_name", "备注名", true);
            frm.ShowThis(title, name);
        }
        /// <summary>
        /// 群组复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picGroupCoppy_Click(object sender, EventArgs e)
        {

            var tmpset = Applicate.GetWindow<FrmCoppyGroup>();

            if (tmpset == null)
            {
                FrmCoppyGroup frmCoppyGroup = new FrmCoppyGroup();
                frmCoppyGroup.GetData(mfriend, memberLst.Count);
                frmCoppyGroup.Show();
            }
            else
            {
                tmpset.Activate();
                tmpset.WindowState = FormWindowState.Normal;
            }

        }
    }
}
