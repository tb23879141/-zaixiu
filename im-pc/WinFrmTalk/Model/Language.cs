using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace WinFrmTalk.Model
{
    public class Language
    {
        #region private member
        //private string dok = ": ";
        #endregion

        #region public member
        /// <summary>
        /// 固有名称做主键（非翻译）
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, Length = 128)]
        public string Name { get; set; }

        /// <summary>
        /// 中文（简体）
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string zh_CN { get; set; }

        /// <summary>
        /// 中文（繁体）
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string zh_HK { get; set; }

        /// <summary>
        /// 英文（美国）
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string en_US { get; set; }
        #endregion

        #region private variable
        private static Language lang = null;
        #endregion

        #region public variable
        public static List<Language> list_langs = null;
        #endregion

        #region 创建数据库表
        /// <summary>
        /// 创建数据库表
        /// </summary>
        public static bool CreateLanguageTable()
        {
            try
            {
                var result = DBSetting.SystemDBContext.Queryable<sqlite_master>().Where(s => s.Name == "Language" && s.Type == "table");
                if (result != null && result.Count() > 0)     //表存在
                {
                    return true;
                }
                //创建数据库表
                DBSetting.SystemDBContext.CodeFirst.SetStringDefaultLength(100).InitTables(typeof(Language));
                return true;
            }
            catch (Exception ex)
            {
                LogUtils.Log(ex.Message);
                return false;
            }
        }
        #endregion

        #region 从XML导入数据
        private static Dictionary<string,string> LoadXmlData(string language)
        {
            if (Applicate.ENABLE_MULTI_LANGUAGE)
            {
                Dictionary<string, string> xmlDicData = new Dictionary<string, string>();
                //if (language.Equals("zh-CN"))
                //{
                //    dok = "：";
                //}
                XmlDocument xml_doc = new XmlDocument();
                string xml_path = string.Format(AppDomain.CurrentDomain.BaseDirectory + @"Language\MyLanguage-{0}.xml", language);
                if (File.Exists(xml_path))
                {
                    xml_doc.Load(xml_path);
                }
                else
                {
                    return xmlDicData;
                }
                //获取指定节点
                XmlNode xml_node = xml_doc.SelectSingleNode("property");
                //4.获取指定节点下所有子节点
                XmlNodeList node_list = xml_node.ChildNodes;

                foreach (XmlNode item in node_list)
                {
                    if (!item.Name.Equals("string"))
                        continue;

                    foreach (XmlAttribute art in item.Attributes)
                    {
                        if (art.Name.Equals("name"))
                        {
                            xmlDicData.Add(art.Value, item.InnerText);
                        }
                    }
                }
                return xmlDicData;
            }
            return new Dictionary<string, string>();
        }

        public static int ImportDataByXML()
        {
            List<Language> list_lans = new List<Language>();
            if (CreateLanguageTable())
            {
                var xmlDicData = LoadXmlData("zh-CN");
                foreach (string key in xmlDicData.Keys)
                {
                    Language lan = list_lans.Find(f => f.Name == key);
                    if (lan == null)
                    {
                        Language item = new Language();
                        item.Name = key;
                        item.zh_CN = xmlDicData[key];
                        list_lans.Add(item);
                    }
                    else
                    {
                        lan.zh_CN = xmlDicData[key];
                    }
                }

                xmlDicData = LoadXmlData("zh-HK");
                foreach (string key in xmlDicData.Keys)
                {
                    Language lan = list_lans.Find(f => f.Name == key);
                    if (lan == null)
                    {
                        Language item = new Language();
                        item.Name = key;
                        item.zh_HK = xmlDicData[key];
                        list_lans.Add(item);
                    }
                    else
                    {
                        lan.zh_HK = xmlDicData[key];
                    }
                }

                xmlDicData = LoadXmlData("en-US");
                foreach (string key in xmlDicData.Keys)
                {
                    Language lan = list_lans.Find(f => f.Name == key);
                    if (lan == null)
                    {
                        Language item = new Language();
                        item.Name = key;
                        item.en_US = xmlDicData[key];
                        list_lans.Add(item);
                    }
                    else
                    {
                        lan.en_US = xmlDicData[key];
                    }
                }

                foreach(Language item in list_lans)
                {
                    if(string.IsNullOrEmpty(item.en_US) || string.IsNullOrEmpty(item.zh_CN) || string.IsNullOrEmpty(item.zh_HK))
                    {
                        Console.WriteLine(item.Name);
                    }
                }

                int result = DBSetting.SystemDBContext.Insertable(list_lans.ToArray()).ExecuteCommand();
                return result;
            }
            return 0;
        }
        #endregion

        public static Language GetLanguage()
        {
            if (lang == null)
                lang = new Language();
            return lang;
        }

        public string GetValue(string name)
        {
            if (list_langs == null || list_langs.Count < 1)
            {
                list_langs = DBSetting.SystemDBContext.Queryable<Language>().ToList();
            }

            var item = list_langs.Find(l => l.Name.Equals(name));
            string language = ConfigurationManager.AppSettings["language"];
            if (language.Equals("zh-CN"))
            {
                return item.zh_CN;
            }
            else if (language.Equals("zh-HK"))
            {
                return item.zh_HK;
            }
            else if (language.Equals("en-US"))
            {
                return item.en_US;
            }
            return "";
        }
    }
}
