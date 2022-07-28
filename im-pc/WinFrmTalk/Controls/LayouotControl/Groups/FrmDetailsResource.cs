using RichTextBoxLinks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    /// <summary>
    /// 资源详情
    /// </summary>
    public partial class FrmDetailsResource : FrmBase
    {
        private int ProvideType { get; set; }

        private ResourceModel mData;

        public FrmDetailsResource()
        {
            InitializeComponent();
            if (Program.Started)
            {
                AddCrlMouseWheel(flowLayoutPanel1);
            }
        }

        internal void HttpLoadData(string reId, int type = 1)
        {
            ProvideType = type;

            HttpUtils.Instance.Post().Url(Applicate.URLDATA.data.apiUrl + "resource/getResourceList")
                 .AddParams("reId", reId)
                 .NoErrorTip()
                 .Build()
                 .ExecuteJson<List<ResourceModel>>((success, data) =>
                 {
                     if (success && !UIUtils.IsNull(data))
                     {
                         FillDetailsData(data[0]);
                     }
                 });

        }

        private void SwitchTitleTab(bool provide, bool nodemand)
        {
            Color foucs = Color.FromArgb(51, 51, 51);
            Color unfoucs = Color.FromArgb(153, 153, 153);
            tvProvide.ForeColor = provide ? foucs : unfoucs;
            tvDemain.ForeColor = provide ? unfoucs : foucs;

            if (nodemand)
            {
                label2.Visible = false;
                tvDemain.Visible = false;
            }
        }

        private void SetUserInfoData(ResourceModel data)
        {
            // 放置群成员头像
            if (UIUtils.IsNull(data.headUrl))
            {
                ImageLoader.Instance.DisplayAvatar(data.userId, data.nickName, ivIcon);
            }
            else
            {
                ImageLoader.Instance.Load(data.headUrl).Avatar().Error(data.nickName).Into(ivIcon);
            }


            tvName.Text = data.nickName;
            tvTime.Text = TimeUtils.FromatTime(data.time, "yyyy-MM-dd HH:mm");
        }



        private void FillDetailsData(ResourceModel data)
        {
            this.mData = data;

            SwitchTitleTab(data.provideType == ProvideType, data.demand == null);

            SetUserInfoData(data);

            if (data.provideType == ProvideType)
            {
                AppendResouceData(data.provide);
            }
            else
            {
                AppendResouceData(data.demand);
            }
        }

        private bool mLoaded = false;
        private void AppendResouceData(ResourceContent data)
        {
            if (data == null)
            {
                return;
            }

            int height = 95;
            var text = CreateTextControl(data.body);
            flowLayoutPanel1.Controls.Add(text);
            height += text.Height + 15;


            if (data.picture != null)
            {
                foreach (var url in data.picture)
                {
                    var image = CreateImageControl(url);
                    flowLayoutPanel1.Controls.Add(image);
                    height += image.Height + 15;
                }

            }

            var forword = CreateForwardControl(data.forward);
            flowLayoutPanel1.Controls.Add(forword);
            height += forword.Height + 15;


            flowLayoutPanel1.Height = height;
            mLoaded = true;
            xScrollBar1.Visible = flowLayoutPanel1.Height > limitPanel.Height;
        }

        private void RemoveResouceData()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(panel2);
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

            text.SetReadMode();
            CSetLineSpace.SetLineSpace(text, 30);
            return text;
        }

        private Control CreateImageControl(string url)
        {
            var ivImage = new PictureBox();
            ivImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ivImage.Size = new System.Drawing.Size(350, 700);
            ivImage.Margin = new System.Windows.Forms.Padding((flowLayoutPanel1.Width - 350) / 2, 0, 0, 15);
            ImageLoader.Instance.Load(url).Into((bit, path) =>
            {
                if (bit != null)
                {
                    int height = Convert.ToInt32((float)bit.Height / bit.Width * 350);
                    ivImage.Height = height;
                    ivImage.Image = bit;

                    if (mLoaded)
                    {
                        flowLayoutPanel1.Height += (height - 700);
                    }
                }
            });
            ivImage.MouseWheel += View_MouseWheel;
            return ivImage;
        }


        private Control CreateForwardControl(int count)
        {
            var ivImage = new Label();
            ivImage.Image = Resources.ic_group_resource_share;
            ivImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ivImage.ForeColor = Color.FromArgb(51, 51, 51);
            ivImage.Text = string.Format("     转发 {0}", count);
            ivImage.TextAlign = ContentAlignment.MiddleLeft;
            ivImage.Size = new System.Drawing.Size(350, 24);
            ivImage.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            ivImage.MouseWheel += View_MouseWheel;
            ivImage.Cursor = System.Windows.Forms.Cursors.Hand;
            ivImage.MouseClick += IvImage_MouseClick;
            return ivImage;
        }

        private void IvImage_MouseClick(object sender, MouseEventArgs e)
        {

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

        private void Title_MouseClick(object sender, MouseEventArgs e)
        {
            var item = sender as Control;
            int provide = Convert.ToInt32(item.Tag);

            SwitchTitleTab(provide == 1, mData.demand == null);

            RemoveResouceData();

            if (provide == 1)
            {
                AppendResouceData(mData.provide);
            }
            else
            {
                AppendResouceData(mData.demand);
            }
        }
    }






    public class ResourceModel
    {

        public string headUrl { get; set; }
        public string userId { get; set; }
        public string nickName { get; set; }
        public long time { get; set; }
        public int provideType { get; set; }
        public ResourceContent demand { get; set; }
        public ResourceContent provide { get; set; }
    }


    public class ResourceContent
    {
        /// <summary>
        /// 减肥一般是可以吃土豆，并不会影响到减肥效果，但是一定要注意合理饮食。
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int collect { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int forward { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int isCollect { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int isPraise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> picture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int praise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int reType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string rid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }

    }




}
