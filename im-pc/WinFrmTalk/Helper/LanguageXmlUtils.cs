using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using WinFrmTalk.Model;

namespace WinFrmTalk
{   
    public class LanguageXmlUtils
    {
        private LanguageXmlUtils() { }

        private static string dok = ": ";
        private static readonly object locker = new object();
        private static Dictionary<string, string> xmlDicData = null;

        public static Dictionary<string, string> DataInterface()
        {
            if(xmlDicData == null)
            {
                lock (locker)
                {
                    if(xmlDicData == null)
                    {
                        string language = ConfigurationManager.AppSettings["language"];
                        LoadXmlData(language);
                    }
                }
            }
            return xmlDicData;
        }

        private static void LoadXmlData(string language)
        {
            xmlDicData = new Dictionary<string, string>();

            if (Applicate.ENABLE_MULTI_LANGUAGE)
            {
                if (language.Equals("zh-CN"))
                {
                    dok = "：";
                }
                XmlDocument xml_doc = new XmlDocument();
                string xml_path = string.Format(AppDomain.CurrentDomain.BaseDirectory + @"Language\MyLanguage-{0}.xml", language);
                if (File.Exists(xml_path))
                {
                    xml_doc.Load(xml_path);
                }
                else
                {
                    xml_doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\Language\MyLanguage-zh-CN.xml");
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
            }
        }

        public static string GetValue(string key, string txt_content, bool isAddDok = false)
        {
            try
            {
                if(!Applicate.ENABLE_MULTI_LANGUAGE)
                {
                    return txt_content;
                }

                //string value = DataInterface()[key];
                string value = Language.GetLanguage().GetValue(key);
                if (isAddDok)
                    value += dok;
                return value;
            }
            catch (Exception ex) { return txt_content; }
        }
    }
}
