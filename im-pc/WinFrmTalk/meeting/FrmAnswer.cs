using CefSharp;
using CefSharp.WinForms;
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
using WinFrmTalk.Model;
using WinFrmTalk.Properties;

namespace WinFrmTalk.View
{
    public partial class FrmAnswer : FrmBase
    {
        #region 全局变量
        //定义变量是否在接电话
        public bool isAnswer;
        //是否为群群
        public bool isGroup;
        public FrmAnswer()
        {

            InitializeComponent();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            isEscClose = false;
        }

        // 判断通话类型
        // 0语音  1视频  2屏幕共享
        private int MeetType;

        //实例化
        Friend myFriend;
        MessageObject isMessage;
        public string Url;
        private bool isChoose;
        #endregion

        #region 参数的传递
        //好友接听界面
        public void fillDataFrined(Friend friend, MessageObject message, bool isVideo, string url)
        {
            Url = url;
            isMessage = message;
            //类型
            string str = ToTipContent(message);
            if (!isAnswer)
            {
                myFriend = friend;
                //头像
                ImageLoader.Instance.DisplayAvatar(friend.UserId, rpboxIcon);
                lblNickName.Text = UIUtils.LimitTextLength(friend.NickName, 5, true);
                rpboxClose.Image = Resources.ClosePhone;
                rpbAnswer.Image = Resources.AnswerPhone;
                lblType.Text = str;
                isAnswer = true;
            }
            else
            {
                Task.Factory.StartNew(() =>
                {
                    //等待30秒
                    Thread.Sleep(30 * 1000);
                    //如果接听
                    if (!isChoose)
                    {
                        //对方不愿意
                        ShiKuManager.SendCancelMeetMessage(friend, isVideo);
                        this.Close();
                    }
                });
            }
            this.Show();
            this.Activate();
        }

        private string ToTipContent(MessageObject message)
        {
            switch (message.type)
            {
                case kWCMessageType.VideoChatAsk:
                    MeetType = 1;
                    return "邀请您视频通话";
                case kWCMessageType.AudioChatAsk:
                    MeetType = 0;
                    return "邀请您语音通话";
                case kWCMessageType.ScreenMeetAsk:
                    MeetType = 2;
                    return "邀请您共享屏幕";
                case kWCMessageType.VideoMeetingInvite:
                    MeetType = 1;
                    return "邀请您加入视频会议";
                case kWCMessageType.AudioMeetingInvite:
                    MeetType = 0;
                    return "邀请您加入语音会议";
                case kWCMessageType.ScreenMeetInvite:
                    MeetType = 2;
                    return "邀请您加入屏幕共享";
                default:
                    return "";
            }
        }

        //群接听界面管理
        internal void fillDataGroup(Friend friend, MessageObject message, bool isVideo, bool group = false)
        {
            isGroup = group;
            isMessage = message;
            //类型
            string str = ToTipContent(message);
            if (!isAnswer)
            {
                myFriend = friend;
                //头像
                ImageLoader.Instance.DisplayAvatar(friend.UserId, rpboxIcon);
                lblNickName.Text = UIUtils.LimitTextLength(friend.NickName, 10, true);
                rpboxClose.Image = Resources.ClosePhone;
                rpbAnswer.Image = Resources.AnswerPhone;
                lblType.Text = str;
                isAnswer = true;
            }
            else
            {
                Task.Factory.StartNew(() =>
                {
                    //等待30秒
                    Thread.Sleep(30 * 1000);
                    //如果接听
                    if (!isChoose)
                    {
                        //对方不愿意
                        ShiKuManager.SendCancelMeetMessage(friend, isVideo);
                        this.Close();
                    }
                });
            }
            this.Show();
            this.Activate();


        }
        #endregion

        #region 窗体加载
        //消息验证的方法
        public void MainMessage(MessageObject message)
        {
            //拒绝
            if (message.type == kWCMessageType.AudioChatCancel || message.type == kWCMessageType.VideoChatCancel)
            {
                MeetFormManager.Instance.InitFrom();
                this.Close();
            }

            if (message.type == kWCMessageType.AudioChatAccept || message.type == kWCMessageType.VideoChatAccept)
            {
                MeetFormManager.Instance.OtherRecive();
                this.Close();
            }
        }

        //消息类型验证
        public void ShowMessage(MessageObject message)
        {
            Action<MessageObject> action = new Action<MessageObject>(MainMessage);
            Invoke(action, message);
        }
        //页面加载
        private void FrmAnswer_Load(object sender, EventArgs e)
        {
            //收到消息通知
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_MEETING_MESSAGE, ShowMessage);
            //我的消息发送成功的通知
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_MEETING_RECEIPT, ShowMessage);

            // 播放声音
            MeetFormManager.Instance.PlayWiatSound();

        }
        #endregion

        #region 按钮点击事件
        //接听
        private void rpbAnswer_Click(object sender, EventArgs e)
        {
            if (isGroup)
            {
                MeetFormManager.Instance.ShowRecivePhoneForm(isMessage, Url, true, isGroup);
                this.Close();
            }
            else
            {
                //发接听消息给别人
                SendAnswerMessage();

                MeetFormManager.Instance.ShowRecivePhoneForm(isMessage, Url, false);
                this.Close();
            }
        }

        private void SendAnswerMessage()
        {
            switch (MeetType)
            {
                case 0:
                    ShiKuManager.SendAgreeMeetMessage(myFriend, false);
                    break;
                case 1:
                    ShiKuManager.SendAgreeMeetMessage(myFriend, true);
                    break;
                case 2:
                    ShiKuManager.SendAgreeScreenMeetMsg(myFriend);
                    break;
                default:
                    break;
            }
        }

        private void SendCancelMessage()
        {
            switch (MeetType)
            {
                case 0:
                    ShiKuManager.SendCancelMeetMessage(myFriend, false);
                    break;
                case 1:
                    ShiKuManager.SendCancelMeetMessage(myFriend, true);
                    break;
                case 2:
                    ShiKuManager.SendCancelScreenMeetMsg(myFriend);
                    break;
                default:
                    break;
            }
        }

        //挂断电话
        private void rpboxClose_Click_1(object sender, EventArgs e)
        {
            if (!isGroup)
            {
                //发通知给别人
                SendCancelMessage();
            }

            MeetFormManager.Instance.InitFrom();

            // 停止声音
            MeetFormManager.Instance.StopWiatSound();
            this.Close();
        }
        #endregion
        #region 窗体关闭
        //关闭窗体
        private void FrmAnswer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Messenger.Default.Unregister(this);
            isChoose = true;
        }
        #endregion

        private void rpboxClose_MouseLeave(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.Black;
        }

        private void rpboxClose_MouseMove(object sender, MouseEventArgs e)
        {
            this.panel1.BackColor = Color.FromArgb(152, 152, 152);

        }
    }
}
