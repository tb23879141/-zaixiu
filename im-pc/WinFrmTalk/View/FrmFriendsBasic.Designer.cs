namespace WinFrmTalk
{
    partial class FrmFriendsBasic
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
            this.lblNickname = new System.Windows.Forms.Label();
            this.lblSex_text = new System.Windows.Forms.Label();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.lblRemarkName_text = new System.Windows.Forms.Label();
            this.lblAddress_text = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.txtRemarks = new CCWin.SkinControl.SkinWaterTextBox();
            this.picAddFirend = new System.Windows.Forms.PictureBox();
            this.picSendMsg = new System.Windows.Forms.PictureBox();
            this.picCard = new System.Windows.Forms.PictureBox();
            this.picQRCode = new System.Windows.Forms.PictureBox();
            this.picHead = new WinFrmTalk.RoundPicBox();
            this.lblAccountIM_text = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblBirthday_text = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picAddFirend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSendMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNickname
            // 
            this.lblNickname.AutoEllipsis = true;
            this.lblNickname.BackColor = System.Drawing.Color.Transparent;
            this.lblNickname.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblNickname.Location = new System.Drawing.Point(37, 27);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(184, 30);
            this.lblNickname.TabIndex = 1;
            this.lblNickname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNickname.UseMnemonic = false;
            // 
            // lblSex_text
            // 
            this.lblSex_text.AutoSize = true;
            this.lblSex_text.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblSex_text.Location = new System.Drawing.Point(38, 70);
            this.lblSex_text.Name = "lblSex_text";
            this.lblSex_text.Size = new System.Drawing.Size(32, 17);
            this.lblSex_text.TabIndex = 2;
            this.lblSex_text.Text = "性别";
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.skinLine1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(38, 100);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(244, 1);
            this.skinLine1.TabIndex = 0;
            this.skinLine1.Text = "skinLine1";
            // 
            // lblRemarkName_text
            // 
            this.lblRemarkName_text.AutoSize = true;
            this.lblRemarkName_text.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemarkName_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblRemarkName_text.Location = new System.Drawing.Point(39, 125);
            this.lblRemarkName_text.Name = "lblRemarkName_text";
            this.lblRemarkName_text.Size = new System.Drawing.Size(32, 17);
            this.lblRemarkName_text.TabIndex = 2;
            this.lblRemarkName_text.Text = "备注";
            // 
            // lblAddress_text
            // 
            this.lblAddress_text.AutoSize = true;
            this.lblAddress_text.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddress_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblAddress_text.Location = new System.Drawing.Point(39, 152);
            this.lblAddress_text.Name = "lblAddress_text";
            this.lblAddress_text.Size = new System.Drawing.Size(44, 17);
            this.lblAddress_text.TabIndex = 2;
            this.lblAddress_text.Text = "所在地";
            // 
            // lblSex
            // 
            this.lblSex.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex.Location = new System.Drawing.Point(99, 70);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(60, 18);
            this.lblSex.TabIndex = 4;
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSex.UseMnemonic = false;
            // 
            // lblRemarks
            // 
            this.lblRemarks.BackColor = System.Drawing.Color.Transparent;
            this.lblRemarks.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblRemarks.Location = new System.Drawing.Point(106, 124);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(128, 18);
            this.lblRemarks.TabIndex = 4;
            this.lblRemarks.Text = "点击设置备注";
            this.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRemarks.Click += new System.EventHandler(this.lblRemarks_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblLocation.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLocation.Location = new System.Drawing.Point(106, 151);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(100, 18);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLocation.UseMnemonic = false;
            // 
            // lblBirthday
            // 
            this.lblBirthday.BackColor = System.Drawing.Color.Transparent;
            this.lblBirthday.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBirthday.Location = new System.Drawing.Point(106, 179);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(100, 18);
            this.lblBirthday.TabIndex = 4;
            this.lblBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBirthday.UseMnemonic = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemarks.Location = new System.Drawing.Point(108, 120);
            this.txtRemarks.MaxLength = 10;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(126, 23);
            this.txtRemarks.TabIndex = 5;
            this.txtRemarks.Visible = false;
            this.txtRemarks.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtRemarks.WaterText = "";
            this.txtRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemarks_KeyPress);
            // 
            // picAddFirend
            // 
            this.picAddFirend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddFirend.Image = global::WinFrmTalk.Properties.Resources.ic_basic_friend_add;
            this.picAddFirend.Location = new System.Drawing.Point(138, 0);
            this.picAddFirend.Margin = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.picAddFirend.Name = "picAddFirend";
            this.picAddFirend.Size = new System.Drawing.Size(35, 35);
            this.picAddFirend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAddFirend.TabIndex = 6;
            this.picAddFirend.TabStop = false;
            this.picAddFirend.Click += new System.EventHandler(this.picAddFirend_Click);
            this.picAddFirend.MouseEnter += new System.EventHandler(this.picQRCode_MouseEnter);
            this.picAddFirend.MouseLeave += new System.EventHandler(this.picQRCode_MouseLeave);
            // 
            // picSendMsg
            // 
            this.picSendMsg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSendMsg.Image = global::WinFrmTalk.Properties.Resources.sendmsg;
            this.picSendMsg.Location = new System.Drawing.Point(191, 0);
            this.picSendMsg.Margin = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.picSendMsg.Name = "picSendMsg";
            this.picSendMsg.Size = new System.Drawing.Size(35, 35);
            this.picSendMsg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSendMsg.TabIndex = 6;
            this.picSendMsg.TabStop = false;
            this.picSendMsg.Click += new System.EventHandler(this.picSendMsg_Click);
            this.picSendMsg.MouseEnter += new System.EventHandler(this.picQRCode_MouseEnter);
            this.picSendMsg.MouseLeave += new System.EventHandler(this.picQRCode_MouseLeave);
            // 
            // picCard
            // 
            this.picCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCard.Image = global::WinFrmTalk.Properties.Resources.ic_basic_share;
            this.picCard.Location = new System.Drawing.Point(85, 0);
            this.picCard.Margin = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.picCard.Name = "picCard";
            this.picCard.Size = new System.Drawing.Size(35, 35);
            this.picCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCard.TabIndex = 6;
            this.picCard.TabStop = false;
            this.picCard.Click += new System.EventHandler(this.picCard_Click);
            this.picCard.MouseEnter += new System.EventHandler(this.picQRCode_MouseEnter);
            this.picCard.MouseLeave += new System.EventHandler(this.picQRCode_MouseLeave);
            // 
            // picQRCode
            // 
            this.picQRCode.BackColor = System.Drawing.Color.White;
            this.picQRCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picQRCode.Image = global::WinFrmTalk.Properties.Resources.ic_basic_qrcode;
            this.picQRCode.Location = new System.Drawing.Point(32, 0);
            this.picQRCode.Margin = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(35, 35);
            this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQRCode.TabIndex = 6;
            this.picQRCode.TabStop = false;
            this.picQRCode.Click += new System.EventHandler(this.picQRCode_Click);
            this.picQRCode.MouseEnter += new System.EventHandler(this.picQRCode_MouseEnter);
            this.picQRCode.MouseLeave += new System.EventHandler(this.picQRCode_MouseLeave);
            // 
            // picHead
            // 
            this.picHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHead.isDrawRound = true;
            this.picHead.Location = new System.Drawing.Point(227, 27);
            this.picHead.Name = "picHead";
            this.picHead.Size = new System.Drawing.Size(55, 55);
            this.picHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHead.TabIndex = 23;
            this.picHead.TabStop = false;
            this.picHead.Click += new System.EventHandler(this.picHead_Click);
            this.picHead.Paint += new System.Windows.Forms.PaintEventHandler(this.picHead_Paint);
            // 
            // lblAccountIM_text
            // 
            this.lblAccountIM_text.AutoSize = true;
            this.lblAccountIM_text.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAccountIM_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblAccountIM_text.Location = new System.Drawing.Point(39, 208);
            this.lblAccountIM_text.Name = "lblAccountIM_text";
            this.lblAccountIM_text.Size = new System.Drawing.Size(44, 17);
            this.lblAccountIM_text.TabIndex = 2;
            this.lblAccountIM_text.Text = "在秀号";
            // 
            // lblAccount
            // 
            this.lblAccount.BackColor = System.Drawing.Color.Transparent;
            this.lblAccount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAccount.Location = new System.Drawing.Point(106, 207);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(128, 18);
            this.lblAccount.TabIndex = 4;
            this.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAccount.UseMnemonic = false;
            // 
            // lblBirthday_text
            // 
            this.lblBirthday_text.AutoSize = true;
            this.lblBirthday_text.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBirthday_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblBirthday_text.Location = new System.Drawing.Point(39, 180);
            this.lblBirthday_text.Name = "lblBirthday_text";
            this.lblBirthday_text.Size = new System.Drawing.Size(32, 17);
            this.lblBirthday_text.TabIndex = 2;
            this.lblBirthday_text.Text = "日期";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.picSendMsg);
            this.flowLayoutPanel1.Controls.Add(this.picAddFirend);
            this.flowLayoutPanel1.Controls.Add(this.picCard);
            this.flowLayoutPanel1.Controls.Add(this.picQRCode);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(65, 255);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(226, 35);
            this.flowLayoutPanel1.TabIndex = 24;
            // 
            // FrmFriendsBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 312);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.picHead);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.lblBirthday);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblAccountIM_text);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.lblBirthday_text);
            this.Controls.Add(this.lblAddress_text);
            this.Controls.Add(this.lblRemarkName_text);
            this.Controls.Add(this.lblSex_text);
            this.Controls.Add(this.lblNickname);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFriendsBasic";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.FrmFriendsBasic_Deactivate);
            this.Click += new System.EventHandler(this.txtRemarks_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.picAddFirend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSendMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.Label lblSex_text;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.Label lblRemarkName_text;
        private System.Windows.Forms.Label lblAddress_text;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblBirthday;
        private CCWin.SkinControl.SkinWaterTextBox txtRemarks;
        private System.Windows.Forms.PictureBox picQRCode;
        private System.Windows.Forms.PictureBox picCard;
        private System.Windows.Forms.PictureBox picSendMsg;
        private System.Windows.Forms.PictureBox picAddFirend;
        private RoundPicBox picHead;
        private System.Windows.Forms.Label lblAccountIM_text;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblBirthday_text;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}