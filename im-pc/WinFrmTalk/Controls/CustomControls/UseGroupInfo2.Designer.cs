using TestListView;

namespace WinFrmTalk.Controls.CustomControls
{
    partial class UseGroupInfo2
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
            this.components = new System.ComponentModel.Container();
            WinFrmTalk.Model.Friend friend1 = new WinFrmTalk.Model.Friend();
            this.label1 = new System.Windows.Forms.Label();
            this.tvName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lab_detial = new System.Windows.Forms.Label();
            this.btnGroupOrganiz = new System.Windows.Forms.PictureBox();
            this.ivLevelSwitch = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.rightLayout = new WinFrmTalk.Controls.LayouotControl.Groups.GroupIndicateLayout();
            this.groupPageMain1 = new WinFrmTalk.Controls.LayouotControl.Groups.GroupPageMain();
            this.groupPageFunc1 = new WinFrmTalk.Controls.LayouotControl.Groups.GroupPageFunc();
            this.useGroupInfo1 = new WinFrmTalk.Controls.CustomControls.UseGroupInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGroupOrganiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivLevelSwitch)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(0, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(724, 1);
            this.label1.TabIndex = 1;
            // 
            // tvName
            // 
            this.tvName.AutoEllipsis = true;
            this.tvName.AutoSize = true;
            this.tvName.BackColor = System.Drawing.Color.Transparent;
            this.tvName.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvName.ForeColor = System.Drawing.Color.Black;
            this.tvName.Location = new System.Drawing.Point(44, 15);
            this.tvName.MaximumSize = new System.Drawing.Size(460, 21);
            this.tvName.Name = "tvName";
            this.tvName.Size = new System.Drawing.Size(0, 21);
            this.tvName.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::WinFrmTalk.Properties.Resources.groupGQ;
            this.pictureBox1.Location = new System.Drawing.Point(11, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lab_detial
            // 
            this.lab_detial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_detial.BackColor = System.Drawing.Color.Transparent;
            this.lab_detial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_detial.Image = global::WinFrmTalk.Properties.Resources.ic_detail;
            this.lab_detial.Location = new System.Drawing.Point(682, 23);
            this.lab_detial.Name = "lab_detial";
            this.lab_detial.Size = new System.Drawing.Size(30, 30);
            this.lab_detial.TabIndex = 8;
            this.lab_detial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lab_detial_MouseClick);
            this.lab_detial.MouseEnter += new System.EventHandler(this.btnMainPage_MouseEnter);
            this.lab_detial.MouseLeave += new System.EventHandler(this.btnMainPage_MouseLeave);
            // 
            // btnGroupOrganiz
            // 
            this.btnGroupOrganiz.Image = global::WinFrmTalk.Properties.Resources.ic_group_organiz;
            this.btnGroupOrganiz.Location = new System.Drawing.Point(39, 1);
            this.btnGroupOrganiz.Name = "btnGroupOrganiz";
            this.btnGroupOrganiz.Size = new System.Drawing.Size(22, 22);
            this.btnGroupOrganiz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnGroupOrganiz.TabIndex = 16;
            this.btnGroupOrganiz.TabStop = false;
            this.toolTip1.SetToolTip(this.btnGroupOrganiz, "查看群层级");
            this.btnGroupOrganiz.Click += new System.EventHandler(this.btnGroupOrganiz_Click);
            // 
            // ivLevelSwitch
            // 
            this.ivLevelSwitch.Image = global::WinFrmTalk.Properties.Resources.ic_group_switch;
            this.ivLevelSwitch.Location = new System.Drawing.Point(3, 1);
            this.ivLevelSwitch.Name = "ivLevelSwitch";
            this.ivLevelSwitch.Size = new System.Drawing.Size(22, 22);
            this.ivLevelSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ivLevelSwitch.TabIndex = 15;
            this.ivLevelSwitch.TabStop = false;
            this.toolTip1.SetToolTip(this.ivLevelSwitch, "点击跳转其他群");
            this.ivLevelSwitch.Click += new System.EventHandler(this.ivLevelSwitch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ivLevelSwitch);
            this.panel1.Controls.Add(this.btnGroupOrganiz);
            this.panel1.Location = new System.Drawing.Point(408, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(73, 24);
            this.panel1.TabIndex = 17;
            // 
            // rightLayout
            // 
            this.rightLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightLayout.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rightLayout.Location = new System.Drawing.Point(670, 50);
            this.rightLayout.Name = "rightLayout";
            this.rightLayout.SelectIndex = WinFrmTalk.Controls.LayouotControl.Groups.GroupTabIndex.main;
            this.rightLayout.Size = new System.Drawing.Size(52, 611);
            this.rightLayout.TabIndex = 4;
            // 
            // groupPageMain1
            // 
            this.groupPageMain1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPageMain1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupPageMain1.Location = new System.Drawing.Point(0, 50);
            this.groupPageMain1.Name = "groupPageMain1";
            this.groupPageMain1.Size = new System.Drawing.Size(670, 610);
            this.groupPageMain1.TabIndex = 5;
            // 
            // groupPageFunc1
            // 
            this.groupPageFunc1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPageFunc1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupPageFunc1.Location = new System.Drawing.Point(0, 51);
            this.groupPageFunc1.Name = "groupPageFunc1";
            this.groupPageFunc1.Size = new System.Drawing.Size(670, 609);
            this.groupPageFunc1.TabIndex = 6;
            // 
            // useGroupInfo1
            // 
            this.useGroupInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.useGroupInfo1.BackColor = System.Drawing.Color.WhiteSmoke;
            friend1.AccountId = null;
            friend1.AllowConference = 0;
            friend1.AllowInviteFriend = 0;
            friend1.AllowOpenLive = 0;
            friend1.AllowSendCard = 0;
            friend1.AllowSpeakCourse = 0;
            friend1.AllowUploadFile = 0;
            friend1.AreaCode = null;
            friend1.AreaId = 0;
            friend1.Birthday = ((long)(0));
            friend1.ChatKeyGroup = null;
            friend1.CityId = 0;
            friend1.Content = null;
            friend1.CreateTime = 0;
            friend1.deleteTime = ((long)(0));
            friend1.Description = null;
            friend1.DhPublicKey = null;
            friend1.DownloadRoamEndTime = 0D;
            friend1.DownloadRoamStartTime = 0D;
            friend1.fristAscII = 0;
            friend1.GroupType = 0;
            friend1.IsAtMe = 0;
            friend1.IsClearMsg = 0;
            friend1.IsDismiss = 0;
            friend1.IsEncrypt = 0;
            friend1.IsGroup = 0;
            friend1.isLook = 0;
            friend1.IsLostKeyGroup = 0;
            friend1.IsNeedVerify = 0;
            friend1.IsOnLine = 0;
            friend1.IsOpenReadDel = 0;
            friend1.IsSecretGroup = 0;
            friend1.IsSendRecipt = 0;
            friend1.LastInput = null;
            friend1.LastMsgTime = 0D;
            friend1.LastMsgType = 0;
            friend1.movingState = 0;
            friend1.MsgNum = 0;
            friend1.NickName = null;
            friend1.Nodisturb = 0;
            friend1.OfficialGroupId = null;
            friend1.OfflineEndTime = 0D;
            friend1.ProvinceId = 0;
            friend1.RemarkName = null;
            friend1.RemarkPhone = null;
            friend1.Role = null;
            friend1.RoomId = null;
            friend1.RsaPublicKey = null;
            friend1.Sex = 0;
            friend1.ShowMember = 0;
            friend1.ShowRead = 0;
            friend1.Status = 0;
            friend1.Telephone = null;
            friend1.TopTime = 0;
            friend1.UserId = null;
            friend1.UserType = 0;
            this.useGroupInfo1.GroupInfo = friend1;
            this.useGroupInfo1.Location = new System.Drawing.Point(0, 0);
            this.useGroupInfo1.Name = "useGroupInfo1";
            this.useGroupInfo1.SendAction = null;
            this.useGroupInfo1.Size = new System.Drawing.Size(724, 660);
            this.useGroupInfo1.TabIndex = 7;
            // 
            // UseGroupInfo2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rightLayout);
            this.Controls.Add(this.groupPageMain1);
            this.Controls.Add(this.groupPageFunc1);
            this.Controls.Add(this.tvName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lab_detial);
            this.Controls.Add(this.useGroupInfo1);
            this.Name = "UseGroupInfo2";
            this.Size = new System.Drawing.Size(724, 660);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGroupOrganiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivLevelSwitch)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tvName;
        private LayouotControl.Groups.GroupIndicateLayout rightLayout;
        private LayouotControl.Groups.GroupPageMain groupPageMain1;
        private LayouotControl.Groups.GroupPageFunc groupPageFunc1;
        private UseGroupInfo useGroupInfo1;
        private System.Windows.Forms.Label lab_detial;
        private System.Windows.Forms.PictureBox btnGroupOrganiz;
        private System.Windows.Forms.PictureBox ivLevelSwitch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
    }
}
