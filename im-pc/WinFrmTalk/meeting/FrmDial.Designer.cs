namespace WinFrmTalk.View
{
    partial class FrmDial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDial));
            this.lblNickName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rpbClose = new WinFrmTalk.RoundPicBox();
            this.rpbInco = new WinFrmTalk.RoundPicBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rpbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpbInco)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNickName
            // 
            this.lblNickName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNickName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNickName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNickName.Location = new System.Drawing.Point(87, 208);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(146, 16);
            this.lblNickName.TabIndex = 2;
            this.lblNickName.Text = "bbh哈";
            this.lblNickName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(95, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "正在等待对接受邀请...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rpbClose
            // 
            this.rpbClose.isDrawRound = true;
            this.rpbClose.Location = new System.Drawing.Point(130, 388);
            this.rpbClose.Name = "rpbClose";
            this.rpbClose.Size = new System.Drawing.Size(60, 60);
            this.rpbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rpbClose.TabIndex = 1;
            this.rpbClose.TabStop = false;
            this.rpbClose.Click += new System.EventHandler(this.rpbClose_Click);
            // 
            // rpbInco
            // 
            this.rpbInco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rpbInco.isDrawRound = true;
            this.rpbInco.Location = new System.Drawing.Point(120, 111);
            this.rpbInco.Name = "rpbInco";
            this.rpbInco.Size = new System.Drawing.Size(80, 80);
            this.rpbInco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rpbInco.TabIndex = 0;
            this.rpbInco.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(149, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "挂断";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(283, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(37, 24);
            this.panel1.TabIndex = 16;
            this.panel1.Click += new System.EventHandler(this.rpbClose_Click);
            this.panel1.MouseLeave += new System.EventHandler(this.rpbClose_MouseLeave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rpbClose_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 24);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.rpbClose_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.rpbClose_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rpbClose_MouseMove);
            // 
            // FrmDial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(320, 480);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNickName);
            this.Controls.Add(this.rpbClose);
            this.Controls.Add(this.rpbInco);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmDial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TitleNeed = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDial_FormClosed);
            this.Load += new System.EventHandler(this.FrmDial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rpbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpbInco)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundPicBox rpbInco;
        private RoundPicBox rpbClose;
        private System.Windows.Forms.Label lblNickName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}