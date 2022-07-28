using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFrmTalk.Controls.SystemControls
{
    public class ShadowPanelx : Panel
    {
        private BorderRadius _radius;
        private SolidBrush fillBrush;
        private Pen framePen;

        [Browsable(false)]
        public BorderRadius Radius { get { return _radius; } set { _radius = value; this.Invalidate(); } }

        public Color FillColor
        {
            set
            {
                if (value == null)
                {
                    fillBrush = null;
                }
                else
                {
                    fillBrush = new SolidBrush(value);
                }

                this.Invalidate();
            }
        }

        public Color FrameColor
        {
            set
            {
                if (value == null)
                {
                    framePen = null;
                }
                else
                {
                    framePen = new Pen(value);
                }

                this.Invalidate();
            }
        }




        public ShadowPanelx()
        {
            Radius = new BorderRadius(12);
            this.Resize += Panelx_Resize;
            framePen = new Pen(Color.White);

        }

        private void Panelx_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.AssumeLinear;




            for (int i = 0; i < 5; i++)
            {

                Rectangle rect = new Rectangle(i + 1, i + 1, this.Width - (i * 2), this.Height - (i * 2));
                var path = GraphicUtils.CreateRoundRectanglePath(12 - i, rect);
             


                framePen.Color = Color.FromArgb(Convert.ToInt32(255f * i / 15f), 220, 220, 220);
                g.DrawPath(framePen, path);


            }







            //PathGradientBrush pgb = new PathGradientBrush(path);
            //pgb.CenterColor = Color.Red;
            //pgb.WrapMode = WrapMode.TileFlipX;
            //g.FillPath(pgb, path);

            //if (fillBrush != null)
            //{
            //    g.FillPath(fillBrush, path);
            //}



        }
    }
}
