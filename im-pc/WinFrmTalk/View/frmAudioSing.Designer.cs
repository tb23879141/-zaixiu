namespace WinFrmTalk.View
{
    partial class frmAudioSing
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
            this.rbhung = new System.Windows.Forms.PictureBox();
            this.rbaudio = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.lblinvite = new System.Windows.Forms.Label();
            this.pichead = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rbhung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbaudio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pichead)).BeginInit();
            this.SuspendLayout();
            // 
            // rbhung
            // 
            this.rbhung.Location = new System.Drawing.Point(574, 621);
            this.rbhung.Name = "rbhung";
            this.rbhung.Size = new System.Drawing.Size(60, 60);
            this.rbhung.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rbhung.TabIndex = 25;
            this.rbhung.TabStop = false;
            this.rbhung.Click += new System.EventHandler(this.rbhung_Click);
            // 
            // rbaudio
            // 
            this.rbaudio.Location = new System.Drawing.Point(85, 621);
            this.rbaudio.Name = "rbaudio";
            this.rbaudio.Size = new System.Drawing.Size(60, 60);
            this.rbaudio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rbaudio.TabIndex = 24;
            this.rbaudio.TabStop = false;
            this.rbaudio.Click += new System.EventHandler(this.rbaudio_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "label2";
            // 
            // lbltime
            // 
            this.lbltime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltime.ForeColor = System.Drawing.Color.White;
            this.lbltime.Location = new System.Drawing.Point(7, 417);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(741, 26);
            this.lbltime.TabIndex = 23;
            this.lbltime.Text = "label4";
            this.lbltime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblinvite
            // 
            this.lblinvite.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblinvite.ForeColor = System.Drawing.Color.White;
            this.lblinvite.Location = new System.Drawing.Point(7, 363);
            this.lblinvite.Name = "lblinvite";
            this.lblinvite.Size = new System.Drawing.Size(741, 26);
            this.lblinvite.TabIndex = 22;
            this.lblinvite.Text = "label3";
            this.lblinvite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pichead
            // 
            this.pichead.Location = new System.Drawing.Point(317, 207);
            this.pichead.Name = "pichead";
            this.pichead.Size = new System.Drawing.Size(120, 120);
            this.pichead.TabIndex = 32;
            this.pichead.TabStop = false;
            // 
            // frmAudioSing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(755, 724);
            this.Controls.Add(this.pichead);
            this.Controls.Add(this.lbltime);
            this.Controls.Add(this.rbhung);
            this.Controls.Add(this.rbaudio);
            this.Controls.Add(this.lblinvite);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "frmAudioSing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAudioSing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAudioSing_FormClosed);
            this.Load += new System.EventHandler(this.frmAudioSing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rbhung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbaudio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pichead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox rbhung;
        private System.Windows.Forms.PictureBox rbaudio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Label lblinvite;
        private System.Windows.Forms.PictureBox pichead;
    }
}