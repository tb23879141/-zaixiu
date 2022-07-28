namespace WinFrmTalk.View
{
    partial class FrmNewsTip
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNews = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.ptbHead = new System.Windows.Forms.PictureBox();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHead)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNews
            // 
            this.lblNews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNews.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNews.Location = new System.Drawing.Point(20, 80);
            this.lblNews.Name = "lblNews";
            this.lblNews.Size = new System.Drawing.Size(290, 110);
            this.lblNews.TabIndex = 6;
            this.lblNews.Text = "News";
            this.lblNews.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LblNews_MouseDoubleClick);
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblName.Location = new System.Drawing.Point(45, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(234, 28);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ptbHead
            // 
            this.ptbHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbHead.Location = new System.Drawing.Point(15, 20);
            this.ptbHead.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ptbHead.Name = "ptbHead";
            this.ptbHead.Size = new System.Drawing.Size(25, 25);
            this.ptbHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbHead.TabIndex = 8;
            this.ptbHead.TabStop = false;
            // 
            // lblLine
            // 
            this.lblLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLine.Location = new System.Drawing.Point(13, 214);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(300, 1);
            this.lblLine.TabIndex = 11;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblInfo.Location = new System.Drawing.Point(247, 225);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(31, 17);
            this.lblInfo.TabIndex = 12;
            this.lblInfo.Text = "Info";
            // 
            // FrmNewsTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(327, 255);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.ptbHead);
            this.Controls.Add(this.lblNews);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewsTip";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.ptbHead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNews;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox ptbHead;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblInfo;
    }
}