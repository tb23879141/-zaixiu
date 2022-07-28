namespace WinFrmTalk.View
{
    partial class FrmNewTable
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
            WinFrmTalk.Model.Friend friend1 = new WinFrmTalk.Model.Friend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewTable));
            this.showMsgPanel = new WinFrmTalk.Controls.CustomControls.ShowMsgPanel();
            this.SuspendLayout();
            // 
            // showMsgPanel
            // 
            this.showMsgPanel.BackColor = System.Drawing.Color.WhiteSmoke;
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
            friend1.RemarkPhone = null;
            friend1.Role = "";
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
            this.showMsgPanel.ChooseTarget = friend1;
            this.showMsgPanel.dialogBox = WinFrmTalk.Controls.CustomControls.DialogBox.Normal;
            this.showMsgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showMsgPanel.Location = new System.Drawing.Point(4, 28);
            this.showMsgPanel.Name = "showMsgPanel";
            this.showMsgPanel.Size = new System.Drawing.Size(827, 604);
            this.showMsgPanel.TabIndex = 6;
            // 
            // FrmNewTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(835, 636);
            this.Controls.Add(this.showMsgPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmNewTable";
            this.Text = "";
            this.TitleNeed = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmNewTable_FormClosed);
            this.Load += new System.EventHandler(this.FrmNewTable_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.CustomControls.ShowMsgPanel showMsgPanel;
    }
}