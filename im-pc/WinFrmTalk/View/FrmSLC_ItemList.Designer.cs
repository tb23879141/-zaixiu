namespace WinFrmTalk.View
{
    partial class SLC_ItemList
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
            this.flpSLC = new WinFrmTalk.Controls.FlowLayoutPanelBorder();
            this.SuspendLayout();
            // 
            // flpSLC
            // 
            this.flpSLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSLC.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSLC.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.flpSLC.LineDashPattern = null;
            this.flpSLC.LineDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.flpSLC.LinePenMode = 1;
            this.flpSLC.LineThick = 1;
            this.flpSLC.Location = new System.Drawing.Point(0, 0);
            this.flpSLC.Name = "flpSLC";
            this.flpSLC.Size = new System.Drawing.Size(800, 450);
            this.flpSLC.TabIndex = 0;
            // 
            // SLC_ItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flpSLC);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SLC_ItemList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmSLC_ItemList";
            this.Activated += new System.EventHandler(this.SLC_ItemList_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private WinFrmTalk.Controls.FlowLayoutPanelBorder flpSLC;
    }
}