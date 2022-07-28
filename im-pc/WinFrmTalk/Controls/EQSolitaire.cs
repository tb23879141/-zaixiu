using Newtonsoft.Json;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 接龙
    /// </summary>
    public class EQSolitaire : EQBaseControl
    {
        private string id = "";

        public EQSolitaire(string strJson) : base(strJson)
        {
            isShowRedPoint = true;
            isRemindMessage = false;
        }

        public EQSolitaire(MessageObject messageObject) : base(messageObject)
        {
            isShowRedPoint = true;
            isRemindMessage = false;
        }

        public override void Calc_PanelWidth(Control control)
        {
            BubbleHeight = control.Height;
            BubbleWidth = control.Width;
        }


        private SolitairePanel contentView = null;


        public override Control ContentControl()
        {
            var data = JsonConvert.DeserializeObject<SolitaireData>(messageObject.objectId);

            this.id = data.id;
            contentView = new SolitairePanel();
            contentView.SetItemData(data);
            contentView.BackColor = bg_color;

            contentView.MouseClick += ContentView_MouseClick;

            Calc_PanelWidth(contentView);
            return contentView;
        }

        private void ContentView_MouseClick(object sender, MouseEventArgs e)
        {
            //Messenger.Default.Send(this.id, MessageActions.ShowGroupSocial);

            //去除红点
            DrawIsReceive(lab_redPoint, 1);

            //发送已读通知
            if (messageObject.isRead == 0)
                ShiKuManager.SendReadMessage(messageObject.GetFriend(), messageObject, myRole);
        }
    }
}
