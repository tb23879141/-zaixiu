namespace WinFrmTalk.Controls.CustomControls
{
    partial class CheckSexBoxEx
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
            this.btnWoMan = new System.Windows.Forms.Label();
            this.btnMan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnWoMan
            // 
            this.btnWoMan.BackColor = System.Drawing.Color.Transparent;
            this.btnWoMan.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnWoMan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnWoMan.Location = new System.Drawing.Point(45, -1);
            this.btnWoMan.Name = "btnWoMan";
            this.btnWoMan.Size = new System.Drawing.Size(45, 26);
            this.btnWoMan.TabIndex = 1;
            this.btnWoMan.Text = "女";
            this.btnWoMan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMan
            // 
            this.btnMan.BackColor = System.Drawing.Color.Transparent;
            this.btnMan.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnMan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnMan.Location = new System.Drawing.Point(0, -1);
            this.btnMan.Name = "btnMan";
            this.btnMan.Size = new System.Drawing.Size(45, 26);
            this.btnMan.TabIndex = 2;
            this.btnMan.Text = "男";
            this.btnMan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckSexBoxEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WinFrmTalk.Properties.Resources.register_sex0;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.btnMan);
            this.Controls.Add(this.btnWoMan);
            this.DoubleBuffered = true;
            this.Name = "CheckSexBoxEx";
            this.Size = new System.Drawing.Size(90, 26);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label btnWoMan;
        private System.Windows.Forms.Label btnMan;
    }
}
