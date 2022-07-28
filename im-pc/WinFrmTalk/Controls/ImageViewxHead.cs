using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 圆形头像控件+未读红点数量
    /// xuan
    /// 2019-12-26 15:07:49
    /// </summary>
    /// 
    public class ImageViewxHead : PictureBox
    {
        private const int RED_SIZE = 21;

        private int _num = 10;

        // 是否自动切圆
        public bool isRound = true;

        public int Red_Num
        {
            get
            {
                return _num;
            }
            set
            {
                _num = value;
                this.Refresh();
            }
        }


        private SolidBrush mRedPen;
        private SolidBrush mTextBrush;
        private Font mTextFont;


        public ImageViewxHead()
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

                int offset = 0;//GetRedOffset();

                // 居中缩放
                RectangleF srcRect = CropCenterRect(Image, this.Width - offset, this.Height - offset);

                if (isRound)
                {
                    // 图像切圆
                    Image imageModel = CutEllipse(Image, srcRect, this.Width - offset, this.Height - offset);
                    // 绘制图片
                    graphics.DrawImage(imageModel, 0, offset);
                }
                else
                {
                    var descRect = new RectangleF(0, 0, this.Width, this.Height);
                    graphics.DrawImage(Image, descRect, srcRect, GraphicsUnit.Pixel);
                }
                // 绘制红点
                DrawRedNum(graphics);
            }
        }


        private void DrawRedNum(Graphics graphics)
        {
            if (Red_Num > 0)
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                // 绘制红点
                graphics.FillEllipse(mRedPen, this.Width - RED_SIZE - 1, 0, RED_SIZE, RED_SIZE);

                // 绘制文字f
                float textx = Red_Num.ToString().Length * -3.5f + 7.8f;
                graphics.DrawString(Red_Num.ToString(), mTextFont, mTextBrush, this.Width - RED_SIZE + textx, 2.5f);
            }
        }

        // 图片切圆
        private Image CutEllipse(Image img, RectangleF rec, int width, int height)
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (TextureBrush br = new TextureBrush(img, System.Drawing.Drawing2D.WrapMode.Clamp, rec))
                {
                    br.ScaleTransform(bitmap.Width / (float)rec.Width, bitmap.Height / (float)rec.Height);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillEllipse(br, new Rectangle(0, 0, width - 1, height - 1));
                }
            }
            return bitmap;
        }

        // 居中缩放
        public RectangleF CropCenterRect(Image image, float width, float height)
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
