using RichTextBoxLinks;
using System;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    public partial class GroupPageNotify : UserControl
    {
        public GroupPageNotify()
        {
            InitializeComponent();
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        public void SetControlData(Information information, bool topMargin)
        {
            bool existText = !UIUtils.IsNull(information.text);
            bool existImage = !UIUtils.IsNull(information.picPath);

            int imageWidth = 200;

            int height = 0;

            if (!UIUtils.IsNull(information.title))
            {
                var title = CreateTitleControl(information.title);
                var line = CreateLineControl();
                height += title.Height + title.Margin.Top;

                title.MouseClick += Item_MouseClick;
                title.MouseDown += Item_MouseDown;

                flowLayoutPanel1.Controls.Add(title);
                flowLayoutPanel1.Controls.Add(line);
            }

            int lineWidth = 0;

            if (existText)
            {
                int maxWidth = existImage ? flowLayoutPanel1.Width - (imageWidth + 40) : flowLayoutPanel1.Width - 20;

                var text = CreateContentControl(information.text);

                text.Size = new System.Drawing.Size(maxWidth, 400);
                int lineNumber = text.GetLineFromCharIndex(text.TextLength) + 1;

                // 真实的高度
                var textHeight = lineNumber * 30;
                if (!topMargin && textHeight < 400)
                {
                    // 上下居中
                    var top = (limitPanel.Height - height - textHeight) / 2 + 20;
                    text.Margin = new Padding(0, top, 0, 0);
                }
                else
                {
                    text.Margin = new Padding(0, 20, 0, 0);
                }
                lineWidth = text.Height + text.Margin.Top;

                text.MouseClick += Item_MouseClick;
                text.MouseDown += Item_MouseDown;

                height += text.Height + text.Margin.Top;
                flowLayoutPanel1.Controls.Add(text);
            }


            if (existImage)
            {
                string url = information.picPath[0];
                var image = CreateImageControl(url, existText, imageWidth);

                image.MouseClick += Item_MouseClick;
                image.MouseDown += Item_MouseDown;

                flowLayoutPanel1.Controls.Add(image);

                height += Math.Max(lineWidth, image.Height + image.Margin.Top);
            }

            flowLayoutPanel1.Height = height;
            xScrollBar1.Visible = !topMargin && flowLayoutPanel1.Height > limitPanel.Height;
        }


        private Control CreateTitleControl(string title)
        {
            var tvTitle = new Label();
            tvTitle.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            tvTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            tvTitle.Margin = new Padding(0, 20, 0, 0);
            tvTitle.Name = "tvTitle";
            tvTitle.Size = new System.Drawing.Size(flowLayoutPanel1.Width, 30);
            tvTitle.Text = title;
            return tvTitle;
        }

        private Control CreateLineControl()
        {
            var item = new Label();
            item.BackColor = System.Drawing.Color.FromArgb(214, 214, 214);
            item.Margin = new Padding(0, 20, 0, 0);
            item.Name = "line";
            item.Size = new System.Drawing.Size(flowLayoutPanel1.Width, 1);
            return item;
        }

        private RichTextBox CreateContentControl(string text)
        {
            var item = new RichTextBoxEx();
            item.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            item.BackColor = this.BackColor;
            item.DetectUrls = false;
            item.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            item.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            item.BorderStyle = System.Windows.Forms.BorderStyle.None;
            item.Margin = new Padding(0, 20, 0, 0);
            item.Name = "content";
            item.Text = text;

            item.ContextMenuStrip = this.ContextMenuStrip;

            item.SetReadMode();
            CSetLineSpace.SetLineSpace(item, 30);
            return item;
        }


        private Control CreateImageControl(string url, bool existText, int imageWidth)
        {
            var item = new PictureBox();
            item.BackColor = System.Drawing.Color.Transparent;
            item.Margin = new Padding(existText ? 20 : 0, 20, 0, 0);
            item.Name = "image";
            item.Size = new System.Drawing.Size(existText ? imageWidth : flowLayoutPanel1.Width, 400);

            item.SizeMode = PictureBoxSizeMode.Zoom;
            ImageLoader.Instance.DisplayImage(url, item);

            return item;
        }

        private void limitPanel_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Width = limitPanel.Width;
        }
    }
}
