namespace WinFrmTalk
{
    partial class FrmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegister));
            this.picImgCode = new System.Windows.Forms.PictureBox();
            this.tmrCode = new System.Windows.Forms.Timer(this.components);
            this.txtTel = new WinFrmTalk.View.Common.NoPraseTextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtImgCode = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.picLogo = new WinFrmTalk.RoundPicBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelLinePhone = new System.Windows.Forms.Panel();
            this.panelLinePwd = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panelLineImg = new System.Windows.Forms.Panel();
            this.panelLineSms = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbWomen = new WinFrmTalk.Controls.CustomControls.CheckSexBoxEx();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.txtPasswordChk = new System.Windows.Forms.TextBox();
            this.panelLinePwdChk = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lblContry = new System.Windows.Forms.Label();
            this.panelLineUser = new System.Windows.Forms.Panel();
            this.npTxtName = new WinFrmTalk.View.Common.NoPraseTextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnSendCode = new System.Windows.Forms.Label();
            this.lollipopFlatButton1 = new LollipopFlatButton();
            this.btnRegister = new WinFrmTalk.Controls.CustomControls.RegisterBtnEx();
            this.chkRememberPwd = new WinFrmTalk.Controls.CustomControls.CheckTextBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.picImgCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // picImgCode
            // 
            this.picImgCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picImgCode.Location = new System.Drawing.Point(49, 96);
            this.picImgCode.Name = "picImgCode";
            this.picImgCode.Size = new System.Drawing.Size(72, 24);
            this.picImgCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImgCode.TabIndex = 4;
            this.picImgCode.TabStop = false;
            this.picImgCode.Click += new System.EventHandler(this.PicImgCode_Click);
            // 
            // tmrCode
            // 
            this.tmrCode.Interval = 1000;
            this.tmrCode.Tick += new System.EventHandler(this.TmrCode_Tick);
            // 
            // txtTel
            // 
            this.txtTel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTel.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtTel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.txtTel.Location = new System.Drawing.Point(103, 53);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(170, 20);
            this.txtTel.TabIndex = 2;
            this.txtTel.Text = "请输入手机号";
            this.txtTel.TextChanged += new System.EventHandler(this.CheckedBtnEnabel);
            this.txtTel.Enter += new System.EventHandler(this.txtTel_Enter);
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTel_KeyPress);
            this.txtTel.Leave += new System.EventHandler(this.txtTel_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.txtPassword.Location = new System.Drawing.Point(55, 196);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(220, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "请输入6位及以上密码";
            this.txtPassword.TextChanged += new System.EventHandler(this.CheckedBtnEnabel);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtImgCode
            // 
            this.txtImgCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImgCode.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtImgCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.txtImgCode.Location = new System.Drawing.Point(131, 98);
            this.txtImgCode.Name = "txtImgCode";
            this.txtImgCode.Size = new System.Drawing.Size(103, 20);
            this.txtImgCode.TabIndex = 1;
            this.txtImgCode.Text = "请输入正确答案";
            this.txtImgCode.TextChanged += new System.EventHandler(this.CheckedBtnEnabel);
            this.txtImgCode.Enter += new System.EventHandler(this.txtImgCode_Enter);
            this.txtImgCode.Leave += new System.EventHandler(this.txtImgCode_Leave);
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.txtCode.Location = new System.Drawing.Point(45, 145);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(103, 20);
            this.txtCode.TabIndex = 3;
            this.txtCode.Text = "验证码";
            this.txtCode.TextChanged += new System.EventHandler(this.CheckedBtnEnabel);
            this.txtCode.Enter += new System.EventHandler(this.txtCode_Enter);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Image = global::WinFrmTalk.Properties.Resources.Logo;
            this.picLogo.isDrawRound = true;
            this.picLogo.Location = new System.Drawing.Point(138, 57);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(70, 70);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 15;
            this.picLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(96, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 31);
            this.label1.TabIndex = 54;
            this.label1.Text = "欢迎注册在秀";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label2.Location = new System.Drawing.Point(8, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 55;
            this.label2.Text = "点击注册即代表您同意";
            this.label2.Visible = false;
            // 
            // panelLinePhone
            // 
            this.panelLinePhone.BackColor = System.Drawing.Color.Silver;
            this.panelLinePhone.Location = new System.Drawing.Point(16, 78);
            this.panelLinePhone.Name = "panelLinePhone";
            this.panelLinePhone.Size = new System.Drawing.Size(263, 1);
            this.panelLinePhone.TabIndex = 56;
            // 
            // panelLinePwd
            // 
            this.panelLinePwd.BackColor = System.Drawing.Color.Silver;
            this.panelLinePwd.Location = new System.Drawing.Point(16, 221);
            this.panelLinePwd.Name = "panelLinePwd";
            this.panelLinePwd.Size = new System.Drawing.Size(263, 1);
            this.panelLinePwd.TabIndex = 57;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Transparent;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 9F);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel1.Location = new System.Drawing.Point(146, 540);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(173, 12);
            this.linkLabel1.TabIndex = 58;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "《用户使用协议》《隐私协议》";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panelLineImg
            // 
            this.panelLineImg.BackColor = System.Drawing.Color.Silver;
            this.panelLineImg.Location = new System.Drawing.Point(16, 123);
            this.panelLineImg.Name = "panelLineImg";
            this.panelLineImg.Size = new System.Drawing.Size(263, 1);
            this.panelLineImg.TabIndex = 58;
            // 
            // panelLineSms
            // 
            this.panelLineSms.BackColor = System.Drawing.Color.Silver;
            this.panelLineSms.Location = new System.Drawing.Point(16, 170);
            this.panelLineSms.Name = "panelLineSms";
            this.panelLineSms.Size = new System.Drawing.Size(263, 1);
            this.panelLineSms.TabIndex = 58;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WinFrmTalk.Properties.Resources.login_pwd;
            this.pictureBox2.Location = new System.Drawing.Point(14, 196);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 59;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinFrmTalk.Properties.Resources.regsmsicon;
            this.pictureBox1.Location = new System.Drawing.Point(14, 145);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WinFrmTalk.Properties.Resources.reg_safe;
            this.pictureBox3.Location = new System.Drawing.Point(14, 98);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 63;
            this.pictureBox3.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rbWomen);
            this.panel5.Controls.Add(this.pictureBox9);
            this.panel5.Controls.Add(this.pictureBox10);
            this.panel5.Controls.Add(this.txtPasswordChk);
            this.panel5.Controls.Add(this.panelLinePwdChk);
            this.panel5.Controls.Add(this.pictureBox8);
            this.panel5.Controls.Add(this.pictureBox7);
            this.panel5.Controls.Add(this.pictureBox5);
            this.panel5.Controls.Add(this.pictureBox6);
            this.panel5.Controls.Add(this.lblContry);
            this.panel5.Controls.Add(this.panelLineUser);
            this.panel5.Controls.Add(this.npTxtName);
            this.panel5.Controls.Add(this.pictureBox4);
            this.panel5.Controls.Add(this.btnSendCode);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.lollipopFlatButton1);
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Controls.Add(this.picImgCode);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.txtTel);
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.txtPassword);
            this.panel5.Controls.Add(this.panelLineSms);
            this.panel5.Controls.Add(this.txtImgCode);
            this.panel5.Controls.Add(this.panelLineImg);
            this.panel5.Controls.Add(this.txtCode);
            this.panel5.Controls.Add(this.panelLinePwd);
            this.panel5.Controls.Add(this.panelLinePhone);
            this.panel5.Location = new System.Drawing.Point(28, 166);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(296, 293);
            this.panel5.TabIndex = 66;
            // 
            // rbWomen
            // 
            this.rbWomen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbWomen.BackgroundImage")));
            this.rbWomen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbWomen.Location = new System.Drawing.Point(192, 0);
            this.rbWomen.Name = "rbWomen";
            this.rbWomen.Size = new System.Drawing.Size(90, 26);
            this.rbWomen.TabIndex = 69;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::WinFrmTalk.Properties.Resources.loginpwdsee;
            this.pictureBox9.Location = new System.Drawing.Point(261, 247);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(20, 20);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 87;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::WinFrmTalk.Properties.Resources.login_pwd;
            this.pictureBox10.Location = new System.Drawing.Point(14, 247);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(24, 24);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 86;
            this.pictureBox10.TabStop = false;
            // 
            // txtPasswordChk
            // 
            this.txtPasswordChk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPasswordChk.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtPasswordChk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.txtPasswordChk.Location = new System.Drawing.Point(53, 247);
            this.txtPasswordChk.Name = "txtPasswordChk";
            this.txtPasswordChk.Size = new System.Drawing.Size(220, 20);
            this.txtPasswordChk.TabIndex = 5;
            this.txtPasswordChk.Text = "确认密码";
            this.txtPasswordChk.TextChanged += new System.EventHandler(this.CheckedBtnEnabel);
            this.txtPasswordChk.Enter += new System.EventHandler(this.txtPasswordChk_Enter);
            this.txtPasswordChk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPasswordChk_KeyPress);
            this.txtPasswordChk.Leave += new System.EventHandler(this.txtPasswordChk_Leave);
            // 
            // panelLinePwdChk
            // 
            this.panelLinePwdChk.BackColor = System.Drawing.Color.Silver;
            this.panelLinePwdChk.Location = new System.Drawing.Point(18, 274);
            this.panelLinePwdChk.Name = "panelLinePwdChk";
            this.panelLinePwdChk.Size = new System.Drawing.Size(263, 1);
            this.panelLinePwdChk.TabIndex = 85;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::WinFrmTalk.Properties.Resources.loginpwdsee;
            this.pictureBox8.Location = new System.Drawing.Point(261, 196);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(20, 20);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 83;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::WinFrmTalk.Properties.Resources.regimgfresh;
            this.pictureBox7.Location = new System.Drawing.Point(262, 98);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(20, 20);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 82;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::WinFrmTalk.Properties.Resources.phonedown;
            this.pictureBox5.Location = new System.Drawing.Point(69, 60);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(12, 7);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 81;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::WinFrmTalk.Properties.Resources.login_phone;
            this.pictureBox6.Location = new System.Drawing.Point(14, 53);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(24, 24);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 80;
            this.pictureBox6.TabStop = false;
            // 
            // lblContry
            // 
            this.lblContry.BackColor = System.Drawing.Color.Transparent;
            this.lblContry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblContry.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblContry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.lblContry.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblContry.Location = new System.Drawing.Point(33, 52);
            this.lblContry.Name = "lblContry";
            this.lblContry.Size = new System.Drawing.Size(38, 22);
            this.lblContry.TabIndex = 79;
            this.lblContry.Text = "+86";
            this.lblContry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLineUser
            // 
            this.panelLineUser.BackColor = System.Drawing.Color.Silver;
            this.panelLineUser.Location = new System.Drawing.Point(16, 29);
            this.panelLineUser.Name = "panelLineUser";
            this.panelLineUser.Size = new System.Drawing.Size(263, 1);
            this.panelLineUser.TabIndex = 57;
            // 
            // npTxtName
            // 
            this.npTxtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npTxtName.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.npTxtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.npTxtName.Location = new System.Drawing.Point(45, 4);
            this.npTxtName.Name = "npTxtName";
            this.npTxtName.Size = new System.Drawing.Size(136, 20);
            this.npTxtName.TabIndex = 1;
            this.npTxtName.Text = "用户名";
            this.npTxtName.TextChanged += new System.EventHandler(this.CheckedBtnEnabel);
            this.npTxtName.Enter += new System.EventHandler(this.npTxtName_Enter);
            this.npTxtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.npTxtName_KeyPress);
            this.npTxtName.Leave += new System.EventHandler(this.npTxtName_Leave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WinFrmTalk.Properties.Resources.reg_person;
            this.pictureBox4.Location = new System.Drawing.Point(14, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 75;
            this.pictureBox4.TabStop = false;
            // 
            // btnSendCode
            // 
            this.btnSendCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendCode.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSendCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.btnSendCode.Image = ((System.Drawing.Image)(resources.GetObject("btnSendCode.Image")));
            this.btnSendCode.Location = new System.Drawing.Point(190, 142);
            this.btnSendCode.Name = "btnSendCode";
            this.btnSendCode.Size = new System.Drawing.Size(90, 26);
            this.btnSendCode.TabIndex = 69;
            this.btnSendCode.Text = "发送验证码";
            this.btnSendCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSendCode.Click += new System.EventHandler(this.BtnSendCode_Click);
            // 
            // lollipopFlatButton1
            // 
            this.lollipopFlatButton1.BackColor = System.Drawing.Color.Transparent;
            this.lollipopFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lollipopFlatButton1.FontColor = "#333333";
            this.lollipopFlatButton1.Location = new System.Drawing.Point(165, 371);
            this.lollipopFlatButton1.Name = "lollipopFlatButton1";
            this.lollipopFlatButton1.Size = new System.Drawing.Size(102, 20);
            this.lollipopFlatButton1.TabIndex = 74;
            this.lollipopFlatButton1.Text = "收不到验证码？";
            this.lollipopFlatButton1.Visible = false;
            this.lollipopFlatButton1.Click += new System.EventHandler(this.Lblnocode_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.White;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Image = global::WinFrmTalk.Properties.Resources.ic_login_btn2;
            this.btnRegister.Location = new System.Drawing.Point(63, 491);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(220, 30);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "注册";
            this.btnRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // chkRememberPwd
            // 
            this.chkRememberPwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkRememberPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.chkRememberPwd.LabelFont = new System.Drawing.Font("宋体", 9F);
            this.chkRememberPwd.LabelText = "我已阅读并同意";
            this.chkRememberPwd.Location = new System.Drawing.Point(35, 536);
            this.chkRememberPwd.MouseEffage = false;
            this.chkRememberPwd.Name = "chkRememberPwd";
            this.chkRememberPwd.Size = new System.Drawing.Size(116, 20);
            this.chkRememberPwd.TabIndex = 69;
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WinFrmTalk.Properties.Resources.regbg;
            this.BorderColor = System.Drawing.Color.White;
            this.BtnCloseImage = global::WinFrmTalk.Properties.Resources.Close_White;
            this.BtnNarrowImage = global::WinFrmTalk.Properties.Resources.Narrow_White;
            this.ClientSize = new System.Drawing.Size(346, 584);
            this.Controls.Add(this.chkRememberPwd);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MdiBackColor = System.Drawing.Color.Transparent;
            this.Name = "FrmRegister";
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 注册";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.TitleNeed = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegister_FormClosing);
            this.Load += new System.EventHandler(this.FrmRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImgCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picImgCode;
        private System.Windows.Forms.Timer tmrCode;
        private View.Common.NoPraseTextBox txtTel;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtImgCode;
        private System.Windows.Forms.TextBox txtCode;
        private RoundPicBox picLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelLinePhone;
        private System.Windows.Forms.Panel panelLinePwd;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panelLineImg;
        private System.Windows.Forms.Panel panelLineSms;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel5;
        private Controls.CustomControls.RegisterBtnEx btnRegister;
        private System.Windows.Forms.Label btnSendCode;
        private LollipopFlatButton lollipopFlatButton1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panelLineUser;
        private View.Common.NoPraseTextBox npTxtName;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lblContry;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.TextBox txtPasswordChk;
        private System.Windows.Forms.Panel panelLinePwdChk;
        private Controls.CustomControls.CheckSexBoxEx rbWomen;
        private Controls.CustomControls.CheckTextBoxEx chkRememberPwd;
    }
}