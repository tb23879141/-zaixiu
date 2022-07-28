
namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    partial class FrmDetailsNotify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetailsNotify));
            this.limitPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.xScrollBar1 = new TestListView.XScrollBar();
            this.limitPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // limitPanel
            // 
            this.limitPanel.Controls.Add(this.flowLayoutPanel1);
            this.limitPanel.Location = new System.Drawing.Point(58, 40);
            this.limitPanel.Name = "limitPanel";
            this.limitPanel.Size = new System.Drawing.Size(430, 583);
            this.limitPanel.TabIndex = 15;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(430, 483);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // xScrollBar1
            // 
            this.xScrollBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xScrollBar1.BackgroundImage")));
            this.xScrollBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xScrollBar1.Location = new System.Drawing.Point(539, 40);
            this.xScrollBar1.Name = "xScrollBar1";
            this.xScrollBar1.Size = new System.Drawing.Size(10, 583);
            this.xScrollBar1.TabIndex = 18;
            this.xScrollBar1.ScrollChangeListener += new TestListView.XScrollBar.EventProgressHandler(this.xScrollBar1_ScrollChangeListener);
            // 
            // FrmDetailsNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(550, 640);
            this.Controls.Add(this.xScrollBar1);
            this.Controls.Add(this.limitPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmDetailsNotify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TitleNeed = false;
            this.limitPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel limitPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private TestListView.XScrollBar xScrollBar1;
    }
}