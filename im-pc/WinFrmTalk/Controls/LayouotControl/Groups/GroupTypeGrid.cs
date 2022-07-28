using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Controls.SystemControls;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    /// <summary>
    /// 群分类
    /// </summary>
    public partial class GroupTypeGrid : UserControl
    {
        public string FirstId { get; set; }
        public string SecondId { get; set; }

        public TypeItemView Selected;

        public Action<bool, SubclassListItem> GroupTypeSelected;

        public GroupTypeGrid()
        {
            InitializeComponent();
            if (Program.Started)
            {
                this.Load += GroupTypeGrid_Load;
            }

        }

        private void GroupTypeGrid_Load(object sender, EventArgs e)
        {
            HttpLoadGroupSortId();
        }


        private Control CreateControlItem(GroupTyteData data)
        {
            var item = new TypeItemView();
            item.MouseEnterColor = Color.Empty;
            item.Name = "item_" + data.id;
            item.Font = new Font("微软雅黑", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
            item.AccessibleDescription = data.id;
            item.Radius = 5;
            item.Size = new Size(70, 30);
            item.Text = data.name;
            item.Tag = data.subclassList;
            item.Margin = new Padding(18, 8, 0, 8);

            var foucs = data.id == FirstId;
            item.FocusChanged(foucs);

            item.MouseClick += Item_MouseClick;
            return item;
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            if (Selected != null)
            {
                Selected.FocusChanged(false);
            }

            var item = sender as TypeItemView;

            FirstId = item.AccessibleDescription;
            Selected = item;
            Selected.FocusChanged(true);

            var dataList = item.Tag as List<SubclassListItem>;
            var frm = new FrmSelectGroupType();
            frm.Location = new Point(Cursor.Position.X + 20, Cursor.Position.Y - 20);
            frm.SetContentData(dataList, SecondId);
            frm.ItemSelected = ItemSelected;
            frm.Show();
        }



        private void ItemSelected(SubclassListItem obj)
        {
            SecondId = obj.cid;
            obj.parentName = Selected.Text;
            GroupTypeSelected?.Invoke(true, obj);
        }

        //获取分类数据
        private void HttpLoadGroupSortId()
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "community/getCommunityClassify")
                .Build()
                .ExecuteJson<List<GroupTyteData>>((sccess, dataList) =>
                {
                    if (sccess && !UIUtils.IsNull(dataList))
                    {
                        foreach (var data in dataList)
                        {

                            var item = CreateControlItem(data);
                            flowLayoutPanel1.Controls.Add(item);
                        }

                        var pName = dataList[0].name;
                        var sub = dataList[0].subclassList[0];
                        sub.parentName = pName;
                        GroupTypeSelected?.Invoke(false, sub);
                    }
                });
        }
    }


    public class TypeItemView : Buttonx, FocusControl
    {
        public void FocusChanged(bool focus)
        {
            if (focus)
            {
                this.ForeColor = Color.White;

                this.MouseLeaveColor = Color.FromArgb(12, 206, 99);
                this.FrameColor = Color.FromArgb(12, 206, 99);
            }
            else
            {
                this.ForeColor = Color.FromArgb(51, 51, 51);
                this.FrameColor = Color.FromArgb(225, 225, 225);
                this.MouseLeaveColor = Color.FromArgb(225, 225, 225);
            }
        }
    }
}
