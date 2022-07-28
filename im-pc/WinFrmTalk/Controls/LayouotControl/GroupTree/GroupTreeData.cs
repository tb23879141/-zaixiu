using Newtonsoft.Json;
using System.Collections.Generic;

namespace WinFrmTalk.Controls.LayouotControl.GroupTree
{
    public class GroupTreeData : TreeNodex<GroupTreeData>
    {

        [JsonProperty("jid")]
        public string UserId { get; set; }

        [JsonProperty("id")]
        public string RoomId { get; set; }

        public string name { get; set; }

        //  0普通群；2官方群；3商城群；4临时群；5个人粉丝群；11官方群1级主群；12官方群二级分群；13官方群三级支群；14官方群四级子群 99 = 客服人员 98 = 销售人
        public int type { get; set; }

        /// <summary>
        ///  0内部群、1外部群
        /// </summary>
        public int inside { get; set; }

        public int isLook { get; set; }

        public long watchTime { get; set; }
        public long withdrawTime { get; set; }
        public string parentId { get; set; }


        /// <summary>
        /// 插入一个子节点
        /// 插入后请调用列表的RefreshItemEnd方法
        /// </summary>
        public void InsertNode(GroupTreeData child, int index = 0)
        {
            if (childNode == null)
            {
                childNode = new List<TreeNodex<GroupTreeData>>();
            }

            if (child != null)
            {
                child.NodeLevel = this.NodeLevel + 1;
                childNode.Add(child);
            }
        }

        /// <summary>
        /// 删除一个子节点
        /// 暂不支持多级删除
        /// 移除后请调用列表的RefreshItemEnd方法
        /// </summary>
        /// <param name="child"></param>
        public void RemoveNode(GroupTreeData child)
        {
            if (childNode != null)
            {
                childNode.Remove(child);
            }
        }


    }





    public class MemberTreeData
    {
        public List<RoomMember> members { get; set; }
    }

}
