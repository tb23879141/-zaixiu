﻿namespace WinFrmTalk.Controls
{
    partial class FilePanelRight
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilePanelRight));
            this.panel_file = new System.Windows.Forms.Panel();
            this.lab_icon = new System.Windows.Forms.Label();
            this.lab_lineLime = new System.Windows.Forms.Label();
            this.lab_txt = new System.Windows.Forms.Label();
            this.lab_lineSilver = new System.Windows.Forms.Label();
            this.lab_fileSize = new System.Windows.Forms.Label();
            this.lab_fileName = new System.Windows.Forms.Label();
            this.panel_file.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_file
            // 
            this.panel_file.Controls.Add(this.lab_icon);
            this.panel_file.Controls.Add(this.lab_lineLime);
            this.panel_file.Controls.Add(this.lab_txt);
            this.panel_file.Controls.Add(this.lab_lineSilver);
            this.panel_file.Controls.Add(this.lab_fileSize);
            this.panel_file.Controls.Add(this.lab_fileName);
            this.panel_file.Location = new System.Drawing.Point(0, 0);
            this.panel_file.Name = "panel_file";
            this.panel_file.Size = new System.Drawing.Size(225, 76);
            this.panel_file.TabIndex = 14;
            // 
            // lab_icon
            // 
            this.lab_icon.Image = ((System.Drawing.Image)(resources.GetObject("lab_icon.Image")));
            this.lab_icon.Location = new System.Drawing.Point(173, 10);
            this.lab_icon.Name = "lab_icon";
            this.lab_icon.Size = new System.Drawing.Size(38, 38);
            this.lab_icon.TabIndex = 18;
            // 
            // lab_lineLime
            // 
            this.lab_lineLime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_lineLime.BackColor = System.Drawing.Color.Lime;
            this.lab_lineLime.Location = new System.Drawing.Point(13, 54);
            this.lab_lineLime.Name = "lab_lineLime";
            this.lab_lineLime.Size = new System.Drawing.Size(120, 2);
            this.lab_lineLime.TabIndex = 17;
            // 
            // lab_txt
            // 
            this.lab_txt.Font = new System.Drawing.Font(Applicate.SetFont, 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_txt.ForeColor = System.Drawing.Color.Gray;
            this.lab_txt.Location = new System.Drawing.Point(11, 58);
            this.lab_txt.Name = "lab_txt";
            this.lab_txt.Size = new System.Drawing.Size(41, 14);
            this.lab_txt.TabIndex = 0;
            this.lab_txt.Text = "文件";
            // 
            // lab_lineSilver
            // 
            this.lab_lineSilver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_lineSilver.BackColor = System.Drawing.Color.Silver;
            this.lab_lineSilver.Location = new System.Drawing.Point(13, 54);
            this.lab_lineSilver.Name = "lab_lineSilver";
            this.lab_lineSilver.Size = new System.Drawing.Size(198, 1);
            this.lab_lineSilver.TabIndex = 15;
            // 
            // lab_fileSize
            // 
            this.lab_fileSize.AutoSize = true;
            this.lab_fileSize.Font = new System.Drawing.Font(Applicate.SetFont, 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_fileSize.ForeColor = System.Drawing.Color.Gray;
            this.lab_fileSize.Location = new System.Drawing.Point(14, 32);
            this.lab_fileSize.Name = "lab_fileSize";
            this.lab_fileSize.Size = new System.Drawing.Size(59, 17);
            this.lab_fileSize.TabIndex = 14;
            this.lab_fileSize.Text = "400.0 KB";
            // 
            // lab_fileName
            // 
            this.lab_fileName.AutoSize = true;
            this.lab_fileName.Font = new System.Drawing.Font(Applicate.SetFont, 10F);
            this.lab_fileName.Location = new System.Drawing.Point(12, 9);
            this.lab_fileName.Name = "lab_fileName";
            this.lab_fileName.Size = new System.Drawing.Size(132, 20);
            this.lab_fileName.TabIndex = 13;
            this.lab_fileName.Text = "13493b27dfce.amr";
            this.lab_fileName.TextChanged += new System.EventHandler(this.lab_fileName_TextChanged);
            // 
            // FilePanelRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_file);
            this.Name = "FilePanelRight";
            this.Size = new System.Drawing.Size(227, 78);
            this.panel_file.ResumeLayout(false);
            this.panel_file.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_file;
        private System.Windows.Forms.Label lab_lineLime;
        private System.Windows.Forms.Label lab_txt;
        private System.Windows.Forms.Label lab_lineSilver;
        private System.Windows.Forms.Label lab_fileSize;
        private System.Windows.Forms.Label lab_fileName;
        private System.Windows.Forms.Label lab_icon;
    }
}
