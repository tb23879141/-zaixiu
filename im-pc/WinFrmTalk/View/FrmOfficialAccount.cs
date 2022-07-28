using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls.ItemControl;
using WinFrmTalk.Model;
using WinFrmTalk.View.list;

namespace WinFrmTalk.View
{
    public partial class FrmOfficialAccount : FrmBase
    {
        private FdQueryAdapter<OfficialAccountItem> queryAdapter = null;

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            this.Text = LanguageXmlUtils.GetValue("frmOfficialAccount_title", this.Text);
        }

        public FrmOfficialAccount()
        {
            InitializeComponent();
            LoadLanguageText();

            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            BindData_HotOCA();
            officialAccountPanel.QueryAct = QueryData;
        }

        private void BindData_HotOCA()
        {
            //http get请求获得数据
            HttpUtils.Instance.InitHttp(this);
            //将数据保存
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "public/search/list") // 公众号搜索列表
                .AddParams("access_token", Applicate.Access_Token)
                .Build()
                .Execute((success, result) =>
                {
                    if (success)
                    {
                        JArray friendArray = JArray.Parse(result["data"].ToString());
                        if (friendArray.Count <= 0)
                        {
                            this.ShowTip("该用户不存在");
                        }
                        List<Friend> list = new List<Friend>();
                        foreach (JToken friend in friendArray)
                        {
                            Friend item = JsonConvert.DeserializeObject<Friend>(friend.ToString());
                            list.Add(item);
                        }

                        queryAdapter = new FdQueryAdapter<OfficialAccountItem>();
                        queryAdapter.datas = list;
                        officialAccountPanel.xlvTabel.SetAdapter(queryAdapter);
                    }
                });
        }

        private void QueryData()
        {
            HttpUtils.Instance.InitHttp(this);
            //将数据保存
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "public/search/list") // 公众号搜索列表
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("page", "0")
                .AddParams("limit", "99")
                .AddParams("keyWorld", officialAccountPanel.query_key)
                .Build()
                .Execute((success, result) =>
                {
                    if (success)
                    {
                        JArray friendArray = JArray.Parse(result["data"].ToString());
                        if (friendArray.Count <= 0)
                        {
                            this.ShowTip("该用户不存在");
                        }
                        List<Friend> list = new List<Friend>();
                        foreach (JToken friend in friendArray)
                        {
                            Friend item = JsonConvert.DeserializeObject<Friend>(friend.ToString());
                            list.Add(item);
                        }

                        queryAdapter = new FdQueryAdapter<OfficialAccountItem>();
                        queryAdapter.datas = list;
                        officialAccountPanel.xlvTabel.SetAdapter(queryAdapter);
                    }
                });
        }
    }
}
