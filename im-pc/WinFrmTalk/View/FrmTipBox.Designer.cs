namespace WinFrmTalk.View
{
    partial class FrmTipBox
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
            this.btnConfirm = new LollipopButton();
            this.lblContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.BGColor = "#1AAD19";
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.FontColor = "#ffffff";
            this.btnConfirm.Location = new System.Drawing.Point(145, 172);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(70, 28);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // lblContent
            // 
            this.lblContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblContent.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblContent.Location = new System.Drawing.Point(4, 28);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(352, 130);
            this.lblContent.TabIndex = 6;
            this.lblContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmTipBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(360, 224);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblContent);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTipBox";
            this.Text = "";
            this.ResumeLayout(false);

        }

        #endregion

        public LollipopButton btnConfirm;
        private System.Windows.Forms.Label lblContent;
    }
}