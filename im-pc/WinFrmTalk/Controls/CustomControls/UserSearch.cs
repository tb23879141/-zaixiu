using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFrmTalk.Controls.CustomControls
{
    public delegate void SearchDeleate(string text);
    public delegate void ShowLoadDeleate();

    public partial class UserSearch : UserControl
    {

        private Color UnSelectColor = Color.FromArgb(219, 217, 216);

        /// <summary>
        /// 修改未选中时的颜色
        /// </summary>
        public void ChangeUnselectColor(Color color)
        {
            UnSelectColor = color;
            this.ResumeUi();
        }

        private Color SelectColor = Color.White;

        #region 变量
        //定义带参数的委托


        // 开始搜索，显示等待符的委托事件
        public event SearchDeleate SearchEvent;

        public event ShowLoadDeleate OnShowLoadSeach;

        public string tips;//水印提示字
        private Timer timer;//计时器

        // 失去焦点自动恢复
        public bool LoseFocusResume { set; get; }

        #endregion

        #region 初始化
        public UserSearch()
        {
            InitializeComponent();
            txt_Search.LostFocus += Txt_Search_LostFocus;//绑定文本框失去焦点事件
        }

        /// <summary>
        ///恢复到最初的颜色布局
        /// </summary>
        private void ResumeUi()
        {
            if (lbl_Search.Visible == false)
            {
                txt_Search.Text = "";
                txt_Search.Visible = false;
                lbl_Cancel.Visible = false;
                lbl_Search.Visible = true;
                this.BackColor = UnSelectColor;
                txt_Search.BackColor = UnSelectColor;
                lbl_Right.Visible = false;
                lbl_left.Visible = false;
                lbl_Top.Visible = false;
                lbl_Buttom.Visible = false;
            }
        }

        /// <summary>
        /// 初次加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserSearch_Load(object sender, EventArgs e)
        {
            lbl_Search.Text = tips;
        }
        #endregion
        #region  计时器事件
        private void Timer_Tick(object sender, EventArgs e)
        {

            OnShowLoadSeach?.Invoke();

            SearchEvent?.Invoke(txt_Search.Text);//执行搜索事件

            StopTimer(false);
        }
        #endregion
        #region 水印提示label 的点击事件
        /// <summary>
        /// 显示提示字的label，点击后文本框获取焦点，这个框的背景变为白色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void lbl_Search_Click(object sender, EventArgs e)
        {
            txt_Search.Text = "";
            if (lbl_Search.Text != tips)
            {
                txt_Search.Text = lbl_Search.Text;
                txt_Search.Visible = true;
                lbl_Search.Visible = false;
                txt_Search.Focus();
                lbl_Cancel.Visible = true;
                this.BackColor = SelectColor;
                txt_Search.BackColor = SelectColor;
                lbl_Right.Visible = true;
                lbl_left.Visible = true;
                lbl_Top.Visible = true;
                lbl_Buttom.Visible = true;
            }
            else
            {
                txt_Search.Visible = true;
                txt_Search.Focus();
                lbl_Search.Visible = false;
                lbl_Cancel.Visible = true;
                this.BackColor = SelectColor;
                txt_Search.BackColor = SelectColor;
                lbl_Right.Visible = true;
                lbl_left.Visible = true;
                lbl_Top.Visible = true;
                lbl_Buttom.Visible = true;
            }
        }
        #endregion
        /// <summary>
        /// 搜索文本框清除后背景颜色恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Search_TextChanged(object sender, EventArgs e)
        {

            if (timer == null)
            {
                InitTimer();
            }
            else
            {
                StopTimer(false);
            }

            timer.Start();
        }
        #region 搜索 图标的点击事件
        /// <summary>
        /// 点击搜索搜索图标，整个搜索框恢复，并失焦
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_Head_Click(object sender, EventArgs e)
        {
            ResumeUi();
        }
        #endregion

        #region 取消图标的点击事件
        /// <summary>
        /// 点击取消图标，整个搜索框恢复，并失焦
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_Cancel_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            ResumeUi();
            SearchEvent?.Invoke("");//执行搜索事件
            StopTimer();
        }

        /// <summary>
        /// 文本框失去焦点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Search_LostFocus(object sender, EventArgs e)
        {
            this.OnLostFocus(e);
            if (LoseFocusResume)
            {
                ResumeUi();
                SearchEvent?.Invoke("");//执行搜索事件
                StopTimer();
            }
        }

        #endregion
        #region UserSearch 大小改变事件
        /// <summary>
        /// 控件大小发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserSearch_SizeChanged(object sender, EventArgs e)
        {
            #region 改变方框四条线的大小和位置
            lbl_Buttom.Location = new Point(1, this.Size.Height - 1);
            lbl_left.Location = new Point(0, 0);
            lbl_Right.Location = new Point(this.Size.Width - 1, 0);
            lbl_Top.Location = new Point(1, 0);

            lbl_Buttom.Size = new Size(this.Size.Width - 2, 1);
            lbl_Top.Size = new Size(this.Size.Width - 2, 1);
            lbl_left.Size = new Size(1, this.Size.Height);
            lbl_Right.Size = new Size(1, this.Size.Height);
            #endregion
            #region 改变搜索图片，以及文本输入框，文本显示框的位置
            lbl_Head.Location = new Point(5, (this.Height - 15) / 2);
            lbl_Cancel.Location = new Point(lbl_Cancel.Location.X, (this.Height - 28) / 2);
            txt_Search.Location = new Point(txt_Search.Location.X, (this.Height - 18) / 2);
            //lbl_Search.Location = new Point(lbl_Search.Location.X, (this.Height - 18) / 2);
            #endregion
        }
        #endregion

        private void InitTimer()
        {
            timer = new Timer();
            timer.Interval = 300;//定时器间隔时间
            timer.Tick += Timer_Tick;

        }

        private void StopTimer(bool isDispose = true)
        {
            if (timer != null)
            {
                timer.Stop();
                if (isDispose)
                {
                    timer.Dispose();
                    timer = null;
                }
            }
        }
    }
}
