namespace WinFrmTalk.Controls
{
    partial class ChatItem
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
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.pboxHead = new WinFrmTalk.RoundPicBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxHead)).BeginInit();
            this.SuspendLayout();
            // 
            // skinLine1
            // 
            this.skinLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.skinLine1.LineColor = System.Drawing.Color.Black;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(60, 79);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(495, 1);
            this.skinLine1.TabIndex = 23;
            this.skinLine1.Text = "skinLine1";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblName.Location = new System.Drawing.Point(60, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 17);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "Name";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblDateTime.Location = new System.Drawing.Point(466, 20);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(95, 17);
            this.lblDateTime.TabIndex = 19;
            this.lblDateTime.Text = "2019/11/11";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pboxHead
            // 
            this.pboxHead.isDrawRound = true;
            this.pboxHead.Location = new System.Drawing.Point(10, 20);
            this.pboxHead.Name = "pboxHead";
            this.pboxHead.Size = new System.Drawing.Size(35, 35);
            this.pboxHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxHead.TabIndex = 21;
            this.pboxHead.TabStop = false;
            // 
            // ChatItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.pboxHead);
            this.Controls.Add(this.lblName);
            this.Name = "ChatItem";
            this.Size = new System.Drawing.Size(564, 80);
            ((System.ComponentModel.ISupportInitialize)(this.pboxHead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLine skinLine1;
        public RoundPicBox pboxHead;
        public System.Windows.Forms.Label lblDateTime;
        public System.Windows.Forms.Label lblName;
    }
}
