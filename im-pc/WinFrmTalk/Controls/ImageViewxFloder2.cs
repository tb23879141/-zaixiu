using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 文件夹样式2
    /// </summary>
    public class ImageViewxFloder2 : Control
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

        /// <summary>
        /// 文件夹类型
        /// 0 == 1级目录
        /// 1 == 2级目录
        /// 2 == 相册
        /// </summary>
        private int _type;
        public int FolderType
        {
            get { return _type; }
            set
            {
                _type = value;
                this.Invalidate();
            }
        }

        public ImageViewxFloder2()
        {
            this.Size = new Size(100, 86);
        }



        protected override void OnPaint(PaintEventArgs pe)
        {
            var graphics = pe.Graphics;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (FolderType == 0)
            {
                // 一级文件夹
                Image frontImage = Resources.ic_group_floder2;
                var srcRect = new RectangleF(0, 0, frontImage.Width, frontImage.Height);
                var destRect = new RectangleF(0, 0, this.Width, this.Height);
                graphics.DrawImage(frontImage, destRect, srcRect, GraphicsUnit.Pixel);
            }
            else if (FolderType == 1)
            {
                // 二级文件夹
                Image frontImage = Resources.ic_group_floder5;
                var srcRect = new RectangleF(0, 0, frontImage.Width, frontImage.Height);
                var destRect = new RectangleF(0, 0, this.Width, this.Height);
                graphics.DrawImage(frontImage, destRect, srcRect, GraphicsUnit.Pixel);
            }
            else
            {

                // 二级文件夹

                // 背板
                var backImage = Resources.ic_group_floder4;
                var srcRect = new RectangleF(0, 0, backImage.Width, backImage.Height);
                graphics.DrawImage(backImage, 0, 0, srcRect, GraphicsUnit.Pixel);


                // 中间层
                // 绘制图像
                var width = this.Width - 11;
                var height = this.Height - 12;
                if (Image != null)
                {
                    RectangleF srcRect1 = CropCenterRect(Image, width - 2, height - 3);
                    RectangleF descRect1 = new RectangleF(1, 12, width - 1, height - 6);
                    graphics.DrawImage(Image, descRect1, srcRect1, GraphicsUnit.Pixel);
                }

                width = this.Width;
                height = this.Height - 35;
                // 前景图
                var frontImage = Resources.ic_group_floder3;
                srcRect = new RectangleF(0, 0, frontImage.Width, frontImage.Height);
                graphics.DrawImage(frontImage, 0, this.Height - frontImage.Height, srcRect, GraphicsUnit.Pixel);

            }
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
