namespace WinFrmTalk.View
{
    partial class FrmBatchSend
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
            this.xListView = new TestListView.XListView();
            this.friendListView = new TestListView.XListView();
            this.tvBatchTitle = new System.Windows.Forms.Label();
            this.chatSendView = new WinFrmTalk.Controls.LayouotControl.ChatSendLayout();
            this.lab_splitTool = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // xListView
            // 
            this.xListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xListView.BackColor = System.Drawing.SystemColors.Window;
            this.xListView.Location = new System.Drawing.Point(261, 68);
            this.xListView.Name = "xListView";
            this.xListView.ScrollBarWidth = 10;
            this.xListView.Size = new System.Drawing.Size(547, 435);
            this.xListView.TabIndex = 7;
            // 
            // friendListView
            // 
            this.friendListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendListView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.friendListView.Location = new System.Drawing.Point(1, 68);
            this.friendListView.Name = "friendListView";
            this.friendListView.ScrollBarWidth = 10;
            this.friendListView.Size = new System.Drawing.Size(260, 598);
            this.friendListView.TabIndex = 30;
            // 
            // tvBatchTitle
            // 
            this.tvBatchTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvBatchTitle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tvBatchTitle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tvBatchTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tvBatchTitle.Location = new System.Drawing.Point(3, 31);
            this.tvBatchTitle.Name = "tvBatchTitle";
            this.tvBatchTitle.Size = new System.Drawing.Size(263, 37);
            this.tvBatchTitle.TabIndex = 31;
            this.tvBatchTitle.Text = "你将给此列表中 0位好友群发消息";
            this.tvBatchTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chatSendView
            // 
            this.chatSendView.Location = new System.Drawing.Point(261, 500);
            this.chatSendView.Name = "chatSendView";
            this.chatSendView.Size = new System.Drawing.Size(547, 163);
            this.chatSendView.TabIndex = 37;
            // 
            // lab_splitTool
            // 
            this.lab_splitTool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_splitTool.BackColor = System.Drawing.Color.Gainsboro;
            this.lab_splitTool.Location = new System.Drawing.Point(0, 68);
            this.lab_splitTool.Name = "lab_splitTool";
            this.lab_splitTool.Size = new System.Drawing.Size(812, 1);
            this.lab_splitTool.TabIndex = 43;
            // 
            // FrmBatchSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(810, 665);
            this.Controls.Add(this.lab_splitTool);
            this.Controls.Add(this.friendListView);
            this.Controls.Add(this.xListView);
            this.Controls.Add(this.chatSendView);
            this.Controls.Add(this.tvBatchTitle);
            this.Name = "FrmBatchSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "群发消息";
            this.ResumeLayout(false);

        }

        #endregion
        public TestListView.XListView xListView;
        public TestListView.XListView friendListView;
        private System.Windows.Forms.Label tvBatchTitle;
        private Controls.LayouotControl.ChatSendLayout chatSendView;
        private System.Windows.Forms.Label lab_splitTool;
    }
}