using TestListView;

namespace WinFrmTalk.View
{
    partial class FrmHistoryMsg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHistoryMsg));
            this.historyTablePanel = new TestListView.XListView();
            this.lblTitlt = new System.Windows.Forms.Label();
            this.useSearch = new WinFrmTalk.Controls.CustomControls.UserSearch();
            this.SuspendLayout();
            // 
            // historyTablePanel
            // 
            this.historyTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historyTablePanel.BackColor = System.Drawing.Color.White;
            this.historyTablePanel.Location = new System.Drawing.Point(39, 107);
            this.historyTablePanel.Margin = new System.Windows.Forms.Padding(4);
            this.historyTablePanel.Name = "historyTablePanel";
            this.historyTablePanel.ScrollBarWidth = 10;
            this.historyTablePanel.Size = new System.Drawing.Size(488, 553);
            this.historyTablePanel.TabIndex = 9;
            // 
            // lblTitlt
            // 
            this.lblTitlt.AutoSize = true;
            this.lblTitlt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitlt.Location = new System.Drawing.Point(18, 13);
            this.lblTitlt.Name = "lblTitlt";
            this.lblTitlt.Size = new System.Drawing.Size(43, 17);
            this.lblTitlt.TabIndex = 12;
            this.lblTitlt.Text = "label1";
            this.lblTitlt.UseMnemonic = false;
            // 
            // useSearch
            // 
            this.useSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.useSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.useSearch.Location = new System.Drawing.Point(39, 58);
            this.useSearch.LoseFocusResume = true;
            this.useSearch.Name = "useSearch";
            this.useSearch.Size = new System.Drawing.Size(475, 21);
            this.useSearch.TabIndex = 15;
            this.useSearch.Load += new System.EventHandler(this.useSearch_Load);
            // 
            // FrmHistoryMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(553, 682);
            this.CloseBoxSize = new System.Drawing.Size(34, 24);
            this.CloseMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseMouseBack")));
            this.CloseNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseNormlBack")));
            this.ControlBoxOffset = new System.Drawing.Point(0, 0);
            this.Controls.Add(this.useSearch);
            this.Controls.Add(this.lblTitlt);
            this.Controls.Add(this.historyTablePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaxNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxNormlBack")));
            this.MaxSize = new System.Drawing.Size(34, 24);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(553, 682);
            this.MiniNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniNormlBack")));
            this.MiniSize = new System.Drawing.Size(34, 24);
            this.Name = "FrmHistoryMsg";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.Special = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.FrmHistoryMsg_Load);
            this.Shown += new System.EventHandler(this.FrmHistoryMsg_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmHistoryMsg_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitlt;
        private Controls.CustomControls.UserSearch useSearch;
        public XListView historyTablePanel;
    }
}