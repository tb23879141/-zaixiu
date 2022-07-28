using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Live;
using WinFrmTalk.Model;

namespace WinFrmTalk.View
{
    public partial class FrmRecordVideo : FrmBase
    {
        public static bool isRecord = false;
        private Thread _Thread = null;
        EQRecordStream pushStream = null;
        string picName = string.Empty;
        public Action<string, Friend> videoInfo;    //录像保存的本地路径和时间
        private bool isFirstLoad = true;    //用于修改窗口的尺寸
        private bool isCanClose = false;
        private Friend chatFd = null;       //用于录像结束后的回调，避免更换了聊天对象

        System.Timers.Timer timer_count = new System.Timers.Timer();
        int tick_num = 0;

        public FrmRecordVideo(Friend chatFd)
        {
            InitializeComponent();
            isClose = false;
            this.chatFd = chatFd;
            ////开启线程池
            //Task.Factory.StartNew(() =>
            //{
            //    StartLoding();
            //    //视屏时间限制
            //    Thread.Sleep(int.Parse(Applicate.URLDATA.data.videoLength) * 1000);
            //    lbltime.Visible = false;
            //    //关闭录像文件,如果忘了不关闭,将会得到一个损坏的文件,无法播放
            //    btnstop.Visible = false;
            //    pushStream.CloseAllData = new Action<bool>((result) =>
            //    {
            //        this.Invoke(new Action(() =>
            //        {
            //            //销毁等待符
            //            if (loding != null)
            //                loding.stop();
            //            //设置按钮
            //            btnreturn.Visible = true;
            //            btnsend.Visible = true;
            //        }));
            //    });
            //    pushStream.exit_thread = 1;
            //});
        }

        #region 展示等待符
        LodingUtils loding = new LodingUtils();     //新创一个等待符
        private void StartLoding(string title = "")
        {
            //loding = new LodingUtils();
            loding.Title = title;
            loding.size = new Size(30, 30);
            loding.parent = pictureBox1;
            loding.BgColor = Color.Transparent;
            loding.start();
        }
        #endregion

        private void FrmRecordVideo_Load(object sender, EventArgs e)
        {
            timer_count.Elapsed += tick_count;  //到达时间的时候执行事件；
            timer_count.AutoReset = true;  //设置是执行一次（false）还是一直执行(true)；
            timer_count.Interval = 1000;

            StartLoding("启动设备中，请稍等...");
            picName = GetVideoPath() + "\\" + TimeUtils.CurrentTime().ToString() + ".mp4";
            StartRecord(picName);
        }

        /// <summary>
        /// 计时器计时并转换时间
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>

