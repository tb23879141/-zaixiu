namespace WinFrmTalk.View
{
    partial class FrmAnswer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnswer));
            this.lblNickName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.rpbAnswer = new WinFrmTalk.RoundPicBox();
            this.rpboxClose = new WinFrmTalk.RoundPicBox();
            this.rpboxIcon = new WinFrmTalk.RoundPicBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.rpbAnswer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpboxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpboxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNickName
            // 
            this.lblNickName.BackColor = System.Drawing.Color.Black;
            this.lblNickName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNickName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNickName.Location = new System.Drawing.Point(7, 189);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(306, 16);
            this.lblNickName.TabIndex = 1;
            this.lblNickName.Text = "NULL";
            this.lblNickName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.Color.Black;
            this.lblType.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblType.Location = new System.Drawing.Point(7, 230);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(306, 12);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "语音呼叫...";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rpbAnswer
            // 
            this.rpbAnswer.isDrawRound = true;
            this.rpbAnswer.Location = new System.Drawing.Point(59, 394);
            this.rpbAnswer.Name = "rpbAnswer";
            this.rpbAnswer.Size = new System.Drawing.Size(60, 60);
            this.rpbAnswer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rpbAnswer.TabIndex = 4;
            this.rpbAnswer.TabStop = false;
            this.rpbAnswer.Click += new System.EventHandler(this.rpbAnswer_Click);
            // 
            // rpboxClose
            // 
            this.rpboxClose.isDrawRound = true;
            this.rpboxClose.Location = new System.Drawing.Point(199, 394);
            this.rpboxClose.Name = "rpboxClose";
            this.rpboxClose.Size = new System.Drawing.Size(60, 60);
            this.rpboxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rpboxClose.TabIndex = 3;
            this.rpboxClose.TabStop = false;
            this.rpboxClose.Click += new System.EventHandler(this.rpboxClose_Click_1);
            // 
            // rpboxIcon
            // 
            this.rpboxIcon.isDrawRound = true;
            this.rpboxIcon.Location = new System.Drawing.Point(120, 86);
            this.rpboxIcon.Name = "rpboxIcon";
            this.rpboxIcon.Size = new System.Drawing.Size(80, 80);
            this.rpboxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rpboxIcon.TabIndex = 0;
            this.rpboxIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(215, 461);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "挂断";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(76, 461);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "接听";
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
            this.pictureBox1.Click += new System.EventHandler(this.rpboxClose_Click_1);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.rpboxClose_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rpboxClose_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(283, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(37, 24);
            this.panel1.TabIndex = 15;
            this.panel1.Click += new System.EventHandler(this.rpboxClose_Click_1);
            this.panel1.MouseLeave += new System.EventHandler(this.rpboxClose_MouseLeave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rpboxClose_MouseMove);
            // 
            // FrmAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(320, 480);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.rpbAnswer);
            this.Controls.Add(this.rpboxClose);
            this.Controls.Add(this.lblNickName);
            this.Controls.Add(this.rpboxIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmAnswer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TitleNeed = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAnswer_FormClosed);
            this.Load += new System.EventHandler(this.FrmAnswer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rpbAnswer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpboxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpboxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundPicBox rpboxIcon;
        private System.Windows.Forms.Label lblNickName;
        private System.Windows.Forms.Label lblType;
        private RoundPicBox rpboxClose;
        private RoundPicBox rpbAnswer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}