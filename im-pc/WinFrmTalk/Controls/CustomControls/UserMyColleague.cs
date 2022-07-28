using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using WinFrmTalk.Model;
using WinFrmTalk.View.list;
using WinFrmTalk.Controls.CustomControls;
using Newtonsoft.Json.Linq;

namespace WinFrmTalk.Controls
{
    public partial class UserMyColleague : UserControl
    {
        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            btnCreate.Text = LanguageXmlUtils.GetValue("btn_create_company", btnCreate.Text);
            lblTitle.Text = LanguageXmlUtils.GetValue("userMyColleague_title", lblTitle.Text);
            label1.Text = LanguageXmlUtils.GetValue("selected", label1.Text, true);
            AddDepartment.Text = LanguageXmlUtils.GetValue("add_department", AddDepartment.Text);
            EditCompany.Text = LanguageXmlUtils.GetValue("modify_company_name", EditCompany.Text);
            QuitCompany.Text = LanguageXmlUtils.GetValue("quit_company", QuitCompany.Text);
            DeleteCompany.Text = LanguageXmlUtils.GetValue("destory_company", DeleteCompany.Text);
            tsmCreateCompany.Text = LanguageXmlUtils.GetValue("creare_company_group", tsmCreateCompany.Text);
            AddSubdivisions.Text = LanguageXmlUtils.GetValue("addd_subdivisions", AddSubdivisions.Text);
            AddMember.Text = LanguageXmlUtils.GetValue("add_member", AddMember.Text);
            EditDepartmentName.Text = LanguageXmlUtils.GetValue("modify_department_name", EditDepartmentName.Text);
            DeleteDepartment.Text = LanguageXmlUtils.GetValue("delete_department", DeleteDepartment.Text);
            tsmCreateDepart.Text = LanguageXmlUtils.GetValue("create_department_group", tsmCreateDepart.Text);
            tsmDepartChat.Text = LanguageXmlUtils.GetValue("create_department_group_chat", tsmDepartChat.Text);
            tsmDetails.Text = LanguageXmlUtils.GetValue("details", tsmDetails.Text);
            tsmReplaceDepar.Text = LanguageXmlUtils.GetValue("replace_department", tsmReplaceDepar.Text);
            tsmEditPosition.Text = LanguageXmlUtils.GetValue("modify_post", tsmEditPosition.Text);
            tsmDeleteStaff.Text = LanguageXmlUtils.GetValue("delete_staff", tsmDeleteStaff.Text);
        }

        public UserMyColleague()
        {
            InitializeComponent();
            LoadLanguageText();
            lblNodeName.Text = "";
            mAdapter = new ColleagueAdapter();
            RegisterMessenger();
        }
        List<Friend> DepartfriendList = new List<Friend>();
        Dictionary<string, Friend> CompanyGroup = new Dictionary<string, Friend>();
        List<Control> controlLst = new List<Control>();
        List<employeesItem> employeesIst = new List<employeesItem>();
        DepartmentsItem departmentsItem = new DepartmentsItem();

        ColleagueAdapter mAdapter;
        public MyColleague myColleague = null;//我的同事所有信息


        public int refretime = 0;

        public void RefreData()
        {
            if (TimeUtils.CurrentIntTime() - refretime > 60)
            {
                refretime = TimeUtils.CurrentIntTime();
                httpData();
            }
        }
        Friend selectfriend;
        private void RegisterMessenger()
        {

            Messenger.Default.Register<bool>(this, UserMyColleague.SEND_Colleage_MSG, (_) =>
            {
                FrmMain MainForm = (FrmMain)this.Parent;
                MainForm.SendMessageToFriend(selectfriend);
            });
        }
        /// <summary>
        /// 数据绑定
        /// <para>ios公司id以部门I节点下公司ID为准</para>
        /// </summary>
        /// 
        private void httpData(bool UpdateContrlo = true)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/company/getByUserId")
                   .AddParams("access_token", Applicate.Access_Token)
                   .AddParams("userId", Applicate.MyAccount.userId)

