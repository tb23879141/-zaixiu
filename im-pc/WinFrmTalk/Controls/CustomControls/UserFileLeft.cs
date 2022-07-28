using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class UserFileLeft : UserControl
    {
        public UserFileLeft()
        {
            InitializeComponent();
            this.lab_icon.MouseDown += UserFileLeft_MouseDown;
            this.lab_fileName.MouseDown += UserFileLeft_MouseDown;
            this.lab_fileSize.MouseDown += UserFileLeft_MouseDown;
        }

        private void FilePanel_Load(object sender, EventArgs e)
        {
            this.Size = new Size(panel_file.Width + 2, panel_file.Height + 2);
        }



        private void UserFileLeft_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }
    }
}
