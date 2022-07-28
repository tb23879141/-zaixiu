using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Live;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls
{
    public partial class LiveRoomNotice : UserControl
    {
        public static Dictionary<string, LiveCardBean> lives = new Dictionary<string, LiveCardBean>();
        /// <summary>
        /// room
        /// </summary>
        public Friend RoomData { get; set; }

        public LiveRoomNotice()
        {
            InitializeComponent();
        }

        public void UpdateRoomLiveNotice(string userName, string liveStatus)
        {
            //为了避免直播间重复打开
            if(!lives.Keys.Contains(RoomData.RoomId))     //字典中不存在该群组，则需要添加到字典中
            {
                LiveCardBean liveCardBean = new LiveCardBean();
                liveCardBean.liveRoomId = RoomData.RoomId;
                lives.Add(RoomData.RoomId, liveCardBean);
            }
            else    //在字典中，则更新状态
            {
                LiveCardBean liveCardBean = lives.Where(live => live.Key == RoomData.RoomId).Select(l=>l.Value).FirstOrDefault();
            }

            if (string.IsNullOrEmpty(userName) || liveStatus == "0")
            {
                this.Visible = false;
                lblText.Text = "";
            }
            else
            {
                //this.Cursor = Cursors.Hand;
                //this.MouseClick += RoomLiveNotice_MouseClick;
                lblText.MouseClick += RoomLiveNotice_MouseClick;
                //lblText.Visible = true;
                lblText.Text = EQControlManager.StrAddEllipsis(userName, lblText.Font, 150) + " 正在直播，点击进入";
                //lblText.BringToFront();
                this.Visible = true;
                this.BringToFront();
            }
        }

        private void RoomLiveNotice_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            //避免直播间重复打开
            LiveCardBean liveCardBean = lives.Where(live => live.Key == RoomData.RoomId).Select(l => l.Value).FirstOrDefault();
            if (!liveCardBean.isOpen)
            {
                liveCardBean.isOpen = true;
                new RoomLive().GetRoom_Live(RoomData.RoomId);
            }
            //else  //避免多次点击
            //{
            //    HttpUtils.Instance.ShowTip("该直播间已打开");
            //}
        }

    }
}
