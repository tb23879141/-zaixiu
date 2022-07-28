using WinFrmTalk.Controls.LayouotControl.GroupDomain;
using WinFrmTalk.Controls.LayouotControl.Items;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    /// <summary>
    /// 文件夹详情
    /// </summary>
    public partial class FrmDetailsFolder : FrmBase
    {

        public FrmDetailsFolder()
        {
            InitializeComponent();
        }

        internal void SetContentData(GroupFolderItem item, int insideType, bool saveList = false)
        {
            var data = item.itemData;
            if (UIUtils.IsNull(data.folderId))
            {
                tvCreateTime.Text = "未知";
            }
            else
            {
                tvCreateTime.Text = TimeUtils.FromatTime(data.updateTime, "yyyy/MM/dd HH:mm:ss");
            }


            tvTitle.Text = string.Format("属性/{0}", data.folderName);
            tvFolderName.Text = data.folderName;
            tvTotal.Text = string.Format("总共：{0}条", GetLevelDownCount(data));
            tvFolderCount.Text = string.Format("文件夹：{0}个", data.SubCount);

            if (saveList)
            {
                tvAllowDown.Visible = false;
                tvUnDown.Visible = false;
                label1.Visible = false;
                return;
            }

            if (insideType == 2)
            {
                // 官群
                tvAllowDown.Text = string.Format("围观可下载：{0}条", GetAllowDownCount(data, true));
                tvUnDown.Text = string.Format("围观不可下载：{0}条", GetDisDownCount(data, true));
                label1.Visible = false;
            }
            else if (insideType == 1)
            {
                // 外部群
                tvAllowDown.Text = string.Format("仅群员可下载：{0}条", GetAllowDownCount(data, false));
                tvUnDown.Text = string.Format("群员、围观可下载：{0}条", GetAllowDownCount(data, true));
                label1.Text = string.Format("群员、围观不可下载：{0}条", GetDisDownCount(data, true));
                label1.Visible = true;
            }
            else if (insideType == 0)
            {
                // 内部群
                tvAllowDown.Text = string.Format("群员可下载：{0}条", GetAllowDownCount(data, false));
                tvUnDown.Text = string.Format("群员不可下载：{0}条", GetDisDownCount(data, false));
                label1.Visible = false;
            }
        }

        public static int GetLevelDownCount(HttpFolderData data)
        {
            int count = 0;

            if (data.SubCount > 0)
            {
                foreach (var item in data.SubFolderList)
                {
                    count += item.Count;
                }
            }

            count += data.Count;
            return count;
        }

        private int GetAllowDownCount(HttpFolderData data, bool isWatch)
        {
            int count = 0;

            if (data.SubCount > 0)
            {
                foreach (var item in data.SubFolderList)
                {
                    item.type = data.type;
                    count += GetAllowDownCount(item, isWatch);
                }
            }

            if (data.Count > 0)
            {
                if (data.type == 5)
                {
                    foreach (var item in data.activityList)
                    {
                        if (item.isMemberDownload == 0 || (isWatch && item.isWatchDownload == 0))
                        {
                            count++;
                        }
                    }
                }
                else if (data.type == 4)
                {
                    foreach (var item in data.noticeList)
                    {
                        if (item.isMemberDownload == 0 || (isWatch && item.isWatchDownload == 0))
                        {
                            count++;
                        }
                    }
                }
                else
                {
                    foreach (var item in data.groupShareList)
                    {
                        if (item.isMemberDownload == 0 || (isWatch && item.isWatchDownload == 0))
                        {
                            count++;
                        }
                    }
                }
                return count;
            }

            return 0;
        }


        private int GetDisDownCount(HttpFolderData data, bool isWatch)
        {
            int count = 0;

            if (data.SubCount > 0)
            {
                foreach (var item in data.SubFolderList)
                {
                    item.type = data.type;
                    count += GetDisDownCount(item, isWatch);
                }
            }

            if (data.Count > 0)
            {
                if (data.type == 5)
                {
                    foreach (var item in data.activityList)
                    {
                        if (item.isMemberDownload == 1 || (isWatch && item.isWatchDownload == 1))
                        {
                            count++;
                        }
                    }
                }
                else if (data.type == 4)
                {
                    foreach (var item in data.noticeList)
                    {
                        if (item.isMemberDownload == 1 || (isWatch && item.isWatchDownload == 1))
                        {
                            count++;
                        }
                    }
                }
                else
                {
                    foreach (var item in data.groupShareList)
                    {
                        if (item.isMemberDownload == 1 || (isWatch && item.isWatchDownload == 1))
                        {
                            count++;
                        }
                    }
                }

                return count;
            }
            return 0;
        }



    }
}
