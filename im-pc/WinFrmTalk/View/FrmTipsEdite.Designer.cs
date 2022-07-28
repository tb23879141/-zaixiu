namespace WinFrmTalk.View
{
    partial class FrmTipsEdite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTipsEdite));
            this.btnsure = new System.Windows.Forms.Button();
            this.lblScacle = new System.Windows.Forms.Label();
            this.textEdite = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnsure
            // 
            this.btnsure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(181)))), ((int)(((byte)(26)))));
            this.btnsure.FlatAppearance.BorderSize = 0;
            this.btnsure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsure.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnsure.ForeColor = System.Drawing.Color.White;
            this.btnsure.Location = new System.Drawing.Point(440, 415);
            this.btnsure.Name = "btnsure";
            this.btnsure.Size = new System.Drawing.Size(75, 23);
            this.btnsure.TabIndex = 17;
            this.btnsure.Text = "确定";
            this.btnsure.UseVisualStyleBackColor = false;
            this.btnsure.Click += new System.EventHandler(this.btnsure_Click);
            // 
            // lblScacle
            // 
            this.lblScacle.BackColor = System.Drawing.Color.Transparent;
            this.lblScacle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScacle.ForeColor = System.Drawing.Color.Gray;
            this.lblScacle.Location = new System.Drawing.Point(6, 411);
            this.lblScacle.Name = "lblScacle";
            this.lblScacle.Size = new System.Drawing.Size(100, 23);
            this.lblScacle.TabIndex = 18;
            this.lblScacle.Text = "0/500";
            this.lblScacle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textEdite
            // 
            this.textEdite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEdite.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textEdite.Location = new System.Drawing.Point(7, 42);
            this.textEdite.MaxLength = 5000;
            this.textEdite.Multiline = true;
            this.textEdite.Name = "textEdite";
            this.textEdite.Size = new System.Drawing.Size(508, 368);
            this.textEdite.TabIndex = 21;
            this.textEdite.TextChanged += new System.EventHandler(this.TxtTips_TextChanged);
            // 
            // FrmTipsEdite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(522, 453);
            this.Controls.Add(this.textEdite);
            this.Controls.Add(this.lblScacle);
            this.Controls.Add(this.btnsure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTipsEdite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnsure;
        private System.Windows.Forms.Label lblScacle;
        public System.Windows.Forms.TextBox textEdite;
    }
}