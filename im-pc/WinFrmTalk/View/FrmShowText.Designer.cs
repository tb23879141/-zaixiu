namespace WinFrmTalk.View
{
    partial class FrmShowText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowText));
            this.txtContent = new RichTextBoxLinks.RichTextBoxEx();
            this.SuspendLayout();
            // 
            // txtContent
            // 
            this.txtContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtContent.BackColor = System.Drawing.Color.White;
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContent.DetectUrls = false;
            this.txtContent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtContent.Location = new System.Drawing.Point(7, 31);
            this.txtContent.MaximumSize = new System.Drawing.Size(429, 330);
            this.txtContent.MinimumSize = new System.Drawing.Size(0, 30);
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.Size = new System.Drawing.Size(429, 330);
            this.txtContent.TabIndex = 16;
            this.txtContent.Text = "";
            // 
            // FrmShowText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(443, 369);
            this.Controls.Add(this.txtContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShowText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.FrmShowText_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBoxLinks.RichTextBoxEx txtContent;
    }
}