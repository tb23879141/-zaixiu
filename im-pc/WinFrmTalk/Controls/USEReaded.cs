using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls
{

    public partial class USEReaded : UserControl
    {
        public USEReaded()
        {
            InitializeComponent();
        }

        private MessageObject messageObject = new MessageObject();
        public MessageObject messageData
        {
            get
            {
                return messageObject;
            }
            set
            {
                messageObject = value;
                lab_name.Text = EQControlManager.StrAddEllipsis(value.fromUserName, lab_name.Font, lab_name.Width - 10);
                lab_ReaddTime.Text = LanguageXmlUtils.GetValue("read_time", "阅读时间：", true) + TimeUtils.FromatTime(Convert.ToInt32(value.timeSend)).ToString();//消息阅读时间
                pic_head.Tag = Applicate.LocalConfigData.ImageFolderPath + value.fromUserId + ".jpg";
                ImageLoader.Instance.DisplayAvatar(messageObject.fromUserId, this.pic_head);//设置头像

                //现在的时间减去阅读的时间

                lab_time.Text = DateStringFromNow(Helpers.StampToDatetime(value.timeSend));

            }
        }
        //时间的转换
        public static string DateStringFromNow(DateTime dateTime)
        {

            TimeSpan span = DateTime.Now - dateTime;
            if (span.TotalDays > 60)
            {
                return dateTime.ToShortDateString();
            }
            else if (span.TotalDays > 30)
            {
                return
                LanguageXmlUtils.GetValue("one_month_ago", "1个月前");
            }
            else if (span.TotalDays > 14)
            {
                return
                LanguageXmlUtils.GetValue("two_weeks_ago", "2周前");
            }
            else if (span.TotalDays > 7)
            {
                return
                LanguageXmlUtils.GetValue("one_week_ago", "1周前");
            }
            else if (span.TotalDays > 1)
            {
                return
                //string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                Convert.ToInt32(Math.Floor(span.TotalDays)).ToString() + LanguageXmlUtils.GetValue("days_ago", "天前");
            }
            else if (span.TotalHours > 1)
            {
                return
                //string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                Convert.ToInt32(Math.Floor(span.TotalHours)).ToString() + LanguageXmlUtils.GetValue("hours_ago", "小时前");
            }
            else if (span.TotalMinutes > 1)
            {
                return
                //string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                Convert.ToInt32(Math.Floor(span.TotalMinutes)).ToString() + LanguageXmlUtils.GetValue("minutes_ago", "分钟前");
            }
            else if (span.TotalSeconds >= 1)
            {
                return
                //string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                Convert.ToInt32(Math.Floor(span.TotalSeconds)).ToString() + LanguageXmlUtils.GetValue("seconds_ago", "秒前");
            }
            else
            {
                return
                LanguageXmlUtils.GetValue("one_sencond_ago", "1秒前");
            }
        }


    }
}
