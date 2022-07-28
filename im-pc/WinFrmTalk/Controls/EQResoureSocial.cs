using Newtonsoft.Json;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 秀吧
    /// </summary>
    public class EQResoureSocial : EQBaseControl
    {
        private string id = "";

        public EQResoureSocial(string strJson) : base(strJson)
        {
            isShowRedPoint = true;
            isRemindMessage = false;
        }

        public EQResoureSocial(MessageObject messageObject) : base(messageObject)
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
            var data = JsonConvert.DeserializeObject<MyGroupResource>(messageObject.objectId);

            this.id = data.id;
            contentView = new ResourexResPanel();
            contentView.SetItemData(data, false);
            contentView.BackColor = bg_color;

            contentView.MouseClick += ContentView_MouseClick;

            Calc_PanelWidth(contentView);
            return contentView;
        }

        private void ContentView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }

            Messenger.Default.Send(this.id, MessageActions.ShowGroupSocial);

            //去除红点
            DrawIsReceive(lab_redPoint, 1);

            //发送已读通知
            if (messageObject.isRead == 0)
                ShiKuManager.SendReadMessage(messageObject.GetFriend(), messageObject, myRole);
        }
    }
}
