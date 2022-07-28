namespace WinFrmTalk.Controls.LayouotControl
{
    partial class ChatSendLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatSendLayout));
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
            this.Bottom_Panel.SuspendLayout();
            this.Tool_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Bottom_Panel
            // 
            this.Bottom_Panel.BackColor = System.Drawing.Color.White;
            this.Bottom_Panel.Controls.Add(this.btnSend);
            this.Bottom_Panel.Controls.Add(this.txtSend);
            this.Bottom_Panel.Controls.Add(this.Tool_Panel);
            this.Bottom_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Bottom_Panel.Location = new System.Drawing.Point(0, 0);
            this.Bottom_Panel.Name = "Bottom_Panel";
            this.Bottom_Panel.Size = new System.Drawing.Size(571, 160);
            this.Bottom_Panel.TabIndex = 15;
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
            this.btnSend.Location = new System.Drawing.Point(490, 129);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(68, 23);
            this.btnSend.TabIndex = 17;
            this.btnSend.Text = "发送(S)";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSend.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSend.Location = new System.Drawing.Point(16, 46);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(542, 77);
            this.txtSend.TabIndex = 15;
            this.txtSend.Text = "";
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
            this.Tool_Panel.Size = new System.Drawing.Size(571, 36);
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
            this.lblSoundRecord.Click += new System.EventHandler(this.lblSoundRecord_Click);
            // 
            // lblPhotography
            // 
            this.lblPhotography.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPhotography.Image = ((System.Drawing.Image)(resources.GetObject("lblPhotography.Image")));
            this.lblPhotography.Location = new System.Drawing.Point(220, 1);
            this.lblPhotography.Name = "lblPhotography";
            this.lblPhotography.Size = new System.Drawing.Size(34, 34);
            this.lblPhotography.TabIndex = 12;
            this.lblPhotography.Click += new System.EventHandler(this.lblPhotography_Click);
            // 
            // lblCamera
            // 
            this.lblCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCamera.Image = ((System.Drawing.Image)(resources.GetObject("lblCamera.Image")));
            this.lblCamera.Location = new System.Drawing.Point(186, 1);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(34, 34);
            this.lblCamera.TabIndex = 11;
            this.lblCamera.Click += new System.EventHandler(this.lblCamera_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLocation.Image = ((System.Drawing.Image)(resources.GetObject("lblLocation.Image")));
            this.lblLocation.Location = new System.Drawing.Point(118, 1);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(34, 34);
            this.lblLocation.TabIndex = 10;
            this.lblLocation.Click += new System.EventHandler(this.lblLocation_Click);
            // 
            // lblScreen
            // 
            this.lblScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblScreen.Image = ((System.Drawing.Image)(resources.GetObject("lblScreen.Image")));
            this.lblScreen.Location = new System.Drawing.Point(84, 1);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(34, 34);
            this.lblScreen.TabIndex = 6;
            this.lblScreen.Click += new System.EventHandler(this.lblScreen_Click);
            // 
            // lab_splitTool
            // 
            this.lab_splitTool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_splitTool.BackColor = System.Drawing.Color.Gainsboro;
            this.lab_splitTool.Location = new System.Drawing.Point(0, 0);
            this.lab_splitTool.Name = "lab_splitTool";
            this.lab_splitTool.Size = new System.Drawing.Size(571, 1);
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
            this.lblSendFile.Click += new System.EventHandler(this.lblSendFile_Click);
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
            // ChatSendLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Bottom_Panel);
            this.Name = "ChatSendLayout";
            this.Size = new System.Drawing.Size(571, 160);
            this.Bottom_Panel.ResumeLayout(false);
            this.Tool_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
    }
}
