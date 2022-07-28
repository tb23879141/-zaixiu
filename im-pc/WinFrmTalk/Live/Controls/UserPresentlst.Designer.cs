namespace WinFrmTalk.Live.Controls
{
    partial class UserPresentlst
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
            this.btnRight = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnleft = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PalGiftList
            // 
            this.PalGiftList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PalGiftList.BackColor = System.Drawing.Color.Transparent;
            this.PalGiftList.Location = new System.Drawing.Point(50, 0);
            this.PalGiftList.Name = "PalGiftList";
            this.PalGiftList.Size = new System.Drawing.Size(1423, 76);
            this.PalGiftList.TabIndex = 0;
            // 
            // btnRight
            // 
            this.btnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnRight.Image = global::WinFrmTalk.Properties.Resources.Left_row;
            this.btnRight.Location = new System.Drawing.Point(4, 10);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(26, 56);
            this.btnRight.TabIndex = 2;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnleft);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(47, 74);
            this.panel1.TabIndex = 0;
            // 
            // btnleft
            // 
            this.btnleft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnleft.Image = global::WinFrmTalk.Properties.Resources.Right_row;
            this.btnleft.Location = new System.Drawing.Point(15, 10);
            this.btnleft.Name = "btnleft";
            this.btnleft.Size = new System.Drawing.Size(26, 56);
            this.btnleft.TabIndex = 1;
            this.btnleft.Click += new System.EventHandler(this.btnleft_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnRight);
            this.panel2.Location = new System.Drawing.Point(775, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(50, 73);
            this.panel2.TabIndex = 0;
            // 
            // UserPresentlst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PalGiftList);
            this.Name = "UserPresentlst";
            this.Size = new System.Drawing.Size(818, 76);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PalGiftList;
        private System.Windows.Forms.Label btnleft;
        private System.Windows.Forms.Label btnRight;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}
