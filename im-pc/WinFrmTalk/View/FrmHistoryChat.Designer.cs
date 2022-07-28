namespace WinFrmTalk.View
{
    partial class FrmHistoryChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHistoryChat));
            this.lblAll = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblVideo = new System.Windows.Forms.Label();
            this.lblNickName = new System.Windows.Forms.Label();
            this.xlvMsgs = new TestListView.XListView();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.SearchMessage = new WinFrmTalk.Controls.CustomControls.UserSearch();
            this.CmsChat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemInputEls = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuIteminputTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNext = new System.Windows.Forms.PictureBox();
            this.lbl_split1 = new System.Windows.Forms.Label();
            this.CmsChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblNext)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAll
            // 
            this.lblAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblAll.AutoSize = true;
            this.lblAll.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAll.ForeColor = System.Drawing.Color.Black;
            this.lblAll.Location = new System.Drawing.Point(169, 107);
            this.lblAll.Name = "lblAll";
            this.lblAll.Size = new System.Drawing.Size(42, 21);
            this.lblAll.TabIndex = 0;
            this.lblAll.Text = "全部";
            this.lblAll.Click += new System.EventHandler(this.lblAll_Click);
            // 
            // lblFile
            // 
            this.lblFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFile.Location = new System.Drawing.Point(254, 107);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(42, 21);
            this.lblFile.TabIndex = 9;
            this.lblFile.Text = "文件";
            this.lblFile.Click += new System.EventHandler(this.lblAll_Click);
            // 
            // lblImage
            // 
            this.lblImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImage.Location = new System.Drawing.Point(339, 107);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(42, 21);
            this.lblImage.TabIndex = 10;
            this.lblImage.Text = "图片";
            this.lblImage.Click += new System.EventHandler(this.lblAll_Click);
            // 
            // lblVideo
            // 
            this.lblVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblVideo.AutoSize = true;
            this.lblVideo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVideo.Location = new System.Drawing.Point(424, 107);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(42, 21);
            this.lblVideo.TabIndex = 11;
            this.lblVideo.Text = "视频";
            this.lblVideo.Click += new System.EventHandler(this.lblAll_Click);
            // 
            // lblNickName
            // 
            this.lblNickName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNickName.Location = new System.Drawing.Point(8, 8);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(504, 21);
            this.lblNickName.TabIndex = 14;
            this.lblNickName.Text = "label1";
            this.lblNickName.UseMnemonic = false;
            this.lblNickName.TextChanged += new System.EventHandler(this.lblNickName_TextChanged);
            // 
            // xlvMsgs
            // 
            this.xlvMsgs.BackColor = System.Drawing.Color.Transparent;
            this.xlvMsgs.Location = new System.Drawing.Point(45, 140);
            this.xlvMsgs.Name = "xlvMsgs";
            this.xlvMsgs.ScrollBarWidth = 10;
            this.xlvMsgs.Size = new System.Drawing.Size(595, 420);
            this.xlvMsgs.TabIndex = 17;
            // 
            // flpTable
            // 
            this.flpTable.Location = new System.Drawing.Point(45, 140);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(550, 453);
            this.flpTable.TabIndex = 18;
            this.flpTable.Visible = false;
            // 
            // SearchMessage
            // 
            this.SearchMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.SearchMessage.Location = new System.Drawing.Point(55, 60);
            this.SearchMessage.LoseFocusResume = true;
            this.SearchMessage.Name = "SearchMessage";
            this.SearchMessage.Size = new System.Drawing.Size(530, 26);
            this.SearchMessage.TabIndex = 0;
            // 
            // CmsChat
            // 
            this.CmsChat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemInputEls,
            this.MenuIteminputTxt});
            this.CmsChat.Name = "CmsChat";
            this.CmsChat.Size = new System.Drawing.Size(178, 48);
            // 
            // MenuItemInputEls
            // 
            this.MenuItemInputEls.Name = "MenuItemInputEls";
            this.MenuItemInputEls.Size = new System.Drawing.Size(177, 22);
            this.MenuItemInputEls.Text = "导出excel聊天记录";
            this.MenuItemInputEls.Click += new System.EventHandler(this.MenuItemInputEls_Click);
            // 
            // MenuIteminputTxt
            // 
            this.MenuIteminputTxt.Name = "MenuIteminputTxt";
            this.MenuIteminputTxt.Size = new System.Drawing.Size(177, 22);
            this.MenuIteminputTxt.Text = "导出txt聊天记录";
            this.MenuIteminputTxt.Click += new System.EventHandler(this.MenuIteminputTxt_Click);
            // 
            // lblNext
            // 
            this.lblNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNext.Image = global::WinFrmTalk.Properties.Resources.ic_exportdown;
            this.lblNext.Location = new System.Drawing.Point(531, 0);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(36, 24);
            this.lblNext.TabIndex = 57;
            this.lblNext.TabStop = false;
            this.lblNext.Click += new System.EventHandler(this.lblNext_Click);
            this.lblNext.MouseEnter += new System.EventHandler(this.lblNext_MouseEnter);
            this.lblNext.MouseLeave += new System.EventHandler(this.lblNext_MouseLeave);
            // 
            // lbl_split1
            // 
            this.lbl_split1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_split1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.lbl_split1.Location = new System.Drawing.Point(0, 136);
            this.lbl_split1.Name = "lbl_split1";
            this.lbl_split1.Size = new System.Drawing.Size(640, 1);
            this.lbl_split1.TabIndex = 60;
            // 
            // FrmHistoryChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(640, 600);
            this.Controls.Add(this.lbl_split1);
            this.Controls.Add(this.lblNext);
            this.Controls.Add(this.SearchMessage);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.xlvMsgs);
            this.Controls.Add(this.lblNickName);
            this.Controls.Add(this.lblVideo);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 598);
            this.Name = "FrmHistoryChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TitleNeed = false;
            this.Load += new System.EventHandler(this.FrmHistoryChat_Load);
            this.CmsChat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblNext)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAll;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblVideo;
        private System.Windows.Forms.Label lblNickName;
        private Controls.CustomControls.UserSearch SearchMessage;
        private System.Windows.Forms.ContextMenuStrip CmsChat;
        private System.Windows.Forms.ToolStripMenuItem MenuItemInputEls;
        private System.Windows.Forms.ToolStripMenuItem MenuIteminputTxt;
        private System.Windows.Forms.PictureBox lblNext;
        private System.Windows.Forms.Label lbl_split1;
        public TestListView.XListView xlvMsgs;
        public System.Windows.Forms.FlowLayoutPanel flpTable;
    }
}