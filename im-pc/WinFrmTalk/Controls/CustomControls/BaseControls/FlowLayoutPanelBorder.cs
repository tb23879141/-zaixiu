using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.Controls
{
    public class FlowLayoutPanelBorder: FlowLayoutPanel
    {
        private Color _lineColor;
        private int _lineThick;
        private float[] _DashPattern;
        private DashStyle _DashStyle;

        public FlowLayoutPanelBorder()
        {
            _lineColor = Color.FromArgb(230, 230, 230);
            _lineThick = 1;
            _DashStyle = DashStyle.Solid;
        }

        [Browsable(true)]
        public Color LineColor
        {
            get
            {
                return _lineColor;
            }
            set
            {
                _lineColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        public int LineThick
        {
            get
            {
                return _lineThick;
            }
            set
            {
                _lineThick = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        public int LinePenMode
        {
            get
            {
                return _lineThick;
            }
            set
            {
                _lineThick = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        public float[] LineDashPattern
        {
            get
            {
                return _DashPattern;
            }
            set
            {
                _DashPattern = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        public DashStyle LineDashStyle
        {
            get
            {
                return _DashStyle;
            }
            set
            {
                _DashStyle = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen p = new Pen(LineColor, LineThick);
            p.DashStyle = LineDashStyle;
            if ((p.DashStyle == DashStyle.DashDot) || (p.DashStyle == DashStyle.DashDotDot))
                p.DashPattern = LineDashPattern;

            Point left_top = new Point(0, 0);
            Point left_bottom = new Point(0, this.Height - _lineThick);
            Point right_top = new Point(this.Width - 1, 0);
            Point right_bottom = new Point(this.Width - 1, this.Height - _lineThick);

            e.Graphics.DrawLine(p, left_bottom.X, left_bottom.Y, right_bottom.X, right_bottom.Y);   //bottom
            e.Graphics.DrawLine(p, left_top.X, left_top.Y, left_bottom.X, left_bottom.Y);           //left
            e.Graphics.DrawLine(p, left_top.X, left_top.Y, right_top.X, right_top.Y);               //top
            e.Graphics.DrawLine(p, right_top.X, right_top.Y, right_bottom.X, right_bottom.Y);       //right
        }
    }
}
