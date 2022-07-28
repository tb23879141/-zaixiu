namespace WinFrmTalk.Live.Controls
{
    partial class FrmGiftTip
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
            this.components = new System.ComponentModel.Container();
            this.lblname = new System.Windows.Forms.Label();
            this.picgift = new System.Windows.Forms.PictureBox();
            this.lblcount = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pic_head = new WinFrmTalk.RoundPicBox();
            this.lbl_giftname = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picgift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_head)).BeginInit();
            this.SuspendLayout();
            // 
            // lblname
            // 
            this.lblname.AutoEllipsis = true;
            this.lblname.BackColor = System.Drawing.Color.Transparent;
            this.lblname.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblname.ForeColor = System.Drawing.Color.White;
            this.lblname.Location = new System.Drawing.Point(70, 4);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(118, 22);
            this.lblname.TabIndex = 0;
            this.lblname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picgift
            // 
            this.picgift.BackColor = System.Drawing.Color.Transparent;
            this.picgift.Location = new System.Drawing.Point(207, 1);
            this.picgift.Name = "picgift";
            this.picgift.Size = new System.Drawing.Size(58, 58);
            this.picgift.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picgift.TabIndex = 1;
            this.picgift.TabStop = false;
            // 
            // lblcount
            // 
            this.lblcount.BackColor = System.Drawing.Color.Transparent;
            this.lblcount.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcount.ForeColor = System.Drawing.Color.Lime;
            this.lblcount.Location = new System.Drawing.Point(267, 19);
            this.lblcount.Name = "lblcount";
            this.lblcount.Size = new System.Drawing.Size(48, 27);
            this.lblcount.TabIndex = 2;
            this.lblcount.Text = "x36";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pic_head
            // 
            this.pic_head.BackColor = System.Drawing.Color.Transparent;
            this.pic_head.isDrawRound = true;
            this.pic_head.Location = new System.Drawing.Point(7, 4);
            this.pic_head.Name = "pic_head";
            this.pic_head.Size = new System.Drawing.Size(50, 50);
            this.pic_head.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_head.TabIndex = 3;
            this.pic_head.TabStop = false;
            // 
            // lbl_giftname
            // 
            this.lbl_giftname.AutoEllipsis = true;
            this.lbl_giftname.BackColor = System.Drawing.Color.Transparent;
            this.lbl_giftname.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_giftname.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_giftname.Location = new System.Drawing.Point(72, 31);
            this.lbl_giftname.Name = "lbl_giftname";
            this.lbl_giftname.Size = new System.Drawing.Size(115, 22);
            this.lbl_giftname.TabIndex = 4;
            this.lbl_giftname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmGiftTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(308, 60);
            this.Controls.Add(this.lbl_giftname);
            this.Controls.Add(this.pic_head);
            this.Controls.Add(this.lblcount);
            this.Controls.Add(this.picgift);
            this.Controls.Add(this.lblname);
            this.DoubleBuffered = true;
            this.IsShowRegion = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGiftTip";
            this.RegionRadius = 50;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "";
            this.TransparencyKey = System.Drawing.Color.AliceBlue;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGiftTip_FormClosed);
            this.Load += new System.EventHandler(this.FrmGiftTip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picgift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_head)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.PictureBox picgift;
        private System.Windows.Forms.Label lblcount;
        private System.Windows.Forms.Timer timer1;
        private RoundPicBox pic_head;
        private System.Windows.Forms.Label lbl_giftname;
    }
}