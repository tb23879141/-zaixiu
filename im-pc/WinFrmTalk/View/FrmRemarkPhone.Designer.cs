namespace WinFrmTalk.View
{
    partial class FrmRemarkPhone
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
            this.pnlRemarkPhone = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // pnlRemarkPhone
            // 
            this.pnlRemarkPhone.BackColor = System.Drawing.Color.White;
            this.pnlRemarkPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRemarkPhone.Location = new System.Drawing.Point(0, 0);
            this.pnlRemarkPhone.Name = "pnlRemarkPhone";
            this.pnlRemarkPhone.Size = new System.Drawing.Size(231, 48);
            this.pnlRemarkPhone.TabIndex = 0;
            // 
            // FrmRemarkPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 48);
            this.Controls.Add(this.pnlRemarkPhone);
            this.Name = "FrmRemarkPhone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmRemarkPhone";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlRemarkPhone;
    }
}