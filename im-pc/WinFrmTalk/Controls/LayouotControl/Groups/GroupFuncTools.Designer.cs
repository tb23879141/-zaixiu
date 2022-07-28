namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    partial class GroupFuncTools
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
            this.tvName = new System.Windows.Forms.Label();
            this.tvCount = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.PictureBox();
            this.btnCreate = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.filterMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemActiveSort = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem0 = new System.Windows.Forms.ToolStripMenuItem();
            this.userSearch1 = new WinFrmTalk.Controls.CustomControls.UserSearch();
            ((System.ComponentModel.ISupportInitialize)(this.btnFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.filterMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvName
            // 
            this.tvName.AutoSize = true;
            this.tvName.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvName.Location = new System.Drawing.Point(35, 4);
            this.tvName.MaximumSize = new System.Drawing.Size(336, 27);
            this.tvName.Name = "tvName";
            this.tvName.Size = new System.Drawing.Size(136, 27);
            this.tvName.TabIndex = 1;
            this.tvName.Text = "Folder Name";
            // 
            // tvCount
            // 
            this.tvCount.AutoSize = true;
            this.tvCount.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tvCount.Location = new System.Drawing.Point(169, 8);
            this.tvCount.Name = "tvCount";
            this.tvCount.Size = new System.Drawing.Size(45, 19);
            this.tvCount.TabIndex = 2;
            this.tvCount.Text = "count";
            // 
            // btnFilter
            // 
            this.btnFilter.Image = global::WinFrmTalk.Properties.Resources.ic_group_res_filter;
            this.btnFilter.Location = new System.Drawing.Point(277, 0);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(24, 24);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.TabStop = false;
            this.toolTip1.SetToolTip(this.btnFilter, "筛选");
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Image = global::WinFrmTalk.Properties.Resources.ic_group_res_create;
            this.btnCreate.Location = new System.Drawing.Point(241, 0);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(24, 24);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.TabStop = false;
            this.toolTip1.SetToolTip(this.btnCreate, "创建文件夹");
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::WinFrmTalk.Properties.Resources.ic_group_res_search;
            this.btnSearch.Location = new System.Drawing.Point(205, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(24, 24);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.TabStop = false;
            this.toolTip1.SetToolTip(this.btnSearch, "搜索");
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnBack
            // 
            this.btnBack.Image = global::WinFrmTalk.Properties.Resources.ic_collect_back;
            this.btnBack.Location = new System.Drawing.Point(6, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(24, 24);
            this.btnBack.TabIndex = 0;
            this.btnBack.TabStop = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnFilter);
            this.flowLayoutPanel1.Controls.Add(this.btnCreate);
            this.flowLayoutPanel1.Controls.Add(this.btnSearch);
            this.flowLayoutPanel1.Controls.Add(this.userSearch1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(334, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(311, 24);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // filterMenu
            // 
            this.filterMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemActiveSort,
            this.toolStripMenuItem0,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.filterMenu.Name = "contextMenuStrip1";
            this.filterMenu.Size = new System.Drawing.Size(181, 114);
            // 
            // itemActiveSort
            // 
            this.itemActiveSort.Checked = true;
            this.itemActiveSort.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemActiveSort.Name = "itemActiveSort";
            this.itemActiveSort.Size = new System.Drawing.Size(180, 22);
            this.itemActiveSort.Tag = "0";
            this.itemActiveSort.Text = "全部";
            this.itemActiveSort.Click += new System.EventHandler(this.ItemMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Tag = "2";
            this.toolStripMenuItem1.Text = "允许围观下载";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ItemMenu_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Tag = "3";
            this.toolStripMenuItem2.Text = "不允许围观下载";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ItemMenu_Click);
            // 
            // toolStripMenuItem0
            // 
            this.toolStripMenuItem0.Name = "toolStripMenuItem0";
            this.toolStripMenuItem0.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem0.Tag = "1";
            this.toolStripMenuItem0.Text = "允许围观下载";
            this.toolStripMenuItem0.Click += new System.EventHandler(this.ItemMenu_Click);
            // 
            // userSearch1
            // 
            this.userSearch1.BackColor = System.Drawing.Color.White;
            this.userSearch1.Location = new System.Drawing.Point(23, 0);
            this.userSearch1.LoseFocusResume = false;
            this.userSearch1.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.userSearch1.Name = "userSearch1";
            this.userSearch1.Size = new System.Drawing.Size(180, 24);
            this.userSearch1.TabIndex = 3;
            this.userSearch1.Visible = false;
            // 
            // GroupFuncTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvName);
            this.Controls.Add(this.tvCount);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "GroupFuncTools";
            this.Size = new System.Drawing.Size(648, 36);
            ((System.ComponentModel.ISupportInitialize)(this.btnFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.filterMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnBack;
        private System.Windows.Forms.Label tvName;
        private System.Windows.Forms.Label tvCount;
        private CustomControls.UserSearch userSearch1;
        private System.Windows.Forms.PictureBox btnSearch;
        private System.Windows.Forms.PictureBox btnCreate;
        private System.Windows.Forms.PictureBox btnFilter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip filterMenu;
        private System.Windows.Forms.ToolStripMenuItem itemActiveSort;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem0;
    }
}
