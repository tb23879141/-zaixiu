using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using WinFrmTalk;
using WinFrmTalk.Helper.http.requst;

/// <summary>
/// http请求框架
/// liuxuan
/// 2019-3-8 17:31:19
/// </summary>
internal class HttpUtils
{

    // 单例模式 
    private HttpUtils()
    {
    }
    private static HttpUtils _instance;
    public static HttpUtils Instance => _instance ?? (_instance = new HttpUtils());

    public bool isVisibleTip = false;

    private List<FrmBase> views = new List<FrmBase>();
    private Dictionary<string, long> cancels = new Dictionary<string, long>();

    public void PutView(FrmBase frm)
    {
        //Console.WriteLine("form create by: " + frm);
        views.Insert(0, frm);
    }

    public void PopView(FrmBase frm)
    {
        //Console.WriteLine("form destroy by: " + frm);
        views.Remove(frm);
        if (mControl == frm)
        {
            mControl = CurrtView();
        }
    }


    /// <summary>
    /// 判断某个窗口是否打开
    /// </summary>
    /// <param name="frm"></param>
    public bool IsOpen(Type frm)
    {
        return FindFrm(frm) != null;
    }


    /// <summary>
    /// 查询某个窗口
    /// </summary>
    /// <param name="frm"></param>
    /// <returns></returns>
    public FrmBase FindFrm(Type frm)
    {
        if (views.Count == 0)
        {
            return null;
        }

        if (frm == null)
        {
            return null;
        }

        foreach (var item in views)
        {
            if (frm.IsAssignableFrom(item.GetType()))
            {
                return item;
            }
        }

        return null;
    }

    public FrmBase CurrtView()
    {
        if (views.Count > 0)
        {
            return views[0];
        }
        return null;
    }

    public void ShowTip(string err, bool isMainFrm = false)
    {
        FrmBase frm = null;
        if (isMainFrm)
        {
            frm = Applicate.GetWindow<FrmMain>();
        }
        else
            frm = CurrtView();
        if (frm != null)
        {
            frm.ShowTip(err);
        }
    }

    public bool ShowPromptBox(string err)
    {
        FrmBase frm = CurrtView();
        if (frm != null)
        {
            return frm.ShowPromptBox(err);
        }

        return false;
    }

    public void Cancel(string requestToekn)
    {
        if (!cancels.ContainsKey(requestToekn))
        {
            cancels.Add(requestToekn, UIUtils.CurrentTimeMillis());
        }
    }

    internal bool CancelPool(string tag, long time)
    {
        if (cancels.ContainsKey(tag))
        {
            long cancel = cancels[tag];
            cancels.Remove(tag);

            if (cancel > time)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// get请求
    /// </summary>
    /// <returns></returns>
    public GetBuilder Get()
    {
        return new GetBuilder();
    }

    /// <summary>
    /// post请求
    /// </summary>
    /// <returns></returns>
    public PostBuilder Post()
    {
        return new PostBuilder();
    }

    public Control GetControl()
    {
        return mControl;
    }

    private Control mControl;

    public void InitHttp(Control control)
    {
        if (mControl == null)
        {
            mControl = control;
        }
        else
        {
            if (control is FrmPromptBox)
            {
                return;
            }

            lock (mControl)
            {

                mControl = control;
            }
        }
    }

    public void Invoke(Delegate method, params object[] args)
    {
        // 这里会影响上传失败
        if (method == null)
        {
            return;
        }

        try
        {
            if (CurrtView() != null)
            {
                CurrtView().Invoke(method, args);
            }
            else
            {
                mControl.Invoke(method, args);
            }
        }
        catch (Exception ex)
        {
            LogUtils.Log(ex.Message);
        }
    }

    public bool AvailableNetwork()
    {
        bool net = NetworkInterface.GetIsNetworkAvailable();
        return net;
    }

}
