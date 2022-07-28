using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;

namespace WinFrmTalk.View
{
    public partial class FrmRecivePhone : FrmBase
    {
        #region 窗体加载
        public FrmRecivePhone()
        {
            InitializeComponent();
            isEscClose = false;
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle); //加载icon图标
            //验证窗体是否再次打开
            SelfPermission.Instance.RequestOpenVideoPermission();
            //按钮
            rpboxClose.Image = Resources.ClosePhone;
        }
        #endregion

        #region 全局变量
        private delegate void DelegateString(string msg);
        private bool IsGroup;
        public int StartTime { get; private set; }
        Friend myFriend;

        /// <summary>
        /// 接听类型 0 语音 1视频 2屏幕
        /// </summary>
        private int MeetType;


        //第三方浏览器界面
        private ChromiumWebBrowser CWebBrowser;
        //开启计时器
        private System.Timers.Timer timer = new System.Timers.Timer();
        private bool isClose;
        //开启新的计时器
        //计算时间结束
        //传递过来的地址
        public string myUserid { get; internal set; }
        private MessageObject groupMessage;
        #endregion
        #region ping与消息管理

        //接听
        //消息验证的方法
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
                    //开启计时器
                    AutoMeetDisconn();
                }
            }
        }
        public void StartSendPing()
        {
            //开启线程
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("我发送了ping消息：：：：" + FrmMain.isRecovePhone);
                //循环多次发送
                while (FrmMain.isRecovePhone == 2)
                {
                    //3秒一个包10次一个包收不到就挂断
                    Thread.Sleep(3 * 1000);
                    //挂断
                    Console.WriteLine("我发送了ping消息：：：：" + FrmMain.isRecovePhone);
                    ShiKuManager.SendMeetPingMessage(myFriend);
                }
            });
        }
        //  消息初始化
        public void InitTimer()
        {
            timer.Interval = 30 * 1000; //30秒刷新界面
            //间隔到触发事件
            timer.Elapsed += new System.Timers.ElapsedEventHandler(DisconnMeet);
            //设置是false执行一次还是一直执行(true)
            timer.AutoReset = false;
            timer.Enabled = false; //是否执行System.Timers.Timer.Elapsed事件；
            AutoMeetDisconn();
        }

        //计时器的开启
        public void AutoMeetDisconn()
        {
            timer.Stop();
            timer.Start();
        }

        //间隔到触发的事件
        private void DisconnMeet(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("吉时已到挂电话：：：：");
            //关闭本窗体
            this.Close();
            //发送消息给对方
            int tiemLen = TimeUtils.CurrentIntTime() - StartTime;

            SnedEndMessage(myFriend, MeetType, tiemLen);
        }


        #endregion

        #region 窗体加载
        private void FrmRecivePhone_Load(object sender, EventArgs e)
        {
            IniitCefsharp();
            //消息通知
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_MEETING_MESSAGE, MainMessage);
            StartSendPing();
        }

        private void IniitCefsharp()
        {
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            string path = Environment.CurrentDirectory + "\\Cefsharp.html";
            //调用浏览器
            CWebBrowser = new ChromiumWebBrowser(path);
            panel1.Controls.Add(CWebBrowser);
            CWebBrowser.Dock = DockStyle.Fill;
            CWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>(FrmEnd);

            // 1.注册网页监听
            //  RegistBrowserListener(CWebBrowser);


        }
        public bool isLoad = false;
        private void StartMain(string data)
        {
            if (Thread.CurrentThread.IsBackground)
            {
                var main = new DelegateString(StartMain);
                Invoke(main, data);
                rpboxClose_Click(null, null);
                return;
            }

        }
        public void Audiomute()
        {
            if (CWebBrowser != null)
            {
                string info = "Audiomute()";
                CWebBrowser.ExecuteScriptAsync(info);

            }
        }
        public bool loadingsucee = false;
        private void FrmEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (isLoad)
            {
                loadingsucee = true;
                return;
            }
            isLoad = true;
            Dictionary<string, string> dr = new Dictionary<string, string>();
            string url = Applicate.URLDATA.data.jitsiServer;
            url = url.Substring(8);
            string headUrl = ImageLoader.Instance.GetHeadUrl(Applicate.MyAccount.userId);
            dr.Add("url", url);
            dr.Add("roomname", myUserid);
            int r = 0;
            if (MeetType == 0 || MeetType == 2)
            {
                r = 1;
            }
            dr.Add("type", r.ToString());
            if (IsGroup)
            {
                // 修改会议中我的名字不对的问题2020-2-26 20:25:12
                dr.Add("nickname", Applicate.MyAccount.nickname);
            }
            dr.Add("header", headUrl);
            string json = JsonConvert.SerializeObject(dr);
            string info = "name(" + json + ")";
            CWebBrowser.ExecuteScriptAsync(info);
        }

        #endregion


        #region 参数传递

        //好友的接听
        internal void fillDataFrined(Friend friend, int meettype, string url)
        {
            MeetType = meettype;
            myFriend = friend;
            myUserid = url;

            this.Show();
            //开始计时
            StartTime = TimeUtils.CurrentIntTime();
        }

        //群聊接听
        internal void ShowGroup(Friend friend, string url, bool isGroup, int meettype, MessageObject Message)
        {
            MeetType = meettype;
            myFriend = friend;
            IsGroup = isGroup;
            this.myUserid = url;
            this.groupMessage = Message;


            this.Show();
            //开始计时
            StartTime = TimeUtils.CurrentIntTime();


        }

        #endregion


        public void ExitMeet()
        {
            if (CWebBrowser != null)
            {
                string info = "exitMeet()";
                CWebBrowser.ExecuteScriptAsync(info);

            }
        }

        public string getCount()
        {
            Task<CefSharp.JavascriptResponse> t = CWebBrowser.EvaluateScriptAsync("GetNumber()");
            // 等待js 方法执行完后，获取返回值

            t.Wait();
            // t.Result 是 CefSharp.JavascriptResponse 对象
            // t.Result.Result 是一个 object 对象，来自js的 callTest2() 方法的返回值
            if (t.Result.Result != null)
            {
                return t.Result.Result.ToString();
            }
            else
            {
                return "-1";
            }
        }

        #region 窗体关闭
        //按钮窗体关闭
        public void rpboxClose_Click(object sender, EventArgs e)
        {

            MeetFormManager.Instance.InitFrom();
            if (!IsGroup)
            {
                //调用xmpp消息
                //发送消息回执
                //结束时间
                int tiemLen = TimeUtils.CurrentIntTime() - StartTime;
                ExitMeet();
                SnedEndMessage(myFriend, MeetType, tiemLen);

                this.Close();
                return;

            }
            else
            {
                ExitMeet();
                string CurrentCount = getCount();
                if (CurrentCount == "-1" && loadingsucee)
                {
                    Friend friend = new Friend { IsGroup = 1, UserId = groupMessage.objectId, RoomId = groupMessage.fileName };

                    SnedMeetingEndMessage(friend, MeetType);
                }
                this.Close();
                return;
            }
        }
        //关闭
        private void btnClosed_Click(object sender, EventArgs e)
        {
            rpboxClose_Click(sender, e);
        }
        //窗体关闭
        private void FrmRecivePhone_FormClosed(object sender, FormClosedEventArgs e)
        {
            MeetFormManager.Instance.InitFrom();
            Messenger.Default.Unregister(this);
            this.Dispose();
            isClose = true;
        }
        #endregion

        #region js转换类

        /// <summary>
        /// 注册一个网页监听器
        /// </summary>
        private void RegistBrowserListener(ChromiumWebBrowser cWebBrowser)
        {
            //注册JS
            //JSEvent sEvent = new JSEvent();
            //sEvent.SetSelectListener((url) =>
            //{
            //    OnReceMeetJoined(url);
            //});

            //sEvent.SetExitListener((url) =>
            //{
            //    OnReceMeetExit(url);
            //});

            //var bindScriptOption = new CefSharp.BindingOptions();
            //bindScriptOption.CamelCaseJavascriptNames = false;
            //cWebBrowser.RegisterAsyncJsObject("jsObj", sEvent, bindScriptOption);

        }


        public string joins;
        /// <summary>
        /// 收到了来自网页的成员加入的消息
        /// </summary>
        /// <param name="avaurl"></param>
        /// 

        public Action<string, bool> joinsInfo;//录像保存的本地路径和时间

        public void OnReceMeetJoined(string avatarUrl)
        {
            string userId = MeetFormManager.IntercaptUserId(avatarUrl);
            joins = userId;
            joinsInfo?.Invoke(joins, isjoins);

            Console.WriteLine("获取到的头像地址" + avatarUrl);
            Console.WriteLine("获取到的userid" + userId);

            // 这个方法不确定是否UI线程，如果不能直接创建UI就需要换线程

        }

        public void OnReceMeetExit(string avatarUrl)
        {
            string userId = MeetFormManager.IntercaptUserId(avatarUrl);
            joins = userId;
            joinsInfo?.Invoke(joins, isjoins);

            Console.WriteLine("获取到的头像地址" + avatarUrl);
            Console.WriteLine("获取到的userid" + userId);

            // 这个方法不确定是否UI线程，如果不能直接创建UI就需要换线程
        }

        static bool isjoins;


        #endregion
        #region 窗体改变大小
        private void FrmRecivePhone_SizeChanged(object sender, EventArgs e)
        {
            if (!isLoad)
            {
                return;
            }
            if (WindowState == FormWindowState.Maximized)
            {
                Dictionary<string, string> dr = new Dictionary<string, string>();
                dr.Add("width", this.Width.ToString() + "px");
                dr.Add("height", (this.Height - 30).ToString() + "px");
                string json = JsonConvert.SerializeObject(dr);
                string info = "changeSize(" + json + ")";
                CWebBrowser.ExecuteScriptAsync(info);
            }
            if (WindowState == FormWindowState.Normal)
            {
                Dictionary<string, string> dr = new Dictionary<string, string>();
                dr.Add("width", this.Width.ToString() + "px");
                dr.Add("height", (this.Height - 30).ToString() + "px");
                string json = JsonConvert.SerializeObject(dr);
                string info = "changeSize(" + json + ")";
                CWebBrowser.ExecuteScriptAsync(info);
            }
        }
        #endregion


        /// <summary>
        /// 发送挂断的xmpp消息
        /// </summary>
        /// <param name="myFriend"></param>
        /// <param name="meetType"></param>
        /// <param name="tiemLen"></param>
        private void SnedEndMessage(Friend toFriend, int meetType, int tiemLen)
        {
            switch (meetType)
            {
                case 0:
                    ShiKuManager.SendEndMeetMessage(myFriend, false, tiemLen);
                    break;
                case 1:
                    ShiKuManager.SendEndMeetMessage(myFriend, true, tiemLen);
                    break;
                case 2:
                    ShiKuManager.SendEndScreenMeetMsg(myFriend, tiemLen);
                    break;
                default:
                    break;
            }
        }
        public void SnedMeetingEndMessage(Friend toFriend, int meetType)
        {
            switch (meetType)
            {
                case 0:
                    ShiKuManager.SendVideoMeetingEndMsg(toFriend, false);
                    break;
                case 1:
                    ShiKuManager.SendVideoMeetingEndMsg(toFriend, true);
                    break;

            }
        }

        private void btnClosed_MouseMove(object sender, MouseEventArgs e)
        {

            this.panel2.BackColor = Color.FromArgb(152, 152, 152);
        }

        private void btnClosed_MouseLeave(object sender, EventArgs e)
        {
            this.panel2.BackColor = Color.FromArgb(71, 71, 71);
        }
    }

}
