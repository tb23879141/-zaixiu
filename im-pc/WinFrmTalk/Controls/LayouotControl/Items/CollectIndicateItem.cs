using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFrmTalk.Controls.LayouotControl.Items
{
    public partial class CollectIndicateItem : UserControl, FocusControl
    {
        private string _abname;

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


        public CollectIndicateItem()
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
        //private void Item_MouseEnter(object sender, EventArgs e)
        //{
        //    //非选中状态
        //    if (!Selected)
        //    {
        //        this.BackColor = BackColor = Color.FromArgb(220, 220, 220);//悬浮颜色
        //    }
        //}

        //private void Item_MouseLeave(object sender, EventArgs e)
        //{
        //    //非选中状态
        //    if (!Selected)
        //    {
        //        this.BackColor = Color.Transparent;//离开时变回默认的颜色
        //    }
        //}

        #endregion

        public void FocusChanged(bool focus)
        {
            // Selected = focus;

            if (focus)
            {
                this.tvText.ForeColor = Color.FromArgb(12, 206, 99);
            }
            else
            {
                this.tvText.ForeColor = Color.FromArgb(168, 168, 168);
            }
            //this.BackColor = Color.Transparent;
        }
    }
}