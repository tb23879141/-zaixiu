namespace WinFrmTalk.Live.Controls
{
    partial class UserLiveTitle
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_tips = new System.Windows.Forms.Label();
            this.lbl_All = new System.Windows.Forms.Label();
            this.PalAll = new System.Windows.Forms.Panel();
            this.pic_check = new System.Windows.Forms.PictureBox();
            this.pic_sex = new System.Windows.Forms.PictureBox();
            this.picRoom = new WinFrmTalk.RoundPicBox();
            this.lblClose = new System.Windows.Forms.Label();
            this.PalAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_check)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoEllipsis = true;
            this.lbl_name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lbl_name.Location = new System.Drawing.Point(78, 15);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(466, 19);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "label1";
            // 
            // lbl_tips
            // 
            this.lbl_tips.AutoEllipsis = true;
            this.lbl_tips.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_tips.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbl_tips.Location = new System.Drawing.Point(103, 49);
            this.lbl_tips.Name = "lbl_tips";
            this.lbl_tips.Size = new System.Drawing.Size(60, 14);
            this.lbl_tips.TabIndex = 3;
            this.lbl_tips.Text = "label2";
            // 
            // lbl_All
            // 
            this.lbl_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_All.AutoEllipsis = true;
            this.lbl_All.AutoSize = true;
            this.lbl_All.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_All.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lbl_All.Location = new System.Drawing.Point(38, 12);
            this.lbl_All.Name = "lbl_All";
            this.lbl_All.Size = new System.Drawing.Size(42, 21);
            this.lbl_All.TabIndex = 10;
            this.lbl_All.Text = "全屏";
            this.lbl_All.Click += new System.EventHandler(this.panel1_Click);
            // 
            // PalAll
            // 
            this.PalAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PalAll.Controls.Add(this.pic_check);
            this.PalAll.Controls.Add(this.lbl_All);
            this.PalAll.Location = new System.Drawing.Point(732, 17);
            this.PalAll.Name = "PalAll";
            this.PalAll.Size = new System.Drawing.Size(86, 46);
            this.PalAll.TabIndex = 11;
            this.PalAll.Click += new System.EventHandler(this.panel1_Click);
            // 
            // pic_check
            // 
            this.pic_check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_check.Image = global::WinFrmTalk.Properties.Resources.Maxsize;
            this.pic_check.Location = new System.Drawing.Point(12, 13);
            this.pic_check.Name = "pic_check";
            this.pic_check.Size = new System.Drawing.Size(20, 20);
            this.pic_check.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_check.TabIndex = 11;
            this.pic_check.TabStop = false;
            this.pic_check.Click += new System.EventHandler(this.panel1_Click);
            // 
            // pic_sex
            // 
            this.pic_sex.Image = global::WinFrmTalk.Properties.Resources.Numbers;
            this.pic_sex.Location = new System.Drawing.Point(78, 48);
            this.pic_sex.Name = "pic_sex";
            this.pic_sex.Size = new System.Drawing.Size(15, 15);
            this.pic_sex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_sex.TabIndex = 2;
            this.pic_sex.TabStop = false;
            // 
            // picRoom
            // 
            this.picRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRoom.isDrawRound = true;
            this.picRoom.Location = new System.Drawing.Point(15, 15);
            this.picRoom.Name = "picRoom";
            this.picRoom.Size = new System.Drawing.Size(50, 50);
            this.picRoom.TabIndex = 0;
            this.picRoom.TabStop = false;
            this.picRoom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PicRoom_MouseClick);
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.Color.Red;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(595, 17);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(114, 46);
            this.lblClose.TabIndex = 12;
            this.lblClose.Text = "结束直播";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseClick);
            // 
            // UserLiveTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.PalAll);
            this.Controls.Add(this.lbl_tips);
            this.Controls.Add(this.pic_sex);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.picRoom);
            this.Name = "UserLiveTitle";
            this.Size = new System.Drawing.Size(818, 78);
            this.PalAll.ResumeLayout(false);
            this.PalAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_check)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundPicBox picRoom;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.PictureBox pic_sex;
        public System.Windows.Forms.Panel PalAll;
        public System.Windows.Forms.Label lbl_All;
        public System.Windows.Forms.PictureBox pic_check;
        public System.Windows.Forms.Label lbl_tips;
        private System.Windows.Forms.Label lblClose;
    }
}
