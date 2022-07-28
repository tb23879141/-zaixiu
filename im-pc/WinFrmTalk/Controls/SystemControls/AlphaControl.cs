using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinFrmTalk.Controls.SystemControls
{
    internal class AlphaControl : System.Windows.Forms.Control
    {
        private bool _transparentBG = true;//是否使用透明
        private int _alpha = 125;//设置透明度

        private System.ComponentModel.Container components = new System.ComponentModel.Container();




        public AlphaControl() : this(125)
        {
        }

        public AlphaControl(int Alpha)
        {
            SetStyle(System.Windows.Forms.ControlStyles.Opaque, true);
            base.CreateControl();

            this._alpha = Alpha;
            if (Image != null)
            {
                PictureBox pictureBox_Loading = new PictureBox();
                pictureBox_Loading.BackColor = System.Drawing.Color.White;
                pictureBox_Loading.Image = Image;
                pictureBox_Loading.Name = "pictureBox_Loading";
                pictureBox_Loading.Size = this.Size;
                pictureBox_Loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                //Point Location = new Point(this.Location.X + (this.Width - pictureBox_Loading.Width) / 2, this.Location.Y + (this.Height - pictureBox_Loading.Height) / 2);//居中
                pictureBox_Loading.Location = Location;
                pictureBox_Loading.Anchor = AnchorStyles.None;
                this.Controls.Add(pictureBox_Loading);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!((components == null)))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 自定义绘制窗体
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            float vlblControlWidth;
            float vlblControlHeight;

            Pen labelBorderPen;
            SolidBrush labelBackColorBrush;

            if (_transparentBG)
            {
                Color drawColor = Color.FromArgb(this._alpha, this.BackColor);
                labelBorderPen = new Pen(drawColor, 0);
                labelBackColorBrush = new SolidBrush(drawColor);
            }
            else
            {
                labelBorderPen = new Pen(this.BackColor, 0);
                labelBackColorBrush = new SolidBrush(this.BackColor);
            }
            base.OnPaint(e);
            vlblControlWidth = this.Size.Width;
            vlblControlHeight = this.Size.Height;
            e.Graphics.DrawRectangle(labelBorderPen, 0, 0, vlblControlWidth, vlblControlHeight);
            e.Graphics.FillRectangle(labelBackColorBrush, 0, 0, vlblControlWidth, vlblControlHeight);
        }


        protected override CreateParams CreateParams//v1.10 
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //0x20;  // 开启 WS_EX_TRANSPARENT,使控件支持透明
                return cp;
            }
        }

        /*
         * [Category("myOpaqueLayer"), Description("是否使用透明,默认为True")]
         * 一般用于说明你自定义控件的属性（Property）。
         * Category用于说明该属性属于哪个分类，Description自然就是该属性的含义解释。
         */
        [Category("AlphaControl"), Description("是否使用透明,默认为True")]
        public bool TransparentBG
        {
            get
            {
                return _transparentBG;
            }
            set
            {
                _transparentBG = value;
                this.Invalidate();
            }
        }

        [Category("AlphaControl"), Description("设置透明度")]
        public int Alpha
        {
            get
            {
                return _alpha;
            }
            set
            {
                _alpha = value;
                this.Invalidate();
            }
        }


        [Category("AlphaControl"), Description("设置图片")]
        public Bitmap Image
        {
            get; set;
        }
    }
}