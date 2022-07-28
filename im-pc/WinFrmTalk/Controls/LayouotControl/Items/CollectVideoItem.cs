using System;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.LayouotControl.Items
{
    public partial class CollectVideoItem : UserControl
    {
        public GroupFilesx itemData { get; set; }

        public CollectVideoItem()
        {
            InitializeComponent();


            this.tvName.MouseClick += Item_MouseClick;
            this.tvDay.MouseClick += Item_MouseClick;
            this.tvMonth.MouseClick += Item_MouseClick;
            this.tvLength.MouseClick += Item_MouseClick;
            this.ivIcon.MouseClick += Item_MouseClick;
            this.tvTime.MouseClick += Item_MouseClick;

            this.tvName.MouseDown += Item_MouseDown;
            this.tvDay.MouseDown += Item_MouseDown;
            this.tvMonth.MouseDown += Item_MouseDown;
            this.tvLength.MouseDown += Item_MouseDown;
            this.ivIcon.MouseDown += Item_MouseDown;
            this.tvTime.MouseDown += Item_MouseDown;


            tvName.MouseMove += Item_MouseMove;
            tvDay.MouseMove += Item_MouseMove;
            tvMonth.MouseMove += Item_MouseMove;
            tvLength.MouseMove += Item_MouseMove;
            ivIcon.MouseMove += Item_MouseMove;
            tvTime.MouseMove += Item_MouseMove;

            tvName.MouseUp += Item_MouseUp;
            tvDay.MouseUp += Item_MouseUp;
            tvMonth.MouseUp += Item_MouseUp;
            tvLength.MouseUp += Item_MouseUp;
            ivIcon.MouseUp += Item_MouseUp;
            tvTime.MouseUp += Item_MouseUp;
        }

        private void Item_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }
        private void Item_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        internal void SetContentData(GroupFilesx data, bool header)
        {
            this.itemData = data;

            tvName.Text = FileUtils.GetFileName(data.DisplayName);

            tvLength.Text = UIUtils.FromatFileSize(Convert.ToInt32(data.fileSize));
            tvTime.Text = TimeUtils.FromatTime(data.createTime, "HH:mm");
            ThubImageLoader.Instance.LoadImage(data.url, ivIcon);

            if (header)
            {
                tvDay.Text = TimeUtils.FromatTime(data.createTime, "dd");
                tvMonth.Text = TimeUtils.FromatTime(data.createTime, "MM月");
            }
            else
            {
                tvDay.Visible = false;
                tvMonth.Visible = false;
                icRound.Visible = false;
            }
        }
    }
}
