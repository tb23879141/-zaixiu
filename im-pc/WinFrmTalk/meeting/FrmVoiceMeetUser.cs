using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;
using static MeetFormManager;

namespace WinFrmTalk.View
{
    public partial class FrmVoiceMeetUser : FrmBase
    {
        // 当前通话对象
        public Friend mFriend { get; set; }

        public string mOpenUrl { get; set; }

        // 是否开启扬声器
        private bool isOpenSound;

        // 是否开启麦克风
        private bool isOpenRecord;

        // 是否开启麦克风
        private bool isFrmClose;

        // 通话时间
        private int MeetTime = 0;

        public FrmVoiceMeetUser()
        {
            InitializeComponent();
            rbhung.Image = Resources.ClosePhone;
            rbaudio.Image = Resources.ic_audiomeeting_Audio;

            SelfPermission.Instance.RequestOpenVideoPermission();

        }


        public void ConnectVoice(Friend friend, string url)
        {
            this.mFriend = friend;
            this.mOpenUrl = url;


        }


        private void FrmVoiceMeetUser_Load(object sender, EventArgs e)
        {
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_MEETING_MESSAGE, MainMessage);
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

            InitTimer();
            StopLoading();

            ImageLoader.Instance.DisplayAvatar(mFriend.UserId, pichead);
            lblinvite.Text = mFriend.GetRemarkName();
        }


        private void ShowLoading()
        {
            loding.Visible = true;
        }

        private void StopLoading()
        {
            loding.Visible = false;
        }

        #region =========================消息处理=================================

        private long mLastRecePingTime;
        private long mLastSendPingTime;

        public void MainMessage(MessageObject message)
        {
            //结束通话
            if (message.type == kWCMessageType.AudioChatEnd || message.type == kWCMessageType.VideoChatEnd || message.type == kWCMessageType.ScreenMeetEnd)
            {
                MeetFormManager.Instance.InitFrom();
                ExitMeet();
                this.Close();
            }

            //通话中
            if (message.type == kWCMessageType.PhoneCalling)
            {
                Console.WriteLine("我收到了ping消息：：：：");
                //收不到消息的时候
                if (!message.IsMySend())
                {
                    // 最后一次收到对方的ping消息时间
                    mLastRecePingTime = TimeUtils.CurrentIntTime();
                }
            }
        }

        private void HandlePingMessage()
        {
            long crrt = TimeUtils.CurrentIntTime();
            // 对方超过了30秒没有ping我，说明已经掉线了 
            if (crrt - mLastRecePingTime > 30)
            {
                Console.WriteLine("超时间没有收到对方的ping消息");
                ExitMeet();
                //关闭本窗体
                this.Close();
                //发送消息给对方
                ShiKuManager.SendEndMeetMessage(mFriend, false, MeetTime);
            }
        }

        private void SendPingMeeage()
        {
            mLastSendPingTime++;

            if (mLastSendPingTime > 5)
            {
                mLastSendPingTime = 0;
                Console.WriteLine("单聊语音通话:发送了ping消息");
                ShiKuManager.SendMeetPingMessage(mFriend);
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
            mLastRecePingTime = TimeUtils.CurrentIntTime();
            mLastSendPingTime = 0;
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

            if (!isFrmClose)
            {
                this.lbltime.Text = text;
            }
            
            // 处理ping机制.
            HandlePingMessage();
            SendPingMeeage();
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
            dr.Add("type", "1");
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
            //mEvent.SetLoadListener(() =>
            //{
                OnMeetLoaded();
           // });

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
            isFrmClose = true;
            ExitMeet();
            ShiKuManager.SendEndMeetMessage(mFriend, false, MeetTime);
            this.Close();
        }


        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmVoiceMeetUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            isFrmClose = true;
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