namespace WinFrmTalk
{
    partial class FriendListLayout
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
            this.searchTime = new System.Windows.Forms.Timer(this.components);
            this.xListView = new TestListView.XListView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // searchTime
            // 
            this.searchTime.Interval = 300;
            this.searchTime.Tick += new System.EventHandler(this.searchTime_Tick);
            // 
            // xListView
            // 
            this.xListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.xListView.Location = new System.Drawing.Point(0, 3);
            this.xListView.Name = "xListView";
            this.xListView.ScrollBarWidth = 10;
            this.xListView.Size = new System.Drawing.Size(235, 432);
            this.xListView.TabIndex = 24;
            // 
            // FriendListLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.xListView);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FriendListLayout";
            this.Size = new System.Drawing.Size(235, 437);
            this.Load += new System.EventHandler(this.MainListLayout_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer searchTime;
        private TestListView.XListView xListView;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
