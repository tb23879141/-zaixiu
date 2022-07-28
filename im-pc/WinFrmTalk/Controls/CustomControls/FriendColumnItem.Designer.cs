namespace WinFrmTalk.Controls.CustomControls
{
    partial class FriendColumnItem
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
            this.line = new System.Windows.Forms.Label();
            this.lab_name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // line
            // 
            this.line.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line.BackColor = System.Drawing.Color.Gainsboro;
            this.line.Location = new System.Drawing.Point(0, 1);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(260, 1);
            this.line.TabIndex = 44;
            // 
            // lab_name
            // 
            this.lab_name.AutoSize = true;
            this.lab_name.BackColor = System.Drawing.Color.Transparent;
            this.lab_name.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lab_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.lab_name.Location = new System.Drawing.Point(8, 13);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(39, 17);
            this.lab_name.TabIndex = 45;
            this.lab_name.Text = "NULL";
            this.lab_name.UseMnemonic = false;
            // 
            // FriendColumnItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lab_name);
            this.Controls.Add(this.line);
            this.Name = "FriendColumnItem";
            this.Size = new System.Drawing.Size(260, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label line;
        public System.Windows.Forms.Label lab_name;
    }
}
