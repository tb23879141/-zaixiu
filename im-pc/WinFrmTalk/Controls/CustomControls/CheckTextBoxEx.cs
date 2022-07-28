using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class CheckTextBoxEx : UserControl
    {
        private bool _checked;
        private Font _Font = new Font("宋体", 9f);

        public bool MouseEffage { get; set; } = true;

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
        public Font LabelFont
        {
            get { return _Font; }
            set
            {
                _Font = value;
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

        public CheckTextBoxEx()
        {
            InitializeComponent();

            this.MouseClick += Item_MouseClick;
            label1.MouseClick += Item_MouseClick;
            pictureBox1.MouseClick += Item_MouseClick;


            this.MouseEnter += Item_MouseEnter;
            label1.MouseEnter += Item_MouseEnter;
            pictureBox1.MouseEnter += Item_MouseEnter;

            this.MouseLeave += Item_MouseLeave;
            label1.MouseLeave += Item_MouseLeave;
            pictureBox1.MouseLeave += Item_MouseLeave;
        }

        private void Item_MouseEnter(object sender, EventArgs e)
        {
            if (MouseEffage)
                this.BackColor = Color.FromArgb(231, 231, 231);
        }

        private void Item_MouseLeave(object sender, EventArgs e)
        {
            if (MouseEffage)
                this.BackColor = Color.Transparent;
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            Checked = !Checked;
        }

        private void CheckTextBoxEx_SizeChanged(object sender, System.EventArgs e)
        {
            pictureBox1.Location = new Point(0, (this.Height - pictureBox1.Height) / 2);
        }
    }
}
