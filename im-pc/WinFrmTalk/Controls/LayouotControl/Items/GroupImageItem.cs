using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.LayouotControl.Items
{
    /// <summary>
    /// 照片项
    /// </summary>
    public partial class GroupImageItem : UserControl
    {
        public GroupImageItem()
        {
            InitializeComponent();

            imageViewxFloder1.MouseClick += Item_MouseClick;
            tvName.MouseClick += Item_MouseClick;

            imageViewxFloder1.MouseDown += Item_MouseDown;
            tvName.MouseDown += Item_MouseDown;

            imageViewxFloder1.MouseMove += Item_MouseMove;
            tvName.MouseMove += Item_MouseMove;

            imageViewxFloder1.MouseUp += Item_MouseUp;
            tvName.MouseUp += Item_MouseUp;
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

        internal void SetContentData(GroupFilesx data)
        {
            imageViewxFloder1.SizeMode = PictureBoxSizeMode.Zoom;
            ImageLoader.Instance.Load(data.url).Center().Into(imageViewxFloder1);

            long time = data.time == 0 ? data.createTime : data.time;
            tvName.Text = TimeUtils.FromatTime(time, "yyyy-MM-dd");
        }

    }

}