                   .Build().Execute((suss, resultData) =>
                   {
                       if (suss)
                       {
                           myColleague = JsonConvert.DeserializeObject<MyColleague>(JsonConvert.SerializeObject(resultData));//数据泛型解析
                           if (UpdateContrlo)
                           {
                               tvwColleague.Nodes.Clear();
                               loadContrlo();
                           }
                       }
                   });
        }
        public int companycount = 0;
        public void downloadData()
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/company/getByUserId")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("userId", Applicate.MyAccount.userId)

                    .Build().Execute((suss, resultData) =>
                    {
                        if (suss)
                        {
                            myColleague = JsonConvert.DeserializeObject<MyColleague>(JsonConvert.SerializeObject(resultData));//数据泛型解析
                            if (myColleague.data == null)
                            {
                                lblNodeName.Text = "";
                            }
                        }
                    });
        }

        /// <summary>
        /// 加载数据到控件
        /// </summary>
        public void loadContrlo()
        {
            bool state2 = true;
            if (myColleague.data != null)
            {
                //label1.Text = "已选择：";
                label1.Visible = true;
                lblNodeName.Visible = true;
                foreach (ItemData itemData in myColleague.data)
                {
                    //公司层
                    TreeNode tn1 = new TreeNode(itemData.departments[0].departName);
                    tn1.Name = itemData.departments[0].id;
                    tn1.Tag = itemData.departments[0];
                    tvwColleague.Nodes.Add(tn1);
                    if (state2)
                    {
                        tvwColleague.SelectedNode = tn1;//默认选中的节点
                        Clicknode = tn1;
                        lblNodeName.Text = itemData.departments[0].departName;
                        state2 = false;
                    }
                    foreach (DepartmentsItem itemDataDepartment1 in itemData.departments)
                    {
                        //第一层部门层
                        TreeNode tn2 = new TreeNode();
                        if (itemDataDepartment1.parentId == itemData.departments[0].id)
                        {

                      //  int textwidth=    (int)EQControlManager.GetStringTheSize(itemDataDepartment1.departName, tn2.Font).Width;

                            tn2.Text = itemDataDepartment1.departName;
                            tn2.Name = itemDataDepartment1.id;
                            tn2.Tag = itemDataDepartment1;
                            tn1.Expand();
                            tn1.Nodes.Add(tn2);
                            //员工层
                            //foreach (employeesItem employeesItem in itemDataDepartment.employees)
                            //{
                            //    TreeNode tn3=new TreeNode(employeesItem.nickname);
                            //    tn2.Nodes.Add(tn3);
                            //}
                            //第二层员工层
                            foreach (DepartmentsItem itemDataDepartment2 in itemData.departments)
                            {
                                if (itemDataDepartment1.id == itemDataDepartment2.parentId)
                                {
                                    TreeNode tn2_1 = new TreeNode(itemDataDepartment2.departName);
                                    tn2_1.Name = itemDataDepartment2.id;
                                    tn2_1.Tag = itemDataDepartment2;
                                    tn2.Nodes.Add(tn2_1);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                //label1.Text = null;
                //lblNodeName.Text = null;
                label1.Visible = false;
                lblNodeName.Visible = false;
            }
        }
        //private void AdddataTopal(List<Friend> memberlsts)
        //{

        //    controlLst.Clear();
        //    tabpal.Controls.Clear();

        //    int j = 0, k = 0;


        //    for (int i = 0; i < memberlsts.Count; i++)
        //    {

        //        USEpicAddName uSEpicAddName = new USEpicAddName();
        //        uSEpicAddName.pics.Size = new Size(55, 55);
        //        uSEpicAddName.Size = new Size(70, 100);
        //        // uSEpicAddName.CurrentRole = CurrentRole;
        //        uSEpicAddName.lblName.Location = new Point(0, uSEpicAddName.pics.Size.Height + 10);
        //        uSEpicAddName.lblName.Font = new Font(Applicate.SetFont, 8F);
        //        // uSEpicAddName.Tag = memberlsts[i].role;
        //        uSEpicAddName.NickName = memberlsts[i].NickName;
        //        uSEpicAddName.Userid = memberlsts[i].UserId;
        //        ImageLoader.Instance.DisplayAvatar(memberlsts[i].UserId, uSEpicAddName.pics);


        //        uSEpicAddName.Margin = new Padding(10, 8, 3, 3);


        //        uSEpicAddName.pics.Click -= uSEpicAddName.pics_Click;
        //        uSEpicAddName.pics.MouseHover -= uSEpicAddName.pics_MouseHover;
        //        controlLst.Add(uSEpicAddName);
        //        tabpal.Controls.Add(controlLst[k]);
        //        k++;


        //    }

        //}


        public TreeNode Clicknode = null;//记录点击的节点
        public ColleagueItem SelectItem = null;
        public object createUserId;


        public string GetSelectNodeTextTitle(TreeNode currtNode)
        {

            if (currtNode == null)
            {
                return string.Empty;
            }

            string title = currtNode.Text;


            TreeNode next = currtNode.Parent;
            while (next != null)
            {
                title = next.Text + " -> " + title;
                next = next.Parent;
            }

            return title;
        }

        /// <summary>
        /// 点击节点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            lblNodeName.Text = GetSelectNodeTextTitle(e.Node);

            LogUtils.Log("公司ID:" + ((DepartmentsItem)e.Node.Tag).companyId);

            cmsCompany.Items[0].Enabled = true;
            cmsCompany.Items[1].Enabled = true;
            cmsCompany.Items[3].Enabled = true;
            cmsDepartment.Enabled = true;
            if (e.Button == MouseButtons.Right)
            {
                tvwColleague.SelectedNode = e.Node;
                Clicknode = e.Node;
                if (e.Node.Level <= 0)
                {
                    //公司层
                    if (e.Node.Tag is DepartmentsItem)
                    {
                        foreach (var dataDepartment in myColleague.data)
                        {
                            if (dataDepartment.id == ((DepartmentsItem)e.Node.Tag).companyId)
                            {
                                foreach (var department in dataDepartment.departments)
                                {
                                    CompanyGroup = new Dictionary<string, Friend>();
                                    CompanyGroup = EmployessToFriendValue(department.employees);
                                }
                            }

                        }
                        string jid = "room" + ((DepartmentsItem)Clicknode.Tag).companyId;
                        Friend friend = new Friend { UserId = jid, IsGroup = 1 }.GetFdByUserId();

                        //这里正确的表达应该是
                        //如果能在数据找到就是查看公司群，
                        //否则就是创建公司群
                        if (friend != null)
                        {
                            isLookCompany = true;
                            cmsCompany.Items[4].Text = "查看公司群";
                        }
                        else
                        {
                            isLookCompany = false;
                            cmsCompany.Items[4].Text = "创建公司群";
                        }


                        if (((DepartmentsItem)e.Node.Tag).createUserId.ToString() != Applicate.MyAccount.userId)
                        {
                            cmsCompany.Items[0].Enabled = false;
                            cmsCompany.Items[1].Enabled = false;
                            cmsCompany.Items[3].Enabled = false;
                            cmsCompany.Items[2].Enabled = true;

                        }
                    }
                    e.Node.ContextMenuStrip = cmsCompany;
                }
                //部门层
                if (e.Node.Level > 0)
                {
                    if (e.Node.Tag is DepartmentsItem)
                    {
                        if (((DepartmentsItem)e.Node.Tag).createUserId.ToString() != Applicate.MyAccount.userId)
                        {
                            // cmsDepartment.Enabled = false;


                        }
                        else
                        {
                            cmsDepartment.Items[0].Enabled = true;
                            cmsDepartment.Items[1].Enabled = true;
                            cmsDepartment.Items[2].Enabled = true;
                            cmsDepartment.Items[3].Enabled = true;
                        }
                        DepartfriendList = new List<Friend>();

                        if (((DepartmentsItem)e.Node.Tag).employees != null)
                        {
                            DepartfriendList = EmployessToFriend(((DepartmentsItem)e.Node.Tag).employees);
                            cmsDepartment.Items[4].Enabled = true;
                            string Departjid = "roomDepart" + ((DepartmentsItem)Clicknode.Tag).id;
                            Friend Depfriend = new Friend { UserId = Departjid, IsGroup = 1 };

                            if (Depfriend.GetByUserId() != Depfriend)
                            {

                                cmsDepartment.Items[5].Text = "发起部门群聊";
                            }

                        }
                    }
                    e.Node.ContextMenuStrip = cmsDepartment;
                }
                return;
            }

            LogUtils.Log(e.Node.Name);
            List<Control> lisitem = new List<Control>();
            //点击加载第四级部门
            foreach (var dataDepartment in myColleague.data)
            {
                foreach (var department in dataDepartment.departments)
                {
                    departmentsItem = department;
                    if (e.Node.Level > 0 && e.Node.FirstNode == null)
                    {


                        if (e.Node.Name == department.parentId)
                        {
                            TreeNode tn2_1 = new TreeNode(department.departName);
                            tn2_1.Tag = department;
                            tn2_1.Name = department.id;
                            e.Node.Nodes.Add(tn2_1);
                        }

                    }
                    //禁止连点击连续加载现象出现
                    if (department.id == ((DepartmentsItem)e.Node.Tag).id && e.Node != Clicknode)
                    {
                        //pnlMyColleague.ClearTabel();
                        LodingUtils loding = new LodingUtils();
                        loding.parent = pnlMyColleague;
                        loding.start();
                        employeesIst = department.employees;//存在employeesIst刷新，但是department.employees没有刷新？？

                        mAdapter.BindDatas(employeesIst, departmentsItem);
                        mAdapter.SetMaengForm(this);
                        pnlMyColleague.SetAdapter(mAdapter);
                        loding.stop();
                        //foreach (var employee in department.employees)
                        //{

                        //    ColleagueItem item = new ColleagueItem();
                        //    item.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        //    item.Width = 500;
                        //    Friend friend = new Friend();
                        //    item.createUserId = department.createUserId;
                        //    item.UserID = employee.userId;
                        //    friend.nickName = employee.nickname;
                        //    friend.userId = employee.userId;
                        //    item.friendData = friend;
                        //    item.Position = employee.position;
                        //    item.Tag = employee;
                        //    item.DoubleClick += (sen, eve) =>
                        //    {
                        //        if (friend.userId != Applicate.MyAccount.userId)
                        //        {
                        //            SendAction?.Invoke(friend);
                        //        }
                        //    };

                        //    item.pic_head.isDrawRound = true;
                        //    ImageLoader.Instance.DisplayAvatar(employee.userId, item.pic_head);
                        //    this.createUserId = department.createUserId;
                        //    item.RightMenu((coll) =>
                        //    {
                        //        tsmReplaceDepar.DropDownItems.Clear();
                        //        foreach (var itemData in myColleague.data)
                        //        {
                        //            if (e.Node.Level > 0)
                        //            {
                        //                if (((DepartmentsItem)Clicknode.Tag).companyId == itemData.id)
                        //                {
                        //                    foreach (DepartmentsItem itemDataDepartment1 in itemData.departments)
                        //                    {
                        //                        if (itemDataDepartment1.parentId == itemData.departments[0].id && itemDataDepartment1.id != Clicknode.Name)
                        //                        {
                        //                            ToolStripMenuItem toolStrip = new ToolStripMenuItem(itemDataDepartment1.departName);
                        //                            toolStrip.Name = itemDataDepartment1.id;
                        //                            toolStrip.Tag = itemDataDepartment1;
                        //                            toolStrip.Click += ToolStrip_Click;
                        //                            tsmReplaceDepar.DropDownItems.Add(toolStrip);
                        //                        }

                        //                    }
                        //                }

                        //            }

                        //            if (SelectItem != null)
                        //            {
                        //                SelectItem.IsSelected = false;
                        //                SelectItem.ContextMenuStrip = null;
                        //            }

                        //            this.SelectItem = coll;
                        //            SelectItem.IsSelected = true;
                        //        }
                        //    });
                        //    item.MouseDown += Item_MouseDown;
                        //    lisitem.Add(item);
                        //}
                        //List<Control> views = new List<Control>();
                        //for (int i = 0; i < 20; i++)
                        //{
                        //    //验证是否有该index
                        //    if (i < lisitem.Count)
                        //        views.Add(lisitem[i]);
                        //}
                        //pnlMyColleague.AddViewsToPanel(views);
                        //loding.stop();

                        //pnlMyColleague.AddScollerBouttom((index) =>
                        //{
                        //    views = new List<Control>();
                        //    for (int i = 0; i < 10; i++)
                        //    {
                        //        int num = i + ((index - (20 / 10) - 1) * 10) + 20;
                        //        if (num < lisitem.Count)
                        //            views.Add(lisitem[num]);
                        //    }
                        //    pnlMyColleague.AddViewsToPanel(views);
                        //   LogUtils.Log(index);
                        //}, 20, 10);
                    }

                }
            }
            Clicknode = e.Node;
        }

        private List<Friend> EmployessToFriend(List<employeesItem> employees)
        {
            List<Friend> friends = new List<Friend>();
            for (int i = 0; i < employees.Count; i++)
            {
                Friend friend = new Friend();
                friend.UserId = employees[i].userId;
                friend.NickName = employees[i].nickname;
                friends.Add(friend);
            }
            return friends;
        }
        private Dictionary<string, Friend> EmployessToFriendValue(List<employeesItem> employees)
        {
            Dictionary<string, Friend> friends = new Dictionary<string, Friend>();
            for (int i = 0; i < employees.Count; i++)
            {
                Friend friend = new Friend();
                friend.UserId = employees[i].userId;
                friend.NickName = employees[i].nickname;
                friends.Add(employees[i].userId, friend);
            }
            return friends;
        }

        /// <summary>
        /// 成员右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Item_MouseDown(object sender, MouseEventArgs e)
        {


            cmsStaff.Items[1].Enabled = true;
            cmsStaff.Items[2].Enabled = true;
            cmsStaff.Items[3].Enabled = true;
            if (e.Button == MouseButtons.Right)
            {
                if (this.createUserId.ToString() != Applicate.MyAccount.userId)
                {
                    if (SelectItem.UserID == Applicate.MyAccount.userId)
                    {
                        cmsStaff.Items[1].Enabled = false;
                        cmsStaff.Items[3].Enabled = false;
                    }

                    if (SelectItem.UserID != Applicate.MyAccount.userId)
                    {
                        cmsStaff.Items[1].Enabled = false;
                        cmsStaff.Items[2].Enabled = false;
                        cmsStaff.Items[3].Enabled = false;
                    }
                }
                else
                {
                    cmsStaff.Items[2].Enabled = true;
                }
                SelectItem.ContextMenuStrip = cmsStaff;
            }
            //创建者和自己都能修改职位
            if (SelectItem.UserID != Applicate.MyAccount.userId && this.createUserId.ToString() != Applicate.MyAccount.userId)
            {
                cmsStaff.Items[2].Enabled = false;
            }
        }
        /// <summary>
        /// 创建公司
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            FrmMyColleagueEidt frm = Applicate.GetWindow<FrmMyColleagueEidt>();
            if (frm == null)
            {
                frm = new FrmMyColleagueEidt();
            }
            else
            {
                frm.Activate();
                return;
            }
         
            frm.maxLength = 12;
            frm.Location = new Point(this.Location.X + (this.Width - frm.Width) / 2, this.Location.Y + (this.Height - frm.Height) / 2);
            frm.ColleagueName((data) =>
            {
                HttpUtils.Instance.PopView(frm);
                frm.Close();
                var main = new DelegateString(ChangeCollData);
                Invoke(main, "company/create", data);
            });

            string title = LanguageXmlUtils.GetValue("title_create_company", "创建公司");
            string name = LanguageXmlUtils.GetValue("name_company_name", "公司名称", true);
            frm.ShowThis(title, name);

        }
        #region 公司层右键菜单
        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDepartment_Click(object sender, EventArgs e)
        {
            //弹窗编辑
            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();
            frm.Location = new Point(this.Location.X + (this.Width - frm.Width) / 2, this.Location.Y + (this.Height - frm.Height) / 2);
            frm.ColleagueName((data) =>
            {
                HttpUtils.Instance.PopView(frm);
                frm.Close();
                var main = new DelegateString(ChangeCollData);
                Invoke(main, "create666", data);
            });

            string title = LanguageXmlUtils.GetValue("title_create_company", "创建部门");
            string name = LanguageXmlUtils.GetValue("name_company_name", "部门名称", true);
            frm.ShowThis(title, name);

        }
        /// <summary>
        /// 修改公司名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCompany_Click(object sender, EventArgs e)
        {
            //弹窗编辑
            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();
            frm.NameEdit = Clicknode.Text;
            frm.Location = new Point(this.Location.X + (this.Width - frm.Width) / 2, this.Location.Y + (this.Height - frm.Height) / 2);
            frm.ColleagueName((data) =>
            {
                HttpUtils.Instance.PopView(frm);
                frm.Close();
                var main = new DelegateString(ChangeCollData);
                Invoke(main, "modify", data);
            });

            string title = LanguageXmlUtils.GetValue("title_modify_company_name", "修改公司名称");
            string name = LanguageXmlUtils.GetValue("name_company_name", "公司名称", true);
            frm.ShowThis(title, name);
        }
        private delegate void DelegateString(string msg, string data);

        public void ChangeCollData(string type, string data)
        {
            if (type.Equals("modify"))
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/company/modify")
                   .AddParams("access_token", Applicate.Access_Token)
                   .AddParams("companyId", ((DepartmentsItem)Clicknode.Tag).companyId)
                   .AddParams("companyName", data)
                   .Build()
                   .Execute((suss, resultData) =>
                   {
                       //关闭窗体的后提示消息也会关闭

                       if (suss)
                       {
                           tvwColleague.Nodes.Clear();
                           httpData();
                           HttpUtils.Instance.ShowTip("修改成功");
                       }

                   });
            }
            else if ("department/modify".Equals(type))
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/department/modify")
                   .AddParams("access_token", Applicate.Access_Token)
                   .AddParams("departmentId", Clicknode.Name)
                   .AddParams("dpartmentName", data)
                   .Build().Execute((suss, resultData) =>
                   {
                       if (suss)
                       {
                           tvwColleague.Nodes.Clear();
                           httpData();
                           HttpUtils.Instance.ShowTip("修改成功");
                       }
                   });
            }
            else if ("company/create".Equals(type))
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/company/create")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("companyName", data)
                    .AddParams("createUserId", Applicate.MyAccount.userId)
                    .Build().Execute((suss, resultData) =>
                    {
                        if (suss)
                        {
                            // tvwColleague.Nodes.Clear();
                            //httpData();
                            List<DepartmentsItem> departmentlst = new List<DepartmentsItem>();
                            downloadData();
                            //公司层
                            TreeNode tn1 = new TreeNode(UIUtils.DecodeString(resultData, "companyName"));
                            tn1.Name = UIUtils.DecodeString(resultData, "id");
                            var demp = JsonConvert.DeserializeObject<List<object>>(resultData["departments"].ToString());
                            string selectcompany = "";
                            foreach (var item in demp)
                            {
                                var em = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.ToString());
                                //if (itemDataDepartment1.parentId == itemData.departments[0].id)
                                //{

                                //}
                                DepartmentsItem departmentsItem = new DepartmentsItem();
                                departmentsItem.companyId = UIUtils.DecodeString(em, "companyId");
                                departmentsItem.createTime = UIUtils.DecodeInt(em, "createTime");
                                departmentsItem.createUserId = UIUtils.DecodeInt(em, "createUserId");
                                departmentsItem.departName = UIUtils.DecodeString(em, "departName");
                                departmentsItem.empNum = UIUtils.DecodeInt(em, "empNum");
                                departmentsItem.employees = JsonConvert.DeserializeObject<List<employeesItem>>(em["employees"].ToString());
                                departmentsItem.id = UIUtils.DecodeString(em, "id");
                                departmentsItem.type = UIUtils.DecodeInt(em, "type");
                                departmentsItem.parentId = UIUtils.DecodeString(em, "parentId");

                                if (departmentsItem.parentId != "")
                                {
                                    TreeNode tn2_1 = new TreeNode(departmentsItem.departName);
                                    tn1.Expand();
                                    tn2_1.Name = departmentsItem.id;
                                    tn2_1.Tag = departmentsItem;
                                    tn1.Nodes.Add(tn2_1);
                                    departmentlst.Add(departmentsItem);
                                }
                                else
                                {
                                    selectcompany = departmentsItem.departName;
                                }

                            }

                            tn1.Tag = departmentlst[0];
                            tvwColleague.SelectedNode = tn1;//默认选中的节点
                            Clicknode = tn1;
                            //label1.Text = "已选择:";
                            label1.Visible = true;
                            lblNodeName.Visible = true;
                            lblNodeName.Text = selectcompany;

                            tvwColleague.Nodes.Add(tn1);
                            HttpUtils.Instance.ShowTip("创建成功");
                        }
                    });
            }
            else if ("modifyPosition".Equals(type))
            {

                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/employee/modifyPosition")
                   .AddParams("access_token", Applicate.Access_Token)
                   .AddParams("userId", SelectItem.UserID)
                   .AddParams("companyId", ((employeesItem)SelectItem.Tag).companyId)
                   .AddParams("position", data)
                   .Build().Execute((suss, resultData) =>
                   {
                       if (suss)
                       {
                           if (mAdapter.GetItemCount() != 0)
                           {
                               pnlMyColleague.ClearList();
                           }
                           tvwColleague.Nodes.Clear();
                           httpData();
                           HttpUtils.Instance.ShowTip("修改成功");
                       }
                   });

            }
            else if ("create666".Equals(type))
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/department/create")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("companyId", ((DepartmentsItem)Clicknode.Tag).companyId)//部门节点的公司ID
                    .AddParams("parentId", ((DepartmentsItem)Clicknode.Tag).id)
                    .AddParams("departName", data)
                    .AddParams("createUserId", Applicate.MyAccount.userId)
                    .Build().Execute((suss, resultData) =>
                    {
                        if (suss)
                        {
                            tvwColleague.Nodes.Clear();
                            httpData();
                            HttpUtils.Instance.ShowTip("创建成功");
                        }
                    });
            }
            else if ("create".Equals(type))
            {

                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/department/create")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("companyId", ((DepartmentsItem)Clicknode.Tag).companyId)
                    .AddParams("parentId", Clicknode.Name)
                    .AddParams("departName", data)
                    .AddParams("createUserId", Applicate.MyAccount.userId)
                    .Build().Execute((suss, resultData) =>
                    {

                        if (suss)
                        {
                            //tvwColleague.Nodes.Clear();
                            downloadData();
                            DepartmentsItem departments = JsonConvert.DeserializeObject<DepartmentsItem>(JsonConvert.SerializeObject(resultData));
                            TreeNode tree = new TreeNode { Text = departments.departName, Name = departments.id, Tag = departments };

                            Clicknode.Nodes.Add(tree);
                            if (mAdapter.GetItemCount() != 0)
                            {
                                pnlMyColleague.ClearList();
                            }
                            tvwColleague.SelectedNode = tree;//默认选中的节点
                            HttpUtils.Instance.ShowTip("创建成功");
                        }
                    });
            }
        }

        /// <summary>
        /// 退出公司
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitCompany_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出此公司", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/company/quit")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("companyId", ((DepartmentsItem)Clicknode.Tag).companyId)
                    .AddParams("userId", Applicate.MyAccount.userId)
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            tvwColleague.Nodes.Clear();
                            httpData();
                            if (mAdapter.GetItemCount() != 0)
                            {

                                pnlMyColleague.ClearList();

                            }
                            //if (mAdapter.GetItemCount() != 0)
                            //{
                            //    pnlMyColleague.ClearList();
                            //}

                            HttpUtils.Instance.ShowTip("退出成功");
                        }
                    });
            }
        }
        /// <summary>
        /// 删除公司
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCompany_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认删除此公司", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/company/delete")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("companyId", ((DepartmentsItem)Clicknode.Tag).companyId)
                    .AddParams("userId", Applicate.MyAccount.userId)
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            tvwColleague.SelectedNode.Remove();
                            if (mAdapter.GetItemCount() != 0)
                            {
                                pnlMyColleague.ClearList();
                            }

                            downloadData();
                            HttpUtils.Instance.ShowTip("删除成功");
                            //需要做一个判断，如果面板上公司为零，顶上的提示也要删除
                        }
                    });
            }
        }
        #endregion
        #region 部门层右键菜单
        /// <summary>
        /// 添加子部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSubdivisions_Click(object sender, EventArgs e)
        {
            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();
            frm.Location = new Point(this.Location.X + (this.Width - frm.Width) / 2, this.Location.Y + (this.Height - frm.Height) / 2);
            frm.ColleagueName((data) =>
            {
                HttpUtils.Instance.PopView(frm);
                frm.Close();
                var main = new DelegateString(ChangeCollData);
                Invoke(main, "create", data);
            });

            string title = LanguageXmlUtils.GetValue("title_add_sub-department", "添加子部门");
            string name = LanguageXmlUtils.GetValue("name_sub-department_name", "部门名称", true);
            frm.ShowThis(title, name);
        }

        /// <summary>
        /// 添加成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMember_Click(object sender, EventArgs e)
        {
            //筛选出本部门已存在的成员
            List<RoomMember> listuserid = new List<RoomMember>();
            foreach (var data in myColleague.data)
            {
                foreach (var departmentsItem in data.departments)
                {
                    foreach (var employeesItem in departmentsItem.employees)
                    {
                        if (employeesItem.companyId == ((DepartmentsItem)Clicknode.Tag).companyId)
                        {
                            listuserid.Add(new RoomMember() { userId = employeesItem.userId });
                        }
                    }
                }
            }
            FrmFriendSelect frm = new FrmFriendSelect();
            frm.LoadFriendsData(listuserid,false);//在好友选择器中删掉已存在的成员
            frm.AddConfrmListener((UserFriends) =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("[");
                foreach (var itemValue in UserFriends.Values)
                {
                    sb.Append("\"" + itemValue.UserId + "\",");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("]");
                LogUtils.Log(sb.ToString());
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/employee/add")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("userId", sb.ToString()) //需要添加的用户id，json字符串
                    .AddParams("companyId", ((DepartmentsItem)Clicknode.Tag).companyId)
                    .AddParams("departmentId", Clicknode.Name)
                    .AddParams("role", "1")
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            //tvwColleague.Nodes.Clear();
                            // httpData();
                            employeesIst = new List<employeesItem>();
                            var emplo = JsonConvert.DeserializeObject<List<object>>(data["data"].ToString());



                            foreach (var item in emplo)
                            {
                                var em = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.ToString());

                                employeesItem employeesItem = new employeesItem();
                                employeesItem.companyId = UIUtils.DecodeString(em, "companyId");
                                employeesItem.departmentId = UIUtils.DecodeString(em, "departmentId");
                                employeesItem.id = UIUtils.DecodeString(em, "id");
                                employeesItem.isCustomer = UIUtils.DecodeInt(em, "isCustomer");
                                employeesItem.isPause = UIUtils.DecodeInt(em, "isPause");
                                employeesItem.nickname = UIUtils.DecodeString(em, "nickname");
                                employeesItem.operationType = UIUtils.DecodeInt(em, "operationType");

                                employeesItem.position = UIUtils.DecodeString(em, "position");
                                employeesItem.role = UIUtils.DecodeInt(em, "role");
                                employeesItem.userId = UIUtils.DecodeString(em, "userId");
                                employeesItem.chatNum = UIUtils.DecodeInt(em, "chatNum");

                                employeesIst.Add(employeesItem);

                            }

                            foreach (var itemData in myColleague.data)
                            {
                                foreach (var departmentsItem in itemData.departments)
                                {
                                    foreach (var employees in departmentsItem.employees)
                                    {
                                        if (employees.departmentId == Clicknode.Name)
                                        {
                                            departmentsItem.employees = employeesIst;
                                        }
                                    }

                                }
                            }

                            mAdapter.BindDatas(employeesIst, departmentsItem);

                            mAdapter.SetMaengForm(this);
                            pnlMyColleague.SetAdapter(mAdapter);
                            //  pnlMyColleague.
                            ((DepartmentsItem)Clicknode.Tag).employees = employeesIst;
                            ((DepartmentsItem)Clicknode.Tag).empNum = employeesIst.Count;
                            downloadData();
                            HttpUtils.Instance.ShowTip("添加成功");
                        }
                    });
            });
        }

        /// <summary>
        /// 修改部门名称
        /// </summary>f
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditDepartmentName_Click(object sender, EventArgs e)
        {
            //弹窗编辑
            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();
            frm.NameEdit = Clicknode.Text;
            frm.maxLength = 30;
            frm.Location = new Point(this.Location.X + (this.Width - frm.Width) / 2, this.Location.Y + (this.Height - frm.Height) / 2);
            frm.ColleagueName((data) =>
            {
                HttpUtils.Instance.PopView(frm);


                frm.Close();
                var main = new DelegateString(ChangeCollData);
                Invoke(main, "department/modify", data);
            });

            string title = LanguageXmlUtils.GetValue("title_modify_department", "修改部门名称");
            string name = LanguageXmlUtils.GetValue("name_department_name", "部门名称", true);
            frm.ShowThis(title, name);
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteDepartment_Click(object sender, EventArgs e)
        {
            // downloadData();
            if (((DepartmentsItem)Clicknode.Tag).employees.Count != 0)//没有及时刷新
            {
                HttpUtils.Instance.ShowTip("部门内还有人员禁止删除");
                return;
            }
            DialogResult result = MessageBox.Show("确认删除此部门", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                if (Clicknode.FirstNode == null)
                {
                    HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/department/delete")
                        .AddParams("access_token", Applicate.Access_Token)
                        .AddParams("departmentId", ((DepartmentsItem)Clicknode.Tag).id)
                        .Build().Execute((suss, data) =>
                        {
                            if (suss)
                            {
                                if (mAdapter.GetItemCount() != 0)
                                {
                                    pnlMyColleague.ClearList();
                                }
                                downloadData();
                                tvwColleague.Nodes.Remove(Clicknode);
                                HttpUtils.Instance.ShowTip("删除成功"); ;

                            }
                        });
                }
                else
                {
                    HttpUtils.Instance.ShowTip("该部门内有人，不能被删除");
                }
            }
        }
        #endregion

        #region 员工层右键菜单
        /// <summary>
        /// 好友详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDetails_Click(object sender, EventArgs e)
        {

            FrmFriendsBasic frm = new FrmFriendsBasic();
            frm.ShowUserInfoById(SelectItem.UserID);
        }
        /// <summary>
        /// 更换部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ToolStrip_Click(object sender, EventArgs e)
        {
            ToolStripItem tool = ((ToolStripMenuItem)sender);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/employee/modifyDpart")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", SelectItem.UserID)
                .AddParams("companyId", ((DepartmentsItem)tool.Tag).companyId)
                .AddParams("newDepartmentId", tool.Name)
                .Build().Execute((suss, resultdata) =>
                {
                    if (suss)
                    {

                        //((DepartmentsItem)tool.Tag).empNum++;
                        //同时要从原先的部门删除掉
                        httpData();//loadContrlo刷新后能够重新绑定点击数据，如果不刷新，点击事件会报错，刷新
                        //((DepartmentsItem)Clicknode.Tag).empNum--;
                        for (int i = 0; i < employeesIst.Count; i++)
                        {
                            if (employeesIst[i].userId == SelectItem.UserID)
                            {
                                // ((DepartmentsItem)tool.Tag).employees.Add(employeesIst[i]);

                                pnlMyColleague.RemoveItem(i);
                                mAdapter.RemoveData(i);
                            }
                        }

                        //downloadData();

                        HttpUtils.Instance.ShowTip("更换成功");


                        //TreeNode treeNode = new TreeNode(((DepartmentsItem)tool.Tag).departName);
                        //tvwColleague.SelectedNode = treeNode;
                        //foreach (var itemData in myColleague.data)
                        //{
                        //    foreach (var departmentsItem in itemData.departments)
                        //    {
                        //        foreach (var employees in departmentsItem.employees)
                        //        {
                        //            if (employees.departmentId == tool.Name)
                        //            {
                        //                employeesItem employeesItem = new employeesItem();
                        //                employeesItem.companyId = UIUtils.DecodeString(resultdata, "companyId");
                        //                employeesItem.departmentId = UIUtils.DecodeString(resultdata, "departmentId");
                        //                employeesItem.id = UIUtils.DecodeString(resultdata, "id");
                        //                employeesItem.isCustomer = UIUtils.DecodeInt(resultdata, "isCustomer");
                        //                employeesItem.isPause = UIUtils.DecodeInt(resultdata, "isPause");
                        //                employeesItem.nickname = UIUtils.DecodeString(resultdata, "nickname");
                        //                employeesItem.operationType = UIUtils.DecodeInt(resultdata, "operationType");

                        //                employeesItem.position = UIUtils.DecodeString(resultdata, "position");
                        //                employeesItem.role = UIUtils.DecodeInt(resultdata, "role");
                        //                employeesItem.userId = UIUtils.DecodeString(resultdata, "userId");
                        //                employeesItem.chatNum = UIUtils.DecodeInt(resultdata, "chatNum");
                        //               // employeesIst.Add(employeesItem);

                        //                departmentsItem.employees.Add(employeesItem);
                        //            }
                        //        }

                        //    }
                        //}

                    }
                });
        }
        /// <summary>
        /// 修改职位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmEditPosition_Click(object sender, EventArgs e)
        {
            //弹窗编辑
            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();
            frm.NameEdit = SelectItem.Position;
            frm.maxLength = 12;
            frm.Location = new Point(this.Location.X + (this.Width - frm.Width) / 2, this.Location.Y + (this.Height - frm.Height) / 2);
            frm.ColleagueName((data) =>
            {
                HttpUtils.Instance.PopView(frm);
                frm.Close();
                var main = new DelegateString(ChangeCollData);
                Invoke(main, "modifyPosition", data);
            });

            string title = LanguageXmlUtils.GetValue("title_modify_post", "修改职位");
            string name = LanguageXmlUtils.GetValue("name_post_name", "职位名称", true);
            frm.ShowThis(title, name);
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDeleteStaff_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认删除此员工", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {

                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/employee/delete")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("userIds", "[\"" + SelectItem.UserID + "\"]")
                    .AddParams("departmentId", ((employeesItem)SelectItem.Tag).departmentId)
                    //.AddErrorListener((suss, msg) =>
                    //{
                    //    HttpUtils.Instance.ShowTip(msg);
                    //})
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            for (int i = 0; i < employeesIst.Count; i++)
                            {
                                if (employeesIst[i].userId == SelectItem.UserID)
                                {
                                    pnlMyColleague.RemoveItem(i);
                                    mAdapter.RemoveData(i);
                                    //  (()SelectItem.Tag).e
                                }
                            }
                            // pnlMyColleague.ClearList();
                            // tvwColleague.Nodes.Clear();
                            httpData();
                            HttpUtils.Instance.ShowTip("删除成功");
                        }
                    });
            }
        }

        #endregion
        public Action<Friend> SendAction { get; set; }
        public const string SEND_Colleage_MSG = nameof(SEND_Colleage_MSG);

        bool isLookCompany;
        /// <summary>
        /// 创建公司群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmCreateCompany_Click(object sender, EventArgs e)
        {

            if (!isLookCompany)
            {
                string name = Clicknode.Text + "群";
                string roomdesc = Clicknode.Text + "群(公司)";
                Dictionary<string, Friend> select = new Dictionary<string, Friend>();
                // 去选择好友
                Friend friend = new Friend();
                friend.NickName = name;
                friend.Description = roomdesc;
                string jid = "room" + ((DepartmentsItem)Clicknode.Tag).companyId;
                jid = ShiKuManager.mSocketCore.CreateGroup(friend.NickName, friend.Description, jid);
                friend.UserId = jid;
                HttpCreateNormalRoom(friend, CompanyGroup);
            }
            else
            {
                selectfriend = new Friend();
                selectfriend.UserId = "room" + ((DepartmentsItem)Clicknode.Tag).companyId;
                selectfriend = selectfriend.GetByUserId();
                Messenger.Default.Send(true, UserMyColleague.SEND_Colleage_MSG);
            }
        }
        private void HttpCreateNormalRoom(Friend friend, Dictionary<string, Friend> select)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/add")//新建群组
            .AddParams("jid", friend.UserId)
            .AddParams("access_token", Applicate.Access_Token)
            .AddParams("desc", friend.Description)
            .AddParams("name", friend.NickName)
            .AddParams("showRead", "0")
            .AddParams("cityId", "440300")
            .AddParams("countryId", "1")
            .AddParams("provinceId", "440000")
            .AddParams("areaId", "440307")
            .AddParams("longitude", "114.066307")
            .AddParams("latitude", "22.609084")
            .Build().Execute((sccess, data) =>
            {
                if (sccess)
                {
                    string roomId = UIUtils.DecodeString(data, "id");

                    if (select != null && select.Count > 0)
                    {

                        InviteToGroup(roomId, select, 0);
                        SaveRoomUsers(roomId, select);
             
                    }

                    selectfriend = friend;
                    Messenger.Default.Send(true, UserMyColleague.SEND_Colleage_MSG);

                }
                else
                {
                    MessageBox.Show(data.ToString());
                }
            });
        }
        private void InviteToGroup(string roomId, Dictionary<string, Friend> select, int isEncrypt)
        {
            List<Friend> datas = new List<Friend>();
            JArray josnIds = new JArray();
            foreach (var item in select.Keys)
            {
                datas.Add(select[item]);
                josnIds.Add(item);
            }

            string userids = josnIds.ToString();

            Dictionary<string, string> value = new Dictionary<string, string>();
            value.Add("access_token", Applicate.Access_Token);
            value.Add("roomId", roomId);
            value.Add("text", userids);
            value.Add("isSecretGroup", isEncrypt.ToString());

            HttpUtils.Instance.InitHttp(this);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/member/update") //获取群详情
            .AddParams(value)
            .AddErrorListener((code, err) =>
            {
                HttpUtils.Instance.FindFrm(typeof(FrmMain)).ShowTip(err);
            })
            .Build().Execute((state, data) =>
            {
                HttpUtils.Instance.FindFrm(typeof(FrmMain)).ShowTip("创建成功");
            });
        }
        private void SaveRoomUsers(string _roomId, Dictionary<string, Friend> select)
        {
            List<RoomMember> memberList = new List<RoomMember>();
            foreach (KeyValuePair<string, Friend> a in select)
            {
                RoomMember roomMembers = new RoomMember();
                roomMembers.roomId = _roomId;
                roomMembers.userId = a.Key;
                roomMembers.nickName = a.Value.NickName;
                roomMembers.role = 3;
                roomMembers.talkTime = 0;
                roomMembers.sub = 1;
                roomMembers.offlineNoPushMsg = 0;
                roomMembers.remarkName = a.Value.NickName;

                memberList.Add(roomMembers);

            }

            RoomMember roomMember = new RoomMember() { roomId = _roomId };
            roomMember.AutoInsertOrUpdate(memberList);
        }
        /// <summary>
        /// 创建部门群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmCreateDepart_Click(object sender, EventArgs e)
        {

            // 去选择好友
            Friend friend = new Friend();
            friend.NickName = ((DepartmentsItem)Clicknode.Tag).departName + "群";
            friend.Description = ((DepartmentsItem)Clicknode.Tag).departName + "群";
            FrmFriendSelect frm = new FrmFriendSelect();

            frm.LoadFriendsData(DepartfriendList);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.AddConfrmListener((disFriend) =>
            {
                string jid = ShiKuManager.mSocketCore.CreateGroup(friend.NickName, friend.Description);
                friend.UserId = jid;
                HttpCreateNormalRoom(friend, disFriend);
            });



        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDepartChat_Click(object sender, EventArgs e)
        {
            if (tsmDepartChat.Text != "发起部门群聊")
            {
                string name = ((DepartmentsItem)Clicknode.Tag).departName + "群";
                string roomdesc = ((DepartmentsItem)Clicknode.Tag).departName + "部门群";
                Dictionary<string, Friend> select = new Dictionary<string, Friend>();
                // 去选择好友
                Friend friend = new Friend();
                friend.NickName = name;
                friend.Description = roomdesc;
                string jid = "roomDepart" + ((DepartmentsItem)Clicknode.Tag).id;
                jid = ShiKuManager.mSocketCore.CreateGroup(friend.NickName, friend.Description, jid);
                friend.UserId = jid;

                FrmFriendSelect frm = new FrmFriendSelect();

                frm.LoadFriendsData(DepartfriendList);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.AddConfrmListener((disFriend) =>
                {
                    HttpCreateNormalRoom(friend, disFriend);
                });

            }
            else
            {
                selectfriend = new Friend();
                selectfriend.UserId = "roomDepart" + ((DepartmentsItem)Clicknode.Tag).id;
                selectfriend = selectfriend.GetByUserId();
                Messenger.Default.Send(true, UserMyColleague.SEND_Colleage_MSG);
            }
        }
    }
}