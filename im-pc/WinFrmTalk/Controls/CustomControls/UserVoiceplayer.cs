using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WinFrmTalk.Model;
using System.IO;
using WinFrmTalk.Helper;
using System.Timers;
using Timer = System.Windows.Forms.Timer;
using System.Management;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class UserVoiceplayer : UserControl
    {

        public delegate void EventPlayCompteHandler(string url);
        public event EventPlayCompteHandler OnPlayCompte;

        public bool IsStart;
        public UserVoiceplayer()
        {
            InitializeComponent();

           
            timer_count.Start();
            timer_count.Tick += Timer_count_Tick; ;  //到达时间的时候执行事件；
                                                     //设置是执行一次（false）还是一直执行(true)；
            timer_count.Interval = 1000;

        }

        private void Timer_count_Tick(object sender, EventArgs e)
        {

            timer += 1;
            int temp = (int)timer;

            int sec = temp % 60;

            int min = temp / 60;
            if (60 == min)
            {
                min = 0;
                min++;
            }

            int hour = min / 60;
            string second = sec.ToString();
            string mins = min.ToString();
            if (sec / 10 < 1)
            {
                second = "0" + sec;
            }
            if (min / 10 < 1)
            {
                mins = "0" + min;
            }
            String tick = mins + ":" + second;
            this.lblStartTime.Text = tick;


            if (timer > durationSecond)
            {
                timer = 0;
                musicBar1.Value = timer / durationSecond * 100;
                timer_count.Stop();
                this.lblStartTime.Text = "00:00";
                pboxStart.Image = global::WinFrmTalk.Properties.Resources.ic_voice_play;
                IsStart = true;
                musicBar1.Value = 0;
                OnPlayCompte?.Invoke(LocationPath);
            }
            else
            {
                musicBar1.Value = timer / durationSecond * 100;
            }
        }


        int durationSecond;
        private static LodingUtils loding = null;
        private MessageObject messageList;
        public string LocationPath;
        private double timer = 0.00;
        MP3Player mp3 = new MP3Player();
        public int Seconds { get; private set; }
    

     
        public void VidoShowList(MessageObject message)
        {
            messageList = message;

            string filepath = message.content;
            string fileName = FileUtils.GetFileName(filepath);
            LocationPath = Applicate.LocalConfigData.VideoFolderPath + fileName;
            if (!File.Exists(LocationPath))
            {
                //等待符
                loding = new LodingUtils();
                loding.parent = this;
                loding.size = new Size(30, 30);
                loding.start();
                HttpDownloader.DownloadFile(filepath, LocationPath, (path) =>
                {
                    if (!string.IsNullOrEmpty(path))
                    {
                        VidoPlay(LocationPath);
                        loding.stop();
                    }
                });
            }
            //复制过去
            else
            {
                //LocationPath = Applicate.LocalConfigData.AudioFolderPath + fileName;
                //FileInfo fileInfo = new FileInfo(filepath);
                VidoPlay(LocationPath);
                //fileInfo.CopyTo(LocationPath, true);
                //loding.stop();
            }

        }
        Timer timer_count = new Timer();
        //播放的方法
        private void VidoPlay(string LocationPath)
        {
            if (!timer_count.Enabled)
            {
                pboxStart.Image = global::WinFrmTalk.Properties.Resources.ic_voice_stop;
                IsStart = false;
                mp3.Play();
                timer_count.Start();
                return;
            }
            // string mp3_fileName = Applicate.LocalConfigData.VoiceFolderPath + LocationPath + ".mp3";
            mp3.FilePath = LocationPath;
            //播放   
            mp3.Play();

            //pboxStart.Visible = false;
            pboxStart.Image = global::WinFrmTalk.Properties.Resources.ic_voice_stop;
            IsStart = false;
            // pboxStop.Visible = true;
            //视频长度
            durationSecond = (int)messageList.timeLen;
            string Min = durationSecond / 60 + "";
            if (Min.Length == 1)
            {
                Min = "0" + Min;
            }
            Seconds = durationSecond % 60;
            string secos = Seconds.ToString();
            if (secos.Length == 1)
            {
                secos = "0" + secos;
            }
            string endTime = Min + ":" + secos;
            //结束时间
            lblStopTime.Text = endTime;
            //最大值
            if (timer >= messageList.timeLen)
            {
                timer = 0;
                //this.viewProgress1.SetProgress(currt, durationSecond);
                //musicBar1.Value = 0.0;
                ////停止计时器
                //pboxStar.Visible = false;
                //pboxStop.Visible = true;
                //pboxStop.Location = pboxStar.Location;
            }
        }

        private void pboxStart_Click(object sender, EventArgs e)
        {
            if (IsStart)
            {
                musicBar1.Visible = true;
                pboxStart.Image = global::WinFrmTalk.Properties.Resources.ic_voice_stop;
                IsStart = false;
                mp3.Play();
                timer_count.Start();
                if (timer >= durationSecond)
                {
                    timer = 0;
                    mp3.Stop();
                    musicBar1.Value = 0.0;
                    timer_count.Stop();
                    timer_count.Start();
                    mp3.Play();
                    Timer_count_Tick(sender, e);
                    pboxStart.Image = global::WinFrmTalk.Properties.Resources.ic_voice_play;
                    IsStart = true;
                }
            }
            else
            {
                pboxStart.Image = global::WinFrmTalk.Properties.Resources.ic_voice_play;
                IsStart = true;
                // pboxStop.Location = pboxStar.Location;
                mp3.Pause();

                timer_count.Stop();
            }

        }
        //暂停

    }
}
