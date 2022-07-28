
namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    partial class FrmDetailsResource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetailsResource));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tvProvide = new System.Windows.Forms.Label();
            this.tvDemain = new System.Windows.Forms.Label();
            this.tvTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(430, 483);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tvProvide);
            this.panel2.Controls.Add(this.tvDemain);
            this.panel2.Controls.Add(this.tvTime);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tvName);
            this.panel2.Controls.Add(this.ivIcon);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 95);
            this.panel2.TabIndex = 14;
            // 
            // tvProvide
            // 
            this.tvProvide.AutoSize = true;
            this.tvProvide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvProvide.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tvProvide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvProvide.Location = new System.Drawing.Point(0, 0);
            this.tvProvide.Name = "tvProvide";
            this.tvProvide.Size = new System.Drawing.Size(84, 25);
            this.tvProvide.TabIndex = 8;
            this.tvProvide.Tag = "1";
            this.tvProvide.Text = "提供资源";
            this.tvProvide.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Title_MouseClick);
            // 
            // tvDemain
            // 
            this.tvDemain.AutoSize = true;
            this.tvDemain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvDemain.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tvDemain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tvDemain.Location = new System.Drawing.Point(103, 0);
            this.tvDemain.Name = "tvDemain";
            this.tvDemain.Size = new System.Drawing.Size(84, 25);
            this.tvDemain.TabIndex = 9;
            this.tvDemain.Tag = "0";
            this.tvDemain.Text = "所需资源";
            this.tvDemain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Title_MouseClick);
            // 
            // tvTime
            // 
            this.tvTime.AutoSize = true;
            this.tvTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tvTime.Location = new System.Drawing.Point(45, 62);
            this.tvTime.Name = "tvTime";
            this.tvTime.Size = new System.Drawing.Size(44, 17);
            this.tvTime.TabIndex = 13;
            this.tvTime.Text = "王冰冰";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label2.Location = new System.Drawing.Point(90, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1, 18);
            this.label2.TabIndex = 10;
            // 
            // tvName
            // 
            this.tvName.AutoSize = true;
            this.tvName.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tvName.Location = new System.Drawing.Point(44, 39);
            this.tvName.Name = "tvName";
            this.tvName.Size = new System.Drawing.Size(51, 20);
            this.tvName.TabIndex = 12;
            this.tvName.Text = "王冰冰";
            // 
            // ivIcon
            // 
            this.ivIcon.Location = new System.Drawing.Point(0, 40);
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
            this.xScrollBar1.ScrollChangeListener += new TestListView.XScrollBar.EventProgressHandler(this.xScrollBar1_ScrollChangeListener);
            // 
            // FrmDetailsResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(550, 640);
            this.Controls.Add(this.xScrollBar1);
            this.Controls.Add(this.limitPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmDetailsResource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TitleNeed = false;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ivIcon)).EndInit();
            this.limitPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label tvProvide;
        private System.Windows.Forms.Label tvDemain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ivIcon;
        private System.Windows.Forms.Label tvName;
        private System.Windows.Forms.Label tvTime;
        private System.Windows.Forms.Panel limitPanel;
        private System.Windows.Forms.Panel panel2;
        private TestListView.XScrollBar xScrollBar1;
    }
}