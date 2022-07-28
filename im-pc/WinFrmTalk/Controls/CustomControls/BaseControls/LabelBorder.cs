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
    public class EQBorder : Component
    {
        public EQBorder()
        {
            _lineColor = Color.FromArgb(230, 230, 230);
            _lineThick = 1;
            _DashStyle = DashStyle.Solid;
        }

        private Color _lineColor;
        private int _lineThick;
        private float[] _DashPattern;
        private DashStyle _DashStyle;


        [Category("边框线条颜色"), Browsable(true)]
        public Color LineColor
        {
            get
            {
                return _lineColor;
            }
            set
            {
                _lineColor = value;
                //Invalidate();
            }
        }

        [Category("边框线条宽度"), Browsable(true)]
        public int LineThick
        {
            get
            {
                return _lineThick;
            }
            set
            {
                _lineThick = value;
                //Invalidate();
            }
        }

        [Category("虚线间隔"), Browsable(true)]
        public float[] LineDashPattern
        {
            get
            {
                return _DashPattern;
            }
            set
            {
                _DashPattern = value;
                //Invalidate();
            }
        }

        [Category("线条的类型"), Browsable(true)]
        public DashStyle LineDashStyle
        {
            get
            {
                return _DashStyle;
            }
            set
            {
                _DashStyle = value;
                //Invalidate();
            }
        }

        public bool IsShowLeft { get; set; }

        public bool IsShowTop { get; set; }

        public bool IsShowRight { get; set; }

        public bool IsShowBottom { get; set; }

    }

    public class LabelBorder : Label
    {
        EQBorder _border = new EQBorder();
        [TypeConverter(typeof(System.ComponentModel.CollectionConverter))]//指定编辑器特性
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]//设定序列化特性
        [Category("自定义边框"), Description("边框属性集")]
        public EQBorder Border
        {
            get => _border;
        }

        public LabelBorder()
        {            
            this.Font = new Font("微软雅黑", 9F);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen p = new Pen(Border.LineColor, Border.LineThick);
            p.DashStyle = Border.LineDashStyle;
            if ((p.DashStyle == DashStyle.DashDot) || (p.DashStyle == DashStyle.DashDotDot))
                p.DashPattern = Border.LineDashPattern;

            Point left_top = new Point(0, 0);
            Point left_bottom = new Point(0, this.Height - Border.LineThick);
            Point right_top = new Point(this.Width - Border.LineThick, 0);
            Point right_bottom = new Point(this.Width - Border.LineThick, this.Height - Border.LineThick);

            if (Border.IsShowBottom)
                e.Graphics.DrawLine(p, left_bottom.X, left_bottom.Y, right_bottom.X, right_bottom.Y);   //bottom
            if (Border.IsShowLeft)
                e.Graphics.DrawLine(p, left_top.X, left_top.Y, left_bottom.X, left_bottom.Y);           //left
            if (Border.IsShowTop)
                e.Graphics.DrawLine(p, left_top.X, left_top.Y, right_top.X, right_top.Y);               //top
            if (Border.IsShowRight)
                e.Graphics.DrawLine(p, right_top.X, right_top.Y, right_bottom.X, right_bottom.Y);       //right
        }
    }
}
