using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls
{
    public class EQProductPush : EQBaseControl
    {
        public EQProductPush(string strJson) : base(strJson) { }

        public EQProductPush(MessageObject messageObject) : base(messageObject) { }

        public override void Calc_PanelWidth(Control control)
        {
            BubbleWidth = control.Width;
            BubbleHeight = control.Height;
        }

        //CardPanel panel_card;
        public override Control ContentControl()
        {
            ProductPush productPush = new ProductPush();
            productPush.SetProductText(messageObject.content);
            Calc_PanelWidth(productPush);
            return productPush;
        }
    }
}
