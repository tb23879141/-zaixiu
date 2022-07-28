using PBMessage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;

namespace WinFrmTalk.View.list
{
    public class MyColleagueAdapter : IBaseAdapter
    {

        List<MyColleagues> myColleagues = new List<MyColleagues>();

        private UserCollection UserCollection;

        public override int GetItemCount()
        {
            return myColleagues.Count;
        }

        public void SetMaengForm(UserCollection collection)
        {
            this.UserCollection = collection;
        }

        public override Control OnCreateControl(int index)
        {

            UserCollectionItem item = new UserCollectionItem();


            item.Size = new Size(UserCollection.cc.Width, item.Height);
            item.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            item.Name = myColleagues[index].courseId;
            item.lblComeFrom.Visible = false;
            item.lblTime.Location = new Point(item.lblTime.Location.X, item.lblTime.Location.Y + 15);
            EQShowInfoPanelAlpha eQShowInfo = new EQShowInfoPanelAlpha();
            eQShowInfo.Cursor = Cursors.Hand;
            eQShowInfo.Size = item.panel.Size;
            eQShowInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            eQShowInfo.Location = item.panel.Location;
            eQShowInfo.BringToFront();
            item.panel.Controls.Add(eQShowInfo);

            UserFileLeft panel_file = new UserFileLeft();
            panel_file.Name = "panel_file";
            panel_file.Cursor = Cursors.Hand;
            string fileNames = LanguageXmlUtils.GetValue("name_courseware_name", "课件名称：", true) + myColleagues[index].courseName;
            panel_file.lab_fileName.Text = fileNames;

            int num = 0;
            if (!UIUtils.IsNull(myColleagues[index].messageIds.ToString()))
            {
                num = System.Text.RegularExpressions.Regex.Matches(myColleagues[index].messageIds.ToString(), ",").Count + 1;
            }

            panel_file.lab_fileSize.Text = LanguageXmlUtils.GetValue("number_tiao", num + "条").Replace("%s", num.ToString());
            panel_file.Location = new Point(20, 20);
            panel_file.lab_icon.Image = Resources.ic_flie_type_class;

            item.Tag = myColleagues[index].courseName;
            item.panel.Controls.Add(panel_file);
            item.RefreshCourseTime(myColleagues[index].createTime);
         

            // 我的课程详情点击
            eQShowInfo.MouseDown += (sen, eve) =>
            {
                UserCollection.OnClickCourseItem(item, eve);
            };


           // UserCollectionItem item = new UserCollectionItem();

           //// item.ComeFrom = "来自：" + UIUtils.LimitTextLength(Applicate.MyAccount.nickname, 4, true);//收藏来自哪？
           // item.Time =
           //     "录制时间：" + TimeUtils.FromatTime(
           //         long.Parse(myColleagues[index].createTime), "yy/MM/dd");
           // item.Name = myColleagues[index].courseId;
           // item.Size = new Size(535, item.Height);
           // item.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            
           // item.Tag += myColleagues[index].messageIds.ToString();

           // item.CollectContent = "课件名称：" + myColleagues[index].courseName;//收藏内容


           // item.MouseDown += (sen, eve) =>
           // {
           //     //获取讲课详情
           //     HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/course/get")
           //         .AddParams("courseId", item.Name)
           //         .AddParams("access_token", Applicate.Access_Token)
           //         .Build().ExecuteJson<List<CourseMessage>>((state, jsonArray) =>
           //         {
           //             if (state)
           //             {
           //                 UserCollection.ListMessage = new List<MessageObject>();

           //                 foreach (var arrItme in jsonArray)
           //                 {
           //                     MessageObject msg = arrItme.ToMessageObject();

           //                     //解析出错
           //                     if (msg == null)
           //                     {
           //                         continue;
           //                     }

           //                     if (msg.isEncrypt > 0)
           //                     {
           //                         SkSSLUtils.DecryptRecordMessage(msg, msg.ChatJid.Length > 18);
           //                     }

           //                     if (msg.isEncrypt != 3)
           //                     {
           //                         UserCollection.ListMessage.Add(msg);
           //                     }
           //                 }

           //                 if (eve.Button == MouseButtons.Right)
           //                 {
           //                     if (UserCollection.control != null)
           //                     {
           //                         UserCollection.control.IsSelected = false;
           //                         UserCollection.control.BagColor = Color.WhiteSmoke;
           //                         UserCollection.control.ContextMenuStrip = null;
           //                     }

           //                   //  UserCollection.control =(UserCollection)item;
           //                     UserCollection.control.IsSelected = true;

           //                     item.ContextMenuStrip = UserCollection.cmsLecture;
           //                 }

           //                 if (eve.Button == MouseButtons.Left)
           //                 {
           //                     if (UserCollection.control != null)
           //                     {
           //                         UserCollection.control.IsSelected = false;
           //                         UserCollection.control.BagColor = Color.WhiteSmoke;
           //                         UserCollection.control.ContextMenuStrip = null;
           //                     }

           //                    // UserCollection.control = item;
           //                     UserCollection.control.IsSelected = true;

           //                     FrmHistoryMsg frmHistoryMsg = new FrmHistoryMsg() { messages = UserCollection.ListMessage, FromLocal = false };
           //                     frmHistoryMsg.Text = "我的课件";
           //                     frmHistoryMsg.Show();
           //                 }
           //             }
           //         });
           // };







            //UserLabelItem item = new UserLabelItem();
            //item.Name = myColleagues[index].courseId;
            //item.lblName.Text =
            //    "课件名称：" +myColleagues[index].courseName;
            //item.Cursor = Cursors.Hand;
            //item.lblName.Name = myColleagues[index].courseName;
            //item.lblFriend.Text =
            //    "录制时间：" + TimeUtils.FromatTime(
            //        long.Parse(myColleagues[index].createTime), "yy/MM/dd");
            //item.Tag += myColleagues[index].messageIds.ToString();

            //item.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //item.MouseDown += (sen, eve) =>
            //{
            //    //获取讲课详情
            //    HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/course/get")
            //        .AddParams("courseId", item.Name)
            //        .AddParams("access_token", Applicate.Access_Token)
            //        .Build().ExecuteJson<List<CourseMessage>>((state, jsonArray) =>
            //        {
            //            if (state)
            //            {
            //                UserCollection.ListMessage = new List<MessageObject>();

            //                foreach (var arrItme in jsonArray)
            //                {
            //                    MessageObject msg = arrItme.ToMessageObject();

            //                    //解析出错
            //                    if(msg == null)
            //                    {
            //                        continue;
            //                    }

            //                    if (msg.isEncrypt > 0)
            //                    {
            //                        SkSSLUtils.DecryptRecordMessage(msg, msg.ChatJid.Length > 18);
            //                    }

            //                    if (msg.isEncrypt != 3)
            //                    {
            //                        UserCollection.ListMessage.Add(msg);
            //                    }
            //                }

            //                if (eve.Button == MouseButtons.Right)
            //                {
            //                    if (UserCollection.control != null)
            //                    {
            //                        UserCollection.control.IsSelected = false;
            //                        UserCollection.control.BagColor = Color.WhiteSmoke;
            //                        UserCollection.control.ContextMenuStrip = null;
            //                    }

            //                    UserCollection.control = item;
            //                    UserCollection.control.IsSelected = true;

            //                    item.ContextMenuStrip = UserCollection.cmsLecture;
            //                }

            //                if (eve.Button == MouseButtons.Left)
            //                {
            //                    if (UserCollection.control != null)
            //                    {
            //                        UserCollection.control.IsSelected = false;
            //                        UserCollection.control.BagColor = Color.WhiteSmoke;
            //                        UserCollection.control.ContextMenuStrip = null;
            //                    }

            //                    UserCollection.control = item;
            //                    UserCollection.control.IsSelected = true;

            //                    FrmHistoryMsg frmHistoryMsg = new FrmHistoryMsg() { messages = UserCollection.ListMessage, FromLocal = false };
            //                    frmHistoryMsg.Text = "我的课件";
            //                    frmHistoryMsg.Show();
            //                }
            //            }
            //        });
            //};

            return item;
        }


