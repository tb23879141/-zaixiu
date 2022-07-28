namespace WinFrmTalk
{
    partial class FriendLabelLayout
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
            this.xListView = new TestListView.XListView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCreate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // xListView
            // 
            this.xListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.xListView.Location = new System.Drawing.Point(0, 38);
            this.xListView.Name = "xListView";
            this.xListView.ScrollBarWidth = 10;
            this.xListView.Size = new System.Drawing.Size(275, 500);
            this.xListView.TabIndex = 24;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Image = global::WinFrmTalk.Properties.Resources.ic_button_bg1;
            this.btnCreate.Location = new System.Drawing.Point(75, 556);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(121, 41);
            this.btnCreate.TabIndex = 32;
            this.btnCreate.Text = "创建标签";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCreate.Click += new System.EventHandler(this.OnCreateLable);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 38);
            this.label1.TabIndex = 33;
            this.label1.Text = "好友标签";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FriendLabelLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.xListView);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FriendLabelLayout";
            this.Size = new System.Drawing.Size(275, 610);
            this.ResumeLayout(false);

        }

        #endregion
        private TestListView.XListView xListView;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label btnCreate;
        private System.Windows.Forms.Label label1;
    }
}
