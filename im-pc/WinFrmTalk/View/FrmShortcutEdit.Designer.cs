namespace WinFrmTalk.View
{
    partial class FrmShortcutEdit
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
            this.xListView = new TestListView.XListView();
            this.textBox = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // xListView
            // 
            this.xListView.BackColor = System.Drawing.Color.White;
            this.xListView.Location = new System.Drawing.Point(7, 31);
            this.xListView.Name = "xListView";
            this.xListView.ScrollBarWidth = 10;
            this.xListView.Size = new System.Drawing.Size(525, 339);
            this.xListView.TabIndex = 6;
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox.Location = new System.Drawing.Point(7, 376);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(439, 67);
            this.textBox.TabIndex = 7;
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(151)))), ((int)(((byte)(22)))));
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.Location = new System.Drawing.Point(452, 376);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(80, 67);
            this.btnInsert.TabIndex = 14;
            this.btnInsert.Text = "新增";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // FrmShortcutEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(539, 450);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.xListView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShortcutEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑常用语";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TestListView.XListView xListView;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button btnInsert;
    }
}