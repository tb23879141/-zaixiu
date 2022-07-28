using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 公告
    /// 公告/秀吧/等
    /// </summary>
    public class EQResoureNotify : EQBaseControl
    {
        private string title = "";
        private string link_url = "";
        private string img_url = "";

        public EQResoureNotify(string strJson) : base(strJson)
        {
            isShowRedPoint = true;
            isRemindMessage = false;
        }

        public EQResoureNotify(MessageObject messageObject) : base(messageObject)
        {
            isShowRedPoint = true;
            isRemindMessage = false;
        }

        public override void Calc_PanelWidth(Control control)
        {
            BubbleHeight = control.Height;
            BubbleWidth = control.Width;
        }


        private ResourexResPanel contentView = null;


        public override Control ContentControl()
        {
            contentView = new ResourexResPanel();
            contentView.SetItemData(this.messageObject);
            contentView.BackColor = bg_color;

            Calc_PanelWidth(contentView);
            contentView.MouseClick += ContentView_MouseClick;

            return contentView;
        }

        private void ContentView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }

            CollectionSave data = toCollection();
            Messenger.Default.Send(data, MessageActions.ShowGroupNotify);

            //去除红点
            DrawIsReceive(lab_redPoint, 1);

            //发送已读通知
            if (messageObject.isRead == 0)
                ShiKuManager.SendReadMessage(messageObject.GetFriend(), messageObject, myRole);
        }

        private CollectionSave toCollection()
        {
            CollectionSave item = new CollectionSave();
            item.title = this.messageObject.fileName;
            item.shareURL = this.messageObject.objectId;
            item.msg = this.messageObject.content;
            return item;

        }
    }
}
