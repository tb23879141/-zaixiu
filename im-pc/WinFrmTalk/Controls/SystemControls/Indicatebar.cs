using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFrmTalk.Controls.SystemControls
{

    /// <summary>
    /// 指示器控件
    /// </summary>
    public partial class Indicatebar : Control
    {

        /// <summary>
        /// 圆角大小
        /// </summary>
        public const int RoundSize = 120;

        /// <summary>
        /// 圆角个数
        /// </summary>
        public const int RoundCount = 89;

        public Indicatebar()
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; //使绘图质量最高，即消除锯齿
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;


            OnDraw(g);
        }

        protected void OnDraw(Graphics graphics)
        {


            //var client = new Rectangle(0, 0, this.Width, this.Height);

            //// 创建路径
            //GraphicsPath path = CreateRoundRectanglePath(12, this.Width, this.Height);


            //Region region = new Region(client);
            //region.Xor(path);

            //graphics.FillRegion(Brushes.White, region);
        }

    }
}
