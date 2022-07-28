namespace WinFrmTalk.Controls
{
    partial class FriendItem
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
            this.lab_name = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ivLogo = new System.Windows.Forms.PictureBox();
            this.pic_Nonfriends = new System.Windows.Forms.PictureBox();
            this.btnLook = new System.Windows.Forms.PictureBox();
            this.pic_head = new WinFrmTalk.RoundPicBox();
            ((System.ComponentModel.ISupportInitialize)(this.ivLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Nonfriends)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_head)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_name
            // 
            this.lab_name.AutoEllipsis = true;
            this.lab_name.AutoSize = true;
            this.lab_name.BackColor = System.Drawing.Color.Transparent;
            this.lab_name.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_name.Location = new System.Drawing.Point(50, 20);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(48, 20);
            this.lab_name.TabIndex = 1;
            this.lab_name.Text = "NULL";
            this.lab_name.UseMnemonic = false;
            // 
            // ivLogo
            // 
            this.ivLogo.BackgroundImage = global::WinFrmTalk.Properties.Resources.groupGQ;
            this.ivLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ivLogo.Location = new System.Drawing.Point(44, 20);
            this.ivLogo.Margin = new System.Windows.Forms.Padding(0);
            this.ivLogo.Name = "ivLogo";
            this.ivLogo.Size = new System.Drawing.Size(20, 20);
            this.ivLogo.TabIndex = 3;
            this.ivLogo.TabStop = false;
            this.ivLogo.Visible = false;
            // 
            // pic_Nonfriends
            // 
            this.pic_Nonfriends.BackgroundImage = global::WinFrmTalk.Properties.Resources.deleted;
            this.pic_Nonfriends.Location = new System.Drawing.Point(212, 22);
            this.pic_Nonfriends.Margin = new System.Windows.Forms.Padding(0);
            this.pic_Nonfriends.Name = "pic_Nonfriends";
            this.pic_Nonfriends.Size = new System.Drawing.Size(16, 16);
            this.pic_Nonfriends.TabIndex = 2;
            this.pic_Nonfriends.TabStop = false;
            this.pic_Nonfriends.Visible = false;
            // 
            // btnLook
            // 
            this.btnLook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLook.Image = global::WinFrmTalk.Properties.Resources.ic_group_look1;
            this.btnLook.Location = new System.Drawing.Point(186, 19);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(52, 23);
            this.btnLook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLook.TabIndex = 4;
            this.btnLook.TabStop = false;
            this.btnLook.Visible = false;
            // 
            // pic_head
            // 
            this.pic_head.isDrawRound = true;
            this.pic_head.Location = new System.Drawing.Point(6, 13);
            this.pic_head.Name = "pic_head";
            this.pic_head.Size = new System.Drawing.Size(35, 35);
            this.pic_head.TabIndex = 0;
            this.pic_head.TabStop = false;
            // 
            // FriendItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnLook);
            this.Controls.Add(this.ivLogo);
            this.Controls.Add(this.pic_Nonfriends);
            this.Controls.Add(this.pic_head);
            this.Controls.Add(this.lab_name);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FriendItem";
            this.Size = new System.Drawing.Size(250, 60);
            this.Load += new System.EventHandler(this.FriendItem_Load);
            this.MouseEnter += new System.EventHandler(this.FriendItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FriendItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.ivLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Nonfriends)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_head)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lab_name;
        public RoundPicBox pic_head;
        private System.Windows.Forms.PictureBox pic_Nonfriends;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox ivLogo;
        private System.Windows.Forms.PictureBox btnLook;
    }
}
