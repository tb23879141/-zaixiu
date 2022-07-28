namespace WinFrmTalk.View
{
    partial class FrmChromeBrowser
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
            this.LivePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // LivePanel
            // 
            this.LivePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LivePanel.Location = new System.Drawing.Point(4, 28);
            this.LivePanel.Name = "LivePanel";
            this.LivePanel.Size = new System.Drawing.Size(1072, 768);
            this.LivePanel.TabIndex = 0;
            // 
            // FrmChromeBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 800);
            this.Controls.Add(this.LivePanel);
            this.KeyPreview = true;
            this.Name = "FrmChromeBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmChromeBrowser_FormClosed);
            this.Load += new System.EventHandler(this.FrmChromeBrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LivePanel;
    }
}