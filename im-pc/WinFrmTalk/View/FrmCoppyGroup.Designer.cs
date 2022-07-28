namespace WinFrmTalk.View
{
    partial class FrmCoppyGroup
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
            this.picGroup = new System.Windows.Forms.PictureBox();
            this.lbl_GroupName = new System.Windows.Forms.Label();
            this.lblNumbers = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnsure = new LollipopButton();
            ((System.ComponentModel.ISupportInitialize)(this.picGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // picGroup
            // 
            this.picGroup.Location = new System.Drawing.Point(121, 31);
            this.picGroup.Name = "picGroup";
            this.picGroup.Size = new System.Drawing.Size(60, 60);
            this.picGroup.TabIndex = 6;
            this.picGroup.TabStop = false;
            // 
            // lbl_GroupName
            // 
            this.lbl_GroupName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_GroupName.Location = new System.Drawing.Point(7, 100);
            this.lbl_GroupName.Name = "lbl_GroupName";
            this.lbl_GroupName.Size = new System.Drawing.Size(280, 23);
            this.lbl_GroupName.TabIndex = 7;
            this.lbl_GroupName.Text = "label1";
            this.lbl_GroupName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumbers
            // 
            this.lblNumbers.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNumbers.Location = new System.Drawing.Point(7, 132);
            this.lblNumbers.Name = "lblNumbers";
            this.lblNumbers.Size = new System.Drawing.Size(280, 23);
            this.lblNumbers.TabIndex = 8;
            this.lblNumbers.Text = "label1";
            this.lblNumbers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "温馨提示：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(314, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "1.一键复制新群后，将生成一个群成员相同的群；";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(7, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "2.生成的新群，群成员在老群中的设置无法复制。";
            // 
            // btnsure
            // 
            this.btnsure.BackColor = System.Drawing.Color.Transparent;
            this.btnsure.BGColor = "26,181,26";
            this.btnsure.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnsure.FontColor = "#ffffff";
            this.btnsure.Location = new System.Drawing.Point(80, 285);
            this.btnsure.Name = "btnsure";
            this.btnsure.Size = new System.Drawing.Size(168, 38);
            this.btnsure.TabIndex = 12;
            this.btnsure.Text = "确定复制";
            this.btnsure.Click += new System.EventHandler(this.btnsure_Click);
            // 
            // FrmCoppyGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(325, 349);
            this.Controls.Add(this.btnsure);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNumbers);
            this.Controls.Add(this.lbl_GroupName);
            this.Controls.Add(this.picGroup);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCoppyGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.picGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGroup;
        private System.Windows.Forms.Label lbl_GroupName;
        private System.Windows.Forms.Label lblNumbers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private LollipopButton btnsure;
    }
}