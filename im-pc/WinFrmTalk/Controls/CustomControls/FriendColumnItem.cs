using System.Windows.Forms;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class FriendColumnItem : UserControl
    {
        public FriendColumnItem()
        {
            InitializeComponent();
        }


        public string FristText
        {
            set
            {
                lab_name.Text = value;
            }
        }

        internal void HideFristLine()
        {
            line.Visible = false;
        }
    }
}
