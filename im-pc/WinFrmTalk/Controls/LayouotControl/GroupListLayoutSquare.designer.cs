using WinFrmTalk.Controls.CustomControls;

namespace WinFrmTalk
{
    partial class GroupListLayoutSquare
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tvSortName = new System.Windows.Forms.Label();
            this.xListView = new TestListView.XListView();
            this.groupTypeGrid1 = new WinFrmTalk.Controls.LayouotControl.Groups.GroupTypeGrid();
            this.tabLayoutPanel1 = new WinFrmTalk.Controls.TabLayoutPanel();
            this.ivNext = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemActiveSort = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMemberSort = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ivNext)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvSortName
            // 
            this.tvSortName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.tvSortName.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvSortName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tvSortName.Location = new System.Drawing.Point(110, 8);
            this.tvSortName.Name = "tvSortName";
            this.tvSortName.Size = new System.Drawing.Size(145, 19);
            this.tvSortName.TabIndex = 0;
            this.tvSortName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tvSortName.Click += new System.EventHandler(this.SortName_Click);
            // 
            // xListView
            // 
            this.xListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.xListView.Location = new System.Drawing.Point(0, 38);
            this.xListView.Name = "xListView";
            this.xListView.ScrollBarWidth = 10;
            this.xListView.Size = new System.Drawing.Size(275, 572);
            this.xListView.TabIndex = 26;
            // 
            // groupTypeGrid1
            // 
            this.groupTypeGrid1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.groupTypeGrid1.FirstId = null;
            this.groupTypeGrid1.Location = new System.Drawing.Point(0, 38);
            this.groupTypeGrid1.Name = "groupTypeGrid1";
            this.groupTypeGrid1.SecondId = null;
            this.groupTypeGrid1.Size = new System.Drawing.Size(275, 572);
            this.groupTypeGrid1.TabIndex = 30;
            // 
            // tabLayoutPanel1
            // 
            this.tabLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.tabLayoutPanel1.DelimitLineHeight = 16;
            this.tabLayoutPanel1.ItemMaginLeft = 10;
            this.tabLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tabLayoutPanel1.Name = "tabLayoutPanel1";
            this.tabLayoutPanel1.Size = new System.Drawing.Size(275, 38);
            this.tabLayoutPanel1.TabIndex = 29;
            // 
            // ivNext
            // 
            this.ivNext.BackColor = System.Drawing.Color.FromArgb(230, 229, 229);
            this.ivNext.Image = global::WinFrmTalk.Properties.Resources.ic_group_tab_next;
            this.ivNext.Location = new System.Drawing.Point(253, 8);
            this.ivNext.Name = "ivNext";
            this.ivNext.Size = new System.Drawing.Size(20, 20);
            this.ivNext.TabIndex = 31;
            this.ivNext.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemActiveSort,
            this.itemMemberSort});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            // 
            // itemActiveSort
            // 
            this.itemActiveSort.Checked = true;
            this.itemActiveSort.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemActiveSort.Name = "itemActiveSort";
            this.itemActiveSort.Size = new System.Drawing.Size(148, 22);
            this.itemActiveSort.Tag = "1";
            this.itemActiveSort.Text = "按活跃度排列";
            this.itemActiveSort.Click += new System.EventHandler(this.ItemSort_Click);
            // 
            // itemMemberSort
            // 
            this.itemMemberSort.Name = "itemMemberSort";
            this.itemMemberSort.Size = new System.Drawing.Size(148, 22);
            this.itemMemberSort.Tag = "2";
            this.itemMemberSort.Text = "按群人数排列";
            this.itemMemberSort.Click += new System.EventHandler(this.ItemSort_Click);
            // 
            // GroupListLayoutSquare
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.tvSortName);
            this.Controls.Add(this.ivNext);
            this.Controls.Add(this.tabLayoutPanel1);
            this.Controls.Add(this.xListView);
            this.Controls.Add(this.groupTypeGrid1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GroupListLayoutSquare";
            this.Size = new System.Drawing.Size(275, 610);
            ((System.ComponentModel.ISupportInitialize)(this.ivNext)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        private TestListView.XListView xListView;
        private System.Windows.Forms.ToolTip toolTip1;
        private Controls.TabLayoutPanel tabLayoutPanel1;
        private System.Windows.Forms.Label tvSortName;
        private Controls.LayouotControl.Groups.GroupTypeGrid groupTypeGrid1;
        private System.Windows.Forms.PictureBox ivNext;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem itemActiveSort;
        private System.Windows.Forms.ToolStripMenuItem itemMemberSort;
        #endregion
        /*
        private System.Windows.Forms.TextBox txtSearch;
        private MyTabLayoutPanel tlpRoomList;
        private System.Windows.Forms.Button btnPlus;
        */
    }
}
