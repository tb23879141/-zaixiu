using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class LiveRoundPanel : Panel
    {
        private Color _borderColor = Color.FromArgb(23, 169, 254);
        private int _radius = 10;
        private RoundStyle _roundeStyle;
        private const int WM_PAINT = 0xF;

        public LiveRoundPanel() : base()
        {
        }

        /// <summary>
        /// 建立圆角路径的样式。
        /// </summary>
        public enum RoundStyle
        {
            /// <summary>
            /// 四个角都不是圆角。
            /// </summary>
            None = 0,
            /// <summary>
            /// 四个角都为圆角。
            /// </summary>
            All = 1,
            /// <summary>
            /// 左边两个角为圆角。
            /// </summary>
            Left = 2,
            /// <summary>
            /// 右边两个角为圆角。
            /// </summary>
            Right = 3,
            /// <summary>
            /// 上边两个角为圆角。
            /// </summary>
            Top = 4,
            /// <summary>
            /// 下边两个角为圆角。
            /// </summary>
            Bottom = 5,
        }
        /// <summary>
        /// 建立带有圆角样式的路径。
        /// </summary>
        /// <param name="rect">用来建立路径的矩形。</param>
        /// <param name="_radius">圆角的大小。</param>
        /// <param name="style">圆角的样式。</param>
        /// <param name="correction">是否把矩形长宽减 1,以便画出边框。</param>
        /// <returns>建立的路径。</returns>
        GraphicsPath CreatePath(Rectangle rect, int radius, RoundStyle style, bool correction)
        {
            GraphicsPath path = new GraphicsPath();
            int radiusCorrection = correction ? 1 : 0;
            switch (style)
            {
                case RoundStyle.None:
                    path.AddRectangle(rect);
                    break;
                case RoundStyle.All:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Right - radius - radiusCorrection, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Right - radius - radiusCorrection, rect.Bottom - radius - radiusCorrection, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius - radiusCorrection, radius, radius, 90, 90);
                    break;
                case RoundStyle.Left:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddLine(rect.Right - radiusCorrection, rect.Y, rect.Right - radiusCorrection, rect.Bottom - radiusCorrection);
                    path.AddArc(rect.X, rect.Bottom - radius - radiusCorrection, radius, radius, 90, 90);
                    break;
                case RoundStyle.Right:
                    path.AddArc(rect.Right - radius - radiusCorrection, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Right - radius - radiusCorrection, rect.Bottom - radius - radiusCorrection, radius, radius, 0, 90);
                    path.AddLine(rect.X, rect.Bottom - radiusCorrection, rect.X, rect.Y);
                    break;
                case RoundStyle.Top:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Right - radius - radiusCorrection, rect.Y, radius, radius, 270, 90);
                    path.AddLine(rect.Right - radiusCorrection, rect.Bottom - radiusCorrection, rect.X, rect.Bottom - radiusCorrection);
                    break;
                case RoundStyle.Bottom:
                    path.AddArc(rect.Right - radius - radiusCorrection, rect.Bottom - radius - radiusCorrection, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius - radiusCorrection, radius, radius, 90, 90);
                    path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
                    break;
            }
            path.CloseFigure(); //这句很关键，缺少会没有左边线。
            return path;
        }

        [DefaultValue(typeof(Color), "23, 169, 254"), Description("控件边框颜色")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(int), "10"), Description("圆角弧度大小")]
        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                base.Invalidate();
            }
        }
        public RoundStyle RoundeStyle
        {
            get { return _roundeStyle; }
            set
            {
                _roundeStyle = value;
                base.Invalidate();
            }
        }
        protected override void WndProc(ref Message m)
        {
            try
            {
                base.WndProc(ref m);
                if (m.Msg == WM_PAINT)
                {
                    if (this.Radius > 0)
                    {
                        using (Graphics g = Graphics.FromHwnd(this.Handle))
                        {
                            Rectangle r = new Rectangle();
                            r.Width = this.Width;
                            r.Height = this.Height;
                            DrawBorder(g, r, this.RoundeStyle, this.Radius);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DrawBorder(Graphics g, Rectangle rect, RoundStyle roundStyle, int radius)
        {
            rect.Width -= 1;
            rect.Height -= 1;
            using (GraphicsPath path = CreatePath(rect, radius, roundStyle, false))
            {
                using (Pen pen = new Pen(this.BorderColor))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

    }
}
