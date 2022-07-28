using System.Windows.Forms;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class RegisterBtnEx : Label
    {
        public bool locked = false;

        public RegisterBtnEx()
        {
            this.Image = Properties.Resources.ic_login_btn0;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MouseEnter += RegisterBtnEx_MouseEnter;
            this.MouseLeave += RegisterBtnEx_MouseLeave;
        }

        private void RegisterBtnEx_MouseLeave(object sender, System.EventArgs e)
        {
            if (!locked)
            {
                this.Image = Properties.Resources.ic_login_btn0;
            }
        }

        private void RegisterBtnEx_MouseEnter(object sender, System.EventArgs e)
        {
            if (!locked)
            {
                this.Image = Properties.Resources.ic_login_btn1;
            }
        }
    }
}
