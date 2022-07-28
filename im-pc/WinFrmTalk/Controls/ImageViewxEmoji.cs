using System;
using System.ComponentModel;
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
    public class ImageViewxEmoji : Control
    {
        //
        // 摘要:
        //     获取或设置所显示的图像 System.Windows.Forms.PictureBox。
        //
        // 返回结果:
        //     System.Drawing.Image 来显示。
        [Browsable(true)]
        public Image Image { get; set; }

        [Browsable(false)]
        public EmojiCollect Collect { get; set; }

        [Browsable(false)]
        public WinFrmTalk.View.ExpressionType EmojiType { get; set; }

        [Browsable(false)]
        public string CollectEmojiId
        {
            get
            {
                if (Collect != null)
                {
                    return Collect.emojiId;
                }
                return "";
            }
        }

        public ImageViewxEmoji()
        {
            this.MouseEnter += ImageViewxEmoji_MouseEnter;
            this.MouseLeave += ImageViewxEmoji_MouseLeave;
        }

        private void ImageViewxEmoji_MouseLeave(object sender, EventArgs e)
        {
            if (Image != null)
            {
                this.BackColor = Color.White;
            }

        }

        private void ImageViewxEmoji_MouseEnter(object sender, EventArgs e)
        {
            if (Image != null)
            {
                this.BackColor = Color.FromArgb(243, 243, 243);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (Image != null)
            {
                // 居中缩放
                RectangleF srcRect = CropCenterRect(Image, this.Width, this.Height);
                // 绘制大小和位置
                RectangleF descRect = new RectangleF(Padding.Left, Padding.Top, this.Width - (Padding.Left + Padding.Right), this.Height - (Padding.Top + Padding.Bottom));
                // 绘制图片
                pe.Graphics.DrawImage(Image, descRect, srcRect, GraphicsUnit.Pixel);
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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (Image != null)
            {
                Image.Dispose();
                Image = null;
            }

        }

        internal void ClearImage()
        {
            throw new NotImplementedException();
        }
    }
}
