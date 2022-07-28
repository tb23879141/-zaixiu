namespace WinFrmTalk.Customer
{
    partial class CustomerReplyItem
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(23, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Admin";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lblTime.Location = new System.Drawing.Point(23, 39);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(126, 17);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "2019-12-23 11:40:38";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lblContent.Location = new System.Drawing.Point(23, 66);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(104, 17);
            this.lblContent.TabIndex = 2;
            this.lblContent.Text = "这是一条回复信息";
            // 
            // CustomerReplyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblName);
            this.Name = "CustomerReplyItem";
            this.Size = new System.Drawing.Size(380, 98);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblContent;
    }
}
