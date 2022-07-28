using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;
using static MeetFormManager;

namespace WinFrmTalk.View
{
    public partial class FrmVoiceMeetRoom : FrmBase
    {
        // 当前通话对象
        public Friend mFriend { get; set; }

        //当前通话成员
        private Dictionary<string, string> mUserList { get; set; }
        private List<RoomMember> memList;


        public string mOpenUrl { get; set; }

        // 是否开启扬声器
        private bool isOpenSound;

        // 是否开启麦克风
        private bool isOpenRecord;

        // 通话时间
        private int MeetTime = 0;



        public FrmVoiceMeetRoom()
        {
            SelfPermission.Instance.RequestOpenVideoPermission();

            InitializeComponent();
            rbhung.Image = Resources.ClosePhone;
            rbaudio.Image = Resources.ic_audiomeeting_Audio;
        }


        public void ConnectVoiceMeet(Friend friend, string url, string organizer)
        {
            this.mFriend = friend;
            this.mOpenUrl = url;

            lbltitle.Text = organizer + "发起的语音会议";
            lblinvite.Text = "发起人：" + organizer;
        }


        private void FrmVoiceMeetRoom_Load(object sender, EventArgs e)
        {
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_MEETING_MESSAGE, MainMessage);
            mUserList = new Dictionary<string, string>();
            memList = new List<RoomMember>();
            InitMeet();
        }

        private void OnMeetLoaded()
        {
            if (Thread.CurrentThread.IsBackground)
            {
                var main = new DelegateMeetLoad(OnMeetLoaded);
                Invoke(main);
                return;
            }

            StopLoading();
            InitTimer();
            InitUserList();
        }

        private void ShowLoading()
        {
            loding1.Visible = true;

        }

        private void StopLoading()
        {
            loding1.Visible = false;
        }


        #region =========================消息处理=================================

        public void MainMessage(MessageObject message)
        {
            //结束通话
            if (message.type == kWCMessageType.AudioChatEnd || message.type == kWCMessageType.VideoChatEnd || message.type == kWCMessageType.ScreenMeetEnd)
            {
                MeetFormManager.Instance.InitFrom();
                ExitMeet();
                this.Close();
            }
        }

        #endregion

        #region =========================计时器=================================

        System.Timers.Timer timer_count;

        public void InitTimer()
        {
            timer_count = new System.Timers.Timer();
            //到达时间的时候执行事件；
            timer_count.Elapsed += new System.Timers.ElapsedEventHandler(tick_count);
            timer_count.AutoReset = true;  //设置是执行一次（false）还是一直执行(true)；
            timer_count.Interval = 1000;
            timer_count.Start();
            MeetTime = 0;
        }


        public void tick_count(object source, System.Timers.ElapsedEventArgs e)
        {
            MeetTime++;

            // 秒钟
            int sec = MeetTime % 60;

            // 分钟
            int min = MeetTime / 60 % 60;

            // 小时
            int hour = MeetTime / 3600;

            string text = string.Format("{0:0#}:{1:0#}:{2:0#}", hour, min, sec);

            if (!IsHandleCreated)
            {
                this.lbltime.Text = text;
            }
        }

        #endregion

        #region ========================通话核心================================

        private ChromiumWebBrowser mCoreMeet;
        private void InitMeet()
        {
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            string path = Environment.CurrentDirectory + "\\Cefsharp.html";
            //调用浏览器
            mCoreMeet = new ChromiumWebBrowser(path);
            panel1.Controls.Add(mCoreMeet);
            mCoreMeet.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>(CoreLoaded);

            // 注册监听
            RegistCoreMeetListener();
        }

        // 加载完成回调
        private bool isInitMeet;
        private void CoreLoaded(object sender, FrameLoadEndEventArgs e)
        {
            if (isInitMeet)
            {
                return;
            }

            isInitMeet = true;

            string url = Applicate.URLDATA.data.jitsiServer.Substring(8);
            string headUrl = ImageLoader.Instance.GetHeadUrl(Applicate.MyAccount.userId);
            string nickname = Applicate.MyAccount.nickname;

            //拼接参数
            Dictionary<string, string> dr = new Dictionary<string, string>();
            dr.Add("url", url);
            dr.Add("roomname", mOpenUrl);
            dr.Add("type", "0");
            dr.Add("nickname", nickname);
            dr.Add("header", headUrl);
            string json = JsonConvert.SerializeObject(dr);
            string info = "name(" + json + ")";
            // 开始通话
            mCoreMeet.ExecuteScriptAsync(info);
        }


        /// <summary>
        /// 注册一个网页监听器
        /// </summary>
        private void RegistCoreMeetListener()
        {
            //注册JS
            MeetCallEvent mEvent = new MeetCallEvent();
            mEvent.SetUserChangeListener((tag, url, name) =>
            {
                OnUserChange(tag, url, name);
            });

            mEvent.SetLoadListener(() =>
            {
                OnMeetLoaded();
            });

            var bindScriptOption = new CefSharp.BindingOptions();
            bindScriptOption.CamelCaseJavascriptNames = false;
            mCoreMeet.RegisterAsyncJsObject("jsObj", mEvent, bindScriptOption);
        }

        // 核心挂断电话
        public void ExitMeet()
        {
            if (mCoreMeet != null)
            {
                string info = "exitMeet()";
                mCoreMeet.ExecuteScriptAsync(info);
                mCoreMeet.Dispose();
                mCoreMeet = null;
            }
        }

