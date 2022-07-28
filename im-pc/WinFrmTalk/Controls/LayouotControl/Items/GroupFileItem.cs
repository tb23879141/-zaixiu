using System;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.View;

namespace WinFrmTalk.Controls.LayouotControl.Items
{
    public partial class GroupFileItem : UserControl
    {

        public GroupResource itemData;
        public float fileSize;

        public GroupFileItem()
        {
            InitializeComponent();

            label1.MouseDown += Item_MouseDown;
            tvTitle.MouseDown += Item_MouseDown;
            ivIcon.MouseDown += Item_MouseDown;
            tvTime.MouseDown += Item_MouseDown;
            tvFileName.MouseDown += Item_MouseDown;
            tvSize.MouseDown += Item_MouseDown;

            label1.MouseClick += Item_MouseClick;
            tvTitle.MouseClick += Item_MouseClick;
            ivIcon.MouseClick += Item_MouseClick;
            tvTime.MouseClick += Item_MouseClick;
            tvFileName.MouseClick += Item_MouseClick;
            tvSize.MouseClick += Item_MouseClick;

            label1.MouseMove += Item_MouseMove;
            tvTitle.MouseMove += Item_MouseMove;
            ivIcon.MouseMove += Item_MouseMove;
            tvTime.MouseMove += Item_MouseMove;
            tvFileName.MouseMove += Item_MouseMove;
            tvSize.MouseMove += Item_MouseMove;

            label1.MouseUp += Item_MouseUp;
            tvTitle.MouseUp += Item_MouseUp;
            ivIcon.MouseUp += Item_MouseUp;
            tvTime.MouseUp += Item_MouseUp;
            tvFileName.MouseUp += Item_MouseUp;
            tvSize.MouseUp += Item_MouseUp;
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
            this.itemData = data.resource;
            this.fileSize = data.resource.size;
            tvTitle.Text = data.title;

            if (UIUtils.IsNull(data.resource.oFileName))
            {
                tvFileName.Text = FileUtils.GetFileName(data.resource.oUrl);
            }
            else
            {
                tvFileName.Text = data.resource.oFileName;
            }


            tvTime.Text = string.Format("{0}  {1}", TimeUtils.FromatTime(data.time, "yyyy/MM/dd HH:mm:ss"), data.nickname);
            tvTime.MaximumSize = new System.Drawing.Size(240, 17);
            tvTime.AutoEllipsis = true;
            toolTip1.SetToolTip(tvTime, data.nickname);

            ivIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            FrmHistoryChat.TypeFileToImage(data.resource.oUrl, ivIcon);

            this.AccessibleDescription = tvFileName.Text;
        }

        internal void SetContentData(GroupFilesx data, bool line)
        {
            this.fileSize = data.fileSize;

            if (UIUtils.IsNull(data.title))
            {
                label1.Visible = false;
                tvTitle.Visible = false;
                this.Height = 105 - 34;
            }
            else
            {
                tvTitle.Text = data.title;
            }


            tvFileName.Text = FileUtils.GetFileName(data.DisplayName);
            this.AccessibleName = tvFileName.Text;

            ivIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            FrmHistoryChat.TypeFileToImage(data.url, ivIcon);

            tvTime.Text = TimeUtils.FromatTime(data.createTime, "yyyy/MM/dd HH:mm");
            tvSize.Text = UIUtils.FromatFileSize(Convert.ToInt32(data.fileSize));
            bottmLine.Visible = line;
        }

        internal void SetContentData(MyGroupActivity_ContentsItem data)
        {
            this.Height = 105 - 34;
            label1.Visible = false;
            tvTitle.Visible = false;
            bottmLine.Visible = false;
            tvTime.Visible = false;
            tvSize.Visible = false;

            tvFileName.Text = FileUtils.GetFileName(data.oFileName);
            this.AccessibleName = tvFileName.Text;
            tvFileName.Location = new System.Drawing.Point(tvFileName.Location.X, ivIcon.Location.Y + 5);

            ivIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            FrmHistoryChat.TypeFileToImage(data.oFileName, ivIcon);
        }
    }
}
