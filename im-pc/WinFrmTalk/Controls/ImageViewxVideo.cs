using System;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 略缩图显示控件
    /// xuan
    /// 2019-12-26 15:07:49
    /// </summary>
    public class ImageViewxVideo : PictureBox
    {
        public int incosize = 42;

        // 等待符
        private PictureBox lodinview = null;
        // 当前状态
        private int state;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }



        public Image Image
        {
            get
            {
                return base.Image;
            }
            set
            {

                base.Image = value;
                state = 0;
            }
        }

        /// <summary>
        /// true == 平铺裁切模式
        /// false == 图像将会原比例显示在控件上,控件可能会有留白
        /// 图像会铺满整个控件,图片多余的部分将会被舍弃
        /// </summary>
        public bool StretchMode { get; internal set; }
        public int BorderSize { get; internal set; } = 0;

        public void Error()
        {
            state = -1;
            this.Image = Resources.ic_black_rect;

            this.Refresh();
        }

        public void Loding()
        {
            state = 1;

            if (lodinview == null)
            {
                lodinview = new PictureBox();
                lodinview.Parent = this;
                lodinview.Size = new Size(incosize, incosize);

                lodinview.Location = new Point((Width - incosize) / 2, (Height - incosize) / 2);
                string path = Applicate.AppCurrentDirectory + "Resource\\load.gif";
                lodinview.Image = new Bitmap(path);
                lodinview.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            this.Refresh();
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            // Console.WriteLine("不支持使用背景颜色");
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            var graphics = pe.Graphics;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (Image != null && state != 1)
            {
                if (BorderSize > 0)
                {
                    // 平铺 缩放比例
                    int maxWidth = Width - (BorderSize * 2);
                    RectangleF destRect1 = new RectangleF(BorderSize, 0, maxWidth, Height);

                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(51, 51, 51)))
                    {
                        graphics.FillRectangle(brush, destRect1);
                    }

                    float newWidth = (float)Height / Image.Height * Image.Width;
                    if (newWidth < maxWidth)
                    {
                        RectangleF srcRect = new RectangleF(0, 0, Image.Width, Image.Height);
                        RectangleF destRect = new RectangleF((maxWidth - newWidth) / 2 + BorderSize, 0, newWidth, Height);
                        // 绘制视频缩略图片
                        graphics.DrawImage(Image, destRect, srcRect, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        RectangleF srcRect = new RectangleF(0, 0, Image.Width, Image.Height);
                        // 绘制视频缩略图片
                        graphics.DrawImage(Image, destRect1, srcRect, GraphicsUnit.Pixel);
                    }
                }
                else
                {
                    if (!StretchMode)
                    {
                        // 居中平铺
                        RectangleF dest = new RectangleF(0, 0, this.Width, this.Height);
                        RectangleF src = SrcCenterRect(Image, this.Width, this.Height);
                        // 绘制视频缩略图片
                        graphics.DrawImage(Image, dest, src, GraphicsUnit.Pixel);

                    }
                    else
                    {
                        // 居中缩放
                        RectangleF dest = CropCenterRect(Image, this.Width, this.Height);
                        RectangleF src = new RectangleF(0, 0, Image.Width, Image.Height);
                        // 绘制视频缩略图片
                        graphics.DrawImage(Image, dest, src, GraphicsUnit.Pixel);
                    }
                }
            }

            // 绘制播放按钮
            DrawPlayIcon(graphics);
        }

        private void DrawPlayIcon(Graphics graphics)
        {
            if (state == 0)
            {
                if (lodinview != null)
                {
                    lodinview.Dispose();
                    lodinview = null;
                }

                incosize = this.Width > 500 ? 55 : 20;

                Image image = Resources.jc_play_normal;

                Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);
                Rectangle centrect = new Rectangle((Width - incosize) / 2, (Height - incosize) / 2, incosize, incosize);

                graphics.DrawImage(image, centrect, rectangle, GraphicsUnit.Pixel);
            }
            else if (state == -1)
            {
                if (lodinview != null)
                {
                    lodinview.Dispose();
                    lodinview = null;
                }

                //Image image = Resources.jc_play_error;

                //Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);
                //Rectangle centrect = new Rectangle((Width - incosize) / 2, (Height - incosize) / 2, incosize, incosize);

                //graphics.DrawImage(image, centrect, rectangle, GraphicsUnit.Pixel);
            }
        }



        // 居中缩放
        private RectangleF CropCenterRect(Image image, float width, float height)
        {
            //得到图片斜率
            float image_scale = (float)image.Width / image.Height;
            //得到容器斜率
            float dest_scale = width / height;

            float new_width = 0, new_height = 0;


            if (Math.Abs(image_scale - dest_scale) < 0.01)
            {
                // 斜率相同，直接缩放就行
                new_width = width;
                new_height = height;
            }
            else
            {
                new_width = height / image.Height * image.Width;
                if (new_width <= width)
                {
                    new_height = height;
                }
                else
                {
                    new_height = width / image.Width * image.Height;
                    new_width = width;
                }
            }

            RectangleF destRect = new RectangleF((width - new_width) / 2, (height - new_height) / 2, new_width, new_height);
            return destRect;
        }


        // 居中缩放
        private RectangleF SrcCenterRect(Image image, float width, float height)
        {
            //得到图片斜率
            float image_scale = (float)image.Width / image.Height;
            //得到容器斜率
            float dest_scale = width / height;

            float new_width = image.Width;
            float new_height = image.Height;


            if (Math.Abs(image_scale - dest_scale) < 0.01)
            {
                // 斜率相同，直接缩放就行
                new_width = width;
                new_height = height;
            }
            else
            {
                // 新的矩形框
                new_width = image.Height / height * width;
                new_height = image.Height;
                if (new_width > image.Width || new_height > image.Height)
                {
                    // 以宽度计算
                    new_height = image.Width / width * height;
                    new_width = image.Width;
                }
            }

            RectangleF destRect = new RectangleF((image.Width - new_width) / 2, (image.Height - new_height) / 2, new_width, new_height);
            return destRect;
        }
        private RectangleF SrcCenterRect1(Image image, float width, float height)
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
    }
}
