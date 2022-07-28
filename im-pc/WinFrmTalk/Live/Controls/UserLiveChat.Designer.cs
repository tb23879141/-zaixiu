namespace WinFrmTalk.Live.Controls
{
    partial class UserLiveChat
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
            this.btnliveinfo = new System.Windows.Forms.Label();
            this.btnFansinfo = new System.Windows.Forms.Label();
            this.menuDel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemUnTalk = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTalk = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTalk30min = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTalkOneHour = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTalkOneDay = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTalkthreeDay = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemexite = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSetAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.btntext = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.CmsChat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemChat = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemB = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNext = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FansLst = new TestListView.XListView();
            this.ChatList = new TestListView.XListView();
            this.menuDel.SuspendLayout();
            this.CmsChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnliveinfo
            // 
            this.btnliveinfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(209)))), ((int)(((byte)(5)))));
            this.btnliveinfo.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnliveinfo.ForeColor = System.Drawing.Color.White;
            this.btnliveinfo.Location = new System.Drawing.Point(0, 0);
            this.btnliveinfo.Name = "btnliveinfo";
            this.btnliveinfo.Size = new System.Drawing.Size(196, 50);
            this.btnliveinfo.TabIndex = 46;
            this.btnliveinfo.Text = "聊天室";
            this.btnliveinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnliveinfo.Click += new System.EventHandler(this.btnliveinfo_Click);
            // 
            // btnFansinfo
            // 
            this.btnFansinfo.BackColor = System.Drawing.Color.White;
            this.btnFansinfo.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFansinfo.ForeColor = System.Drawing.Color.Black;
            this.btnFansinfo.Location = new System.Drawing.Point(196, 0);
            this.btnFansinfo.Name = "btnFansinfo";
            this.btnFansinfo.Size = new System.Drawing.Size(196, 50);
            this.btnFansinfo.TabIndex = 47;
            this.btnFansinfo.Text = "粉丝列表";
            this.btnFansinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFansinfo.Click += new System.EventHandler(this.btnFansinfo_Click);
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
            this.MenuItemUnTalk.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemTalk,
            this.MenuItemTalk30min,
            this.MenuItemTalkOneHour,
            this.MenuItemTalkOneDay,
            this.MenuItemTalkthreeDay});
            this.MenuItemUnTalk.Name = "MenuItemUnTalk";
            this.MenuItemUnTalk.Size = new System.Drawing.Size(136, 22);
            this.MenuItemUnTalk.Text = "禁言";
            // 
            // MenuItemTalk
            // 
            this.MenuItemTalk.Name = "MenuItemTalk";
            this.MenuItemTalk.Size = new System.Drawing.Size(138, 22);
            this.MenuItemTalk.Tag = "1";
            this.MenuItemTalk.Text = "不禁言";
            this.MenuItemTalk.Click += new System.EventHandler(this.MenuItemTalkTime_Click);
            // 
            // MenuItemTalk30min
            // 
            this.MenuItemTalk30min.Name = "MenuItemTalk30min";
            this.MenuItemTalk30min.Size = new System.Drawing.Size(138, 22);
            this.MenuItemTalk30min.Tag = "2";
            this.MenuItemTalk30min.Text = "禁言30分钟";
            this.MenuItemTalk30min.Click += new System.EventHandler(this.MenuItemTalkTime_Click);
            // 
            // MenuItemTalkOneHour
            // 
            this.MenuItemTalkOneHour.Name = "MenuItemTalkOneHour";
            this.MenuItemTalkOneHour.Size = new System.Drawing.Size(138, 22);
            this.MenuItemTalkOneHour.Tag = "3";
            this.MenuItemTalkOneHour.Text = "禁言1小时";
            this.MenuItemTalkOneHour.Click += new System.EventHandler(this.MenuItemTalkTime_Click);
            // 
            // MenuItemTalkOneDay
            // 
            this.MenuItemTalkOneDay.Name = "MenuItemTalkOneDay";
            this.MenuItemTalkOneDay.Size = new System.Drawing.Size(138, 22);
            this.MenuItemTalkOneDay.Tag = "4";
            this.MenuItemTalkOneDay.Text = "禁言1天";
            this.MenuItemTalkOneDay.Click += new System.EventHandler(this.MenuItemTalkTime_Click);
            // 
            // MenuItemTalkthreeDay
            // 
            this.MenuItemTalkthreeDay.Name = "MenuItemTalkthreeDay";
            this.MenuItemTalkthreeDay.Size = new System.Drawing.Size(138, 22);
            this.MenuItemTalkthreeDay.Tag = "5";
            this.MenuItemTalkthreeDay.Text = "禁言3天";
            this.MenuItemTalkthreeDay.Click += new System.EventHandler(this.MenuItemTalkTime_Click);
            // 
            // MenuItemexite
            // 
            this.MenuItemexite.Name = "MenuItemexite";
            this.MenuItemexite.Size = new System.Drawing.Size(136, 22);
            this.MenuItemexite.Text = "踢出";
            this.MenuItemexite.Click += new System.EventHandler(this.MenuItemexite_Click);
            // 
            // MenuItemSetAdmin
            // 
            this.MenuItemSetAdmin.Name = "MenuItemSetAdmin";
            this.MenuItemSetAdmin.Size = new System.Drawing.Size(136, 22);
            this.MenuItemSetAdmin.Text = "设置管理员";
            this.MenuItemSetAdmin.Click += new System.EventHandler(this.MenuItemSetAdmin_Click);
            // 
            // btntext
            // 
            this.btntext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btntext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(209)))), ((int)(((byte)(5)))));
            this.btntext.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btntext.ForeColor = System.Drawing.Color.White;
            this.btntext.Location = new System.Drawing.Point(282, 589);
            this.btntext.Name = "btntext";
            this.btntext.Size = new System.Drawing.Size(68, 59);
            this.btntext.TabIndex = 50;
            this.btntext.Text = "发送";
            this.btntext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSend
            // 
            this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSend.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSend.Location = new System.Drawing.Point(15, 589);
            this.txtSend.MaxLength = 300;
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtSend.Size = new System.Drawing.Size(266, 59);
            this.txtSend.TabIndex = 51;
            this.txtSend.Text = "";
            this.txtSend.Enter += new System.EventHandler(this.txtSend_Enter);
            this.txtSend.Leave += new System.EventHandler(this.txtSend_Leave);
            // 
            // CmsChat
            // 
            this.CmsChat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemChat,
            this.MenuItemB});
            this.CmsChat.Name = "CmsChat";
            this.CmsChat.Size = new System.Drawing.Size(101, 48);
            // 
            // MenuItemChat
            // 
            this.MenuItemChat.Name = "MenuItemChat";
            this.MenuItemChat.Size = new System.Drawing.Size(100, 22);
            this.MenuItemChat.Text = "聊天";
            this.MenuItemChat.Click += new System.EventHandler(this.MenuItemChat_Click);
            // 
            // MenuItemB
            // 
            this.MenuItemB.Name = "MenuItemB";
            this.MenuItemB.Size = new System.Drawing.Size(100, 22);
            this.MenuItemB.Text = "弹幕";
            this.MenuItemB.Click += new System.EventHandler(this.MenuItemB_Click);
            // 
            // lblNext
            // 
            this.lblNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(209)))), ((int)(((byte)(5)))));
            this.lblNext.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblNext.ForeColor = System.Drawing.Color.White;
            this.lblNext.Image = global::WinFrmTalk.Properties.Resources.Barrage;
            this.lblNext.Location = new System.Drawing.Point(349, 589);
            this.lblNext.Margin = new System.Windows.Forms.Padding(0);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(25, 59);
            this.lblNext.TabIndex = 53;
            this.lblNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNext.Click += new System.EventHandler(this.lblNext_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(346, 613);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 15);
            this.label1.TabIndex = 54;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 592);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 55;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // FansLst
            // 
            this.FansLst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FansLst.BackColor = System.Drawing.Color.White;
            this.FansLst.Location = new System.Drawing.Point(0, 53);
            this.FansLst.Name = "FansLst";
            this.FansLst.ScrollBarWidth = 10;
            this.FansLst.Size = new System.Drawing.Size(392, 617);
            this.FansLst.TabIndex = 48;
            this.FansLst.Visible = false;
            // 
            // ChatList
            // 
            this.ChatList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatList.BackColor = System.Drawing.Color.White;
            this.ChatList.Location = new System.Drawing.Point(-1, 49);
            this.ChatList.Name = "ChatList";
            this.ChatList.ScrollBarWidth = 10;
            this.ChatList.Size = new System.Drawing.Size(393, 537);
            this.ChatList.TabIndex = 1;
            // 
            // UserLiveChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNext);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.btntext);
            this.Controls.Add(this.FansLst);
            this.Controls.Add(this.ChatList);
            this.Controls.Add(this.btnFansinfo);
            this.Controls.Add(this.btnliveinfo);
            this.Controls.Add(this.textBox1);
            this.Name = "UserLiveChat";
            this.Size = new System.Drawing.Size(392, 669);
            this.Load += new System.EventHandler(this.UserLiveChat_Load);
            this.menuDel.ResumeLayout(false);
            this.CmsChat.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       
        private System.Windows.Forms.Label btnliveinfo;
        private System.Windows.Forms.Label btnFansinfo;
        private System.Windows.Forms.ContextMenuStrip menuDel;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUnTalk;
        private System.Windows.Forms.ToolStripMenuItem MenuItemexite;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSetAdmin;
        private TestListView.XListView ChatList;
        public System.Windows.Forms.Label btntext;
        public TestListView.XListView FansLst;
        public System.Windows.Forms.RichTextBox txtSend;
        private System.Windows.Forms.ContextMenuStrip CmsChat;
        private System.Windows.Forms.ToolStripMenuItem MenuItemChat;
        private System.Windows.Forms.ToolStripMenuItem MenuItemB;
        public System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTalk;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTalk30min;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTalkOneHour;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTalkOneDay;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTalkthreeDay;
        private System.Windows.Forms.TextBox textBox1;
    }
}
