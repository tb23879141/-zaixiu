namespace WinFrmTalk
{
    partial class FrmLookImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLookImage));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmCollect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmForward = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSaveAS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pboxColle = new System.Windows.Forms.PictureBox();
            this.pboxZhuan = new System.Windows.Forms.PictureBox();
            this.pboxFile = new System.Windows.Forms.PictureBox();
            this.pboxShrink = new System.Windows.Forms.PictureBox();
            this.pboxDown = new System.Windows.Forms.PictureBox();
            this.pobxMagnify = new System.Windows.Forms.PictureBox();
            this.skbtnLeft = new System.Windows.Forms.PictureBox();
            this.pboxMax = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.skbtnRight = new System.Windows.Forms.PictureBox();
            this.pboxOpenFile = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxColle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxZhuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxShrink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pobxMagnify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skbtnLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMax)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skbtnRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxOpenFile)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCollect,
            this.tsmForward,
            this.tsmDelete,
            this.tsmSaveAS,
            this.tsmDownload});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 114);
            // 
            // tsmCollect
            // 
            this.tsmCollect.Name = "tsmCollect";
            this.tsmCollect.Size = new System.Drawing.Size(112, 22);
            this.tsmCollect.Text = "保存";
            // 
            // tsmForward
            // 
            this.tsmForward.Name = "tsmForward";
            this.tsmForward.Size = new System.Drawing.Size(112, 22);
            this.tsmForward.Text = "转发";
            this.tsmForward.Click += new System.EventHandler(this.tsmTranspond_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(112, 22);
            this.tsmDelete.Text = "删除";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // tsmSaveAS
            // 
            this.tsmSaveAS.Name = "tsmSaveAS";
            this.tsmSaveAS.Size = new System.Drawing.Size(112, 22);
            this.tsmSaveAS.Text = "另存为";
            this.tsmSaveAS.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsmDownload
            // 
            this.tsmDownload.Name = "tsmDownload";
            this.tsmDownload.Size = new System.Drawing.Size(112, 22);
            this.tsmDownload.Text = "下载";
            this.tsmDownload.Visible = false;
            this.tsmDownload.Click += new System.EventHandler(this.tsmLoca_Click);
            // 
            // tsmDown
            // 
            this.tsmDown.Name = "tsmDown";
            this.tsmDown.Size = new System.Drawing.Size(180, 22);
            this.tsmDown.Text = "下载";
            // 
            // pboxColle
            // 
            this.pboxColle.Image = ((System.Drawing.Image)(resources.GetObject("pboxColle.Image")));
            this.pboxColle.Location = new System.Drawing.Point(285, 3);
            this.pboxColle.Margin = new System.Windows.Forms.Padding(15, 3, 0, 3);
            this.pboxColle.Name = "pboxColle";
            this.pboxColle.Size = new System.Drawing.Size(30, 30);
            this.pboxColle.TabIndex = 28;
            this.pboxColle.TabStop = false;
            this.toolTip1.SetToolTip(this.pboxColle, "保存");
            this.pboxColle.Click += new System.EventHandler(this.pboxColle_Click);
            this.pboxColle.MouseEnter += new System.EventHandler(this.pboxColle_MouseEnter);
            // 
            // pboxZhuan
            // 
            this.pboxZhuan.Image = ((System.Drawing.Image)(resources.GetObject("pboxZhuan.Image")));
            this.pboxZhuan.Location = new System.Drawing.Point(240, 3);
            this.pboxZhuan.Margin = new System.Windows.Forms.Padding(15, 3, 0, 3);
            this.pboxZhuan.Name = "pboxZhuan";
            this.pboxZhuan.Size = new System.Drawing.Size(30, 30);
            this.pboxZhuan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxZhuan.TabIndex = 25;
            this.pboxZhuan.TabStop = false;
            this.pboxZhuan.Click += new System.EventHandler(this.pboxZhuan_Click);
            this.pboxZhuan.MouseEnter += new System.EventHandler(this.pboxZhuan_MouseEnter);
            // 
            // pboxFile
            // 
            this.pboxFile.Image = ((System.Drawing.Image)(resources.GetObject("pboxFile.Image")));
            this.pboxFile.Location = new System.Drawing.Point(330, 3);
            this.pboxFile.Margin = new System.Windows.Forms.Padding(15, 3, 0, 3);
            this.pboxFile.Name = "pboxFile";
            this.pboxFile.Size = new System.Drawing.Size(30, 30);
            this.pboxFile.TabIndex = 27;
            this.pboxFile.TabStop = false;
            this.pboxFile.Visible = false;
            this.pboxFile.Click += new System.EventHandler(this.pboxFile_Click);
            this.pboxFile.MouseEnter += new System.EventHandler(this.pboxFile_MouseEnter);
            // 
            // pboxShrink
            // 
            this.pboxShrink.Image = ((System.Drawing.Image)(resources.GetObject("pboxShrink.Image")));
            this.pboxShrink.Location = new System.Drawing.Point(150, 3);
            this.pboxShrink.Margin = new System.Windows.Forms.Padding(15, 3, 0, 3);
            this.pboxShrink.Name = "pboxShrink";
            this.pboxShrink.Size = new System.Drawing.Size(30, 30);
            this.pboxShrink.TabIndex = 25;
            this.pboxShrink.TabStop = false;
            this.pboxShrink.Click += new System.EventHandler(this.pboxShrink_Click);
            this.pboxShrink.MouseEnter += new System.EventHandler(this.pboxShrink_MouseEnter);
            // 
            // pboxDown
            // 
            this.pboxDown.Image = ((System.Drawing.Image)(resources.GetObject("pboxDown.Image")));
            this.pboxDown.Location = new System.Drawing.Point(195, 3);
            this.pboxDown.Margin = new System.Windows.Forms.Padding(15, 3, 0, 3);
            this.pboxDown.Name = "pboxDown";
            this.pboxDown.Size = new System.Drawing.Size(30, 30);
            this.pboxDown.TabIndex = 26;
            this.pboxDown.TabStop = false;
            this.pboxDown.Click += new System.EventHandler(this.pboxDown_Click);
            this.pboxDown.MouseEnter += new System.EventHandler(this.pboxDown_MouseEnter);
            // 
            // pobxMagnify
            // 
            this.pobxMagnify.Image = ((System.Drawing.Image)(resources.GetObject("pobxMagnify.Image")));
            this.pobxMagnify.Location = new System.Drawing.Point(105, 3);
            this.pobxMagnify.Margin = new System.Windows.Forms.Padding(15, 3, 0, 3);
            this.pobxMagnify.Name = "pobxMagnify";
            this.pobxMagnify.Size = new System.Drawing.Size(30, 30);
            this.pobxMagnify.TabIndex = 26;
            this.pobxMagnify.TabStop = false;
            this.pobxMagnify.Click += new System.EventHandler(this.pobxMagnify_Click);
            this.pobxMagnify.MouseEnter += new System.EventHandler(this.pobxMagnify_MouseEnter);
            // 
            // skbtnLeft
            // 
            this.skbtnLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skbtnLeft.Location = new System.Drawing.Point(15, 3);
            this.skbtnLeft.Margin = new System.Windows.Forms.Padding(15, 3, 0, 3);
            this.skbtnLeft.Name = "skbtnLeft";
            this.skbtnLeft.Size = new System.Drawing.Size(30, 30);
            this.skbtnLeft.TabIndex = 29;
            this.skbtnLeft.TabStop = false;
            this.skbtnLeft.Click += new System.EventHandler(this.skbtnLeft_Click_1);
            this.skbtnLeft.MouseEnter += new System.EventHandler(this.skbtnLeft_MouseEnter);
            // 
            // pboxMax
            // 
            this.pboxMax.Image = ((System.Drawing.Image)(resources.GetObject("pboxMax.Image")));
            this.pboxMax.Location = new System.Drawing.Point(420, 3);
            this.pboxMax.Margin = new System.Windows.Forms.Padding(15, 3, 0, 3);
            this.pboxMax.Name = "pboxMax";
            this.pboxMax.Size = new System.Drawing.Size(30, 30);
            this.pboxMax.TabIndex = 31;
            this.pboxMax.TabStop = false;
            this.pboxMax.Click += new System.EventHandler(this.pboxMax_Click);
            this.pboxMax.MouseEnter += new System.EventHandler(this.pboxMax_MouseEnter);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.skbtnLeft);
            this.panel2.Controls.Add(this.skbtnRight);
            this.panel2.Controls.Add(this.pobxMagnify);
            this.panel2.Controls.Add(this.pboxShrink);
            this.panel2.Controls.Add(this.pboxDown);
            this.panel2.Controls.Add(this.pboxZhuan);
            this.panel2.Controls.Add(this.pboxColle);
            this.panel2.Controls.Add(this.pboxFile);
            this.panel2.Controls.Add(this.pboxOpenFile);
            this.panel2.Controls.Add(this.pboxMax);
            this.panel2.Location = new System.Drawing.Point(1, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 36);
            this.panel2.TabIndex = 7;
            // 
            // skbtnRight
            // 
            this.skbtnRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skbtnRight.Location = new System.Drawing.Point(60, 3);
            this.skbtnRight.Margin = new System.Windows.Forms.Padding(15, 3, 0, 3);
            this.skbtnRight.Name = "skbtnRight";
            this.skbtnRight.Size = new System.Drawing.Size(30, 30);
            this.skbtnRight.TabIndex = 30;
            this.skbtnRight.TabStop = false;
            this.skbtnRight.Click += new System.EventHandler(this.skbtnRight_Click_1);
            this.skbtnRight.MouseEnter += new System.EventHandler(this.skbtnRight_MouseEnter);
            // 
            // pboxOpenFile
            // 
            this.pboxOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("pboxOpenFile.Image")));
            this.pboxOpenFile.Location = new System.Drawing.Point(375, 3);
            this.pboxOpenFile.Margin = new System.Windows.Forms.Padding(15, 3, 0, 3);
            this.pboxOpenFile.Name = "pboxOpenFile";
            this.pboxOpenFile.Size = new System.Drawing.Size(30, 30);
            this.pboxOpenFile.TabIndex = 32;
            this.pboxOpenFile.TabStop = false;
            this.pboxOpenFile.Visible = false;
            this.pboxOpenFile.Click += new System.EventHandler(this.pboxOpenFile_Click);
            this.pboxOpenFile.MouseEnter += new System.EventHandler(this.pboxOpenFile_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 650);
            this.panel1.TabIndex = 12;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Location = new System.Drawing.Point(15, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(769, 616);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // FrmLookImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 730);
            this.CloseBoxSize = new System.Drawing.Size(32, 26);
            this.CloseMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseMouseBack")));
            this.CloseNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseNormlBack")));
            this.ControlBoxOffset = new System.Drawing.Point(0, 0);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaxMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxMouseBack")));
            this.MaxNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxNormlBack")));
            this.MaxSize = new System.Drawing.Size(32, 26);
            this.MiniMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniMouseBack")));
            this.MiniNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniNormlBack")));
            this.MiniSize = new System.Drawing.Size(32, 26);
            this.Name = "FrmLookImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片查看";
            this.TitleNeed = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLookImage_FormClosing);
            this.Load += new System.EventHandler(this.FrmLookImage_Load);
            this.SizeChanged += new System.EventHandler(this.FrmLookImage_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLookImage_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmLookImage_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxColle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxZhuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxShrink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pobxMagnify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skbtnLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMax)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skbtnRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxOpenFile)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmForward;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmSaveAS;
        private System.Windows.Forms.ToolStripMenuItem tsmDown;
        private System.Windows.Forms.ToolStripMenuItem tsmDownload;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pboxZhuan;
        private System.Windows.Forms.PictureBox pboxFile;
        private System.Windows.Forms.PictureBox pboxShrink;
        private System.Windows.Forms.PictureBox pboxColle;
        private System.Windows.Forms.PictureBox pboxDown;
        private System.Windows.Forms.PictureBox pobxMagnify;
        private System.Windows.Forms.PictureBox skbtnLeft;
        private System.Windows.Forms.PictureBox pboxMax;
        private System.Windows.Forms.FlowLayoutPanel panel2;
        private System.Windows.Forms.PictureBox skbtnRight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pboxOpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsmCollect;
    }
}