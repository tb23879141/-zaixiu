namespace WinFrmTalk.Controls.LayouotControl.GroupTree
{
    partial class GroupTreeNodeItem
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
            this.tvName = new System.Windows.Forms.Label();
            this.pic_ex = new System.Windows.Forms.PictureBox();
            this.ivCurrtLevel = new System.Windows.Forms.PictureBox();
            this.btnLook = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivCurrtLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLook)).BeginInit();
            this.SuspendLayout();
            // 
            // tvName
            // 
            this.tvName.AutoEllipsis = true;
            this.tvName.BackColor = System.Drawing.Color.Transparent;
            this.tvName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvName.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvName.ForeColor = System.Drawing.Color.Black;
            this.tvName.Location = new System.Drawing.Point(52, 8);
            this.tvName.Name = "tvName";
            this.tvName.Size = new System.Drawing.Size(183, 18);
            this.tvName.TabIndex = 18;
            this.tvName.Text = "0个";
            this.tvName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tvName.UseMnemonic = false;
            this.tvName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Item_MouseClick);
            // 
            // pic_ex
            // 
            this.pic_ex.BackColor = System.Drawing.Color.Transparent;
            this.pic_ex.Image = global::WinFrmTalk.Properties.Resources.ic_group_level1;
            this.pic_ex.Location = new System.Drawing.Point(0, 8);
            this.pic_ex.Name = "pic_ex";
            this.pic_ex.Size = new System.Drawing.Size(18, 18);
            this.pic_ex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_ex.TabIndex = 20;
            this.pic_ex.TabStop = false;
            this.pic_ex.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Item_MouseClick);
            // 
            // ivCurrtLevel
            // 
            this.ivCurrtLevel.BackColor = System.Drawing.Color.Transparent;
            this.ivCurrtLevel.Image = global::WinFrmTalk.Properties.Resources.ic_group_level1;
            this.ivCurrtLevel.Location = new System.Drawing.Point(23, 6);
            this.ivCurrtLevel.Name = "ivCurrtLevel";
            this.ivCurrtLevel.Size = new System.Drawing.Size(22, 22);
            this.ivCurrtLevel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ivCurrtLevel.TabIndex = 19;
            this.ivCurrtLevel.TabStop = false;
            this.ivCurrtLevel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Item_MouseClick);
            // 
            // btnLook
            // 
            this.btnLook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLook.BackColor = System.Drawing.Color.Transparent;
            this.btnLook.Image = global::WinFrmTalk.Properties.Resources.ic_group_look1;
            this.btnLook.Location = new System.Drawing.Point(248, 6);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(52, 23);
            this.btnLook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLook.TabIndex = 21;
            this.btnLook.TabStop = false;
            this.btnLook.Visible = false;
            this.btnLook.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Look_MouseClick);
            // 
            // GroupTreeNodeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLook);
            this.Controls.Add(this.pic_ex);
            this.Controls.Add(this.ivCurrtLevel);
            this.Controls.Add(this.tvName);
            this.Name = "GroupTreeNodeItem";
            this.Size = new System.Drawing.Size(302, 34);
            ((System.ComponentModel.ISupportInitialize)(this.pic_ex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivCurrtLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ivCurrtLevel;
        private System.Windows.Forms.Label tvName;
        private System.Windows.Forms.PictureBox pic_ex;
        private System.Windows.Forms.PictureBox btnLook;
    }
}
