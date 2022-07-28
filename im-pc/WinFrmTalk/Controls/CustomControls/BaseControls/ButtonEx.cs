using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BaseControls
{
    public class ButtonEx : Control
    {
        private StringFormat format = new StringFormat();
        private SolidBrush textBrush; // 文字笔刷
        private Pen framePen; // 边框笔刷
        private SolidBrush fillBrush; // 填充笔刷

        private Color leaveColor; // 离开的颜色
        private Color enterColor; // 进入的颜色

        /// <summary>
        /// 文字颜色
        /// </summary>
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                textBrush.Color = value;
                this.Invalidate();
            }
        }


        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        [Description("边框颜色")]
        public Color FrameColor
        {
            get
            {
                return framePen.Color;
            }
            set
            {
                framePen.Color = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 填充颜色
        /// </summary>
        [Description("填充颜色")]
        public Color FillColor
        {
            get
            {
                return fillBrush.Color;
            }
            set
            {
                leaveColor = value;
                fillBrush.Color = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 鼠标进入的颜色
        /// </summary>
        [Description("鼠标进入的颜色")]
        public Color EnterColor
        {
            get
            {
                return enterColor;
            }
            set
            {
                enterColor = value;
            }
        }

        [Description("控件圆角半径")]
        public int Raduis { get; set; } = 6;


        public ButtonEx()
        {
            framePen = new Pen(Color.Gray);
            textBrush = new SolidBrush(Color.Black);
            fillBrush = new SolidBrush(Color.Gainsboro);
            leaveColor = Color.Gainsboro;
            enterColor = Color.Empty;

            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (enterColor != leaveColor)
            {
                if (!enterColor.IsEmpty)
                {
                    fillBrush.Color = enterColor;
                    this.Invalidate();
                }
            }

        }


        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (enterColor != leaveColor)
            {
                fillBrush.Color = leaveColor;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs paint)
        {
            var g = paint.Graphics;

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            if (!fillBrush.Color.IsEmpty)
            {
                // 创建路径
                GraphicsPath path = CreateRoundRectanglePath(Raduis, this.Width - 1, this.Height - 1);
                // 绘制背景
                g.FillPath(fillBrush, path);

                if (!framePen.Color.IsEmpty)
                {
                    // 绘制边框
                    g.DrawPath(framePen, path);
                }

                // 销毁路径
                path.Dispose();
            }


            // 绘制文字
            if (!string.IsNullOrEmpty(this.Text))
            {
                RectangleF rectangle = new RectangleF(0, 0, this.Width - 1, this.Height);
                g.DrawString(Text, this.Font, this.textBrush, rectangle, format);
            }
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
                result.AddArc(rectangle.X + rectangle.Width - radius, rectangle.Y + rectangle.Height - radius, radius, radius, 0, 90);
            }
            else
            {
                result.AddLine(new System.Drawing.Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), new System.Drawing.Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height));
            }
            if (radius > 0)
            {
                result.AddArc(rectangle.X, rectangle.Y + rectangle.Height - radius, radius, radius, 90, 90);
            }
            else
            {
                result.AddLine(new System.Drawing.Point(rectangle.X, rectangle.Y + rectangle.Height), new System.Drawing.Point(rectangle.X, rectangle.Y + rectangle.Height));
            }

            result.CloseFigure();
            return result;
        }



        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            UIUtils.DisposeGdi(textBrush);
            UIUtils.DisposeGdi(framePen);
            UIUtils.DisposeGdi(fillBrush);

        }
    }
}
