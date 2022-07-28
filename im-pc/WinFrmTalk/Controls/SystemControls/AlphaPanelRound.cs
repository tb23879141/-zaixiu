using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFrmTalk.Controls.SystemControls
{
    internal class AlphaPanelRound : Panel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // 实现透明样式

                return cp;
            }
        }

        public AlphaPanelRound()
        {
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.Transparent;
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
            if (this.ForeColor != Color.Transparent)
            {
                graphics.Clear(this.ForeColor);
            }
            else if (this.BackColor != Color.Transparent)
            {
                graphics.Clear(this.BackColor);
            }


            var client = new Rectangle(0, 0, this.Width, this.Height);

            // 创建路径
            GraphicsPath path = CreateRoundRectanglePath(12, this.Width, this.Height);


            Region region = new Region(client);
            region.Xor(path);

            graphics.FillRegion(Brushes.White, region);
        }


        public GraphicsPath CreateRoundRectanglePath(int radius, int width, int hegiht)
        {
            // 创建路径
            GraphicsPath result = new GraphicsPath();

            // 矩形区域
            Rectangle rectangle = new Rectangle(0, 0, width, hegiht);
            if (radius > 0)
            {
                result.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90);
            }
            else
            {
                result.AddLine(new System.Drawing.Point(rectangle.X, rectangle.Y), new System.Drawing.Point(rectangle.X, rectangle.Y));
            }


            if (radius > 0)
            {
                result.AddArc(rectangle.X + rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            }
            else
            {
                result.AddLine(new System.Drawing.Point(rectangle.X + rectangle.Width, rectangle.Y), new System.Drawing.Point(rectangle.X + rectangle.Width, rectangle.Y));
            }


            if (radius > 0)
            {
                result.AddArc(rectangle.X + rectangle.Width - radius - 1, rectangle.Y + rectangle.Height - radius - 1, radius, radius, 0, 90);
            }
            else
            {
                result.AddLine(new System.Drawing.Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), new System.Drawing.Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height));
            }


            if (radius > 0)
            {
                result.AddArc(rectangle.X, rectangle.Y + rectangle.Height - radius, radius + 1, radius, 90, 90);
            }
            else
            {
                result.AddLine(new System.Drawing.Point(rectangle.X, rectangle.Y + rectangle.Height), new System.Drawing.Point(rectangle.X, rectangle.Y + rectangle.Height));
            }

            result.CloseFigure();
            return result;
        }

    }
}
