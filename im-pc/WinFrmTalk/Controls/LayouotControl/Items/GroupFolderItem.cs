using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Controls.LayouotControl.GroupDomain;
using WinFrmTalk.Controls.LayouotControl.Groups;

namespace WinFrmTalk.Controls.LayouotControl.Items
{
    /// <summary>
    /// 文件夹项
    /// </summary>
    public partial class GroupFolderItem : UserControl
    {
        [Browsable(false)]
        public string FolderName { get; private set; }

        [Browsable(false)]
        public int Level { get; private set; }

        [Browsable(false)]
        public HttpFolderData itemData { get; private set; }


        [Browsable(false)]
        public GroupTabIndex tabIndex { get; private set; }

        [Browsable(false)]
        public int Count { get; set; }


        public bool SubFolder
        {
            get
            {
                if (itemData != null)
                {
                    return itemData.SubFolder;
                }
                return false;
            }
        }

        public GroupFolderItem()
        {
            InitializeComponent();

            imageViewxFloder1.MouseClick += Item_MouseClick;
            tvName.MouseClick += Item_MouseClick;
            tvCount.MouseClick += Item_MouseClick;

            imageViewxFloder1.MouseDown += Item_MouseDown;
            tvName.MouseDown += Item_MouseDown;
            tvCount.MouseDown += Item_MouseDown;

            imageViewxFloder1.MouseMove += Item_MouseMove;
            tvName.MouseMove += Item_MouseMove;
            tvCount.MouseMove += Item_MouseMove;

            imageViewxFloder1.MouseUp += Item_MouseUp;
            tvName.MouseUp += Item_MouseUp;
            tvCount.MouseUp += Item_MouseUp;

            tvCount.BackColor = Color.Transparent;
            tvCount.Parent = imageViewxFloder1;
            tvCount.Location = new Point(imageViewxFloder1.Width - tvCount.Width - 5, imageViewxFloder1.Height - tvCount.Height - 3);
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



        internal void SetContentData(HttpFolderData data)
        {
            this.itemData = data;
            this.FolderName = UIUtils.IsNull(data.folderName) ? "默认文件夹" : data.folderName;
            this.Level = data.type;
            this.tabIndex = data.tabIndex;


            this.Count = FrmDetailsFolder.GetLevelDownCount(data);

            tvCount.Text = this.Count + "条";
            tvName.Text = FolderName;
            toolTip1.SetToolTip(tvName, data.folderName);
            toolTip1.SetToolTip(imageViewxFloder1, data.folderName);


            if (data.SubFolder)
            {
                if (data.type == 1 && this.Count > 0)
                {
                    var url = data.PictureCover;
                    if (UIUtils.IsNull(url))
                    {
                        imageViewxFloder1.FolderType = 1;
                    }
                    else
                    {
                        ImageLoader.Instance.Load(url).Into((bit, path) =>
                        {
                            imageViewxFloder1.FolderType = 2;
                            imageViewxFloder1.Image = bit;

                        });
                    }

                    imageViewxFloder1.FolderType = 2;
                }
                else
                {
                    imageViewxFloder1.FolderType = 1;
                }

            }
            else
            {
                imageViewxFloder1.FolderType = 0;
            }
        }

    }
}