        public override int OnMeasureHeight(int index)
        {
            return 80;
        }

        public override void RemoveData(int index)
        {
            myColleagues.RemoveAt(index);
        }
        public void BindDatas(List<MyColleagues> data)
        {

            myColleagues = data;
        }

        internal int GetIndexByName(string name)
        {
            for (int i = 0; i < myColleagues.Count; i++)
            {
                if (myColleagues[i].courseId.Equals(name))
                {

                    return i;
                }
            }
            return -1;
        }


        public MessageObject ChatToMessageObject(ChatMessage message)
        {
            MessageObject chat = new MessageObject();
            chat.fromUserId = message.fromUserId;
            chat.fromUserName = message.fromUserName;
            chat.toUserId = message.toUserId;
            chat.toUserName = message.toUserName;
            chat.timeSend = message.timeSend / 1000.0f;
            chat.deleteTime = message.deleteTime / 1000.0f;
            chat.type = (kWCMessageType)message.type;
            chat.isEncrypt = message.isEncrypt ? 1 : 0;
            chat.isReadDel = message.isReadDel ? 1 : 0;
            chat.content = message.content;
            chat.objectId = message.objectId;
            chat.fileName = message.fileName;
            chat.fileSize = message.fileSize;
            chat.timeLen = Convert.ToInt32(message.fileTime);
            chat.location_x = message.location_x;
            chat.location_y = message.location_y;

            MessageHead head = message.messageHead;
            chat.isGroup = head.chatType - 1;
            chat.FromId = message.fromUserId;
            chat.ToId = head.to;
            chat.messageId = head.messageId;

            return chat;
        }
    }
}
