using System;
using System.ComponentModel;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Controls.LayouotControl.GroupDomain;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    public partial class GroupFuncTools : UserControl
    {

        // 开始搜索，显示等待符的委托事件
        public event SearchDeleate SearchEvent;

        public event EventHandler CreateFolderClick;
        public event EventHandler FilterClick;
        public event EventHandler BackClick;

        [Browsable(false)]
        public int Filter { get; private set; }

        [Browsable(false)]
        public HttpFolderData ItemData { get; private set; }

        public bool isManager { get; private set; }
        public int insideType { get; private set; }


        [Browsable(false)]
        public HttpFolderData BaseData { get; private set; }

        public GroupFuncTools()
        {
            InitializeComponent();
            userSearch1.SearchEvent += UserSearch_SearchEvent;
        }

        private void UserSearch_SearchEvent(string text)
        {
            if (UIUtils.IsNull(text))
            {
                btnSearch_Click(this, null);
            }
            else
            {
                tvName.Text = "搜索结果：              ";
            }

            SearchEvent?.Invoke(text);
        }



        internal void SetToolbarData(HttpFolderData folder, int insideType, bool manager, GroupTabIndex mGroupTab)
        {
            if (folder.SubFolder)
            {
                this.BaseData = this.ItemData;
            }

            this.ItemData = folder;
            this.isManager = manager;
            this.insideType = insideType;

            SetToolbarData(folder.folderName, folder.Count, folder.SubFolder, UIUtils.IsNull(folder.folderId));

            if (mGroupTab == GroupTabIndex.image && folder.SubFolder)
            {
                btnSearch.Visible = false;
            }
            else
            {
                btnSearch.Visible = true;
            }
        }

        private void SetToolbarData(string title, int count, bool subFolder, bool defFolder)
        {
            userSearch1.Visible = false;
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
            btnCreate.Visible = isManager && (!defFolder && !subFolder);




            // 重置筛选
            if (insideType == 2)
            {
                // 官群
                toolStripMenuItem0.Text = "围观可下载";
                toolStripMenuItem1.Text = "围观不可下载";
                toolStripMenuItem2.Visible = false;
            }
            else if (insideType == 1)
            {
                // 外部群
                toolStripMenuItem0.Text = "仅群员可下载";
                toolStripMenuItem1.Text = "群员、围观可下载";
                toolStripMenuItem2.Text = "群员、围观不可下载";
                toolStripMenuItem2.Visible = true;
            }
            else if (insideType == 0)
            {
                // 内部群
                toolStripMenuItem0.Text = "群员可下载";
                toolStripMenuItem1.Text = "群员不可下载";
                toolStripMenuItem2.Visible = false;
            }

            ItemMenu_Click(itemActiveSort, null);
        }

        private void GroupFuncTools_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (userSearch1.Visible)
            {
                userSearch1.Visible = false;
                tvName.Text = tvName.AccessibleName;
            }
            else
            {

                userSearch1.Visible = true;
                userSearch1.lbl_Search_Click(userSearch1, e);
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateFolderClick?.Invoke(this, e);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // 显示
            filterMenu.Show(btnFilter.PointToScreen(new System.Drawing.Point(12, 12)));
            //filterMenu.Show(btnFilter, 0,0);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackClick?.Invoke(this, e);
        }


        private void ItemMenu_Click(object sender, EventArgs e)
        {
            var select = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in filterMenu.Items)
            {
                item.Checked = select == item;
            }

            Filter = Convert.ToInt32(select.Tag);

            if (Filter == 0)
            {
                btnFilter.Image = WinFrmTalk.Properties.Resources.ic_group_res_filter;
            }
            else
            {
                btnFilter.Image = WinFrmTalk.Properties.Resources.ic_group_res_filter1;
            }

            if (e != null)
            {
                FilterClick?.Invoke(this, e);
            }
        }


    }
}
