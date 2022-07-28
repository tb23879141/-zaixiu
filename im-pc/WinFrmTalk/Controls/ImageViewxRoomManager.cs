using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 群成员头像控件
    /// xuan
    /// 2019-12-26 15:07:49
    /// </summary>
    public class ImageViewxRoomManager : PictureBox
    {

        // 群成员身份
        private int mRole = 0;

        public void ChangeMemberRole(int role)
        {
            mRole = role;
            this.Refresh();
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

                graphics.SmoothingMode = SmoothingMode.HighQuality;  //图片柔顺模式选择
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;//高质量
                graphics.CompositingQuality = CompositingQuality.HighQuality;//再加一点

                // 图像居中切圆
                Image round = CutEllipse(Image, this.Width, this.Height);

                Rectangle destRect = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
                Rectangle srcRect = new Rectangle(0, 0, round.Width, round.Height);


                // 绘制圆形头像
                graphics.DrawImage(round, destRect, srcRect, GraphicsUnit.Pixel);


                // 绘制群管理边框
                DrawGroupBorder(graphics);

            }
        }

        private void DrawGroupBorder(Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;  //图片柔顺模式选择
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;//高质量
            graphics.CompositingQuality = CompositingQuality.HighQuality;//再加一点

            if (mRole == 1)
            {
                // 群主
                var image = Resources.ic_roommem_border1;
                Rectangle destRect = new Rectangle(0, 0, this.Width, this.Height);
                Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);

                // 绘制群管理
                graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
            }
            else if (mRole == 2)
            {
                // 群管理
                var image = Resources.ic_roommem_border2;

                Rectangle destRect = new Rectangle(0, 0, this.Width, this.Height);
                Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);

                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                // 绘制群管理
                graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
            }
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

                g.SmoothingMode = SmoothingMode.HighQuality;  //图片柔顺模式选择
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;//高质量
                g.CompositingQuality = CompositingQuality.HighQuality;//再加一点

                GraphicsPath gpath = new GraphicsPath();


                gpath.AddEllipse(0, 0, new_size, new_size);
                g.SetClip(gpath);
                var srcRect = new Rectangle(centx, centy, new_size, new_size);
                var descRect = new Rectangle(0, 0, new_size, new_size);

                g.DrawImage(image, descRect, srcRect, GraphicsUnit.Pixel);

            }
            return bm;
        }
    }
}
