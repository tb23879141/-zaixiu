namespace WinFrmTalk.View
{
    partial class FrmVoiceMeetRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVoiceMeetRoom));
            this.lbltitle = new System.Windows.Forms.Label();
            this.lblinvite = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.rbaudio = new System.Windows.Forms.PictureBox();
            this.rbhung = new System.Windows.Forms.PictureBox();
            this.paljoins = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loding1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rbaudio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbhung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loding1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltitle
            // 
            this.lbltitle.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltitle.ForeColor = System.Drawing.Color.White;
            this.lbltitle.Location = new System.Drawing.Point(7, 45);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(741, 26);
            this.lbltitle.TabIndex = 6;
            this.lbltitle.Text = "label1";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblinvite
            // 
            this.lblinvite.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblinvite.ForeColor = System.Drawing.Color.White;
            this.lblinvite.Location = new System.Drawing.Point(7, 102);
            this.lblinvite.Name = "lblinvite";
            this.lblinvite.Size = new System.Drawing.Size(741, 26);
            this.lblinvite.TabIndex = 8;
            this.lblinvite.Text = "label3";
            this.lblinvite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltime
            // 
            this.lbltime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltime.ForeColor = System.Drawing.Color.White;
            this.lbltime.Location = new System.Drawing.Point(7, 147);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(741, 26);
            this.lbltime.TabIndex = 9;
            this.lbltime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbaudio
            // 
            this.rbaudio.Location = new System.Drawing.Point(85, 623);
            this.rbaudio.Name = "rbaudio";
            this.rbaudio.Size = new System.Drawing.Size(60, 60);
            this.rbaudio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rbaudio.TabIndex = 11;
            this.rbaudio.TabStop = false;
            this.rbaudio.Click += new System.EventHandler(this.rbaudio_Click);
            // 
            // rbhung
            // 
            this.rbhung.Location = new System.Drawing.Point(574, 623);
            this.rbhung.Name = "rbhung";
            this.rbhung.Size = new System.Drawing.Size(60, 60);
            this.rbhung.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rbhung.TabIndex = 12;
            this.rbhung.TabStop = false;
            this.rbhung.Click += new System.EventHandler(this.OnClose_Click);
            // 
            // paljoins
            // 
            this.paljoins.Location = new System.Drawing.Point(85, 222);
            this.paljoins.Name = "paljoins";
            this.paljoins.Size = new System.Drawing.Size(549, 354);
            this.paljoins.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 5);
            this.panel1.TabIndex = 23;
            // 
            // loding1
            // 
            this.loding1.Image = global::WinFrmTalk.Properties.Resources.load;
            this.loding1.Location = new System.Drawing.Point(349, 313);
            this.loding1.Name = "loding1";
            this.loding1.Size = new System.Drawing.Size(50, 50);
            this.loding1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loding1.TabIndex = 0;
            this.loding1.TabStop = false;
            // 
            // FrmVoiceMeetRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(755, 724);
            this.Controls.Add(this.loding1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.paljoins);
            this.Controls.Add(this.lbltime);
            this.Controls.Add(this.rbhung);
            this.Controls.Add(this.rbaudio);
            this.Controls.Add(this.lblinvite);
            this.Controls.Add(this.lbltitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmVoiceMeetRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "语音会议";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmVoiceMeetRoom_FormClosed);
            this.Load += new System.EventHandler(this.FrmVoiceMeetRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rbaudio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbhung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loding1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Label lblinvite;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.PictureBox rbaudio;
        private System.Windows.Forms.PictureBox rbhung;
        private System.Windows.Forms.FlowLayoutPanel paljoins;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox loding1;
    }
}