        // 切换麦克风
        public void ToggleMike()
        {
            if (mCoreMeet != null)
            {
                string info = "toggleAudio()";
                mCoreMeet.ExecuteScriptAsync(info);
            }
        }


        #endregion

        #region ========================会议列表系统================================

        private void InitUserList()
        {
            // 加入自己
            RoomMember member = new RoomMember();
            member.userId = Applicate.MyAccount.userId;
            member.nickName = Applicate.MyAccount.nickname;
            UserAudioMeet uSEpicAddName = new UserAudioMeet();
            uSEpicAddName.NickName = Applicate.MyAccount.nickname;
            uSEpicAddName.Userid = Applicate.MyAccount.userId;
            uSEpicAddName.member = member;
            ImageLoader.Instance.DisplayAvatar(member.userId, uSEpicAddName.pics);
            uSEpicAddName.Margin = new Padding(10, 8, 3, 3);
            paljoins.Controls.Add(uSEpicAddName);

            UserAudioMeet useadd = new UserAudioMeet();
            useadd.pics.Image = Resources.Add_01;
            useadd.pics.Click += Invitemembenr;
            useadd.CenterPic();
            useadd.Margin = new Padding(10, 8, 3, 3);
            paljoins.Controls.Add(useadd);
        }

        public void OnUserChange(string tag, string avatarUrl, string name)
        {

            if (Thread.CurrentThread.IsBackground)
            {
                var main = new DelegateChangeUser(OnUserChange);
                Invoke(main, tag, avatarUrl, name);
                return;
            }

            string userId = MeetFormManager.IntercaptUserId(avatarUrl);

            // 成员退出
            if (string.Equals("user_exit", tag))
            {
                if (mUserList.ContainsKey(userId))
                {
                    mUserList.Remove(userId);
                    OnUserExited(userId);
                }
                return;
            }

            // 成员加入
            if (string.Equals("user_join", tag))
            {
                if (!mUserList.ContainsKey(userId))
                {
                    mUserList.Add(userId, name);
                    OnUserJoined(userId, name, avatarUrl);
                }
                return;
            }
        }

        private void OnUserJoined(string userId, string name, string avatar)
        {

            RoomMember member = new RoomMember();
            member.userId = userId;
            member.nickName = name;
            memList.Add(member);


            UserAudioMeet uSEpicAddName = new UserAudioMeet();
            uSEpicAddName.NickName = name;
            uSEpicAddName.Userid = userId;
            uSEpicAddName.member = member;
            ImageLoader.Instance.DisplayAvatar(userId, uSEpicAddName.pics);
            uSEpicAddName.Margin = new Padding(10, 8, 3, 3);

            paljoins.Controls.Add(uSEpicAddName);
            paljoins.Controls.SetChildIndex(uSEpicAddName, 0);

            ShowTip(name + "加入了会议");
        }

        private void OnUserExited(string userId)
        {
            string name = string.Empty;
            for (int i = 0; i < paljoins.Controls.Count; i++)
            {
                UserAudioMeet uSEpicAddName = (UserAudioMeet)paljoins.Controls[i];
                if (string.Equals(userId, uSEpicAddName.Userid))
                {
                    name = uSEpicAddName.member.nickName;
                    memList.Remove(uSEpicAddName.member);
                    paljoins.Controls.Remove(paljoins.Controls[i]);
                    break;
                }
            }

            if (!UIUtils.IsNull(name))
            {
                ShowTip(name + "离开了会议");
            }

        }

        #endregion




        /// <summary>
        /// 麦克风切换
        /// </summary>
        private void rbaudio_Click(object sender, EventArgs e)
        {
            ToggleMike();
            rbaudio.Image = isOpenRecord ? Resources.ic_audiomeeting_Audio : Resources.ic_audiomeeting_CnlAudio;
            isOpenRecord = !isOpenRecord;
        }

        /// <summary>
        /// /挂断
        /// </summary>
        private void OnClose_Click(object sender, EventArgs e)
        {
            ExitMeet();

            if (UIUtils.IsNull(memList))
            {
                ShiKuManager.SendVideoMeetingEndMsg(mFriend, false);
            }
            this.Close();
        }



        /// <summary>
        /// 扬声器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rblound_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 邀请好友
        /// </summary>
        public void Invitemembenr(object sender, EventArgs e)
        {
            //选择转发的好友
            var frmFriendSelect = new FrmFriendSelect();
            frmFriendSelect.LoadFriendsData(mFriend, memList);
            frmFriendSelect.AddConfrmListener((UserFriends) =>
            {
                if (UserFriends.Values.Count < 0)
                    return;
                List<Friend> toFriends = new List<Friend>();
                foreach (var friend in UserFriends.Values)
                    toFriends.Add(friend);
                ShiKuManager.SendGroupAudioMeetMsg(toFriends, mFriend.RoomId, mFriend.UserId);
            });
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmVoiceMeetRoom_FormClosed(object sender, FormClosedEventArgs e)
        {
            MeetFormManager.Instance.InitFrom();
            ExitMeet();

            if (timer_count != null)
            {
                //timer_count.Stop();//计时器停止
                timer_count.Dispose();
                timer_count = null;
            }
        }
    }
}
