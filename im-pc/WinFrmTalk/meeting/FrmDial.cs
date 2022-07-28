using CefSharp;
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
    public partial class FrmDial : FrmBase
    {
        #region 窗体加载 拨号界面

        public bool IsOpen;
        public FrmDial()
        {
            InitializeComponent();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            isEscClose = false;
        }
        //消息验证
        public void MainAction(MessageObject message)
        {
            //接听
            if (message.type == kWCMessageType.AudioChatAccept || message.type == kWCMessageType.VideoChatAccept)
            {

                this.Close();
                MeetFormManager.Instance.ShowRecivePhoneForm(message, Url, true);
            }

            //拒绝
            if (message.type == kWCMessageType.AudioChatCancel || message.type == kWCMessageType.VideoChatCancel)
            {

                MeetFormManager.Instance.InitFrom();
                this.Close();
            }

            //忙线中
            if (message.type == kWCMessageType.AudioMeetingSetSpeaker)
            {
                MeetFormManager.Instance.InitFrom();
                this.Close();
            }
        }
        //验证消息类型方法
        public void ShowMessage(MessageObject message)
        {
            //子线程
            Action<MessageObject> action = new Action<MessageObject>(MainAction);
            Invoke(action, message);
        }
        //页面加载
        private void FrmDial_Load(object sender, EventArgs e)
        {
            //消息通知
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_MEETING_MESSAGE, ShowMessage);


            // 播放声音
            MeetFormManager.Instance.PlayWiatSound();
        }
        #endregion
        #region 全局变量
        //定义好友实体
        Friend myFriend;
        //拨打的状态
        bool isChoose;
        //拨打类型
        public bool Isvideo;
        public string Url;
        #endregion
        #region 参数传递与数据填充
        //填充数据
        public void FillDataList(Friend friend)
        {
            myFriend = friend;
            //头像
            ImageLoader.Instance.DisplayAvatar(friend.UserId, rpbInco);
            //昵称
            lblNickName.Text = UIUtils.LimitTextLength(friend.NickName, 5, true);
            rpbClose.Image = Resources.ClosePhone;
        }

        //拨打电话的方法
        public void CallPhone(Friend friend, string url, bool video)
        {
            if (IsOpen)
            {
                this.Activate();
                return;
            }
            Url = url;
            Isvideo = video;
            //实例化
            myFriend = friend;
            //数据填充
            FillDataList(friend);
            //拨打
            isChoose = true;
            ////开启线程池
            Task.Factory.StartNew(() =>
            {
                //等待30秒
                Thread.Sleep(30 * 1000);
                //如果接听
                if (isChoose)
                {
                    //对方不愿意
                    ShiKuManager.SendCancelMeetMessage(friend, video);
                    // 声音
                    MeetFormManager.Instance.StopWiatSound();
                    this.Close();
                }
            });
            this.Activate();
            this.Show();
        }
        #endregion
        #region 按钮事件与窗体关闭
        //挂断
        private void rpbClose_Click(object sender, EventArgs e)
        {
            //自己挂断
            ShiKuManager.SendCancelMeetMessage(myFriend, Isvideo);
            MeetFormManager.Instance.InitFrom();


            // 声音
            MeetFormManager.Instance.StopWiatSound();

            this.Close();
        }
        //窗体关闭事件
        private void FrmDial_FormClosed(object sender, FormClosedEventArgs e)
        {
            isChoose = false;
            Messenger.Default.Unregister(this);
        }
        #endregion


        private void rpbClose_MouseLeave(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.Black;
        }

        private void rpbClose_MouseMove(object sender, MouseEventArgs e)
        {
            this.panel1.BackColor = Color.FromArgb(152, 152, 152);
        }
    }
}
