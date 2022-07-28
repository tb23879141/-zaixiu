namespace WinFrmTalk.Controls.CustomControls.ItemControl
{
    partial class OfficialAccountItem
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
            this.btnAction = new System.Windows.Forms.Button();
            this.friendItem1 = new WinFrmTalk.Controls.FriendItem();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnAction.FlatAppearance.BorderSize = 0;
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction.ForeColor = System.Drawing.Color.White;
            this.btnAction.Location = new System.Drawing.Point(224, 13);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(64, 25);
            this.btnAction.TabIndex = 9;
            this.btnAction.Text = "关注";
            this.btnAction.UseVisualStyleBackColor = false;
            this.btnAction.Visible = false;
            this.btnAction.Click += new System.EventHandler(this.BtnAction_Click);
            // 
            // friendItem1
            // 
            this.friendItem1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendItem1.BackColor = System.Drawing.Color.Transparent;
            this.friendItem1.CurrtIndex = 0;
            friend1.AccountId = null;
            friend1.AllowConference = 0;
            friend1.AllowInviteFriend = 0;
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
            friend1.Description = null;
            friend1.DhPublicKey = null;
            friend1.DownloadRoamEndTime = 0D;
            friend1.DownloadRoamStartTime = 0D;
            friend1.fristAscII = 0;
            friend1.IsAtMe = 0;
            friend1.IsClearMsg = 0;
            friend1.IsDismiss = 0;
            friend1.IsEncrypt = 0;
            friend1.IsGroup = 0;
            friend1.IsLostKeyGroup = 0;
            friend1.IsNeedVerify = 0;
            friend1.IsOnLine = 0;
            friend1.IsOpenReadDel = 0;
            friend1.IsSecretGroup = 0;
            friend1.IsSendRecipt = 0;
            friend1.LastInput = null;
            friend1.LastMsgTime = 0D;
            friend1.LastMsgType = 0;
            friend1.MsgNum = 0;
            friend1.NickName = null;
            friend1.Nodisturb = 0;
            friend1.OfflineEndTime = 0D;
            friend1.ProvinceId = 0;
            friend1.RemarkName = null;
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
            this.friendItem1.FriendData = friend1;
            this.friendItem1.IsSelected = false;
            this.friendItem1.Location = new System.Drawing.Point(0, 0);
            this.friendItem1.Margin = new System.Windows.Forms.Padding(0);
            this.friendItem1.Name = "friendItem1";
            this.friendItem1.Size = new System.Drawing.Size(300, 50);
            this.friendItem1.TabIndex = 0;
            this.friendItem1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FriendItem1_MouseClick);
            // 
            // OfficialAccountItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.friendItem1);
            this.Name = "OfficialAccountItem";
            this.Size = new System.Drawing.Size(300, 50);
            this.MouseEnter += new System.EventHandler(this.OfficialAccountItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.friendItem_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private FriendItem friendItem1;
        public System.Windows.Forms.Button btnAction;
    }
}
