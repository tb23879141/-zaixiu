namespace WinFrmTalk.View
{
    partial class FrmLive
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
            this.LiveChat = new WinFrmTalk.Live.Controls.UserLiveChat();
            this.menuDel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemUnTalk = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemexite = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSetAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.usertitle = new WinFrmTalk.Live.Controls.UserLiveTitle();
            this.userPresentlst1 = new WinFrmTalk.Live.Controls.UserPresentlst();
            this.userLivePlayer = new WinFrmTalk.Live.Controls.UserLivePlayer();
            this.menuDel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LiveChat
            // 
            this.LiveChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LiveChat.BackColor = System.Drawing.Color.White;
            this.LiveChat.Location = new System.Drawing.Point(848, 38);
            this.LiveChat.Name = "LiveChat";
            this.LiveChat.Size = new System.Drawing.Size(392, 672);
            this.LiveChat.TabIndex = 38;
            // 
            // menuDel
            // 
            this.menuDel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemUnTalk,
            this.MenuItemexite,
            this.MenuItemSetAdmin});
            this.menuDel.Name = "menuDel";
            this.menuDel.Size = new System.Drawing.Size(137, 70);
            // 
            // MenuItemUnTalk
            // 
            this.MenuItemUnTalk.Name = "MenuItemUnTalk";
            this.MenuItemUnTalk.Size = new System.Drawing.Size(136, 22);
            this.MenuItemUnTalk.Text = "禁言";
            // 
            // MenuItemexite
            // 
            this.MenuItemexite.Name = "MenuItemexite";
            this.MenuItemexite.Size = new System.Drawing.Size(136, 22);
            this.MenuItemexite.Text = "踢出";
            // 
            // MenuItemSetAdmin
            // 
            this.MenuItemSetAdmin.Name = "MenuItemSetAdmin";
            this.MenuItemSetAdmin.Size = new System.Drawing.Size(136, 22);
            this.MenuItemSetAdmin.Text = "设置管理员";
            // 
            // usertitle
            // 
            this.usertitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usertitle.BackColor = System.Drawing.Color.White;
            this.usertitle.isShowCloseLive = true;
            this.usertitle.Location = new System.Drawing.Point(15, 38);
            this.usertitle.Name = "usertitle";
            this.usertitle.Size = new System.Drawing.Size(818, 78);
            this.usertitle.TabIndex = 79;
            // 
            // userPresentlst1
            // 
            this.userPresentlst1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userPresentlst1.BackColor = System.Drawing.Color.White;
            this.userPresentlst1.Location = new System.Drawing.Point(15, 634);
            this.userPresentlst1.Margin = new System.Windows.Forms.Padding(0);
            this.userPresentlst1.Name = "userPresentlst1";
            this.userPresentlst1.Size = new System.Drawing.Size(818, 76);
            this.userPresentlst1.TabIndex = 56;
            // 
            // userLivePlayer
            // 
            this.userLivePlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userLivePlayer.Location = new System.Drawing.Point(15, 126);
            this.userLivePlayer.Name = "userLivePlayer";
            this.userLivePlayer.Size = new System.Drawing.Size(818, 498);
            this.userLivePlayer.TabIndex = 73;
            // 
            // FrmLive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1255, 725);
            this.Controls.Add(this.usertitle);
            this.Controls.Add(this.userLivePlayer);
            this.Controls.Add(this.userPresentlst1);
            this.Controls.Add(this.LiveChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "FrmLive";
            this.Text = "直播间";
            this.TitleNeed = false;
            this.Deactivate += new System.EventHandler(this.FrmLive_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLive_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLive_FormClosed);
            this.Load += new System.EventHandler(this.FrmLive_Load);
            this.SizeChanged += new System.EventHandler(this.FrmLive_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLive_KeyDown);
            this.Move += new System.EventHandler(this.FrmLive_Move);
            this.menuDel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Live.Controls.UserLiveChat LiveChat;
        private System.Windows.Forms.ContextMenuStrip menuDel;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUnTalk;
        private System.Windows.Forms.ToolStripMenuItem MenuItemexite;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSetAdmin;
        public Live.Controls.UserLiveTitle usertitle;
        private Live.Controls.UserPresentlst userPresentlst1;
        public Live.Controls.UserLivePlayer userLivePlayer;
    }
}