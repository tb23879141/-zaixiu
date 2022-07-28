namespace WinFrmTalk.Controls.CustomControls
{
    partial class USEFriendInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private float text_font_size = 10f;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labPhoneRemark = new System.Windows.Forms.Label();
            this.lbl_title_RePhone = new System.Windows.Forms.Label();
            this.picHead = new WinFrmTalk.RoundPicBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.skinLine2 = new CCWin.SkinControl.SkinLine();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.btnSend = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblNickname = new System.Windows.Forms.Label();
            this.lblAccountIM_title = new System.Windows.Forms.Label();
            this.lblAddress_title = new System.Windows.Forms.Label();
            this.lblDate_title = new System.Windows.Forms.Label();
            this.lblSex_title = new System.Windows.Forms.Label();
            this.lblRemark_title = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labPhoneRemark);
            this.panel1.Controls.Add(this.lbl_title_RePhone);
            this.panel1.Controls.Add(this.picHead);
            this.panel1.Controls.Add(this.txtRemarks);
            this.panel1.Controls.Add(this.skinLine2);
            this.panel1.Controls.Add(this.skinLine1);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.lblAccount);
            this.panel1.Controls.Add(this.lblLocation);
            this.panel1.Controls.Add(this.lblBirthday);
            this.panel1.Controls.Add(this.lblRemarks);
            this.panel1.Controls.Add(this.lblSex);
            this.panel1.Controls.Add(this.lblNickname);
            this.panel1.Controls.Add(this.lblAccountIM_title);
            this.panel1.Controls.Add(this.lblAddress_title);
            this.panel1.Controls.Add(this.lblDate_title);
            this.panel1.Controls.Add(this.lblSex_title);
            this.panel1.Controls.Add(this.lblRemark_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 656);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // labPhoneRemark
            // 
            this.labPhoneRemark.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPhoneRemark.Location = new System.Drawing.Point(194, 430);
            this.labPhoneRemark.Name = "labPhoneRemark";
            this.labPhoneRemark.Size = new System.Drawing.Size(173, 18);
            this.labPhoneRemark.TabIndex = 42;
            this.labPhoneRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labPhoneRemark.Click += new System.EventHandler(this.OnPhoneRemarks_Click);
            // 
            // lbl_title_RePhone
            // 
            this.lbl_title_RePhone.AutoSize = true;
            this.lbl_title_RePhone.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_title_RePhone.ForeColor = System.Drawing.Color.Gray;
            this.lbl_title_RePhone.Location = new System.Drawing.Point(92, 431);
            this.lbl_title_RePhone.Name = "lbl_title_RePhone";
            this.lbl_title_RePhone.Size = new System.Drawing.Size(56, 17);
            this.lbl_title_RePhone.TabIndex = 41;
            this.lbl_title_RePhone.Text = "手机备注";
            // 
            // picHead
            // 
            this.picHead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picHead.BackColor = System.Drawing.Color.Transparent;
            this.picHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHead.isDrawRound = true;
            this.picHead.Location = new System.Drawing.Point(403, 106);
            this.picHead.Name = "picHead";
            this.picHead.Size = new System.Drawing.Size(60, 60);
            this.picHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHead.TabIndex = 40;
            this.picHead.TabStop = false;
            this.picHead.Click += new System.EventHandler(this.picHead_Click);
            this.picHead.Paint += new System.Windows.Forms.PaintEventHandler(this.picHead_Paint);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRemarks.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemarks.Location = new System.Drawing.Point(196, 269);
            this.txtRemarks.MaxLength = 50;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(171, 23);
            this.txtRemarks.TabIndex = 39;
            this.txtRemarks.Visible = false;
            this.txtRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemarks_KeyPress);
            // 
            // skinLine2
            // 
            this.skinLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.skinLine2.LineColor = System.Drawing.Color.Black;
            this.skinLine2.LineHeight = 1;
            this.skinLine2.Location = new System.Drawing.Point(91, 489);
            this.skinLine2.Name = "skinLine2";
            this.skinLine2.Size = new System.Drawing.Size(372, 1);
            this.skinLine2.TabIndex = 37;
            this.skinLine2.Text = "skinLine1";
            // 
            // skinLine1
            // 
            this.skinLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.skinLine1.LineColor = System.Drawing.Color.Black;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(91, 230);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(372, 1);
            this.skinLine1.TabIndex = 38;
            this.skinLine1.Text = "skinLine1";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Image = global::WinFrmTalk.Properties.Resources.ic_button_bg1;
            this.btnSend.Location = new System.Drawing.Point(180, 525);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(139, 38);
            this.btnSend.TabIndex = 36;
            this.btnSend.Text = "发消息";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblAccount
            // 
            this.lblAccount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAccount.Location = new System.Drawing.Point(194, 396);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(173, 18);
            this.lblAccount.TabIndex = 33;
            this.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLocation
            // 
            this.lblLocation.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLocation.Location = new System.Drawing.Point(194, 365);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(100, 18);
            this.lblLocation.TabIndex = 34;
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBirthday
            // 
            this.lblBirthday.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBirthday.Location = new System.Drawing.Point(194, 334);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(100, 18);
            this.lblBirthday.TabIndex = 35;
            this.lblBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemarks
            // 
            this.lblRemarks.BackColor = System.Drawing.Color.Transparent;
            this.lblRemarks.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemarks.Location = new System.Drawing.Point(194, 272);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(173, 18);
            this.lblRemarks.TabIndex = 31;
            this.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRemarks.Click += new System.EventHandler(this.lblRemarks_Click);
            // 
            // lblSex
            // 
            this.lblSex.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex.Location = new System.Drawing.Point(194, 303);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(100, 18);
            this.lblSex.TabIndex = 32;
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNickname
            // 
            this.lblNickname.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNickname.Location = new System.Drawing.Point(89, 106);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(259, 60);
            this.lblNickname.TabIndex = 30;
            this.lblNickname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAccountIM_title
            // 
            this.lblAccountIM_title.AutoSize = true;
            this.lblAccountIM_title.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAccountIM_title.ForeColor = System.Drawing.Color.Gray;
            this.lblAccountIM_title.Location = new System.Drawing.Point(91, 396);
            this.lblAccountIM_title.Name = "lblAccountIM_title";
            this.lblAccountIM_title.Size = new System.Drawing.Size(44, 17);
            this.lblAccountIM_title.TabIndex = 27;
            this.lblAccountIM_title.Text = "在秀号";
            // 
            // lblAddress_title
            // 
            this.lblAddress_title.AutoSize = true;
            this.lblAddress_title.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddress_title.ForeColor = System.Drawing.Color.Gray;
            this.lblAddress_title.Location = new System.Drawing.Point(91, 365);
            this.lblAddress_title.Name = "lblAddress_title";
            this.lblAddress_title.Size = new System.Drawing.Size(52, 17);
            this.lblAddress_title.TabIndex = 28;
            this.lblAddress_title.Text = "所 在 地";
            // 
            // lblDate_title
            // 
            this.lblDate_title.AutoSize = true;
            this.lblDate_title.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDate_title.ForeColor = System.Drawing.Color.Gray;
            this.lblDate_title.Location = new System.Drawing.Point(91, 334);
            this.lblDate_title.Name = "lblDate_title";
            this.lblDate_title.Size = new System.Drawing.Size(56, 17);
            this.lblDate_title.TabIndex = 29;
            this.lblDate_title.Text = "出生日期";
            // 
            // lblSex_title
            // 
            this.lblSex_title.AutoSize = true;
            this.lblSex_title.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex_title.ForeColor = System.Drawing.Color.Gray;
            this.lblSex_title.Location = new System.Drawing.Point(91, 303);
            this.lblSex_title.Name = "lblSex_title";
            this.lblSex_title.Size = new System.Drawing.Size(48, 17);
            this.lblSex_title.TabIndex = 26;
            this.lblSex_title.Text = "性    别";
            // 
            // lblRemark_title
            // 
            this.lblRemark_title.AutoSize = true;
            this.lblRemark_title.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemark_title.ForeColor = System.Drawing.Color.Gray;
            this.lblRemark_title.Location = new System.Drawing.Point(91, 272);
            this.lblRemark_title.Name = "lblRemark_title";
            this.lblRemark_title.Size = new System.Drawing.Size(48, 17);
            this.lblRemark_title.TabIndex = 25;
            this.lblRemark_title.Text = "备    注";
            // 
            // USEFriendInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel1);
            this.Name = "USEFriendInfo";
            this.Size = new System.Drawing.Size(553, 656);
            this.Click += new System.EventHandler(this.txtRemarks_Leave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private RoundPicBox picHead;
        private System.Windows.Forms.TextBox txtRemarks;
        private CCWin.SkinControl.SkinLine skinLine2;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.Label btnSend;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.Label lblAccountIM_title;
        private System.Windows.Forms.Label lblAddress_title;
        private System.Windows.Forms.Label lblDate_title;
        private System.Windows.Forms.Label lblSex_title;
        private System.Windows.Forms.Label lblRemark_title;
        private System.Windows.Forms.Label lbl_title_RePhone;
        private System.Windows.Forms.Label labPhoneRemark;
    }
}
