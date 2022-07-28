namespace WinFrmTalk.Live.Controls
{
    partial class UserLiveGift
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
            this.PalGiftList = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // PalGiftList
            // 
            this.PalGiftList.BackColor = System.Drawing.Color.Transparent;
            this.PalGiftList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PalGiftList.Location = new System.Drawing.Point(0, 0);
            this.PalGiftList.Name = "PalGiftList";
            this.PalGiftList.Size = new System.Drawing.Size(804, 176);
            this.PalGiftList.TabIndex = 0;
            this.PalGiftList.Paint += new System.Windows.Forms.PaintEventHandler(this.PalGiftList_Paint);
            // 
            // UserLiveGift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PalGiftList);
            this.Name = "UserLiveGift";
            this.Size = new System.Drawing.Size(804, 176);
            this.Load += new System.EventHandler(this.UserLiveGift_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PalGiftList;
    }
}
