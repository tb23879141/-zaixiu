namespace WinFrmTalk.View
{
    partial class FrmRecivePhone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecivePhone));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rpboxClose = new WinFrmTalk.RoundPicBox();
            this.btnClosed = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpboxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClosed)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.rpboxClose);
            this.panel1.Location = new System.Drawing.Point(4, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 698);
            this.panel1.TabIndex = 5;
            // 
            // rpboxClose
            // 
            this.rpboxClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rpboxClose.BackColor = System.Drawing.Color.Transparent;
            this.rpboxClose.isDrawRound = true;
            this.rpboxClose.Location = new System.Drawing.Point(421, 636);
            this.rpboxClose.Name = "rpboxClose";
            this.rpboxClose.Size = new System.Drawing.Size(42, 42);
            this.rpboxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rpboxClose.TabIndex = 0;
            this.rpboxClose.TabStop = false;
            this.rpboxClose.Click += new System.EventHandler(this.rpboxClose_Click);
            // 
            // btnClosed
            // 
            this.btnClosed.BackColor = System.Drawing.Color.Transparent;
            this.btnClosed.Image = ((System.Drawing.Image)(resources.GetObject("btnClosed.Image")));
            this.btnClosed.Location = new System.Drawing.Point(0, 0);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(31, 23);
            this.btnClosed.TabIndex = 11;
            this.btnClosed.TabStop = false;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            this.btnClosed.MouseLeave += new System.EventHandler(this.btnClosed_MouseLeave);
            this.btnClosed.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnClosed_MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClosed);
            this.panel2.Location = new System.Drawing.Point(865, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 28);
            this.panel2.TabIndex = 16;
            this.panel2.MouseLeave += new System.EventHandler(this.btnClosed_MouseLeave);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnClosed_MouseMove);
            // 
            // FrmRecivePhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(900, 730);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmRecivePhone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TitleNeed = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmRecivePhone_FormClosed);
            this.Load += new System.EventHandler(this.FrmRecivePhone_Load);
            this.SizeChanged += new System.EventHandler(this.FrmRecivePhone_SizeChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rpboxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClosed)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private RoundPicBox rpboxClose;
        private System.Windows.Forms.PictureBox btnClosed;
        private System.Windows.Forms.Panel panel2;
    }
}