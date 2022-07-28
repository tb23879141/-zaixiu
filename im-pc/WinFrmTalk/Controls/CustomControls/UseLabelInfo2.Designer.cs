using TestListView;

namespace WinFrmTalk.Controls.CustomControls
{
    partial class UseLabelInfo2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UseLabelInfo2));
            this.label1 = new System.Windows.Forms.Label();
            this.tvName = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.limitPanel = new System.Windows.Forms.Panel();
            this.xScrollBar1 = new TestListView.XScrollBar();
            this.limitPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(0, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(724, 1);
            this.label1.TabIndex = 1;
            // 
            // tvName
            // 
            this.tvName.AutoSize = true;
            this.tvName.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvName.ForeColor = System.Drawing.Color.Black;
            this.tvName.Location = new System.Drawing.Point(20, 15);
            this.tvName.Name = "tvName";
            this.tvName.Size = new System.Drawing.Size(0, 21);
            this.tvName.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(600, 412);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // limitPanel
            // 
            this.limitPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.limitPanel.Controls.Add(this.flowLayoutPanel1);
            this.limitPanel.Location = new System.Drawing.Point(55, 53);
            this.limitPanel.Name = "limitPanel";
            this.limitPanel.Size = new System.Drawing.Size(600, 600);
            this.limitPanel.TabIndex = 4;
            // 
            // xScrollBar1
            // 
            this.xScrollBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xScrollBar1.BackgroundImage")));
            this.xScrollBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xScrollBar1.Location = new System.Drawing.Point(711, 53);
            this.xScrollBar1.Name = "xScrollBar1";
            this.xScrollBar1.Size = new System.Drawing.Size(10, 600);
            this.xScrollBar1.TabIndex = 5;
            this.xScrollBar1.Visible = false;
            // 
            // UseLabelInfo2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.xScrollBar1);
            this.Controls.Add(this.limitPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvName);
            this.Name = "UseLabelInfo2";
            this.Size = new System.Drawing.Size(725, 660);
            this.limitPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tvName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel limitPanel;
        private XScrollBar xScrollBar1;
    }
}
