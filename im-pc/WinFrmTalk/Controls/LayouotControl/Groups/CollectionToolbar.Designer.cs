namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    partial class CollectionToolbar
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
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // tvName
            // 
            this.tvName.AutoEllipsis = true;
            this.tvName.AutoSize = true;
            this.tvName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvName.Location = new System.Drawing.Point(35, 8);
            this.tvName.MaximumSize = new System.Drawing.Size(200, 20);
            this.tvName.Name = "tvName";
            this.tvName.Size = new System.Drawing.Size(175, 20);
            this.tvName.TabIndex = 1;
            this.tvName.Text = "Folder Name11111111";
            // 
            // tvCount
            // 
            this.tvCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tvCount.AutoSize = true;
            this.tvCount.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tvCount.Location = new System.Drawing.Point(237, 9);
            this.tvCount.Name = "tvCount";
            this.tvCount.Size = new System.Drawing.Size(38, 19);
            this.tvCount.TabIndex = 2;
            this.tvCount.Text = "10张";
            this.tvCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // CollectionToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvCount);
            this.Controls.Add(this.tvName);
            this.Controls.Add(this.btnBack);
            this.Name = "CollectionToolbar";
            this.Size = new System.Drawing.Size(275, 36);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnBack;
        private System.Windows.Forms.Label tvCount;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label tvName;
    }
}
