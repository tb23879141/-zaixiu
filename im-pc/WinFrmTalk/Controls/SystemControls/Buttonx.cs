using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFrmTalk.Controls.SystemControls
{
    /// <summary>
    /// 圆角按钮
    /// </summary>
    public class Buttonx : Control
    {
        private SolidBrush CurrentBrush = new SolidBrush(Color.FromArgb(225, 225, 225));
        private SolidBrush textBrush = new SolidBrush(Color.Black);
        private Pen framePen = new Pen(Color.FromArgb(200, 200, 200));
        private Color enterColor = Color.Empty;
        private Color leaveColor = Color.FromArgb(225, 225, 225);

        /// <summary>
        /// 鼠标进入的颜色
        /// </summary>
        public Color MouseEnterColor
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

        /// <summary>
        /// 鼠标离开的颜色
        /// </summary>
        public Color MouseLeaveColor
        {
            get
            {
                return leaveColor;
            }
            set
            {
                leaveColor = value;
                CurrentBrush.Color = leaveColor;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color FrameColor
        {
            get { return framePen.Color; }
            set
            {
                framePen.Color = value;
                this.Invalidate();
            }
        }

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


        public int Radius { get; set; } = 6;

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }

        public override Font Font { get { return base.Font; } set { base.Font = value; } }

        public Buttonx()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.MouseLeave += ImageViewx_MouseLeave;
            this.MouseEnter += ImageViewx_MouseEnter;
        }

      


        private void ImageViewx_MouseEnter(object sender, EventArgs e)
        {
            //base.OnMouseEnter(e);
            if (enterColor != null && !enterColor.IsEmpty)
            {
                CurrentBrush.Color = enterColor;
                this.Invalidate();
            }
        }

        private void ImageViewx_MouseLeave(object sender, EventArgs e)
        {
            //base.OnMouseEnter(e);
            if (leaveColor != null && !leaveColor.IsEmpty)
            {
                CurrentBrush.Color = leaveColor;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.AssumeLinear;



            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            var path = GraphicUtils.CreateRoundRectanglePath(Radius, rect);

            if (CurrentBrush != null && !CurrentBrush.Color.IsEmpty)
            {
                g.FillPath(CurrentBrush, path);
            }

            if (framePen != null && !framePen.Color.IsEmpty)
            {
                g.DrawPath(framePen, path);
            }

            if (!string.IsNullOrEmpty(Text) && textBrush != null)
            {
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                //rect.Y = 2;
                //rect.Width = this.Width;
                //rect.Height = this.Height;
                g.DrawString(Text, Font, textBrush, rect, format);
                //Console.WriteLine("IsNullOrEmpty: " + Text);
            }
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            GraphicUtils.Dispose(CurrentBrush);
            GraphicUtils.Dispose(textBrush);
            GraphicUtils.Dispose(framePen);

        }
    }
}
