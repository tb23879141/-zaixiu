using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.LayouotControl.Items
{
    public partial class GroupPhotoItem : UserControl
    {
        public string PhotoName { get; private set; }

        public string PhotoId { get; private set; }

        public List<PhotoItemInfo> PhotoList { get; private set; }

        public GroupPhotoItem()
        {
            InitializeComponent();

            imageViewxFloder1.MouseClick += Item_MouseClick;
            tvName.MouseClick += Item_MouseClick;
            tvCount.MouseClick += Item_MouseClick;

            imageViewxFloder1.MouseDown += Item_MouseDown;
            tvName.MouseDown += Item_MouseDown;
            tvCount.MouseDown += Item_MouseDown;

            imageViewxFloder1.MouseMove += Item_MouseMove;
            tvName.MouseMove += Item_MouseMove;
            tvCount.MouseMove += Item_MouseMove;

            imageViewxFloder1.MouseUp += Item_MouseUp;
            tvName.MouseUp += Item_MouseUp;
            tvCount.MouseUp += Item_MouseUp;
        }

        private void Item_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }
        private void Item_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }


        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }


        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        //internal void SetContentData(GroupFilesx data)
        //{
        //    this.PhotoName = data.title;
        //    tvName.Text = data.title;
        //    tvCount.Text = "1张";

        //    ImageLoader.Instance.Load(data.resource.tUrl).Into((bit, path) =>
        //    {
        //        imageViewxFloder1.Image = bit;
        //    });
        //}

        internal void SetContentData(PictureFloder data)
        {
            this.PhotoId = data.folderId;
            this.PhotoName = data.folderName;

            tvName.Text = data.folderName;

            toolTip1.SetToolTip(tvName, data.folderName);
            toolTip1.SetToolTip(imageViewxFloder1, data.folderName);
            if (!UIUtils.IsNull(data.groupShareList))
            {
                string cover = data.groupShareList[0].url;

                List<PhotoItemInfo> list = new List<PhotoItemInfo>();
                foreach (CollectionSave item in data.groupShareList)
                {
                    list.Add(new PhotoItemInfo()
                    {
                        emojiId = item.emojiId,
                        url = item.url,
                        time = Math.Max(item.createTime, item.time),
                        folderId = data.folderId,
                        folderName = data.folderName,
                        isPublic = data.isPublic,
                        isMemberDownload = data.isMemberDownload,
                        isWatchDownload = data.isWatchDownload,
                    });
                }

                ImageLoader.Instance.Load(cover).Into((bit, path) =>
                {
                    imageViewxFloder1.Image = bit;
                });

                tvCount.Text = data.groupShareList.Count + "张";

                PhotoList = list;
            }
            else
            {
                imageViewxFloder1.Image = null;
                tvCount.Text = "0张";
            }




        }

        internal string GetCount()
        {
            return tvCount.Text;
        }
    }

    public class PhotoItemInfo
    {
        public string emojiId { get; set; }
        public string folderId { get; set; }

        public string folderName { get; set; }

        public long time { get; set; }

        public string url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int isMemberDownload { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isPublic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isWatchDownload { get; set; }
    }

}
