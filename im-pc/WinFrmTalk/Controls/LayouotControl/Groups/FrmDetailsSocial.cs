using Newtonsoft.Json;
using RichTextBoxLinks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Controls.LayouotControl.Items;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    /// <summary>
    /// 秀吧
    /// </summary>
    public partial class FrmDetailsSocial : FrmBase
    {
        private ResourceSocial mData;

        public FrmDetailsSocial()
        {
            InitializeComponent();
            if (Program.Started)
            {
                AddCrlMouseWheel(flowLayoutPanel1);
            }
        }

        internal void HttpLoadData(string reId)
        {
            HttpUtils.Instance.Post().Url(Applicate.URLDATA.data.apiUrl + "bbs/getOneList")
                 .AddParams("bbsId", reId)
                 .NoErrorTip()
                 .Build()
                 .ExecuteJson<ResourceSocial>((success, data) =>
                 {
                     if (success)
                     {
                         FillDetailsData(data);
                     }
                 });

        }


        internal void HttpCommentData(string reId)
        {
            //https://test-xiu.tnshow.com/bbs/commentList?showId=62b4346b1bc02856d6963c27&pageIndex=0&pageSize=20&language=zh&access_token=2aed3c0199b841c890ec7391c31bbc7f&salt=1656138564575&secret=vRyNcxXpZqnAsvVIsL%2FMQQ%3D%3D
            HttpUtils.Instance.Post().Url(Applicate.URLDATA.data.apiUrl + "bbs/commentList")
                 .AddParams("showId", reId)
                 .AddParams("pageIndex", "0")
                 .AddParams("pageSize", "20")
                 .NoErrorTip()
                 .Build()
                 .ExecuteJson<List<SocialCommentData>>((success, dataList) =>
                 {
                     if (success && !UIUtils.IsNull(dataList))
                     {

                         // 添加评论
                         int height = flowLayoutPanel1.Height;
                         height += AppendCommentData(dataList);

                         flowLayoutPanel1.Height = height;
                         xScrollBar1.Visible = flowLayoutPanel1.Height > limitPanel.Height;

                     }
                 });

        }

        private void SetUserInfoData(ResourceSocial data)
        {
            // 放置群成员头像
            ImageLoader.Instance.DisplayAvatar(data.userId, ivIcon, true, null, data.nickName);

            tvName.Text = data.nickName;
            tvTime.Text = TimeUtils.FromatTime(data.time, "yyyy-MM-dd HH:mm");
        }



        private void FillDetailsData(ResourceSocial data)
        {
            this.mData = data;

            tvTitle.Text = data.title;

            SetUserInfoData(data);

            AppendContentData(data);

        }

        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="NotImplementedException"></exception>
        private int AppendCommentData(List<SocialCommentData> comments)
        {

            int height = 0;
            foreach (var comm in comments)
            {
                var item = new SocialCommentItem();
                item.SetContentData(comm);
                item.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
                item.MouseWheel += View_MouseWheel;
                item.BackColor = flowLayoutPanel1.BackColor;
                height += item.Height + 10;

                flowLayoutPanel1.Controls.Add(item);
            }

            return height;
        }

        private void AppendContentData(ResourceSocial data)
        {
            int height = 70 + tvTitle.Height;

            Control control = null;
            foreach (var content in data.contents)
            {
                if (content.type == 1)
                {
                    // 文字
                    control = CreateTextControl(content.content);

                }
                else if (content.type == 2)
                {
                    //图片
                    control = CreateImageControl(content);
                }

                flowLayoutPanel1.Controls.Add(control);
                height += control.Height + 15;
            }


            var forword = CreateForwardControl(data.forward, true);
            flowLayoutPanel1.Controls.Add(forword);
            height += forword.Height + 15;


            var comment = CreateForwardControl(data.comment, false);
            flowLayoutPanel1.Controls.Add(comment);
            height += comment.Height + 15;



            flowLayoutPanel1.Height = height;
            xScrollBar1.Visible = flowLayoutPanel1.Height > limitPanel.Height;


            // 请求评论
            HttpCommentData(data.id);
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

        private Control CreateImageControl(ResourceSocialData data)
        {
            var info = data.content.Substring(1, data.content.Length - 2);

            var image = JsonConvert.DeserializeObject<SocialImageData>(info);

            int height = Convert.ToInt32((float)image.imageHeight / image.imageWidth * flowLayoutPanel1.Width);

            var ivImage = new PictureBox();
            ivImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ivImage.Size = new System.Drawing.Size(flowLayoutPanel1.Width, height);
            ivImage.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            ImageLoader.Instance.Load(image.oUrl).Into(ivImage);
            ivImage.MouseWheel += View_MouseWheel;
            return ivImage;
        }


        private Control CreateForwardControl(int count, bool forword)
        {
            var ivImage = new Label();
            if (forword)
            {
                ivImage.Image = Resources.ic_group_resource_share;
                ivImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                ivImage.Text = string.Format("     转发 {0}", count);
                ivImage.Cursor = System.Windows.Forms.Cursors.Hand;
                ivImage.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            }
            else
            {
                ivImage.Text = string.Format("全部回复 ({0})", count);
                ivImage.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            }

            ivImage.ForeColor = Color.FromArgb(51, 51, 51);
            ivImage.TextAlign = ContentAlignment.MiddleLeft;
            ivImage.Size = new System.Drawing.Size(350, 24);

            ivImage.MouseWheel += View_MouseWheel;

            ivImage.MouseClick += Forword_MouseClick;
            return ivImage;
        }

        private void Forword_MouseClick(object sender, MouseEventArgs e)
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


    }



    public class ResourceSocial
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string nickName { get; set; }
        public string title { get; set; }
        public long time { get; set; }
        public int forward { get; set; }
        public int comment { get; set; }
        public List<ResourceSocialData> contents { get; set; }
        // public List<SocialCommentData> comments { get; set; }
    }


    public class ResourceSocialData
    {
        /// <summary>
        /// 减肥一般是可以吃土豆，并不会影响到减肥效果，但是一定要注意合理饮食。
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }

    }


    public class SocialImageData
    {
        public string oUrl { get; set; }
        public int imageHeight { get; set; }
        public int imageWidth { get; set; }
    }


    public class SocialCommentData
    {
        public string userId { get; set; }
        public string nickname { get; set; }
        public string body { get; set; }
        public long time { get; set; }
    }
}
