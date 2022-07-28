using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;
using WinFrmTalk.View;
using System.Diagnostics;
using WinFrmTalk.Live;
using CefSharp.WinForms.Internals;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class LiveCardItem : UserControl
    {
        public LiveCardBean LiveCardBean { get; set; }

        public UseLiveList useLiveList { get; set; }
        public LiveCardItem()
        {
            InitializeComponent();
        }

        private void LiveCardItem_Paint(object sender, PaintEventArgs e)
        {
            //Draw(e.ClipRectangle, e.Graphics, 18);
            //base.OnPaint(e);
        }

        private void Draw(Rectangle rectangle, Graphics g, int _radius, bool cusp, Color begin_color, Color end_color)
        {
            int span = 2;
            //抗锯齿
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //渐变填充
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush(rectangle, begin_color, end_color, LinearGradientMode.Vertical);
            //画尖角
            if (cusp)
            {
                span = 10;
                PointF p1 = new PointF(rectangle.Width - 12, rectangle.Y + 10);
                PointF p2 = new PointF(rectangle.Width - 12, rectangle.Y + 30);
                PointF p3 = new PointF(rectangle.Width, rectangle.Y + 20);
                PointF[] ptsArray = { p1, p2, p3 };
                g.FillPolygon(myLinearGradientBrush, ptsArray);
            }
            //填充
            g.FillPath(myLinearGradientBrush, DrawRoundRect(rectangle.X, rectangle.Y, rectangle.Width - span, rectangle.Height - 1, _radius));
        }

        public static GraphicsPath DrawRoundRect(int x, int y, int width, int height, int radius)
        {
            //四边圆角
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, radius, radius, 180, 90);
            gp.AddArc(width - radius, y, radius, radius, 270, 90);
            gp.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            gp.AddArc(x, height - radius, radius, radius, 90, 90);
            gp.CloseAllFigures();
            return gp;
        }

        public void BindDataToUI(LiveCardBean liveCardBean)
        {
            LiveCardBean = liveCardBean;
            tv_title.Text = liveCardBean.name;
            tv_nickname.Text = liveCardBean.nickName;
            tv_count.Text = liveCardBean.numbers.ToString();
            ImageLoader.Instance.DisplayAvatar(liveCardBean.userId, null, (bmp) =>
            {
                this.iv_head.BackgroundImageLayout = ImageLayout.Zoom;
                this.iv_head.BackgroundImage = EQControlManager.ClipImage(bmp, this.iv_head.Width, this.iv_head.Height);
            });

            if (liveCardBean.userId == "10000")
            {
                iv_cover.BackgroundImage = Resources.avatar_notice;
            }
            else
            {
                string url = ImageLoader.Instance.GetHeadUrl(liveCardBean.userId, false);
                ImageLoader.Instance.Load(url).Error(Resources.avatar_default).Into((bmp, path) =>
                {
                    this.iv_cover.BackgroundImageLayout = ImageLayout.Zoom;
                    this.iv_cover.BackgroundImage = EQControlManager.ClipImage(bmp, this.iv_cover.Width, this.iv_cover.Height);
                });
            }

            //所有控件绑定点击事件
            ControlAddMouseClick(this);
        }

        private void ControlAddMouseClick(Control crl)
        {
            crl.MouseClick += LiveCardItem_MouseClick;
            foreach (Control item in crl.Controls)
            {
                if (item.Controls.Count > 0)
                    ControlAddMouseClick(item);
                item.Cursor = Cursors.Hand;
                item.MouseClick += LiveCardItem_MouseClick;
            }
        }

        private void LiveCardItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (LiveCardBean.isOpen)
                {
                    HttpUtils.Instance.ShowTip("该直播间已打开");
                    this.Activate();
                    return;
                }
                //自己的直播间不允许打开
                if (LiveCardBean.userId == Applicate.MyAccount.userId)
                {
                    HttpUtils.Instance.ShowTip("不能打开自己的直播间");
                    return;
                }
                if (TimeUtils.CurrentIntTime() - Applicate.ColseLiveTime < 2)
                {
                    HttpUtils.Instance.ShowTip("请稍候");
                    return;
                }
                try
                {
                    if (!useLiveList.frmLivePairs.ContainsKey(LiveCardBean.url))
                    {
                        FrmLive frmLive = new FrmLive();
                        frmLive.useLiveList = this.useLiveList;
                        frmLive.LiveStart(LiveCardBean.url, LiveCardBean, 1);
                        Console.WriteLine("click");

                        frmLive.Show();
                    }
                    else
                    {
                        useLiveList.frmLivePairs[LiveCardBean.url].Activate();
                    }
                   
                    //if (!AllowEnter)
                    //{
                    //    HttpUtils.Instance.ShowTip("您已被踢出");
                    //    frmLive.Dispose();
                    //}
                    //else
                    //{
                    //    frmLive.Show();
                    //}





                    //FrmLiveTest frmLiveTest = new FrmLiveTest();
                    //frmLiveTest.LiveStart(LiveCardBean.url, LiveCardBean);
                    //frmLiveTest.Show();
                }
                catch (Exception ex)
                {
                    LogHelper.log.Error("----------------打开直播间失败:", ex);
                }
                // LiveCardBean.isOpen = true;
            }
        }


    }
}
