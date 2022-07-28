﻿namespace WinFrmTalk.Controls.LayouotControl.Items
{
    partial class CollectActiveItem
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
            this.components = new System.ComponentModel.Container();
            this.tvLength = new System.Windows.Forms.Label();
            this.skLine = new System.Windows.Forms.Label();
            this.tvMonth = new System.Windows.Forms.Label();
            this.tvDay = new System.Windows.Forms.Label();
            this.tvName = new System.Windows.Forms.Label();
            this.icRound = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.icRound)).BeginInit();
            this.SuspendLayout();
            // 
            // tvLength
            // 
            this.tvLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tvLength.AutoSize = true;
            this.tvLength.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.tvLength.Location = new System.Drawing.Point(61, 75);
            this.tvLength.Name = "tvLength";
            this.tvLength.Size = new System.Drawing.Size(32, 17);
            this.tvLength.TabIndex = 8;
            this.tvLength.Text = "付费";
            // 
            // skLine
            // 
            this.skLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.skLine.AutoEllipsis = true;
            this.skLine.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skLine.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.skLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.skLine.Location = new System.Drawing.Point(50, 0);
            this.skLine.Name = "skLine";
            this.skLine.Size = new System.Drawing.Size(1, 100);
            this.skLine.TabIndex = 10;
            // 
            // tvMonth
            // 
            this.tvMonth.AutoEllipsis = true;
            this.tvMonth.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tvMonth.Location = new System.Drawing.Point(3, 43);
            this.tvMonth.Name = "tvMonth";
            this.tvMonth.Size = new System.Drawing.Size(44, 22);
            this.tvMonth.TabIndex = 11;
            this.tvMonth.Text = "付费";
            this.tvMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tvDay
            // 
            this.tvDay.AutoEllipsis = true;
            this.tvDay.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvDay.Location = new System.Drawing.Point(0, 12);
            this.tvDay.Name = "tvDay";
            this.tvDay.Size = new System.Drawing.Size(50, 30);
            this.tvDay.TabIndex = 12;
            this.tvDay.Text = "12";
            this.tvDay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tvName
            // 
            this.tvName.AutoEllipsis = true;
            this.tvName.AutoSize = true;
            this.tvName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvName.Location = new System.Drawing.Point(60, 12);
            this.tvName.MaximumSize = new System.Drawing.Size(183, 62);
            this.tvName.MinimumSize = new System.Drawing.Size(183, 20);
            this.tvName.Name = "tvName";
            this.tvName.Size = new System.Drawing.Size(183, 62);
            this.tvName.TabIndex = 13;
            this.tvName.Text = "付费付费付费付费付费付费付费付费付付费付费付费付费付费付费付费付费费付费付费付费";
            // 
            // icRound
            // 
            this.icRound.BackColor = System.Drawing.Color.Transparent;
            this.icRound.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.icRound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.icRound.Image = global::WinFrmTalk.Properties.Resources.ic_collect_tab_round;
            this.icRound.Location = new System.Drawing.Point(47, 0);
            this.icRound.Name = "icRound";
            this.icRound.Size = new System.Drawing.Size(7, 7);
            this.icRound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icRound.TabIndex = 15;
            this.icRound.TabStop = false;
            this.icRound.Text = "付费";
            // 
            // CollectActiveItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.icRound);
            this.Controls.Add(this.tvName);
            this.Controls.Add(this.tvMonth);
            this.Controls.Add(this.skLine);
            this.Controls.Add(this.tvLength);
            this.Controls.Add(this.tvDay);
            this.Name = "CollectActiveItem";
            this.Size = new System.Drawing.Size(246, 100);
            ((System.ComponentModel.ISupportInitialize)(this.icRound)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label tvLength;
        private System.Windows.Forms.Label skLine;
        private System.Windows.Forms.Label tvMonth;
        private System.Windows.Forms.Label tvDay;
        private System.Windows.Forms.Label tvName;
        private System.Windows.Forms.PictureBox icRound;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}