namespace WinFrmTalk.View
{
    partial class FrmMassMsg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMassMsg));
            this.Main_Panel = new System.Windows.Forms.Panel();
            this.Bottom_Panel = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.Tool_Panel = new System.Windows.Forms.Panel();
            this.lblSoundRecord = new System.Windows.Forms.Label();
            this.lblPhotography = new System.Windows.Forms.Label();
            this.lblCamera = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblScreen = new System.Windows.Forms.Label();
            this.lab_splitTool = new System.Windows.Forms.Label();
            this.lblSendFile = new System.Windows.Forms.Label();
            this.lblExpression = new System.Windows.Forms.Label();
            this.xListView = new TestListView.XListView();
            this.userSoundRecording = new WinFrmTalk.Controls.CustomControls.UserSoundRecording();
            this.lblAdrNum = new System.Windows.Forms.Label();
            this.xlvAddressees = new TestListView.XListView();
            this.lab_splitTitle = new System.Windows.Forms.Label();
            this.Main_Panel.SuspendLayout();
            this.Bottom_Panel.SuspendLayout();
            this.Tool_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_Panel
            // 
            this.Main_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_Panel.Controls.Add(this.Bottom_Panel);
            this.Main_Panel.Controls.Add(this.xListView);
            this.Main_Panel.Controls.Add(this.userSoundRecording);
            this.Main_Panel.Location = new System.Drawing.Point(256, 28);
            this.Main_Panel.Name = "Main_Panel";
            this.Main_Panel.Size = new System.Drawing.Size(602, 635);
            this.Main_Panel.TabIndex = 30;
            // 
            // Bottom_Panel
            // 
            this.Bottom_Panel.BackColor = System.Drawing.Color.White;
            this.Bottom_Panel.Controls.Add(this.btnSend);
            this.Bottom_Panel.Controls.Add(this.txtSend);
            this.Bottom_Panel.Controls.Add(this.Tool_Panel);
            this.Bottom_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Bottom_Panel.Location = new System.Drawing.Point(0, 475);
            this.Bottom_Panel.Name = "Bottom_Panel";
            this.Bottom_Panel.Size = new System.Drawing.Size(602, 160);
            this.Bottom_Panel.TabIndex = 26;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(150)))), ((int)(((byte)(37)))));
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSend.Location = new System.Drawing.Point(521, 129);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(68, 23);
            this.btnSend.TabIndex = 17;
            this.btnSend.Text = "发送(S)";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSend.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSend.Location = new System.Drawing.Point(16, 46);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(573, 77);
            this.txtSend.TabIndex = 15;
            this.txtSend.Text = "";
            this.txtSend.TextChanged += new System.EventHandler(this.TxtSend_TextChanged);
            this.txtSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSend_KeyDown);
            this.txtSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtSend_KeyUp);
            // 
            // Tool_Panel
            // 
            this.Tool_Panel.Controls.Add(this.lblSoundRecord);
            this.Tool_Panel.Controls.Add(this.lblPhotography);
            this.Tool_Panel.Controls.Add(this.lblCamera);
            this.Tool_Panel.Controls.Add(this.lblLocation);
            this.Tool_Panel.Controls.Add(this.lblScreen);
            this.Tool_Panel.Controls.Add(this.lab_splitTool);
            this.Tool_Panel.Controls.Add(this.lblSendFile);
            this.Tool_Panel.Controls.Add(this.lblExpression);
            this.Tool_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Tool_Panel.Location = new System.Drawing.Point(0, 0);
            this.Tool_Panel.Name = "Tool_Panel";
            this.Tool_Panel.Size = new System.Drawing.Size(602, 36);
            this.Tool_Panel.TabIndex = 16;
            // 
            // lblSoundRecord
            // 
            this.lblSoundRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSoundRecord.Image = ((System.Drawing.Image)(resources.GetObject("lblSoundRecord.Image")));
            this.lblSoundRecord.Location = new System.Drawing.Point(152, 1);
            this.lblSoundRecord.Name = "lblSoundRecord";
            this.lblSoundRecord.Size = new System.Drawing.Size(34, 34);
            this.lblSoundRecord.TabIndex = 13;
            this.lblSoundRecord.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblSoundRecord_MouseClick);
            // 
            // lblPhotography
            // 
            this.lblPhotography.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPhotography.Image = ((System.Drawing.Image)(resources.GetObject("lblPhotography.Image")));
            this.lblPhotography.Location = new System.Drawing.Point(220, 1);
            this.lblPhotography.Name = "lblPhotography";
            this.lblPhotography.Size = new System.Drawing.Size(34, 34);
            this.lblPhotography.TabIndex = 12;
            this.lblPhotography.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblPhotography_MouseClick);
            // 
            // lblCamera
            // 
            this.lblCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCamera.Image = ((System.Drawing.Image)(resources.GetObject("lblCamera.Image")));
            this.lblCamera.Location = new System.Drawing.Point(186, 1);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(34, 34);
            this.lblCamera.TabIndex = 11;
            this.lblCamera.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblCamera_MouseClick);
            // 
            // lblLocation
            // 
            this.lblLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLocation.Image = ((System.Drawing.Image)(resources.GetObject("lblLocation.Image")));
            this.lblLocation.Location = new System.Drawing.Point(118, 1);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(34, 34);
            this.lblLocation.TabIndex = 10;
            this.lblLocation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblLocation_MouseClick);
            // 
            // lblScreen
            // 
            this.lblScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblScreen.Image = ((System.Drawing.Image)(resources.GetObject("lblScreen.Image")));
            this.lblScreen.Location = new System.Drawing.Point(84, 1);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(34, 34);
            this.lblScreen.TabIndex = 6;
            this.lblScreen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblScreen_MouseClick);
            // 
            // lab_splitTool
            // 
            this.lab_splitTool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_splitTool.BackColor = System.Drawing.Color.Gainsboro;
            this.lab_splitTool.Location = new System.Drawing.Point(0, 0);
            this.lab_splitTool.Name = "lab_splitTool";
            this.lab_splitTool.Size = new System.Drawing.Size(602, 1);
            this.lab_splitTool.TabIndex = 5;
            // 
            // lblSendFile
            // 
            this.lblSendFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSendFile.Image = ((System.Drawing.Image)(resources.GetObject("lblSendFile.Image")));
            this.lblSendFile.Location = new System.Drawing.Point(50, 1);
            this.lblSendFile.Name = "lblSendFile";
            this.lblSendFile.Size = new System.Drawing.Size(34, 34);
            this.lblSendFile.TabIndex = 1;
            this.lblSendFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblSendFile_MouseClick);
            // 
            // lblExpression
            // 
            this.lblExpression.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExpression.Image = global::WinFrmTalk.Properties.Resources.ExpressionNormal;
            this.lblExpression.Location = new System.Drawing.Point(16, 1);
            this.lblExpression.Name = "lblExpression";
            this.lblExpression.Size = new System.Drawing.Size(34, 34);
            this.lblExpression.TabIndex = 0;
            this.lblExpression.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblExpression_MouseClick);
            // 
            // xListView
            // 
            this.xListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xListView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xListView.Location = new System.Drawing.Point(0, 25);
            this.xListView.Name = "xListView";
            this.xListView.ScrollBarWidth = 10;
            this.xListView.Size = new System.Drawing.Size(602, 450);
            this.xListView.TabIndex = 25;
            // 
            // userSoundRecording
            // 
            this.userSoundRecording.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userSoundRecording.BackColor = System.Drawing.Color.White;
            this.userSoundRecording.Location = new System.Drawing.Point(1, 440);
            this.userSoundRecording.Name = "userSoundRecording";
            this.userSoundRecording.nr.PathCallback = null;
            this.userSoundRecording.Size = new System.Drawing.Size(595, 33);
            this.userSoundRecording.TabIndex = 28;
            this.userSoundRecording.Visible = false;
            // 
            // lblAdrNum
            // 
            this.lblAdrNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdrNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblAdrNum.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblAdrNum.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblAdrNum.Location = new System.Drawing.Point(7, 28);
            this.lblAdrNum.Name = "lblAdrNum";
            this.lblAdrNum.Size = new System.Drawing.Size(849, 25);
            this.lblAdrNum.TabIndex = 17;
            this.lblAdrNum.Text = "你将发消息给x位好友";
            // 
            // xlvAddressees
            // 
            this.xlvAddressees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.xlvAddressees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.xlvAddressees.Location = new System.Drawing.Point(7, 53);
            this.xlvAddressees.Name = "xlvAddressees";
            this.xlvAddressees.ScrollBarWidth = 10;
            this.xlvAddressees.Size = new System.Drawing.Size(245, 608);
            this.xlvAddressees.TabIndex = 29;
            // 
            // lab_splitTitle
            // 
            this.lab_splitTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_splitTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.lab_splitTitle.Location = new System.Drawing.Point(0, 53);
            this.lab_splitTitle.Name = "lab_splitTitle";
            this.lab_splitTitle.Size = new System.Drawing.Size(860, 1);
            this.lab_splitTitle.TabIndex = 36;
            // 
            // FrmMassMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(860, 665);
            this.Controls.Add(this.lab_splitTitle);
            this.Controls.Add(this.lblAdrNum);
            this.Controls.Add(this.xlvAddressees);
            this.Controls.Add(this.Main_Panel);
            this.Name = "FrmMassMsg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "群发";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMassMsg_FormClosed);
            this.Load += new System.EventHandler(this.FrmMassMsg_Load);
            this.Main_Panel.ResumeLayout(false);
            this.Bottom_Panel.ResumeLayout(false);
            this.Tool_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Main_Panel;
        private System.Windows.Forms.Panel Bottom_Panel;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox txtSend;
        private System.Windows.Forms.Panel Tool_Panel;
        private System.Windows.Forms.Label lblSoundRecord;
        private System.Windows.Forms.Label lblPhotography;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.Label lab_splitTool;
        private System.Windows.Forms.Label lblSendFile;
        private System.Windows.Forms.Label lblExpression;
        public TestListView.XListView xListView;
        private Controls.CustomControls.UserSoundRecording userSoundRecording;
        private System.Windows.Forms.Label lblAdrNum;
        private TestListView.XListView xlvAddressees;
        private System.Windows.Forms.Label lab_splitTitle;
    }
}