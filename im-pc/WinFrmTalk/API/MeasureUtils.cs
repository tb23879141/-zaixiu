using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFrmTalk
{
    public class MeasureUtils
    {
        private static RichTextBox richTextBox1 = null;

        static MeasureUtils()
        {
            richTextBox1 = new RichTextBox() { Size = new Size(1, 10000) };
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.WordWrap = true;
        }



        /// <summary>
        ///  测量用指定的 System.Drawing.Font 绘制的指定字符串。
        /// </summary>
        /// <param name="content"> 要测量的字符串,可能包含表情代码  [code] </param>
        /// <param name="font">System.Drawing.Font，它定义字符串的格式。</param>
        /// <param name="maxWidth">字符串的最大宽度（以像素为单位）。</param>
        /// <param name="rtf">如果content中包含表情,那么需要计算出对于的rtf</param>
        /// <returns></returns>
        public static Size MeasureString(string content, Font font, int maxWidth, string rtf = null, bool isLabel = false)
        {
            if (string.IsNullOrEmpty(content))
            {
                return new Size();
            }

            int text_width = 0, text_height = 0;
            List<int> emoji_index = new List<int>();

            richTextBox1.Width = maxWidth;
            richTextBox1.Font = font;


            if (rtf != null && rtf.Length > 0)
            {
                richTextBox1.Rtf = rtf;
                // 遍历出 content 中所有的emoji-code并转化成无表情代码的字符串 也就是 richTextBox1.text, 并和空格一一对应,emoji_index中存储了哪些空格是表情
                LoopEmojiCodeIndex(ref emoji_index, content, 0);
            }
            else
            {
                richTextBox1.Text = content;
            }

            // 获取真实显示文本的总行数
            int lineNumber = richTextBox1.GetLineFromCharIndex(richTextBox1.TextLength) + 1;
            int end = richTextBox1.TextLength;

            // 循环获取每一行的高度
            for (int i = lineNumber - 1; i > -1 && end > -1; i--)
            {
                // 计算出某一行文字相对于控件的位置,其实就是这一行文字的宽和高
                var point = richTextBox1.GetPositionFromCharIndex(end);

                // 获取某一行的第一个字符位置
                int index = richTextBox1.GetFirstCharIndexFromLine(i);

                // 判断这一行文字中是否存在表情
                bool emoji = ExistEmoji(index, end, content, emoji_index);

                // 得到这一行文字的高度 存在emoji的文本行会比普通文本行要高出7个像素
                int line_height = emoji ? point.Y + 32 : point.Y + 25;

                // 得到这一行文字的宽度 emoji如果在行尾的文本行point会忽略,导致文本行宽度丢失了一个emoji宽,需要手动补上
                int line_width = point.X + 8;

                // 得到最后一个字符
                var endchar = richTextBox1.Text[i == lineNumber - 1 ? end - 1 : end];
                if (i < lineNumber - 1 && endchar == ' ')
                {
                    // 如果是 emoji
                    emoji = ExistEmoji(end - 1, end, content, emoji_index);
                    if (emoji)
                    {
                        // 手动补上 emoji 在行尾的24个像素
                        line_width += 24;
                    }
                }

                // 从所有行里面获取最宽的一行作为整个字符的宽度
                if (line_width > text_width)
                {
                    text_width = line_width > maxWidth ? maxWidth : line_width;
                }

                if (line_height > text_height)
                {
                    text_height = line_height;
                }

                // 因为是倒序遍历,所以下一行的最后一个字符就是这一行的首字符-1
                end = index - 1;
            }

            if (isLabel)
            {
                var line_height = Convert.ToInt32(font.GetHeight(font.SizeInPoints) + 0.5f) + 1;
                text_height = line_height * lineNumber;
            }

            return new Size(text_width, text_height);
        }

        /// <summary>
        /// 计算固定高度的文字
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="font"></param>
        /// <param name="width"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        internal static Size MeasureFixedHeight(string content, Font font, int maxWidth, int lineHeight)
        {
            if (string.IsNullOrEmpty(content))
            {
                return new Size();
            }

            richTextBox1.Width = maxWidth;
            richTextBox1.Font = font;
            richTextBox1.Text = content;

            // 获取真实显示文本的总行数
            int lineNumber = richTextBox1.GetLineFromCharIndex(richTextBox1.TextLength) + 1;
            return new Size(maxWidth, Convert.ToInt32(lineNumber * (lineHeight)));
        }

        private static void LoopEmojiCodeIndex(ref List<int> data, string content, int count)
        {
            Match match = Regex.Match(content, @"\[(\w*-?\w+)\]", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                // 判断是否是emoji-code
                if (isEmoji(match.Groups[1].ToString()))
                {
                    data.Add(count + match.Index);
                    count += (match.Index + 1);
                }
                else
                {
                    count += (match.Index + match.Length);
                }

                // 把匹配到的表情从content中移除
                LoopEmojiCodeIndex(ref data, content.Substring(match.Index + match.Length), count);
            }
        }

        private static bool isEmoji(string emoji_code)
        {
            return false;
        }

        private static bool ExistEmoji(int index, int end, string content, List<int> emoji_index)
        {
            //var temp = richTextBox1.Text.ToCharArray();

            // 检测 某一段文本中是否包含emoji-code
            foreach (var item in emoji_index)
            {
                if (item >= index && item < end)
                {
                    return true;
                }
            }

            return false;
        }
    }
}