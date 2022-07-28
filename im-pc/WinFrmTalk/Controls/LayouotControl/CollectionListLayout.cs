using CCWin.SkinControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinFrmTalk;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Controls.LayouotControl.GroupDomain;
using WinFrmTalk.Controls.LayouotControl.Groups;
using WinFrmTalk.Controls.LayouotControl.Items;
using WinFrmTalk.Helper;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;
using WinFrmTalk.View;

namespace WinFrmTalk
{
    /// <summary>
    /// Ⱥ���б�
    /// </summary>
    public partial class CollectionListLayout : UserControl
    {

        //����1ͼƬ��2��Ƶ��3�ļ���4���֣�5����
        private GroupTabIndex mGroupTab = GroupTabIndex.files;
        private List<HttpFolderData> folderList = null;

        public CollectionListLayout()
        {
            InitializeComponent();

            if (Program.Started)
            {
                //mAdapter = new GroupListAdapter();
                //mAdapter.MouseDown += MouseDownItem;
                flowLayoutPanel1.MouseWheel += View_MouseWheel;
                vScrollBar.MouseWheel += View_MouseWheel;
                this.Load += new System.EventHandler(this.CollectionListLayout_Load);

                Messenger.Default.Register<string>(this, MessageActions.CLEAR_DRAG, item =>
                {
                    dragStart = false;
                });

                RegisterMessenger();
            }
        }



        #region ע��֪ͨ
        private void RegisterMessenger()
        {
            Messenger.Default.Register<string>(this, MessageActions.SearchEventCollec, SearchEvent);
            Messenger.Default.Register<string>(this, MessageActions.MenuEventCollec, Menu_Click);
        }



        #region �����ı��ı�ʱ

        private string lastSearchText = "";

        public void SearchEvent(string currText)
        {
            if (string.IsNullOrEmpty(currText) && string.IsNullOrEmpty(lastSearchText))
            {
                LogUtils.Log("SearchTextChanged null");
                return;
            }

            if (string.Equals(lastSearchText, currText))
            {
                LogUtils.Log("SearchTextChanged Equals");
                return;
            }

            // �����������
            if (string.IsNullOrEmpty(currText) && !string.IsNullOrEmpty(lastSearchText))
            {
                lastSearchText = currText;
                // �ָ�ԭ�б�
                SearchData();
                return;
            }

            lastSearchText = currText;
            if (!string.IsNullOrEmpty(currText))
            {
                // ������������
                SearchData(currText);
                return;
            }
        }

        /// <summary>
        /// �����б�����
        /// </summary>
        public void SearchData(string searchText = "")
        {
            // ���¼�������
            TabLayout_ItemSelected(tabLabel, null);
        }

        #endregion

        private void Menu_Click(string obj)
        {

        }

        #endregion

        private void CollectionListLayout_Load(object sender, EventArgs e)
        {
            tabLayoutPanel1.ItemFocusChanged += TabLayout_ItemFocusChanged;
            tabLayoutPanel1.ItemSelected += TabLayout_ItemSelected;

            collectionToolbar1.BackClick += Label_MouseClick;

            // ����1ͼƬ��2��Ƶ��3�ļ���4���֣�5����
            var v1 = CreateTabItem("�ļ�", 3);
            tabLayoutPanel1.AppendControl(v1, true);

            var v2 = CreateTabItem("��Ƶ", 2);
            tabLayoutPanel1.AppendControl(v2);

            var v3 = CreateTabItem("���", 1);
            tabLayoutPanel1.AppendControl(v3);

            var v4 = CreateTabItem("����", 5);
            tabLayoutPanel1.AppendControl(v4);

            // ���ص�һҳ������
            tabLabel = v1;
            HttpCollectionList("3");
        }


        private Control CreateTabItem(string text, int data)
        {
            var item = new CollectIndicateItem();
            item.BackColor = System.Drawing.Color.FromArgb(230, 229, 229);
            item.Desname = text;
            item.Location = new System.Drawing.Point(0, 0);
            item.Margin = new System.Windows.Forms.Padding(0);
            item.Name = text;
            item.Size = new System.Drawing.Size(52, 52);
            item.Tag = data;
            return item;
        }



        private void TabLayout_ItemFocusChanged(object sender, bool focus)
        {
            var item = sender as CollectIndicateItem;


            if (item.Desname == "�ļ�")
            {
                item.Image = focus ? Resources.ic_collect_tab_f1 : Resources.ic_collect_tab_f0;
            }
            else if (item.Desname == "��Ƶ")
            {
                item.Image = focus ? Resources.ic_collect_tab_v1 : Resources.ic_collect_tab_v0;
            }
            else if (item.Desname == "���")
            {
                item.Image = focus ? Resources.ic_collect_tab_p1 : Resources.ic_collect_tab_p0;
            }
            else if (item.Desname == "����")
            {
                item.Image = focus ? Resources.ic_collect_tab_o1 : Resources.ic_collect_tab_o0;
            }
        }

        private void TabLayout_ItemSelected(object sender, MouseEventArgs e)
        {
            tabLabel = sender as Control;
            var data = Convert.ToString(tabLabel.Tag);

            SetCurrentTab(data);

            ChangeToolbar();

            // ��������
            HttpCollectionList(data, lastSearchText);
        }



        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Label_MouseClick(object sender, EventArgs e)
        {
            if (collectionToolbar1.ItemData.SubFolder)
            {
                var item = new GroupFolderItem();
                item.SetContentData(collectionToolbar1.BaseData);
                Folder_MouseClick(item, null);
            }
            else
            {
                TabLayout_ItemSelected(tabLabel, null);
            }
        }

        /// <summary>
        /// ���ƹ�����
        /// </summary>
        /// <param name="visiable"></param>
        /// <param name="level"></param>
        /// <param name="folderName"></param>
        /// <param name="count"></param>
        private void ChangeToolbar(HttpFolderData folder = null)
        {
            this.SuspendLayout();

            if (folder != null)
            {
                collectionToolbar1.Visible = true;

                collectionToolbar1.SetToolbarData(folder);
                limitPanel.Height = this.Height - 36 - 56;
                limitPanel.Location = new Point(limitPanel.Location.X, 36 + 56);

                vScrollBar.Height = this.Height - 36 - 56;
                vScrollBar.Location = new Point(vScrollBar.Location.X, 36 + 56);
            }
            else
            {
                collectionToolbar1.Visible = false;

                limitPanel.Location = new Point(limitPanel.Location.X, 56);
                limitPanel.Height = this.Height - 56;

                vScrollBar.Location = new Point(vScrollBar.Location.X, 56);
                vScrollBar.Height = this.Height - 56;

            }
            this.ResumeLayout(true);
        }


