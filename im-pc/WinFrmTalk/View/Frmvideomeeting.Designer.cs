namespace WinFrmTalk.View
{
    partial class Frrmvideomeeting
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
            this.lbltitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblinvite = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.rbaudio = new System.Windows.Forms.PictureBox();
            this.rbhung = new System.Windows.Forms.PictureBox();
            this.rblound = new System.Windows.Forms.PictureBox();
            this.paljoins = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.rbaudio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbhung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rblound)).BeginInit();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
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
            this.lbltime.Text = "label4";
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
            this.rbhung.Location = new System.Drawing.Point(321, 623);
            this.rbhung.Name = "rbhung";
            this.rbhung.Size = new System.Drawing.Size(60, 60);
            this.rbhung.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rbhung.TabIndex = 12;
            this.rbhung.TabStop = false;
            this.rbhung.Click += new System.EventHandler(this.rbhung_Click);
            // 
            // rblound
            // 
            this.rblound.Location = new System.Drawing.Point(574, 623);
            this.rblound.Name = "rblound";
            this.rblound.Size = new System.Drawing.Size(60, 60);
            this.rblound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rblound.TabIndex = 13;
            this.rblound.TabStop = false;
            this.rblound.Click += new System.EventHandler(this.rblound_Click);
            // 
            // paljoins
            // 
            this.paljoins.Location = new System.Drawing.Point(85, 222);
            this.paljoins.Name = "paljoins";
            this.paljoins.Size = new System.Drawing.Size(549, 354);
            this.paljoins.TabIndex = 19;
            // 
            // Frrmvideomeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(755, 724);
            this.Controls.Add(this.paljoins);
            this.Controls.Add(this.lbltime);
            this.Controls.Add(this.rblound);
            this.Controls.Add(this.rbhung);
            this.Controls.Add(this.rbaudio);
            this.Controls.Add(this.lblinvite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbltitle);
            this.Name = "Frrmvideomeeting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "音频会议";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frrmvideomeeting_FormClosed);
            this.Load += new System.EventHandler(this.Frrmvideomeeting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rbaudio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbhung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rblound)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblinvite;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.PictureBox rbaudio;
        private System.Windows.Forms.PictureBox rbhung;
        private System.Windows.Forms.PictureBox rblound;
        private System.Windows.Forms.FlowLayoutPanel paljoins;
    }
}
