using Newtonsoft.Json;
using System.Collections.Generic;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    internal class GroupNewsInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Information information { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string roomId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }

    }


    internal class GroupTopInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Information information { get; set; }
    }


    public class Information
    {
        /// <summary>
        /// 
        /// </summary>
        public string forward { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string forwardId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string shareId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int time { get; set; }

        /// <summary>
        /// 露露
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size { get; set; }

        public int isMemberDownload { get; set; }
        public int isPublic { get; set; }
        public int isWatchDownload { get; set; }

        public List<string> picPath { get; set; }
        public GroupResource resource { get; set; }

        [JsonIgnore]
        public string FindName
        {
            get
            {

                if (resource != null)
                {
                    return resource.oFileName;
                }

                return "";
            }
        }
    }



}