        private LodingUtils loding;

        /// <summary>
        /// ʹ�õȴ���
        /// </summary>
        private void ShowLoding(Control parent)
        {
            if (loding == null)
            {
                loding = new LodingUtils();
                loding.parent = parent;
                loding.start();
            }
        }

        private void StopLoding()
        {
            if (loding != null)
            {
                loding.stop();
                loding = null;
            }
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <param name="joinFolder"></param>
        private void HttpCollectionList(string type, string key = "", string joinFolder = "")
        {
            ShowLoding(this);

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "community/collectionFile/v2")
                .AddParams("type", type)
                .AddParams("keyword", key)
                .AddParams("fileType", "1")
                .AddParams("pageIndex", "0")
                .AddParams("pageSize", "1000")
                 .Build().ExecuteJson<List<HttpFolderData>>((sccess, dataList) =>
                {

                    if (sccess && dataList != null)
                    {
                        this.folderList = dataList;
                        if (UIUtils.IsNull(joinFolder))
                        {
                            ShowFolderList(dataList, mGroupTab);
                        }
                        else
                        {
                            FindFolderById(dataList, joinFolder, mGroupTab);
                        }
                    }
                    else
                    {
                        this.folderList = null;
                        UpdateListHeight(0);
                    }

                    StopLoding();
                });
        }




        /// <summary>
        /// ��ʾһ���ļ����б���
        /// </summary>
        /// <param name="folders"></param>
        /// <param name="tabIndex"></param>
        private void ShowFolderList(List<HttpFolderData> folders, GroupTabIndex tabIndex)
        {
            this.flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Location = new Point();
            vScrollBar.SetProgress(0);

            int height = 125 + 20, width = 0;
            int type = Convert.ToInt32(GetFolderType(tabIndex));
            foreach (var data in folders)
            {
                data.tabIndex = tabIndex;
                data.type = type;

                var item = CreateFolderItem(data);

                // ���Ҽ��˵�
                item.ContextMenuStrip = folderMenu;

                // �󶨹����¼�
                AddCrlMouseWheel(item);

                width += item.Width + item.Margin.Left;
                if (width > flowLayoutPanel1.Width)
                {
                    width = item.Width + item.Margin.Left;
                    height += item.Height + item.Margin.Top;
                }

                item.MouseDown += Folder_MouseDown;
                this.flowLayoutPanel1.Controls.Add(item);
            }

            UpdateListHeight(height);

            this.flowLayoutPanel1.ResumeLayout();
        }

        /// <summary>
        /// ��ʾ�����ļ����б���
        /// </summary>
        /// <param name="subList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private int ShowSubFolderList(List<HttpFolderData> subList, GroupTabIndex index)
        {
            if (!UIUtils.IsNull(subList))
            {
                Control last = null;

                int height = 125 + 10, width = 0;

                foreach (var sub in subList)
                {
                    sub.tabIndex = index;
                    sub.SubFolder = true;
                    HttpFolderData data = sub;

                    var item = CreateFolderItem(data);

                    // ���Ҽ��˵�
                    item.ContextMenuStrip = folderMenu;

                    // �󶨹����¼�
                    AddCrlMouseWheel(item);

                    width += item.Width + item.Margin.Left;
                    if (width > flowLayoutPanel1.Width)
                    {
                        width = item.Width + item.Margin.Left;
                        height += item.Height + Margin.Top;
                    }

                    item.MouseDown += Folder_MouseDown;
                    this.flowLayoutPanel1.Controls.Add(item);
                    last = item;
                }

                if (last != null)
                {
                    flowLayoutPanel1.SetFlowBreak(last, true);
                }

                return height;
            }

            return 0;
        }

        /// <summary>
        /// ��ʾ�ļ��б���
        /// </summary>
        /// <param name="folder"></param>
        private void ShowFileList(HttpFolderData folder)
        {
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Location = new Point();
            vScrollBar.SetProgress(0);


            int height = ShowSubFolderList(folder.groupUserAlbumList, GroupTabIndex.files);

            if (folder.Count > 0)
            {
                foreach (var data in folder.groupShareList)
                {
                    var item = CreateFilesItem(data);

                    // ���Ҽ��˵�
                    item.ContextMenuStrip = contextMenu;
                    item.MouseDown += Item_MouseDown;
                    item.MouseMove += Item_MouseMove;
                    item.MouseUp += Item_MouseUp;
                    // �󶨹����¼�
                    AddCrlMouseWheel(item);

                    this.flowLayoutPanel1.Controls.Add(item);

                    height += (item.Height + item.Margin.Top);
                }
            }

            UpdateListHeight(height + 10);
            flowLayoutPanel1.ResumeLayout();
        }

        /// <summary>
        /// ������Ƶ����
        /// </summary>
        /// <param name="folder"></param>
        private void ShowVideoList(HttpFolderData folder)
        {
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Location = new Point();
            vScrollBar.SetProgress(0);

            int height = ShowSubFolderList(folder.groupUserAlbumList, GroupTabIndex.video);

            if (!UIUtils.IsNull(folder.groupShareList))
            {
                HashSet<string> times = new HashSet<string>();

                foreach (var data in folder.groupShareList)
                {
                    string time = TimeUtils.FromatTime(data.createTime, "MM-dd");

                    bool header = !times.Contains(time);

                    var item = CreateVideoItem(data, header);

                    // ���Ҽ��˵�
                    item.ContextMenuStrip = contextMenu;
                    item.MouseDown += Item_MouseDown;
                    item.MouseMove += Item_MouseMove;
                    item.MouseUp += Item_MouseUp;
                    // �󶨹����¼�
                    AddCrlMouseWheel(item);

                    this.flowLayoutPanel1.Controls.Add(item);

                    height += (item.Height + item.Margin.Top);

                    if (header)
                    {
                        times.Add(time);
                    }
                }
            }

            UpdateListHeight(height + 20);
            flowLayoutPanel1.ResumeLayout();
        }

