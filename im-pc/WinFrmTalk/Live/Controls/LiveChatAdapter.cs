using RichTextBoxLinks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;

namespace WinFrmTalk.Live.Controls
{
    public class LiveChatAdapter : IBaseAdapter
    {
        public List<MessageObject> msgLst = new List<MessageObject>();
        public List<LiveMember> liveMembers = new List<LiveMember>();

        string userid; 

        public override int GetItemCount()
        {
            return msgLst.Count;
        }

        public override Control OnCreateControl(int index)
        {
            UserLiveItem userLiveItem = new UserLiveItem();
            if(msgLst[index].type== kWCMessageType.TYPE_SEND_ENTER_LIVE_ROOM|| msgLst[index].type == kWCMessageType.TYPE_LIVE_EXIT_ROOM)
            {
                userLiveItem.NickName = "系统:";
            }
            else
            {
                userLiveItem.NickName = msgLst[index].fromUserName + ":";
            }
            
           
            RichTextBoxEx richText = new RichTextBoxEx();
            richText.Font = new Font(Applicate.SetFont, 10f);
            richText.Size = new Size(295, 20);

            // label.TextAlign = ContentAlignment.MiddleLeft;
            int a = userLiveItem.lblName.Location.X + userLiveItem.lblName.Width + 5;
            richText.Location = new Point(a, userLiveItem.lblName.Location.Y-4);
            richText.BackColor = Color.White;
            richText.Text = msgLst[index].content;
            richText.ContentsResized += RichText_ContentsResized;

            // richText.BackColor = Color.WhiteSmoke;
            richText.BorderStyle = BorderStyle.None;
            richText.ScrollBars = RichTextBoxScrollBars.None;
            richText.ReadOnly = true;

           
            richText.Multiline = true;
            // richText.BringToFront();
            userLiveItem.Size = new Size(342, richText.Height + 10);
            EQShowInfoPanelAlpha eQShowInfo = new EQShowInfoPanelAlpha();//透明遮罩 

            eQShowInfo.Size = userLiveItem.Size;
            eQShowInfo.Location = userLiveItem.Location;
            eQShowInfo.BringToFront();
            userLiveItem.Controls.Add(eQShowInfo);
            userLiveItem.Controls.Add(richText);
            

            return userLiveItem;

        }
        public void BindDatas(List<LiveMember> data)
        {
            liveMembers = data;
        }

        public void InsertData(int index, MessageObject data)
        {
            msgLst.Insert(index, data);
        }

        private void RichText_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            RichTextBoxEx richText = (RichTextBoxEx)sender;
            richText.Height = e.NewRectangle.Height + 5;
        }

        public override int OnMeasureHeight(int index)
        {
            
            MessageObject msg = new MessageObject();
            msg.content = msgLst[index].content;
            EQControlManager.CalculateWidthAndHeight_Text(msg, false, 282);
            //if (msg.BubbleHeight == 26)
            //{
                return msg.BubbleHeight + 5;
            //}
            //else
            //{
            //    return msg.BubbleHeight+20 ;
            //}
        } 

        public override void RemoveData(int index)
        {
            msgLst.RemoveAt(index);
        }
        public int GetIndexById(string Messigeid)
        {
            for (int i = 0; i < GetItemCount(); i++)
            {
                if (GetDatas(i).messageId.Equals(Messigeid))
                {
                    return i;
                }
            }

            return -1;
        }

        private MessageObject GetDatas(int i)
        {
            return msgLst[i];
        }
    }
}
