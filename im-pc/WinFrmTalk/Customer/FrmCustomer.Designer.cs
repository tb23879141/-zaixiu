namespace WinFrmTalk.Customer
{
    partial class FrmCustomer
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
            this.pnlRight = new System.Windows.Forms.Panel();
            this.cmbAllocation = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblText3 = new System.Windows.Forms.Label();
            this.lblText2 = new System.Windows.Forms.Label();
            this.lblText1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlReply = new System.Windows.Forms.FlowLayoutPanel();
            this.pbnlSender = new System.Windows.Forms.Panel();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.lblChannel = new System.Windows.Forms.Label();
            this.lblSenderEmail = new System.Windows.Forms.Label();
            this.lblSenderPhone = new System.Windows.Forms.Label();
            this.lblSenderName = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lbl_split1 = new System.Windows.Forms.Label();
            this.lbl_split2 = new System.Windows.Forms.Label();
            this.lbl_split3 = new System.Windows.Forms.Label();
            this.lbl_split4 = new System.Windows.Forms.Label();
            this.lbl_split5 = new System.Windows.Forms.Label();
            this.pnlRight.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pbnlSender.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.cmbAllocation);
            this.pnlRight.Controls.Add(this.cmbStatus);
            this.pnlRight.Controls.Add(this.lblText3);
            this.pnlRight.Controls.Add(this.lblText2);
            this.pnlRight.Controls.Add(this.lblText1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(396, 28);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(200, 538);
            this.pnlRight.TabIndex = 6;
            // 
            // cmbAllocation
            // 
            this.cmbAllocation.BackColor = System.Drawing.Color.White;
            this.cmbAllocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllocation.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbAllocation.FormattingEnabled = true;
            this.cmbAllocation.Items.AddRange(new object[] {
            "未分配",
            "未处理",
            "已解决"});
            this.cmbAllocation.Location = new System.Drawing.Point(22, 70);
            this.cmbAllocation.Name = "cmbAllocation";
            this.cmbAllocation.Size = new System.Drawing.Size(159, 25);
            this.cmbAllocation.TabIndex = 6;
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.White;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "未分配",
            "未处理",
            "已解决"});
            this.cmbStatus.Location = new System.Drawing.Point(22, 157);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(159, 25);
            this.cmbStatus.TabIndex = 5;
            // 
            // lblText3
            // 
            this.lblText3.AutoSize = true;
            this.lblText3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblText3.Location = new System.Drawing.Point(19, 137);
            this.lblText3.Name = "lblText3";
            this.lblText3.Size = new System.Drawing.Size(32, 17);
            this.lblText3.TabIndex = 2;
            this.lblText3.Text = "状态";
            // 
            // lblText2
            // 
            this.lblText2.AutoSize = true;
            this.lblText2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblText2.Location = new System.Drawing.Point(19, 50);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(32, 17);
            this.lblText2.TabIndex = 1;
            this.lblText2.Text = "分配";
            // 
            // lblText1
            // 
            this.lblText1.AutoSize = true;
            this.lblText1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblText1.Location = new System.Drawing.Point(90, 10);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(32, 17);
            this.lblText1.TabIndex = 0;
            this.lblText1.Text = "处理";
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.pnlReply);
            this.pnlMain.Controls.Add(this.pbnlSender);
            this.pnlMain.Controls.Add(this.pnlInput);
            this.pnlMain.Location = new System.Drawing.Point(0, 28);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(396, 538);
            this.pnlMain.TabIndex = 7;
            // 
            // pnlReply
            // 
            this.pnlReply.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReply.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlReply.Location = new System.Drawing.Point(0, 208);
            this.pnlReply.Name = "pnlReply";
            this.pnlReply.Size = new System.Drawing.Size(396, 230);
            this.pnlReply.TabIndex = 2;
            // 
            // pbnlSender
            // 
            this.pbnlSender.Controls.Add(this.lblContent);
            this.pbnlSender.Controls.Add(this.lblUpdateTime);
            this.pbnlSender.Controls.Add(this.lblCreateTime);
            this.pbnlSender.Controls.Add(this.lblChannel);
            this.pbnlSender.Controls.Add(this.lblSenderEmail);
            this.pbnlSender.Controls.Add(this.lblSenderPhone);
            this.pbnlSender.Controls.Add(this.lblSenderName);
            this.pbnlSender.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbnlSender.Location = new System.Drawing.Point(0, 0);
            this.pbnlSender.Name = "pbnlSender";
            this.pbnlSender.Size = new System.Drawing.Size(396, 208);
            this.pbnlSender.TabIndex = 1;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblContent.Location = new System.Drawing.Point(17, 149);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(44, 17);
            this.lblContent.TabIndex = 6;
            this.lblContent.Text = "内容：";
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblUpdateTime.Location = new System.Drawing.Point(17, 127);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 17);
            this.lblUpdateTime.TabIndex = 5;
            this.lblUpdateTime.Text = "更新时间：";
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblCreateTime.Location = new System.Drawing.Point(17, 105);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(68, 17);
            this.lblCreateTime.TabIndex = 4;
            this.lblCreateTime.Text = "创建时间：";
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblChannel.Location = new System.Drawing.Point(17, 83);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(44, 17);
            this.lblChannel.TabIndex = 3;
            this.lblChannel.Text = "渠道：";
            // 
            // lblSenderEmail
            // 
            this.lblSenderEmail.AutoSize = true;
            this.lblSenderEmail.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblSenderEmail.Location = new System.Drawing.Point(17, 59);
            this.lblSenderEmail.Name = "lblSenderEmail";
            this.lblSenderEmail.Size = new System.Drawing.Size(80, 17);
            this.lblSenderEmail.TabIndex = 2;
            this.lblSenderEmail.Text = "发起人邮箱：";
            // 
            // lblSenderPhone
            // 
            this.lblSenderPhone.AutoSize = true;
            this.lblSenderPhone.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblSenderPhone.Location = new System.Drawing.Point(17, 37);
            this.lblSenderPhone.Name = "lblSenderPhone";
            this.lblSenderPhone.Size = new System.Drawing.Size(80, 17);
            this.lblSenderPhone.TabIndex = 1;
            this.lblSenderPhone.Text = "发起人手机：";
            // 
            // lblSenderName
            // 
            this.lblSenderName.AutoSize = true;
            this.lblSenderName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSenderName.Location = new System.Drawing.Point(17, 15);
            this.lblSenderName.Name = "lblSenderName";
            this.lblSenderName.Size = new System.Drawing.Size(56, 17);
            this.lblSenderName.TabIndex = 0;
            this.lblSenderName.Text = "发起人：";
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.txtSend);
            this.pnlInput.Controls.Add(this.btnSend);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInput.Location = new System.Drawing.Point(0, 438);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(396, 100);
            this.pnlInput.TabIndex = 0;
            // 
            // txtSend
            // 
            this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSend.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSend.Location = new System.Drawing.Point(7, 6);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(383, 53);
            this.txtSend.TabIndex = 19;
            this.txtSend.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(150)))), ((int)(((byte)(37)))));
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSend.Location = new System.Drawing.Point(315, 65);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(68, 26);
            this.btnSend.TabIndex = 18;
            this.btnSend.Text = "发送(S)";
            this.btnSend.UseVisualStyleBackColor = false;
            // 
            // lbl_split1
            // 
            this.lbl_split1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_split1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbl_split1.Location = new System.Drawing.Point(0, 27);
            this.lbl_split1.Name = "lbl_split1";
            this.lbl_split1.Size = new System.Drawing.Size(600, 1);
            this.lbl_split1.TabIndex = 13;
            // 
            // lbl_split2
            // 
            this.lbl_split2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_split2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lbl_split2.Location = new System.Drawing.Point(0, 235);
            this.lbl_split2.Name = "lbl_split2";
            this.lbl_split2.Size = new System.Drawing.Size(396, 1);
            this.lbl_split2.TabIndex = 19;
            // 
            // lbl_split3
            // 
            this.lbl_split3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_split3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbl_split3.Location = new System.Drawing.Point(0, 464);
            this.lbl_split3.Name = "lbl_split3";
            this.lbl_split3.Size = new System.Drawing.Size(396, 1);
            this.lbl_split3.TabIndex = 20;
            // 
            // lbl_split4
            // 
            this.lbl_split4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_split4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbl_split4.Location = new System.Drawing.Point(396, 28);
            this.lbl_split4.Name = "lbl_split4";
            this.lbl_split4.Size = new System.Drawing.Size(1, 543);
            this.lbl_split4.TabIndex = 14;
            // 
            // lbl_split5
            // 
            this.lbl_split5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_split5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbl_split5.Location = new System.Drawing.Point(396, 65);
            this.lbl_split5.Name = "lbl_split5";
            this.lbl_split5.Size = new System.Drawing.Size(200, 1);
            this.lbl_split5.TabIndex = 23;
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 570);
            this.Controls.Add(this.lbl_split5);
            this.Controls.Add(this.lbl_split4);
            this.Controls.Add(this.lbl_split3);
            this.Controls.Add(this.lbl_split2);
            this.Controls.Add(this.lbl_split1);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCustomer";
            this.Text = "";
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pbnlSender.ResumeLayout(false);
            this.pbnlSender.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Panel pbnlSender;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.FlowLayoutPanel pnlReply;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.Label lblSenderEmail;
        private System.Windows.Forms.Label lblSenderPhone;
        private System.Windows.Forms.Label lblSenderName;
        private System.Windows.Forms.RichTextBox txtSend;
        private System.Windows.Forms.Label lbl_split1;
        private System.Windows.Forms.Label lbl_split4;
        private System.Windows.Forms.Label lbl_split2;
        private System.Windows.Forms.Label lbl_split3;
        private System.Windows.Forms.Label lblText3;
        private System.Windows.Forms.Label lblText2;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.Label lbl_split5;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbAllocation;
    }
}