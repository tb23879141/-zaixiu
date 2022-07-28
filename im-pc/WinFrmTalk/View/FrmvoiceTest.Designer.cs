namespace WinFrmTalk.View
{
    partial class FrmvoiceTest
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
            this.userVoiceplayer1 = new WinFrmTalk.Controls.CustomControls.UserVoiceplayer();
            this.SuspendLayout();
            // 
            // userVoiceplayer1
            // 
            this.userVoiceplayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userVoiceplayer1.BackColor = System.Drawing.Color.White;
            this.userVoiceplayer1.Location = new System.Drawing.Point(2, 20);
            this.userVoiceplayer1.Name = "userVoiceplayer1";
            this.userVoiceplayer1.Size = new System.Drawing.Size(462, 49);
            this.userVoiceplayer1.TabIndex = 3;
            // 
            // FrmvoiceTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 72);
            this.Controls.Add(this.userVoiceplayer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmvoiceTest";
            this.Radius = 0;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "";
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.CustomControls.UserVoiceplayer userVoiceplayer1;
    }
}