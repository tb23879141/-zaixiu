using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WinFrmTalk
{
    /// <summary>
    /// 正则表达式工具类
    /// </summary>
    public class REUtils
    {
        /// <summary>
        /// 中国电话号码
        /// </summary>
        public const string CH_Phone = @"1[3-8].[\d]{9}";

        /// <summary>
        /// 全球的电话（包括短号，座机和手机号码）
        /// </summary>
        public const string Global_Phone = @"\d{3,15}";

        /// <summary>
        /// Emoji表情的格式
        /// </summary>
        public const string Emoji_Format = @"\[[a-z_-]*\]";

        /// <summary>
        /// 超链接
        /// </summary>
        public const string Internet_URL = @"^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$";
        public const string Easy_URL = @"[a-zA-z]+://[^\s]*";


        /// <summary>
        /// 正则方式验证字符串（匹配单个结果）
        /// </summary>
        /// <param name="str">被验证的字符串</param>
        /// <param name="regexStr">正则规则</param>
        /// <param name="value">抛出返回值</param>
        /// <returns></returns>
        public static bool MatchRE(string content, string regexStr, out string value)
        {
            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(regexStr))
            {
                value = "";
                return false;
            }
            Regex reg = new Regex(regexStr);
            Match match = reg.Match(content);
            value = match.Value;
            return match.Success;
        }

        /// <summary>
        /// 正则方式验证字符串（匹配多个结果）
        /// </summary>
        /// <param name="str">被验证的字符串</param>
        /// <param name="regexStr">正则规则</param>
        /// <param name="values">抛出返回值</param>
        /// <returns></returns>
        public static bool MatchCollectionRE(string content, string regexStr, out List<string> values)
        {
            values = new List<string>();
            MatchCollection result = Regex.Matches(content, regexStr, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if(result.Count < 1)
            {
                return false;
            }
            foreach(Match match in result)
            {
                values.Add(match.Value);
            }
            return true;
        } 
        
        
        
        
        /// <summary>
        /// 正则方式验证字符串（匹配多个结果）
        /// </summary>
        /// <param name="str">被验证的字符串</param>
        /// <param name="regexStr">正则规则</param>
        /// <param name="values">抛出返回值</param>
        /// <returns></returns>
        public static string MatchStrUrl(string content)
        {
            Regex reg = new Regex(@"(?imn)(?<do>http://[^/]+/)(?<dir>([^/]+/)*([^/.]*$)?)((?<page>[^?.]+\.[^?]+)\?)?(?<par>.*$)");
            MatchCollection mc = reg.Matches(content);
            foreach (Match m in mc)
            {
                Console.WriteLine(m.Groups["do"].Value);  //http://www.rczjp.cn/
                Console.WriteLine(m.Groups["dir"].Value); //A/B/C/
                Console.WriteLine(m.Groups["page"].Value);  //index.aspx
                Console.WriteLine(m.Groups["par"].Value); //cid=11&sid=22

                if (!UIUtils.IsNull(m.Groups["do"].Value))
                {
                    return m.Groups["do"].Value;
                }
            }

            return "";
        }

        public static bool isInternetURL(string content)
        {
            string result = "";
            bool isHave = MatchRE(content, Internet_URL, out result);
            if (!isHave)
            {
                isHave = MatchRE(content, Easy_URL, out result);
            }
            return isHave;
        }
    }
}
