using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class CheckSexBoxEx : UserControl
    {
        private bool _checked;

        public bool Checked
        {
            get { return _checked; }
            internal set
            {
                _checked = value;
                this.BackgroundImage = value ? Resources.register_sex1 : Resources.register_sex0;
                if (value)
                {
                    btnWoMan.ForeColor = Color.White;
                    btnMan.ForeColor = Color.FromArgb(51, 51, 51);
                    this.BackgroundImage = Resources.register_sex1;
                }
                else
                {
                    btnMan.ForeColor = Color.White;
                    btnWoMan.ForeColor = Color.FromArgb(51, 51, 51);
                    this.BackgroundImage = Resources.register_sex0;
                }
            }
        }


        public CheckSexBoxEx()
        {
            InitializeComponent();

            btnWoMan.MouseClick += Woman_MouseClick;
            btnMan.MouseClick += Man_MouseClick;
            Checked = false;
        }

        private void Woman_MouseClick(object sender, MouseEventArgs e)
        {
            Checked = true;
        }

        private void Man_MouseClick(object sender, MouseEventArgs e)
        {
            Checked = false;
        }
    }
}
