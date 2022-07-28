using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 资源气泡
    /// </summary>
    public partial class ResourexResPanel : UserControl
    {

        public ResourexResPanel()
        {
            InitializeComponent();

            this.tvTitle.MouseClick += Item_MouseClick;
            this.tvResType.MouseClick += Item_MouseClick;
            this.ivImage.MouseClick += Item_MouseClick;
            this.lab_lineSilver.MouseClick += Item_MouseClick;
            this.tvContent.MouseClick += Item_MouseClick;
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        public void SetItemData(MyGroupResource data, bool res = true)
        {
            this.tvContent.Text = data.subTitle;
            if (res)
            {
                this.tvResType.Text = data.title;
                this.tvResType.ForeColor = data.title == "所需资源" ? Color.FromArgb(255, 70, 70) : Color.FromArgb(12, 206, 99);
                this.tvTitle.Location = new System.Drawing.Point(60, this.tvTitle.Location.Y);
                this.tvTitle.Width = this.Width - 60;
                this.tvTitle.Text = "";
                label6.Text = "资源";
                toolTip1.SetToolTip(this.tvContent, "资源");
            }
            else
            {
                this.tvTitle.Text = data.title;
                label6.Text = "秀吧";
                toolTip1.SetToolTip(this.tvContent, "秀吧");
            }

            ivImage.SizeMode = PictureBoxSizeMode.StretchImage;
            ImageLoader.Instance.Load(data.imageUrl).Center().Into(ivImage);
        }

        internal void SetItemData(MessageObject data)
        {
            this.tvResType.Visible = false;
            if (!UIUtils.IsNull(data.fileName))
            {
                this.tvTitle.Text = data.fileName;
            }
            else
            {
                this.tvTitle.Visible = false;

                this.Height = 120 - 25;
            }

            if (!UIUtils.IsNull(data.objectId))
            {
                ivImage.SizeMode = PictureBoxSizeMode.Zoom;
                ImageLoader.Instance.Load(data.objectId).Center().Into(ivImage);
            }
            else
            {
                tvContent.Width = this.Width;
            }

            tvContent.Text = data.content;
            toolTip1.SetToolTip(this.tvContent, "公告");
            label6.Text = "公告";
        }


        internal void SetCardItemData(MessageObject data)
        {
            ImageLoader.Instance.DisplayGroupAvatar(data.objectId, data.signature, ivImage);
            label6.Text = "邀请链接";
            this.Height = 100;
            tvContent.Text = data.content;
            tvTitle.Text = data.fileName;
        }




    }
}
