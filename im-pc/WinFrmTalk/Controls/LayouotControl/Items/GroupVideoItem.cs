using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.LayouotControl.Items
{
    public partial class GroupVideoItem : UserControl
    {

        public GroupFilesx itemData;

        public GroupVideoItem()
        {
            InitializeComponent();

            this.tvName.MouseClick += Item_MouseClick;
            this.tvLength.MouseClick += Item_MouseClick;
            this.imageViewxVideo1.MouseClick += Item_MouseClick;


            this.tvName.MouseDown += Item_MouseDown;
            this.tvLength.MouseDown += Item_MouseDown;
            this.imageViewxVideo1.MouseDown += Item_MouseDown;
        }


        internal void SetContentData(GroupFilesx data)
        {
            this.itemData = data;

            tvName.Text = data.title;
            tvLength.Text = string.Format("{0}", UIUtils.FromatFileSize(data.resource.size));

            ThubImageLoader.Instance.LoadImage(data.resource.oUrl, imageViewxVideo1);
            this.Height = tvName.Height + 130;
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

    }
}
