namespace WinFrmTalk.Controls.CustomControls
{
    partial class ServiceListCrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceListCrl));
            this.lblShow = new WinFrmTalk.Controls.LabelBorder();
            this.SuspendLayout();
            // 
            // lblShow
            // 
            this.lblShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShow.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblShow.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblShow.Image = ((System.Drawing.Image)(resources.GetObject("lblShow.Image")));
            this.lblShow.Border.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblShow.Border.LineDashPattern = null;
            this.lblShow.Border.LineDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblShow.Border.LineThick = 1;
            this.lblShow.Border.IsShowLeft = false;
            this.lblShow.Border.IsShowTop = true;
            this.lblShow.Border.IsShowRight = false;
            this.lblShow.Border.IsShowBottom = false;
            this.lblShow.Location = new System.Drawing.Point(390, 0);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(50, 50);
            this.lblShow.TabIndex = 0;
            this.lblShow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblShow_MouseClick);
            // 
            // ServiceListCrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.Controls.Add(this.lblShow);
            this.Name = "ServiceListCrl";
            this.Size = new System.Drawing.Size(440, 50);
            this.SizeChanged += new System.EventHandler(this.ServiceListCrl_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private WinFrmTalk.Controls.LabelBorder lblShow;
    }
}
