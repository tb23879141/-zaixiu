using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls.LayouotControl.Items
{
    public partial class GroupActiveItem2 : UserControl
    {

        public MyGroupActivity itemData { get; set; }


        public GroupActiveItem2()
        {
            InitializeComponent();

            this.pictureBox1.MouseClick += Item_MouseClick;
            this.tvCharge.MouseClick += Item_MouseClick;
            this.tvTitle.MouseClick += Item_MouseClick;
            this.tvAddress.MouseClick += Item_MouseClick;
            this.tvTime.MouseClick += Item_MouseClick;
            this.alphaPanelRound1.MouseClick += Item_MouseClick;


            this.pictureBox1.MouseDown += Item_MouseDown;
            this.tvCharge.MouseDown += Item_MouseDown;
            this.tvTitle.MouseDown += Item_MouseDown;
            this.tvAddress.MouseDown += Item_MouseDown;
            this.tvTime.MouseDown += Item_MouseDown;
            this.alphaPanelRound1.MouseDown += Item_MouseDown;
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        internal void SetContentData(MyGroupActivity data)
        {
            this.itemData = data;

            var curr = TimeUtils.CurrentTimeMillis();

            if (data.charge == 0)
            {
                this.tvCharge.Text = "收费";
                this.tvCharge.ForeColor = Color.FromArgb(255, 70, 70);
            }

            this.tvTitle.Text = data.title;
            this.tvAddress.Text = string.Format("活动地址:{0}", data.address);
            this.tvTime.Text = string.Format("  截止时间:{0}", TimeUtils.FromatTime(data.endTime / 1000, "yyyy-MM-dd"));


            if (curr < data.endTime)
            {
                ivState.Image = Resources.ActivityJXZ;
            }
            else
            {
                ivState.Image = Resources.ActivityYJS;
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            ImageLoader.Instance.Load(data.cover).Error(Resources.ic_group_active_defalt).Center().Into(pictureBox1);

            //this.BackColor = Color.FromArgb(240, 240, 240);
        }
    }
}
