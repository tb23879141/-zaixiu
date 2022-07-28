namespace WinFrmTalk.Live.Controls
{
    partial class UserGiftItem
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
            this.lab_money = new System.Windows.Forms.Label();
            this.pic_gift = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_gift)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_money
            // 
            this.lab_money.AutoEllipsis = true;
            this.lab_money.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_money.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lab_money.Location = new System.Drawing.Point(0, 39);
            this.lab_money.Name = "lab_money";
            this.lab_money.Size = new System.Drawing.Size(56, 12);
            this.lab_money.TabIndex = 1;
            this.lab_money.Text = "10";
            this.lab_money.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_money.Click += new System.EventHandler(this.Parent_Click);
            // 
            // pic_gift
            // 
            this.pic_gift.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_gift.Location = new System.Drawing.Point(11, 5);
            this.pic_gift.Name = "pic_gift";
            this.pic_gift.Size = new System.Drawing.Size(35, 35);
            this.pic_gift.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_gift.TabIndex = 0;
            this.pic_gift.TabStop = false;
            this.pic_gift.Click += new System.EventHandler(this.Parent_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 56);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label2.Location = new System.Drawing.Point(1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 1);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label3.Location = new System.Drawing.Point(55, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1, 56);
            this.label3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label4.Location = new System.Drawing.Point(2, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 1);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            // 
            // UserGiftItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lab_money);
            this.Controls.Add(this.pic_gift);
            this.Name = "UserGiftItem";
            this.Size = new System.Drawing.Size(56, 56);
            ((System.ComponentModel.ISupportInitialize)(this.pic_gift)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.PictureBox pic_gift;
        public System.Windows.Forms.Label lab_money;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
