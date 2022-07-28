
namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    partial class FrmDetailsSocial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetailsSocial));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tvTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tvTime = new System.Windows.Forms.Label();
            this.tvName = new System.Windows.Forms.Label();
            this.ivIcon = new System.Windows.Forms.PictureBox();
            this.limitPanel = new System.Windows.Forms.Panel();
            this.xScrollBar1 = new TestListView.XScrollBar();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ivIcon)).BeginInit();
            this.limitPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel1.Controls.Add(this.tvTitle);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(430, 483);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tvTitle
            // 
            this.tvTitle.AutoEllipsis = true;
            this.tvTitle.AutoSize = true;
            this.tvTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tvTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvTitle.Location = new System.Drawing.Point(3, 0);
            this.tvTitle.MaximumSize = new System.Drawing.Size(430, 50);
            this.tvTitle.Name = "tvTitle";
            this.tvTitle.Size = new System.Drawing.Size(84, 25);
            this.tvTitle.TabIndex = 8;
            this.tvTitle.Tag = "1";
            this.tvTitle.Text = "提供资源";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tvTime);
            this.panel2.Controls.Add(this.tvName);
            this.panel2.Controls.Add(this.ivIcon);
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 60);
            this.panel2.TabIndex = 14;
            // 
            // tvTime
            // 
            this.tvTime.AutoSize = true;
            this.tvTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tvTime.Location = new System.Drawing.Point(45, 29);
            this.tvTime.Name = "tvTime";
            this.tvTime.Size = new System.Drawing.Size(44, 17);
            this.tvTime.TabIndex = 13;
            this.tvTime.Text = "王冰冰";
            // 
            // tvName
            // 
            this.tvName.AutoSize = true;
            this.tvName.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tvName.Location = new System.Drawing.Point(44, 6);
            this.tvName.Name = "tvName";
            this.tvName.Size = new System.Drawing.Size(51, 20);
            this.tvName.TabIndex = 12;
            this.tvName.Text = "王冰冰";
            // 
            // ivIcon
            // 
            this.ivIcon.Location = new System.Drawing.Point(0, 7);
            this.ivIcon.Name = "ivIcon";
            this.ivIcon.Size = new System.Drawing.Size(40, 40);
            this.ivIcon.TabIndex = 11;
            this.ivIcon.TabStop = false;
            // 
            // limitPanel
            // 
            this.limitPanel.Controls.Add(this.flowLayoutPanel1);
            this.limitPanel.Location = new System.Drawing.Point(58, 40);
            this.limitPanel.Name = "limitPanel";
            this.limitPanel.Size = new System.Drawing.Size(430, 583);
            this.limitPanel.TabIndex = 14;
            // 
            // xScrollBar1
            // 
            this.xScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xScrollBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xScrollBar1.BackgroundImage")));
            this.xScrollBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xScrollBar1.Location = new System.Drawing.Point(539, 40);
            this.xScrollBar1.Name = "xScrollBar1";
            this.xScrollBar1.Size = new System.Drawing.Size(10, 583);
            this.xScrollBar1.TabIndex = 18;
            // 
            // FrmDetailsSocial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(550, 640);
            this.Controls.Add(this.xScrollBar1);
            this.Controls.Add(this.limitPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmDetailsSocial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "秀吧";
            this.TitleNeed = false;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ivIcon)).EndInit();
            this.limitPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label tvTitle;
        private System.Windows.Forms.PictureBox ivIcon;
        private System.Windows.Forms.Label tvName;
        private System.Windows.Forms.Label tvTime;
        private System.Windows.Forms.Panel limitPanel;
        private System.Windows.Forms.Panel panel2;
        private TestListView.XScrollBar xScrollBar1;
    }
}