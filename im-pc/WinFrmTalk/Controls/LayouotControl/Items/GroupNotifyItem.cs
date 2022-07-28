using CCWin.SkinControl;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.LayouotControl.Items
{
    /// <summary>
    /// 群公告子项
    /// </summary>
    public partial class GroupNotifyItem : UserControl
    {


        public int ListWidth { get; internal set; }
        public MyGroupNotice itemData;


        public GroupNotifyItem()
        {
            InitializeComponent();

            tvContent.SetReadMode();

            tvTime.MouseDown += Item_MouseDown;
            tvTitle.MouseDown += Item_MouseDown;
            tvContent.MouseDown += Item_MouseDown;
            label1.MouseDown += Item_MouseDown;

            tvTime.MouseClick += Item_MouseClick;
            tvTitle.MouseClick += Item_MouseClick;
            tvContent.MouseClick += Item_MouseClick;
            label1.MouseClick += Item_MouseClick;
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }



        internal void SetContentData(MyGroupNotice data, SkinContextMenuStrip contextMenu)
        {
            this.itemData = data;

            tvContent.ContextMenuStrip = contextMenu;
            tvContent.BackColor = Color.FromArgb(245, 245, 245);
            tvTitle.Text = data.title;
            this.tvContent.Text = data.text;
            tvTime.Text = string.Format("{0}  {1}", data.nickname, TimeUtils.FromatTime(data.time, "yyyy-MM-dd"));

            int maxWidth = this.ListWidth - 30;

            if (!UIUtils.IsNull(data.picPath))
            {
                ivIcon.Visible = true;
                tvContent.Location = new Point(78, 44);
                maxWidth = maxWidth - 75;
                ivIcon.SizeMode = PictureBoxSizeMode.Zoom;
                ImageLoader.Instance.Load(data.picPath[0]).Into(ivIcon);
            }

            var size = MeasureUtils.MeasureString(data.text, this.tvContent.Font, maxWidth);
            int height = size.Height + 5;


            this.tvContent.Size = new Size(size.Width, height);
            this.Size = new Size(ListWidth, tvContent.Height + 100);

            if (ivIcon.Visible)
            {
                ivIcon.Location = new Point(12, (this.Height - ivIcon.Height) / 2 - 10);

            }

        }

        internal CollectionSave toCollection()
        {
            CollectionSave data = new CollectionSave();
            data.title = itemData.title;
            data.msg = itemData.text;
            return data;
        }
    }
}