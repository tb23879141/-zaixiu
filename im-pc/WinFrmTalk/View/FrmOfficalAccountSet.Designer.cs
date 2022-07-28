namespace WinFrmTalk.View
{
    partial class FrmOfficalAccountSet
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
            this.userOffialAccountSet1 = new WinFrmTalk.Controls.CustomControls.UserOffialAccountSet();
            this.SuspendLayout();
            // 
            // userOffialAccountSet1
            // 
            this.userOffialAccountSet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userOffialAccountSet1.Location = new System.Drawing.Point(0, 0);
            this.userOffialAccountSet1.Name = "userOffialAccountSet1";
            this.userOffialAccountSet1.Size = new System.Drawing.Size(250, 597);
            this.userOffialAccountSet1.TabIndex = 0;
            // 
            // FrmOfficalAccountSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 597);
            this.Controls.Add(this.userOffialAccountSet1);
            this.Name = "FrmOfficalAccountSet";
            this.ShowInTaskbar = false;
            this.Text = "FrmOfficalAccountSet";
            this.Load += new System.EventHandler(this.FrmOfficalAccountSet_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CustomControls.UserOffialAccountSet userOffialAccountSet1;
    }
}