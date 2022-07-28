namespace WinFrmTalk.Controls.CustomControls
{
    partial class UseGroupInfo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnsend = new System.Windows.Forms.Label();
            this.tabpal = new System.Windows.Forms.FlowLayoutPanel();
            this.lbldispose = new System.Windows.Forms.Label();
            this.btnSeeMember = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pic = new WinFrmTalk.RoundPicBox();
            this.lblSpiltLine = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 588);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.btnsend);
            this.panel3.Controls.Add(this.tabpal);
            this.panel3.Controls.Add(this.lbldispose);
            this.panel3.Controls.Add(this.btnSeeMember);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 185);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(555, 403);
            this.panel3.TabIndex = 4;
            // 
            // btnsend
            // 
            this.btnsend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnsend.BackColor = System.Drawing.Color.Transparent;
            this.btnsend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsend.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnsend.ForeColor = System.Drawing.Color.White;
            this.btnsend.Image = global::WinFrmTalk.Properties.Resources.ic_button_bg1;
            this.btnsend.Location = new System.Drawing.Point(224, 325);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(116, 36);
            this.btnsend.TabIndex = 37;
            this.btnsend.Text = "查看";
            this.btnsend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnsend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tabpal
            // 
            this.tabpal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabpal.AutoScroll = true;
            this.tabpal.Location = new System.Drawing.Point(85, 30);
            this.tabpal.Name = "tabpal";
            this.tabpal.Size = new System.Drawing.Size(384, 268);
            this.tabpal.TabIndex = 13;
            // 
            // lbldispose
            // 
            this.lbldispose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbldispose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldispose.Location = new System.Drawing.Point(192, 367);
            this.lbldispose.Name = "lbldispose";
            this.lbldispose.Size = new System.Drawing.Size(180, 17);
            this.lbldispose.TabIndex = 12;
            this.lbldispose.Text = "该群已解散";
            this.lbldispose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbldispose.Visible = false;
            // 
            // btnSeeMember
            // 
            this.btnSeeMember.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSeeMember.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeeMember.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSeeMember.ForeColor = System.Drawing.Color.Silver;
            this.btnSeeMember.Location = new System.Drawing.Point(192, 299);
            this.btnSeeMember.Name = "btnSeeMember";
            this.btnSeeMember.Size = new System.Drawing.Size(180, 23);
            this.btnSeeMember.TabIndex = 11;
            this.btnSeeMember.Text = "查看群成员详情";
            this.btnSeeMember.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSeeMember.Click += new System.EventHandler(this.btnSeeMember_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pic);
            this.panel2.Controls.Add(this.lblSpiltLine);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(555, 185);
            this.panel2.TabIndex = 3;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinFrmTalk.Properties.Resources.groupGQ;
            this.pictureBox1.Location = new System.Drawing.Point(87, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pic
            // 
            this.pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic.isDrawRound = true;
            this.pic.Location = new System.Drawing.Point(407, 73);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(60, 60);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 9;
            this.pic.TabStop = false;
            // 
            // lblSpiltLine
            // 
            this.lblSpiltLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpiltLine.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSpiltLine.Location = new System.Drawing.Point(89, 177);
            this.lblSpiltLine.Name = "lblSpiltLine";
            this.lblSpiltLine.Size = new System.Drawing.Size(377, 1);
            this.lblSpiltLine.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(125, 73);
            this.lblTitle.MaximumSize = new System.Drawing.Size(276, 76);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(67, 25);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "label1";
            this.lblTitle.UseMnemonic = false;
            // 
            // UseGroupInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UseGroupInfo";
            this.Size = new System.Drawing.Size(555, 588);
            this.Load += new System.EventHandler(this.GroupInfo2_Load);
            this.SizeChanged += new System.EventHandler(this.UseGroupInfo_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel tabpal;
        private System.Windows.Forms.Label lbldispose;
        private System.Windows.Forms.Label btnSeeMember;
        private System.Windows.Forms.Panel panel2;
        public RoundPicBox pic;
        private System.Windows.Forms.Label lblSpiltLine;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label btnsend;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
