namespace WinFrmTalk.View
{
    partial class FrmRecordVideo
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
            this.btnstart = new System.Windows.Forms.Button();
            this.btnstop = new System.Windows.Forms.Button();
            this.lbltime = new System.Windows.Forms.Label();
            this.btnpuse = new System.Windows.Forms.Button();
            this.btnreturn = new System.Windows.Forms.Button();
            this.btnsend = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pictureBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnstart
            // 
            this.btnstart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnstart.BackColor = System.Drawing.Color.Transparent;
            this.btnstart.BackgroundImage = global::WinFrmTalk.Properties.Resources.videoStart;
            this.btnstart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnstart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnstart.FlatAppearance.BorderSize = 0;
            this.btnstart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnstart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnstart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstart.Location = new System.Drawing.Point(371, 377);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(60, 60);
            this.btnstart.TabIndex = 12;
            this.btnstart.UseVisualStyleBackColor = false;
            this.btnstart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Btnstart_MouseClick);
            // 
            // btnstop
            // 
            this.btnstop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnstop.BackColor = System.Drawing.Color.Transparent;
            this.btnstop.BackgroundImage = global::WinFrmTalk.Properties.Resources.videoStop;
            this.btnstop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnstop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnstop.FlatAppearance.BorderSize = 0;
            this.btnstop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnstop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnstop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstop.Location = new System.Drawing.Point(371, 377);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(60, 60);
            this.btnstop.TabIndex = 39;
            this.btnstop.UseVisualStyleBackColor = false;
            this.btnstop.Visible = false;
            this.btnstop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Btnstop_MouseClick);
            // 
            // lbltime
            // 
            this.lbltime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbltime.AutoSize = true;
            this.lbltime.BackColor = System.Drawing.Color.White;
            this.lbltime.Location = new System.Drawing.Point(379, 353);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(41, 12);
            this.lbltime.TabIndex = 40;
            this.lbltime.Text = "label1";
            this.lbltime.Visible = false;
            // 
            // btnpuse
            // 
            this.btnpuse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnpuse.BackColor = System.Drawing.Color.Transparent;
            this.btnpuse.BackgroundImage = global::WinFrmTalk.Properties.Resources.videoSpuse;
            this.btnpuse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnpuse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnpuse.FlatAppearance.BorderSize = 0;
            this.btnpuse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnpuse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnpuse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpuse.Location = new System.Drawing.Point(510, 407);
            this.btnpuse.Name = "btnpuse";
            this.btnpuse.Size = new System.Drawing.Size(30, 30);
            this.btnpuse.TabIndex = 20;
            this.btnpuse.Tag = "暂停";
            this.btnpuse.UseVisualStyleBackColor = false;
            this.btnpuse.Visible = false;
            // 
            // btnreturn
            // 
            this.btnreturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnreturn.BackColor = System.Drawing.Color.Transparent;
            this.btnreturn.BackgroundImage = global::WinFrmTalk.Properties.Resources.photoReten;
            this.btnreturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnreturn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnreturn.FlatAppearance.BorderSize = 0;
            this.btnreturn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnreturn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnreturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreturn.Location = new System.Drawing.Point(256, 407);
            this.btnreturn.Name = "btnreturn";
            this.btnreturn.Size = new System.Drawing.Size(30, 30);
            this.btnreturn.TabIndex = 41;
            this.btnreturn.UseVisualStyleBackColor = false;
            this.btnreturn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Btnreturn_MouseClick);
            // 
            // btnsend
            // 
            this.btnsend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnsend.BackColor = System.Drawing.Color.Transparent;
            this.btnsend.BackgroundImage = global::WinFrmTalk.Properties.Resources.photoSend;
            this.btnsend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsend.FlatAppearance.BorderSize = 0;
            this.btnsend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsend.Location = new System.Drawing.Point(510, 407);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(30, 30);
            this.btnsend.TabIndex = 42;
            this.btnsend.UseVisualStyleBackColor = false;
            this.btnsend.Visible = false;
            this.btnsend.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Btnsend_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Controls.Add(this.btnsend);
            this.pictureBox1.Controls.Add(this.btnreturn);
            this.pictureBox1.Controls.Add(this.btnpuse);
            this.pictureBox1.Controls.Add(this.lbltime);
            this.pictureBox1.Controls.Add(this.btnstop);
            this.pictureBox1.Controls.Add(this.btnstart);
            this.pictureBox1.Location = new System.Drawing.Point(4, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(801, 451);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // FrmRecordVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(809, 483);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "FrmRecordVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "录像";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmRecordVideo_FormClosed);
            this.Load += new System.EventHandler(this.FrmRecordVideo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pictureBox1.ResumeLayout(false);
            this.pictureBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Button btnstop;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Button btnpuse;
        private System.Windows.Forms.Button btnreturn;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}