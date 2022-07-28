namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    partial class GroupPageNotify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupPageNotify));
            this.limitPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.xScrollBar1 = new TestListView.XScrollBar();
            this.limitPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // limitPanel
            // 
            this.limitPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.limitPanel.Controls.Add(this.flowLayoutPanel1);
            this.limitPanel.Location = new System.Drawing.Point(45, 20);
            this.limitPanel.Name = "limitPanel";
            this.limitPanel.Size = new System.Drawing.Size(600, 600);
            this.limitPanel.TabIndex = 5;
            this.limitPanel.SizeChanged += new System.EventHandler(this.limitPanel_SizeChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(600, 400);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // xScrollBar1
            // 
            this.xScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xScrollBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xScrollBar1.BackgroundImage")));
            this.xScrollBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xScrollBar1.Location = new System.Drawing.Point(660, 20);
            this.xScrollBar1.Name = "xScrollBar1";
            this.xScrollBar1.Size = new System.Drawing.Size(10, 600);
            this.xScrollBar1.TabIndex = 6;
            // 
            // GroupPageNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.xScrollBar1);
            this.Controls.Add(this.limitPanel);
            this.Name = "GroupPageNotify";
            this.Size = new System.Drawing.Size(670, 640);
            this.limitPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel limitPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private TestListView.XScrollBar xScrollBar1;
    }
}
