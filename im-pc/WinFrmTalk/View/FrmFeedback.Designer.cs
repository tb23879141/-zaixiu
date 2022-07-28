namespace WinFrmTalk.View
{
    partial class FrmFeedback
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.textContent = new System.Windows.Forms.TextBox();
            this.panelEx1 = new WinFrmTalk.Controls.CustomControls.PanelEx();
            this.btnsure = new WinFrmTalk.Controls.CustomControls.RegisterBtnEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelEx2 = new WinFrmTalk.Controls.CustomControls.PanelEx();
            this.image3 = new System.Windows.Forms.Panel();
            this.image4 = new System.Windows.Forms.Panel();
            this.image2 = new System.Windows.Forms.Panel();
            this.image1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.type4 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.type3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.type2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.type1 = new System.Windows.Forms.Panel();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.type4.SuspendLayout();
            this.type3.SuspendLayout();
            this.type2.SuspendLayout();
            this.type1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblTitle.Location = new System.Drawing.Point(10, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(65, 20);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "意见反馈";
            // 
            // textContent
            // 
            this.textContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textContent.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.textContent.Location = new System.Drawing.Point(24, 16);
            this.textContent.Margin = new System.Windows.Forms.Padding(0);
            this.textContent.Multiline = true;
            this.textContent.Name = "textContent";
            this.textContent.Size = new System.Drawing.Size(396, 115);
            this.textContent.TabIndex = 10;
            this.textContent.Text = "请输入您要反馈的问题（5-200字以内）！";
            this.textContent.Enter += new System.EventHandler(this.textContent_Enter);
            this.textContent.Leave += new System.EventHandler(this.textContent_Leave);
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.White;
            this.panelEx1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panelEx1.BorderSize = 1;
            this.panelEx1.Controls.Add(this.textContent);
            this.panelEx1.Location = new System.Drawing.Point(125, 167);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(442, 150);
            this.panelEx1.TabIndex = 28;
            // 
            // btnsure
            // 
            this.btnsure.BackColor = System.Drawing.Color.Transparent;
            this.btnsure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsure.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnsure.ForeColor = System.Drawing.Color.White;
            this.btnsure.Location = new System.Drawing.Point(243, 511);
            this.btnsure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsure.Name = "btnsure";
            this.btnsure.Size = new System.Drawing.Size(150, 35);
            this.btnsure.TabIndex = 32;
            this.btnsure.Text = "确认提交";
            this.btnsure.Click += new System.EventHandler(this.btnsure_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(40, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "您有任何疑问都可以通过在秀官方邮箱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(40, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "问题类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(24)))), ((int)(((byte)(219)))));
            this.label3.Location = new System.Drawing.Point(282, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "tnshow@tnshow.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label4.Location = new System.Drawing.Point(430, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "与我们联系!";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.Location = new System.Drawing.Point(40, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "图片说明";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label6.Location = new System.Drawing.Point(40, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "详细描述";
            // 
            // panelEx2
            // 
            this.panelEx2.BackColor = System.Drawing.Color.White;
            this.panelEx2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panelEx2.BorderSize = 1;
            this.panelEx2.Controls.Add(this.image3);
            this.panelEx2.Controls.Add(this.image4);
            this.panelEx2.Controls.Add(this.image2);
            this.panelEx2.Controls.Add(this.image1);
            this.panelEx2.Location = new System.Drawing.Point(125, 339);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(442, 116);
            this.panelEx2.TabIndex = 29;
            // 
            // image3
            // 
            this.image3.BackgroundImage = global::WinFrmTalk.Properties.Resources.add_photo;
            this.image3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image3.Location = new System.Drawing.Point(204, 16);
            this.image3.Name = "image3";
            this.image3.Size = new System.Drawing.Size(80, 80);
            this.image3.TabIndex = 55;
            this.image3.Click += new System.EventHandler(this.image_Click);
            // 
            // image4
            // 
            this.image4.BackgroundImage = global::WinFrmTalk.Properties.Resources.add_photo;
            this.image4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image4.Location = new System.Drawing.Point(296, 16);
            this.image4.Name = "image4";
            this.image4.Size = new System.Drawing.Size(80, 80);
            this.image4.TabIndex = 56;
            this.image4.Click += new System.EventHandler(this.image_Click);
            // 
            // image2
            // 
            this.image2.BackgroundImage = global::WinFrmTalk.Properties.Resources.add_photo;
            this.image2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image2.Location = new System.Drawing.Point(112, 16);
            this.image2.Name = "image2";
            this.image2.Size = new System.Drawing.Size(80, 80);
            this.image2.TabIndex = 55;
            this.image2.Click += new System.EventHandler(this.image_Click);
            // 
            // image1
            // 
            this.image1.BackgroundImage = global::WinFrmTalk.Properties.Resources.add_photo;
            this.image1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.image1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image1.Location = new System.Drawing.Point(20, 16);
            this.image1.Name = "image1";
            this.image1.Size = new System.Drawing.Size(80, 80);
            this.image1.TabIndex = 54;
            this.image1.Click += new System.EventHandler(this.image_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label7.Location = new System.Drawing.Point(371, 459);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 20);
            this.label7.TabIndex = 47;
            this.label7.Text = "(选填，最多上传4张问题截图)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.label8.Location = new System.Drawing.Point(13, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 21);
            this.label8.TabIndex = 11;
            this.label8.Text = "功能异常";
            this.label8.Click += new System.EventHandler(this.type1_Click);
            // 
            // type4
            // 
            this.type4.BackgroundImage = global::WinFrmTalk.Properties.Resources.o_select;
            this.type4.Controls.Add(this.label11);
            this.type4.Location = new System.Drawing.Point(467, 106);
            this.type4.Name = "type4";
            this.type4.Size = new System.Drawing.Size(100, 36);
            this.type4.TabIndex = 50;
            this.type4.Click += new System.EventHandler(this.type4_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.label11.Location = new System.Drawing.Point(13, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 21);
            this.label11.TabIndex = 14;
            this.label11.Text = "其他问题";
            this.label11.Click += new System.EventHandler(this.type4_Click);
            // 
            // type3
            // 
            this.type3.BackgroundImage = global::WinFrmTalk.Properties.Resources.o_unselected;
            this.type3.Controls.Add(this.label10);
            this.type3.Location = new System.Drawing.Point(353, 106);
            this.type3.Name = "type3";
            this.type3.Size = new System.Drawing.Size(100, 36);
            this.type3.TabIndex = 51;
            this.type3.Click += new System.EventHandler(this.type3_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.label10.Location = new System.Drawing.Point(13, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 21);
            this.label10.TabIndex = 13;
            this.label10.Text = "新增模块";
            this.label10.Click += new System.EventHandler(this.type3_Click);
            // 
            // type2
            // 
            this.type2.BackgroundImage = global::WinFrmTalk.Properties.Resources.o_unselected;
            this.type2.Controls.Add(this.label9);
            this.type2.Location = new System.Drawing.Point(239, 106);
            this.type2.Name = "type2";
            this.type2.Size = new System.Drawing.Size(100, 36);
            this.type2.TabIndex = 52;
            this.type2.Click += new System.EventHandler(this.type2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.label9.Location = new System.Drawing.Point(13, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 12;
            this.label9.Text = "页面优化";
            this.label9.Click += new System.EventHandler(this.type2_Click);
            // 
            // type1
            // 
            this.type1.BackgroundImage = global::WinFrmTalk.Properties.Resources.o_unselected;
            this.type1.Controls.Add(this.label8);
            this.type1.Location = new System.Drawing.Point(125, 106);
            this.type1.Name = "type1";
            this.type1.Size = new System.Drawing.Size(100, 36);
            this.type1.TabIndex = 53;
            this.type1.Click += new System.EventHandler(this.type1_Click);
            // 
            // FrmFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BtnCloseImage = global::WinFrmTalk.Properties.Resources.settings_close;
            this.BtnNarrowImage = global::WinFrmTalk.Properties.Resources.min;
            this.ClientSize = new System.Drawing.Size(634, 564);
            this.CloseBoxSize = new System.Drawing.Size(0, 0);
            this.Controls.Add(this.type1);
            this.Controls.Add(this.type2);
            this.Controls.Add(this.type3);
            this.Controls.Add(this.type4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsure);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFeedback";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.FrmFeedback_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            this.type4.ResumeLayout(false);
            this.type4.PerformLayout();
            this.type3.ResumeLayout(false);
            this.type3.PerformLayout();
            this.type2.ResumeLayout(false);
            this.type2.PerformLayout();
            this.type1.ResumeLayout(false);
            this.type1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox textContent;
        private Controls.CustomControls.PanelEx panelEx1;
        private Controls.CustomControls.RegisterBtnEx btnsure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Controls.CustomControls.PanelEx panelEx2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel type4;
        private System.Windows.Forms.Panel type3;
        private System.Windows.Forms.Panel type2;
        private System.Windows.Forms.Panel type1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel image1;
        private System.Windows.Forms.Panel image2;
        private System.Windows.Forms.Panel image4;
        private System.Windows.Forms.Panel image3;
    }
}