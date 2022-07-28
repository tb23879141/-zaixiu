namespace WinFrmTalk
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.lblRegister = new LollipopFlatButton();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panelLinePhone = new System.Windows.Forms.Panel();
            this.panelLinePwd = new System.Windows.Forms.Panel();
            this.btnForgetPwd = new LollipopFlatButton();
            this.lblContry = new System.Windows.Forms.Label();
            this.login_tip = new LollipopFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogin = new WinFrmTalk.Controls.CustomControls.RegisterBtnEx();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.chkRememberPwd = new WinFrmTalk.Controls.CustomControls.CheckTextBoxEx();
            this.panel_loading = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegister
            // 
            this.lblRegister.BackColor = System.Drawing.Color.Transparent;
            this.lblRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRegister.Enabled = false;
            this.lblRegister.Font = new System.Drawing.Font("Œ¢»Ì—≈∫⁄", 10F);
            this.lblRegister.FontColor = "#999999";
            this.lblRegister.Location = new System.Drawing.Point(121, 443);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(80, 21);
            this.lblRegister.TabIndex = 19;
            this.lblRegister.Text = "’À∫≈◊¢≤·";
            this.lblRegister.Click += new System.EventHandler(this.lblRegister_Click);
            // 
            // txtTelephone
            // 
            this.txtTelephone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelephone.Font = new System.Drawing.Font("Œ¢»Ì—≈∫⁄", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTelephone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.txtTelephone.Location = new System.Drawing.Point(115, 198);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.ShortcutsEnabled = false;
            this.txtTelephone.Size = new System.Drawing.Size(170, 19);
            this.txtTelephone.TabIndex = 0;
            this.txtTelephone.Text = "«Î ‰»Î ÷ª˙∫≈¬Î";
            this.txtTelephone.TextChanged += new System.EventHandler(this.txtTelephone_TextChanged);
            this.txtTelephone.Enter += new System.EventHandler(this.txtTelephone_Enter);
            this.txtTelephone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginKeyDown);
            this.txtTelephone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelephone_KeyPress);
            this.txtTelephone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTelephone_KeyUp);
            this.txtTelephone.Leave += new System.EventHandler(this.txtTelephone_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Œ¢»Ì—≈∫⁄", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.txtPassword.Location = new System.Drawing.Point(72, 268);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(198, 19);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "«Î ‰»Î6Œª√‹¬Î";
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginKeyDown);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // panelLinePhone
            // 
            this.panelLinePhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelLinePhone.Location = new System.Drawing.Point(39, 222);
            this.panelLinePhone.Name = "panelLinePhone";
            this.panelLinePhone.Size = new System.Drawing.Size(259, 1);
            this.panelLinePhone.TabIndex = 39;
            // 
            // panelLinePwd
            // 
            this.panelLinePwd.BackColor = System.Drawing.Color.Gainsboro;
            this.panelLinePwd.Location = new System.Drawing.Point(30, 292);
            this.panelLinePwd.Name = "panelLinePwd";
            this.panelLinePwd.Size = new System.Drawing.Size(268, 1);
            this.panelLinePwd.TabIndex = 40;
            // 
            // btnForgetPwd
            // 
            this.btnForgetPwd.BackColor = System.Drawing.Color.Transparent;
            this.btnForgetPwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnForgetPwd.Enabled = false;
            this.btnForgetPwd.Font = new System.Drawing.Font("Œ¢»Ì—≈∫⁄", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnForgetPwd.FontColor = "#333333";
            this.btnForgetPwd.Location = new System.Drawing.Point(225, 306);
            this.btnForgetPwd.Name = "btnForgetPwd";
            this.btnForgetPwd.Size = new System.Drawing.Size(76, 20);
            this.btnForgetPwd.TabIndex = 19;
            this.btnForgetPwd.Text = "Õ¸º«√‹¬Î?";
            this.btnForgetPwd.Click += new System.EventHandler(this.btnForgetPwd_Click);
            // 
            // lblContry
            // 
            this.lblContry.BackColor = System.Drawing.Color.Transparent;
            this.lblContry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblContry.Font = new System.Drawing.Font("Œ¢»Ì—≈∫⁄", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblContry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.lblContry.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblContry.Location = new System.Drawing.Point(58, 197);
            this.lblContry.Name = "lblContry";
            this.lblContry.Size = new System.Drawing.Size(38, 22);
            this.lblContry.TabIndex = 45;
            this.lblContry.Text = "+86";
            this.lblContry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContry.Click += new System.EventHandler(this.cmbAreaCode_Click);
            // 
            // login_tip
            // 
            this.login_tip.BackColor = System.Drawing.Color.Transparent;
            this.login_tip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_tip.Enabled = false;
            this.login_tip.Font = new System.Drawing.Font("Œ¢»Ì—≈∫⁄", 9F);
            this.login_tip.FontColor = "#000000";
            this.login_tip.Location = new System.Drawing.Point(49, 431);
            this.login_tip.Name = "login_tip";
            this.login_tip.Size = new System.Drawing.Size(216, 20);
            this.login_tip.TabIndex = 50;
            this.login_tip.Text = "’˝‘⁄œ¬‘ÿ ˝æ›";
            this.login_tip.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Œ¢»Ì—≈∫⁄", 15F, System.Drawing.FontStyle.Italic);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(71, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 27);
            this.label1.TabIndex = 53;
            this.label1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::WinFrmTalk.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(127, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WinFrmTalk.Properties.Resources.login_pwd;
            this.pictureBox2.Location = new System.Drawing.Point(40, 265);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.TabIndex = 57;
            this.pictureBox2.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLogin.Font = new System.Drawing.Font("Œ¢»Ì—≈∫⁄", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.Location = new System.Drawing.Point(53, 398);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(220, 30);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "µ«¬º";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WinFrmTalk.Properties.Resources.login_phone;
            this.pictureBox3.Location = new System.Drawing.Point(40, 195);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 73;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WinFrmTalk.Properties.Resources.phonedown;
            this.pictureBox4.Location = new System.Drawing.Point(94, 205);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(12, 7);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 76;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::WinFrmTalk.Properties.Resources.loginpwdsee;
            this.pictureBox6.Location = new System.Drawing.Point(276, 266);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(20, 20);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 80;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // chkRememberPwd
            // 
            this.chkRememberPwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkRememberPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.chkRememberPwd.LabelFont = new System.Drawing.Font("Œ¢»Ì—≈∫⁄", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkRememberPwd.LabelText = "º«◊°√‹¬Î";
            this.chkRememberPwd.Location = new System.Drawing.Point(42, 305);
            this.chkRememberPwd.Margin = new System.Windows.Forms.Padding(4);
            this.chkRememberPwd.MouseEffage = true;
            this.chkRememberPwd.Name = "chkRememberPwd";
            this.chkRememberPwd.Size = new System.Drawing.Size(92, 20);
            this.chkRememberPwd.TabIndex = 84;
            // 
            // panel_loading
            // 
            this.panel_loading.Location = new System.Drawing.Point(73, 344);
            this.panel_loading.Name = "panel_loading";
            this.panel_loading.Size = new System.Drawing.Size(180, 47);
            this.panel_loading.TabIndex = 87;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WinFrmTalk.Properties.Resources.loginBG320;
            this.BorderColor = System.Drawing.Color.White;
            this.BtnCloseImage = global::WinFrmTalk.Properties.Resources.Close_White;
            this.BtnNarrowImage = global::WinFrmTalk.Properties.Resources.Narrow_White1;
            this.ClientSize = new System.Drawing.Size(324, 500);
            this.Controls.Add(this.panel_loading);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.chkRememberPwd);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login_tip);
            this.Controls.Add(this.panelLinePwd);
            this.Controls.Add(this.panelLinePhone);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.btnForgetPwd);
            this.Controls.Add(this.lblRegister);
            this.Controls.Add(this.lblContry);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.ShowBorder = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TitleColor = System.Drawing.Color.White;
            this.TitleNeed = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LollipopFlatButton lblRegister;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel panelLinePhone;
        private System.Windows.Forms.Panel panelLinePwd;
        private LollipopFlatButton btnForgetPwd;
        private System.Windows.Forms.Label lblContry;
        private LollipopFlatButton login_tip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Controls.CustomControls.RegisterBtnEx btnLogin;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox6;
        private Controls.CustomControls.CheckTextBoxEx chkRememberPwd;
        private System.Windows.Forms.Panel panel_loading;
    }
}