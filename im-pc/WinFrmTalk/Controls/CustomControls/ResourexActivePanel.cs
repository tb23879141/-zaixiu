using System.Windows.Forms;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 活动的气泡
    /// </summary>
    public partial class ResourexActivePanel : UserControl
    {
        public ResourexActivePanel()
        {
            InitializeComponent();

            foreach (Control item in this.Controls)
            {
                item.MouseClick += Item_MouseClick;
            }
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        public void SetItemData(MyGroupActivity data)
        {
            this.ivCharge.Image = data.charge == 0 ? Resources.ic_group_active_charge0 : Resources.ic_group_active_charge1;
            this.tvTitle.Text = data.title;
            this.tvType.Text = data.type;
            this.tvAddress.Text = data.address;
            this.tvCreateTime.Text = TimeUtils.FromatTime(data.time, "yyyy-MM-dd HH:mm");

            ivImage.SizeMode = PictureBoxSizeMode.Zoom;
            ImageLoader.Instance.Load(data.cover).Error(Resources.ic_group_active_defalt).Center().Into(ivImage);

            label6.Text = "活动";
            //toolTip1.SetToolTip(this.tvContent, "公告");
        }

    }
}
