using System.Windows.Forms;
using TestListView;

namespace WinFrmTalk.Controls.LayouotControl.GroupTree
{
    public class GroupOrganizAdapter : IBaseAdapter
    {
        private GroupTreeData datas;
        private XListView xListView;

        public GroupOrganizAdapter(XListView xListView)
        {
            this.xListView = xListView;
        }

        //public FrmTypeSelect frmTypeSelect;
        public override int GetItemCount()
        {
            if (datas != null)
            {
                return datas.Count;
            }

            return 0;
        }

        public override Control OnCreateControl(int index)
        {
            var item = new GroupTreeNodeItem();
            //item.Size = new System.Drawing.Size(302, 34);
            GroupTreeData data = GetIndexData(index);
            item.SetItemData(data);

            // 项的展开和收起
            item.MouseClick += NodeMouseClick;
            return item;
        }

        public void NodeMouseClick(object sender, MouseEventArgs e)
        {
            var item = (GroupTreeNodeItem)sender;

            if (e.Button == MouseButtons.Left)
            {

                item.itemData.IsExpand = !item.itemData.IsExpand;
                item.Expend(item.itemData.IsExpand);

                if (item.itemData.childNode != null)
                {
                    // 刷新下面的项
                    xListView.RefreshItemEnd();
                }
            }
        }

        private GroupTreeData GetIndexData(int index)
        {
            var data = datas.GetNode(index) as GroupTreeData;
            return data;
        }
        public override int OnMeasureHeight(int index)
        {
            return 34;
        }

        public override void RemoveData(int index)
        {

        }

        public void BindFriendData(GroupTreeData data)
        {
            datas = data;
        }

        public int GetIndexById(string userId)
        {
            //返回的应该是第几层的第几个
            for (int i = 0; i < GetItemCount(); i++)
            {

                if (GetIndexData(i).ExistChild)
                {
                    for (int j = 0; j < GetIndexData(i).childNode.Count; j++)
                    {
                        if ((GetIndexData(i).childNode[j] as GroupTreeData).UserId.Equals(userId))
                        {
                            return j;
                        }
                    }
                }

            }

            return -1;
        }
    }
}