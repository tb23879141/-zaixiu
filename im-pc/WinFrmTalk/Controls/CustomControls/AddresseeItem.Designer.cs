namespace WinFrmTalk.Controls.CustomControls
{
    partial class AddresseeItem
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
            this.labRemove = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(8, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(85, 19);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "收信人名字";
            // 
            // labRemove
            // 
            this.labRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labRemove.Image = global::WinFrmTalk.Properties.Resources.ClosFrom;
            this.labRemove.Location = new System.Drawing.Point(104, 9);
            this.labRemove.Name = "labRemove";
            this.labRemove.Size = new System.Drawing.Size(20, 20);
            this.labRemove.TabIndex = 1;
            this.labRemove.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labRemove_MouseClick);
            // 
            // AddresseeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.labRemove);
            this.Controls.Add(this.lblName);
            this.Name = "AddresseeItem";
            this.Size = new System.Drawing.Size(132, 37);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label labRemove;
    }
}
