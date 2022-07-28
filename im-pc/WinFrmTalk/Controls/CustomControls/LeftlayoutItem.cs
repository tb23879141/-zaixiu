using System;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class LeftlayoutItem : UserControl
    {

        private bool Selected;


        private string _abname;


        public Image MouseImage { get; set; }

        private Image _abImage;



        public Image Image
        {
            get
            {
                return _abImage;
            }
            set
            {
                _abImage = value;
                this.ivImage.Image = value;
            }
        }

        public string Desname
        {

            get
            {
                return _abname;
            }
            set
            {
                _abname = value;
                this.tvText.Text = value;
            }
        }



        public LeftlayoutItem()
        {
            InitializeComponent();

            this.Load += LeftlayoutItem_Load;
        }

        private void LeftlayoutItem_Load(object sender, EventArgs e)
        {
            #region 继承父级的方法
            //Click Event
            ivImage.Click += Parent_Click;
            tvText.Click += Parent_Click;

            //Double Click Event
            ivImage.DoubleClick += Parent_DoubleClick;
            tvText.DoubleClick += Parent_DoubleClick;

            //MouseClick Event
            ivImage.MouseClick += Parent_MouseClick;
            tvText.MouseClick += Parent_MouseClick;

            //MouseLeave Event
            ivImage.MouseLeave += Parent_MouseLeave;
            tvText.MouseLeave += Parent_MouseLeave;

            //MouseEnter Event
            ivImage.MouseEnter += Parent_MouseEnter;
            tvText.MouseEnter += Parent_MouseEnter;

            //MouseEnter Event
            tvText.MouseDown += Parent_MouseDown;
            ivImage.MouseDown += Parent_MouseDown;
            #endregion

            this.MouseEnter += Item_MouseEnter;
            this.MouseLeave += Item_MouseLeave;
        }

        #region Parent Event
        private void Parent_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void Parent_DoubleClick(object sender, EventArgs e)
        {
            this.OnDoubleClick(e);
        }


        private void Parent_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void Parent_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void Parent_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void Parent_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        #endregion


        #region 鼠标移入移出事件
        private void Item_MouseEnter(object sender, EventArgs e)
        {
            //非选中状态
            if (!Selected)
            {
                this.ivImage.Image = MouseImage;
                this.tvText.ForeColor = Color.FromArgb(12, 206, 99);
                // this.BackColor = BackColor = Color.FromArgb(39, 28, 255);//悬浮颜色
            }
        }

        private void Item_MouseLeave(object sender, EventArgs e)
        {
            //非选中状态
            if (!Selected)
            {
                this.ivImage.Image = Image;
                this.tvText.ForeColor = Color.White;
                //  this.BackColor = Color.Transparent;//离开时变回默认的颜色
            }
        }

        #endregion


        public void ItemFousced(bool foucs)
        {
            this.Selected = foucs;

            if (foucs)
            {
                //       labelRecent.BackColor = Color.Transparent;
                this.BackgroundImage = Resources.mainSelectBG;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                tvText.ForeColor = Color.Blue;
                this.BackColor = Color.Transparent;
            }
            else
            {

                this.BackgroundImage = null;
                tvText.ForeColor = Color.White;
                this.BackColor = Color.Transparent;

            }
        }

        public void UnreadCount(int count)
        {
            this.ivImage.UnreadCount = count;
        }
    }
}
