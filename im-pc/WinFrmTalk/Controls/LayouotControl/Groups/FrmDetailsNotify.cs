using RichTextBoxLinks;
using System;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    public partial class FrmDetailsNotify : FrmBase
    {

        public FrmDetailsNotify()
        {
            InitializeComponent();
            // tvContent.SetReadMode();
        }

        private bool mLoaded;

        public void ShowContent(string title, string text, string shareURL)
        {
            int height = 0;

            if (!UIUtils.IsNull(title))
            {
                var item = CreateTitleControl(title);
                height += item.Height + 15;
                flowLayoutPanel1.Controls.Add(item);
            }

            if (!UIUtils.IsNull(text))
            {
                var item = CreateTextControl(text);
                height += item.Height + 15;
                flowLayoutPanel1.Controls.Add(item);
            }

            if (!UIUtils.IsNull(shareURL))
            {
                var item = CreateImageControl(shareURL);
                height += item.Height + 15;
                flowLayoutPanel1.Controls.Add(item);
            }

            mLoaded = true;
            flowLayoutPanel1.Height = height;
            xScrollBar1.Visible = flowLayoutPanel1.Height > limitPanel.Height;
        }


        public void HttpLoadData(CollectionSave data)
        {
            ShowContent(data.title, data.msg, data.shareURL);
        }



        private Control CreateTitleControl(string text1)
        {
            var text = new Label();
            text.BackColor = flowLayoutPanel1.BackColor;
            text.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            text.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            text.Size = MeasureUtils.MeasureString(text1, text.Font, flowLayoutPanel1.Width);
            text.Text = text1;
            text.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            text.MouseWheel += View_MouseWheel;

            return text;
        }


        private Control CreateTextControl(string text1)
        {
            var text = new RichTextBoxEx();
            text.BackColor = flowLayoutPanel1.BackColor;
            text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            text.ForeColor = System.Drawing.Color.FromArgb(153, 153, 153);
            text.Font = new System.Drawing.Font("微软雅黑", 14f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            text.Size = MeasureUtils.MeasureFixedHeight(text1, text.Font, flowLayoutPanel1.Width, 30);
            text.Text = text1;
            text.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            text.MouseWheel += View_MouseWheel;
            text.DetectUrls = true;
            text.SetReadMode();
            CSetLineSpace.SetLineSpace(text, 30);
            //点击超链接
            text.LinkClicked += (sender, e) =>
            {
                System.Diagnostics.Process.Start(e.LinkText);
            };

            return text;
        }

        private Control CreateImageControl(string url)
        {
            var ivImage = new PictureBox();
            ivImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ivImage.Size = new System.Drawing.Size(350, 700);
            ivImage.Margin = new System.Windows.Forms.Padding((flowLayoutPanel1.Width - 350) / 2, 0, 0, 15);
            ImageLoader.Instance.Load(url).Into(ivImage);
            ImageLoader.Instance.Load(url).Into((bit, path) =>
            {
                if (bit != null)
                {
                    int height = Convert.ToInt32((float)bit.Height / bit.Width * ivImage.Width);
                    ivImage.Height = height;
                    ivImage.Image = bit;

                    if (mLoaded)
                    {
                        flowLayoutPanel1.Height += (height - 700);
                        xScrollBar1.Visible = flowLayoutPanel1.Height > limitPanel.Height;
                    }
                }
            });


            ivImage.MouseWheel += View_MouseWheel;
            return ivImage;
        }




        #region 给子控件添加滚轮事件
        private void AddCrlMouseWheel(Control crl)
        {
            crl.MouseWheel += View_MouseWheel;

            AddCrlMouseWheelList(crl.Controls);
        }

        private void AddCrlMouseWheelList(Control.ControlCollection controls)
        {
            if (controls == null)
            {
                return;
            }

            foreach (Control item in controls)
            {

                AddCrlMouseWheel(item);
            }
        }


        /// <summary>
        /// 鼠标滚动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_MouseWheel(object sender, MouseEventArgs e)
        {

            if (flowLayoutPanel1.Height <= limitPanel.Height)
            {
                return;
            }

            int totleHeight = flowLayoutPanel1.Height - limitPanel.Height;


            int movey = e.Delta > 0 ? 40 : -40;

            if (flowLayoutPanel1.Location.Y + movey > 0)
            {
                movey = -flowLayoutPanel1.Location.Y;
            }
            else if (flowLayoutPanel1.Location.Y + movey < -totleHeight)
            {
                movey = Math.Abs(flowLayoutPanel1.Location.Y) - totleHeight;
            }


            // 移动panel
            ModifyLocation(flowLayoutPanel1, movey, false);

            // 同步滚动条
            var pro = Math.Abs(flowLayoutPanel1.Location.Y) / (float)totleHeight * 100;
            xScrollBar1.SetProgress((int)pro);
        }


        /// <summary>
        /// 修改控件位置
        /// </summary>
        /// <param name="control"></param>
        /// <param name="loc_y"></param>
        /// <param name="abs">是否绝对坐标</param>
        private void ModifyLocation(Control control, int loc_y, bool abs = true)
        {
            Point point = control.Location;

            if (abs)
            {
                point.Y = loc_y;
            }
            else
            {
                point.Y = point.Y + loc_y;
            }

            control.Location = point;
        }

        private int last_progress;
        private void xScrollBar1_ScrollChangeListener()
        {
            if (xScrollBar1.Value == last_progress)
            {
                return;
            }

            if (limitPanel.Height > flowLayoutPanel1.Height)
            {
                return;
            }


            last_progress = xScrollBar1.Value;


            float max = flowLayoutPanel1.Height - limitPanel.Height;

            int movey = Convert.ToInt32(last_progress / 100f * max * -1);

            // 移动panel
            ModifyLocation(flowLayoutPanel1, movey, true);
        }

        #endregion
    }
}
