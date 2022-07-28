using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;

namespace WinFrmTalk.View
{
    public partial class frmAudioSing : FrmBase
    {
        public frmAudioSing()
        {
            InitializeComponent();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle); //加载icon图标
            rbhung.Image = Resources.ClosePhone;
            rbaudio.Image = Resources.ic_audiomeeting_Audio;
        }
        public Friend myfriend;
        public Action<string, bool> joinsmen;
        private MessageObject mymessage;
        private FrmRecivePhone frmRecivePhone;
        private int tick_num = 0;
        private bool isaudio = false;//是否静音
        private List<RoomMember> roommemberlst = new List<RoomMember>();
        System.Timers.Timer timer_count = new System.Timers.Timer();

        public void MainMessage(MessageObject message)
        {
            //结束通话
            if (message.type == kWCMessageType.AudioChatEnd || message.type == kWCMessageType.VideoChatEnd || message.type == kWCMessageType.ScreenMeetEnd)
            {
                MeetFormManager.Instance.InitFrom();
                frmRecivePhone. ExitMeet();
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
                    frmRecivePhone. AutoMeetDisconn();
                }
            }
        }
        public void getdats(Friend friend, FrmRecivePhone frmRecive)
        {

            lblinvite.Text = friend.NickName;


            myfriend = friend;
            frmRecivePhone = frmRecive;
          
            ImageLoader.Instance.DisplayAvatar(friend.UserId, pichead);
        }

        private void frmAudioSing_Load(object sender, EventArgs e)
        {
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_MEETING_MESSAGE, MainMessage);
            timer_count.Elapsed += new System.Timers.ElapsedEventHandler(tick_count);  //到达时间的时候执行事件；
            timer_count.AutoReset = true;  //设置是执行一次（false）还是一直执行(true)；
            timer_count.Interval = 1000;
            timer_count.Start();
        }
        /// <summary>
        /// 静音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbaudio_Click(object sender, EventArgs e)
        {
            if (isaudio)
            {
                frmRecivePhone.Audiomute();
                rbaudio.Image = Resources.ic_audiomeeting_Audio;

                isaudio = false;
            }
            else
            {
                frmRecivePhone.Audiomute();
                rbaudio.Image = Resources.ic_audiomeeting_CnlAudio;

                isaudio = true;
            }
        }
        /// <summary>
        /// /挂断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbhung_Click(object sender, EventArgs e)
        {
            frmRecivePhone.rpboxClose_Click(null, null);
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAudioSing_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.isClose)
            {
                frmRecivePhone.rpboxClose_Click(null, null);
                this.Close();
            }
            timer_count.Stop();//计时器停止
        }
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

            String tick = hour.ToString() + "：" + min.ToString() + "：" + sec.ToString();
            this.lbltime.Text = tick;
        }
    }
}
