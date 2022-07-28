using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFrmTalk.Controls.LayouotControl.GroupTree;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    public partial class FrmGroupOrganizTree : FrmSuspension
    {
        public Friend mFriend { get; set; }

        /// <summary>
        /// 0内部群、1外部群
        /// </summary>
        public int inside { get; set; } = 1;


        /// <summary>
        /// 不可见的顶级树
        /// </summary>
        private GroupTreeData RootTree { get; set; }


        /// <summary>
        /// 只有官群有结构树
        /// </summary>
        public FrmGroupOrganizTree()
        {
            InitializeComponent();
            this.IsClose = true;
            this.Is_DropShadow = false;
            this.Radius = 0;

            if (Program.Started)
            {

                RootTree = new GroupTreeData();
                RootTree.IsRoot = true;
                RootTree.IsExpand = true;



                this.Load += FrmGroupOrganizTree_Load;
            }
        }

        private void FrmGroupOrganizTree_Load(object sender, System.EventArgs e)
        {
            HttpLoadGroupCount(mFriend.RoomId);
            HttpLoadGroupList(mFriend.RoomId);

            ivGroupIcon.Image = Resources.groupGQ;
            labName.Text = mFriend.NickName;
            label1.Text = this.inside == 0 ? "内部群" : "外部群";
        }

        private void HttpLoadGroupCount(string roomId)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "officialGroup/getOfficialGroup")
                .AddParams("control", "1")
                .AddParams("roomId", roomId)
                .Build().Execute((sccess, data) =>
                {

                    if (sccess)
                    {
                        var memberSize = UIUtils.DecodeInt(data, "userSize");

                        // 主群 8
                        var mainGroupSize = UIUtils.DecodeInt(data, "mainGroupSize");

                        // 分群 6
                        var branchGroupSize = UIUtils.DecodeInt(data, "branchGroupSize");

                        // 支群 5
                        var ofGroupSize = UIUtils.DecodeInt(data, "ofGroupSize");

                        // 子群 1
                        var subGroupSize = UIUtils.DecodeInt(data, "subGroupSize");

                        label2.Text = string.Format("{0}个", mainGroupSize);
                        label3.Text = string.Format("{0}个", branchGroupSize);
                        label4.Text = string.Format("{0}个", ofGroupSize);
                        label5.Text = string.Format("{0}个", subGroupSize);
                    }
                });
        }



        /// <summary>
        /// 群组织结构
        /// </summary>
        /// <param name="roomId"></param>
        private void HttpLoadGroupList(string roomId)
        {
            // 清空所有数据
            RootTree.Clear();

            if (inside == 1)
            {
                // 获取客服  officialGroup/customerServiceGroup
                HttpLoadCustomer(roomId);

                // 获取销售  officialGroup/saleServiceGroup
                HttpLoadSale(roomId);
            }


            //// 创建当前官群 根节点
            //GroupTreeData CurrTree = new GroupTreeData();
            //CurrTree.IsExpand = true;

            //CurrTree.UserId = mFriend.UserId;
            //CurrTree.RoomId = mFriend.RoomId;
            //CurrTree.name = mFriend.NickName;
            //CurrTree.type = 2;

            //RootTree.InsertNode(CurrTree);

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "officialGroup/getSubGroup")
                .AddParams("inside", Convert.ToString(inside)) // 0内部群、1外部群
                .AddParams("roomId", roomId)
                .Build().ExecuteJson<List<GroupTreeData>>((sccess, data) =>
                {
                    if (sccess && !UIUtils.IsNull(data))
                    {
                        // 构建层级关系
                        foreach (var item in data)
                        {
                            item.IsExpand = true;
                            if (item.parentId == mFriend.RoomId)
                            {
                                RootTree.InsertNode(item);
                            }

                            foreach (var item1 in data)
                            {
                                item1.IsExpand = true;
                                if (item.RoomId == item1.parentId)
                                {
                                    item.InsertNode(item1);
                                }
                            }
                        }

                        System.Console.WriteLine("建构树建立完成");
                    }


                    // 显示数据
                    var adapter = new GroupOrganizAdapter(xListView);
                    adapter.BindFriendData(RootTree);
                    xListView.SetAdapter(adapter);

                });
        }

        /// <summary>
        /// 获取销售人员
        /// </summary>
        /// <param name="roomId"></param>
        private void HttpLoadSale(string roomId)
        {
            //销售的树
            GroupTreeData SaleTree = new GroupTreeData();

            SaleTree.UserId = mFriend.UserId;
            SaleTree.RoomId = mFriend.RoomId;
            SaleTree.name = "销售";
            SaleTree.type = 11;
            SaleTree.inside = 0;
            SaleTree.IsExpand = true;

            RootTree.InsertNode(SaleTree);

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "officialGroup/saleServiceGroup")
               .AddParams("OfficialGroupId", roomId)
               .NoErrorTip()
               .Build().ExecuteJson<MemberTreeData>((sccess, data) =>
               {
                   if (sccess && !UIUtils.IsNull(data.members))
                   {
                       foreach (var item in data.members)
                       {
                           SaleTree.InsertNode(ConvertNode(item, false));
                       }
                   }
               });
        }

        /// <summary>
        /// 获取客服人员
        /// </summary>
        /// <param name="roomId"></param>
        private void HttpLoadCustomer(string roomId)
        {
            //客服的树
            GroupTreeData CustTree = new GroupTreeData();

            CustTree.UserId = mFriend.UserId;
            CustTree.RoomId = mFriend.RoomId;
            CustTree.name = "客服";
            CustTree.type = 11;
            CustTree.inside = 0;
            CustTree.IsExpand = true;

            RootTree.InsertNode(CustTree);

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "officialGroup/customerServiceGroup")
               .AddParams("OfficialGroupId", roomId)
               .NoErrorTip()
               .Build().ExecuteJson<MemberTreeData>((sccess, data) =>
               {
                   if (sccess && !UIUtils.IsNull(data.members))
                   {
                       foreach (var item in data.members)
                       {
                           CustTree.InsertNode(ConvertNode(item));
                       }
                   }
               });
        }

        private GroupTreeData ConvertNode(RoomMember item, bool cust = true)
        {
            // 将群成员数据转换成节点数据
            GroupTreeData member = new GroupTreeData();
            member.UserId = item.userId;
            member.RoomId = mFriend.RoomId;
            member.name = item.nickName;
            member.type = cust ? 99 : 98;
            member.inside = 0;
            return member;
        }

        private void Inside_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var control = sender as Control;
            contextMenuStrip1.Show(control, e.X, e.Y);
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            this.inside = Convert.ToInt32(item.Tag);

            label1.Text = this.inside == 0 ? "内部群" : "外部群";
            HttpLoadGroupList(mFriend.RoomId);
        }
    }
}
