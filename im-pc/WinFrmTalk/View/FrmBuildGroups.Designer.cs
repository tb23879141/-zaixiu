namespace WinFrmTalk.View
{
    partial class FrmBuildGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuildGroups));
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescrip = new System.Windows.Forms.Label();
            this.btnInviteFrds = new LollipopButton();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtGroupDis = new System.Windows.Forms.TextBox();
            this.rlEncrypt = new WinFrmTalk.Controls.CustomControls.USeCheckData();
            this.lblTips = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblDescrip
            // 
            resources.ApplyResources(this.lblDescrip, "lblDescrip");
            this.lblDescrip.Name = "lblDescrip";
            // 
            // btnInviteFrds
            // 
            this.btnInviteFrds.BackColor = System.Drawing.Color.Transparent;
            this.btnInviteFrds.BGColor = "26,181,26";
            resources.ApplyResources(this.btnInviteFrds, "btnInviteFrds");
            this.btnInviteFrds.FontColor = "#ffffff";
            this.btnInviteFrds.Name = "btnInviteFrds";
            this.btnInviteFrds.Click += new System.EventHandler(this.btnInviteFrds_Click);
            // 
            // txtGroupName
            // 
            resources.ApplyResources(this.txtGroupName, "txtGroupName");
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGroupName_KeyPress);
            // 
            // txtGroupDis
            // 
            resources.ApplyResources(this.txtGroupDis, "txtGroupDis");
            this.txtGroupDis.Name = "txtGroupDis";
            this.txtGroupDis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGroupName_KeyPress);
            // 
            // rlEncrypt
            // 
            this.rlEncrypt.FunctionName = "私密群组";
            resources.ApplyResources(this.rlEncrypt, "rlEncrypt");
            this.rlEncrypt.Name = "rlEncrypt";
            this.rlEncrypt.Tag = "3";
            // 
            // lblTips
            // 
            resources.ApplyResources(this.lblTips, "lblTips");
            this.lblTips.Name = "lblTips";
            // 
            // FrmBuildGroups
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.rlEncrypt);
            this.Controls.Add(this.txtGroupDis);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.btnInviteFrds);
            this.Controls.Add(this.lblDescrip);
            this.Controls.Add(this.lblName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBuildGroups";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBuildGroups_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescrip;
        private LollipopButton btnInviteFrds;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtGroupDis;
        private Controls.CustomControls.USeCheckData rlEncrypt;
        private System.Windows.Forms.Label lblTips;
    }
}