        /// <summary>
        /// ����ͼƬ�б���
        /// </summary>
        /// <param name="folder"></param>
        private void ShowImageList(HttpFolderData folder)
        {
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Location = new Point();
            vScrollBar.SetProgress(0);


            int height1 = ShowSubFolderList(folder.groupUserAlbumList, GroupTabIndex.image);

            int height = 130, width = 0;

            if (folder.Count > 0)
            {
                foreach (var photo in folder.groupShareList)
                {
                    var con = CreateImageItem(photo, height == 130);
                    flowLayoutPanel1.Controls.Add(con);

                    // ���Ҽ��˵�
                    con.ContextMenuStrip = contextMenu;

                    // �󶨹����¼�
                    AddCrlMouseWheel(con);

                    con.MouseDown += Item_MouseDown;
                    con.MouseMove += Item_MouseMove;
                    con.MouseUp += Item_MouseUp;


                    width += con.Width + con.Margin.Left;
                    if (width > flowLayoutPanel1.Width)
                    {
                        width = con.Width + con.Margin.Left;
                        height += (con.Height + con.Margin.Top);
                    }
                }
            }

            UpdateListHeight(height + height1 + 10);

            flowLayoutPanel1.ResumeLayout();
        }


        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="dataList"></param>
        private void ShowOtherList(HttpFolderData folder)
        {
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Location = new Point();
            vScrollBar.SetProgress(0);


            int height = ShowSubFolderList(folder.groupUserAlbumList, GroupTabIndex.other);


            if (!UIUtils.IsNull(folder.groupShareList))
            {
                HashSet<string> times = new HashSet<string>();

                foreach (var data in folder.groupShareList)
                {
                    string time = TimeUtils.FromatTime(data.createTime, "MM-dd");

                    bool header = !times.Contains(time);

                    var item = CreateActiveItem(data, header);

                    // ���Ҽ��˵�
                    item.ContextMenuStrip = contextMenu;
                    item.MouseDown += Item_MouseDown;
                    item.MouseMove += Item_MouseMove;
                    item.MouseUp += Item_MouseUp;
                    // �󶨹����¼�
                    AddCrlMouseWheel(item);

                    this.flowLayoutPanel1.Controls.Add(item);

                    height += (item.Height + item.Margin.Top);

                    if (header)
                    {
                        times.Add(time);
                    }
                }
            }

            UpdateListHeight(height + 20);
            flowLayoutPanel1.ResumeLayout();
        }



        #region �����б���

        /// <summary>
        /// �����ļ�����
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Control CreateFolderItem(HttpFolderData data)
        {
            var item = new GroupFolderItem();
            item.SetContentData(data);
            item.MouseClick += Folder_MouseClick;
            item.Margin = new Padding(4, 10, 0, 0);
            item.Tag = data;
            if (UIUtils.IsNull(data.folderId))
            {
                item.Name = "0";
            }
            else
            {
                item.Name = data.folderId;
            }

            item.AccessibleDescription = data.folderName;
            return item;
        }



        /// <summary>
        /// �����ļ���
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>

        public Control CreateFilesItem(GroupFilesx data)
        {
            var item = new WinFrmTalk.Controls.LayouotControl.Items.GroupFileItem();

            if (UIUtils.IsNull(data.DisplayName))
            {
                data.fileName = FileUtils.GetFileName(data.url);
            }

            item.Size = new Size(245, 105);
            item.SetContentData(data, true);
            item.Margin = new Padding(10, 20, 0, 0);

            item.AccessibleDescription = data.url;
            item.AccessibleName = data.DisplayName;
            item.Tag = data;
            item.MouseClick += File_MouseClick;
            item.Name = data.emojiId;
            item.BackColor = System.Drawing.Color.FromArgb(230, 229, 229);
            return item;
        }

        /// <summary>
        /// ������Ƶ��
        /// </summary>
        /// <param name="data"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public Control CreateVideoItem(GroupFilesx data, bool header)
        {
            var item = new CollectVideoItem();

            item.SetContentData(data, header);

            if (header)
            {
                item.Margin = new Padding(10, 10, 0, 0);
            }
            else
            {
                item.Margin = new Padding(10, 0, 0, 0);
            }

            item.Tag = data;
            item.AccessibleDescription = data.url;
            item.AccessibleName = data.fileSize.ToString();
            item.MouseClick += Video_MouseClick;
            item.Name = data.emojiId;
            item.BackColor = System.Drawing.Color.FromArgb(230, 229, 229);
            return item;
        }



        /// <summary>
        /// ������Ƭ��
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        private Control CreateImageItem(GroupFilesx photo, bool topLine)
        {
            var item = new GroupImageItem();
            item.Size = new Size(78, 110);
            item.SetContentData(photo);
            item.MouseClick += Image_MouseClick;
            if (topLine)
            {
                item.Margin = new Padding(8, 15, 0, 0);
            }
            else
            {
                item.Margin = new Padding(8, 5, 0, 0);
            }

            item.Tag = photo;
            item.AccessibleDescription = photo.url;
            item.Name = photo.emojiId;
            item.MouseClick += Image_MouseClick;

            return item;
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="data"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public Control CreateActiveItem(GroupFilesx data, bool header)
        {
            var item = new CollectActiveItem();
            item.Tag = data;
            item.ListWidth = flowLayoutPanel1.Width - 20;
            item.SetContentData(data, header);

            if (header)
            {
                item.Margin = new Padding(10, 20, 0, 0);
            }
            else
            {
                item.Margin = new Padding(10, 0, 0, 0);
            }

            item.Tag = data;

            item.MouseClick += Other_MouseClick;
            item.Name = data.emojiId;
            item.BackColor = System.Drawing.Color.FromArgb(230, 229, 229);
            return item;

        }









        #endregion


        #region ���ӿؼ���ӹ����¼�
        private void AddCrlMouseWheel(Control crl)
        {
            crl.MouseWheel += View_MouseWheel;

            AddCrlMouseWheelList(crl.Controls);
        }

        private void AddCrlMouseWheelList(Control.ControlCollection controls)
        {
            if (controls == null)
            {
                return;
            }

            foreach (Control item in controls)
            {

                AddCrlMouseWheel(item);
            }
        }


        /// <summary>
        /// ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_MouseWheel(object sender, MouseEventArgs e)
        {

            if (flowLayoutPanel1.Height <= limitPanel.Height)
            {
                return;
            }

            int totleHeight = flowLayoutPanel1.Height - limitPanel.Height;


            int movey = e.Delta > 0 ? 40 : -40;

            if (flowLayoutPanel1.Location.Y + movey > 0)
            {
                movey = -flowLayoutPanel1.Location.Y;
            }
            else if (flowLayoutPanel1.Location.Y + movey < -totleHeight)
            {
                movey = Math.Abs(flowLayoutPanel1.Location.Y) - totleHeight;
            }


            // �ƶ�panel
            ModifyLocation(flowLayoutPanel1, movey, false);

            // ͬ��������
            var pro = Math.Abs(flowLayoutPanel1.Location.Y) / (float)totleHeight * 100;
            vScrollBar.SetProgress((int)pro);
        }


        /// <summary>
        /// �޸Ŀؼ�λ��
        /// </summary>
        /// <param name="control"></param>
        /// <param name="loc_y"></param>
        /// <param name="abs">�Ƿ��������</param>
        private void ModifyLocation(Control control, int loc_y, bool abs = true)
        {
            Point point = control.Location;

            if (abs)
            {
                point.Y = loc_y;
            }
            else
            {
                point.Y = point.Y + loc_y;
            }

            control.Location = point;
        }

        private int last_progress;

        private void VScrollBar_ScrollChangeListener()
        {
            if (vScrollBar.Value == last_progress)
            {
                return;
            }

            if (limitPanel.Height > flowLayoutPanel1.Height)
            {
                return;
            }


            last_progress = vScrollBar.Value;


            float max = flowLayoutPanel1.Height - limitPanel.Height;

            int movey = Convert.ToInt32(last_progress / 100f * max * -1);

            // �ƶ�panel
            ModifyLocation(flowLayoutPanel1, movey, true);
        }

        #endregion



        #region ��ק

        private bool dragStart = false;
        private DragFileData dragData = null;
        private void Item_MouseMove(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Item_MouseMove" + dragStart);
            if (dragStart && dragData != null)
            {
                dragStart = false;
                var effect = mSelectControl.DoDragDrop(dragData, DragDropEffects.All | DragDropEffects.Copy);
            }
        }

        private void Item_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Item_MouseUp" + dragStart);
            dragStart = false;
        }

