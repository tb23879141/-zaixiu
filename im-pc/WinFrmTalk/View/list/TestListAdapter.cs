using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;
using WinFrmTalk.View;

public class TestListAdapter : IBaseAdapter
{
    private List<Friend> datas;

    public void BindFriendData(List<Friend> data)
    {
        datas = data;
    }

    public override int GetItemCount()
    {
        if (UIUtils.IsNull(datas))
        {
            return 0;
        }

        return datas.Count;
    }

    public override Control OnCreateControl(int index)
    {
        Friend friend = datas[index];
        NewsItem item = new NewsItem();
        item.FriendData = friend;
   
        return item;
    }

    public override int OnMeasureHeight(int index)
    {
        return 60;
    }


    public void InsertData(int index, Friend data)
    {
        datas.Insert(index, data);
    }

    public override void RemoveData(int index)
    {
        datas.RemoveAt(index);
    }




    public void ChangeData(int index, Friend friend)
    {
        datas[index] = friend;
    }


    public Friend GetData(int index)
    {
        return datas[index];
    }

    public void MoveData(int fromIndex, int toIndex)
    {
        if (fromIndex == toIndex)
        {
            return;
        }

        Friend temp = datas[fromIndex];

        // 从 1 --->   3
        if (fromIndex < toIndex)
        {
            int next = fromIndex + 1;
            while (next <= toIndex)
            {
                // 移动数据
                datas[next - 1] = datas[next];
                next++;
            }
        }
        else
        {
            // 从 5---->  2
            int next = fromIndex - 1;
            while (next >= toIndex)
            {
                // 移动数据
                datas[next + 1] = datas[next];
                next--;
            }
        }

        datas[toIndex] = temp;
    }


    public int GetIndexByFriendId(string userId)
    {
        //GetItemCount是否准确？
        for (int i = 0; i < GetItemCount(); i++)
        {
            string name = datas[i].NickName;
            if (datas[i].UserId.Equals(userId))
            {
                return i;
            }
        }

        return -1;
    }

    internal int GetTotalUnReadCount()
    {
        int totalcount = 0;

        foreach (var item in datas)
        {
            totalcount += item.MsgNum;

        }

        return totalcount;
    }

    internal int NextUnpoint(int currt)
    {
        int next = currt;
        for (int i = currt + 1; i < currt + GetItemCount(); i++)
        {
            next = i % GetItemCount();
            if (datas[next].MsgNum > 0)
            {
                return next;
            }
        }

        return currt;
    }
}
