using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;


namespace WinFrmTalk.View.list
{
    public class GroupCollectionAdapter : IBaseAdapter
    {
        List<Collections> mDatas = new List<Collections>();
        private GroupCollection GroupCollection;
        public void SetMaengForm(GroupCollection collection)
        {
            this.GroupCollection = collection;
        }
        public override int GetItemCount()
        {
            return mDatas.Count;
        }


        public override Control OnCreateControl(int index)
        {
            UserCollectionItem item = new UserCollectionItem();
            item.Size = new Size(GroupCollection.cc.Width, OnMeasureHeight(index));
            item.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            Collections collect = mDatas[index];
            //item.Collections = collect;
            item.FillCollectData(collect);
            item.OnClickCollectItem += GroupCollection.OnClickCollectionItem;
            item.OnClickCollectImage += GroupCollection.OnClickCollectionImage;
            //item.MouseDoubleClick
            item.ContextMenuStrip = GroupCollection.cmsCollection;
            return item;
        }


        public override int OnMeasureHeight(int index)
        {
            Collections collect = mDatas[index];
            int height = 100;
            switch (collect.type)
            {
                case "1":
                    if (!UIUtils.IsNull(collect.collectContent))
                    {
                        // 单文字25 + 图片100
                        height = 125;
                    }
                    break;
                case "5":
                    height = 80;
                    break;
            }
            return height;
        }

        public override void RemoveData(int index)
        {
            mDatas.RemoveAt(index);
        }

        /// <summary>
        /// bangd
        /// </summary>
        /// <param name="data"></param>
        public void BindDatas(List<Collections> data)
        {
            mDatas = data;
        }

        internal int GetMessageIdByIndex(string name)
        {
            for (int i = mDatas.Count - 1; i > -1; i--)
            {
                if (mDatas[i].emojiId == name)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
