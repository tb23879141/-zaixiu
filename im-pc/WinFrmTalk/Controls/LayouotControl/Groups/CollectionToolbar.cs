using System;
using System.ComponentModel;
using System.Windows.Forms;
using WinFrmTalk.Controls.LayouotControl.GroupDomain;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    public partial class CollectionToolbar : UserControl
    {
        public event EventHandler BackClick;

        [Browsable(false)]
        public HttpFolderData ItemData { get; private set; }


        [Browsable(false)]
        public HttpFolderData BaseData { get; private set; }

        public CollectionToolbar()
        {
            InitializeComponent();
        }

        public string FolderId
        {
            get
            {
                return !this.Visible || ItemData == null ? "" : ItemData.folderId;
            }
        }

        internal void SetToolbarData(HttpFolderData folder)
        {
            if (folder.SubFolder)
            {
                this.BaseData = this.ItemData;
            }

            this.ItemData = folder;

            var count = FrmDetailsFolder.GetLevelDownCount(folder);
            SetToolbarData(folder.folderName, count, folder.SubFolder, UIUtils.IsNull(folder.folderId));
        }

        private void SetToolbarData(string title, int count, bool subFolder, bool defFolder)
        {
            if (!subFolder)
            {
                tvName.Text = UIUtils.IsNull(title) ? "默认文件夹" : title;
            }
            else
            {
                tvName.Text = string.Format("{0}/{1}", tvName.Text, title);
            }

            tvName.AccessibleName = tvName.Text;
            tvCount.Text = string.Format("{0}条", count);
            tvCount.Location = new System.Drawing.Point(tvName.Location.X + tvName.Width - 2, tvCount.Location.Y);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackClick?.Invoke(this, e);
        }
    }
}
