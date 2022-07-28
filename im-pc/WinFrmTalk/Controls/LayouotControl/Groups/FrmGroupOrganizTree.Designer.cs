
namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    partial class FrmGroupOrganizTree
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
            this.ivGroupIcon = new System.Windows.Forms.PictureBox();
            this.labName = new System.Windows.Forms.Label();
            this.roundPanel1 = new WinFrmTalk.Controls.SystemControls.RoundPanel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox0 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.leftLine = new System.Windows.Forms.Label();
            this.xListView = new TestListView.XListView();
            this.contextMenuStrip1 = new CCWin.SkinControl.SkinContextMenuStrip();
            this.item_inside = new System.Windows.Forms.ToolStripMenuItem();
            this.separator_one = new System.Windows.Forms.ToolStripSeparator();
            this.item_external = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ivGroupIcon)).BeginInit();
            this.roundPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ivGroupIcon
            // 
            this.ivGroupIcon.Image = global::WinFrmTalk.Properties.Resources.groupGQ;
            this.ivGroupIcon.Location = new System.Drawing.Point(11, 16);
            this.ivGroupIcon.Name = "ivGroupIcon";
            this.ivGroupIcon.Size = new System.Drawing.Size(20, 20);
            this.ivGroupIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ivGroupIcon.TabIndex = 14;
            this.ivGroupIcon.TabStop = false;
            // 
            // labName
            // 
            this.labName.AutoEllipsis = true;
            this.labName.BackColor = System.Drawing.Color.Transparent;
            this.labName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labName.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labName.ForeColor = System.Drawing.Color.Black;
            this.labName.Location = new System.Drawing.Point(37, 16);
            this.labName.MaximumSize = new System.Drawing.Size(220, 21);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(190, 21);
            this.labName.TabIndex = 13;
            this.labName.Text = "我是默认名称";
            this.labName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // roundPanel1
            // 
            this.roundPanel1.Controls.Add(this.pictureBox4);
            this.roundPanel1.Controls.Add(this.label1);
            this.roundPanel1.FillColor = System.Drawing.Color.White;
            this.roundPanel1.FrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.roundPanel1.Location = new System.Drawing.Point(233, 14);
            this.roundPanel1.Name = "roundPanel1";
            this.roundPanel1.Raduis = 4;
            this.roundPanel1.Size = new System.Drawing.Size(80, 24);
            this.roundPanel1.TabIndex = 15;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WinFrmTalk.Properties.Resources.ic_group_tree_expaned;
            this.pictureBox4.Location = new System.Drawing.Point(61, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(18, 18);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 28;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Inside_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(7, 2);
            this.label1.MaximumSize = new System.Drawing.Size(220, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "外部群";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Inside_MouseClick);
            // 
            // pictureBox0
            // 
            this.pictureBox0.Image = global::WinFrmTalk.Properties.Resources.ic_group_org4;
            this.pictureBox0.Location = new System.Drawing.Point(12, 50);
            this.pictureBox0.Name = "pictureBox0";
            this.pictureBox0.Size = new System.Drawing.Size(18, 18);
            this.pictureBox0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox0.TabIndex = 17;
            this.pictureBox0.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label2.Location = new System.Drawing.Point(34, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "0个";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.UseMnemonic = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinFrmTalk.Properties.Resources.ic_group_org3;
            this.pictureBox1.Location = new System.Drawing.Point(89, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WinFrmTalk.Properties.Resources.ic_group_org2;
            this.pictureBox2.Location = new System.Drawing.Point(166, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WinFrmTalk.Properties.Resources.ic_group_org1;
            this.pictureBox3.Location = new System.Drawing.Point(243, 50);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 18);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label3.Location = new System.Drawing.Point(110, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "0个";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.UseMnemonic = false;
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label4.Location = new System.Drawing.Point(186, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "0个";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.UseMnemonic = false;
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label5.Location = new System.Drawing.Point(262, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "0个";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.UseMnemonic = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Location = new System.Drawing.Point(10, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(300, 1);
            this.label6.TabIndex = 24;
            this.label6.UseMnemonic = false;
            // 
            // leftLine
            // 
            this.leftLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftLine.BackColor = System.Drawing.SystemColors.ControlLight;
            this.leftLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leftLine.Location = new System.Drawing.Point(0, 0);
            this.leftLine.Name = "leftLine";
            this.leftLine.Size = new System.Drawing.Size(1, 640);
            this.leftLine.TabIndex = 25;
            this.leftLine.UseMnemonic = false;
            // 
            // xListView
            // 
            this.xListView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xListView.Location = new System.Drawing.Point(10, 82);
            this.xListView.Name = "xListView";
            this.xListView.ScrollBarWidth = 10;
            this.xListView.Size = new System.Drawing.Size(313, 557);
            this.xListView.TabIndex = 26;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Arrow = System.Drawing.Color.Black;
            this.contextMenuStrip1.Back = System.Drawing.Color.White;
            this.contextMenuStrip1.BackRadius = 1;
            this.contextMenuStrip1.Base = System.Drawing.Color.White;
            this.contextMenuStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.contextMenuStrip1.DropShadowEnabled = false;
            this.contextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contextMenuStrip1.Fore = System.Drawing.Color.Black;
            this.contextMenuStrip1.HoverFore = System.Drawing.Color.Black;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.ItemAnamorphosis = false;
            this.contextMenuStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.contextMenuStrip1.ItemBorderShow = false;
            this.contextMenuStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.contextMenuStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.contextMenuStrip1.ItemRadius = 1;
            this.contextMenuStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_inside,
            this.separator_one,
            this.item_external});
            this.contextMenuStrip1.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.contextMenuStrip1.Name = "contentMenuStrip";
            this.contextMenuStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 54);
            this.contextMenuStrip1.SkinAllColor = true;
            this.contextMenuStrip1.TitleAnamorphosis = false;
            this.contextMenuStrip1.TitleColor = System.Drawing.Color.White;
            this.contextMenuStrip1.TitleRadius = 4;
            this.contextMenuStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // item_inside
            // 
            this.item_inside.Name = "item_inside";
            this.item_inside.Size = new System.Drawing.Size(112, 22);
            this.item_inside.Tag = "0";
            this.item_inside.Text = "内部群";
            this.item_inside.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // separator_one
            // 
            this.separator_one.Name = "separator_one";
            this.separator_one.Size = new System.Drawing.Size(109, 6);
            // 
            // item_external
            // 
            this.item_external.Name = "item_external";
            this.item_external.Size = new System.Drawing.Size(112, 22);
            this.item_external.Tag = "1";
            this.item_external.Text = "外部群";
            this.item_external.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // FrmGroupOrganizTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(322, 640);
            this.Controls.Add(this.xListView);
            this.Controls.Add(this.leftLine);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox0);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.roundPanel1);
            this.Controls.Add(this.ivGroupIcon);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmGroupOrganizTree";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.ivGroupIcon)).EndInit();
            this.roundPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ivGroupIcon;
        private System.Windows.Forms.Label labName;
        private SystemControls.RoundPanel roundPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label leftLine;
        private TestListView.XListView xListView;
        private System.Windows.Forms.PictureBox pictureBox4;
        private CCWin.SkinControl.SkinContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem item_inside;
        private System.Windows.Forms.ToolStripSeparator separator_one;
        private System.Windows.Forms.ToolStripMenuItem item_external;
    }
}