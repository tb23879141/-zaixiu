using FFmpeg.AutoGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Helper.MVVM;
using WinFrmTalk.Live;
using WinFrmTalk.Live.Controls;
using WinFrmTalk.Model;

namespace WinFrmTalk.View
{
    public partial class FrmLive : FrmBase
    {
        #region 变量
        Point frmpoint;
        Point playerpoint;
        Size playersize;
        LiveCardBean LiveRoomInfo;//直播间信息
        FrmGiftTip FrmGift;//礼物窗体
        List<UserGiftItem> userGiftItemlst = new List<UserGiftItem>();//礼物项集合
        public int currentstate;
        FrmBarrage frmBarrage;
        SynchronizationContext m_SyncContext = null;    //UI线程的同步主线程
        public UseLiveList useLiveList { get; set; }

        public Dictionary<string, FrmLive> frmLivePairs = new Dictionary<string, FrmLive>();

        //记录已经打开的礼物窗口
        public Dictionary<string, FrmGiftTip> openGifeFrm = new Dictionary<string, FrmGiftTip>();


        private string openUrl;//已经打开的网址

        public FrmMain MainForm { get; set; }
        #endregion

        public FrmLive()
        {
            //this.isClose = false;
            InitializeComponent();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            Regeister();
            //初始化配置，指定引用库
            //vlcControl1.VlcLibDirectoryNeeded += vlcControl1_VlcLibDirectoryNeeded;
            // userBarrage1.Parent = userLivePlayer.ActivePlayer;//如果不设置会导致弹幕显示不出来，如果设置
            m_SyncContext = SynchronizationContext.Current; //同步上下文
        }
        #region 注册事件
        /// <summary>
        /// 监听
        /// </summary>
        public void Regeister()
        {
            //直播间的普通消息
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_NORMAL_MESSAGE, item => Getmonitor(item));
            //直播间的控制消息
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_lIVEROOMCTL_MESSAGE, item => Getmonitor(item));
        }
        public void Getmonitor(MessageObject msg)
        {
            if (this.IsHandleCreated)
            {


                Invoke(new Action(() =>
                {
                    if (string.Equals(LiveRoomInfo.jid, msg.ChatJid))//
                    {
                        switch (msg.type)
                        {//1572919294
                            case kWCMessageType.TYPE_SEND_DANMU://弹幕
                                                                // generateItem(msg.content);
                                                                //ShowBarrage(msg.content);
                                new Thread(new ThreadStart(() => { m_SyncContext.Post(ShowBarrage, msg.content); })).Start();
                                break;
                            case kWCMessageType.Text:
                                LiveChat.JudgeMsgIsAddToPanel(msg);//普通消息
                                break;
                            case kWCMessageType.TYPE_SEND_GIFT://礼物

                                Gift _gift = userPresentlst1.GetGift(msg.content);

                                if (!openGifeFrm.ContainsKey(msg.fromUserName))
                                {
                                    FrmGifTBack frmGifTBack = new FrmGifTBack();
                                    var count = openGifeFrm.Values.Count();//送礼用户数量
                                    FrmGift = new FrmGiftTip();
                                    FrmGift.ShowGift(msg, _gift);
                                    FrmGift.Location = new Point(this.Location.X + 20, (this.Location.Y + 300) + 70 * count);// (int)(this.Height * 0.75) + 70 * count);
                                    FrmGift.frmLive = this;
                                    FrmGift.isshow = false;
                                    frmGifTBack = new FrmGifTBack();
                                    frmGifTBack.Show(FrmGift, frmGifTBack, Color.FromArgb(60, 60, 60), 0.1, this);
                                    openGifeFrm.Add(msg.fromUserName, FrmGift);
                                }
                                else
                                {
                                    openGifeFrm[msg.fromUserName].ShowGift(msg, _gift);
                                }

                                #region 弃用
                                //FrmGift.ShowGift(msg, _gift);
                                //if (FrmGift.isshow)
                                //{

                                //    //1.目前问题大量发送礼物界面出现闪烁2.所有的字体图像，文字有严重锯齿
                                //    if (FrmGift.IsDisposed)
                                //    {
                                //        FrmGift = new FrmGiftTip();
                                //        FrmGift.ShowGift(msg, _gift);
                                //        FrmGift.Location = new Point(this.Location.X + 20, (int)(this.Height * 0.75));
                                //        FrmGift.frmLive = this;
                                //        FrmGift.isshow = false;

                                //        frmGifTBack = new FrmGifTBack();
                                //        frmGifTBack.Show(FrmGift, frmGifTBack, Color.FromArgb(60, 60, 60), 0.7, this);
                                //        openGifeFrm.Add(msg.fromUserName, FrmGift);
                                //        //FrmGift.Show(this);
                                //    }
                                //    else
                                //    {
                                //        FrmGift = new FrmGiftTip();
                                //        FrmGift.isshow = false;
                                //        FrmGift.Location = new Point(this.Location.X + 20, (int)(this.Height * 0.75));
                                //        frmGifTBack.Show(FrmGift, frmGifTBack, Color.FromArgb(60, 60, 60), 0.7, this);
                                //        // FrmGift.Show(this);
                                //    }

                                //}
                                //else
                                //{
                                //    //FrmGift.isshow = true;
                                //    //FrmGift.Location = new Point(this.Location.X + 20, (int)(this.Height * 0.75));
                                //    //frmGifTBack.Show(FrmGift, frmGifTBack, Color.FromArgb(60, 60, 60), 0.5, this);
                                //}

                                #endregion

                                msg.content = msg.fromUserName + "赠送礼物:" + _gift.name;
                                LiveChat.JudgeMsgIsAddToPanel(msg);

                                //else
                                //{
                                //    FrmGift = new FrmGiftTip();
                                //        frmGifTBack = new FrmGifTBack();
                                //    FrmGift.ShowGift(msg, _gift);
                                //    FrmGift.Location = new Point(this.Location.X + 20, (int)(this.Height * 0.75));
                                //    FrmGift.isshow = true;
                                //    frmGifTBack.Show(FrmGift, frmGifTBack, Color.FromArgb(60, 60, 60), 0.5);
                                //}

                                break;
                            case kWCMessageType.TYPE_SEND_ENTER_LIVE_ROOM://加入直播间
                                LiveChat.isupdate = true;
                                if (msg.toUserId != LiveRoomInfo.userId)
                                {
                                    LiveRoomInfo.numbers++;//非主播
                                }

                                usertitle.lbl_tips.Text = LiveRoomInfo.numbers.ToString();
                                if (!LiveChat.IsLoadRoom)
                                {
                                    if (msg.toUserId != Applicate.MyAccount.userId)
                                    {
                                        LiveChat.AddFans(msg);
                                    }
                                }
                                if (LiveChat.flag)
                                {
                                    LiveChat.flag = false;
                                    LiveChat.isupdate = true;

                                    Task.Factory.StartNew(() =>
                                    {
                                        Thread.Sleep(600);
                                        LiveChat.GetRoomLst(LiveRoomInfo.roomId);
                                    });
                                }

                                msg.content = msg.toUserName + "加入了直播间";

                                LiveChat.JudgeMsgIsAddToPanel(msg);//
                                break;
                            case kWCMessageType.TYPE_LIVE_EXIT_ROOM://踢出/退出直播间
                                LiveChat.isupdate = true;
                                LiveRoomInfo.numbers--;

                                if (LiveChat.flag)
                                {
                                    LiveChat.flag = false;
                                    LiveChat.isupdate = true;

                                    Task.Factory.StartNew(() =>
                                    {
                                        Thread.Sleep(600);
                                        LiveChat.GetRoomLst(LiveRoomInfo.roomId);
                                    });
                                }

                                usertitle.lbl_tips.Text = LiveRoomInfo.numbers.ToString();
                                if (!LiveChat.IsLoadRoom)
                                {
                                    if (msg.toUserId != Applicate.MyAccount.userId)
                                    {
                                        LiveChat.DelFans(msg);
                                    }
                                }
                                msg.content = msg.toUserName + "退出了直播间";
                                LiveChat.JudgeMsgIsAddToPanel(msg);

                                //if (msg.toUserId.Equals(Applicate.MyAccount.userId))
                                //{

                                //    userLivePlayer.CloseLive(this);
                                //}
                                if (msg.toUserId.Equals(LiveRoomInfo.userId) || msg.toUserId.Equals(Applicate.MyAccount.userId))
                                {
                                    if (userLivePlayer.ActivePlayer is VlcControl vlc)
                                    {
                                        vlc.Stop();
                                    }
                                }
                                break;
                            case kWCMessageType.TYPE_SEND_HEART://点赞
                                break;
                            case kWCMessageType.TYPE_LIVE_SET_MANAGER:
                                LiveChat.SetAdmin(msg, msg.content);

                                if (LiveChat.flag)
                                {
                                    LiveChat.flag = false;
                                    LiveChat.isupdate = true;

                                    Task.Factory.StartNew(() =>
                                    {
                                        Thread.Sleep(600);
                                        LiveChat.GetRoomLst(LiveRoomInfo.roomId);
                                    });
                                }

                                if (msg.content.Equals("0"))
                                {
                                    if (msg.toUserId.Equals(Applicate.MyAccount.userId))//我被设置或取消管理员
                                    {
                                        LiveChat.Role = 3;
                                    }
                                    msg.content = msg.fromUserName + "取消了" + msg.toUserName + "为管理员";
                                }
                                else
                                {
                                    if (msg.toUserId.Equals(Applicate.MyAccount.userId))//我被设置或取消管理员
                                    {
                                        LiveChat.Role = 2;
                                    }
                                    msg.content = msg.fromUserName + "设置" + msg.toUserName + "为管理员";
                                }
                                LiveChat.JudgeMsgIsAddToPanel(msg);//

                                break;
                            case kWCMessageType.TYPE_LIVE_SHAT_UP://禁言
                                if (!LiveChat.IsLoadRoom)
                                {
                                    //LiveChat.SetTalk(msg, msg.content);
                                }
                                if (msg.toUserId.Equals(Applicate.MyAccount.userId))
                                {
                                    if (msg.content != "0")
                                    {
                                        currentstate = 1;
                                    }
                                    else
                                    {
                                        currentstate = Convert.ToInt32(msg.content);
                                    }

                                    setTalk();
                                }
                                if (msg.content.Equals("0"))
                                {
                                    msg.content = msg.fromUserName + "对" + msg.toUserName + "取消了禁言";
                                }
                                else
                                {
                                    msg.content = msg.toUserName + "已被" + msg.fromUserName + "禁言";
                                }

                                LiveChat.JudgeMsgIsAddToPanel(msg);//


                                break;

                            default:

                                break;
                        }

                    }

                }));
            }
        }


        #endregion
        #region 窗体加载/关闭
        private void FrmLive_Load(object sender, EventArgs e)
        {
            FFmpegBinariesHelper.RegisterFFmpegBinaries();
            SetupLogging();
            LiveChat.btntext.Click += BtnSend_Click;//发送
            LiveChat.txtSend.KeyUp += BtnSend_KeyUp;
            usertitle.PalAll.Click += PalAll_Click;
            usertitle.lbl_All.Click += PalAll_Click;
            usertitle.pic_check.Click += PalAll_Click;
            Console.WriteLine("z直播窗体位置之前");
            playerpoint = userLivePlayer.Location;
            Console.WriteLine("z直播窗体位置之后");
            frmpoint = this.Location;
            Console.WriteLine("frmpoint位置之后");
            playersize = userLivePlayer.Size;
            Console.WriteLine("playersize位置之后");
            frmBarrage = new FrmBarrage();
            Console.WriteLine("frmBarrage之后");

            // frmBarrage.Show();
        }
        public void GetmyInfo()
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "liveRoom/get/member")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", LiveRoomInfo.roomId)
                .AddParams("userId", Applicate.MyAccount.userId)
                .Build()
                .Execute((success, result) =>
                {
                    if (success)
                    {
                        currentstate = UIUtils.DecodeInt(result, "talkTime");
                        LiveChat.Role = UIUtils.DecodeInt(result, "type");
                        setTalk();
                    }
                });
        }
        public void setTalk()
        {
            LiveChat.TalkState = currentstate;
            if (currentstate == 1 && LiveChat.btntext.Text == "发送")
            {
                LiveChat.txtSend.Enabled = false;
                LiveChat.btntext.Enabled = false;

            }
            else
            {
                LiveChat.txtSend.Enabled = true;
                LiveChat.btntext.Enabled = true;

            }
        }
        /// <summary>
        /// 全屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PalAll_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            userLivePlayer.BringToFront();
            userLivePlayer.Location = new Point(0, 38);
            userLivePlayer.Size = new Size(this.Size.Width, this.Size.Height - 38);
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLive_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!userLivePlayer.isCanClose)
            {
                e.Cancel = true;
                if (userLivePlayer.ActivePlayer is VlcControl vlcControl)
                {
                    Console.WriteLine("1");
                    vlcControl.Stop();
                }
                else
                {
                    useLiveList.frmLivePairs.Remove(openUrl);//去除已经打开的记录
                    userLivePlayer.CloseLive(this);
                }
            }
            else
            {
                //如果为群内直播，需要设置isOpen为false
                if (!string.IsNullOrEmpty(userLivePlayer.liveCardBean.liveRoomId))
                {
                    var liveBean = LiveRoomNotice.lives.Where(live => live.Key == userLivePlayer.liveCardBean.liveRoomId).Select(l => l.Value).FirstOrDefault();
                    //liveBean.isOpen = false;
                    liveBean.ClearLiveData();
                }

                frmBarrage.IsShow = false;
                frmBarrage.Close();
                Applicate.isliveopen = false;
                //userLivePlayer.CloseLive(this);
                userLivePlayer.isspoot = false;
                FrmGift.isshow = true;
                FrmGift.count.Clear();
                useLiveList.frmLivePairs.Remove(openUrl);//去除已经打开的记录
                FrmGift.Close();
            }
        }

        private void FrmLive_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
        #endregion
        #region 发送弹幕/直播聊天事件
        /// <summary>
        /// 回车发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSend_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                BtnSend_Click(null, null);

            }
        }
        #region 发送事件
        /// <summary>
        /// 显示弹幕
        /// </summary>
        /// <param name="text"></param>
        public void ShowBarrage(object text)
        {
            //frmBarrage.TopMost= true;

            //frmBarrage.Parent = this;
            //frmBarrage.MdiParent = this;

            if (!frmBarrage.IsShow)
            {
                if (frmBarrage.IsDisposed)
                {
                    frmBarrage = new FrmBarrage();
                    frmBarrage.ShowIcon = false;
                    frmBarrage.ShowInTaskbar = false;
                    frmBarrage.Location = new Point(this.Location.X + 15, this.Location.Y + 120);
                    frmBarrage.generateItem(text.ToString());
                    //frmBarrage.BringToFront();
                    //frmBarrage.MdiParent = this;
                    //frmBarrage.Parent = this;
                    frmBarrage.Show(this);
                    frmBarrage.IsShow = true;
                }
                else
                {
                    frmBarrage.ShowIcon = false;
                    frmBarrage.ShowInTaskbar = false;
                    frmBarrage.Location = new Point(this.Location.X + 15, this.Location.Y + 120);
                    frmBarrage.generateItem(text.ToString());
                    frmBarrage.Show(this);
                    frmBarrage.IsShow = true;

                }

            }
            else
            {
                frmBarrage.ShowIcon = false;
                frmBarrage.ShowInTaskbar = false;
                frmBarrage.Location = new Point(this.Location.X + 15, this.Location.Y + 120);
                frmBarrage.generateItem(text.ToString());

            }
        }
        int lastsentTime = 0;
        private void BtnSend_Click(object sender, EventArgs e)
        {
            string text = LiveChat.txtSend.Text.Replace("\r", " ").Replace("\n", " ").Replace("开启大喇叭，1钻石/条", "");
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(LiveChat.txtSend.Text))
            {
                if (LiveChat.CheckBarrage)
                {
                    if (text.Length > 15)
                    {
                        HttpUtils.Instance.ShowTip("弹幕不能超过15个字");
                        return;
                    }
                    //MessageObject txt_msg = null;
                    //txt_msg = ShiKuManager.SendBarrageMessage(LivebeanToFriend(), text.TrimEnd(), true);
                    int nowtime = TimeUtils.CurrentIntTime();
                    if (nowtime - lastsentTime > 1)
                    {
                        //lastsentTime = nowtime;
                        SendBarrage(LiveRoomInfo.roomId, Applicate.MyAccount.userId, text);
                        //new Thread(new ThreadStart(() => { m_SyncContext.Post(ShowBarrage, text); })).Start();

                    }
                    else
                    {
                        HttpUtils.Instance.ShowTip("间隔时间太短");
                    }

                    //ShowBarrage(text);

                    #region dzj_test

                    #endregion
                }
                else
                {
                    MessageObject txt_msg = null;
                    txt_msg = ShiKuManager.SendTextMessage(LivebeanToFriend(), text.TrimEnd());

                    LiveChat.JudgeMsgIsAddToPanel(txt_msg);
                }
            }
            else
            {
                HttpUtils.Instance.ShowTip("输入不能为空");
                return;
            }
            LiveChat.txtSend.Clear();//清除发送框
        }
        #endregion
        /// <summary>
        /// 调接口发送弹幕
        /// </summary>
        /// <param name="Roomid">直播室的roomid</param>
        /// <param name="Userid">发送者的userid</param>
        /// <param name="Text">发送文字</param>

        public void SendBarrage(string Roomid, string Userid, string Text)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/barrage")
               .AddParams("access_token", Applicate.Access_Token)
               .AddParams("roomId", Roomid)
               .AddParams("userId", Userid)
                .AddParams("text", Text)
               .Build()
               .Execute((success, result) =>
               {
                   if (success && result != null)
                   {
                       //MessageObject txt_msg = null;
                       //txt_msg = ShiKuManager.SendBarrageMessage(LivebeanToFriend(), Text.TrimEnd(), true);
                       // // generateItem(Text);
                       // //ShowBarrage(Text);
                       // //目前问题：1.文字有白边2.窗体关闭（1.如果当frmBarrage窗体未开启的时候就显示，开启后就不显示，本窗体关闭的时候就关闭frmBarrage）
                       // if (!frmBarrage.IsShow)
                       // {
                       //     frmBarrage.Show();
                       //     frmBarrage.IsShow = true;
                       // }
                       //// frmGifTBack.Show(frmBarrage, this, Color.FromArgb(60, 60, 60), 0.1,this);
                   }
               });
        }


        #endregion
        /// <summary>
        /// 直播间的实体类转换为Friend类
        /// </summary>
        /// <returns></returns>
        public Friend LivebeanToFriend()
        {
            Friend friend = new Friend { UserId = LiveRoomInfo.jid, NickName = LiveRoomInfo.nickName, RoomId = LiveRoomInfo.roomId, IsGroup = 1 };
            return friend;
        }



        //static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    Console.WriteLine(e.ExceptionObject.ToString());
        //    Console.ReadLine();
        //}


        //private void OnPlay(int index)
        //{
        //    //ff
        //}

        private static unsafe void SetupLogging()
        {
            ffmpeg.av_log_set_level(ffmpeg.AV_LOG_VERBOSE);

            // do not convert to local function
            av_log_set_callback_callback logCallback = (p0, level, format, vl) =>
            {
                if (level > ffmpeg.av_log_get_level()) return;

                var lineSize = 1024;
                var lineBuffer = stackalloc byte[lineSize];
                var printPrefix = 1;
                ffmpeg.av_log_format_line(p0, level, format, vl, lineBuffer, lineSize, &printPrefix);
                var line = Marshal.PtrToStringAnsi((IntPtr)lineBuffer);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(line);
                Console.ResetColor();
            };

            ffmpeg.av_log_set_callback(logCallback);
        }

        #region 开启直播间

        /// <summary>
        /// 开启直播间
        /// </summary>
        /// <param name="url"></param>
        /// <param name="liveCardBean"></param>
        /// <param name="liveType"></param>
        internal void LiveStart(string url, LiveCardBean liveCardBean, int liveType)
        {
            LiveRoomInfo = new LiveCardBean();
            LiveRoomInfo = liveCardBean;
            FrmGift = new FrmGiftTip();
            openUrl = url;
            //推流
            if (liveType == 0)
            {
                Action<string> close_live = new Action<string>((content) =>
                {
                    var result = ShowTipBox(content);
                    this.Close();
                });
                userLivePlayer.StartLive_Push(url, liveCardBean, this, close_live);
            }
            //拉流
            else if (liveType == 1)
            {
                Console.WriteLine("点开始播流");
                userLivePlayer.StartLive_Pull(url, liveCardBean, this);
            }
            //群内直播——推流
            else if (liveType == 2)
            {
                Action<string> close_live = new Action<string>((content) =>
                {
                    var result = ShowTipBox(content);
                    this.Close();
                });
                userLivePlayer.StartRoomLive_Push(url, liveCardBean, this, close_live);
            }
            //群内直播——拉流
            else if (liveType == 3)
            {
                Console.WriteLine("点开始播流");
                userLivePlayer.StartRoomLive_Pull(url, liveCardBean, this);
            }

            if (Applicate.MyAccount.userId != LiveRoomInfo.userId)
            {
                LiveRoomInfo.numbers++;//非主播
            }
            else
            {
                userPresentlst1.Visible = false;
                userLivePlayer.Size = new System.Drawing.Size(userLivePlayer.Width, 584);
            }
            userPresentlst1.setdata(LiveRoomInfo);
            usertitle.setdata(LiveRoomInfo, this);
            LiveChat.LiveRoomInfo = LiveRoomInfo;
        }
        /// <summary>
        /// 用于我打开别人的直播间（在进入直播间前先调取接口，有可能我被踢出了，不允许进入）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="liveCardBean"></param>
        /// <param name="liveType"></param>
        /// <param name="frmLive"></param>
        internal void LiveStarts(string url, LiveCardBean liveCardBean, int liveType, FrmLive frmLive)
        {
            LiveRoomInfo = new LiveCardBean();
            LiveRoomInfo = liveCardBean;
            FrmGift = new FrmGiftTip();
            userLivePlayer.StartLive_Pulls(url, liveCardBean, frmLive);
            userPresentlst1.setdata(LiveRoomInfo);
            usertitle.setdata(LiveRoomInfo, this);
            //  userGiftItemlst = userPresentlst1.userGiftItems;
            LiveChat.LiveRoomInfo = LiveRoomInfo;

        }
        #endregion


        private void FrmLive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {

                    this.WindowState = FormWindowState.Normal;
                    userLivePlayer.Location = playerpoint;
                    userLivePlayer.Size = playersize;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void FrmLive_SizeChanged(object sender, EventArgs e)
        {

            if (this.WindowState != FormWindowState.Minimized && this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                userLivePlayer.Location = playerpoint;
                userLivePlayer.Size = playersize;
            }
            else
            {
                //this.WindowState = FormWindowState.Maximized;
                //userLivePlayer.BringToFront();
                //userLivePlayer.Location = new Point(0, 38);
                //userLivePlayer.Size = new Size(this.Size.Width, this.Size.Height - 38);

            }
            frmBarrage.Size = new Size(userLivePlayer.Size.Width, frmBarrage.Height);
            if (this.WindowState == FormWindowState.Minimized)
            {
                FrmGift.Visible = false;
                // frmGifTBack.Visible = false;
            }
            else
            {
                //FrmGift.Visible = true;
                // frmGifTBack.Visible = true;
            }
        }

        private void FrmLive_Move(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var item in openGifeFrm.Values)
            {
                item.Location = new Point(this.Location.X + 20, (this.Location.Y + 300) + 70 * i);
                i++;
            }
            if (frmBarrage == null)
            {
                frmBarrage = new FrmBarrage();
            }
            frmBarrage.Location = new Point(this.Location.X + 15, this.Location.Y + 120);
        }

        private void FrmLive_Deactivate(object sender, EventArgs e)
        {
            //frmBarrage.Visible = false
        }
    }
}
