using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 自动居中缩放图片控件
    /// xuan
    /// 2019-12-26 15:07:49
    /// </summary>
    public class ImageViewx : PictureBox
    {
        // 是否是将图片切成圆形
        private bool isRound = false;

        // 未读数量
        private int mUnread = 0;
        private int unread_size = 20;
        private int unread_margin = 0;

        public int UnreadSize
        {
            get { return unread_size; }
            set
            {
                unread_size = value;
                this.Refresh();
            }
        }

        public int UnreadCount
        {
            get { return mUnread; }
            set
            {
                mUnread = value;
                this.Refresh();
            }
        }

        public int UnreadMargin
        {
            get { return unread_margin; }
            set
            {
                unread_margin = value;
            }
        }



        // 是否把图片切成圆形
        public void ChangeImageRound(bool isRound)
        {
            this.isRound = isRound;
            this.Refresh();
        }

        private SolidBrush mRedPen;
        private SolidBrush mTextBrush;
        private Font mTextFont;

        public ImageViewx()
        {
            mRedPen = new SolidBrush(Color.Red);
            mTextBrush = new SolidBrush(Color.FromArgb(250, Color.White));
            mTextFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }


        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            Console.WriteLine("不支持使用背景颜色");
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (Image != null)
            {
                var graphics = pe.Graphics;

                if (isRound)
                {
                    // 图像切圆
                    Image round = CutEllipse(Image, this.Width, this.Height);


                    Rectangle destRect = new Rectangle(2, 2, this.Width - 1, this.Height - 1);
                    Rectangle srcRect = new Rectangle(0, 0, round.Width, round.Height);
                    // 绘制圆形头像
                    graphics.DrawImage(round, destRect, srcRect, GraphicsUnit.Pixel);
                }
                else
                {
                    // 居中缩放
                    RectangleF srcRect = CropCenterRect(Image, this.Width, this.Height);
                    // 绘制大小和位置
                    RectangleF descRect = new RectangleF(Padding.Left, Padding.Top, this.Width - (Padding.Left + Padding.Right), this.Height - (Padding.Top + Padding.Bottom));
                    // 绘制图片
                    graphics.DrawImage(Image, descRect, srcRect, GraphicsUnit.Pixel);
                }


                if (mUnread > 0)
                {
                    DrawRedNum(graphics);
                }
            }
        }


        /// <summary>
        /// a
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawRedNum(Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // 绘制红点
            graphics.FillEllipse(mRedPen, this.Width - unread_size - 1 - UnreadMargin, UnreadMargin, unread_size, unread_size);

            string mUnreadStr = mUnread < 100 ? mUnread.ToString() : "99+";
            // 绘制文字f
            float textx = mUnreadStr.Length * -3.5f + 7.8f;
            graphics.DrawString(mUnreadStr, mTextFont, mTextBrush, this.Width - unread_size + textx - UnreadMargin, 1.5f + UnreadMargin);
        }


        // 居中缩放
        private RectangleF CropCenterRect(Image image, float width, float height)
        {
            float img_width = image.Width;
            float img_height = image.Height;

            float new_width = 0;
            float new_height = 0;

            //获取合适的比例进行裁剪
            new_width = img_width;
            new_height = img_width / width * height;

            if (new_height > img_height)
            {
                new_width = img_height / new_height * new_width;
                new_height = img_height;
            }

            return new RectangleF((image.Width - new_width) / 2, (image.Height - new_height) / 2, new_width, new_height);
        }


        // 图片居中内切圆
        private Image CutEllipse(Image image, int width, int height)
        {
            int new_size = Math.Min(image.Width, image.Height);

            int centx = (image.Width - new_size) / 2;
            int centy = (image.Height - new_size) / 2;

            Bitmap bm = new Bitmap(new_size, new_size);

            using (Graphics g = Graphics.FromImage(bm))
            {
                GraphicsPath gpath = new GraphicsPath();

                gpath.AddEllipse(0, 0, new_size, new_size);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.HighQuality;

                g.SetClip(gpath);

                var srcRect = new Rectangle(centx, centy, new_size, new_size);
                var descRect = new Rectangle(0, 0, new_size, new_size);
                g.DrawImage(image, descRect, srcRect, GraphicsUnit.Pixel);
            }
            return bm;
        }
    }
}
