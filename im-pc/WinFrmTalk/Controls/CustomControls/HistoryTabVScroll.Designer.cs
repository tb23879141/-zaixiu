﻿namespace WinFrmTalk.Controls.CustomControls
{
    partial class HistoryTabVScroll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryTabVScroll));
            this.TakeScrollBar_panel = new System.Windows.Forms.Panel();
            this.TakeScrollHard_panel = new System.Windows.Forms.Panel();
            this.TakeScrollBar_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TakeScrollBar_panel
            // 
            this.TakeScrollBar_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TakeScrollBar_panel.BackgroundImage")));
            this.TakeScrollBar_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TakeScrollBar_panel.Controls.Add(this.TakeScrollHard_panel);
            this.TakeScrollBar_panel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TakeScrollBar_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.TakeScrollBar_panel.Location = new System.Drawing.Point(0, 0);
            this.TakeScrollBar_panel.Name = "TakeScrollBar_panel";
            this.TakeScrollBar_panel.Size = new System.Drawing.Size(10, 150);
            this.TakeScrollBar_panel.TabIndex = 6;
            // 
            // TakeScrollHard_panel
            // 
            this.TakeScrollHard_panel.BackColor = System.Drawing.Color.Transparent;
            this.TakeScrollHard_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TakeScrollHard_panel.BackgroundImage")));
            this.TakeScrollHard_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TakeScrollHard_panel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TakeScrollHard_panel.Location = new System.Drawing.Point(0, 3);
            this.TakeScrollHard_panel.Name = "TakeScrollHard_panel";
            this.TakeScrollHard_panel.Size = new System.Drawing.Size(9, 50);
            this.TakeScrollHard_panel.TabIndex = 3;
            // 
            // HistoryTabVScroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TakeScrollBar_panel);
            this.Name = "HistoryTabVScroll";
            this.Size = new System.Drawing.Size(10, 150);
            this.TakeScrollBar_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TakeScrollBar_panel;
        private System.Windows.Forms.Panel TakeScrollHard_panel;
    }
}
