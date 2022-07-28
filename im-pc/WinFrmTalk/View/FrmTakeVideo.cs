using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing.Imaging;
using AForge.Video.DirectShow;


using AForge.Video.FFMPEG;
using System.Diagnostics;
using System.Threading;
using System.Management;
using WinFrmTalk.Live;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace WinFrmTalk.View
{
    public partial class FrmTakeVideo : FrmBase
    {
        FilterInfoCollection videoDevices;
        /// <summary>
        /// �����ƵԴ��ӱ�����Ƶ�����豸��ȡ��Ƶ���ݣ�
        /// ��USB��������ͷ(���ڲ�)��֡ץȡ������׽�塪���κζ���
        /// ֧��DirectShow�Ľӿڡ������п��Ű�ť���豸
        /// ����֧���ⲿ�����������Ҳ���������ա�
        /// ��Ƶ��С�Ϳ��մ�С���������á�
        /// </summary>
        //������ƵԴץȡ��
        VideoCaptureDevice videoSource;
        private VideoFileWriter VideoOutPut = new VideoFileWriter();
        //�����±�
        public int selectedDeviceIndex = 0;
        private static FrmTakeVideo instance = null;
        public Action<string> videoInfo;//¼�񱣴�ı���·����ʱ��
        String picName = "";
        bool is_record_video = false;
        int tick_num = 0;
        public static FrmTakeVideo GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmTakeVideo();
            }
            if (instance != null)
            {
                instance.Activate();
            }
            return instance;
        }

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            this.Text = LanguageXmlUtils.GetValue("frmTakePhoto_title", this.Text);
        }

        public FrmTakeVideo()
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//����iconͼ��
            btnstart.Parent = photo;
            btnstop.Parent = photo;
            btnstop.BackColor = Color.Transparent;
            btnstart.BackColor = Color.Transparent;
            btnpuse.Parent = photo;
            btnreturn.Parent = photo;
            btnsend.Parent = photo;
            btnsend.BackColor = Color.Transparent;
            btnpuse.BackColor = Color.Transparent;
            btnreturn.BackColor = Color.Transparent;
            btnreturn.Tag = "����";
        }
        /// <summary>
        /// ��ȡ�Ƿ�������豸
        /// </summary>
        /// <returns></returns>
        public bool iscontentpoto()
        {
            bool iscontent = true;
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                iscontent = false;
            }
            else
            {
                selectedDeviceIndex = 0;
                /// <summary>
                /// 1����⵽����豸2.��ʼ��������豸���ж���������豸��״̬�����ݲ�ͬ��״̬��������
                /// </summary>

                //���ûص�,aforge�᲻�ϴ�����ص��Ƴ�ͼ������

                //ʵ������ƵԴץȡ��
                //videoDevices[selectedDeviceIndex].MonikerString   �����������ֵ��ַ�����
                videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//��������ͷ
                                                                                                      //��Ƶ�ֱ�����
                                                                                                      //��������������һ��֧�ֵ���Ƶ�ֱ���
                                                                                                      //�����ʹ��AForge.Video.DirectShow.VideoCaptureDevice.VideoCapabilities
                                                                                                      //�����Ի��֧�ֵ���Ƶ�ֱ����б�
                                                                                                      //���������ʼ��Ч֮ǰ�������úø����ԡ�
                                                                                                      //���Ե�Ĭ��ֵ����Ϊnull������ζ��Ĭ�ϵ���Ƶ�ֱ���
                                                                                                      //ʹ�á�
                videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];
                //��ʵ�����õ�videosource�ำֵ��photo�ؼ���VideoSource����

                photo.VideoSource = videoSource;
                //����photo�ؼ�
                photo.Start();
                System.Threading.Thread.Sleep(2000);
                Bitmap bimp = photo.GetCurrentVideoFrame();
                if (bimp == null)
                {
                    iscontent = false;
                }

            }

            return iscontent;
            //���û�����ӳɹ���ť������
            if (!photo.IsRunning)
            {
                btnstart.Visible = false;
                btnreturn.Visible = false;
            }
        }

        private Bitmap bmp = new Bitmap(1, 1);
        private Stopwatch stopWatch = new Stopwatch();

        private void VideoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if (is_record_video)
            {
                VideoOutPut.WriteVideoFrame(eventArgs.Frame);
                //lock (bmp)
                //{
                //    //�ͷ���һ������
                //    bmp.Dispose();
                //    //����һ�ݻ���
                //    bmp = eventArgs.Frame.Clone() as Bitmap;
                //}
            }
        }
        #region ��ʼ¼����Ƶ
        /// <summary>
        /// ��ʼ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnstart_Click(object sender, EventArgs e)
        {
            if (photo.IsRunning)
            {
                timer_count.Start();
                btnstart.Visible = false;
                isshowbutton(btnstart.Visible);
                btnstop.Visible = true;
                btnpuse.Visible = true;
                btnreturn.Visible = false;
                is_record_video = true;
                timer_count.Enabled = true;
                lbltime.Text = "";
                lbltime.Visible = true;
                btnsend.Visible = false;

                picName = GetVideoPath() + "\\" + TimeUtils.CurrentTime().ToString() + ".mp4";
                //����Ϊ9��ԭ������������ֵ¼�Ƶ���Ƶ�����٣��������ֵ����٣����������
                VideoOutPut.Open(picName, videoSource.VideoResolution.FrameSize.Width, videoSource.VideoResolution.FrameSize.Height, 9, VideoCodec.MPEG4);
                videoSource.NewFrame += VideoSource_NewFrame;
               
             }
        }
        #endregion
        /// <summary>
        /// ��ȡ·��
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
        /// <summary>
        /// ��ʱ����ʱ��ת��ʱ��
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
            string tick = hour.ToString() + "��" + min.ToString() + "��" + sec.ToString();
            this.lbltime.Text = tick;
            if (int.Parse(Applicate.URLDATA.data.videoLength)== tick_num)
            {
                timer_count.Stop();
                btnstop_Click(null,null);
            }
        }
        #region ����¼�ƣ���ͣ�����
        /// <summary>
        /// ����¼��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnstop_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                videoSource.NewFrame -= VideoSource_NewFrame;
                // videoSource.Stop();
                timer_count.Enabled = false; ;
                lbltime.Visible = false;
                is_record_video = false;
                tick_num = 0;
                //�ر�¼���ļ�,������˲��ر�,����õ�һ���𻵵��ļ�,�޷�����
                VideoOutPut.Close();
                btnstart.Visible = true;
                btnreturn.Visible = true;
                btnpuse.Visible = false;
                btnsend.Visible = true;

            }));

            //ֹ֮ͣ��
        }
        /// <summary>
        /// ��ͣ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnpuse_Click(object sender, EventArgs e)
        {

            if (this.btnpuse.Tag.ToString() == "��ͣ")
            {

                //   stopWatch.Stop();
                this.lbltime.Visible = true;
                this.btnpuse.Tag = "����";
                is_record_video = false;
                this.btnpuse.BackgroundImage = global::WinFrmTalk.Properties.Resources.videoContinue;
                //�ı䱳��ͼƬ

                timer_count.Enabled = false;  //��ͣ��ʱ
                return;
            }
            if (this.btnpuse.Tag.ToString() == "����")
            {
                // stopWatch.Start();

                timer_count.Enabled = true;

                is_record_video = true;

                this.lbltime.Visible = true;
                this.btnpuse.BackgroundImage = global::WinFrmTalk.Properties.Resources.videoSpuse;
                this.btnpuse.Tag = "��ͣ";
            }
        }
        #endregion
        /// <summary>
        /// ���ذ�ť�����ֵ���ʾ
        /// </summary>
        /// <param name="isshow"></param>
        private void isshowbutton(bool isshow)
        {
            if (isshow)
            {

                btnreturn.Tag = "����";
            }
            else
            {

                btnreturn.Tag = "�������";
            }
        }
        /// <summary>
        /// ����1.����������2.�˳�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnreturn_Click(object sender, EventArgs e)
        {
            if (btnreturn.Tag.ToString() == "����")
            {
                this.Close();
            }
            if (btnreturn.Tag.ToString() == "�������")//������¼�ƽ��棬�ٷ��ؾ�ֱ�ӹر�
            {
                if (File.Exists(picName))
                {
                    File.Delete(picName);
                }
                btnsend.Visible = false;
                btnreturn.Tag = "����";
            }

        }
        /// <summary>
        /// �رմ����ͷ���Դ
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTakeVideo_FormClosed(object sender, FormClosedEventArgs e)
        {
            videoSource.NewFrame -= VideoSource_NewFrame;
            videoSource.Stop();
            Thread thread1 = new Thread(new ThreadStart(photostop));
            thread1.Start();
        }
        public void photostop()
        {
            if (photo.InvokeRequired)//��ͬ�߳�Ϊtrue������������true
            {
                BeginInvoke(new Action(() => { photo.Stop(); }));

            }
        }
        System.Timers.Timer timer_count = new System.Timers.Timer();

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTakeVideo_Load(object sender, EventArgs e)
        {
            timer_count.Elapsed += new System.Timers.ElapsedEventHandler(tick_count);  //����ʱ���ʱ��ִ���¼���
            timer_count.AutoReset = true;  //������ִ��һ�Σ�false������һֱִ��(true)��
            timer_count.Interval = 1000;
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsend_Click(object sender, EventArgs e)
        {
            isshowbutton(btnstart.Visible);

            //Demo2.ffmpegtool = Application.StartupPath + "\\" + @"ffmpeg.exe";
            //Demo2.sourceFile = picName;
            //Demo2.playFile = picName;
            //Demo2 demo2 = new Demo2();
            string after_fileName = GetVideoPath() + "\\" + TimeUtils.CurrentTime().ToString() + ".mp4";
            ConvertToMp4(Applicate.AppCurrentDirectory, picName, after_fileName);
            Thread.Sleep(1000);
            //demo2.ConvertVideo();
            videoInfo?.Invoke(after_fileName);//����·����ʱ��
                                              //

            this.Close();
        }
        /// <summary>
        /// ����Ƶ�ļ�ת��ΪMP4��ʽ
        /// </summary>
        /// <param name="applicationPath"> ffmeg.exe �ļ�·��</param>
        /// <param name="before_fileName"> ԭ�ȵ��ļ�·��</param>
        /// <param name="after_fileName"> ��������ļ�·��</param>
        public void ConvertToMp4(string applicationPath, string before_fileName, string after_fileName)
        {
            LogUtils.Save("=====ffmeg.exe�ļ�·����" + applicationPath + "======\r\n");
            LogUtils.Save("=====ת��֮ǰ���ļ���·��(���ļ���)��" + before_fileName + "======\r\n");
            LogUtils.Save("=====����Ŀǰmp3�ļ�·�������ļ�������" + after_fileName + "======\r\n");

            string c = applicationPath + @"\ffmpeg.exe -i " + before_fileName + " -y  -vcodec h264 -b 500000 " + after_fileName;
            LogUtils.Save("=====ƴ�ӵ�·����" + c + "======\r\n");
            Cmd(c);
        }

        /// <summary>
        /// ִ��Cmd����
        /// </summary>
        private void Cmd(string c)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.Start();
                process.StandardInput.WriteLine(c);
                process.StandardInput.AutoFlush = true;
                process.StandardInput.WriteLine("exit");
                StreamReader reader = process.StandardOutput;//��ȡ�����           
                //process.WaitForExit(5000);
                process.Close();
            }
            catch (Exception ex)
            {
                LogUtils.Save("=====zת��MP3��ʽ����" + ex.Message + "======\r\n");

            }
        }

    }
}