        #endregion


        #region �Ҽ��˵�

        private Control mSelectControl = null;

        public Control tabLabel { get; private set; }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            mSelectControl = sender as Control;
            //���²˵���https://imuploadqn-test.tnshow.com/u/124/10000124/202202/copy/e4af279b10964ba9a16718fcdc1e57ca.pdf
            UpdateMenuStrip(ref contextMenu, mGroupTab);

            dragStart = false;

            if (e.Button == MouseButtons.Left)
            {
                dragStart = true;
                Console.WriteLine("Item_MouseDown" + dragStart);

                DragFileData dragFileData = new DragFileData();

                switch (mGroupTab)
                {
                    case GroupTabIndex.other:
                        var res = mSelectControl as Controls.LayouotControl.Items.CollectActiveItem;
                        if (res != null)
                        {
                            dragFileData.type = res.ItemData.toMessageType(res.ResType);
                            dragFileData.other = res.ItemData.toJsonString(res.ResType);
                        }
                        break;
                    case GroupTabIndex.files:
                        var file = mSelectControl as Controls.LayouotControl.Items.GroupFileItem;
                        dragFileData.type = kWCMessageType.File;
                        dragFileData.url = file.AccessibleDescription;
                        dragFileData.path = file.AccessibleName;
                        dragFileData.size = Convert.ToInt64(file.fileSize);
                        break;
                    case GroupTabIndex.video:
                        var video = mSelectControl as CollectVideoItem;
                        dragFileData.type = kWCMessageType.Video;
                        dragFileData.url = video.itemData.url;
                        dragFileData.path = video.itemData.DisplayName;
                        dragFileData.size = Convert.ToInt64(video.itemData.fileSize);
                        break;
                    case GroupTabIndex.image:
                        var url = mSelectControl.AccessibleDescription;
                        dragFileData.type = kWCMessageType.Image;
                        dragFileData.url = url;
                        dragFileData.path = FileUtils.GetFileName(url);
                        dragFileData.size = 0;
                        break;
                }

                if (UIUtils.IsNull(dragFileData.url) && UIUtils.IsNull(dragFileData.other))
                {
                    dragData = null;
                    dragStart = false;
                }
                else
                {
                    dragData = dragFileData;
                }
            }
        }

        /// <summary>
        /// ���õ�ǰѡ����
        /// </summary>
        /// <param name="data">����1��ᣬ2��Ƶ��3�ļ���4���֣�5����</param>
        private void SetCurrentTab(string data)
        {
            switch (data)
            {
                case "1":
                    mGroupTab = GroupTabIndex.image;
                    break;
                case "2":
                    mGroupTab = GroupTabIndex.video;
                    break;
                case "3":
                    mGroupTab = GroupTabIndex.files;
                    break;
                case "5":
                case "0":
                default:
                    mGroupTab = GroupTabIndex.other;
                    break;
            }
        }



