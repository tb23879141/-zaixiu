using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.Controls.SystemControls
{
    public class RoundPanelEx : Panel
    {

        // 边框笔刷
        private Pen framePen;
        // 填充笔刷
        private SolidBrush fillBrush;

        private BorderRadius _radius;
        [Description("控件圆角半径")]
        [Browsable(false)]
        public BorderRadius Radius { get { return _radius; } set { _radius = value; this.Invalidate(); } }

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
                fillBrush.Color = value;
                this.Invalidate();
            }
        }



        public RoundPanelEx()
        {
            framePen = new Pen(Color.Gray);
            fillBrush = new SolidBrush(Color.Gainsboro);
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
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                var path = GraphicUtils.CreateRoundRectanglePath(Radius, rect);
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

            UIUtils.DisposeGdi(framePen);
            UIUtils.DisposeGdi(fillBrush);
        }
    }
}