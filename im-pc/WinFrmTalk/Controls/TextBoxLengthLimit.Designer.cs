namespace WinFrmTalk.Controls
{
    partial class TextBoxLengthLimit
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
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContent.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtContent.Location = new System.Drawing.Point(6, 6);
            this.txtContent.MaxLength = 100;
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(268, 70);
            this.txtContent.TabIndex = 0;
            this.txtContent.TextChanged += new System.EventHandler(this.TxtContent_TextChanged);
            // 
            // lblNumber
            // 
            this.lblNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblNumber.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNumber.ForeColor = System.Drawing.Color.Gray;
            this.lblNumber.Location = new System.Drawing.Point(204, 79);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(70, 18);
            this.lblNumber.TabIndex = 1;
            this.lblNumber.Text = "0/100";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextBoxLengthLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.txtContent);
            this.Name = "TextBoxLengthLimit";
            this.Size = new System.Drawing.Size(280, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblNumber;
    }
}
