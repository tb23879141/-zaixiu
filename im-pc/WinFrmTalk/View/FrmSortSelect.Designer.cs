namespace WinFrmTalk.Controls.CustomControls
{
    partial class FrmSortSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.skinLine2 = new CCWin.SkinControl.SkinLine();
            this.rightList = new TestListView.XListView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.tvwColleague = new WinFrmTalk.Controls.CustomControls.SortSelectTree();
            this.leftList = new TestListView.XListView();
            this.cmtSelct = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsAllselct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCnlAllselct = new System.Windows.Forms.ToolStripMenuItem();
            this.userSearch = new WinFrmTalk.Controls.CustomControls.UserSearch();
            this.lbltips = new System.Windows.Forms.Label();
            this.cmtSelct.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinLine2
            // 
            this.skinLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinLine2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.skinLine2.LineColor = System.Drawing.Color.DimGray;
            this.skinLine2.LineHeight = 1;
            this.skinLine2.Location = new System.Drawing.Point(285, 0);
            this.skinLine2.Name = "skinLine2";
            this.skinLine2.Size = new System.Drawing.Size(1, 574);
            this.skinLine2.TabIndex = 21;
            this.skinLine2.Text = "skinLine2";
            // 
            // rightList
            // 
            this.rightList.BackColor = System.Drawing.Color.White;
            this.rightList.Location = new System.Drawing.Point(294, 79);
            this.rightList.Name = "rightList";
            this.rightList.ScrollBarWidth = 10;
            this.rightList.Size = new System.Drawing.Size(266, 454);
            this.rightList.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(213)))), ((int)(((byte)(140)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(474, 539);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 25);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(213)))), ((int)(((byte)(140)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(387, 539);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(68, 25);
            this.btnConfirm.TabIndex = 16;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(474, 44);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(81, 17);
            this.lblCount.TabIndex = 14;
            this.lblCount.Text = "0/15人";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tvwColleague
            // 
            this.tvwColleague.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvwColleague.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tvwColleague.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwColleague.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.tvwColleague.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.tvwColleague.HotTracking = true;
            this.tvwColleague.Indent = 20;
            this.tvwColleague.ItemHeight = 30;
            this.tvwColleague.Location = new System.Drawing.Point(10, 67);
            this.tvwColleague.Name = "tvwColleague";
            this.tvwColleague.Size = new System.Drawing.Size(267, 480);
            this.tvwColleague.TabIndex = 29;
            this.tvwColleague.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwColleague_NodeMouseClick);
            // 
            // leftList
            // 
            this.leftList.BackColor = System.Drawing.Color.White;
            this.leftList.Location = new System.Drawing.Point(6, 67);
            this.leftList.Name = "leftList";
            this.leftList.ScrollBarWidth = 10;
            this.leftList.Size = new System.Drawing.Size(273, 480);
            this.leftList.TabIndex = 35;
            this.leftList.Visible = false;
            // 
            // cmtSelct
            // 
            this.cmtSelct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAllselct,
            this.tsCnlAllselct});
            this.cmtSelct.Name = "cmtSelct";
            this.cmtSelct.Size = new System.Drawing.Size(125, 48);
            // 
            // tsAllselct
            // 
            this.tsAllselct.Name = "tsAllselct";
            this.tsAllselct.Size = new System.Drawing.Size(124, 22);
            this.tsAllselct.Text = "全选";
            this.tsAllselct.Click += new System.EventHandler(this.tsAllselct_Click);
            // 
            // tsCnlAllselct
            // 
            this.tsCnlAllselct.Name = "tsCnlAllselct";
            this.tsCnlAllselct.Size = new System.Drawing.Size(124, 22);
            this.tsCnlAllselct.Text = "取消全选";
            this.tsCnlAllselct.Click += new System.EventHandler(this.tsCnlAllselct_Click);
            // 
            // userSearch
            // 
            this.userSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(217)))), ((int)(((byte)(216)))));
            this.userSearch.Location = new System.Drawing.Point(23, 40);
            this.userSearch.LoseFocusResume = true;
            this.userSearch.Name = "userSearch";
            this.userSearch.Size = new System.Drawing.Size(230, 21);
            this.userSearch.TabIndex = 41;
            // 
            // lbltips
            // 
            this.lbltips.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltips.ForeColor = System.Drawing.Color.Gray;
            this.lbltips.Location = new System.Drawing.Point(303, 34);
            this.lbltips.Name = "lbltips";
            this.lbltips.Size = new System.Drawing.Size(163, 36);
            this.lbltips.TabIndex = 47;
            this.lbltips.Text = "请勾选需要添加的联系人";
            this.lbltips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmSortSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(564, 573);
            this.Controls.Add(this.lbltips);
            this.Controls.Add(this.userSearch);
            this.Controls.Add(this.leftList);
            this.Controls.Add(this.tvwColleague);
            this.Controls.Add(this.skinLine2);
            this.Controls.Add(this.rightList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSortSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "好友选择器";
            this.cmtSelct.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinLine skinLine2;
        private TestListView.XListView rightList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblCount;
        public SortSelectTree tvwColleague;
        private TestListView.XListView leftList;
        private System.Windows.Forms.ContextMenuStrip cmtSelct;
        private System.Windows.Forms.ToolStripMenuItem tsAllselct;
        private System.Windows.Forms.ToolStripMenuItem tsCnlAllselct;
        private UserSearch userSearch;
        private System.Windows.Forms.Label lbltips;
    }
}