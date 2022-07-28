using TestListView;

namespace WinFrmTalk.View
{
    partial class FrmMoreMember
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
            this.palGroupMenber = new TestListView.XListView();
            this.palLoading = new System.Windows.Forms.Panel();
            this.useSearch = new WinFrmTalk.Controls.CustomControls.UserSearch();
            this.SuspendLayout();
            // 
            // palGroupMenber
            // 
            this.palGroupMenber.BackColor = System.Drawing.Color.White;
            this.palGroupMenber.Location = new System.Drawing.Point(3, 65);
            this.palGroupMenber.Name = "palGroupMenber";
            this.palGroupMenber.ScrollBarWidth = 10;
            this.palGroupMenber.Size = new System.Drawing.Size(300, 465);
            this.palGroupMenber.TabIndex = 1;
            this.palGroupMenber.Load += new System.EventHandler(this.palGroupMenber_Load);
            // 
            // palLoading
            // 
            this.palLoading.Location = new System.Drawing.Point(3, 65);
            this.palLoading.Name = "palLoading";
            this.palLoading.Size = new System.Drawing.Size(300, 80);
            this.palLoading.TabIndex = 8;
            this.palLoading.Visible = false;
            // 
            // useSearch
            // 
            this.useSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(217)))), ((int)(((byte)(216)))));
            this.useSearch.Location = new System.Drawing.Point(9, 25);
            this.useSearch.LoseFocusResume = true;
            this.useSearch.Name = "useSearch";
            this.useSearch.Size = new System.Drawing.Size(288, 28);
            this.useSearch.TabIndex = 14;
            // 
            // FrmMoreMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(304, 561);
            this.Controls.Add(this.useSearch);
            this.Controls.Add(this.palLoading);
            this.Controls.Add(this.palGroupMenber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MdiBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmMoreMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "群成员";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMoreMember_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion
        private XListView palGroupMenber;
        private System.Windows.Forms.Panel palLoading;
        private Controls.CustomControls.UserSearch useSearch;
    }
}