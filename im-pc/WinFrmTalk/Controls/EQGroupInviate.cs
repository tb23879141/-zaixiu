using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 群邀请
    /// </summary>
    public class EQGroupInviate : EQBaseControl
    {

        public EQGroupInviate(string strJson) : base(strJson)
        {
            isShowRedPoint = true;
            isRemindMessage = false;
        }

        public EQGroupInviate(MessageObject messageObject) : base(messageObject)
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
            contentView.SetCardItemData(messageObject);
            contentView.BackColor = bg_color;

            contentView.MouseClick += ContentView_MouseClick;

            Calc_PanelWidth(contentView);
            return contentView;
        }

        private void ContentView_MouseClick(object sender, MouseEventArgs e)
        {
            // 去除红点
            DrawIsReceive(lab_redPoint, 1);

            // 发送已读通知
            if (messageObject.isRead == 0)
                ShiKuManager.SendReadMessage(messageObject.GetFriend(), messageObject, myRole);


            // 修改
            if (messageObject.timeLen == 1)
            {
                //显示群信息
                var frmFriendsBasic = new FrmGroupBasic();
                frmFriendsBasic.ShowGroupInfoById(messageObject.signature);

            }
            else
            {
                //显示用户信息
                var frmFriendsBasic = new FrmFriendsBasic();
                frmFriendsBasic.ShowUserInfoById(messageObject.objectId);
            }
        }
    }
}
