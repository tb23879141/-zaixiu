namespace WinFrmTalk.Controls.CustomControls
{
    partial class USEUserGridItem
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
            this.tv_name = new System.Windows.Forms.Label();
            this.PicHead = new WinFrmTalk.Controls.ImageViewxRoomManager();
            ((System.ComponentModel.ISupportInitialize)(this.PicHead)).BeginInit();
            this.SuspendLayout();
            // 
            // tv_name
            // 
            this.tv_name.AutoEllipsis = true;
            this.tv_name.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_name.Location = new System.Drawing.Point(8, 70);
            this.tv_name.Name = "tv_name";
            this.tv_name.Size = new System.Drawing.Size(54, 20);
            this.tv_name.TabIndex = 1;
            this.tv_name.Text = "111111";
            this.tv_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicHead
            // 
            this.PicHead.Location = new System.Drawing.Point(8, 8);
            this.PicHead.Name = "PicHead";
            this.PicHead.Size = new System.Drawing.Size(54, 54);
            this.PicHead.TabIndex = 2;
            this.PicHead.TabStop = false;
            this.PicHead.MouseHover += new System.EventHandler(this.PicHead_MouseHover);
            // 
            // USEUserGridItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PicHead);
            this.Controls.Add(this.tv_name);
            this.Name = "USEUserGridItem";
            this.Size = new System.Drawing.Size(70, 100);
            ((System.ComponentModel.ISupportInitialize)(this.PicHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label tv_name;
        public ImageViewxRoomManager PicHead;
    }
}
