namespace WinFrmTalk.View
{
    partial class FrmROOMVerify
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
            this.lblTips = new System.Windows.Forms.Label();
            this.textReson = new System.Windows.Forms.TextBox();
            this.btnSure = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTips
            // 
            this.lblTips.CausesValidation = false;
            this.lblTips.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTips.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblTips.Location = new System.Drawing.Point(54, 67);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(248, 44);
            this.lblTips.TabIndex = 0;
            this.lblTips.Text = "群主已开启“群组邀请确认”，邀请朋友进群可以想群主描述原因";
            // 
            // textReson
            // 
            this.textReson.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textReson.Location = new System.Drawing.Point(54, 125);
            this.textReson.Name = "textReson";
            this.textReson.Size = new System.Drawing.Size(244, 23);
            this.textReson.TabIndex = 1;
            // 
            // btnSure
            // 
            this.btnSure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnSure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSure.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSure.ForeColor = System.Drawing.Color.White;
            this.btnSure.Location = new System.Drawing.Point(173, 183);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(72, 23);
            this.btnSure.TabIndex = 11;
            this.btnSure.Text = "确定";
            this.btnSure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "群组验证";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(266, 183);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // FrmROOMVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(360, 225);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.textReson);
            this.Controls.Add(this.lblTips);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmROOMVerify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "群组验证";
            this.TitleNeed = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Label btnSure;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textReson;
        private System.Windows.Forms.Label btnCancel;
    }
}