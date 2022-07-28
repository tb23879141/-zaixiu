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
using WinFrmTalk.Helper.MVVM;
using WinFrmTalk.Live;
using WinFrmTalk.Model;
using WinFrmTalk.View;

namespace WinFrmTalk.Live.Controls
{
    public partial class UserLivePlayer : UserControl
    {
        private string rtmp_url = string.Empty;
        private Process process = null;
        private Thread _Thread = null;
        public Control ActivePlayer { get; private set; }
        public LiveCardBean liveCardBean { get; private set; }
        private LodingUtils loding;         //等待符控件全局
        public bool isCanClose = false;    //指示窗体是否可以关闭，必须先结束直播线程再关闭窗体
        public UserLivePlayer()
        {
            InitializeComponent();
            vlcControl1.EndInit();

        }

        EQPushStream pushStream;
        private void ShowLodingDialog()
        {
            loding = new LodingUtils();
            loding.parent = vlcControl1;
            loding.Title = "加载中";
            loding.start();
        }
        public void StartLive_Push(string rtmp_url, LiveCardBean liveCardBean, FrmLive frmLive, Action<string> close_live)
        {
            try
            {
                ActivePlayer = this.playwnd1;
                this.liveCardBean = liveCardBean;
                //如果是自己的直播间，要进行推流
                //if (liveCardBean.userId.Equals(Applicate.MyAccount.userId))
                //创建直播间
                HttpUtils.Instance.InitHttp(this);
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/start")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("roomId", liveCardBean.roomId)
                    .AddParams("status", "1")
                    .Build()
                    .Execute((success, result) =>
                    {
                        if (success && result != null && result.Count > 0)
                        {
                            //显示pictureBox不显示VLC
                            playwnd1.BringToFront();
                            playwnd1.Enabled = true;
                            playwnd1.Visible = true;
                            vlcControl1.Enabled = false;
                            vlcControl1.Visible = false;

                            //加入直播间
                            //http get请求获得数据
                            HttpUtils.Instance.InitHttp(this);
                            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/enterInto")
                                .AddParams("access_token", Applicate.Access_Token)
                                .AddParams("roomId", liveCardBean.roomId)
                                .AddParams("userId", Applicate.MyAccount.userId)
                                .Build()
                                .Execute((success_e, result_e) =>
                                {
                                    if (success_e && result_e != null && result_e.Count > 0)
                                    {
                                        frmLive.GetmyInfo();
                                        ShiKuManager.mSocketCore.JoinRoom(liveCardBean.jid, 0);
                                    }

                                });

                            //OpenLiveStreaming
                            //Task.Factory.StartNew(() =>
                            _Thread = new Thread(new ThreadStart(() =>
                            {
                                Applicate.IsPullLive = true;
                                CancellationTokenSource tokenSource = new CancellationTokenSource();
                                pushStream = new EQPushStream();
                                int push_ret = pushStream.StartPush(liveCardBean.url, (bmp) =>
                                {
                                    try
                                    {
                                        //Graphics gp = playwnd1.CreateGraphics();
                                        //gp.SmoothingMode = SmoothingMode.HighSpeed;
                                        //gp.DrawImage(bmp, 0, 0, (int)playwnd1.Size.Width, (int)playwnd1.Size.Height); //在窗体的画布中绘画出内存中的图像
                                        //gp.Dispose();

                                        Bitmap bitmap = new Bitmap(playwnd1.Size.Width, playwnd1.Size.Height);
                                        Graphics g = Graphics.FromImage(bitmap);
                                        g.SmoothingMode = SmoothingMode.HighSpeed;
                                        g.DrawImage(bmp, 0, 0, playwnd1.Size.Width, playwnd1.Size.Height);
                                        if (playwnd1.Image != null)
                                        {
                                            Image img = playwnd1.Image;
                                            playwnd1.Image = null;
                                            playwnd1.Image = bitmap;
                                            img.Dispose();
                                        }
                                        else
                                        {
                                            playwnd1.Image = bitmap;
                                        }
                                        LoopLable();
                                        g.Dispose();
                                    }
                                    catch (Exception ex) { }
                                });
                                if (push_ret < 0)
                                {
                                    isCanClose = true;
                                }
                                if (push_ret == -10) //open output error.
                                {
                                    //HttpUtils.Instance.ShowTip("打开直播流时出错，可能导致此问题的原因：\n1.正在其他端进行直播，直播地址被占用。\n2.输入的摄像头或者麦克风异常。");
                                    string error = "打开直播流时出错，可能导致此问题的原因：\n1.正在其他端进行直播，直播地址被占用。\n2.输入的摄像头或者麦克风异常。";
                                    close_live(error);
                                }
                            }));
                            _Thread.IsBackground = true;
                            _Thread.SetApartmentState(ApartmentState.STA);
                            _Thread.Start();
                            Console.WriteLine("================== my player start ==================");

                        }
                    });

            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public void StartRoomLive_Push(string rtmp_url, LiveCardBean liveCardBean, FrmLive frmLive, Action<string> close_live)
        {
            try
            {
                ActivePlayer = this.playwnd1;
                this.liveCardBean = liveCardBean;
                //如果是自己的直播间，要进行推流
                //if (liveCardBean.userId.Equals(Applicate.MyAccount.userId))
                //创建直播间
                HttpUtils.Instance.InitHttp(this);
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/start")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("roomId", liveCardBean.roomId)
                    .AddParams("liveRoomId", liveCardBean.liveRoomId)
                    .AddParams("status", "1")
                    .Build()
                    .Execute((success, result) =>
                    {
                        if (success && result != null && result.Count > 0)
                        {
                            //显示pictureBox不显示VLC
                            playwnd1.BringToFront();
                            playwnd1.Enabled = true;
                            playwnd1.Visible = true;
                            vlcControl1.Enabled = false;
                            vlcControl1.Visible = false;

                            //加入直播间
                            //http get请求获得数据
                            HttpUtils.Instance.InitHttp(this);
                            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/enterInto")
                                .AddParams("access_token", Applicate.Access_Token)
                                .AddParams("roomId", liveCardBean.roomId)
                                .AddParams("userId", Applicate.MyAccount.userId)
                                .Build()
                                .Execute((success_e, result_e) =>
                                {
                                    if (success_e && result_e != null && result_e.Count > 0)
                                    {
                                        frmLive.GetmyInfo();
                                        ShiKuManager.mSocketCore.JoinRoom(liveCardBean.jid,0);
                                    }

                                });

                            //OpenLiveStreaming
                            //Task.Factory.StartNew(() =>
                            _Thread = new Thread(new ThreadStart(() =>
                            {
                                Applicate.IsPullLive = true;
                                CancellationTokenSource tokenSource = new CancellationTokenSource();
                                pushStream = new EQPushStream();
                                int push_ret = pushStream.StartPush(liveCardBean.url, (bmp) =>
                                {
                                    try
                                    {
                                        //Graphics gp = playwnd1.CreateGraphics();
                                        //gp.SmoothingMode = SmoothingMode.HighSpeed;
                                        //gp.DrawImage(bmp, 0, 0, (int)playwnd1.Size.Width, (int)playwnd1.Size.Height); //在窗体的画布中绘画出内存中的图像
                                        //gp.Dispose();

                                        Bitmap bitmap = new Bitmap(playwnd1.Size.Width, playwnd1.Size.Height);
                                        Graphics g = Graphics.FromImage(bitmap);
                                        g.SmoothingMode = SmoothingMode.HighSpeed;
                                        g.DrawImage(bmp, 0, 0, playwnd1.Size.Width, playwnd1.Size.Height);
                                        if (playwnd1.Image != null)
                                        {
                                            Image img = playwnd1.Image;
                                            playwnd1.Image = null;
                                            playwnd1.Image = bitmap;
                                            img.Dispose();
                                        }
                                        else
                                        {
                                            playwnd1.Image = bitmap;
                                        }
                                        LoopLable();
                                        g.Dispose();
                                    }
                                    catch (Exception ex) { }
                                });
                                if (push_ret < 0)
                                {
                                    isCanClose = true;
                                }
                                if (push_ret == -10) //open output error.
                                {
                                    //HttpUtils.Instance.ShowTip("打开直播流时出错，可能导致此问题的原因：\n1.正在其他端进行直播，直播地址被占用。\n2.输入的摄像头或者麦克风异常。");
                                    string error = "打开直播流时出错，可能导致此问题的原因：\n1.正在其他端进行直播，直播地址被占用。\n2.输入的摄像头或者麦克风异常。";
                                    close_live(error);
                                }
                            }));
                            _Thread.IsBackground = true;
                            _Thread.SetApartmentState(ApartmentState.STA);
                            _Thread.Start();
                            Console.WriteLine("================== my player start ==================");

                        }
                    });

            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public void StartLive_Pull(string rtmp_url, LiveCardBean liveCardBean, FrmLive frmLive)
        {
            this.liveCardBean = liveCardBean;
            ActivePlayer = this.vlcControl1;
            //显示VLC不显示pictureBox
            vlcControl1.BringToFront();
            vlcControl1.Enabled = true;
            vlcControl1.Visible = true;
            playwnd1.Enabled = false;
            playwnd1.Visible = false;
            HttpUtils.Instance.InitHttp(this);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/enterInto")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", liveCardBean.roomId)
                .AddParams("userId", Applicate.MyAccount.userId)
                .Build()
                .Execute((success_e, result_e) =>
                {

                    if (success_e && result_e != null && result_e.Count > 0)
                    {
                        liveCardBean.isOpen = true;
                        frmLive.GetmyInfo();
                        //谁加入了直播间
                        ShiKuManager.mSocketCore.JoinRoom(liveCardBean.jid, 0);
                    }
                    else
                    {
                        this.Parent.Dispose();
                    }
                });


            this.rtmp_url = rtmp_url;
            //string out_filename = Applicate.LocalConfigData.VideoFolderPath + "receive.flv";
            this.liveCardBean = liveCardBean;
            //if (_Thread != null)
            //{
            //    _Thread.Abort();
            //}
            //_Thread = new Thread(new ThreadStart(DecodeAllFramesToImages));
            //_Thread = new Thread(new ParameterizedThreadStart(RtmpReceiver.ReceiverRtmp));
            //_Thread.IsBackground = true;
            //WMPPlay wMPPlay = new WMPPlay()
            //{
            //    rtmp_url = rtmp_url,
            //    outFile_url = out_filename,
            //    action = new Action(() => StartPlayFlvByRtmp(out_filename))
            //};
            //_Thread.Start(wMPPlay);

            StartPlayFlvByRtmp(rtmp_url);
            //_Thread = new Thread(new ParameterizedThreadStart(StartPlayFlvByRtmp));
            //_Thread.IsBackground = true;
            //_Thread.Start(rtmp_url);
            Console.WriteLine("================== vlc player start ==================");
        }

        public void StartRoomLive_Pull(string rtmp_url, LiveCardBean liveCardBean, FrmLive frmLive)
        {
            this.liveCardBean = liveCardBean;
            ActivePlayer = this.vlcControl1;
            //显示VLC不显示pictureBox
            vlcControl1.BringToFront();
            vlcControl1.Enabled = true;
            vlcControl1.Visible = true;
            playwnd1.Enabled = false;
            playwnd1.Visible = false;
            HttpUtils.Instance.InitHttp(this);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/enterInto")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", liveCardBean.roomId)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("liveRoomId", liveCardBean.liveRoomId)
                .Build()
                .Execute((success_e, result_e) =>
                {

                    if (success_e && result_e != null && result_e.Count > 0)
                    {
                        liveCardBean.isOpen = true;
                        frmLive.GetmyInfo();
                        //谁加入了直播间
                        ShiKuManager.mSocketCore.JoinRoom(liveCardBean.jid, 0);
                    }
                    else
                    {
                        this.Parent.Dispose();
                    }
                });


            this.rtmp_url = rtmp_url;
            //string out_filename = Applicate.LocalConfigData.VideoFolderPath + "receive.flv";
            this.liveCardBean = liveCardBean;
            //if (_Thread != null)
            //{
            //    _Thread.Abort();
            //}
            //_Thread = new Thread(new ThreadStart(DecodeAllFramesToImages));
            //_Thread = new Thread(new ParameterizedThreadStart(RtmpReceiver.ReceiverRtmp));
            //_Thread.IsBackground = true;
            //WMPPlay wMPPlay = new WMPPlay()
            //{
            //    rtmp_url = rtmp_url,
            //    outFile_url = out_filename,
            //    action = new Action(() => StartPlayFlvByRtmp(out_filename))
            //};
            //_Thread.Start(wMPPlay);

            StartPlayFlvByRtmp(rtmp_url);
            //_Thread = new Thread(new ParameterizedThreadStart(StartPlayFlvByRtmp));
            //_Thread.IsBackground = true;
            //_Thread.Start(rtmp_url);
            Console.WriteLine("================== vlc player start ==================");
        }

        public void StartLive_Pulls(string rtmp_url, LiveCardBean liveCardBean, FrmLive frmLive)
        {

            bool AllowEnter = true;
            ActivePlayer = this.vlcControl1;
            //显示VLC不显示pictureBox
            vlcControl1.BringToFront();
            vlcControl1.Enabled = true;
            vlcControl1.Visible = true;
            playwnd1.Enabled = false;
            playwnd1.Visible = false;
            HttpUtils.Instance.InitHttp(this);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/enterInto")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", liveCardBean.roomId)
                .AddParams("userId", Applicate.MyAccount.userId)
                .Build()
                .Execute((success_e, result_e) =>
                {
                    if (success_e && result_e != null && result_e.Count > 0)
                    {
                        //谁加入了直播间
                        frmLive.Show();
                        frmLive.GetmyInfo();
                        ShiKuManager.mSocketCore.JoinRoom(liveCardBean.jid, 0);
                        liveCardBean.isOpen = true;
                    }
                    else
                    {
                        HttpUtils.Instance.ShowTip("您已被踢出");
                        AllowEnter = false;
                        frmLive.Dispose();
                    }

                });


            this.rtmp_url = rtmp_url;
            //string out_filename = Applicate.LocalConfigData.VideoFolderPath + "receive.flv";
            this.liveCardBean = liveCardBean;
            //if (_Thread != null)
            //{
            //    _Thread.Abort();
            //}
            //_Thread = new Thread(new ThreadStart(DecodeAllFramesToImages));
            //_Thread = new Thread(new ParameterizedThreadStart(RtmpReceiver.ReceiverRtmp));
            //_Thread.IsBackground = true;
            //WMPPlay wMPPlay = new WMPPlay()
            //{
            //    rtmp_url = rtmp_url,
            //    outFile_url = out_filename,
            //    action = new Action(() => StartPlayFlvByRtmp(out_filename))
            //};
            //_Thread.Start(wMPPlay);

            StartPlayFlvByRtmp(rtmp_url);
            //_Thread = new Thread(new ParameterizedThreadStart(StartPlayFlvByRtmp));
            //_Thread.IsBackground = true;
            //_Thread.Start(rtmp_url);
            Console.WriteLine("================== vlc player start ==================");

        }
        #region vlc
        private void StartPlayFlvByRtmp(object url)
        {
            //Invoke(new Action(() =>
            //{
            //vlcControl1.Play(new FileInfo(url));
            rtmp_url = url.ToString();
            vlcControl1.Play(new Uri(rtmp_url));
            Console.WriteLine("VLC Playing. rtmp_url: " + rtmp_url);
            //}));
        }


        private void vlcControl1_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (currentDirectory == null)
                return;
            if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)
                e.VlcLibDirectory = new DirectoryInfo(currentDirectory);
            else
                e.VlcLibDirectory = new DirectoryInfo(currentDirectory);
            //    e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"libvlc\win-x86\"));
            //else
            //    e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"libvlc\win-x64\"));
            if (!e.VlcLibDirectory.Exists)
            {
                var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
                folderBrowserDialog.Description = "Select Vlc libraries folder.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }
        #endregion
        #region 关闭直播并关闭窗体
        public void CloseLive(FrmLive frmLive)
        {
            Applicate.ColseLiveTime = TimeUtils.CurrentIntTime();
            if (pushStream != null)
            {
                if (pushStream.exit_thread == 1)
                    return;
                pushStream.exit_thread = 1;
            }
            if (liveCardBean != null && liveCardBean.userId == Applicate.MyAccount.userId)
            {
                if (pushStream == null)
                {
                    Applicate.IsPullLive = false;
                    Messenger.Default.Unregister(frmLive);//反注册
                    isCanClose = true;
                    frmLive.Close();
                    return;
                }
                pushStream.CloseAllData = ((end_result) =>
                {
                    Applicate.IsPullLive = false;
                    Messenger.Default.Unregister(frmLive);//反注册
                                                          //关闭直播间
                    HttpUtils.Instance.InitHttp(this);
                    var httpUtils = HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/quit")
                        .AddParams("access_token", Applicate.Access_Token)
                        .AddParams("roomId", liveCardBean.roomId)
                        .AddParams("userId", Applicate.MyAccount.userId);
                    if (!string.IsNullOrEmpty(liveCardBean.liveRoomId))     //是否为群内直播
                        httpUtils.AddParams("liveRoomId", liveCardBean.liveRoomId);
                    httpUtils.Build()
                        .Execute((success, result) =>
                        {
                            if (success && result != null && result.Count > 0)
                            {
                                //结束直播间
                                HttpUtils.Instance.InitHttp(this);
                                var httpUtils_start = HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/start")
                                    .AddParams("access_token", Applicate.Access_Token)
                                    .AddParams("roomId", liveCardBean.roomId)
                                    .AddParams("status", "0");
                                if (!string.IsNullOrEmpty(liveCardBean.liveRoomId))     //是否为群内直播
                                    httpUtils_start.AddParams("liveRoomId", liveCardBean.liveRoomId);
                                httpUtils_start.Build()
                                    .Execute((success1, result1) =>
                                    {
                                        if (success1)
                                        {
                                            Console.WriteLine("告诉服务器——结束直播");
                                            LogUtils.Save("结束直播成功\r\n");
                                        }
                                        else
                                        {
                                            LogUtils.Save("结束直播失败\r\n");
                                        }
                                    });
                                //发xmpp退出直播（房间）
                                ShiKuManager.mSocketCore.ExitRoom(liveCardBean.jid);
                                //CloseCmd();
                                //  Messenger.Default.Unregister(frmLive);//反注册
                            }
                            else
                            {
                                HttpUtils.Instance.ShowTip("直播间关闭失败！！");
                                LogUtils.Save("直播间关闭失败！！\r\n");
                            }
                            //不管关闭成功与否都要执行
                            isCanClose = true;
                            frmLive.Close();
                        });
                });
            }
            else if (liveCardBean != null && liveCardBean.userId != Applicate.MyAccount.userId)//非主播退出直播间
            {
                //

                Messenger.Default.Unregister(frmLive);//反注册
                HttpUtils.Instance.InitHttp(this);
                var httpUtils = HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/quit")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("roomId", liveCardBean.roomId)
                    .AddParams("userId", Applicate.MyAccount.userId);
                if (!string.IsNullOrEmpty(liveCardBean.liveRoomId))     //是否为群内直播
                    httpUtils.AddParams("liveRoomId", liveCardBean.liveRoomId);
                httpUtils.Build()
                    .Execute((success, result) =>
                    {
                        if (success && result != null && result.Count > 0)
                        {
                            //结束直播间

                            //发xmpp退出直播（房间）
                            ShiKuManager.mSocketCore.ExitRoom(liveCardBean.jid);
                            liveCardBean.numbers--;
                            //CloseCmd();
                        }
                        else
                            HttpUtils.Instance.ShowTip("直播间关闭失败！！");

                        Console.WriteLine("3");
                        //不管关闭成功与否都要执行
                        isCanClose = true;
                        //vlcControl1.Stop();
                        //vlcControl1.Dispose();
                        frmLive.Close();
                    });
            }
        }
        #endregion
        #region cmd指令
        /// <summary>
        /// 开启自己的直播间
        /// </summary>
        private void OpenLiveStreaming(string rtmp_url)
        {
            string video_name = "Logitech HD Webcam C270";
            string audio_name = "麦克风 (HD Webcam C270)";
            string cmd_content = string.Format(".\\ffmpeg -r 25 -f dshow -s {0}x{1} -i video=\"{2}\":audio=\"{3}\" -vcodec libx264 -b:a 30k -b:v 1500k -acodec aac -ab 128k -preset:v ultrafast -tune:v zerolatency -f flv {4}",
                640, 480, video_name, audio_name, rtmp_url);
            Console.WriteLine(cmd_content);
            ConsoleCmd(cmd_content);
        }
        #region 关闭cmd命令
        private void ConsoleCmd(string content)
        {
            try
            {
                process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.Start();
                process.StandardInput.WriteLine("cd " + Application.StartupPath);
                process.StandardInput.WriteLine(content);
                process.StandardInput.AutoFlush = true;
                //process.WaitForInputIdle();

                //退出CMD
                //process.StandardInput.WriteLine("exit");
                ////process.WaitForExit(5000);
                ////process.WaitForExit();
                //process.Close();
            }
            catch (Exception ex)
            {
                LogHelper.log.Error("--------直播输入CMD出错，content: " + content + "\r\n", ex);
            }
        }

        private void CloseCmd()
        {
            try
            {
                if (process == null)
                    return;

                //退出ffmpeg
                process.StandardInput.WriteLine("q");
                //退出CMD
                process.StandardInput.WriteLine("exit");
                process.WaitForExit(1500);
                process.Close();
            }
            catch (Exception ex) { LogHelper.log.Error("-----------退出cmd时出错", ex); }
        }
        #endregion
        #endregion

        #region 弹幕运动 2019/11/2 liuhuan
        public List<BarrageItem> barrageItemlst = new List<BarrageItem>();//弹幕列表
        public bool isspoot = true;
        private void UserLivePlayer_Load(object sender, EventArgs e)
        {
            ShowLodingDialog();
            //Task.Factory.StartNew(() =>
            //{
            //    // 运动代码
            //    while (isspoot)
            //    {
            //        Thread.Sleep(16);
            //        if (!this.IsDisposed)
            //        {
            //            try
            //            {
            //                Invoke(new Action(() =>
            //                {
            //                    LoopLable();
            //                }));
            //            }
            //            catch (Exception)
            //            {

            //            }

            //        }

            //    }
            //});
        }
        private void LoopLable()
        {
            if (barrageItemlst == null)
            {
                barrageItemlst = new List<BarrageItem>();
            }
            if (barrageItemlst.Count > 0)
            {
                for (int i = barrageItemlst.Count - 1; i >= 0; i--)
                {
                    Point p1 = barrageItemlst[i].textView.Location;
                    p1.X += 3;
                    barrageItemlst[i].textView.Location = p1;
                    if (p1.X >= this.Width)
                    {
                        barrageItemlst[i].textView.Dispose();
                        barrageItemlst.RemoveAt(i);
                    }

                }

            }
        }
        #endregion

        private void vlcControl1_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {
            if (loding != null)
            {
                loding.stop();
            }
        }

        private void VlcControl1_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            if (this.Parent is FrmLive frmLive && !isCanClose)
            {
                Console.WriteLine("2");
                isCanClose = true;
                //liveCardBean.isOpen = false;
                liveCardBean.ClearLiveData();
                CloseLive(frmLive);
            }
        }
    }
}
