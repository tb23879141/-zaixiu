namespace WinFrmTalk.View
{
    partial class AddTips
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTips));
            this.txtTips = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblScacle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTips
            // 
            this.txtTips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTips.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTips.Location = new System.Drawing.Point(7, 41);
            this.txtTips.MaxLength = 5000;
            this.txtTips.Multiline = true;
            this.txtTips.Name = "txtTips";
            this.txtTips.Size = new System.Drawing.Size(508, 368);
            this.txtTips.TabIndex = 0;
            this.txtTips.TextChanged += new System.EventHandler(this.TxtTips_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(181)))), ((int)(((byte)(26)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(440, 415);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // lblScacle
            // 
            this.lblScacle.BackColor = System.Drawing.Color.Transparent;
            this.lblScacle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScacle.ForeColor = System.Drawing.Color.Gray;
            this.lblScacle.Location = new System.Drawing.Point(7, 412);
            this.lblScacle.Name = "lblScacle";
            this.lblScacle.Size = new System.Drawing.Size(100, 23);
            this.lblScacle.TabIndex = 5;
            this.lblScacle.Text = "0/500";
            this.lblScacle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddTips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(522, 453);
            this.Controls.Add(this.lblScacle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTips);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTips";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "发布公告";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox txtTips;
        private System.Windows.Forms.Label lblScacle;
    }
}