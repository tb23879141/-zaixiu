namespace WinFrmTalk
{
    partial class FrmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTest));
            this.leftLayout1 = new WinFrmTalk.LeftLayoutTab();
            this.listLayoutTitleBar1 = new WinFrmTalk.Controls.CustomControls.ListLayoutTitleBar();
            this.mainPageLayout1 = new WinFrmTalk.Controls.LayouotControl.MainPageLayout();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkTextBoxEx21 = new WinFrmTalk.Controls.CheckTextBoxEx2();
            this.checkSexBoxEx1 = new WinFrmTalk.Controls.CustomControls.CheckSexBoxEx();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // leftLayout1
            // 
            this.leftLayout1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(222)))));
            this.leftLayout1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftLayout1.BackgroundImage")));
            this.leftLayout1.Location = new System.Drawing.Point(0, 50);
            this.leftLayout1.MainForm = null;
            this.leftLayout1.Name = "leftLayout1";
            this.leftLayout1.SelectIndex = WinFrmTalk.MainTabIndex.RecentListPage;
            this.leftLayout1.Size = new System.Drawing.Size(100, 742);
            this.leftLayout1.TabIndex = 12;
            // 
            // listLayoutTitleBar1
            // 
            this.listLayoutTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.listLayoutTitleBar1.Name = "listLayoutTitleBar1";
            this.listLayoutTitleBar1.Size = new System.Drawing.Size(375, 50);
            this.listLayoutTitleBar1.TabIndex = 13;
            // 
            // mainPageLayout1
            // 
            this.mainPageLayout1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPageLayout1.BackColor = System.Drawing.Color.Gray;
            this.mainPageLayout1.Location = new System.Drawing.Point(375, 0);
            this.mainPageLayout1.MainForm = null;
            this.mainPageLayout1.Name = "mainPageLayout1";
            this.mainPageLayout1.SelectedIndex = WinFrmTalk.MainTabIndex.RecentListPage;
            this.mainPageLayout1.Size = new System.Drawing.Size(723, 658);
            this.mainPageLayout1.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(190, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(190, 292);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 30;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkTextBoxEx21
            // 
            this.checkTextBoxEx21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkTextBoxEx21.LabelText = null;
            this.checkTextBoxEx21.Location = new System.Drawing.Point(149, 406);
            this.checkTextBoxEx21.Name = "checkTextBoxEx21";
            this.checkTextBoxEx21.Size = new System.Drawing.Size(230, 62);
            this.checkTextBoxEx21.TabIndex = 36;
            // 
            // checkSexBoxEx1
            // 
            this.checkSexBoxEx1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkSexBoxEx1.BackgroundImage")));
            this.checkSexBoxEx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkSexBoxEx1.Location = new System.Drawing.Point(159, 90);
            this.checkSexBoxEx1.Name = "checkSexBoxEx1";
            this.checkSexBoxEx1.Size = new System.Drawing.Size(90, 26);
            this.checkSexBoxEx1.TabIndex = 42;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(612, 210);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(310, 145);
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 660);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkSexBoxEx1);
            this.Controls.Add(this.checkTextBoxEx21);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mainPageLayout1);
            this.Controls.Add(this.leftLayout1);
            this.Controls.Add(this.listLayoutTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmTest";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LeftLayoutTab leftLayout1;
        private Controls.CustomControls.ListLayoutTitleBar listLayoutTitleBar1;
        private Controls.LayouotControl.MainPageLayout mainPageLayout1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private Controls.CheckTextBoxEx2 checkTextBoxEx21;
        private Controls.CustomControls.CheckSexBoxEx checkSexBoxEx1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}