        private void UpdateMenuStrip(ref SkinContextMenuStrip contextMenuScript, GroupTabIndex type)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                item.Visible = true;
            }

            var id = collectionToolbar1.ItemData.folderId;
            menuItem_Floder.Enabled = !UIUtils.IsNull(id);


            RefreshMoveSubMenu(menuItem_Moveto, collectionToolbar1.ItemData.folderId, false);

            menuItem_Open.Text = "��";

            switch (type)
            {
                case GroupTabIndex.files:
                    menuItem_Emoji.Visible = false;
                    break;
                case GroupTabIndex.video:
                    menuItem_Open.Text = "��������";
                    menuItem_Emoji.Visible = false;
                    break;
                case GroupTabIndex.image:
                    menuItem_Emoji.Visible = true;
                    break;
                case GroupTabIndex.other:
                    menuItem_Emoji.Visible = false;
                    menuItem_SaveAs.Visible = false;
                    separator_three.Visible = false;
                    break;
            }
        }


        // ��
        private void menuItem_Open_Click(object sender, EventArgs e)
        {

            switch (mGroupTab)
            {
                case GroupTabIndex.files:
                    File_MouseClick(mSelectControl, null);
                    break;
                case GroupTabIndex.video:
                    Video_MouseClick(mSelectControl, null);
                    break;
                case GroupTabIndex.image:
                    Image_MouseClick(mSelectControl, null);
                    break;
                case GroupTabIndex.other:
                    Other_MouseClick(mSelectControl, null);
                    break;
            }
        }

        // ����
        private void menuItem_Copy_Click(object sender, EventArgs e)
        {
            string url = mSelectControl.AccessibleDescription;
            string localPath = Applicate.LocalConfigData.FileFolderPath + mSelectControl.AccessibleName;

            switch (mGroupTab)
            {
                case GroupTabIndex.files:
                    url = mSelectControl.AccessibleDescription;
                    localPath = Applicate.LocalConfigData.FileFolderPath + mSelectControl.AccessibleName;
                    break;
                case GroupTabIndex.image:
                    url = Convert.ToString(mSelectControl.AccessibleDescription);
                    localPath = Applicate.LocalConfigData.ImageFolderPath + FileUtils.GetFileName(url);
                    break;
                case GroupTabIndex.video:
                    url = Convert.ToString(mSelectControl.AccessibleDescription);
                    localPath = Applicate.LocalConfigData.VideoFolderPath + FileUtils.GetFileName(url);
                    break;
                case GroupTabIndex.other:
                    var item = mSelectControl as CollectActiveItem;
                    var data = item.Tag as GroupFilesx;
                    if (data.collectType == 5)
                    {
                        Clipboard.SetText(string.Format(data.msg));
                    }
                    else
                    {
                        Clipboard.SetText(string.Format("http://hr.tnshow.com/active.html?id={0}", data.emojiId));
                    }

                    return;
                default:

                    return;
            }

            if (File.Exists(localPath))
            {
                StringCollection strcoll = new StringCollection { localPath };
                Clipboard.SetFileDropList(strcoll);
                HttpUtils.Instance.ShowTip("���Ƴɹ�");
            }
            else
            {
                //�����ļ�
                DownloadEngine.Instance.DownUrl(url).SavePath(localPath)
                    .Down((path) =>
                    {
                        if (File.Exists(path))
                        {
                            StringCollection strcoll = new StringCollection { path };
                            Clipboard.SetFileDropList(strcoll);
                            HttpUtils.Instance.ShowTip("���Ƴɹ�");
                        }
                        else
                        {
                            HttpUtils.Instance.ShowTip("����ʧ��");
                        }
                    });
            }
        }

        // ת��
        private void menuItem_Forward_Click(object sender, EventArgs e)
        {
            MessageObject messageObject = null;

            switch (mGroupTab)
            {
                case GroupTabIndex.active:
                    return;
                case GroupTabIndex.other:
                    var res = mSelectControl as Controls.LayouotControl.Items.CollectActiveItem;
                    if (res != null)
                    {
                        if (res.ResType == ResourcexType.msg)
                        {
                            messageObject = ShiKuManager.SendTextMessage(new Friend(), res.ItemData.collectContent, false, false);
                        }
                        else
                        {
                            messageObject = ShiKuManager.SendCollectMessage(new Friend(), res.ResType, res.ItemData, false, false);
                        }
                    }
                    break;
                case GroupTabIndex.files:
                    var file = mSelectControl as Controls.LayouotControl.Items.GroupFileItem;
                    messageObject = ShiKuManager.SendFileMessage(new Friend(), file.AccessibleDescription, file.AccessibleName, Convert.ToInt64(file.fileSize), false, false);
                    break;
                case GroupTabIndex.video:
                    var video = mSelectControl as CollectVideoItem;
                    messageObject = ShiKuManager.SendVideoMessage(new Friend(), video.itemData.url, video.itemData.title, Convert.ToInt64(video.itemData.fileSize), false, false);
                    break;
                case GroupTabIndex.image:
                    var url = mSelectControl.AccessibleDescription;
                    messageObject = ShiKuManager.SendImageMessage(new Friend(), url, FileUtils.GetFileName(url), 0, false, false);
                    break;
            }

            //ѡ��ת���ĺ���
            var frmFriendSelect = new FrmSortSelect();
            frmFriendSelect.LoadFriendsData(true, true, true, true, true);
            frmFriendSelect.Show();
            frmFriendSelect.AddConfrmListener((UserFriends) =>
            {
                Invoke(new Action(() =>
                {
                    var frmSchedule = new FrmSchedule(UserFriends, (fd) =>
                    {
                        if (fd.IsGroup == 1)
                        {

                            RoomMember roomMember = new RoomMember { roomId = fd.RoomId, userId = Applicate.MyAccount.userId };
                            roomMember = roomMember.GetRoomMember();

                            if (roomMember.role == 3)
                            {
                                //�Ƿ�ȫ�����
                                string all = LocalDataUtils.GetStringData(fd.UserId + "BANNED_TALK_ALL" + Applicate.MyAccount.userId, "0");
                                //����Ա��Ⱥ������
                                if (!"0".Equals(all))
                                {
                                    // ȫ�����
                                    HttpUtils.Instance.ShowTip("����ת����Ϣ��ȫ�����Ⱥ");
                                    return;
                                }

                                string single = LocalDataUtils.GetStringData(fd.UserId + "BANNED_TALK" + Applicate.MyAccount.userId, "0");
                                //�Ƿ񵥸�����
                                if (!"0".Equals(single))
                                {
                                    HttpUtils.Instance.ShowTip("���ѱ���ֹ�ڴ�Ⱥ����");
                                    return;
                                }
                            }


                            if (roomMember.role == 4)
                            {
                                HttpUtils.Instance.ShowTip("���ڴ�ȺΪ�����ˣ����ܷ�����Ϣ");
                                return;
                            }
                        }

                        //���ΪȺ�飬�Լ�Ϊ�����˻��߱�����
                        MessageObject msg = ShiKuManager.SendForwardMessage(fd, messageObject);

                    }, false);
                    frmSchedule.Show();
                }
                ));

            });
        }


        // ɾ��
        private void menuItem_Deletion_Click(object sender, EventArgs e)
        {
            string emojiId = mSelectControl.Name;
            string type = GetFolderType(mGroupTab, true);

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/deleteUserGroupShare")
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("emojiId", emojiId)
                .AddParams("type", type)
                .Build().Execute((sccess, dataList) =>
                {
                    if (sccess)
                    {
                        // ����1ͼƬ��2��Ƶ��3�ļ���4���֣�5����
                        // ˢ�½���
                        if (flowLayoutPanel1.Controls.ContainsKey(emojiId))
                        {
                            flowLayoutPanel1.Controls.RemoveByKey(emojiId);
                        }
                    }
                });
        }




        // ���Ϊ
        private void menuItem_SaveAs_Click(object sender, EventArgs e)
        {
            string url = "";
            string localPath = "";

            switch (mGroupTab)
            {
                case GroupTabIndex.other:
                    return;
                case GroupTabIndex.active:
                    return;
                case GroupTabIndex.files:
                    url = mSelectControl.AccessibleDescription;
                    localPath = Applicate.LocalConfigData.FileFolderPath + mSelectControl.AccessibleName;
                    break;
                case GroupTabIndex.video:
                    url = mSelectControl.AccessibleDescription;
                    localPath = Applicate.LocalConfigData.VideoFolderPath + FileUtils.GetFileName(url);
                    break;
                case GroupTabIndex.image:
                    url = mSelectControl.AccessibleDescription;
                    localPath = Applicate.LocalConfigData.ImageFolderPath + FileUtils.GetFileName(url);
                    break;
            }


            string filename = FileUtils.GetFileName(localPath);

            //ѡ���ļ���·��
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "���Ϊ..",
                FileName = filename,
                Filter = @"�����ļ�|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //�ļ��ı���·��
                var savepage = dialog.FileName;
                if (string.IsNullOrEmpty(savepage))
                    return;

                if (File.Exists(localPath))
                {
                    var frm = this.FindForm() as FrmBase;
                    frm.ShowTip("���Ϊ�ɹ�:" + savepage);
                    File.Copy(localPath, savepage, true);
                    return;
                }

                //�����ļ�
                DownloadEngine.Instance.DownUrl(url).SavePath(savepage)
                    .Down((path) =>
                    {
                        HttpUtils.Instance.ShowTip("���Ϊ�ɹ�:" + path);
                    });
            }
        }

        // �����
        private void menuItem_Emoji_Click(object sender, EventArgs e)
        {
            var url = Convert.ToString(mSelectControl.AccessibleDescription);
            // �����
            var msg = new MessageObject();
            msg.messageId = Guid.NewGuid().ToString("N");//����Guid
            msg.type = kWCMessageType.Image;
            msg.content = url;

            CollectUtils.CollectExpression(msg);
        }

        #endregion

        #region �ļ����Ҽ��˵�

        private void Folder_MouseDown(object sender, MouseEventArgs e)
        {
            mSelectControl = sender as Control;
            var item = sender as GroupFolderItem;

            bool ismove = item.itemData.SubFolder;

            btnCreate.Visible = !ismove;
            toolStripSeparator3.Visible = !ismove;
            btnMoveto.Visible = ismove;

            var id = collectionToolbar1.FolderId;
            btnCreate.Enabled = !UIUtils.IsNull(id);

            if (ismove)
            {
                RefreshMoveSubMenu(btnMoveto, item.itemData.folderId, true);
            }
        }


        /// <summary>
        /// ˢ���ƶ����˵�
        /// </summary>
        public void RefreshMoveSubMenu(ToolStripMenuItem baseItem, string folderId, bool isFolder)
        {
            baseItem.DropDownItems.Clear();

            if (!UIUtils.IsNull(this.folderList))
            {
                foreach (var item in folderList)
                {
                    var sub = CreateSubMenuItem(item, folderId, isFolder);
                    if (sub != null)
                    {
                        baseItem.DropDownItems.Add(sub);

                        if (!isFolder && item.SubCount > 0)
                        {
                            foreach (var item1 in item.groupUserAlbumList)
                            {
                                var sub1 = CreateSubMenuItem(item1, folderId, isFolder);
                                if (sub1 != null)
                                {
                                    sub.DropDownItems.Add(sub1);
                                }
                            }
                        }
                    }
                }
            }
        }

        public ToolStripMenuItem CreateSubMenuItem(HttpFolderData data, string folderId, bool isFolder)
        {
            // ��Դ���������ļ������ƶ�
            if (UIUtils.IsNull(data.folderId))
            {
                return null;
            }

            ToolStripMenuItem mnuPrintPageSet = new ToolStripMenuItem(data.folderName);
            mnuPrintPageSet.Name = data.folderId;
            mnuPrintPageSet.Text = data.folderName;
            mnuPrintPageSet.Click += menuItem_MoveAs_Click;
            return mnuPrintPageSet;
        }

        // �ƶ���
        private void menuItem_MoveAs_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (mSelectControl is GroupFolderItem folder)
            {
                HttpMovetoFolder(folder.itemData.folderId, item.Name, Convert.ToString(folder.itemData.type), true);
            }
            else
            {
                // Ⱥ�ļ������� 1Ⱥ�ļ� 2Ⱥ��Ƶ 3ȺͼƬ 4������ 5��� �����ļ��� 1001Ⱥ�ļ� 1002Ⱥ��Ƶ 1003ȺͼƬ 1004������ 1005���
                if (mSelectControl.Tag is GroupFilesx filex)
                {
                    var type = GetFolderType(mGroupTab, true);
                    HttpMovetoFolder(filex.emojiId, item.Name, type, false);
                }
            }
        }

        /// <summary>
        /// ���ļ���
        /// </summary>
        private void menuItem_OpenFolder_Click(object sender, EventArgs e)
        {
            Folder_MouseClick(mSelectControl, null);
        }


        // �½��ļ���
        private void menuItem_Folder_Click(object sender, EventArgs e)
        {
            if (Applicate.GetWindow<FrmMyColleagueEidt>() != null)
            {
                Applicate.GetWindow<FrmMyColleagueEidt>().Activate();
                Applicate.GetWindow<FrmMain>().ShowTip("�����Ѵ�");
                return;
            }

            // �����ļ�id
            string folderId = "";
            if (collectionToolbar1.Visible && collectionToolbar1.ItemData != null)
            {
                folderId = collectionToolbar1.ItemData.folderId;
            }

            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();
            frm.maxLength = 20;
            frm.AccessibleDescription = folderId;
            frm.ColleagueName((text) =>
            {
                HttpCreateFolder(text, mGroupTab, frm.AccessibleDescription);
                frm.Close();
            });
            string title = "�����ļ���";
            string name = "�ļ�������:";

            var baseFrm = this.FindForm();
            frm.Location = new Point((baseFrm.Location.X + (baseFrm.Width - frm.Width) / 2), baseFrm.Location.Y + (baseFrm.Height - frm.Height) / 2);
            frm.ShowThis(title, name);
        }

        // �������ļ���
        private void menuItem_Rename_Click(object sender, EventArgs e)
        {
            var item = mSelectControl as GroupFolderItem;
            var data = item.itemData;
            var baseFrm = FindForm() as FrmBase;


            if (UIUtils.IsNull(data.folderId))
            {
                baseFrm.ShowTip("�����޸�Ĭ���ļ��е�����");
                return;
            }

            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();
            frm.maxLength = 20;
            frm.ColleagueName((text) =>
            {
                HttpUpdateFolder(data.folderId, text, mGroupTab);
                frm.Close();
            });
            string title = "�޸��ļ���";
            string name = "�ļ�������";
            frm.Location = new Point((baseFrm.Location.X + (baseFrm.Width - frm.Width) / 2), baseFrm.Location.Y + (baseFrm.Height - frm.Height) / 2);
            frm.ShowThis(title, name, data.folderName);
        }

        // ɾ���ļ���
        private void menuItem_Delete_Click(object sender, EventArgs e)
        {
            var item = mSelectControl as GroupFolderItem;
            var data = item.itemData;
            var frm = FindForm() as FrmBase;

            if (UIUtils.IsNull(data.folderId))
            {
                frm.ShowTip("Ĭ���ļ��в���ɾ��");
                return;
            }

            var text = string.Format("ȷ��Ҫɾ��{0}�ļ��к��ļ����е�����������?", data.folderName);
            if (frm.ShowPromptBox(text))
            {
                HttpDeleteFolder(data.folderId);
            }
        }

        /// <summary>
        /// �ļ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Detail_Click(object sender, EventArgs e)
        {
            var item = mSelectControl as GroupFolderItem;

            var frm = Applicate.GetWindow<FrmDetailsFolder>();
            if (frm == null)
            {
                frm = new FrmDetailsFolder();
                frm.SetContentData(item, 0, true);
                frm.Show();
            }
            else
            {
                frm.SetContentData(item, 0, true);
                frm.Show();
            }
        }

        #endregion

        #region ��


        /// <summary>
        /// ���ļ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Folder_MouseClick(object sender, MouseEventArgs e)
        {

            if (e != null && e.Button == MouseButtons.Right)
            {
                mSelectControl = sender as Control;
                return;
            }

            var folder = sender as GroupFolderItem;

            ChangeToolbar(folder.itemData);

            // ��ʾ����
            if (folder.tabIndex == GroupTabIndex.other)
            {
                ShowOtherList(folder.itemData);
            }
            else if (folder.tabIndex == GroupTabIndex.files)
            {
                ShowFileList(folder.itemData);
            }
            else if (folder.tabIndex == GroupTabIndex.video)
            {
                ShowVideoList(folder.itemData);
            }
            else if (folder.tabIndex == GroupTabIndex.image)
            {
                ShowImageList(folder.itemData);
            }
        }


        /// <summary>
        /// ���ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void File_MouseClick(object sender, MouseEventArgs e)
        {
            if (e != null && e.Button == MouseButtons.Right)
            {
                mSelectControl = sender as Control;
                return;
            }

            var item = sender as Control;

            string url = item.AccessibleDescription;
            string localPath = Applicate.LocalConfigData.FileFolderPath + item.AccessibleName;

            OpenFile(url, localPath);
        }


        /// <summary>
        /// ����Ƶ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Video_MouseClick(object sender, MouseEventArgs e)
        {
            if (e != null && e.Button == MouseButtons.Right)
            {
                mSelectControl = sender as Control;
                return;
            }

            var item = sender as Control;
            var url = Convert.ToString(item.AccessibleDescription);

            var messageObject = new MessageObject() { content = url };
            FrmVideoFlash frmVideoFlash = FrmVideoFlash.CreateInstrance();
            frmVideoFlash.noVolumn = e == null;
            frmVideoFlash.VidoShowList(messageObject, false);
            frmVideoFlash.Show();
        }






        /// <summary>
        /// ��ͼƬ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Image_MouseClick(object sender, MouseEventArgs e)
        {
            if (e != null && e.Button == MouseButtons.Right)
            {
                mSelectControl = sender as Control;
                return;
            }

            var item = (Control)sender;
            FrmLookImage look = new FrmLookImage();
            string url = Convert.ToString(item.AccessibleDescription);
            look.pictureBox1_SetImage(url, false);
        }


        /// <summary>
        /// �������Դ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Other_MouseClick(object sender, MouseEventArgs e)
        {
            var item = sender as CollectActiveItem;
            var data = item.Tag as GroupFilesx;

            if (data != null)
            {
                if (data.collectType == 5 || data.collectType == 0)
                {
                    // ����
                    CollectionSave noti = item.toCollection();
                    Messenger.Default.Send(noti, MessageActions.ShowGroupNotify);
                }
                else if (data.collectType == 4)
                {
                    // �
                    if (data.collectContent != null)
                    {
                        MyGroupActivity activity = JsonConvert.DeserializeObject<MyGroupActivity>(data.collectContent);
                        Messenger.Default.Send(activity.id, MessageActions.ShowGroupActive);
                    }
                    else
                    {
                        Messenger.Default.Send(data.emojiId, MessageActions.ShowGroupActive);
                    }
                }
                else if (data.collectType == 3)
                {
                    // ��Դ��Ϣ
                    try
                    {
                        var resourc = JsonConvert.DeserializeObject<MyGroupResource>(data.collectContent);
                        Messenger.Default.Send(resourc.id, MessageActions.ShowGroupResource);
                    }
                    catch (Exception)
                    {
                        var resourc = data.emojiId;
                        Messenger.Default.Send(resourc, MessageActions.ShowGroupResource);
                    }

                }
                else if (data.collectType == 2)
                {
                    // ���

                    try
                    {
                        var resourc = JsonConvert.DeserializeObject<MyGroupResource>(data.collectContent);
                        Messenger.Default.Send(resourc.id, MessageActions.ShowGroupSocial);
                    }
                    catch (Exception)
                    {
                        var resourc = data.emojiId;
                        Messenger.Default.Send(resourc, MessageActions.ShowGroupSocial);
                    }

                }
            }

        }



        private void OpenFile(string url, string localPath)
        {
            if (File.Exists(localPath))
            {
                try
                {
                    var frm = this.FindForm() as FrmBase;
                    frm.ShowTip("�ļ�����...");
                    //���ļ�
                    System.Diagnostics.Process.Start(localPath);
                }
                catch (Exception)
                {
                    HttpUtils.Instance.ShowTip("���ܴ򿪴������ļ�");
                }
            }
            else
            {

                var frm = this.FindForm() as FrmBase;
                frm.ShowTip("�ļ���������...");

                //�����ļ�
                DownloadEngine.Instance.DownUrl(url)
                .SavePath(localPath)
                .Down((path) =>
                {

                    var frm1 = this.FindForm() as FrmBase;

                    if (string.IsNullOrEmpty(path))
                    {
                        frm1.ShowTip("�ļ�����ʧ��");
                        return;
                    }
                    else
                    {
                        frm.ShowTip("�ļ�����...");
                        //���ļ�
                        System.Diagnostics.Process.Start(localPath);
                    }

                });
            }

        }
        #endregion


        #region ���ļ��еĲ���

        /// <summary>
        /// �����ļ���
        /// </summary>
        /// <param name="floderId">���ļ��е�ID</param>
        /// <param name="floderName"></param>
        /// <param name="roomType">Ⱥ�ļ������� 1Ⱥ�ļ� 2Ⱥ��Ƶ 3ȺͼƬ 4������ 5���  �����ļ��� 1001Ⱥ�ļ� 1002Ⱥ��Ƶ 1003ȺͼƬ 1004������ 1005��� </param>
        /// <param name=""></param>
        private void HttpCreateFolder(string floderName, GroupTabIndex index, string floderId = "")
        {
            //   [{"shareId":"","folderId":"","folderName":"�ļ���1","type":1,"parentFolderId"��"","opType":1}]
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("opType", "1");
            data.Add("folderName", floderName);
            data.Add("type", GetFolderType(index, true));

            if (!UIUtils.IsNull(floderId))
            {
                data.Add("parentFolderId", floderId);
            }

            string text = string.Format("[{0}]", JsonConvert.SerializeObject(data));
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/updateUserFolder/v2")
                .AddParams("folders", text)
                .Build().Execute((sccess, dataList) =>
                {
                    if (sccess)
                    {
                        // ������
                        var baseFrm = this.FindForm() as FrmBase;
                        baseFrm.ShowTip("�����ļ��гɹ�");

                        // ˢ��ҳ��
                        string type = GetFolderType(mGroupTab, true);
                        HttpCollectionList(type, "", floderId);
                    }
                });
        }

        /// <summary>
        /// �޸��ļ�������
        /// </summary>
        /// <param name="floderName"></param>
        /// <param name="floderId"></param>
        /// <param name="index"></param>
        private void HttpUpdateFolder(string floderId, string floderName, GroupTabIndex index)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("opType", "2");
            data.Add("folderName", floderName);
            data.Add("roomType", GetFolderType(index, true));
            data.Add("folderId", floderId);

            string text = string.Format("[{0}]", JsonConvert.SerializeObject(data));
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/updateUserFolder/v2")
                .AddParams("folders", text)
                .Build().Execute((sccess, dataList) =>
                {
                    if (sccess)
                    {
                        if (flowLayoutPanel1.Controls.ContainsKey(floderId))
                        {
                            var item = flowLayoutPanel1.Controls[floderId] as GroupFolderItem;
                            item.itemData.folderName = floderName;
                            item.SetContentData(item.itemData);
                        };

                        var baseFrm = this.FindForm() as FrmBase;
                        baseFrm.ShowTip("�޸ĳɹ�");
                    }
                });
        }



        /// <summary>
        /// ɾ���ļ���
        /// </summary>
        /// <param name="floderId"></param>
        /// <param name="type"></param>
        private void HttpDeleteFolder(string floderId)
        {
            // ɾ���ļ���
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/deleteUserFolder")
                .AddParams("folderId", floderId)
                .Build().Execute((sccess, dataList) =>
                {
                    if (sccess)
                    {
                        if (flowLayoutPanel1.Controls.ContainsKey(floderId))
                        {
                            var item = flowLayoutPanel1.Controls[floderId];
                            flowLayoutPanel1.Controls.Remove(item);
                        };

                        var baseFrm = this.FindForm() as FrmBase;
                        baseFrm.ShowTip("ɾ���ɹ�");
                    }
                });
        }


        /// <summary>
        /// �ƶ��ļ���
        /// </summary>
        /// <param name="floderId"></param>
        /// <param name="type"></param>
        private void HttpMovetoFolder(string fromId, string toId, string type, bool isFolderMove)
        {
            var baseFrm = this.FindForm() as FrmBase;

            if (fromId == toId)
            {
                baseFrm.ShowTip("�޷��ƶ�����ͬ���ļ���");
                return;
            }

            if (isFolderMove && !baseFrm.ShowPromptBox("���ļ��к��ļ����е����ݽ���һ���ƶ����Ƿ�ȷ���ƶ���"))
            {
                return;
            }

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("opType", isFolderMove ? "4" : "3");
            data.Add(isFolderMove ? "parentFolderId" : "folderId", toId);
            data.Add(isFolderMove ? "folderId" : "shareId", fromId);
            data.Add("type", type);

            string text = string.Format("[{0}]", JsonConvert.SerializeObject(data));

            // �ƶ��ļ���
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/updateUserFolder/v2")
                .AddParams("folders", text)
                .Build().Execute((sccess, dataList) =>
                {
                    if (sccess)
                    {
                        // ������
                        var frm = this.FindForm() as FrmBase;
                        if (isFolderMove)
                        {
                            frm.ShowTip("�ļ����ƶ��ɹ�");
                        }
                        else
                        {
                            frm.ShowTip("�����ƶ��ɹ�");
                        }

                        // ˢ��ҳ��

                        string folderId = "";
                        if (collectionToolbar1.Visible && collectionToolbar1.ItemData != null)
                        {
                            folderId = collectionToolbar1.ItemData.folderId;
                        }
                        HttpCollectionList(type, "", folderId);
                    }
                });
        }


        #endregion


        private string GetFolderType(GroupTabIndex index, bool http = false)
        {
            // ����1ͼƬ��2��Ƶ��3�ļ���4���֣�5����
            switch (index)
            {
                case GroupTabIndex.files:
                    return "3";
                case GroupTabIndex.video:
                    return "2";
                case GroupTabIndex.image:
                    return "1";
                case GroupTabIndex.other:
                    return http ? "5" : "0";
                default:
                    return "0";
            }

        }

        private void FindFolderById(List<HttpFolderData> dataList, string joinFolder, GroupTabIndex tab)
        {
            foreach (var item in dataList)
            {
                if (item.folderId == joinFolder)
                {
                    item.tabIndex = tab;
                    var view = new GroupFolderItem();
                    view.SetContentData(item);
                    Folder_MouseClick(view, null);
                    return;
                }

                if (!UIUtils.IsNull(item.groupUserAlbumList))
                {
                    foreach (var album in item.groupUserAlbumList)
                    {
                        if (album.folderId == joinFolder)
                        {
                            album.tabIndex = tab;
                            var view = new GroupFolderItem();
                            view.SetContentData(album);
                            Folder_MouseClick(view, null);
                        }
                    }
                }
            }
        }

        private void UpdateListHeight(int height)
        {
            if (height > 0 && flowLayoutPanel1.Controls.Count > 0)
            {
                flowLayoutPanel1.Height = height;
                vScrollBar.Visible = flowLayoutPanel1.Height > limitPanel.Height;

            }
            else
            {
                vScrollBar.Visible = false;
                // ��ʾ��ҳ��
                var empty = CreateEmptyTip();
                flowLayoutPanel1.Controls.Add(empty);
                flowLayoutPanel1.Height = limitPanel.Height - 1;
            }
        }

        public Control CreateEmptyTip()
        {
            var item = new Label();
            item.AutoSize = false;
            item.Font = new System.Drawing.Font("΢���ź�", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            item.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            item.Name = "item";
            item.Size = new System.Drawing.Size(74, 21);
            item.Text = "��������";
            item.Margin = new System.Windows.Forms.Padding((limitPanel.Width - 74) / 2, (limitPanel.Height - 21) / 2, 0, 0);
            item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return item;
        }

        private void skinContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // �ļ���ID

            var id = collectionToolbar1.FolderId;
            toolStripMenuItem4.Visible = !UIUtils.IsNull(id);

        }
    }

}


[Serializable]
public class DragFileData
{
    public string path = "";
    public long size = 0;
    public string url = "";
    public kWCMessageType type;
    public string other = "";
}