using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls
{
    public partial class CheckTextBoxEx2 : UserControl
    {
        public bool _checked;

        public bool Checked
        {
            get { return _checked; }
            internal set
            {
                _checked = value;
                pictureBox1.Image = value ? Resources.login_check1 : Resources.login_check0;
            }
        }


        [Browsable(true)]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                label1.Font = value;
            }
        }

        [Browsable(true)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                label1.ForeColor = value;
            }
        }

        private string labelText;

        [Browsable(true)]
        public string LabelText
        {
            get { return labelText; }
            set { labelText = value; label1.Text = labelText; }
        }

        public CheckTextBoxEx2()
        {
            InitializeComponent();

            this.MouseClick += Item_MouseClick;
            label1.MouseClick += Item_MouseClick;
            //   pictureBox1.MouseClick += Item_MouseClick;
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            Checked = !Checked;
        }
    }
}
