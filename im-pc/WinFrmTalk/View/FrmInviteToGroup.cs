using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;

namespace WinFrmTalk.View
{
    public partial class FrmInviteToGroup : FrmBase
    {
        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            lblTitle.Text = LanguageXmlUtils.GetValue("frmInviteToGroup_title", lblTitle.Text);
            lblInvited.Text = LanguageXmlUtils.GetValue("btn_confirm_invite", lblInvited.Text);
            btnSure.Text = LanguageXmlUtils.GetValue("btn_confirm_invite", btnSure.Text);
        }

        public FrmInviteToGroup()
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
        }
        #region 全局变量
        private MessageObject _Msg;

        private Friend _friend;
        private string inviteduserid;//邀请人的userid

        private string[] usernamelst;   //被邀请人的集合

        private string[] userids;
        private LodingUtils loding;//等待符
        #endregion
        /// <summary>
        /// 接受到的消息
        /// </summary>
        public MessageObject AcceptMessage
        {
            get { return _Msg; }
            set
            {
                _Msg = value;
            }
        }
        /// <summary>
        /// friend
        /// </summary>
        public Friend Getfriend
        {
            get { return _friend; }
            set
            {
                _friend = value;

            }
        }
        /// <summary>
        /// 显示等待符号
        /// </summary>
        private void ShowLodingDialog()
        {
            loding = new LodingUtils();
            loding.parent = tabPal;
            loding.Title = LanguageXmlUtils.GetValue("loading", "加载中");
            loding.start();
        }
        /// <summary>
        ///判断该条邀请确认消息是否已经同意邀请
        ///<para>true表示已经确认邀请过，false没有确认邀请</para>
        /// </summary>
        /// <returns></returns>
        private bool Isinvited()
        {
            //目前是根据message中的isupload标志来保存并进行判断
            if (AcceptMessage.isUpload == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 加载页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInviteToGroup_Load(object sender, EventArgs e)
        {
            DesCodeMessage();

        }
        #region 确认邀请,群主确认将好友添加进入
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            List<string> datas = new List<string>();
            for (int i = 0; i < userids.Length; i++)
            {
                datas.Add(userids[i]);
            }
            ShowLodingDialog();
            string useids = Newtonsoft.Json.JsonConvert.SerializeObject(datas);//userid拼接的集合
            if (tabPal != null)//调接口
            {
                HttpUtils.Instance.InitHttp(this);
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/member/update") //更新群成员
              .AddParams("access_token", Applicate.Access_Token)
              .AddParams("roomId", Getfriend.RoomId)
              .AddParams("text", useids)
                .Build().AddErrorListener((code, err) =>
                {
                    loding.stop();

                })
             .Execute((sccess, data) =>
             {
                 if (sccess)
                 {
                     loding.stop();

                     AcceptMessage.isUpload = 1;
                     AcceptMessage.updatemessageupdate(AcceptMessage.isUpload);//更新数据库isUpload字段

                     RoomMember roomMember = new RoomMember();
                     roomMember.roomId = Getfriend.RoomId;

                     List<RoomMember> memberList = new List<RoomMember>();

                     for (int i = 0; i < userids.Length; i++)
                     {
                         RoomMember roomMembers = new RoomMember();
                         roomMembers.roomId = Getfriend.RoomId;
                         roomMembers.userId = userids[i];
                         roomMembers.nickName = usernamelst[i];
                         roomMembers.role = 3;
                         roomMembers.talkTime = 0;
                         roomMembers.sub = 1;
                         roomMembers.offlineNoPushMsg = 0;
                         //  roomMember.remarkName = a.Value.nickName;
                         memberList.Add(roomMembers);//添加更新列表
                     }

                     roomMember.AutoInsertOrUpdate(memberList);//邀请的好友保存数据库
                     btnSure.Visible = false;
                     lblInvited.Visible = true;
                     lblInvited.Enabled = false;
                     // this.Close();
                     // this.Dispose();


                 }
                 else
                 {

                 }
             });
            }


        }


        #endregion
        #region 解析message并进行赋值
        /// <summary>
        /// 
        /// </summary>
        private void DesCodeMessage()
        {
            inviteduserid = AcceptMessage.fromUserId;
            //解析
            string objecid = AcceptMessage.objectId;
            var notic = JsonConvert.DeserializeObject<Dictionary<string, object>>(objecid.ToString());
            string roomJid = UIUtils.DecodeString(notic, "roomJid");
            string nickname = AcceptMessage.fromUserName;
            string useids = UIUtils.DecodeString(notic, "userIds");
            userids = useids.Split(',');

            string usernames = UIUtils.DecodeString(notic, "userNames");
            usernamelst = usernames.Split(',');
            string reson = UIUtils.DecodeString(notic, "reason");
            string isInvite = UIUtils.DecodeString(notic, "isInvite");
            lblNick.Text = nickname;
            ImageLoader.Instance.DisplayAvatar(inviteduserid, pic);
            lblReson.Text = LanguageXmlUtils.GetValue("invite_reason", "邀请原因：", true) + reson;
            string group_name = EQControlManager.StrAddEllipsis(Getfriend.NickName, lblInviterInfo.Font, 500);
            if (nickname == usernames)
            {
                lblInviterInfo.Text = LanguageXmlUtils.GetValue("apply_to_join_group", "申请加入群聊：", true) + group_name;
            }
            else
            {
                //lblInviterInfo.Text = "想邀请" + userids.Length.ToString() + "位朋友进入群聊：" + group_name;
                string content = LanguageXmlUtils.GetValue("invite_fd_join_group", "想邀请" + userids.Length.ToString() + "位朋友进入群聊：", true) + group_name;
                lblInviterInfo.Text = content.Replace("%s", userids.Length.ToString());
            }

            if (Isinvited())
            {
                btnSure.Visible = false;//确认按钮不可见
                lblInvited.Visible = true;//确认lable可见（灰色的）
                lblInvited.Enabled = false;//（不可点击）
            }
            //被邀请的好友显示在面板上
            for (int i = 0; i < userids.Length; i++)
            {
                USEpicAddName uSEpicAddName = new USEpicAddName();

                uSEpicAddName.pics.Size = new Size(35, 35);
                uSEpicAddName.Size = new Size(50, 58);
                uSEpicAddName.LabelFont = new Font(Applicate.SetFont, 8F);
                uSEpicAddName.Userid = userids[i].ToString();
                uSEpicAddName.NickName = usernamelst[i].ToString();
                ImageLoader.Instance.DisplayAvatar(uSEpicAddName.Userid, uSEpicAddName.pics);
                tabPal.Controls.Add(uSEpicAddName);
            }
        }
        #endregion
    }
}