        public void tick_count(object source, System.Timers.ElapsedEventArgs e)
        {
            tick_num++;
            int temp = tick_num;

            int sec = temp % 60;

            int min = temp / 60;
            if (60 == min)
            {
                min = 0;
                min++;
            }

            int hour = min / 60;

            string tick = hour.ToString() + "：" + min.ToString() + "：" + sec.ToString();
            this.lbltime.Text = tick;
            if (int.Parse(Applicate.URLDATA.data.videoLength)== tick_num)
            {
                timer_count.Enabled = false;
                //StartLoding();
                lbltime.Visible = false;
                //关闭录像文件,如果忘了不关闭,将会得到一个损坏的文件,无法播放
                btnstop.Visible = false;
                pushStream.CloseAllData = new Action<bool>((result) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        //销毁等待符
                        if (loding != null)
                            loding.stop();
                        //设置按钮
                        btnreturn.Visible = true;
                        btnsend.Visible = true;
                        tick_num = 0;
                        //btnreturn.BringToFront();
                        //btnsend.BringToFront();
                    }));
                });
                pushStream.exit_thread = 1;
            }
        }

        /// <summary>
        /// 获取路径
        /// </summary>
        /// <returns></returns>
        private string GetVideoPath()
        {
            string personImgPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)
                         + Path.DirectorySeparatorChar.ToString() + "PersonImg";
            if (!Directory.Exists(personImgPath))
            {
                Directory.CreateDirectory(personImgPath);
            }

            return personImgPath;
        }

        public void StartRecord(string path)
        {
            _Thread = new Thread(new ThreadStart(() =>
            {
                //CancellationTokenSource tokenSource = new CancellationTokenSource();
                pushStream = new EQRecordStream();
                int push_ret = pushStream.StartPush(path, (bmp) =>
                {
                    try
                    {
                        if (isFirstLoad)
                        {
                            //int diff_w = pictureBox1.Width - bmp.Width;
                            //int diff_h = pictureBox1.Height - bmp.Height;
                            //this.Width -= diff_w;
                            //this.Height -= diff_h;
                            isFirstLoad = false;
                            //销毁等待符
                            if (loding != null)
                                loding.stop();
                        }


                        Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        Graphics g = Graphics.FromImage(bitmap);
                        g.SmoothingMode = SmoothingMode.HighSpeed;
                        g.DrawImage(bmp, 0, 0, pictureBox1.Width, pictureBox1.Height);
                        if (pictureBox1.Image != null)
                        {
                            Image img = pictureBox1.Image;
                            pictureBox1.Image = null;
                            pictureBox1.Image = bitmap;
                            img.Dispose();
                        }
                        else
                        {
                            pictureBox1.Image = bitmap;
                        }
                        g.Dispose();
                    }
                    catch (Exception ex) { }
                });
            }));
            _Thread.IsBackground = true;
            _Thread.SetApartmentState(ApartmentState.STA);
            _Thread.Start();
        }

        private void Btnstart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            //Console.WriteLine("PictureBox1 background is " + (pictureBox1.Image == null ? "NULL" : "Not NULL"));
            if (pictureBox1.Image == null)
                return;


            timer_count.Start();
            timer_count.Enabled = true;

            btnstart.Visible = false;
            btnstop.Visible = true;
            //btnpuse.Visible = true;
            btnreturn.Visible = false;
            lbltime.Text = "";
            lbltime.Visible = true;

            pushStream.recording = 1;
        }

        private void Btnstop_MouseClick(object sender, MouseEventArgs e)
        {
            if (e != null && e.Button != MouseButtons.Left)
                return;
            
            timer_count.Enabled = false; 
            StartLoding();
            lbltime.Visible = false;
            //关闭录像文件,如果忘了不关闭,将会得到一个损坏的文件,无法播放
            btnstop.Visible = false;
            pushStream.CloseAllData = new Action<bool>((result) =>
            {
                this.Invoke(new Action(() =>
                {
                    //销毁等待符
                    if (loding != null)
                        loding.stop();
                    //设置按钮
                    btnreturn.Visible = true;
                    btnsend.Visible = true;
                    tick_num = 0;
                    //btnreturn.BringToFront();
                    //btnsend.BringToFront();
                }));
            });
            pushStream.exit_thread = 1;
        }

        public void CloseRecord()
        {
            if (pushStream.exit_thread == 0)
            {
                pushStream.CloseAllData = new Action<bool>((result) =>
                {
                    isCanClose = true;
                    this.Close();
                });
                pushStream.exit_thread = 1;
            }
            else
            {
                isCanClose = true;
                this.Close();
            }
        }

        private void Btnreturn_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (pictureBox1.Image == null)
                return;

            if (pushStream.exit_thread == 0)
            {
                pushStream.CloseAllData = new Action<bool>((result) =>
                {
                    isCanClose = true;
                    if (File.Exists(picName))
                    {
                        File.Delete(picName);
                    }
                    this.Close();
                });
                pushStream.exit_thread = 1;
            }
            else
            {
                isCanClose = true;
                if (File.Exists(picName))
                {
                    File.Delete(picName);
                }
                this.Close();
            }

        }

        private void Btnsend_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            videoInfo?.Invoke(picName, chatFd);//本地路径和时间

            this.Close();
        }

        private void FrmRecordVideo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (pushStream != null && pushStream.exit_thread == 0)
                {
                    if (!isCanClose)
                    {
                        e.Cancel = true;
                    }
                    //pushStream.exit_thread = 1;
                    //e.Cancel = true;
                    //LogHelper.log.Error("非正常途径关闭录像——FrmRecordVideo_FormClosing \r\n");
                    CloseRecord();
                }
            }
            catch (Exception ex)
            {
                LogHelper.log.Error("FrmRecordVideo_FormClosing Error: \r\n" + ex.Message);
            }
        }

        private void FrmRecordVideo_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRecord = false;
            this.Dispose();
        }
    }
}
