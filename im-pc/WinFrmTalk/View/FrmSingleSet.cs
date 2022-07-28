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
    public partial class FrmSingleSet : FrmSuspension
    {
        public Friend friend { get; set; }

        public FrmSingleSet()
        {
            InitializeComponent();
      
            this.IsClose = true;

            this.Is_DropShadow = false;
            this.Radius = 0;
            Messenger.Default.Register<Friend>(this, MessageActions.DELETE_FRIEND, (s) => { this.Close();});
        }

       
        private void FrmSingleSet_Load(object sender, EventArgs e)
        {
            useSingleSet1.BackColor = Color.White;
            useSingleSet1.BindViewData(friend);
        }
    }
}
