using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;

namespace WinFrmTalk.View.list
{
    class PhoneRemarkAdapter : IBaseAdapter
    {
        private List<string> datas;

        public FrmFriendDescribe DescribePage { get; set; }

        public void BindData(List<string> data)
        {
            datas = data;
        }

        public override int GetItemCount()
        {
            if (datas != null)
            {
                return datas.Count;
            }

            return 0;
        }


        public string GetDatas(int index)
        {
            return datas[index];
        }

        public override Control OnCreateControl(int index)
        {
            string common = GetDatas(index);


            UserChatSometime usertext = new UserChatSometime();
            usertext.Size = new System.Drawing.Size(296, 42);
            usertext.Sometimetext = common;
            usertext.OnitemDel += DescribePage.OnDelPhone_Click;

            return usertext;
        }

        public override int OnMeasureHeight(int index)
        {
            return 42;
        }

        public override void RemoveData(int index)
        {
            datas.RemoveAt(index);
        }

        public void InsertData(int index, string data)
        {
            if (UIUtils.IsNull(datas))
            {
                datas = new List<string>();
                datas.Add(data);

                return;
            }

            datas.Insert(index, data);
        }

        public string GetRemarkPhoneStr()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < GetItemCount(); i++)
            {
                sb.Append(GetDatas(i));
                sb.Append(';');
            }

            if (GetItemCount() > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }



        public int GetIndexByText(string text)
        {
            for (int i = 0; i < GetItemCount(); i++)
            {
                if (GetDatas(i).Equals(text))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
