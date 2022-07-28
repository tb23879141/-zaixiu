using TestListView;

namespace WinFrmTalk.View
{
    partial class FrmMagent
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.palMember = new TestListView.XListView();
            this.lblGroupCard = new System.Windows.Forms.Label();
            this.lblMember = new System.Windows.Forms.Label();
            this.lblMemberTable = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.palcopy = new System.Windows.Forms.Panel();
            this.picGroupCoppy = new System.Windows.Forms.PictureBox();
            this.lblcopy = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblnewsSend = new System.Windows.Forms.Label();
            this.lblTransmitWay = new System.Windows.Forms.Label();
            this.checkRoomPublic = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.lblpublic = new System.Windows.Forms.Label();
            this.checkclass = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.checkConference = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.checkupload = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.checkShowMember = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.checkAllowmembertoInvi = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.checkPrive = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.checkMemberNotice = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.checkInviteSure = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.checkReaded = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.checktalktime = new WinFrmTalk.Controls.CustomControls.USEToggle();
            this.lblCanInviteFd = new System.Windows.Forms.Label();
            this.lblCanUpload = new System.Windows.Forms.Label();
            this.lblCanCourseware = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSilence = new System.Windows.Forms.Label();
            this.c = new WinFrmTalk.RoundPicBox();
            this.lblCanShowMember = new System.Windows.Forms.Label();
            this.lblCanMeeting = new System.Windows.Forms.Label();
            this.lblPrivateChat = new System.Windows.Forms.Label();
            this.lblInviteVerification = new System.Windows.Forms.Label();
            this.lblReduce = new System.Windows.Forms.Label();
            this.lblReadPerson = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.menuDel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTran = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemMeange = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTalk = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNoTalk = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTalk30 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTalkhour = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTalkDay = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTalk3Day = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.menuiteminvisible = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemGroupnickname = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmsnewssendway = new CCWin.SkinControl.SkinContextMenuStrip();
            this.tspmDocuments = new System.Windows.Forms.ToolStripMenuItem();
            this.tspm3des = new System.Windows.Forms.ToolStripMenuItem();
            this.tspmAES = new System.Windows.Forms.ToolStripMenuItem();
            this.tspmPTP = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.palcopy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGroupCoppy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c)).BeginInit();
            this.menuDel.SuspendLayout();
            this.cmsnewssendway.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 663);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.palMember);
            this.panel3.Controls.Add(this.lblGroupCard);
            this.panel3.Controls.Add(this.lblMember);
            this.panel3.Controls.Add(this.lblMemberTable);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(255, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(297, 663);
            this.panel3.TabIndex = 1;
            // 
            // palMember
            // 
            this.palMember.BackColor = System.Drawing.Color.White;
            this.palMember.Location = new System.Drawing.Point(0, 57);
            this.palMember.Name = "palMember";
            this.palMember.ScrollBarWidth = 10;
            this.palMember.Size = new System.Drawing.Size(294, 550);
            this.palMember.TabIndex = 2;
            // 
            // lblGroupCard
            // 
            this.lblGroupCard.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGroupCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblGroupCard.Location = new System.Drawing.Point(187, 36);
            this.lblGroupCard.Name = "lblGroupCard";
            this.lblGroupCard.Size = new System.Drawing.Size(95, 20);
            this.lblGroupCard.TabIndex = 4;
            this.lblGroupCard.Text = "群名片";
            this.lblGroupCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblMember.Location = new System.Drawing.Point(41, 37);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(37, 20);
            this.lblMember.TabIndex = 3;
            this.lblMember.Text = "成员";
            // 
            // lblMemberTable
            // 
            this.lblMemberTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMemberTable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMemberTable.Location = new System.Drawing.Point(0, 0);
            this.lblMemberTable.Name = "lblMemberTable";
            this.lblMemberTable.Size = new System.Drawing.Size(297, 32);
            this.lblMemberTable.TabIndex = 0;
            this.lblMemberTable.Text = " 群成员列表";
            this.lblMemberTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.palcopy);
            this.panel2.Controls.Add(this.lblcopy);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.lblnewsSend);
            this.panel2.Controls.Add(this.lblTransmitWay);
            this.panel2.Controls.Add(this.checkRoomPublic);
            this.panel2.Controls.Add(this.lblpublic);
            this.panel2.Controls.Add(this.checkclass);
            this.panel2.Controls.Add(this.checkConference);
            this.panel2.Controls.Add(this.checkupload);
            this.panel2.Controls.Add(this.checkShowMember);
            this.panel2.Controls.Add(this.checkAllowmembertoInvi);
            this.panel2.Controls.Add(this.checkPrive);
            this.panel2.Controls.Add(this.checkMemberNotice);
            this.panel2.Controls.Add(this.checkInviteSure);
            this.panel2.Controls.Add(this.checkReaded);
            this.panel2.Controls.Add(this.checktalktime);
            this.panel2.Controls.Add(this.lblCanInviteFd);
            this.panel2.Controls.Add(this.lblCanUpload);
            this.panel2.Controls.Add(this.lblCanCourseware);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lblSilence);
            this.panel2.Controls.Add(this.c);
            this.panel2.Controls.Add(this.lblCanShowMember);
            this.panel2.Controls.Add(this.lblCanMeeting);
            this.panel2.Controls.Add(this.lblPrivateChat);
            this.panel2.Controls.Add(this.lblInviteVerification);
            this.panel2.Controls.Add(this.lblReduce);
            this.panel2.Controls.Add(this.lblReadPerson);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(255, 663);
            this.panel2.TabIndex = 0;
            // 
            // palcopy
            // 
            this.palcopy.Controls.Add(this.picGroupCoppy);
            this.palcopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.palcopy.Location = new System.Drawing.Point(103, 629);
            this.palcopy.Name = "palcopy";
            this.palcopy.Size = new System.Drawing.Size(119, 24);
            this.palcopy.TabIndex = 115;
            this.palcopy.Click += new System.EventHandler(this.picGroupCoppy_Click);
            // 
            // picGroupCoppy
            // 
            this.picGroupCoppy.BackColor = System.Drawing.Color.Transparent;
            this.picGroupCoppy.Image = global::WinFrmTalk.Properties.Resources.right;
            this.picGroupCoppy.Location = new System.Drawing.Point(97, 5);
            this.picGroupCoppy.Name = "picGroupCoppy";
            this.picGroupCoppy.Size = new System.Drawing.Size(15, 15);
            this.picGroupCoppy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGroupCoppy.TabIndex = 114;
            this.picGroupCoppy.TabStop = false;
            this.picGroupCoppy.Click += new System.EventHandler(this.picGroupCoppy_Click);
            // 
            // lblcopy
            // 
            this.lblcopy.AutoSize = true;
            this.lblcopy.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcopy.Location = new System.Drawing.Point(15, 629);
            this.lblcopy.Name = "lblcopy";
            this.lblcopy.Size = new System.Drawing.Size(80, 17);
            this.lblcopy.TabIndex = 113;
            this.lblcopy.Text = "一键复制群组";
            this.toolTip1.SetToolTip(this.lblcopy, "启用后，群成员需要群主确认才能邀请朋友进群");
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::WinFrmTalk.Properties.Resources.right;
            this.pictureBox3.Location = new System.Drawing.Point(199, 592);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(15, 15);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 112;
            this.pictureBox3.TabStop = false;
            // 
            // lblnewsSend
            // 
            this.lblnewsSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblnewsSend.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnewsSend.ForeColor = System.Drawing.Color.Black;
            this.lblnewsSend.Location = new System.Drawing.Point(103, 592);
            this.lblnewsSend.Name = "lblnewsSend";
            this.lblnewsSend.Size = new System.Drawing.Size(94, 15);
            this.lblnewsSend.TabIndex = 111;
            this.lblnewsSend.Text = "明文传输";
            this.lblnewsSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblnewsSend.Click += new System.EventHandler(this.lblnewsSend_Click);
            // 
            // lblTransmitWay
            // 
            this.lblTransmitWay.AutoSize = true;
            this.lblTransmitWay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTransmitWay.ForeColor = System.Drawing.Color.Black;
            this.lblTransmitWay.Location = new System.Drawing.Point(15, 590);
            this.lblTransmitWay.Name = "lblTransmitWay";
            this.lblTransmitWay.Size = new System.Drawing.Size(80, 17);
            this.lblTransmitWay.TabIndex = 110;
            this.lblTransmitWay.Text = "消息传输方式";
            // 
            // checkRoomPublic
            // 
            this.checkRoomPublic.BackColor = System.Drawing.Color.Transparent;
            this.checkRoomPublic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkRoomPublic.Checked = false;
            this.checkRoomPublic.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.checkRoomPublic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkRoomPublic.Location = new System.Drawing.Point(183, 148);
            this.checkRoomPublic.Name = "checkRoomPublic";
            this.checkRoomPublic.Size = new System.Drawing.Size(31, 30);
            this.checkRoomPublic.TabIndex = 40;
            this.checkRoomPublic.Tag = "8";
            // 
            // lblpublic
            // 
            this.lblpublic.AutoSize = true;
            this.lblpublic.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpublic.Location = new System.Drawing.Point(15, 155);
            this.lblpublic.Name = "lblpublic";
            this.lblpublic.Size = new System.Drawing.Size(44, 17);
            this.lblpublic.TabIndex = 39;
            this.lblpublic.Text = "公开群";
            // 
            // checkclass
            // 
            this.checkclass.BackColor = System.Drawing.Color.Transparent;
            this.checkclass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkclass.Checked = false;
            this.checkclass.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.checkclass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkclass.Location = new System.Drawing.Point(183, 540);
            this.checkclass.Name = "checkclass";
            this.checkclass.Size = new System.Drawing.Size(31, 30);
            this.checkclass.TabIndex = 38;
            this.checkclass.Tag = "11";
            // 
            // checkConference
            // 
            this.checkConference.BackColor = System.Drawing.Color.Transparent;
            this.checkConference.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkConference.Checked = false;
            this.checkConference.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.checkConference.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkConference.Location = new System.Drawing.Point(183, 502);
            this.checkConference.Name = "checkConference";
            this.checkConference.Size = new System.Drawing.Size(31, 30);
            this.checkConference.TabIndex = 37;
            this.checkConference.Tag = "6";
            // 
            // checkupload
            // 
            this.checkupload.BackColor = System.Drawing.Color.Transparent;
            this.checkupload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkupload.Checked = false;
            this.checkupload.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.checkupload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkupload.Location = new System.Drawing.Point(183, 462);
            this.checkupload.Name = "checkupload";
            this.checkupload.Size = new System.Drawing.Size(31, 30);
            this.checkupload.TabIndex = 36;
            this.checkupload.Tag = "10";
            // 
            // checkShowMember
            // 
            this.checkShowMember.BackColor = System.Drawing.Color.Transparent;
            this.checkShowMember.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkShowMember.Checked = false;
            this.checkShowMember.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.checkShowMember.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkShowMember.Location = new System.Drawing.Point(183, 422);
            this.checkShowMember.Name = "checkShowMember";
            this.checkShowMember.Size = new System.Drawing.Size(31, 30);
            this.checkShowMember.TabIndex = 35;
            this.checkShowMember.Tag = "5";
            // 
            // checkAllowmembertoInvi
            // 
            this.checkAllowmembertoInvi.BackColor = System.Drawing.Color.Transparent;
            this.checkAllowmembertoInvi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkAllowmembertoInvi.Checked = false;
            this.checkAllowmembertoInvi.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.checkAllowmembertoInvi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkAllowmembertoInvi.Location = new System.Drawing.Point(183, 383);
            this.checkAllowmembertoInvi.Name = "checkAllowmembertoInvi";
            this.checkAllowmembertoInvi.Size = new System.Drawing.Size(31, 30);
            this.checkAllowmembertoInvi.TabIndex = 34;
            this.checkAllowmembertoInvi.Tag = "12";
            // 
            // checkPrive
            // 
            this.checkPrive.BackColor = System.Drawing.Color.Transparent;
            this.checkPrive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkPrive.Checked = false;
            this.checkPrive.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.checkPrive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkPrive.Location = new System.Drawing.Point(183, 344);
            this.checkPrive.Name = "checkPrive";
            this.checkPrive.Size = new System.Drawing.Size(31, 30);
            this.checkPrive.TabIndex = 33;
            this.checkPrive.Tag = "4";
            // 
            // checkMemberNotice
            // 
            this.checkMemberNotice.BackColor = System.Drawing.Color.Transparent;
            this.checkMemberNotice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkMemberNotice.Checked = false;
            this.checkMemberNotice.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.checkMemberNotice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkMemberNotice.Location = new System.Drawing.Point(183, 304);
            this.checkMemberNotice.Name = "checkMemberNotice";
            this.checkMemberNotice.Size = new System.Drawing.Size(31, 30);
            this.checkMemberNotice.TabIndex = 32;
            this.checkMemberNotice.Tag = "3";
            // 
            // checkInviteSure
            // 
            this.checkInviteSure.BackColor = System.Drawing.Color.Transparent;
            this.checkInviteSure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkInviteSure.Checked = false;
            this.checkInviteSure.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.checkInviteSure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkInviteSure.Location = new System.Drawing.Point(183, 264);
            this.checkInviteSure.Name = "checkInviteSure";
            this.checkInviteSure.Size = new System.Drawing.Size(31, 30);
            this.checkInviteSure.TabIndex = 31;
            this.checkInviteSure.Tag = "2";
            // 
            // checkReaded
            // 
            this.checkReaded.BackColor = System.Drawing.Color.Transparent;
            this.checkReaded.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkReaded.Checked = false;
            this.checkReaded.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.checkReaded.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkReaded.Location = new System.Drawing.Point(183, 224);
            this.checkReaded.Name = "checkReaded";
            this.checkReaded.Size = new System.Drawing.Size(31, 30);
            this.checkReaded.TabIndex = 30;
            this.checkReaded.Tag = "1";
            // 
            // checktalktime
            // 
            this.checktalktime.BackColor = System.Drawing.Color.Transparent;
            this.checktalktime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checktalktime.Checked = false;
            this.checktalktime.checkStyle = WinFrmTalk.Controls.CustomControls.CheckStyle.style1;
            this.checktalktime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checktalktime.Location = new System.Drawing.Point(183, 184);
            this.checktalktime.Name = "checktalktime";
            this.checktalktime.Size = new System.Drawing.Size(31, 30);
            this.checktalktime.TabIndex = 29;
            this.checktalktime.Tag = "7";
            // 
            // lblCanInviteFd
            // 
            this.lblCanInviteFd.AutoSize = true;
            this.lblCanInviteFd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCanInviteFd.Location = new System.Drawing.Point(15, 390);
            this.lblCanInviteFd.Name = "lblCanInviteFd";
            this.lblCanInviteFd.Size = new System.Drawing.Size(128, 17);
            this.lblCanInviteFd.TabIndex = 26;
            this.lblCanInviteFd.Text = "允许普通成员邀请好友";
            this.toolTip1.SetToolTip(this.lblCanInviteFd, "关闭后普通成员将不能使用邀请功能");
            // 
            // lblCanUpload
            // 
            this.lblCanUpload.AutoSize = true;
            this.lblCanUpload.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCanUpload.Location = new System.Drawing.Point(15, 469);
            this.lblCanUpload.Name = "lblCanUpload";
            this.lblCanUpload.Size = new System.Drawing.Size(104, 17);
            this.lblCanUpload.TabIndex = 22;
            this.lblCanUpload.Text = "允许普通成员上传";
            this.toolTip1.SetToolTip(this.lblCanUpload, "关闭后，普通成员将不能上传群共享文件和发送文件信息");
            // 
            // lblCanCourseware
            // 
            this.lblCanCourseware.AutoSize = true;
            this.lblCanCourseware.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCanCourseware.Location = new System.Drawing.Point(15, 549);
            this.lblCanCourseware.Name = "lblCanCourseware";
            this.lblCanCourseware.Size = new System.Drawing.Size(128, 17);
            this.lblCanCourseware.TabIndex = 20;
            this.lblCanCourseware.Text = "允许普通成员发起课件";
            this.toolTip1.SetToolTip(this.lblCanCourseware, "关闭后，普通成员将不能在群内发送Ta的课件");
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Silver;
            this.label10.Location = new System.Drawing.Point(238, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(1, 649);
            this.label10.TabIndex = 19;
            // 
            // lblSilence
            // 
            this.lblSilence.AutoSize = true;
            this.lblSilence.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSilence.Location = new System.Drawing.Point(15, 191);
            this.lblSilence.Name = "lblSilence";
            this.lblSilence.Size = new System.Drawing.Size(56, 17);
            this.lblSilence.TabIndex = 15;
            this.lblSilence.Text = "全体禁言";
            // 
            // c
            // 
            this.c.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.c.isDrawRound = true;
            this.c.Location = new System.Drawing.Point(85, 22);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(60, 60);
            this.c.TabIndex = 14;
            this.c.TabStop = false;
            // 
            // lblCanShowMember
            // 
            this.lblCanShowMember.AutoSize = true;
            this.lblCanShowMember.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCanShowMember.Location = new System.Drawing.Point(15, 429);
            this.lblCanShowMember.Name = "lblCanShowMember";
            this.lblCanShowMember.Size = new System.Drawing.Size(92, 17);
            this.lblCanShowMember.TabIndex = 7;
            this.lblCanShowMember.Text = "允许显示群成员";
            this.toolTip1.SetToolTip(this.lblCanShowMember, "关闭后，普通成员在群组内信息将看不到其他成员，只显示群主与自己");
            // 
            // lblCanMeeting
            // 
            this.lblCanMeeting.AutoSize = true;
            this.lblCanMeeting.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCanMeeting.Location = new System.Drawing.Point(15, 509);
            this.lblCanMeeting.Name = "lblCanMeeting";
            this.lblCanMeeting.Size = new System.Drawing.Size(128, 17);
            this.lblCanMeeting.TabIndex = 6;
            this.lblCanMeeting.Text = "允许普通成员发起会议";
            this.toolTip1.SetToolTip(this.lblCanMeeting, "关闭后，普通成员将不能主动发起语音会议和视频会议");
            // 
            // lblPrivateChat
            // 
            this.lblPrivateChat.AutoSize = true;
            this.lblPrivateChat.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrivateChat.Location = new System.Drawing.Point(15, 351);
            this.lblPrivateChat.Name = "lblPrivateChat";
            this.lblPrivateChat.Size = new System.Drawing.Size(104, 17);
            this.lblPrivateChat.TabIndex = 5;
            this.lblPrivateChat.Text = "允许普通成员私聊";
            this.toolTip1.SetToolTip(this.lblPrivateChat, "关闭后不允许发送名片信息，且普通成员在群聊界面、群组、信息内点击图像无反应");
            // 
            // lblInviteVerification
            // 
            this.lblInviteVerification.AutoSize = true;
            this.lblInviteVerification.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInviteVerification.Location = new System.Drawing.Point(15, 271);
            this.lblInviteVerification.Name = "lblInviteVerification";
            this.lblInviteVerification.Size = new System.Drawing.Size(80, 17);
            this.lblInviteVerification.TabIndex = 4;
            this.lblInviteVerification.Text = "群组邀请确认";
            this.toolTip1.SetToolTip(this.lblInviteVerification, "启用后，群成员需要群主确认才能邀请朋友进群");
            // 
            // lblReduce
            // 
            this.lblReduce.AutoSize = true;
            this.lblReduce.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReduce.Location = new System.Drawing.Point(15, 311);
            this.lblReduce.Name = "lblReduce";
            this.lblReduce.Size = new System.Drawing.Size(80, 17);
            this.lblReduce.TabIndex = 3;
            this.lblReduce.Text = "群组减员通知";
            this.toolTip1.SetToolTip(this.lblReduce, "关闭后，当群成员被踢出群组或主动退群时，群组内不进行通知");
            // 
            // lblReadPerson
            // 
            this.lblReadPerson.AutoSize = true;
            this.lblReadPerson.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReadPerson.Location = new System.Drawing.Point(15, 231);
            this.lblReadPerson.Name = "lblReadPerson";
            this.lblReadPerson.Size = new System.Drawing.Size(80, 17);
            this.lblReadPerson.TabIndex = 2;
            this.lblReadPerson.Text = "显示已读人数";
            this.toolTip1.SetToolTip(this.lblReadPerson, "启用后，当前群组得消息页面的每条消息左侧都会显示该条消息的已读人数，点击还可以查看已读人员列表");
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(15, 93);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(200, 50);
            this.lblName.TabIndex = 1;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.UseMnemonic = false;
            // 
            // menuDel
            // 
            this.menuDel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuDel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemInfo,
            this.MenuItemTran,
            this.MenuItemMeange,
            this.MenuItemTalk,
            this.MenuItemRemove,
            this.menuiteminvisible,
            this.menuitemGroupnickname});
            this.menuDel.Name = "contextMenuStrip1";
            this.menuDel.Size = new System.Drawing.Size(135, 158);
            // 
            // MenuItemInfo
            // 
            this.MenuItemInfo.Name = "MenuItemInfo";
            this.MenuItemInfo.Size = new System.Drawing.Size(134, 22);
            this.MenuItemInfo.Text = "查看详情";
            this.MenuItemInfo.Click += new System.EventHandler(this.TSMseeinfo_Click);
            // 
            // MenuItemTran
            // 
            this.MenuItemTran.Name = "MenuItemTran";
            this.MenuItemTran.Size = new System.Drawing.Size(134, 22);
            this.MenuItemTran.Text = "转让群主";
            this.MenuItemTran.Click += new System.EventHandler(this.TSMtransfer_Click);
            // 
            // MenuItemMeange
            // 
            this.MenuItemMeange.Name = "MenuItemMeange";
            this.MenuItemMeange.Size = new System.Drawing.Size(134, 22);
            this.MenuItemMeange.Text = "指定管理员";
            this.MenuItemMeange.Click += new System.EventHandler(this.TSMAdmin_Click);
            // 
            // MenuItemTalk
            // 
            this.MenuItemTalk.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemNoTalk,
            this.MenuItemTalk30,
            this.MenuItemTalkhour,
            this.MenuItemTalkDay,
            this.MenuItemTalk3Day});
            this.MenuItemTalk.Name = "MenuItemTalk";
            this.MenuItemTalk.Size = new System.Drawing.Size(134, 22);
            this.MenuItemTalk.Text = "禁言";
            // 
            // MenuItemNoTalk
            // 
            this.MenuItemNoTalk.Name = "MenuItemNoTalk";
            this.MenuItemNoTalk.Size = new System.Drawing.Size(141, 22);
            this.MenuItemNoTalk.Tag = "1";
            this.MenuItemNoTalk.Text = "不禁言";
            this.MenuItemNoTalk.Click += new System.EventHandler(this.MemberNoTalk);
            // 
            // MenuItemTalk30
            // 
            this.MenuItemTalk30.Name = "MenuItemTalk30";
            this.MenuItemTalk30.Size = new System.Drawing.Size(141, 22);
            this.MenuItemTalk30.Tag = "2";
            this.MenuItemTalk30.Text = "禁言30分钟";
            this.MenuItemTalk30.Click += new System.EventHandler(this.MemberNoTalk);
            // 
            // MenuItemTalkhour
            // 
            this.MenuItemTalkhour.Name = "MenuItemTalkhour";
            this.MenuItemTalkhour.Size = new System.Drawing.Size(141, 22);
            this.MenuItemTalkhour.Tag = "3";
            this.MenuItemTalkhour.Text = "禁言1个小时";
            this.MenuItemTalkhour.Click += new System.EventHandler(this.MemberNoTalk);
            // 
            // MenuItemTalkDay
            // 
            this.MenuItemTalkDay.Name = "MenuItemTalkDay";
            this.MenuItemTalkDay.Size = new System.Drawing.Size(141, 22);
            this.MenuItemTalkDay.Tag = "4";
            this.MenuItemTalkDay.Text = "禁言1天";
            this.MenuItemTalkDay.Click += new System.EventHandler(this.MemberNoTalk);
            // 
            // MenuItemTalk3Day
            // 
            this.MenuItemTalk3Day.Name = "MenuItemTalk3Day";
            this.MenuItemTalk3Day.Size = new System.Drawing.Size(141, 22);
            this.MenuItemTalk3Day.Tag = "5";
            this.MenuItemTalk3Day.Text = "禁言3天";
            this.MenuItemTalk3Day.Click += new System.EventHandler(this.MemberNoTalk);
            // 
            // MenuItemRemove
            // 
            this.MenuItemRemove.Name = "MenuItemRemove";
            this.MenuItemRemove.Size = new System.Drawing.Size(134, 22);
            this.MenuItemRemove.Text = "从本群移除";
            this.MenuItemRemove.Click += new System.EventHandler(this.TsmFromTomove);
            // 
            // menuiteminvisible
            // 
            this.menuiteminvisible.Name = "menuiteminvisible";
            this.menuiteminvisible.Size = new System.Drawing.Size(134, 22);
            this.menuiteminvisible.Text = "指定隐身人";
            this.menuiteminvisible.Click += new System.EventHandler(this.menuiteminvisible_Click);
            // 
            // menuitemGroupnickname
            // 
            this.menuitemGroupnickname.Name = "menuitemGroupnickname";
            this.menuitemGroupnickname.Size = new System.Drawing.Size(134, 22);
            this.menuitemGroupnickname.Text = "群内备注";
            this.menuitemGroupnickname.Visible = false;
            this.menuitemGroupnickname.Click += new System.EventHandler(this.menuitemGroupnickname_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "群名片";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // cmsnewssendway
            // 
            this.cmsnewssendway.Arrow = System.Drawing.Color.Black;
            this.cmsnewssendway.Back = System.Drawing.Color.White;
            this.cmsnewssendway.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsnewssendway.BackRadius = 4;
            this.cmsnewssendway.Base = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsnewssendway.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsnewssendway.Fore = System.Drawing.Color.Black;
            this.cmsnewssendway.HoverFore = System.Drawing.Color.Black;
            this.cmsnewssendway.ItemAnamorphosis = false;
            this.cmsnewssendway.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsnewssendway.ItemBorderShow = false;
            this.cmsnewssendway.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsnewssendway.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsnewssendway.ItemRadius = 4;
            this.cmsnewssendway.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsnewssendway.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspmDocuments,
            this.tspm3des,
            this.tspmAES,
            this.tspmPTP});
            this.cmsnewssendway.ItemSplitter = System.Drawing.Color.Silver;
            this.cmsnewssendway.Name = "cmsnewssendway";
            this.cmsnewssendway.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsnewssendway.Size = new System.Drawing.Size(155, 92);
            this.cmsnewssendway.SkinAllColor = true;
            this.cmsnewssendway.Tag = "";
            this.cmsnewssendway.TitleAnamorphosis = true;
            this.cmsnewssendway.TitleColor = System.Drawing.Color.White;
            this.cmsnewssendway.TitleRadius = 4;
            this.cmsnewssendway.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // tspmDocuments
            // 
            this.tspmDocuments.Name = "tspmDocuments";
            this.tspmDocuments.Size = new System.Drawing.Size(154, 22);
            this.tspmDocuments.Text = "明文传输";
            this.tspmDocuments.Click += new System.EventHandler(this.SelectEncryptType);
            // 
            // tspm3des
            // 
            this.tspm3des.Name = "tspm3des";
            this.tspm3des.Size = new System.Drawing.Size(154, 22);
            this.tspm3des.Text = "3DES加密传输";
            this.tspm3des.Click += new System.EventHandler(this.SelectEncryptType);
            // 
            // tspmAES
            // 
            this.tspmAES.Name = "tspmAES";
            this.tspmAES.Size = new System.Drawing.Size(154, 22);
            this.tspmAES.Text = "AES加密传输";
            this.tspmAES.Click += new System.EventHandler(this.SelectEncryptType);
            // 
            // tspmPTP
            // 
            this.tspmPTP.Name = "tspmPTP";
            this.tspmPTP.Size = new System.Drawing.Size(154, 22);
            this.tspmPTP.Text = "端对端加密";
            this.tspmPTP.Click += new System.EventHandler(this.SelectEncryptType);
            // 
            // FrmMagent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 695);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMagent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "群管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMagent_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.palcopy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGroupCoppy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c)).EndInit();
            this.menuDel.ResumeLayout(false);
            this.cmsnewssendway.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMemberTable;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ContextMenuStrip menuDel;
        private System.Windows.Forms.ToolStripMenuItem MenuItemInfo;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTran;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMeange;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTalk;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNoTalk;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTalk30;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTalkhour;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTalkDay;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTalk3Day;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRemove;
        private System.Windows.Forms.Label lblInviteVerification;
        private System.Windows.Forms.Label lblReduce;
        private System.Windows.Forms.Label lblReadPerson;
        private System.Windows.Forms.Label lblCanShowMember;
        private System.Windows.Forms.Label lblCanMeeting;
        private System.Windows.Forms.Label lblPrivateChat;
       
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label lblGroupCard;
        private System.Windows.Forms.Label lblMember;
        private RoundPicBox c;
        private System.Windows.Forms.Label lblSilence;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCanCourseware;
        private System.Windows.Forms.Label lblCanUpload;
        private System.Windows.Forms.Label lblCanInviteFd;
        private System.Windows.Forms.ToolStripMenuItem menuiteminvisible;
        private XListView palMember;
        private Controls.CustomControls.USEToggle checktalktime;
        private Controls.CustomControls.USEToggle checkclass;
        private Controls.CustomControls.USEToggle checkConference;
        private Controls.CustomControls.USEToggle checkupload;
        private Controls.CustomControls.USEToggle checkShowMember;
        private Controls.CustomControls.USEToggle checkAllowmembertoInvi;
        private Controls.CustomControls.USEToggle checkPrive;
        private Controls.CustomControls.USEToggle checkMemberNotice;
        private Controls.CustomControls.USEToggle checkInviteSure;
        private Controls.CustomControls.USEToggle checkReaded;
        private System.Windows.Forms.ToolTip toolTip1;
        private Controls.CustomControls.USEToggle checkRoomPublic;
        private System.Windows.Forms.Label lblpublic;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblnewsSend;
        private System.Windows.Forms.Label lblTransmitWay;
        private CCWin.SkinControl.SkinContextMenuStrip cmsnewssendway;
        private System.Windows.Forms.ToolStripMenuItem tspmDocuments;
        private System.Windows.Forms.ToolStripMenuItem tspm3des;
        private System.Windows.Forms.ToolStripMenuItem tspmAES;
        private System.Windows.Forms.ToolStripMenuItem tspmPTP;
        private System.Windows.Forms.ToolStripMenuItem menuitemGroupnickname;
        private System.Windows.Forms.PictureBox picGroupCoppy;
        private System.Windows.Forms.Label lblcopy;
        private System.Windows.Forms.Panel palcopy;
    }
}