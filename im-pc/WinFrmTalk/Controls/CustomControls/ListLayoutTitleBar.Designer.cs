namespace WinFrmTalk.Controls.CustomControls
{
    partial class ListLayoutTitleBar
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
            this.pboxIcon = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.line = new System.Windows.Forms.Label();
            this.RecentSearch = new WinFrmTalk.Controls.CustomControls.UserSearch();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxIcon
            // 
            this.pboxIcon.Image = global::WinFrmTalk.Properties.Resources.ic_titlebar_logo;
            this.pboxIcon.Location = new System.Drawing.Point(15, 13);
            this.pboxIcon.Name = "pboxIcon";
            this.pboxIcon.Size = new System.Drawing.Size(58, 24);
            this.pboxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxIcon.TabIndex = 7;
            this.pboxIcon.TabStop = false;
            this.pboxIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Item_MouseDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::WinFrmTalk.Properties.Resources.ic_titlebar_search;
            this.btnSearch.Location = new System.Drawing.Point(267, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(24, 24);
            this.btnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSearch.TabIndex = 8;
            this.btnSearch.TabStop = false;
            this.btnSearch.Click += new System.EventHandler(this.Search_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.Image = global::WinFrmTalk.Properties.Resources.ic_titlebar_add;
            this.btnMenu.Location = new System.Drawing.Point(301, 13);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(24, 24);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMenu.TabIndex = 9;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // line
            // 
            this.line.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line.BackColor = System.Drawing.Color.Gainsboro;
            this.line.Location = new System.Drawing.Point(0, 49);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(335, 1);
            this.line.TabIndex = 10;
            // 
            // RecentSearch
            // 
            this.RecentSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RecentSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(217)))), ((int)(((byte)(216)))));
            this.RecentSearch.Location = new System.Drawing.Point(93, 13);
            this.RecentSearch.LoseFocusResume = true;
            this.RecentSearch.Name = "RecentSearch";
            this.RecentSearch.Size = new System.Drawing.Size(198, 24);
            this.RecentSearch.TabIndex = 25;
            this.RecentSearch.Visible = false;
            // 
            // ListLayoutTitleBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.line);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pboxIcon);
            this.Controls.Add(this.RecentSearch);
            this.Name = "ListLayoutTitleBar";
            this.Size = new System.Drawing.Size(335, 50);
            ((System.ComponentModel.ISupportInitialize)(this.pboxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pboxIcon;
        private System.Windows.Forms.PictureBox btnSearch;
        private System.Windows.Forms.PictureBox btnMenu;
        private System.Windows.Forms.Label line;
        private UserSearch RecentSearch;
    }
}
