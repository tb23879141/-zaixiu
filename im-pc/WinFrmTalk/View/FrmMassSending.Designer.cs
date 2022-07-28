namespace WinFrmTalk.View
{
    partial class FrmMassSending
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
            this.viewProgress1 = new WinFrmTalk.View.Common.ViewProgress();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // viewProgress1
            // 
            this.viewProgress1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.viewProgress1.Location = new System.Drawing.Point(88, 162);
            this.viewProgress1.Name = "viewProgress1";
            this.viewProgress1.Size = new System.Drawing.Size(290, 6);
            this.viewProgress1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(88, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "22/100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(88, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "消息群发中，请稍等。。";
            // 
            // FrmMassSending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(466, 330);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewProgress1);
            this.Name = "FrmMassSending";
            this.Text = "群发消息中";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.ViewProgress viewProgress1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}