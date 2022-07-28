namespace WinFrmTalk
{
    partial class FrmGroupBasic
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
            this.lblNickname = new System.Windows.Forms.Label();
            this.lblSex_text = new System.Windows.Forms.Label();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.tvDescript = new System.Windows.Forms.Label();
            this.tvCount = new System.Windows.Forms.Label();
            this.btnJoin = new System.Windows.Forms.PictureBox();
            this.btnShare = new System.Windows.Forms.PictureBox();
            this.btnEqcode = new System.Windows.Forms.PictureBox();
            this.picHead = new WinFrmTalk.RoundPicBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tvNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.btnJoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEqcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNickname
            // 
            this.lblNickname.AutoEllipsis = true;
            this.lblNickname.BackColor = System.Drawing.Color.Transparent;
            this.lblNickname.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblNickname.Location = new System.Drawing.Point(16, 26);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(184, 30);
            this.lblNickname.TabIndex = 1;
            this.lblNickname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNickname.UseMnemonic = false;
            // 
            // lblSex_text
            // 
            this.lblSex_text.AutoSize = true;
            this.lblSex_text.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblSex_text.Location = new System.Drawing.Point(20, 66);
            this.lblSex_text.Name = "lblSex_text";
            this.lblSex_text.Size = new System.Drawing.Size(44, 17);
            this.lblSex_text.TabIndex = 2;
            this.lblSex_text.Text = "人数：";
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.skinLine1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(21, 115);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(276, 1);
            this.skinLine1.TabIndex = 0;
            this.skinLine1.Text = "skinLine1";
            // 
            // tvDescript
            // 
            this.tvDescript.AutoEllipsis = true;
            this.tvDescript.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvDescript.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tvDescript.Location = new System.Drawing.Point(20, 124);
            this.tvDescript.Name = "tvDescript";
            this.tvDescript.Size = new System.Drawing.Size(276, 117);
            this.tvDescript.TabIndex = 2;
            // 
            // tvCount
            // 
            this.tvCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvCount.Location = new System.Drawing.Point(61, 65);
            this.tvCount.Name = "tvCount";
            this.tvCount.Size = new System.Drawing.Size(89, 18);
            this.tvCount.TabIndex = 4;
            this.tvCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tvCount.UseMnemonic = false;
            // 
            // btnJoin
            // 
            this.btnJoin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJoin.Image = global::WinFrmTalk.Properties.Resources.ic_basic_group_add;
            this.btnJoin.Location = new System.Drawing.Point(123, 0);
            this.btnJoin.Margin = new System.Windows.Forms.Padding(0);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(35, 35);
            this.btnJoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnJoin.TabIndex = 6;
            this.btnJoin.TabStop = false;
            this.btnJoin.Click += new System.EventHandler(this.picAddFirend_Click);
            this.btnJoin.MouseEnter += new System.EventHandler(this.picQRCode_MouseEnter);
            this.btnJoin.MouseLeave += new System.EventHandler(this.picQRCode_MouseLeave);
            // 
            // btnShare
            // 
            this.btnShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShare.ErrorImage = null;
            this.btnShare.Image = global::WinFrmTalk.Properties.Resources.ic_basic_share;
            this.btnShare.Location = new System.Drawing.Point(73, 0);
            this.btnShare.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(35, 35);
            this.btnShare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnShare.TabIndex = 6;
            this.btnShare.TabStop = false;
            this.toolTip1.SetToolTip(this.btnShare, "分享群名片");
            this.btnShare.Click += new System.EventHandler(this.picCard_Click);
            this.btnShare.MouseEnter += new System.EventHandler(this.picQRCode_MouseEnter);
            this.btnShare.MouseLeave += new System.EventHandler(this.picQRCode_MouseLeave);
            // 
            // btnEqcode
            // 
            this.btnEqcode.BackColor = System.Drawing.Color.White;
            this.btnEqcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEqcode.Image = global::WinFrmTalk.Properties.Resources.ic_basic_qrcode;
            this.btnEqcode.Location = new System.Drawing.Point(23, 0);
            this.btnEqcode.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnEqcode.Name = "btnEqcode";
            this.btnEqcode.Size = new System.Drawing.Size(35, 35);
            this.btnEqcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEqcode.TabIndex = 6;
            this.btnEqcode.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEqcode, "群二维码");
            this.btnEqcode.Click += new System.EventHandler(this.picQRCode_Click);
            this.btnEqcode.MouseEnter += new System.EventHandler(this.picQRCode_MouseEnter);
            this.btnEqcode.MouseLeave += new System.EventHandler(this.picQRCode_MouseLeave);
            // 
            // picHead
            // 
            this.picHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHead.isDrawRound = true;
            this.picHead.Location = new System.Drawing.Point(241, 27);
            this.picHead.Name = "picHead";
            this.picHead.Size = new System.Drawing.Size(55, 55);
            this.picHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHead.TabIndex = 23;
            this.picHead.TabStop = false;
            // 
            // tvNumber
            // 
            this.tvNumber.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvNumber.Location = new System.Drawing.Point(60, 92);
            this.tvNumber.Name = "tvNumber";
            this.tvNumber.Size = new System.Drawing.Size(89, 18);
            this.tvNumber.TabIndex = 25;
            this.tvNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tvNumber.UseMnemonic = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label2.Location = new System.Drawing.Point(19, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "群号：";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnJoin);
            this.flowLayoutPanel1.Controls.Add(this.btnShare);
            this.flowLayoutPanel1.Controls.Add(this.btnEqcode);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(138, 254);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(158, 35);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // FrmGroupBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 312);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tvNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picHead);
            this.Controls.Add(this.tvCount);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.tvDescript);
            this.Controls.Add(this.lblSex_text);
            this.Controls.Add(this.lblNickname);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGroupBasic";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.FrmFriendsBasic_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.btnJoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEqcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.Label lblSex_text;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.Label tvDescript;
        private System.Windows.Forms.Label tvCount;
        private System.Windows.Forms.PictureBox btnEqcode;
        private System.Windows.Forms.PictureBox btnShare;
        private System.Windows.Forms.PictureBox btnJoin;
        private RoundPicBox picHead;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label tvNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}