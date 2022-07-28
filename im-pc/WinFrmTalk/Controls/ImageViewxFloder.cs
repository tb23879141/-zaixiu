using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls
{
    public class ImageViewxFloder : Control
    {

        private Image _image;
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                this.Invalidate();
            }
        }

        private Image frontImage;

        public ImageViewxFloder()
        {
            frontImage = Resources.ic_group_floder;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            // 71*167
            // 97*140


            float scale = (this.Height - 1) / 167f;

            var graphics = pe.Graphics;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // 绘制背板
            float width = 100 * scale;
            float height = 140 * scale;
            float top = 40 * scale;
            using (Brush brush = new SolidBrush(Color.FromArgb(253, 224, 126)))
            {
                graphics.FillRectangle(brush, new RectangleF(0, 0, width, height));
            }

            // 绘制图像
            if (Image != null)
            {
                width = this.Width * 0.9f;
                height = height - top;

                RectangleF srcRect1 = CropCenterRect(Image, width, height);
                RectangleF destRect1 = new RectangleF(5, top, width, height);
                graphics.DrawImage(Image, destRect1, srcRect1, GraphicsUnit.Pixel);
            }

            // 绘制盖板
            width = 71 * scale;
            height = 167 * scale;
            var srcRect = new RectangleF(0, 0, frontImage.Width, frontImage.Height);
            var destRect = new RectangleF(0, 0, width, height);
            graphics.DrawImage(frontImage, destRect, srcRect, GraphicsUnit.Pixel);
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



    }

}
