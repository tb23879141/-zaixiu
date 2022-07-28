using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.View
{
    public partial class FrmNewsTip : FrmBase
    {
        private const int MAXTIME = 10;     //指定多少秒后关闭窗体
        private int time = 0;               //用于倒计时
        private Thread CloseForm = null;    //自动关闭窗体的线程
        public Friend sender { get; private set; }

        public FrmNewsTip()
        {
            InitializeComponent();

            //获取屏幕
            var screen = Screen.FromPoint(new Point(Cursor.Position.X, Cursor.Position.Y));
            //设置显示在右下角
            var x = screen.WorkingArea.X + screen.WorkingArea.Width - this.Width;
            var y = screen.WorkingArea.Y + screen.WorkingArea.Height - this.Height;
            this.Location = new Point(x, y);

            this.TitleNeed = false;
            lblInfo.Text = Applicate.APP_NAME;
            //设置Info的位置始终在右下角（文自适应）
            int point_x = this.Width - lblInfo.Width - 10;
            lblInfo.Location = new Point(point_x, lblInfo.Location.Y);

            //初始化自动关闭窗体的线程
            CloseForm = new Thread((time) =>
            {
                while((int)time >= MAXTIME)
                {
                    this.Close();
                }
                time = (int)time + 1;
                Thread.Sleep(1000);     //每秒执行一次
            });
            CloseForm.IsBackground = true;
            CloseForm.Start(time);
        }

        public void BindData(Friend sender, MessageObject msg_news)
        {
            if (sender == null || string.IsNullOrEmpty(sender.UserId) || msg_news == null || string.IsNullOrEmpty(msg_news.messageId))
                return;

            //绑定发送人
            this.sender = sender;
            string u_name = string.IsNullOrEmpty(sender.RemarkName) ? sender.NickName : sender.RemarkName;
            lblName.Text = EQControlManager.StrAddEllipsis(u_name, this.Font, this.Width - 50);
            //this.Text = EQControlManager.StrAddEllipsis(u_name, this.Font, this.Width - 50);

            //绑定消息内容
            if (sender.IsGroup == 1)
            {
                lblNews.Text = msg_news.fromUserName + ":" + ToContentTipByType(msg_news.type, msg_news.content);
            }
            else
            {
                lblNews.Text = ToContentTipByType(msg_news.type, msg_news.content);
            }
            //EQControlManager.StrAddEllipsis(lblNews, lblNews.Font, this.Width - 40);
            lblNews.Text = EQControlManager.StrAddEllipsis(lblNews.Text, lblNews.Font, lblNews.Width - 20);

            //刷新头像
            if (sender.IsGroup == 1)
            {
                ImageLoader.Instance.DisplayGroupAvatar(sender.UserId, sender.RoomId, ptbHead);
            }
            else
            {
                ImageLoader.Instance.DisplayAvatar(sender.UserId, ptbHead);
            }
        }

        /// <summary>
        /// 刷新数据到窗体
        /// </summary>
        /// <param name="sender">发送人</param>
        /// <param name="msg_news">新消息</param>
        public void RefreshData(MessageObject msg_news)
        {
            if(msg_news != null && !string.IsNullOrEmpty(msg_news.messageId))
            {
                time = 0;
                //绑定消息内容
                if (sender.IsGroup == 1)
                {
                    lblNews.Text = msg_news.fromUserName + ":" + ToContentTipByType(msg_news.type, msg_news.content);
                }
                else
                {
                    lblNews.Text = ToContentTipByType(msg_news.type, msg_news.content);
                }
                EQControlManager.StrAddEllipsis(lblNews, lblNews.Font, this.Width - 40);
            }
        }

        /// <summary>
        /// 显示新消息提醒窗（一个好友一个窗体）
        /// </summary>
        public void ShowTip()
        {

        }

        public string ToContentTipByType(kWCMessageType type, string content)
        {

            if (!UIUtils.IsNull(content))
            {
                content = content.Replace("\r\n", "");
                content = content.Replace("\n", "");
            }

            switch (type)
            {
                case kWCMessageType.Image:
                    return "[" + LanguageXmlUtils.GetValue("Image", "图片") + "]";
                case kWCMessageType.Voice:
                    return "[" + LanguageXmlUtils.GetValue("Voice", "语音") + "]";
                case kWCMessageType.Location:
                    return "[" + LanguageXmlUtils.GetValue("Location", "位置") + "]";
                case kWCMessageType.Gif:
                    return "[" + LanguageXmlUtils.GetValue("Gif", "动画") + "]";
                case kWCMessageType.Video:
                    return "[" + LanguageXmlUtils.GetValue("Video", "视频") + "]";
                case kWCMessageType.Audio:
                    return "[" + LanguageXmlUtils.GetValue("Audio", "视频") + "]";
                case kWCMessageType.Card:
                    return "[" + LanguageXmlUtils.GetValue("Card", "名片") + "]";
                case kWCMessageType.File:
                    return "[" + LanguageXmlUtils.GetValue("File", "文件") + "]";
                case kWCMessageType.RedPacket:
                    return "[" + LanguageXmlUtils.GetValue("RedPacket", "红包") + "]";
                case kWCMessageType.TRANSFER:
                    return "[" + LanguageXmlUtils.GetValue("TRANSFER", "转账") + "]";
                case kWCMessageType.ImageTextSingle:
                    return "[" + LanguageXmlUtils.GetValue("ImageTextSingle", "单条图文") + "]";
                case kWCMessageType.ImageTextMany:
                    return "[" + LanguageXmlUtils.GetValue("ImageTextMany", "多条图文") + "]";
                case kWCMessageType.Link:
                case kWCMessageType.SDKLink:
                    return "[" + LanguageXmlUtils.GetValue("Link", "链接") + "]";
                case kWCMessageType.PokeMessage:
                    return "[" + LanguageXmlUtils.GetValue("PokeMessage", "戳一戳") + "]";
                case kWCMessageType.History:
                    return "[" + LanguageXmlUtils.GetValue("History", "聊天记录") + "]";
                case kWCMessageType.AudioChatEnd:
                    return "[" + LanguageXmlUtils.GetValue("AudioChatEnd", "语音通话结束") + "]";
                case kWCMessageType.VideoChatEnd:
                    return "[" + LanguageXmlUtils.GetValue("VideoChatEnd", "视频通话结束") + "]";
                case kWCMessageType.VideoChatCancel:
                    return "[" + LanguageXmlUtils.GetValue("VideoChatCancel", "视频通话拒绝") + "]";
                case kWCMessageType.AudioChatCancel:
                    return "[" + LanguageXmlUtils.GetValue("AudioChatCancel", "语音通话拒绝") + "]";
                case kWCMessageType.RedBack:
                    return LanguageXmlUtils.GetValue("RedBack", "红包已过期,余额已退回零钱");
                case kWCMessageType.TYPE_SECURE_LOST_KEY:
                    return "[" + LanguageXmlUtils.GetValue("TYPE_SECURE_LOST_KEY", "请求群组通讯密钥") + "]";
                case kWCMessageType.TYPE_SECURE_SEND_KEY:
                    return "[" + LanguageXmlUtils.GetValue("TYPE_SECURE_SEND_KEY", "发送群组通讯密钥") + "]";
                case kWCMessageType.ProductPush:
                    return "[" + LanguageXmlUtils.GetValue("ProductPush", "商品链接") + "]";
                default:
                    return content;
            }
        }

        private void LblNews_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var frmMain = Applicate.GetWindow<FrmMain>();
            frmMain.WindowState = FormWindowState.Normal;
            frmMain.MainShow();
            frmMain.isTwinkle = false;
            frmMain.replace = true;
            frmMain.RefreshIcon();

            Messenger.Default.Send(this.sender, FrmMain.START_NEW_CHAT);

            this.Close();
        }
    }
}
