namespace WinFrmTalk.Controls.LayouotControl
{
    partial class MainPageLayout
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
            WinFrmTalk.Model.Friend friend1 = new WinFrmTalk.Model.Friend();
            this.sendMsgPanel = new WinFrmTalk.Controls.CustomControls.ShowMsgPanel();
            this.FriendInfo = new WinFrmTalk.Controls.CustomControls.USEFriendInfo();
            this.userOfficialAccount = new WinFrmTalk.Controls.CustomControls.UserOfficialAccount();
            this.BlockPage = new WinFrmTalk.BlockListPage();
            this.UserVerifyPage = new WinFrmTalk.USEUserVerifyPage();
            this.useLabelInfo = new WinFrmTalk.Controls.CustomControls.UseLabelInfo2();
            this.groupInfo = new WinFrmTalk.Controls.CustomControls.UseGroupInfo2();
            this.SuspendLayout();
            // 
            // sendMsgPanel
            // 
            this.sendMsgPanel.BackColor = System.Drawing.Color.WhiteSmoke;
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
            this.sendMsgPanel.ChooseTarget = friend1;
            this.sendMsgPanel.dialogBox = WinFrmTalk.Controls.CustomControls.DialogBox.Normal;
            this.sendMsgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendMsgPanel.Location = new System.Drawing.Point(0, 0);
            this.sendMsgPanel.Name = "sendMsgPanel";
            this.sendMsgPanel.Size = new System.Drawing.Size(725, 660);
            this.sendMsgPanel.TabIndex = 2;
            this.sendMsgPanel.TabStop = false;
            // 
            // FriendInfo
            // 
            this.FriendInfo.AutoSize = true;
            this.FriendInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FriendInfo.Birthday = "2019-00-00";
            this.FriendInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FriendInfo.Friend = null;
            this.FriendInfo.Location = new System.Drawing.Point(0, 0);
            this.FriendInfo.LocationName = "广东省深圳市";
            this.FriendInfo.Name = "FriendInfo";
            this.FriendInfo.Nickname = "I N S O";
            this.FriendInfo.RemagkPhone = null;
            this.FriendInfo.RemarkPhone = null;
            this.FriendInfo.Remarks = "MM";
            this.FriendInfo.SendAction = null;
            this.FriendInfo.Sex = "男";
            this.FriendInfo.Size = new System.Drawing.Size(725, 660);
            this.FriendInfo.TabIndex = 1;
            // 
            // userOfficialAccount
            // 
            this.userOfficialAccount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.userOfficialAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userOfficialAccount.Location = new System.Drawing.Point(0, 0);
            this.userOfficialAccount.Name = "userOfficialAccount";
            this.userOfficialAccount.Size = new System.Drawing.Size(725, 660);
            this.userOfficialAccount.TabIndex = 5;
            // 
            // BlockPage
            // 
            this.BlockPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BlockPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlockPage.Location = new System.Drawing.Point(0, 0);
            this.BlockPage.Margin = new System.Windows.Forms.Padding(0);
            this.BlockPage.Name = "BlockPage";
            this.BlockPage.Size = new System.Drawing.Size(725, 660);
            this.BlockPage.TabIndex = 4;
            // 
            // UserVerifyPage
            // 
            this.UserVerifyPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UserVerifyPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserVerifyPage.Location = new System.Drawing.Point(0, 0);
            this.UserVerifyPage.Margin = new System.Windows.Forms.Padding(0);
            this.UserVerifyPage.Name = "UserVerifyPage";
            this.UserVerifyPage.Size = new System.Drawing.Size(725, 660);
            this.UserVerifyPage.TabIndex = 3;
            // 
            // useLabelInfo
            // 
            this.useLabelInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.useLabelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useLabelInfo.Location = new System.Drawing.Point(0, 0);
            this.useLabelInfo.Name = "useLabelInfo";
            this.useLabelInfo.Size = new System.Drawing.Size(725, 660);
            this.useLabelInfo.TabIndex = 9;
            this.useLabelInfo.Visible = false;
            // 
            // groupInfo
            // 
            this.groupInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupInfo.Location = new System.Drawing.Point(0, 0);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(725, 660);
            this.groupInfo.TabIndex = 6;
            // 
            // MainPageLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.sendMsgPanel);
            this.Controls.Add(this.FriendInfo);
            this.Controls.Add(this.userOfficialAccount);
            this.Controls.Add(this.BlockPage);
            this.Controls.Add(this.UserVerifyPage);
            this.Controls.Add(this.useLabelInfo);
            this.Controls.Add(this.groupInfo);
            this.Name = "MainPageLayout";
            this.Size = new System.Drawing.Size(725, 660);
            this.Load += new System.EventHandler(this.MainPageLayout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomControls.USEFriendInfo FriendInfo;
        private USEUserVerifyPage UserVerifyPage;
        private BlockListPage BlockPage;
        public CustomControls.ShowMsgPanel sendMsgPanel;
        private CustomControls.UserOfficialAccount userOfficialAccount;
        private CustomControls.UseGroupInfo2 groupInfo;
        private CustomControls.UseLabelInfo2 useLabelInfo;
    }
}
