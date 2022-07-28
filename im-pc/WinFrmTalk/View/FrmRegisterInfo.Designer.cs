using System;

namespace WinFrmTalk
{
    partial class FrmRegisterInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegisterInfo));
            this.lblNickname = new System.Windows.Forms.Label();
            this.cmsSex = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nan = new System.Windows.Forms.ToolStripMenuItem();
            this.nv = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.lblLivePlace = new System.Windows.Forms.Label();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.cmsRegion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblAccountIM = new System.Windows.Forms.Label();
            this.picHead = new WinFrmTalk.RoundPicBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkMale = new WinFrmTalk.Controls.CustomControls.CheckBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paneldateExt1 = new System.Windows.Forms.Panel();
            this.dtpBirthday = new WinFrmTalk.Controls.CustomControls.DateExt();
            this.panelRegion = new System.Windows.Forms.Panel();
            this.panelAccount = new System.Windows.Forms.Panel();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.checkfemale = new WinFrmTalk.Controls.CustomControls.CheckBoxEx();
            this.panelName = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.btnSubmit = new WinFrmTalk.Controls.CustomControls.RegisterBtnEx();
            this.cmsSex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            this.panel1.SuspendLayout();
            this.paneldateExt1.SuspendLayout();
            this.panelRegion.SuspendLayout();
            this.panelAccount.SuspendLayout();
            this.panelName.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNickname
            // 
            this.lblNickname.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblNickname.ForeColor = System.Drawing.Color.Gray;
            this.lblNickname.Location = new System.Drawing.Point(0, 0);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(80, 24);
            this.lblNickname.TabIndex = 13;
            this.lblNickname.Text = "昵称：";
            this.lblNickname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmsSex
            // 
            this.cmsSex.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nan,
            this.nv});
            this.cmsSex.Name = "contextMenuStrip1";
            this.cmsSex.Size = new System.Drawing.Size(89, 48);
            // 
            // nan
            // 
            this.nan.Name = "nan";
            this.nan.Size = new System.Drawing.Size(88, 22);
            this.nan.Text = "男";
            this.nan.Click += new System.EventHandler(this.Man_Click);
            // 
            // nv
            // 
            this.nv.Name = "nv";
            this.nv.Size = new System.Drawing.Size(88, 22);
            this.nv.Text = "女";
            this.nv.Click += new System.EventHandler(this.Woman_Click);
            // 
            // lblSex
            // 
            this.lblSex.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblSex.ForeColor = System.Drawing.Color.Gray;
            this.lblSex.Location = new System.Drawing.Point(0, 44);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(80, 24);
            this.lblSex.TabIndex = 13;
            this.lblSex.Text = "性别：";
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBirthday
            // 
            this.lblBirthday.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblBirthday.ForeColor = System.Drawing.Color.Gray;
            this.lblBirthday.Location = new System.Drawing.Point(0, 135);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(80, 24);
            this.lblBirthday.TabIndex = 13;
            this.lblBirthday.Text = "出生日期：";
            this.lblBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLivePlace
            // 
            this.lblLivePlace.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblLivePlace.ForeColor = System.Drawing.Color.Gray;
            this.lblLivePlace.Location = new System.Drawing.Point(0, 90);
            this.lblLivePlace.Name = "lblLivePlace";
            this.lblLivePlace.Size = new System.Drawing.Size(80, 24);
            this.lblLivePlace.TabIndex = 13;
            this.lblLivePlace.Text = "居住地：";
            this.lblLivePlace.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNickname
            // 
            this.txtNickname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtNickname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNickname.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNickname.Location = new System.Drawing.Point(8, 4);
            this.txtNickname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNickname.MaxLength = 50;
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(165, 16);
            this.txtNickname.TabIndex = 0;
            this.txtNickname.Enter += new System.EventHandler(this.txtNickname_Enter);
            this.txtNickname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNickname_KeyPress);
            this.txtNickname.Leave += new System.EventHandler(this.txtNickname_Leave);
            // 
            // txtRegion
            // 
            this.txtRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtRegion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRegion.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRegion.Location = new System.Drawing.Point(16, 4);
            this.txtRegion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(149, 16);
            this.txtRegion.TabIndex = 3;
            this.txtRegion.Click += new System.EventHandler(this.TxtRegion_Click);
            this.txtRegion.Enter += new System.EventHandler(this.txtRegion_Enter);
            this.txtRegion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtRegion_KeyPress);
            this.txtRegion.Leave += new System.EventHandler(this.txtRegion_Leave);
            // 
            // cmsRegion
            // 
            this.cmsRegion.Name = "cmsRegion";
            this.cmsRegion.Size = new System.Drawing.Size(61, 4);
            // 
            // lblAccountIM
            // 
            this.lblAccountIM.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblAccountIM.ForeColor = System.Drawing.Color.Gray;
            this.lblAccountIM.Location = new System.Drawing.Point(0, 186);
            this.lblAccountIM.Name = "lblAccountIM";
            this.lblAccountIM.Size = new System.Drawing.Size(80, 24);
            this.lblAccountIM.TabIndex = 13;
            this.lblAccountIM.Text = "在秀号：";
            this.lblAccountIM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAccountIM.Visible = false;
            // 
            // picHead
            // 
            this.picHead.BackColor = System.Drawing.Color.Transparent;
            this.picHead.BackgroundImage = global::WinFrmTalk.Properties.Resources.photo_upload;
            this.picHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHead.isDrawRound = true;
            this.picHead.Location = new System.Drawing.Point(1, 1);
            this.picHead.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picHead.Name = "picHead";
            this.picHead.Size = new System.Drawing.Size(84, 84);
            this.picHead.TabIndex = 27;
            this.picHead.TabStop = false;
            this.picHead.Click += new System.EventHandler(this.PicHead_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkMale);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.paneldateExt1);
            this.panel1.Controls.Add(this.panelRegion);
            this.panel1.Controls.Add(this.panelAccount);
            this.panel1.Controls.Add(this.checkfemale);
            this.panel1.Controls.Add(this.panelName);
            this.panel1.Controls.Add(this.lblNickname);
            this.panel1.Controls.Add(this.lblSex);
            this.panel1.Controls.Add(this.lblBirthday);
            this.panel1.Controls.Add(this.lblLivePlace);
            this.panel1.Controls.Add(this.lblAccountIM);
            this.panel1.Location = new System.Drawing.Point(31, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 234);
            this.panel1.TabIndex = 70;
            // 
            // checkMale
            // 
            this.checkMale.AutoSize = true;
            this.checkMale.BackColor = System.Drawing.Color.Transparent;
            this.checkMale.BaseColor = System.Drawing.Color.White;
            this.checkMale.Checked = true;
            this.checkMale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkMale.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checkMale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkMale.DefaultCheckButtonWidth = 13;
            this.checkMale.DownBack = null;
            this.checkMale.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkMale.Location = new System.Drawing.Point(84, 50);
            this.checkMale.MouseBack = global::WinFrmTalk.Properties.Resources._unchecked;
            this.checkMale.Name = "checkMale";
            this.checkMale.NormlBack = global::WinFrmTalk.Properties.Resources._unchecked;
            this.checkMale.SelectedDownBack = global::WinFrmTalk.Properties.Resources.checked_register;
            this.checkMale.SelectedMouseBack = global::WinFrmTalk.Properties.Resources.checked_register;
            this.checkMale.SelectedNormlBack = global::WinFrmTalk.Properties.Resources.checked_register;
            this.checkMale.Size = new System.Drawing.Size(15, 14);
            this.checkMale.TabIndex = 78;
            this.checkMale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkMale.UseVisualStyleBackColor = false;
            this.checkMale.Click += new System.EventHandler(this.checkMale_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(185, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 21);
            this.label3.TabIndex = 77;
            this.label3.Text = "女";
            this.label3.Click += new System.EventHandler(this.checkfemale_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(103, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 21);
            this.label2.TabIndex = 76;
            this.label2.Text = "男";
            this.label2.Click += new System.EventHandler(this.checkMale_Click);
            // 
            // paneldateExt1
            // 
            this.paneldateExt1.BackColor = System.Drawing.Color.Transparent;
            this.paneldateExt1.BackgroundImage = global::WinFrmTalk.Properties.Resources.d1;
            this.paneldateExt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.paneldateExt1.Controls.Add(this.dtpBirthday);
            this.paneldateExt1.Location = new System.Drawing.Point(83, 135);
            this.paneldateExt1.Margin = new System.Windows.Forms.Padding(0);
            this.paneldateExt1.Name = "paneldateExt1";
            this.paneldateExt1.Size = new System.Drawing.Size(188, 24);
            this.paneldateExt1.TabIndex = 75;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.BackBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dtpBirthday.BackBorderShow = false;
            this.dtpBirthday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            // 
            // 
            // 
            this.dtpBirthday.DatePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpBirthday.DatePicker.BottomBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpBirthday.DatePicker.BottomBarBtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(28)))), ((int)(((byte)(255)))));
            this.dtpBirthday.DatePicker.BottomBarBtnBackDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(32)))), ((int)(((byte)(23)))), ((int)(((byte)(204)))));
            this.dtpBirthday.DatePicker.BottomBarBtnBackEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(32)))), ((int)(((byte)(23)))), ((int)(((byte)(204)))));
            this.dtpBirthday.DatePicker.BottomBarBtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpBirthday.DatePicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpBirthday.DatePicker.DateBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpBirthday.DatePicker.DateBackDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(28)))), ((int)(((byte)(255)))));
            this.dtpBirthday.DatePicker.DateBackEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(32)))), ((int)(((byte)(23)))), ((int)(((byte)(204)))));
            this.dtpBirthday.DatePicker.DateBackSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(28)))), ((int)(((byte)(255)))));
            this.dtpBirthday.DatePicker.DateForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpBirthday.DatePicker.DateFutureForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(28)))), ((int)(((byte)(255)))));
            this.dtpBirthday.DatePicker.DateNormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(28)))), ((int)(((byte)(255)))));
            this.dtpBirthday.DatePicker.DatePastForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(235)))));
            this.dtpBirthday.DatePicker.DateTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.dtpBirthday.DatePicker.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBirthday.DatePicker.Location = new System.Drawing.Point(0, 0);
            this.dtpBirthday.DatePicker.MaxValue = new System.DateTime(2022, 6, 12, 22, 21, 59, 800);
            this.dtpBirthday.DatePicker.Name = "";
            this.dtpBirthday.DatePicker.TabIndex = 0;
            this.dtpBirthday.DatePicker.TopBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(28)))), ((int)(((byte)(255)))));
            this.dtpBirthday.DatePicker.TopBarBtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpBirthday.DatePicker.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBirthday.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dtpBirthday.ForeColor = System.Drawing.Color.Black;
            this.dtpBirthday.FromImage = null;
            this.dtpBirthday.Location = new System.Drawing.Point(8, 4);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(173, 16);
            this.dtpBirthday.TabIndex = 73;
            this.dtpBirthday.Text = "dateExt1";
            this.dtpBirthday.Click += new System.EventHandler(this.dtpBirthday_Click);
            // 
            // panelRegion
            // 
            this.panelRegion.BackColor = System.Drawing.Color.Transparent;
            this.panelRegion.BackgroundImage = global::WinFrmTalk.Properties.Resources.d1;
            this.panelRegion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelRegion.Controls.Add(this.txtRegion);
            this.panelRegion.Location = new System.Drawing.Point(83, 90);
            this.panelRegion.Margin = new System.Windows.Forms.Padding(0);
            this.panelRegion.Name = "panelRegion";
            this.panelRegion.Size = new System.Drawing.Size(188, 24);
            this.panelRegion.TabIndex = 75;
            // 
            // panelAccount
            // 
            this.panelAccount.BackColor = System.Drawing.Color.Transparent;
            this.panelAccount.BackgroundImage = global::WinFrmTalk.Properties.Resources.d1;
            this.panelAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelAccount.Controls.Add(this.txtAccount);
            this.panelAccount.Location = new System.Drawing.Point(83, 187);
            this.panelAccount.Margin = new System.Windows.Forms.Padding(0);
            this.panelAccount.Name = "panelAccount";
            this.panelAccount.Size = new System.Drawing.Size(188, 24);
            this.panelAccount.TabIndex = 75;
            this.panelAccount.Visible = false;
            // 
            // txtAccount
            // 
            this.txtAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtAccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAccount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAccount.Location = new System.Drawing.Point(16, 4);
            this.txtAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(165, 16);
            this.txtAccount.TabIndex = 3;
            this.txtAccount.Visible = false;
            this.txtAccount.Enter += new System.EventHandler(this.txtAccount_Enter);
            this.txtAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccount_KeyPress);
            this.txtAccount.Leave += new System.EventHandler(this.txtAccount_Leave);
            // 
            // checkfemale
            // 
            this.checkfemale.AutoSize = true;
            this.checkfemale.BackColor = System.Drawing.Color.Transparent;
            this.checkfemale.BaseColor = System.Drawing.Color.White;
            this.checkfemale.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checkfemale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkfemale.DefaultCheckButtonWidth = 13;
            this.checkfemale.DownBack = null;
            this.checkfemale.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkfemale.Location = new System.Drawing.Point(164, 50);
            this.checkfemale.MouseBack = global::WinFrmTalk.Properties.Resources._unchecked;
            this.checkfemale.Name = "checkfemale";
            this.checkfemale.NormlBack = global::WinFrmTalk.Properties.Resources._unchecked;
            this.checkfemale.SelectedDownBack = global::WinFrmTalk.Properties.Resources.checked_register;
            this.checkfemale.SelectedMouseBack = global::WinFrmTalk.Properties.Resources.checked_register;
            this.checkfemale.SelectedNormlBack = global::WinFrmTalk.Properties.Resources.checked_register;
            this.checkfemale.Size = new System.Drawing.Size(15, 14);
            this.checkfemale.TabIndex = 21;
            this.checkfemale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkfemale.UseVisualStyleBackColor = false;
            this.checkfemale.Click += new System.EventHandler(this.checkfemale_Click);
            // 
            // panelName
            // 
            this.panelName.BackColor = System.Drawing.Color.Transparent;
            this.panelName.BackgroundImage = global::WinFrmTalk.Properties.Resources.d1;
            this.panelName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelName.Controls.Add(this.txtNickname);
            this.panelName.Controls.Add(this.textBox1);
            this.panelName.Location = new System.Drawing.Point(83, 0);
            this.panelName.Margin = new System.Windows.Forms.Padding(0);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(188, 24);
            this.panelName.TabIndex = 74;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(8, 4);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 16);
            this.textBox1.TabIndex = 1;
            this.textBox1.Enter += new System.EventHandler(this.dtpBirthday_Enter);
            this.textBox1.Leave += new System.EventHandler(this.dtpBirthday_Leave);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = global::WinFrmTalk.Properties.Resources.ic_head_br;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.picHead);
            this.panel6.Location = new System.Drawing.Point(127, 72);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(86, 86);
            this.panel6.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::WinFrmTalk.Properties.Resources.sc1;
            this.label1.Location = new System.Drawing.Point(4, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 28);
            this.label1.TabIndex = 76;
            this.label1.Text = "点击上传";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.PicHead_Click);
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSubmit.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(65, 438);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(220, 30);
            this.btnSubmit.TabIndex = 76;
            this.btnSubmit.Text = "提 交";
            this.btnSubmit.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // FrmRegisterInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WinFrmTalk.Properties.Resources.regbg;
            this.BtnCloseImage = global::WinFrmTalk.Properties.Resources.Close_White;
            this.BtnNarrowImage = global::WinFrmTalk.Properties.Resources.Narrow_White;
            this.ClientSize = new System.Drawing.Size(346, 502);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmRegisterInfo";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "";
            this.TitleColor = System.Drawing.Color.Transparent;
            this.TitleNeed = false;
            this.Load += new System.EventHandler(this.FrmRegisterInfo_Load);
            this.cmsSex.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.paneldateExt1.ResumeLayout(false);
            this.panelRegion.ResumeLayout(false);
            this.panelRegion.PerformLayout();
            this.panelAccount.ResumeLayout(false);
            this.panelAccount.PerformLayout();
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.Label lblLivePlace;
        private System.Windows.Forms.ContextMenuStrip cmsSex;
        private System.Windows.Forms.ToolStripMenuItem nan;
        private System.Windows.Forms.ToolStripMenuItem nv;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.ContextMenuStrip cmsRegion;
        private System.Windows.Forms.Label lblAccountIM;
        private RoundPicBox picHead;
        private System.Windows.Forms.Panel panel1;
        private Controls.CustomControls.CheckBoxEx checkfemale;
        private Controls.CustomControls.DateExt dtpBirthday;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.Panel panelAccount;
        private System.Windows.Forms.Panel paneldateExt1;
        private System.Windows.Forms.Panel panelRegion;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.TextBox textBox1;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Controls.CustomControls.CheckBoxEx checkMale;
        private Controls.CustomControls.RegisterBtnEx btnSubmit;
    }
}