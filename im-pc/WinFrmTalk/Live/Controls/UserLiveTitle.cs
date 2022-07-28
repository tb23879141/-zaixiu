using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.View;

namespace WinFrmTalk.Live.Controls
{
    public partial class UserLiveTitle : UserControl
    {
        private FrmLive frmLive = null;
        private LiveCardBean liveCardBean = null;
        public bool isShowCloseLive { get => lblClose.Visible; set => lblClose.Visible = value; }
        public UserLiveTitle()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="liveCardBean"></param>
        public void setdata(LiveCardBean liveCardBean, FrmLive frmLive)
        {
            this.frmLive = frmLive;
            this.liveCardBean = liveCardBean;
            lbl_name.Text = liveCardBean.name;
            lbl_tips.Text = liveCardBean.numbers.ToString();
            ImageLoader.Instance.DisplayAvatar(liveCardBean.userId, picRoom);
            lblClose.Visible = !string.IsNullOrEmpty(liveCardBean.liveRoomId);
        }
        /// <summary>
        /// 弹幕是否开启的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        private void panel1_Click(object sender, EventArgs e)
        {
           
        }

        private void lblClose_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (liveCardBean.userId.Equals(Applicate.MyAccount.userId))
            {
                frmLive.Close();
                return;
            }

            //强制结束直播
            var builder = HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/closeRoomLiveByAdmin")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", liveCardBean.roomId);
            if (!string.IsNullOrEmpty(liveCardBean.liveRoomId))
            {
                builder.AddParams("liveRoomId", liveCardBean.liveRoomId);
            }
            builder.Build()
                .Execute((success, result) =>
                {
                    if (success && result.Count > 0)
                    {
                        frmLive.Close();
                    }
                });
        }

        private void PicRoom_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (!liveCardBean.userId.Equals(Applicate.MyAccount.userId))
                return;

            FrmBuildLive frmBuildLive = new FrmBuildLive();
            frmBuildLive.lblTitle.Text = "修改直播间";
            frmBuildLive.txtName_Text = liveCardBean.name;
            frmBuildLive.txtNotice_Text = liveCardBean.notice;
            frmBuildLive.roomType = int.Parse(liveCardBean.roomType);
            frmBuildLive.btnStartLive_Text = "确认修改";
            var parent = Applicate.GetWindow<FrmMain>();
            frmBuildLive.Location = new Point(parent.Location.X + (parent.Width - frmBuildLive.Width) / 2, parent.Location.Y + (parent.Height - frmBuildLive.Height) / 2);//居中
            frmBuildLive.ShowDialog();
            if (frmBuildLive.DialogResult == DialogResult.OK)
            {
                //如果没修改就点确定
                if (frmBuildLive.txtName_Text.Equals(liveCardBean.name) && frmBuildLive.txtNotice_Text.Equals(liveCardBean.notice))
                {
                    HttpUtils.Instance.ShowTip("修改失败：未修改任何内容");
                }
                else
                {
                    liveCardBean.name = frmBuildLive.txtName_Text;
                    liveCardBean.notice = frmBuildLive.txtNotice_Text;

                    //强制结束直播
                    var builder = HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/update")
                        .AddParams("access_token", Applicate.Access_Token)
                        .AddParams("roomId", liveCardBean.roomId)
                        .AddParams("name", frmBuildLive.live_name)
                        .AddParams("notice", frmBuildLive.live_notice)
                        .AddParams("roomType", frmBuildLive.live_type.ToString());
                    if (!string.IsNullOrEmpty(liveCardBean.liveRoomId))
                    {
                        builder.AddParams("liveRoomId", liveCardBean.liveRoomId);
                    }
                    builder.Build()
                        .Execute((success, result) =>
                        {
                            if (success && result.Count > 0)
                            {
                                Invoke(new Action(() =>
                                {
                                    this.lbl_name.Text = frmBuildLive.live_name;
                                }));

                                HttpUtils.Instance.ShowTip("修改成功");
                            }
                        });
                }
            }
        }
    }
}
