using WinFrmTalk.Controls.CustomControls;

namespace WinFrmTalk
{
    partial class RecentListLayout
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
            this.btnPlus = new System.Windows.Forms.Button();
            this.RecentSearch = new WinFrmTalk.Controls.CustomControls.UserSearch();
            this.xListView = new TestListView.XListView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlus.BackgroundImage = global::WinFrmTalk.Properties.Resources.ic_friend_add_normal;
            this.btnPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(230,229,229);
            this.btnPlus.FlatAppearance.BorderSize = 0;
            this.btnPlus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(230,229,229);
            this.btnPlus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(230,229,229);
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlus.Location = new System.Drawing.Point(220, 28);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(25, 25);
            this.btnPlus.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btnPlus, "创建群组");
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Visible = false;
            // 
            // RecentSearch
            // 
            this.RecentSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(217)))), ((int)(((byte)(216)))));
            this.RecentSearch.Location = new System.Drawing.Point(13, 30);
            this.RecentSearch.LoseFocusResume = true;
            this.RecentSearch.Name = "RecentSearch";
            this.RecentSearch.Size = new System.Drawing.Size(198, 22);
            this.RecentSearch.TabIndex = 24;
            this.RecentSearch.Visible = false;
            // 
            // xListView
            // 
            this.xListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.xListView.Location = new System.Drawing.Point(0, 3);
            this.xListView.Name = "xListView";
            this.xListView.ScrollBarWidth = 10;
            this.xListView.Size = new System.Drawing.Size(260, 432);
            this.xListView.TabIndex = 23;
            // 
            // RecentListLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.RecentSearch);
            this.Controls.Add(this.xListView);
            this.Controls.Add(this.btnPlus);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RecentListLayout";
            this.Size = new System.Drawing.Size(260, 437);
            this.Load += new System.EventHandler(this.RecentListLayoutLoad);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPlus;
        private TestListView.XListView xListView;
        private UserSearch RecentSearch;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
