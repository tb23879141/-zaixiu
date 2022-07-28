namespace WinFrmTalk
{
    partial class FrmForgetPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmForgetPwd));
            this.tmrCode = new System.Windows.Forms.Timer(this.components);
            this.picLogo = new WinFrmTalk.RoundPicBox();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lblContry = new System.Windows.Forms.Label();
            this.panelLinePwd = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtConfirmPwd = new System.Windows.Forms.TextBox();
            this.btnSendCode = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.picImgCode = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtTelephone = new WinFrmTalk.View.Common.NoPraseTextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.panelLineSms = new System.Windows.Forms.Panel();
            this.txtImgCode = new System.Windows.Forms.TextBox();
            this.panelLineCode = new System.Windows.Forms.Panel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.panelLinePwdChk = new System.Windows.Forms.Panel();
            this.panelLinePhone = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new WinFrmTalk.Controls.CustomControls.RegisterBtnEx();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImgCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrCode
            // 
            this.tmrCode.Interval = 1000;
            this.tmrCode.Tick += new System.EventHandler(this.tmrCode_Tick);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Image = global::WinFrmTalk.Properties.Resources.Logo;
            this.picLogo.isDrawRound = true;
            this.picLogo.Location = new System.Drawing.Point(130, 64);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(70, 70);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 77;
            this.picLogo.TabStop = false;
            // 
            // panelEdit
            // 
            this.panelEdit.Controls.Add(this.pictureBox9);
            this.panelEdit.Controls.Add(this.pictureBox8);
            this.panelEdit.Controls.Add(this.pictureBox7);
            this.panelEdit.Controls.Add(this.pictureBox2);
            this.panelEdit.Controls.Add(this.pictureBox6);
            this.panelEdit.Controls.Add(this.lblContry);
            this.panelEdit.Controls.Add(this.panelLinePwd);
            this.panelEdit.Controls.Add(this.pictureBox1);
            this.panelEdit.Controls.Add(this.txtConfirmPwd);
            this.panelEdit.Controls.Add(this.btnSendCode);
            this.panelEdit.Controls.Add(this.pictureBox3);
            this.panelEdit.Controls.Add(this.picImgCode);
            this.panelEdit.Controls.Add(this.pictureBox4);
            this.panelEdit.Controls.Add(this.txtTelephone);
            this.panelEdit.Controls.Add(this.pictureBox5);
            this.panelEdit.Controls.Add(this.txtNewPwd);
            this.panelEdit.Controls.Add(this.panelLineSms);
            this.panelEdit.Controls.Add(this.txtImgCode);
            this.panelEdit.Controls.Add(this.panelLineCode);
            this.panelEdit.Controls.Add(this.txtCode);
            this.panelEdit.Controls.Add(this.panelLinePwdChk);
            this.panelEdit.Controls.Add(this.panelLinePhone);
            this.panelEdit.Location = new System.Drawing.Point(13, 165);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(295, 256);
            this.panelEdit.TabIndex = 78;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::WinFrmTalk.Properties.Resources.regimgfresh;
            this.pictureBox9.Location = new System.Drawing.Point(268, 64);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(20, 20);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 92;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::WinFrmTalk.Properties.Resources.loginpwdsee;
            this.pictureBox8.Location = new System.Drawing.Point(267, 164);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(20, 20);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 86;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::WinFrmTalk.Properties.Resources.loginpwdsee;
            this.pictureBox7.Location = new System.Drawing.Point(267, 114);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(20, 20);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 85;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WinFrmTalk.Properties.Resources.phonedown;
            this.pictureBox2.Location = new System.Drawing.Point(72, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(12, 7);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 84;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::WinFrmTalk.Properties.Resources.phone;
            this.pictureBox6.Location = new System.Drawing.Point(18, 12);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(24, 24);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 83;
            this.pictureBox6.TabStop = false;
            // 
            // lblContry
            // 
            this.lblContry.BackColor = System.Drawing.Color.Transparent;
            this.lblContry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblContry.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblContry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.lblContry.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblContry.Location = new System.Drawing.Point(36, 12);
            this.lblContry.Name = "lblContry";
            this.lblContry.Size = new System.Drawing.Size(37, 22);
            this.lblContry.TabIndex = 82;
            this.lblContry.Text = "+86";
            this.lblContry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLinePwd
            // 
            this.panelLinePwd.BackColor = System.Drawing.Color.LightGray;
            this.panelLinePwd.Location = new System.Drawing.Point(13, 140);
            this.panelLinePwd.Name = "panelLinePwd";
            this.panelLinePwd.Size = new System.Drawing.Size(290, 1);
            this.panelLinePwd.TabIndex = 58;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinFrmTalk.Properties.Resources.login_pwd;
            this.pictureBox1.Location = new System.Drawing.Point(18, 162);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            // 
            // txtConfirmPwd
            // 
            this.txtConfirmPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmPwd.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtConfirmPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.txtConfirmPwd.Location = new System.Drawing.Point(50, 165);
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.Size = new System.Drawing.Size(220, 19);
            this.txtConfirmPwd.TabIndex = 3;
            this.txtConfirmPwd.Text = "请确认新密码";
            this.txtConfirmPwd.Enter += new System.EventHandler(this.txtConfirmPwd_Enter);
            this.txtConfirmPwd.Leave += new System.EventHandler(this.txtConfirmPwd_Leave);
            // 
            // btnSendCode
            // 
            this.btnSendCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendCode.Enabled = false;
            this.btnSendCode.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSendCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.btnSendCode.Image = ((System.Drawing.Image)(resources.GetObject("btnSendCode.Image")));
            this.btnSendCode.Location = new System.Drawing.Point(197, 211);
            this.btnSendCode.Name = "btnSendCode";
            this.btnSendCode.Size = new System.Drawing.Size(90, 26);
            this.btnSendCode.TabIndex = 69;
            this.btnSendCode.Text = "发送验证码";
            this.btnSendCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSendCode.Click += new System.EventHandler(this.BtnSendCode_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WinFrmTalk.Properties.Resources.reg_safe;
            this.pictureBox3.Location = new System.Drawing.Point(18, 62);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 63;
            this.pictureBox3.TabStop = false;
            // 
            // picImgCode
            // 
            this.picImgCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picImgCode.Location = new System.Drawing.Point(41, 62);
            this.picImgCode.Name = "picImgCode";
            this.picImgCode.Size = new System.Drawing.Size(72, 24);
            this.picImgCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImgCode.TabIndex = 4;
            this.picImgCode.TabStop = false;
            this.picImgCode.Click += new System.EventHandler(this.PicImgCode_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WinFrmTalk.Properties.Resources.regsmsicon;
            this.pictureBox4.Location = new System.Drawing.Point(18, 212);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 60;
            this.pictureBox4.TabStop = false;
            // 
            // txtTelephone
            // 
            this.txtTelephone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelephone.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTelephone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.txtTelephone.Location = new System.Drawing.Point(93, 14);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(170, 19);
            this.txtTelephone.TabIndex = 1;
            this.txtTelephone.Text = "请输入手机号";
            this.txtTelephone.Enter += new System.EventHandler(this.txtTelephone_Enter);
            this.txtTelephone.Leave += new System.EventHandler(this.txtTelephone_Leave);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::WinFrmTalk.Properties.Resources.login_pwd;
            this.pictureBox5.Location = new System.Drawing.Point(18, 112);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(24, 24);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 59;
            this.pictureBox5.TabStop = false;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewPwd.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNewPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.txtNewPwd.Location = new System.Drawing.Point(50, 115);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Size = new System.Drawing.Size(220, 19);
            this.txtNewPwd.TabIndex = 2;
            this.txtNewPwd.Text = "请输入新密码";
            this.txtNewPwd.Enter += new System.EventHandler(this.txtNewPwd_Enter);
            this.txtNewPwd.Leave += new System.EventHandler(this.txtNewPwd_Leave);
            // 
            // panelLineSms
            // 
            this.panelLineSms.BackColor = System.Drawing.Color.LightGray;
            this.panelLineSms.Location = new System.Drawing.Point(13, 241);
            this.panelLineSms.Name = "panelLineSms";
            this.panelLineSms.Size = new System.Drawing.Size(290, 1);
            this.panelLineSms.TabIndex = 58;
            // 
            // txtImgCode
            // 
            this.txtImgCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImgCode.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtImgCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.txtImgCode.Location = new System.Drawing.Point(117, 65);
            this.txtImgCode.Name = "txtImgCode";
            this.txtImgCode.Size = new System.Drawing.Size(103, 19);
            this.txtImgCode.TabIndex = 0;
            this.txtImgCode.Text = "请输入正确答案";
            this.txtImgCode.Enter += new System.EventHandler(this.txtImgCode_Enter);
            this.txtImgCode.Leave += new System.EventHandler(this.txtImgCode_Leave);
            // 
            // panelLineCode
            // 
            this.panelLineCode.BackColor = System.Drawing.Color.LightGray;
            this.panelLineCode.Location = new System.Drawing.Point(13, 90);
            this.panelLineCode.Name = "panelLineCode";
            this.panelLineCode.Size = new System.Drawing.Size(290, 1);
            this.panelLineCode.TabIndex = 58;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.txtCode.Location = new System.Drawing.Point(50, 215);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(103, 19);
            this.txtCode.TabIndex = 5;
            this.txtCode.Text = "请输入验证码";
            this.txtCode.Enter += new System.EventHandler(this.txtCode_Enter);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // panelLinePwdChk
            // 
            this.panelLinePwdChk.BackColor = System.Drawing.Color.LightGray;
            this.panelLinePwdChk.Location = new System.Drawing.Point(13, 190);
            this.panelLinePwdChk.Name = "panelLinePwdChk";
            this.panelLinePwdChk.Size = new System.Drawing.Size(290, 1);
            this.panelLinePwdChk.TabIndex = 57;
            // 
            // panelLinePhone
            // 
            this.panelLinePhone.BackColor = System.Drawing.Color.LightGray;
            this.panelLinePhone.Location = new System.Drawing.Point(13, 40);
            this.panelLinePhone.Name = "panelLinePhone";
            this.panelLinePhone.Size = new System.Drawing.Size(283, 1);
            this.panelLinePhone.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(85, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 31);
            this.label1.TabIndex = 89;
            this.label1.Text = "请重置密码";
            this.label1.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.Location = new System.Drawing.Point(50, 442);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(220, 30);
            this.btnLogin.TabIndex = 92;
            this.btnLogin.Text = "修改密码";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.Click += new System.EventHandler(this.BtnModifyPwd_Click);
            // 
            // FrmForgetPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WinFrmTalk.Properties.Resources.loginBG320;
            this.BorderColor = System.Drawing.Color.White;
            this.BtnCloseImage = global::WinFrmTalk.Properties.Resources.Close_White;
            this.BtnNarrowImage = global::WinFrmTalk.Properties.Resources.Narrow_White1;
            this.ClientSize = new System.Drawing.Size(322, 503);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.panelEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MdiBackColor = System.Drawing.Color.White;
            this.Name = "FrmForgetPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TitleNeed = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmForgetPwd_FormClosing);
            this.Load += new System.EventHandler(this.FrmForgetPwd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImgCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrCode;
        private RoundPicBox picLogo;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Label btnSendCode;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox picImgCode;
        private System.Windows.Forms.PictureBox pictureBox4;
        private View.Common.NoPraseTextBox txtTelephone;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.Panel panelLineSms;
        private System.Windows.Forms.TextBox txtImgCode;
        private System.Windows.Forms.Panel panelLineCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Panel panelLinePwdChk;
        private System.Windows.Forms.Panel panelLinePhone;
        private System.Windows.Forms.Panel panelLinePwd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtConfirmPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lblContry;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox9;
        private Controls.CustomControls.RegisterBtnEx btnLogin;
    }
}