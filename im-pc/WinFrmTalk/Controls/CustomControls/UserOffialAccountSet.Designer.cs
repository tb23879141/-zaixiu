namespace WinFrmTalk.Controls.CustomControls
{
    partial class UserOffialAccountSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserOffialAccountSet));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBurn = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.chkDisturb = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.chkUppermost = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.lblClear = new System.Windows.Forms.Label();
            this.btndeleatefriend = new System.Windows.Forms.Button();
            this.btnClearRecord = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picOverdueDate = new System.Windows.Forms.PictureBox();
            this.lblOverdueDate = new System.Windows.Forms.Label();
            this.lblReadDel = new System.Windows.Forms.Label();
            this.lblNoDisturbing = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.lblOverdueTime = new System.Windows.Forms.Label();
            this.skinLine2 = new CCWin.SkinControl.SkinLine();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.cmsOverdueDate = new CCWin.SkinControl.SkinContextMenuStrip();
            this.tsmForever = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHour = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSeason = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmYear = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNickname = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picHead = new WinFrmTalk.RoundPicBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOverdueDate)).BeginInit();
            this.cmsOverdueDate.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.chkBurn);
            this.panel2.Controls.Add(this.chkDisturb);
            this.panel2.Controls.Add(this.chkUppermost);
            this.panel2.Controls.Add(this.lblClear);
            this.panel2.Controls.Add(this.btndeleatefriend);
            this.panel2.Controls.Add(this.btnClearRecord);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.picOverdueDate);
            this.panel2.Controls.Add(this.lblOverdueDate);
            this.panel2.Controls.Add(this.lblReadDel);
            this.panel2.Controls.Add(this.lblNoDisturbing);
            this.panel2.Controls.Add(this.lblTop);
            this.panel2.Controls.Add(this.lblOverdueTime);
            this.panel2.Controls.Add(this.skinLine2);
            this.panel2.Controls.Add(this.skinLine1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 497);
            this.panel2.TabIndex = 85;
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(160, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 107;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.lblTwoWay_Click);
            // 
            // chkBurn
            // 
            this.chkBurn.BackColor = System.Drawing.Color.Transparent;
            this.chkBurn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkBurn.Checked = false;
            this.chkBurn.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.chkBurn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkBurn.Location = new System.Drawing.Point(184, 128);
            this.chkBurn.Name = "chkBurn";
            this.chkBurn.Size = new System.Drawing.Size(31, 29);
            this.chkBurn.TabIndex = 106;
            this.chkBurn.Click += new System.EventHandler(this.chkBurn_CheckedChanged);
            // 
            // chkDisturb
            // 
            this.chkDisturb.BackColor = System.Drawing.Color.Transparent;
            this.chkDisturb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkDisturb.Checked = false;
            this.chkDisturb.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.chkDisturb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDisturb.Location = new System.Drawing.Point(184, 93);
            this.chkDisturb.Name = "chkDisturb";
            this.chkDisturb.Size = new System.Drawing.Size(31, 29);
            this.chkDisturb.TabIndex = 105;
            this.chkDisturb.Click += new System.EventHandler(this.chkDisturb_CheckedChanged);
            // 
            // chkUppermost
            // 
            this.chkUppermost.BackColor = System.Drawing.Color.Transparent;
            this.chkUppermost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkUppermost.Checked = false;
            this.chkUppermost.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.chkUppermost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkUppermost.Location = new System.Drawing.Point(184, 58);
            this.chkUppermost.Name = "chkUppermost";
            this.chkUppermost.Size = new System.Drawing.Size(31, 29);
            this.chkUppermost.TabIndex = 104;
            this.chkUppermost.Click += new System.EventHandler(this.chkUppermost_CheckedChanged);
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblClear.Location = new System.Drawing.Point(19, 175);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(104, 17);
            this.lblClear.TabIndex = 102;
            this.lblClear.Text = "双向清理聊天记录";
            this.lblClear.Visible = false;
            // 
            // btndeleatefriend
            // 
            this.btndeleatefriend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btndeleatefriend.FlatAppearance.BorderSize = 0;
            this.btndeleatefriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeleatefriend.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btndeleatefriend.ForeColor = System.Drawing.Color.White;
            this.btndeleatefriend.Location = new System.Drawing.Point(63, 434);
            this.btndeleatefriend.Margin = new System.Windows.Forms.Padding(45, 10, 3, 3);
            this.btndeleatefriend.Name = "btndeleatefriend";
            this.btndeleatefriend.Size = new System.Drawing.Size(110, 30);
            this.btndeleatefriend.TabIndex = 101;
            this.btndeleatefriend.Text = "不再关注";
            this.btndeleatefriend.UseVisualStyleBackColor = false;
            this.btndeleatefriend.Click += new System.EventHandler(this.lblDeleteFriend_Click);
            // 
            // btnClearRecord
            // 
            this.btnClearRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnClearRecord.FlatAppearance.BorderSize = 0;
            this.btnClearRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearRecord.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearRecord.ForeColor = System.Drawing.Color.White;
            this.btnClearRecord.Location = new System.Drawing.Point(63, 390);
            this.btnClearRecord.Margin = new System.Windows.Forms.Padding(45, 10, 3, 3);
            this.btnClearRecord.Name = "btnClearRecord";
            this.btnClearRecord.Size = new System.Drawing.Size(110, 30);
            this.btnClearRecord.TabIndex = 99;
            this.btnClearRecord.Text = "清空聊天记录";
            this.btnClearRecord.UseVisualStyleBackColor = false;
            this.btnClearRecord.Click += new System.EventHandler(this.lblClearRecord_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::WinFrmTalk.Properties.Resources.right;
            this.pictureBox2.Location = new System.Drawing.Point(199, 177);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 15);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 98;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.Click += new System.EventHandler(this.lblTwoWay_Click);
            // 
            // picOverdueDate
            // 
            this.picOverdueDate.BackColor = System.Drawing.Color.Transparent;
            this.picOverdueDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picOverdueDate.Image = global::WinFrmTalk.Properties.Resources.right;
            this.picOverdueDate.Location = new System.Drawing.Point(216, 24);
            this.picOverdueDate.Name = "picOverdueDate";
            this.picOverdueDate.Size = new System.Drawing.Size(15, 15);
            this.picOverdueDate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOverdueDate.TabIndex = 96;
            this.picOverdueDate.TabStop = false;
            this.picOverdueDate.Click += new System.EventHandler(this.picOverdueDate_Click);
            // 
            // lblOverdueDate
            // 
            this.lblOverdueDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOverdueDate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOverdueDate.ForeColor = System.Drawing.Color.Black;
            this.lblOverdueDate.Location = new System.Drawing.Point(132, 23);
            this.lblOverdueDate.Name = "lblOverdueDate";
            this.lblOverdueDate.Size = new System.Drawing.Size(83, 15);
            this.lblOverdueDate.TabIndex = 92;
            this.lblOverdueDate.Text = "永久";
            this.lblOverdueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOverdueDate.Click += new System.EventHandler(this.lblOverdueDate_Click);
            // 
            // lblReadDel
            // 
            this.lblReadDel.AutoSize = true;
            this.lblReadDel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReadDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblReadDel.Location = new System.Drawing.Point(21, 134);
            this.lblReadDel.Name = "lblReadDel";
            this.lblReadDel.Size = new System.Drawing.Size(56, 17);
            this.lblReadDel.TabIndex = 90;
            this.lblReadDel.Text = "阅后即焚";
            // 
            // lblNoDisturbing
            // 
            this.lblNoDisturbing.AutoSize = true;
            this.lblNoDisturbing.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNoDisturbing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblNoDisturbing.Location = new System.Drawing.Point(21, 99);
            this.lblNoDisturbing.Name = "lblNoDisturbing";
            this.lblNoDisturbing.Size = new System.Drawing.Size(68, 17);
            this.lblNoDisturbing.TabIndex = 89;
            this.lblNoDisturbing.Text = "消息免打扰";
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblTop.Location = new System.Drawing.Point(21, 64);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(56, 17);
            this.lblTop.TabIndex = 88;
            this.lblTop.Text = "置顶聊天";
            // 
            // lblOverdueTime
            // 
            this.lblOverdueTime.AutoSize = true;
            this.lblOverdueTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOverdueTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblOverdueTime.Location = new System.Drawing.Point(21, 22);
            this.lblOverdueTime.Name = "lblOverdueTime";
            this.lblOverdueTime.Size = new System.Drawing.Size(80, 17);
            this.lblOverdueTime.TabIndex = 86;
            this.lblOverdueTime.Text = "消息过期时间";
            // 
            // skinLine2
            // 
            this.skinLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.skinLine2.LineColor = System.Drawing.Color.Black;
            this.skinLine2.LineHeight = 1;
            this.skinLine2.Location = new System.Drawing.Point(21, 50);
            this.skinLine2.Name = "skinLine2";
            this.skinLine2.Size = new System.Drawing.Size(210, 1);
            this.skinLine2.TabIndex = 83;
            this.skinLine2.Text = "skinLine1";
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.skinLine1.LineColor = System.Drawing.Color.Black;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(21, 7);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(210, 1);
            this.skinLine1.TabIndex = 81;
            this.skinLine1.Text = "skinLine1";
            // 
            // cmsOverdueDate
            // 
            this.cmsOverdueDate.Arrow = System.Drawing.Color.Black;
            this.cmsOverdueDate.Back = System.Drawing.Color.White;
            this.cmsOverdueDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsOverdueDate.BackRadius = 4;
            this.cmsOverdueDate.Base = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsOverdueDate.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsOverdueDate.Fore = System.Drawing.Color.Black;
            this.cmsOverdueDate.HoverFore = System.Drawing.Color.Black;
            this.cmsOverdueDate.ItemAnamorphosis = false;
            this.cmsOverdueDate.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsOverdueDate.ItemBorderShow = false;
            this.cmsOverdueDate.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsOverdueDate.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsOverdueDate.ItemRadius = 4;
            this.cmsOverdueDate.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsOverdueDate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmForever,
            this.tsmHour,
            this.tsmDay,
            this.tsmWeek,
            this.tsmMonth,
            this.tsmSeason,
            this.tsmYear});
            this.cmsOverdueDate.ItemSplitter = System.Drawing.Color.Silver;
            this.cmsOverdueDate.Name = "contextMenuStrip1";
            this.cmsOverdueDate.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsOverdueDate.Size = new System.Drawing.Size(108, 158);
            this.cmsOverdueDate.SkinAllColor = true;
            this.cmsOverdueDate.Tag = "";
            this.cmsOverdueDate.TitleAnamorphosis = true;
            this.cmsOverdueDate.TitleColor = System.Drawing.Color.White;
            this.cmsOverdueDate.TitleRadius = 4;
            this.cmsOverdueDate.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // tsmForever
            // 
            this.tsmForever.Name = "tsmForever";
            this.tsmForever.Size = new System.Drawing.Size(107, 22);
            this.tsmForever.Text = "永久";
            this.tsmForever.Click += new System.EventHandler(this.tsmForever_Click);
            // 
            // tsmHour
            // 
            this.tsmHour.Name = "tsmHour";
            this.tsmHour.Size = new System.Drawing.Size(107, 22);
            this.tsmHour.Text = "1小时";
            this.tsmHour.Click += new System.EventHandler(this.tsmHour_Click);
            // 
            // tsmDay
            // 
            this.tsmDay.Name = "tsmDay";
            this.tsmDay.Size = new System.Drawing.Size(107, 22);
            this.tsmDay.Text = "1天";
            this.tsmDay.Click += new System.EventHandler(this.tsmDay_Click);
            // 
            // tsmWeek
            // 
            this.tsmWeek.Name = "tsmWeek";
            this.tsmWeek.Size = new System.Drawing.Size(107, 22);
            this.tsmWeek.Text = "1周";
            this.tsmWeek.Click += new System.EventHandler(this.tsmWeek_Click);
            // 
            // tsmMonth
            // 
            this.tsmMonth.Name = "tsmMonth";
            this.tsmMonth.Size = new System.Drawing.Size(107, 22);
            this.tsmMonth.Text = "1月";
            this.tsmMonth.Click += new System.EventHandler(this.tsmMonth_Click);
            // 
            // tsmSeason
            // 
            this.tsmSeason.Name = "tsmSeason";
            this.tsmSeason.Size = new System.Drawing.Size(107, 22);
            this.tsmSeason.Text = "1季";
            this.tsmSeason.Click += new System.EventHandler(this.tsmSeason_Click);
            // 
            // tsmYear
            // 
            this.tsmYear.Name = "tsmYear";
            this.tsmYear.Size = new System.Drawing.Size(107, 22);
            this.tsmYear.Text = "1年";
            this.tsmYear.Click += new System.EventHandler(this.tsmYear_Click);
            // 
            // lblNickname
            // 
            this.lblNickname.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNickname.Location = new System.Drawing.Point(87, 55);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(77, 20);
            this.lblNickname.TabIndex = 26;
            this.lblNickname.Text = "客服公众号";
            this.lblNickname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picHead);
            this.panel1.Controls.Add(this.lblNickname);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 97);
            this.panel1.TabIndex = 84;
            // 
            // picHead
            // 
            this.picHead.BackColor = System.Drawing.Color.Transparent;
            this.picHead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picHead.BackgroundImage")));
            this.picHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHead.isDrawRound = true;
            this.picHead.Location = new System.Drawing.Point(107, 14);
            this.picHead.Name = "picHead";
            this.picHead.Size = new System.Drawing.Size(36, 36);
            this.picHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHead.TabIndex = 28;
            this.picHead.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1, 597);
            this.label9.TabIndex = 83;
            // 
            // UserOffialAccountSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Name = "UserOffialAccountSet";
            this.Size = new System.Drawing.Size(250, 597);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOverdueDate)).EndInit();
            this.cmsOverdueDate.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private USEToggle chkBurn;
        private USEToggle chkDisturb;
        private USEToggle chkUppermost;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClearRecord;
        private System.Windows.Forms.PictureBox picOverdueDate;
        private System.Windows.Forms.Label lblOverdueDate;
        private System.Windows.Forms.Label lblReadDel;
        private System.Windows.Forms.Label lblNoDisturbing;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label lblOverdueTime;
        private CCWin.SkinControl.SkinLine skinLine2;
        private CCWin.SkinControl.SkinLine skinLine1;
        private CCWin.SkinControl.SkinContextMenuStrip cmsOverdueDate;
        private System.Windows.Forms.ToolStripMenuItem tsmForever;
        private System.Windows.Forms.ToolStripMenuItem tsmHour;
        private System.Windows.Forms.ToolStripMenuItem tsmDay;
        private System.Windows.Forms.ToolStripMenuItem tsmWeek;
        private System.Windows.Forms.ToolStripMenuItem tsmMonth;
        private System.Windows.Forms.ToolStripMenuItem tsmSeason;
        private System.Windows.Forms.ToolStripMenuItem tsmYear;
        private RoundPicBox picHead;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Button btndeleatefriend;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}
