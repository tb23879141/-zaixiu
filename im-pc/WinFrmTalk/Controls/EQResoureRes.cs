using Newtonsoft.Json;
using System.Windows.Forms;
using WinFrmTalk.Controls.LayouotControl.Groups;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 活动资源
    /// </summary>
    public class EQResoureRes : EQBaseControl
    {

        public EQResoureRes(MessageObject messageObject) : base(messageObject)
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
        private string id;
        private int type;

        public override Control ContentControl()
        {
            var data = JsonConvert.DeserializeObject<MyGroupResource>(messageObject.objectId);
            this.id = data.id;
            this.type = data.title == "所需资源" ? 0 : 1;
            contentView = new ResourexResPanel();
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

            //去除红点
            DrawIsReceive(lab_redPoint, 1);

            //发送已读通知
            if (messageObject.isRead == 0)
                ShiKuManager.SendReadMessage(messageObject.GetFriend(), messageObject, myRole);


            // 打开资源页
            var frm = Applicate.GetWindow<FrmDetailsResource>();
            if (frm == null)
            {
                frm = new FrmDetailsResource();
                frm.HttpLoadData(id, this.type);
                frm.Show();
            }
            else
            {
                frm.Activate();
                frm.Show();
                frm.BringToFront();
            }
        }
    }
}
