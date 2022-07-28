using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WinFrmTalk.Controls.LayouotControl.GroupTree
{
    public class TreeNodex<T>
    {
        /// <summary>
        /// 是否根节点
        /// 根节点将不会显示在界面
        /// </summary>        
        [JsonIgnore]
        public bool IsRoot { get; set; }

        /// <summary>
        /// 是否分组
        /// 根节点将不会显示在界面
        /// </summary>        
        [JsonIgnore]
        public bool IsGroup { get; set; }

        [JsonIgnore]
        public List<TreeNodex<T>> childNode;

        /// <summary>
        /// 节点是否已展开
        /// 根节点必须展开
        /// </summary>
        [JsonIgnore]
        public bool IsExpand { get; set; }

        /// <summary>
        /// 节点层级
        /// </summary>
        [JsonIgnore]
        public int NodeLevel { get; set; }

        /// <summary>
        /// 是否存在子结点
        /// </summary>
        [JsonIgnore]
        public bool ExistChild
        {
            get
            {
                if (childNode == null)
                {
                    return false;
                }

                return childNode.Count > 0;
            }
        }



        [JsonIgnore]
        public int Count
        {
            get
            {
                var count = GetVisiableCount();

                if (count > 0)
                {
                    count--;
                }

                return count;
            }
        }





        private int GetVisiableCount()
        {
            if (ExistChild && IsExpand)
            {
                int count = 1;
                foreach (var item in childNode)
                {
                    count += item.GetVisiableCount();
                }

                return count;
            }
            else
            {
                return 1;
            }
        }


        public TreeNodex<T> GetNode(int index)
        {
            index++;
            return GetVisiableIndex(index);
        }

        private TreeNodex<T> GetVisiableIndex(int index)
        {
            if (index == 0)
            {
                return this;
            }

            index--;

            if (this.IsExpand && this.ExistChild)
            {
                foreach (var item in childNode)
                {
                    var data = item.GetVisiableIndex(index);

                    if (data != null)
                    {
                        return data;
                    }
                    else
                    {
                        index -= item.GetVisiableCount();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 先序遍历所有节点
        /// </summary>
        public void PrintExpand()
        {
            Console.WriteLine("PrintExpand:" + this.ToString());
            if (this.IsExpand && ExistChild)
            {
                foreach (var item in childNode)
                {
                    item.PrintExpand();
                }
            }
        }


        /// <summary>
        /// 清空节点
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Clear()
        {
            if (childNode != null)
            {
                childNode.Clear();
            }
        }
    }
}
