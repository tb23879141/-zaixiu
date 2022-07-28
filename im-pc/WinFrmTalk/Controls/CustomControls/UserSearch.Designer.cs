namespace WinFrmTalk.Controls.CustomControls
{
    partial class UserSearch
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
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.lbl_Search = new System.Windows.Forms.Label();
            this.lbl_left = new System.Windows.Forms.Label();
            this.lbl_Top = new System.Windows.Forms.Label();
            this.lbl_Buttom = new System.Windows.Forms.Label();
            this.lbl_Right = new System.Windows.Forms.Label();
            this.lbl_Cancel = new System.Windows.Forms.Label();
            this.lbl_Head = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Head)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Search
            // 
            this.txt_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(217)))), ((int)(((byte)(216)))));
            this.txt_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Search.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Search.Location = new System.Drawing.Point(23, 7);
            this.txt_Search.MaxLength = 1000;
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(277, 16);
            this.txt_Search.TabIndex = 43;
            this.txt_Search.Visible = false;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // lbl_Search
            // 
            this.lbl_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Search.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Search.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Search.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_Search.Location = new System.Drawing.Point(23, 0);
            this.lbl_Search.Name = "lbl_Search";
            this.lbl_Search.Size = new System.Drawing.Size(302, 26);
            this.lbl_Search.TabIndex = 42;
            this.lbl_Search.Text = "搜索";
            this.lbl_Search.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Search.Click += new System.EventHandler(this.lbl_Search_Click);
            // 
            // lbl_left
            // 
            this.lbl_left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_left.Location = new System.Drawing.Point(0, 0);
            this.lbl_left.Name = "lbl_left";
            this.lbl_left.Size = new System.Drawing.Size(1, 28);
            this.lbl_left.TabIndex = 45;
            this.lbl_left.Visible = false;
            // 
            // lbl_Top
            // 
            this.lbl_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_Top.Location = new System.Drawing.Point(1, 0);
            this.lbl_Top.Name = "lbl_Top";
            this.lbl_Top.Size = new System.Drawing.Size(323, 1);
            this.lbl_Top.TabIndex = 46;
            this.lbl_Top.Text = "label1";
            this.lbl_Top.Visible = false;
            // 
            // lbl_Buttom
            // 
            this.lbl_Buttom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_Buttom.Location = new System.Drawing.Point(1, 27);
            this.lbl_Buttom.Name = "lbl_Buttom";
            this.lbl_Buttom.Size = new System.Drawing.Size(323, 1);
            this.lbl_Buttom.TabIndex = 47;
            this.lbl_Buttom.Text = "label1";
            this.lbl_Buttom.Visible = false;
            // 
            // lbl_Right
            // 
            this.lbl_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_Right.Location = new System.Drawing.Point(324, 0);
            this.lbl_Right.Name = "lbl_Right";
            this.lbl_Right.Size = new System.Drawing.Size(1, 28);
            this.lbl_Right.TabIndex = 48;
            this.lbl_Right.Visible = false;
            // 
            // lbl_Cancel
            // 
            this.lbl_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Cancel.Image = global::WinFrmTalk.Properties.Resources.ic_Close;
            this.lbl_Cancel.Location = new System.Drawing.Point(305, 0);
            this.lbl_Cancel.Name = "lbl_Cancel";
            this.lbl_Cancel.Size = new System.Drawing.Size(17, 28);
            this.lbl_Cancel.TabIndex = 44;
            this.lbl_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Cancel.Visible = false;
            this.lbl_Cancel.Click += new System.EventHandler(this.lbl_Cancel_Click);
            // 
            // lbl_Head
            // 
            this.lbl_Head.Image = global::WinFrmTalk.Properties.Resources.ic_Search;
            this.lbl_Head.Location = new System.Drawing.Point(5, 7);
            this.lbl_Head.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Head.Name = "lbl_Head";
            this.lbl_Head.Size = new System.Drawing.Size(15, 15);
            this.lbl_Head.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lbl_Head.TabIndex = 49;
            this.lbl_Head.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(222, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 14);
            this.textBox1.TabIndex = 50;
            // 
            // UserSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(217)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.lbl_Head);
            this.Controls.Add(this.lbl_Right);
            this.Controls.Add(this.lbl_Buttom);
            this.Controls.Add(this.lbl_Top);
            this.Controls.Add(this.lbl_left);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.lbl_Search);
            this.Controls.Add(this.lbl_Cancel);
            this.Controls.Add(this.textBox1);
            this.Name = "UserSearch";
            this.Size = new System.Drawing.Size(325, 26);
            this.Load += new System.EventHandler(this.UserSearch_Load);
            this.SizeChanged += new System.EventHandler(this.UserSearch_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Head)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Search;
        private System.Windows.Forms.Label lbl_Cancel;
        private System.Windows.Forms.Label lbl_left;
        private System.Windows.Forms.Label lbl_Top;
        private System.Windows.Forms.Label lbl_Buttom;
        private System.Windows.Forms.Label lbl_Right;
        public System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.PictureBox lbl_Head;
        private System.Windows.Forms.TextBox textBox1;
    }
}
