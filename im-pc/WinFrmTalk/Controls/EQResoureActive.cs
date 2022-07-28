using Newtonsoft.Json;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 活动
    /// </summary>
    public class EQResoureActive : EQBaseControl
    {
        public EQResoureActive(MessageObject messageObject) : base(messageObject)
        {
            isShowRedPoint = true;
            isRemindMessage = false;
        }

        public override void Calc_PanelWidth(Control control)
        {
            BubbleHeight = control.Height;
            BubbleWidth = control.Width;
        }


        private ResourexActivePanel contentView = null;
        private string id = "";


        public override Control ContentControl()
        {
            var data = JsonConvert.DeserializeObject<MyGroupActivity>(messageObject.objectId);
            this.id = data.id;
            contentView = new ResourexActivePanel();
            contentView.SetItemData(data);
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

            Messenger.Default.Send(this.id, MessageActions.ShowGroupActive);

            //去除红点
            DrawIsReceive(lab_redPoint, 1);

            //发送已读通知
            if (messageObject.isRead == 0)
                ShiKuManager.SendReadMessage(messageObject.GetFriend(), messageObject, myRole);
        }
    }
}
