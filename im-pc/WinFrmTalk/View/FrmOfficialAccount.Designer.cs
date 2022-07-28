namespace WinFrmTalk.View
{
    partial class FrmOfficialAccount
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
            this.officialAccountPanel = new WinFrmTalk.Controls.CustomControls.OfficialAccountPanel();
            this.SuspendLayout();
            // 
            // officialAccountPanel
            // 
            this.officialAccountPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.officialAccountPanel.Location = new System.Drawing.Point(0, 31);
            this.officialAccountPanel.Name = "officialAccountPanel";
            this.officialAccountPanel.Size = new System.Drawing.Size(320, 454);
            this.officialAccountPanel.TabIndex = 6;
            // 
            // FrmOfficialAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(320, 485);
            this.Controls.Add(this.officialAccountPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmOfficialAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公众号查询";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CustomControls.OfficialAccountPanel officialAccountPanel;
    }
}