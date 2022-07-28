namespace WinFrmTalk
{
    partial class LeftLayoutLive
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
            this.flowLayoutPanelBorder1 = new WinFrmTalk.Controls.FlowLayoutPanelBorder();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.imageViewxLive = new WinFrmTalk.Controls.ImageViewx();
            this.flowLayoutPanelBorder1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewxLive)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelBorder1
            // 
            this.flowLayoutPanelBorder1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelBorder1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelBorder1.Controls.Add(this.panel2);
            this.flowLayoutPanelBorder1.Cursor = System.Windows.Forms.Cursors.Default;
            this.flowLayoutPanelBorder1.LineColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelBorder1.LineDashPattern = null;
            this.flowLayoutPanelBorder1.LineDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.flowLayoutPanelBorder1.LinePenMode = 1;
            this.flowLayoutPanelBorder1.LineThick = 1;
            this.flowLayoutPanelBorder1.Location = new System.Drawing.Point(0, 50);
            this.flowLayoutPanelBorder1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelBorder1.Name = "flowLayoutPanelBorder1";
            this.flowLayoutPanelBorder1.Size = new System.Drawing.Size(60, 610);
            this.flowLayoutPanelBorder1.TabIndex = 0;
            this.flowLayoutPanelBorder1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanelBorder1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.imageViewxLive);
            this.panel2.Location = new System.Drawing.Point(7, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(40, 60);
            this.panel2.TabIndex = 4;
            this.panel2.MouseLeave += new System.EventHandler(this.imageViewxLive_MouseLeave);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageViewxLive_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(40, 18);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(2, -2);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "在秀";
            this.label1.Click += new System.EventHandler(this.imageViewxLive_Click);
            this.label1.MouseLeave += new System.EventHandler(this.imageViewxLive_MouseLeave);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageViewxLive_MouseMove);
            // 
            // imageViewxLive
            // 
            this.imageViewxLive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageViewxLive.Image = global::WinFrmTalk.Properties.Resources.tnshow_logo;
            this.imageViewxLive.Location = new System.Drawing.Point(2, 0);
            this.imageViewxLive.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.imageViewxLive.Name = "imageViewxLive";
            this.imageViewxLive.Size = new System.Drawing.Size(36, 36);
            this.imageViewxLive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageViewxLive.TabIndex = 0;
            this.imageViewxLive.TabStop = false;
            this.imageViewxLive.UnreadCount = 0;
            this.imageViewxLive.UnreadMargin = 0;
            this.imageViewxLive.UnreadSize = 20;
            this.imageViewxLive.Click += new System.EventHandler(this.imageViewxLive_Click);
            this.imageViewxLive.MouseLeave += new System.EventHandler(this.imageViewxLive_MouseLeave);
            this.imageViewxLive.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageViewxLive_MouseMove);
            // 
            // LeftLayoutLive
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flowLayoutPanelBorder1);
            this.Name = "LeftLayoutLive";
            this.Size = new System.Drawing.Size(60, 660);
            this.Load += new System.EventHandler(this.LeftLayoutLive_Load);
            this.flowLayoutPanelBorder1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageViewxLive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private WinFrmTalk.Controls.ImageViewx imageViewxLive;
        private System.Windows.Forms.Label label1;
        private Controls.FlowLayoutPanelBorder flowLayoutPanelBorder1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
