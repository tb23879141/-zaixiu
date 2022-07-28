using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFrmTalk.View.list
{
    public class LabelAdapter : IBaseAdapter
    {
        private List<FriendLabel> friendLabels;
        public FriendLabelLayout UserLabel { get; set; }

        public override int GetItemCount()
        {
            if (friendLabels == null)
            {
                return 0;
            }

            return friendLabels.Count;
        }


        public override Control OnCreateControl(int index)
        {
            FriendLabel data = friendLabels[index];
            UserLabelItem item = new UserLabelItem();
            item.Size = new Size(265, 65);
            item.FriendLabel = data;
            UserLabel.BindContextMenu(item);
            item.MouseDown += UserLabel.OnMouseDownLable;
            item.BackColor = Color.Transparent;
            return item;
        }

        public override int OnMeasureHeight(int index)
        {
            return 65;
        }

        public override void RemoveData(int index)
        {
            friendLabels.RemoveAt(index);
        }
        public void BindDatas(List<FriendLabel> data)
        {
            friendLabels = data;
        }
    }
}
