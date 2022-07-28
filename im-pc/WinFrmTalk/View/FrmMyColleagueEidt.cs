using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFrmTalk
{
    public partial class FrmMyColleagueEidt : FrmBase
    {
        private Action<string> ColleagueCallback;

        private string _nameEdit;
        public string NameEdit
        {
            get { return _nameEdit; }
            set
            {
                _nameEdit = value;
                if (!string.IsNullOrEmpty(NameEdit))
                {
                    txtName.Text = NameEdit;
                }
            }
        }

        public int maxLength = -1;

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            this.Text = LanguageXmlUtils.GetValue("frmMyColleagueEidt_title", this.Text);
            lblName.Text = LanguageXmlUtils.GetValue("frmMyColleagueEidt_name", lblName.Text, true);
            btnConfirm.Text = LanguageXmlUtils.GetValue("btn_ok", btnConfirm.Text);
        }

        public FrmMyColleagueEidt()
        {
            InitializeComponent();
            this.Stacked = false;
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
        }

        internal void ColleagueName(Action<string> p)
        {
            ColleagueCallback = p;
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {

            string input = txtName.Text.TrimStart().Trim();

            if (UIUtils.IsNull(input))
            {
                ShowTip("不能只输入空格");
                return;
            }

            if (maxLength > 0 && maxLength < input.Length)
            {
                ShowTip("字数超过限制");
                return;


            }

            if (!input.Equals(NameEdit))
            {
                ColleagueCallback?.Invoke(txtName.Text);
                ColleagueCallback = null; // 防止重复点击 2019-11-20
            }
            else
            {
                MessageBox.Show(LanguageXmlUtils.GetValue("frmMyColleagueEidt_tips", "未修改过"));
            }

        }

        private void FrmMyColleagueEidt_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NameEdit))
            {
                txtName.Text = NameEdit;
            }
        }
        /// <summary>
        /// 传递参数修改界面UI
        /// </summary>
        /// <param name="title">窗体标题</param>
        /// <param name="Name">文本框名称</param>
        public void ShowThis(string title, string Name, bool isshow = true)
        {
            this.Text = title;
            lblName.Text = Name;
            var parent = Applicate.GetWindow<FrmMain>();
            this.Location = new Point(parent.Location.X + (parent.Width - this.Width) / 2, parent.Location.Y + (parent.Height - this.Height) / 2);//居中
            if (!isshow)
            {
                ShowDialog();
            }
            else
            {
                this.Show();
            }

        }

        public void ShowThis(string title, string Name, string defValue)
        {
            this.Text = title;
            lblName.Text = Name;
            txtName.Text = defValue;
            this.Show();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtName.Text.Length <= 0)
            { //空格不能在第一位
                if ((int)e.KeyChar == 32)
                {
                    e.Handled = true;
                }
            }
            if (e.KeyChar == '\r')
            {
                btnConfirm_Click(sender, e);
            }
        }
    }
}
