using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Dictionarys
{
    internal class EmojiCodeDictionary
    {
        private static Dictionary<string, string> emojiDataNotMine;       //储存栈
        private static Dictionary<string, string> emojiDataIsMine;       //储存栈
        private static Dictionary<string, string> emojiDataRecentNotMine;       //最近消息栏储存栈
        private static Dictionary<string, string> emojiDataRecentIsMine;    //最近消息栏储存栈
        private static Dictionary<string, string> emojiDataRecentNotMineTop;    //置顶未选中栏储存栈
        private static Dictionary<string, string> emojiDataRecentIsMineTop;    //置顶选中储存栈

        private static readonly object looker = new object();       //确保线程的同步，同一时间不能同时访问

        //防止外部创建实例
        private EmojiCodeDictionary() { }

        //public static string GetEmojiCode(string emoji_rtf)
        //{
        //    GetEmojiCodeDataDictionary();
        //    if (emojiDataNotMine.ContainsKey(emoji_rtf))
        //        return emojiDataNotMine[emoji_rtf];
        //    else
        //        return "";
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emojiCode"></param>
        /// <param name="isMine">是否是自己发言</param>
        /// <param name="isRecent">是否是消息栏表情</param>
        /// <param name="isRecentMine">消息栏是否选中</param>
        /// <returns></returns>
        public static string GetEmojiRtfByCode(string emojiCode, bool isMine = false, bool isRecent = false, RecentSelectType isRecentMine = 0)
        {
            if (string.IsNullOrEmpty(emojiCode))
                return "";
            //去除中括号
            emojiCode = emojiCode.Replace("[", "").Replace("]", "");
            //初始化字典
            GetEmojiDataNotMine();
            GetEmojiDataIsMine();

            string emojiRtf = "";
            if (isRecent)//是否是显示在最近消息栏
            {
                switch (isRecentMine)
                {
                    case RecentSelectType.NotMine://未选中
                        if (emojiDataRecentNotMine.ContainsKey(emojiCode))
                        {
                            emojiRtf = emojiDataRecentNotMine[emojiCode];
                            if (string.IsNullOrEmpty(emojiRtf))
                            {
                                string path = Applicate.LocalConfigData.EmojiFolderPath + emojiCode + ".png";
                                //添加白色底色的emoji
                                emojiRtf = GetRtfByImgPath(path, Color.FromArgb(230, 229, 229));
                                //添加到字典
                                emojiDataRecentNotMine[emojiCode] = emojiRtf;
                            }
                        }

                        break;
                    case RecentSelectType.IsMine://选中
                        if (emojiDataRecentIsMine.ContainsKey(emojiCode))
                        {
                            emojiRtf = emojiDataRecentIsMine[emojiCode];
                            if (string.IsNullOrEmpty(emojiRtf))
                            {
                                string path = Applicate.LocalConfigData.EmojiFolderPath + emojiCode + ".png";
                                //添加白色底色的emoji
                                emojiRtf = GetRtfByImgPath(path, Color.FromArgb(216, 216, 217));
                                //添加到字典
                                emojiDataRecentIsMine[emojiCode] = emojiRtf;
                            }
                        }
                        break;
                    case RecentSelectType.NotMineTop://置顶未选中
                        if (emojiDataRecentNotMineTop.ContainsKey(emojiCode))
                        {
                            emojiRtf = emojiDataRecentNotMineTop[emojiCode];
                            if (string.IsNullOrEmpty(emojiRtf))
                            {
                                string path = Applicate.LocalConfigData.EmojiFolderPath + emojiCode + ".png";
                                //添加白色底色的emoji
                                emojiRtf = GetRtfByImgPath(path, Color.FromArgb(220, 220, 220));
                                //添加到字典
                                emojiDataRecentNotMineTop[emojiCode] = emojiRtf;
                            }
                        }
                        break;
                    case RecentSelectType.IsMineTop://置顶选中
                        if (emojiDataRecentIsMineTop.ContainsKey(emojiCode))
                        {
                            emojiRtf = emojiDataRecentIsMineTop[emojiCode];
                            if (string.IsNullOrEmpty(emojiRtf))
                            {
                                string path = Applicate.LocalConfigData.EmojiFolderPath + emojiCode + ".png";
                                //添加白色底色的emoji
                                emojiRtf = GetRtfByImgPath(path, Color.FromArgb(202, 200, 198));
                                //添加到字典
                                emojiDataRecentIsMineTop[emojiCode] = emojiRtf;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (isMine)
                {
                    if (emojiDataIsMine.ContainsKey(emojiCode))
                    {
                        emojiRtf = emojiDataIsMine[emojiCode];
                        if (string.IsNullOrEmpty(emojiRtf))
                        {
                            string path = Applicate.LocalConfigData.EmojiFolderPath + emojiCode + ".png";
                            //添加白色底色的emoji
                            emojiRtf = GetRtfByImgPath(path, Color.FromArgb(139, 233, 219));
                            //添加到字典
                            emojiDataIsMine[emojiCode] = emojiRtf;
                        }
                    }
                }
                else
                {
                    if (emojiDataNotMine.ContainsKey(emojiCode))
                    {
                        emojiRtf = emojiDataNotMine[emojiCode];
                        if (string.IsNullOrEmpty(emojiRtf))
                        {
                            string path = Applicate.LocalConfigData.EmojiFolderPath + emojiCode + ".png";
                            //添加白色底色的emoji
                            emojiRtf = GetRtfByImgPath(path, Color.White);
                            //添加到字典
                            emojiDataNotMine[emojiCode] = emojiRtf;
                        }
                    }
                }
            }
            return emojiRtf;
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetEmojiDataNotMine()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (emojiDataNotMine == null)
            {
                lock (looker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (emojiDataNotMine == null)
                    {
                        emojiDataNotMine = new Dictionary<string, string>();
                    }
                }
            }
            if (emojiDataNotMine.Count < 1)
                AddEmojiData();
            return emojiDataNotMine;
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetEmojiDataIsMine()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (emojiDataIsMine == null)
            {
                lock (looker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (emojiDataIsMine == null)
                    {
                        emojiDataIsMine = new Dictionary<string, string>();
                    }
                }
            }
            if (emojiDataIsMine.Count < 1)
                AddEmojiData();
            return emojiDataIsMine;
        }

        private static void AddEmojiData()
        {
            //emojiDataNotMine = new Dictionary<string, string>();
            //emojiDataIsMine = new Dictionary<string, string>();
            emojiDataNotMine = new EmojiData() { isMine = 0 }.GetEmojiDataByIsMin().ToDictionary(emoji => emoji.emojiCode.Remove(emoji.emojiCode.LastIndexOf("_")), emoji => emoji.emojiRtf);
            emojiDataIsMine = new EmojiData() { isMine = 1 }.GetEmojiDataByIsMin().ToDictionary(emoji => emoji.emojiCode.Remove(emoji.emojiCode.LastIndexOf("_")), emoji => emoji.emojiRtf);
            emojiDataRecentNotMine = new EmojiData() { isMine = 2 }.GetEmojiDataByIsMin().ToDictionary(emoji => emoji.emojiCode.Remove(emoji.emojiCode.LastIndexOf("_")), emoji => emoji.emojiRtf);
            emojiDataRecentIsMine = new EmojiData() { isMine = 3 }.GetEmojiDataByIsMin().ToDictionary(emoji => emoji.emojiCode.Remove(emoji.emojiCode.LastIndexOf("_")), emoji => emoji.emojiRtf);
            emojiDataRecentNotMineTop = new EmojiData() { isMine = 4 }.GetEmojiDataByIsMin().ToDictionary(emoji => emoji.emojiCode.Remove(emoji.emojiCode.LastIndexOf("_")), emoji => emoji.emojiRtf);
            emojiDataRecentIsMineTop = new EmojiData() { isMine = 5 }.GetEmojiDataByIsMin().ToDictionary(emoji => emoji.emojiCode.Remove(emoji.emojiCode.LastIndexOf("_")), emoji => emoji.emojiRtf);
            //emojiDataNotMine = new EmojiData().ListToDictionary(new EmojiData() { isMine = 0 }.GetEmojiDataByIsMin());
            //emojiDataIsMine = new EmojiData().ListToDictionary(new EmojiData() { isMine = 1 }.GetEmojiDataByIsMin());

            //获取所有emoji表情路径
            string[] emojiPaths = Directory.GetFiles(Applicate.LocalConfigData.EmojiFolderPath, "*.png");

            foreach (string path in emojiPaths)
            {
                //获得emojiCode
                string emojiCode = FileUtils.GetFileName(path).Replace(".png", "");
                //如果已经存在则不需要添加到数据库
                if (emojiDataIsMine.ContainsKey(emojiCode) && emojiDataNotMine.ContainsKey(emojiCode))
                    continue;

                if (!emojiDataNotMine.ContainsKey(emojiCode))
                {
                    //添加白色底色的emoji
                    string emojiRtf = GetRtfByImgPath(path, Color.White);
                    //添加到字典
                    emojiDataNotMine.Add(emojiCode, emojiRtf);
                    //插入到数据库
                    new EmojiData() { emojiCode = emojiCode + "_0", emojiRtf = emojiRtf, isMine = 0 }.InsertEmojiData();
                }

                if (!emojiDataIsMine.ContainsKey(emojiCode))
                {
                    //添加绿色底色的emoji
                    string emojiRtf = GetRtfByImgPath(path, Color.FromArgb(139, 233, 219));
                    //添加到字典
                    emojiDataIsMine.Add(emojiCode, emojiRtf);
                    //插入到数据库
                    new EmojiData() { emojiCode = emojiCode + "_1", emojiRtf = emojiRtf, isMine = 1 }.InsertEmojiData();
                }

                if (!emojiDataRecentNotMine.ContainsKey(emojiCode))
                {
                    //添加浅灰色底色的emoji
                    string emojiRtf = GetRtfByImgPath(path, Color.FromArgb(230, 229, 229));
                    //添加到字典
                    emojiDataRecentNotMine.Add(emojiCode, emojiRtf);
                    //插入到数据库
                    new EmojiData() { emojiCode = emojiCode + "_2", emojiRtf = emojiRtf, isMine = 2 }.InsertEmojiData();
                }

                if (!emojiDataRecentIsMine.ContainsKey(emojiCode))
                {
                    //添加灰色底色的emoji
                    string emojiRtf = GetRtfByImgPath(path, Color.FromArgb(216, 216, 217));
                    //添加到字典
                    emojiDataRecentIsMine.Add(emojiCode, emojiRtf);
                    //插入到数据库
                    new EmojiData() { emojiCode = emojiCode + "_3", emojiRtf = emojiRtf, isMine = 3 }.InsertEmojiData();
                }
                if (!emojiDataRecentNotMineTop.ContainsKey(emojiCode))
                {
                    //添加灰色底色的emoji
                    string emojiRtf = GetRtfByImgPath(path, Color.FromArgb(220, 220, 220));
                    //添加到字典
                    emojiDataRecentNotMineTop.Add(emojiCode, emojiRtf);
                    //插入到数据库
                    new EmojiData() { emojiCode = emojiCode + "_4", emojiRtf = emojiRtf, isMine = 4 }.InsertEmojiData();
                }
                if (!emojiDataRecentIsMineTop.ContainsKey(emojiCode))
                {
                    //添加灰色底色的emoji
                    string emojiRtf = GetRtfByImgPath(path, Color.FromArgb(202, 200, 198));
                    //添加到字典
                    emojiDataRecentIsMineTop.Add(emojiCode, emojiRtf);
                    //插入到数据库
                    new EmojiData() { emojiCode = emojiCode + "_5", emojiRtf = emojiRtf, isMine = 5 }.InsertEmojiData();
                }
            }
        }

        private static string subRtf(string emoji_rtf)
        {
            //rtf1–> RTF版本
            //ansi–> 字符集
            //ansicpg936–> 简体中文
            //deff0–> 默认字体0
            //deflang1033–> 美国英语
            //deflangfe2052–> 中国汉语
            //fonttb–> 字体列表
            //f0->字体0
            //fcharset134->GB2312国标码
            //‘cb\’ce\’cc\’e5–> 宋体
            int startIndex = emoji_rtf.IndexOf("\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs18") + "\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs18".Length;
            emoji_rtf = emoji_rtf.Substring(startIndex);
            int endIndex = emoji_rtf.IndexOf("\\par");
            emoji_rtf = emoji_rtf.Substring(0, endIndex);
            return emoji_rtf;
        }

        private static string GetRtfByImgPath(string path, Color color)
        {
            using (RichTextBox richTextBox = new RichTextBox())
            {
                //清空剪切板，防止里面之前有内容
                //Clipboard.Clear();
                Bitmap bmp = new Bitmap(path);
                Bitmap newBmp = new Bitmap(20, 20);
                Graphics g = Graphics.FromImage(newBmp);
                g.Clear(color);

                g.DrawImage(bmp, new Rectangle(0, 0, 20, 20), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                Clipboard.SetDataObject(newBmp, false);
                //将图片粘贴到鼠标焦点位置(选中的字符都会被图片覆盖)
                richTextBox.Paste();
                //Clipboard.Clear();

                //获取emoji的rtf
                string emojiRtf = subRtf(richTextBox.Rtf);
                return emojiRtf;
            }
        }
    }
}
