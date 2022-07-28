namespace WinFrmTalk.Controls.CustomControls
{
    partial class USEGroupSet
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
            this.panelGroupNo = new System.Windows.Forms.Panel();
            this.labelGroupNo = new System.Windows.Forms.Label();
            this.pictureBoxCopy = new System.Windows.Forms.PictureBox();
            this.lblGroupNo = new WinFrmTalk.InfoCard();
            this.btnseemore = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabMember = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new WinFrmTalk.Controls.CustomControls.USEpicAddName();
            this.btnDel = new WinFrmTalk.Controls.CustomControls.USEpicAddName();
            this.palgroupCtl = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new WinFrmTalk.InfoCard();
            this.lblNotice = new WinFrmTalk.InfoCard();
            this.lblMenge = new WinFrmTalk.InfoCard();
            this.lblNickname = new WinFrmTalk.InfoCard();
            this.lblQRCode = new WinFrmTalk.InfoCard();
            this.lblFile = new WinFrmTalk.InfoCard();
            this.lblDes = new WinFrmTalk.InfoCard();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblOverdueTime = new System.Windows.Forms.Label();
            this.lblOverdueDate = new System.Windows.Forms.Label();
            this.lblSpiltLine = new System.Windows.Forms.Label();
            this.lblNoDisturbing = new WinFrmTalk.Controls.CustomControls.USeCheckData();
            this.lblTop = new WinFrmTalk.Controls.CustomControls.USeCheckData();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnexite = new System.Windows.Forms.Button();
            this.infoCard1 = new WinFrmTalk.InfoCard();
            this.cmsOverdueDate = new CCWin.SkinControl.SkinContextMenuStrip();
            this.tsmForever = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHour = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSeason = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmYear = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLeftLine = new System.Windows.Forms.Label();
            this.showInfoVScroll = new WinFrmTalk.MyVScrollBar();
            this.panelGroupNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCopy)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabMember.SuspendLayout();
            this.palgroupCtl.SuspendLayout();
            this.panel3.SuspendLayout();
            this.cmsOverdueDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGroupNo
            // 
            this.panelGroupNo.Controls.Add(this.labelGroupNo);
            this.panelGroupNo.Controls.Add(this.pictureBoxCopy);
            this.panelGroupNo.Controls.Add(this.lblGroupNo);
            this.panelGroupNo.Location = new System.Drawing.Point(2, 61);
            this.panelGroupNo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelGroupNo.Name = "panelGroupNo";
            this.panelGroupNo.Size = new System.Drawing.Size(232, 35);
            this.panelGroupNo.TabIndex = 47;
            this.panelGroupNo.MouseEnter += new System.EventHandler(this.panelGroupNo_MouseEnter);
            this.panelGroupNo.MouseLeave += new System.EventHandler(this.panelGroupNo_MouseLeave);
            // 
            // labelGroupNo
            // 
            this.labelGroupNo.BackColor = System.Drawing.Color.Transparent;
            this.labelGroupNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.labelGroupNo.Location = new System.Drawing.Point(54, 12);
            this.labelGroupNo.Name = "labelGroupNo";
            this.labelGroupNo.Size = new System.Drawing.Size(140, 17);
            this.labelGroupNo.TabIndex = 49;
            this.labelGroupNo.Text = "11111111111";
            this.labelGroupNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelGroupNo.Click += new System.EventHandler(this.labelGroupNo_Click);
            this.labelGroupNo.MouseEnter += new System.EventHandler(this.panelGroupNo_MouseEnter);
            this.labelGroupNo.MouseLeave += new System.EventHandler(this.panelGroupNo_MouseLeave);
            // 
            // pictureBoxCopy
            // 
            this.pictureBoxCopy.Image = global::WinFrmTalk.Properties.Resources.msgcopy;
            this.pictureBoxCopy.Location = new System.Drawing.Point(201, 11);
            this.pictureBoxCopy.Name = "pictureBoxCopy";
            this.pictureBoxCopy.Size = new System.Drawing.Size(18, 18);
            this.pictureBoxCopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCopy.TabIndex = 48;
            this.pictureBoxCopy.TabStop = false;
            this.pictureBoxCopy.Click += new System.EventHandler(this.pictureBoxCopy_Click);
            this.pictureBoxCopy.MouseEnter += new System.EventHandler(this.panelGroupNo_MouseEnter);
            this.pictureBoxCopy.MouseLeave += new System.EventHandler(this.panelGroupNo_MouseLeave);
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.BackColor = System.Drawing.Color.White;
            this.lblGroupNo.btnImage = null;
            this.lblGroupNo.FunctionInfo = "1234";
            this.lblGroupNo.FunctionName = "群号";
            this.lblGroupNo.IsButtonShow = false;
            this.lblGroupNo.ISFunctionInfo = false;
            this.lblGroupNo.IsShowTxtBox = false;
            this.lblGroupNo.Location = new System.Drawing.Point(0, 0);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(195, 35);
            this.lblGroupNo.TabIndex = 47;
            this.lblGroupNo.TagValue = 0;
            this.lblGroupNo.Load += new System.EventHandler(this.lblGroupNo_Load);
            this.lblGroupNo.Click += new System.EventHandler(this.lblGroupNo_Click);
            // 
            // btnseemore
            // 
            this.btnseemore.AutoSize = true;
            this.btnseemore.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnseemore.Location = new System.Drawing.Point(60, 0);
            this.btnseemore.Margin = new System.Windows.Forms.Padding(60, 0, 3, 0);
            this.btnseemore.Name = "btnseemore";
            this.btnseemore.Size = new System.Drawing.Size(92, 17);
            this.btnseemore.TabIndex = 2;
            this.btnseemore.Text = "查看更多群成员";
            this.btnseemore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnseemore.Click += new System.EventHandler(this.btnSeeMore_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.palgroupCtl);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 680);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.tabMember);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.MaximumSize = new System.Drawing.Size(230, 137);
            this.panel2.MinimumSize = new System.Drawing.Size(230, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 72);
            this.panel2.TabIndex = 62;
            // 
            // tabMember
            // 
            this.tabMember.AutoSize = true;
            this.tabMember.Controls.Add(this.btnAdd);
            this.tabMember.Controls.Add(this.btnDel);
            this.tabMember.Location = new System.Drawing.Point(3, 0);
            this.tabMember.MaximumSize = new System.Drawing.Size(225, 137);
            this.tabMember.MinimumSize = new System.Drawing.Size(225, 68);
            this.tabMember.Name = "tabMember";
            this.tabMember.Size = new System.Drawing.Size(225, 69);
            this.tabMember.TabIndex = 60;
            // 
            // btnAdd
            // 
            this.btnAdd.CurrentRole = 0;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(10, 8);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(10, 8, 3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.NickName = "添加";
            this.btnAdd.roomjid = null;
            this.btnAdd.Size = new System.Drawing.Size(42, 57);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Userid = null;
            this.btnAdd.Visible = false;
            // 
            // btnDel
            // 
            this.btnDel.CurrentRole = 0;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Location = new System.Drawing.Point(65, 8);
            this.btnDel.Margin = new System.Windows.Forms.Padding(10, 8, 3, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.NickName = "删除";
            this.btnDel.roomjid = null;
            this.btnDel.Size = new System.Drawing.Size(42, 57);
            this.btnDel.TabIndex = 2;
            this.btnDel.Userid = null;
            this.btnDel.Visible = false;
            // 
            // palgroupCtl
            // 
            this.palgroupCtl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.palgroupCtl.Controls.Add(this.btnseemore);
            this.palgroupCtl.Controls.Add(this.lblName);
            this.palgroupCtl.Controls.Add(this.panelGroupNo);
            this.palgroupCtl.Controls.Add(this.lblNotice);
            this.palgroupCtl.Controls.Add(this.lblMenge);
            this.palgroupCtl.Controls.Add(this.lblNickname);
            this.palgroupCtl.Controls.Add(this.lblQRCode);
            this.palgroupCtl.Controls.Add(this.lblFile);
            this.palgroupCtl.Controls.Add(this.lblDes);
            this.palgroupCtl.Controls.Add(this.panel3);
            this.palgroupCtl.Controls.Add(this.lblSpiltLine);
            this.palgroupCtl.Controls.Add(this.lblNoDisturbing);
            this.palgroupCtl.Controls.Add(this.lblTop);
            this.palgroupCtl.Controls.Add(this.btnclear);
            this.palgroupCtl.Controls.Add(this.btnexite);
            this.palgroupCtl.Controls.Add(this.infoCard1);
            this.palgroupCtl.Location = new System.Drawing.Point(5, 82);
            this.palgroupCtl.MaximumSize = new System.Drawing.Size(225, 580);
            this.palgroupCtl.MinimumSize = new System.Drawing.Size(225, 479);
            this.palgroupCtl.Name = "palgroupCtl";
            this.palgroupCtl.Size = new System.Drawing.Size(225, 580);
            this.palgroupCtl.TabIndex = 61;
            this.palgroupCtl.Visible = false;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.btnImage = null;
            this.lblName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.FunctionInfo = "";
            this.lblName.FunctionName = "群组名称";
            this.lblName.IsButtonShow = false;
            this.lblName.ISFunctionInfo = true;
            this.lblName.IsShowTxtBox = false;
            this.lblName.Location = new System.Drawing.Point(2, 20);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(232, 35);
            this.lblName.TabIndex = 46;
            this.lblName.Tag = "1";
            this.lblName.TagValue = 0;
            // 
            // lblNotice
            // 
            this.lblNotice.BackColor = System.Drawing.Color.White;
            this.lblNotice.btnImage = null;
            this.lblNotice.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNotice.FunctionInfo = "";
            this.lblNotice.FunctionName = "群公告";
            this.lblNotice.IsButtonShow = false;
            this.lblNotice.ISFunctionInfo = true;
            this.lblNotice.IsShowTxtBox = false;
            this.lblNotice.Location = new System.Drawing.Point(2, 102);
            this.lblNotice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(240, 35);
            this.lblNotice.TabIndex = 65;
            this.lblNotice.Tag = "2";
            this.lblNotice.TagValue = 0;
            this.lblNotice.Visible = false;
            this.lblNotice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.infoNotice_MouseDown);
            // 
            // lblMenge
            // 
            this.lblMenge.BackColor = System.Drawing.Color.White;
            this.lblMenge.btnImage = null;
            this.lblMenge.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMenge.FunctionInfo = "";
            this.lblMenge.FunctionName = "群管理";
            this.lblMenge.IsButtonShow = true;
            this.lblMenge.ISFunctionInfo = false;
            this.lblMenge.IsShowTxtBox = false;
            this.lblMenge.Location = new System.Drawing.Point(2, 143);
            this.lblMenge.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblMenge.Name = "lblMenge";
            this.lblMenge.Size = new System.Drawing.Size(232, 35);
            this.lblMenge.TabIndex = 66;
            this.lblMenge.TagValue = 0;
            this.lblMenge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.infoMenge_MouseDown);
            // 
            // lblNickname
            // 
            this.lblNickname.BackColor = System.Drawing.Color.White;
            this.lblNickname.btnImage = null;
            this.lblNickname.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNickname.FunctionInfo = "";
            this.lblNickname.FunctionName = "我在群里的昵称";
            this.lblNickname.IsButtonShow = false;
            this.lblNickname.ISFunctionInfo = true;
            this.lblNickname.IsShowTxtBox = false;
            this.lblNickname.Location = new System.Drawing.Point(2, 184);
            this.lblNickname.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(232, 35);
            this.lblNickname.TabIndex = 3;
            this.lblNickname.Tag = "3";
            this.lblNickname.TagValue = 0;
            // 
            // lblQRCode
            // 
            this.lblQRCode.BackColor = System.Drawing.Color.White;
            this.lblQRCode.btnImage = null;
            this.lblQRCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQRCode.FunctionInfo = "";
            this.lblQRCode.FunctionName = "群二维码";
            this.lblQRCode.IsButtonShow = true;
            this.lblQRCode.ISFunctionInfo = false;
            this.lblQRCode.IsShowTxtBox = false;
            this.lblQRCode.Location = new System.Drawing.Point(2, 225);
            this.lblQRCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblQRCode.Name = "lblQRCode";
            this.lblQRCode.Size = new System.Drawing.Size(229, 35);
            this.lblQRCode.TabIndex = 68;
            this.lblQRCode.Tag = "4";
            this.lblQRCode.TagValue = 0;
            this.lblQRCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.infoGroupQRCode_MouseDown);
            // 
            // lblFile
            // 
            this.lblFile.BackColor = System.Drawing.Color.White;
            this.lblFile.btnImage = global::WinFrmTalk.Properties.Resources.Rig;
            this.lblFile.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFile.FunctionInfo = "";
            this.lblFile.FunctionName = "群文件";
            this.lblFile.IsButtonShow = true;
            this.lblFile.ISFunctionInfo = false;
            this.lblFile.IsShowTxtBox = false;
            this.lblFile.Location = new System.Drawing.Point(2, 266);
            this.lblFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(229, 35);
            this.lblFile.TabIndex = 64;
            this.lblFile.TagValue = 2;
            this.lblFile.Visible = false;
            this.lblFile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.infoCard18_MouseDown);
            // 
            // lblDes
            // 
            this.lblDes.BackColor = System.Drawing.Color.White;
            this.lblDes.btnImage = null;
            this.lblDes.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDes.FunctionInfo = "";
            this.lblDes.FunctionName = "群组描述";
            this.lblDes.IsButtonShow = false;
            this.lblDes.ISFunctionInfo = true;
            this.lblDes.IsShowTxtBox = true;
            this.lblDes.Location = new System.Drawing.Point(2, 307);
            this.lblDes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(225, 35);
            this.lblDes.TabIndex = 67;
            this.lblDes.Tag = "4";
            this.lblDes.TagValue = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblOverdueTime);
            this.panel3.Controls.Add(this.lblOverdueDate);
            this.panel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel3.Location = new System.Drawing.Point(3, 348);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 35);
            this.panel3.TabIndex = 69;
            this.panel3.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            // 
            // lblOverdueTime
            // 
            this.lblOverdueTime.AutoSize = true;
            this.lblOverdueTime.ForeColor = System.Drawing.Color.Black;
            this.lblOverdueTime.Location = new System.Drawing.Point(12, 11);
            this.lblOverdueTime.Name = "lblOverdueTime";
            this.lblOverdueTime.Size = new System.Drawing.Size(80, 17);
            this.lblOverdueTime.TabIndex = 57;
            this.lblOverdueTime.Text = "消息过期时间";
            // 
            // lblOverdueDate
            // 
            this.lblOverdueDate.ForeColor = System.Drawing.Color.Black;
            this.lblOverdueDate.Location = new System.Drawing.Point(132, 9);
            this.lblOverdueDate.Name = "lblOverdueDate";
            this.lblOverdueDate.Size = new System.Drawing.Size(86, 19);
            this.lblOverdueDate.TabIndex = 56;
            this.lblOverdueDate.Text = "永久";
            this.lblOverdueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOverdueDate.Click += new System.EventHandler(this.lblOverdueDate_Click);
            // 
            // lblSpiltLine
            // 
            this.lblSpiltLine.BackColor = System.Drawing.Color.LightGray;
            this.lblSpiltLine.Location = new System.Drawing.Point(17, 386);
            this.lblSpiltLine.Margin = new System.Windows.Forms.Padding(17, 0, 3, 0);
            this.lblSpiltLine.Name = "lblSpiltLine";
            this.lblSpiltLine.Size = new System.Drawing.Size(199, 1);
            this.lblSpiltLine.TabIndex = 70;
            this.lblSpiltLine.Text = "label1";
            // 
            // lblNoDisturbing
            // 
            this.lblNoDisturbing.FunctionName = "消息免打扰";
            this.lblNoDisturbing.Location = new System.Drawing.Point(3, 390);
            this.lblNoDisturbing.Name = "lblNoDisturbing";
            this.lblNoDisturbing.Size = new System.Drawing.Size(225, 35);
            this.lblNoDisturbing.TabIndex = 73;
            this.lblNoDisturbing.Tag = "2";
            // 
            // lblTop
            // 
            this.lblTop.FunctionName = "置顶聊天";
            this.lblTop.Location = new System.Drawing.Point(3, 431);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(224, 35);
            this.lblTop.TabIndex = 71;
            this.lblTop.Tag = "3";
            // 
            // btnclear
            // 
            this.btnclear.BackgroundImage = global::WinFrmTalk.Properties.Resources.ic_button_bg1;
            this.btnclear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclear.FlatAppearance.BorderSize = 0;
            this.btnclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclear.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnclear.ForeColor = System.Drawing.Color.White;
            this.btnclear.Location = new System.Drawing.Point(63, 477);
            this.btnclear.Margin = new System.Windows.Forms.Padding(63, 8, 3, 3);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(110, 34);
            this.btnclear.TabIndex = 74;
            this.btnclear.Text = "清空聊天记录";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.lblClearChat_Click);
            // 
            // btnexite
            // 
            this.btnexite.BackColor = System.Drawing.Color.Transparent;
            this.btnexite.BackgroundImage = global::WinFrmTalk.Properties.Resources.ic_button_bg1;
            this.btnexite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnexite.FlatAppearance.BorderSize = 0;
            this.btnexite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexite.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnexite.ForeColor = System.Drawing.Color.White;
            this.btnexite.Location = new System.Drawing.Point(63, 524);
            this.btnexite.Margin = new System.Windows.Forms.Padding(63, 10, 3, 3);
            this.btnexite.Name = "btnexite";
            this.btnexite.Size = new System.Drawing.Size(110, 34);
            this.btnexite.TabIndex = 75;
            this.btnexite.Text = "删除并并退出";
            this.btnexite.UseVisualStyleBackColor = false;
            this.btnexite.Click += new System.EventHandler(this.btnDelAndExite_Click);
            // 
            // infoCard1
            // 
            this.infoCard1.BackColor = System.Drawing.Color.White;
            this.infoCard1.btnImage = null;
            this.infoCard1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.infoCard1.FunctionInfo = "";
            this.infoCard1.FunctionName = "群公告";
            this.infoCard1.IsButtonShow = false;
            this.infoCard1.ISFunctionInfo = true;
            this.infoCard1.IsShowTxtBox = false;
            this.infoCard1.Location = new System.Drawing.Point(3, 565);
            this.infoCard1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.infoCard1.Name = "infoCard1";
            this.infoCard1.Size = new System.Drawing.Size(186, 35);
            this.infoCard1.TabIndex = 76;
            this.infoCard1.Tag = "2";
            this.infoCard1.TagValue = 0;
            this.infoCard1.Visible = false;
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
            this.tsmForever.Text = "永不";
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
            // lblLeftLine
            // 
            this.lblLeftLine.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblLeftLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLeftLine.Location = new System.Drawing.Point(0, 0);
            this.lblLeftLine.Name = "lblLeftLine";
            this.lblLeftLine.Size = new System.Drawing.Size(1, 644);
            this.lblLeftLine.TabIndex = 3;
            this.lblLeftLine.Text = "label2";
            // 
            // showInfoVScroll
            // 
            this.showInfoVScroll.BackColor = System.Drawing.Color.Transparent;
            this.showInfoVScroll.canAdd = 0;
            this.showInfoVScroll.canTop = 0;
            this.showInfoVScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.showInfoVScroll.Location = new System.Drawing.Point(241, 0);
            this.showInfoVScroll.Name = "showInfoVScroll";
            this.showInfoVScroll.Size = new System.Drawing.Size(12, 644);
            this.showInfoVScroll.TabIndex = 2;
            this.showInfoVScroll.Visible = false;
            // 
            // USEGroupSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLeftLine);
            this.Controls.Add(this.showInfoVScroll);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "USEGroupSet";
            this.Size = new System.Drawing.Size(253, 644);
            this.Load += new System.EventHandler(this.USEGroupSet_Load);
            this.panelGroupNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCopy)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabMember.ResumeLayout(false);
            this.palgroupCtl.ResumeLayout(false);
            this.palgroupCtl.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.cmsOverdueDate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label btnseemore;
        private CCWin.SkinControl.SkinContextMenuStrip cmsOverdueDate;
        private System.Windows.Forms.ToolStripMenuItem tsmForever;
        private System.Windows.Forms.ToolStripMenuItem tsmHour;
        private System.Windows.Forms.ToolStripMenuItem tsmDay;
        private System.Windows.Forms.ToolStripMenuItem tsmWeek;
        private System.Windows.Forms.ToolStripMenuItem tsmMonth;
        private System.Windows.Forms.ToolStripMenuItem tsmSeason;
        private System.Windows.Forms.ToolStripMenuItem tsmYear;
        private System.Windows.Forms.FlowLayoutPanel tabMember;
        private USEpicAddName btnAdd;
        private USEpicAddName btnDel;
        private USeCheckData lblNoDisturbing;
        private USeCheckData lblTop;
        private System.Windows.Forms.FlowLayoutPanel palgroupCtl;
        public InfoCard lblName;
        private InfoCard lblMenge;
        private InfoCard lblQRCode;
        private InfoCard lblFile;
        private InfoCard lblDes;
        private InfoCard lblNotice;
        private InfoCard lblGroupNo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblOverdueTime;
        private System.Windows.Forms.Label lblOverdueDate;
        private System.Windows.Forms.Label lblSpiltLine;
        public MyVScrollBar showInfoVScroll;
        public System.Windows.Forms.Panel panel1;
        private InfoCard lblNickname;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLeftLine;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnexite;
        private InfoCard infoCard1;
        public System.Windows.Forms.Panel panelGroupNo;
        private System.Windows.Forms.PictureBox pictureBoxCopy;
        private System.Windows.Forms.Label labelGroupNo;
    }
}
