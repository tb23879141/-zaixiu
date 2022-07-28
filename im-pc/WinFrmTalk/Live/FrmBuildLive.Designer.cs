namespace WinFrmTalk.Live
{
    partial class FrmBuildLive
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblNotice = new System.Windows.Forms.Label();
            this.lblGn = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic_myIcon = new WinFrmTalk.RoundPicBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.checkRecreation = new WinFrmTalk.Controls.CustomControls.CheckBoxEx();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textShare = new System.Windows.Forms.TextBox();
            this.textRecreation = new System.Windows.Forms.TextBox();
            this.labelRecreation = new System.Windows.Forms.Label();
            this.labelShare = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.checkShare = new WinFrmTalk.Controls.CustomControls.CheckBoxEx();
            this.btnStartLive = new WinFrmTalk.Controls.CustomControls.RegisterBtnEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_myIcon)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtName.Location = new System.Drawing.Point(115, 3);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(490, 22);
            this.txtName.TabIndex = 14;
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNotice.Location = new System.Drawing.Point(0, 50);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(118, 24);
            this.lblNotice.TabIndex = 12;
            this.lblNotice.Text = "直播间公告：";
            // 
            // lblGn
            // 
            this.lblGn.AutoSize = true;
            this.lblGn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblGn.Location = new System.Drawing.Point(0, 0);
            this.lblGn.Name = "lblGn";
            this.lblGn.Size = new System.Drawing.Size(104, 24);
            this.lblGn.TabIndex = 11;
            this.lblGn.Text = "直播间名称:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitle.Location = new System.Drawing.Point(0, 170);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 24);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "请选择你要直播的类型:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::WinFrmTalk.Properties.Resources.tx_type;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.pic_myIcon);
            this.panel1.Location = new System.Drawing.Point(295, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(92, 92);
            this.panel1.TabIndex = 20;
            // 
            // pic_myIcon
            // 
            this.pic_myIcon.BackColor = System.Drawing.Color.Transparent;
            this.pic_myIcon.isDrawRound = true;
            this.pic_myIcon.Location = new System.Drawing.Point(2, 2);
            this.pic_myIcon.Name = "pic_myIcon";
            this.pic_myIcon.Size = new System.Drawing.Size(88, 88);
            this.pic_myIcon.TabIndex = 87;
            this.pic_myIcon.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtNotice);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.btnStartLive);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lblGn);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Controls.Add(this.lblNotice);
            this.panel2.Location = new System.Drawing.Point(50, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 431);
            this.panel2.TabIndex = 23;
            // 
            // txtNotice
            // 
            this.txtNotice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNotice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotice.Font = new System.Drawing.Font("微软雅黑", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNotice.Location = new System.Drawing.Point(110, 49);
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.Size = new System.Drawing.Size(495, 115);
            this.txtNotice.TabIndex = 25;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.checkRecreation);
            this.panel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel5.Location = new System.Drawing.Point(350, 170);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(63, 24);
            this.panel5.TabIndex = 84;
            this.panel5.Click += new System.EventHandler(this.checkRecreation_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(22, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 81;
            this.label3.Text = "娱乐";
            this.label3.Click += new System.EventHandler(this.checkRecreation_Click);
            // 
            // checkRecreation
            // 
            this.checkRecreation.AutoSize = true;
            this.checkRecreation.BackColor = System.Drawing.Color.Transparent;
            this.checkRecreation.BaseColor = System.Drawing.Color.White;
            this.checkRecreation.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checkRecreation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkRecreation.DefaultCheckButtonWidth = 13;
            this.checkRecreation.DownBack = null;
            this.checkRecreation.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkRecreation.Location = new System.Drawing.Point(1, 6);
            this.checkRecreation.MouseBack = global::WinFrmTalk.Properties.Resources.unselected;
            this.checkRecreation.Name = "checkRecreation";
            this.checkRecreation.NormlBack = global::WinFrmTalk.Properties.Resources.unselected;
            this.checkRecreation.SelectedDownBack = global::WinFrmTalk.Properties.Resources.selected;
            this.checkRecreation.SelectedMouseBack = global::WinFrmTalk.Properties.Resources.selected;
            this.checkRecreation.SelectedNormlBack = global::WinFrmTalk.Properties.Resources.selected;
            this.checkRecreation.Size = new System.Drawing.Size(15, 14);
            this.checkRecreation.TabIndex = 79;
            this.checkRecreation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkRecreation.UseVisualStyleBackColor = false;
            this.checkRecreation.Click += new System.EventHandler(this.checkRecreation_Click);
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = global::WinFrmTalk.Properties.Resources.instructions_bg;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.textShare);
            this.panel6.Controls.Add(this.textRecreation);
            this.panel6.Controls.Add(this.labelRecreation);
            this.panel6.Controls.Add(this.labelShare);
            this.panel6.Location = new System.Drawing.Point(0, 216);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(612, 156);
            this.panel6.TabIndex = 85;
            // 
            // textShare
            // 
            this.textShare.BackColor = System.Drawing.Color.White;
            this.textShare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textShare.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textShare.Location = new System.Drawing.Point(16, 55);
            this.textShare.Multiline = true;
            this.textShare.Name = "textShare";
            this.textShare.ReadOnly = true;
            this.textShare.Size = new System.Drawing.Size(589, 97);
            this.textShare.TabIndex = 5;
            this.textShare.Text = "     分享主播有自己非常擅长的东西，主要把自己的服务、讲座、培训、辅导、产品性能等专业内容，帮助观众回答相关问题，传授相关知识及经验，或者生活技能等，刚好有粉" +
    "丝是有这方面的需要，通过分享建立更加友好的交流关系，或者通过后端的课程及服务来进行盈利。";
            // 
            // textRecreation
            // 
            this.textRecreation.BackColor = System.Drawing.Color.White;
            this.textRecreation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textRecreation.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textRecreation.Location = new System.Drawing.Point(16, 55);
            this.textRecreation.Multiline = true;
            this.textRecreation.Name = "textRecreation";
            this.textRecreation.ReadOnly = true;
            this.textRecreation.Size = new System.Drawing.Size(589, 97);
            this.textRecreation.TabIndex = 4;
            this.textRecreation.Text = "        娱乐直播为在线演艺平台，泛娱乐场景，通过唱歌跳舞、才艺展示进行内容输出；与网友、粉丝、游客们互动聊天，抢占流量，收获粉丝，获取礼物打赏或广告等收入" +
    "；我们致力把有才华的艺人、歌手、舞蹈爱好者，通过在秀的网络舞台，走向闪耀的明星之路";
            this.textRecreation.Visible = false;
            // 
            // labelRecreation
            // 
            this.labelRecreation.AutoSize = true;
            this.labelRecreation.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRecreation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.labelRecreation.Location = new System.Drawing.Point(373, 13);
            this.labelRecreation.Name = "labelRecreation";
            this.labelRecreation.Size = new System.Drawing.Size(137, 20);
            this.labelRecreation.TabIndex = 3;
            this.labelRecreation.Text = "\"娱乐\" 直播类型说明";
            // 
            // labelShare
            // 
            this.labelShare.AutoSize = true;
            this.labelShare.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelShare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(24)))), ((int)(((byte)(219)))));
            this.labelShare.Location = new System.Drawing.Point(80, 12);
            this.labelShare.Name = "labelShare";
            this.labelShare.Size = new System.Drawing.Size(157, 21);
            this.labelShare.TabIndex = 0;
            this.labelShare.Text = "\"分享\" 直播类型说明";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.checkShare);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(234, 170);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(64, 24);
            this.panel4.TabIndex = 83;
            this.panel4.Click += new System.EventHandler(this.checkShare_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(20, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 80;
            this.label2.Text = "分享";
            this.label2.Click += new System.EventHandler(this.checkShare_Click);
            // 
            // checkShare
            // 
            this.checkShare.AutoSize = true;
            this.checkShare.BackColor = System.Drawing.Color.Transparent;
            this.checkShare.BaseColor = System.Drawing.Color.White;
            this.checkShare.Checked = true;
            this.checkShare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShare.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checkShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkShare.DefaultCheckButtonWidth = 13;
            this.checkShare.DownBack = null;
            this.checkShare.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkShare.Location = new System.Drawing.Point(1, 5);
            this.checkShare.MouseBack = global::WinFrmTalk.Properties.Resources.unselected;
            this.checkShare.Name = "checkShare";
            this.checkShare.NormlBack = global::WinFrmTalk.Properties.Resources.unselected;
            this.checkShare.SelectedDownBack = global::WinFrmTalk.Properties.Resources.selected;
            this.checkShare.SelectedMouseBack = global::WinFrmTalk.Properties.Resources.selected;
            this.checkShare.SelectedNormlBack = global::WinFrmTalk.Properties.Resources.selected;
            this.checkShare.Size = new System.Drawing.Size(15, 14);
            this.checkShare.TabIndex = 82;
            this.checkShare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkShare.UseVisualStyleBackColor = false;
            this.checkShare.Click += new System.EventHandler(this.checkShare_Click);
            // 
            // btnStartLive
            // 
            this.btnStartLive.BackColor = System.Drawing.Color.Transparent;
            this.btnStartLive.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnStartLive.ForeColor = System.Drawing.Color.White;
            this.btnStartLive.Location = new System.Drawing.Point(195, 390);
            this.btnStartLive.Margin = new System.Windows.Forms.Padding(0);
            this.btnStartLive.Name = "btnStartLive";
            this.btnStartLive.Size = new System.Drawing.Size(200, 36);
            this.btnStartLive.TabIndex = 18;
            this.btnStartLive.Text = "确 定 直 播";
            this.btnStartLive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnStartLive_MouseClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel3.Location = new System.Drawing.Point(110, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(500, 1);
            this.panel3.TabIndex = 15;
            // 
            // FrmBuildLive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(680, 580);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBuildLive";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "c";
            this.TitleNeed = false;
            this.Load += new System.EventHandler(this.FrmBuildLive_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_myIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.Label lblGn;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private WinFrmTalk.Controls.CustomControls.RegisterBtnEx btnStartLive;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private WinFrmTalk.Controls.CustomControls.CheckBoxEx checkShare;
        private System.Windows.Forms.Label label3;
        private WinFrmTalk.Controls.CustomControls.CheckBoxEx checkRecreation;
        private RoundPicBox pic_myIcon;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label labelShare;
        private System.Windows.Forms.Label labelRecreation;
        private System.Windows.Forms.TextBox textRecreation;
        private System.Windows.Forms.TextBox textShare;
        private System.Windows.Forms.TextBox txtNotice;
    }
}