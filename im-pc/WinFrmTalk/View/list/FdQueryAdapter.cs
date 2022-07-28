using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls.ItemControl;
using WinFrmTalk.Model;

namespace WinFrmTalk.View.list
{
    public class FdQueryAdapter<T> : IBaseAdapter
    {
        public List<Friend> datas = new List<Friend>();

        public override int GetItemCount()
        {
            int count = datas == null ? 0 : datas.Count();
            return count;
        }

        public override Control OnCreateControl(int index)
        {
            Friend friend = datas[index];
            if (typeof(T).Name.Equals("OfficialAccountItem"))
            {
                OfficialAccountItem item = new OfficialAccountItem();
                item.friendData = friend;
                item.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                return item;
            }
            return null;
        }

        public override int OnMeasureHeight(int index)
        {
            return 60;
        }

        public override void RemoveData(int index)
        {
            datas = new List<Friend>();
        }
    }
}
