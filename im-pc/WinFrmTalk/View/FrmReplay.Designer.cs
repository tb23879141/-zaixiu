namespace WinFrmTalk.View
{
    partial class FrmReplay
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
            this.btnadd = new System.Windows.Forms.LinkLabel();
            this.palcommonTex = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnadd
            // 
            this.btnadd.AutoSize = true;
            this.btnadd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnadd.Location = new System.Drawing.Point(259, 14);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(29, 12);
            this.btnadd.TabIndex = 0;
            this.btnadd.TabStop = true;
            this.btnadd.Text = "添加";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // palcommonTex
            // 
            this.palcommonTex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.palcommonTex.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.palcommonTex.Location = new System.Drawing.Point(0, 29);
            this.palcommonTex.Name = "palcommonTex";
            this.palcommonTex.Size = new System.Drawing.Size(302, 191);
            this.palcommonTex.TabIndex = 14;
            this.palcommonTex.WrapContents = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(8, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(44, 17);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "常用语";
            this.lblTitle.UseMnemonic = false;
            // 
            // FrmReplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(302, 234);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.palcommonTex);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Symbol", 8.25F);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(302, 234);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(302, 234);
            this.Name = "FrmReplay";
            this.Text = "";
            this.Load += new System.EventHandler(this.FrmReplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel palcommonTex;
        private System.Windows.Forms.LinkLabel btnadd;
    }
}