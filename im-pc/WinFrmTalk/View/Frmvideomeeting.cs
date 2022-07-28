using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;

namespace WinFrmTalk.View
{
    public partial class Frrmvideomeeting : FrmBase
    {
        public Frrmvideomeeting()
        {
            InitializeComponent();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle); //加载icon图标
            rbhung.Image = Resources.ClosePhone;
            rbaudio.Image = Resources.ic_audiomeeting_Audio;
            rblound.Image = Resources.ic_lound;
            
        }
        private string joins;
        private string roomid;
        public Action<string, bool> joinsmen;
        private MessageObject mymessage;
        private FrmRecivePhone frmRecivePhone;
        private int tick_num = 0;
        private bool isaudio = false;//是否静音
        private List<RoomMember> roommemberlst = new List<RoomMember>();
        public void getdats(string joinparts, string Roomid, FrmRecivePhone frmRecive, MessageObject Message)
        {
            lbltitle.Text = Message.fromUserName + "发起的语音会议";
            lblinvite.Text = "发起人：" + Message.fromUserName;


            joins = joinparts;
            roomid = Roomid;

            mymessage = Message;
            frmRecivePhone = frmRecive;


            UserAudioMeet useadd = new UserAudioMeet();

            useadd.pics.Image = WinFrmTalk.Properties.Resources.Add_01;
            useadd.pics.Click += Pics_Click;
            useadd.Margin = new Padding(10, 8, 3, 3);
            paljoins.Controls.Add(useadd);

            

            RoomMember roomMember = new RoomMember { roomId = this.roomid, userId = Applicate.MyAccount.userId,nickName = Applicate.MyAccount.nickname };
            roomMember = roomMember.GetRoomMember();
            UserAudioMeet uSEpicAddName = new UserAudioMeet();
            uSEpicAddName.NickName = roomMember.nickName;
            roommemberlst.Add(roomMember);
            uSEpicAddName.Userid = roomMember.userId;
            ImageLoader.Instance.DisplayAvatar(roomMember.userId, uSEpicAddName.pics);

            
          
            uSEpicAddName.Margin = new Padding(10, 8, 3, 3);
            paljoins.Controls.Add(uSEpicAddName);
            paljoins.Controls.SetChildIndex(uSEpicAddName, 0);
            this.joinsmen = (joins, isjoins) =>
            {
                this.joins = joins;
                if (isjoins)
                {
                    Thread thread1 = new Thread(new ThreadStart(joinsdata));
                    thread1.Start();
                }
                else
                {
                    exite(joins);
                }
                
            };
        }
        /// <summary>
        /// 邀请好友加入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pics_Click(object sender, EventArgs e)
        {
            invitemembenr();
        }

        public void  invitemembenr()
        {
            //能执行到这里说明语音通话一定是打开的
            //if (!Applicate.IsOpenFrom)
            //    return;
            Friend ChooseTarget = new Friend { RoomId = roomid, UserId = mymessage.objectId, IsGroup = 1 };
            //选择转发的好友
            var frmFriendSelect = new FrmFriendSelect();
            frmFriendSelect.LoadFriendsData(ChooseTarget, roommemberlst);
            frmFriendSelect.AddConfrmListener((UserFriends) =>
            {
                if (UserFriends.Values.Count < 0)
                    return;
                List<Friend> toFriends = new List<Friend>();
                foreach (var friend in UserFriends.Values)
                    toFriends.Add(friend);
                ShiKuManager.SendGroupAudioMeetMsg(toFriends, ChooseTarget.RoomId, ChooseTarget.UserId);
            });
        }
        public void joinsdata()
        {
           
                BeginInvoke(new Action(() => { puddata(); }));

        }
        System.Timers.Timer timer_count = new System.Timers.Timer();
        private void puddata()
        {
            //出现加入的成员不在列表中

           
                RoomMember roomMember = new RoomMember { roomId = this.roomid, userId = joins };
                roomMember = roomMember.GetRoomMember();
                UserAudioMeet uSEpicAddName = new UserAudioMeet();
            
                uSEpicAddName.NickName = roomMember.nickName;

                uSEpicAddName.Userid = roomMember.userId;
                ImageLoader.Instance.DisplayAvatar(roomMember.userId, uSEpicAddName.pics);
            roommemberlst.Add(roomMember);
            uSEpicAddName.Margin = new Padding(10, 8, 3, 3);
            paljoins.Controls.Add(uSEpicAddName);
                paljoins.Controls.SetChildIndex(uSEpicAddName, 0);

        }
        private void exite(string userid)
        {
            for (int i = 0; i < paljoins.Controls.Count; i++)
            {
                UserAudioMeet uSEpicAddName = (UserAudioMeet)paljoins.Controls[i];
                if (uSEpicAddName.Userid!=null&& uSEpicAddName.Userid.Equals(userid))
                {
                    RoomMember roomMember = new RoomMember { userId = userid };
                  
                    paljoins.Controls.Remove(paljoins.Controls[i]);
                    roommemberlst.Remove(roomMember);
                    break;
                }
            }
        }
        private void Frrmvideomeeting_Load(object sender, EventArgs e)
        {
            timer_count.Elapsed += new System.Timers.ElapsedEventHandler(tick_count);  //到达时间的时候执行事件；
            timer_count.AutoReset = true;  //设置是执行一次（false）还是一直执行(true)；
            timer_count.Interval = 1000;
            timer_count.Start();
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

            String tick = hour.ToString() + "：" + min.ToString() + "：" + sec.ToString();
            this.lbltime.Text = tick;
        }
        /// <summary>
        /// 挂断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbhung_Click(object sender, EventArgs e)
        {
            
                frmRecivePhone.rpboxClose_Click(null, null);
            
          
            this.Close();
        }
        /// <summary>
        /// 静音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbaudio_Click(object sender, EventArgs e)
        {
            if(isaudio)
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
       /// 扬声器
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void rblound_Click(object sender, EventArgs e)
        {

        }

        private void Frrmvideomeeting_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.isClose)
            {
                frmRecivePhone.rpboxClose_Click(null, null);
                this.Close();
            }

           
        }
    }
}
