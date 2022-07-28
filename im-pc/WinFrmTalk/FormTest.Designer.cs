namespace WinFrmTalk
{
    partial class FormTest
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupFuncTools1 = new WinFrmTalk.Controls.LayouotControl.Groups.GroupFuncTools();
            this.button2 = new System.Windows.Forms.Button();
            this.imageViewxFloder21 = new WinFrmTalk.Controls.ImageViewxFloder2();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "一级文件夹";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupFuncTools1
            // 
            this.groupFuncTools1.Location = new System.Drawing.Point(0, 81);
            this.groupFuncTools1.Name = "groupFuncTools1";
            this.groupFuncTools1.Size = new System.Drawing.Size(648, 36);
            this.groupFuncTools1.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(170, 453);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "二级文件夹";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // imageViewxFloder21
            // 
            this.imageViewxFloder21.FolderType = 0;
            this.imageViewxFloder21.Image = null;
            this.imageViewxFloder21.Location = new System.Drawing.Point(157, 252);
            this.imageViewxFloder21.Name = "imageViewxFloder21";
            this.imageViewxFloder21.Size = new System.Drawing.Size(100, 86);
            this.imageViewxFloder21.TabIndex = 19;
            this.imageViewxFloder21.Text = "imageViewxFloder21";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(280, 453);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "相册";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(395, 453);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 26;
            this.button4.Text = "空文件夹";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(648, 864);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.imageViewxFloder21);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupFuncTools1);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Controls.LayouotControl.Groups.GroupFuncTools groupFuncTools1;
        private System.Windows.Forms.Button button2;
        private Controls.ImageViewxFloder2 imageViewxFloder21;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}