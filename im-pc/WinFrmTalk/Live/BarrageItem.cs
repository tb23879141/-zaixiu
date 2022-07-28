using System.Windows.Forms;

namespace WinFrmTalk.Live
{
    /// <summary>
    /// 弹幕
    /// </summary>
    public struct BarrageItem
    {
        public Label textView;//文本框
        public int textColor;//文本颜色
        public string text;//文本对象
        public int textSize;//文本的大小
        public int moveSpeed;//移动速度
        public int verticalPos;//垂直方向显示的位置
        public int textMeasuredWidth;//字体显示占据的宽度
    }
}
