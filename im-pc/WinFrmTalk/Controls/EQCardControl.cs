using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls
{
    public class EQCardControl : EQBaseControl
    {
        public EQCardControl(string strJson) : base(strJson)
        {
            isShowRedPoint = true;
            isRemindMessage = false;
        }

        public EQCardControl(MessageObject messageObject) : base(messageObject)
        {
            isShowRedPoint = true;
            isRemindMessage = false;
        }

        public override void Calc_PanelWidth(Control control)
        {
            BubbleWidth = control.Width;
            BubbleHeight = control.Height;
        }

        private CardPanel panel_card;
        public override Control ContentControl()
        {
            panel_card = new CardPanel();


            panel_card.SetItemData(messageObject);


            panel_card.Tag = messageObject.messageId;

            //设置气泡大小
            Calc_PanelWidth(panel_card);

            //鼠标点击事件
            panel_card.MouseClick += Panel_card_MouseClick; ;

            return panel_card;
        }

        private void Panel_card_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }

            MessageObject msg = this.messageObject;

            if (msg.isRead == 0)
                ShiKuManager.SendReadMessage(msg.GetFriend(), msg, myRole);

            //更新UI
            var crl_msg = Controls["lab_redPoint"];
            if (crl_msg != null && crl_msg is Label lab_redPoint && lab_redPoint.Image != null)
            {
                //去除红点
                DrawIsReceive(lab_redPoint, 1);
            }

            if (messageObject.timeLen == 1)
            {
                //显示群信息
                var frmFriendsBasic = new FrmGroupBasic();
                frmFriendsBasic.ShowGroupInfoById(msg.signature);

            }
            else
            {
                //显示用户信息
                var frmFriendsBasic = new FrmFriendsBasic();
                frmFriendsBasic.ShowUserInfoById(msg.objectId);
            }

        }
    }
}
