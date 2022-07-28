using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.View
{
  
    public partial class FrmOfficalAccountSet : FrmSuspension
    {
        public Friend friend { get; set; }
        public FrmOfficalAccountSet()
        {
            InitializeComponent();
            this.IsClose = true;

            this.Is_DropShadow = false;
            this.Radius = 0;
            Messenger.Default.Register<Friend>(this, MessageActions.DELETE_FRIEND, (s) => { this.Close(); });
        }

        private void FrmOfficalAccountSet_Load(object sender, EventArgs e)
        {
            userOffialAccountSet1.BackColor = Color.White;
            userOffialAccountSet1.BindViewData(friend);
        }
    }
}
