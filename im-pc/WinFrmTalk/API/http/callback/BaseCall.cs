using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk;

public class BaseCall
{

    private Action<int, string> mErrListener;
    private bool mNotTip;
    //private bool mNotLoding;

    public string requstUrl;
    public string tag;
    private long requestTime;


    public BaseCall(string url)
    {
        requstUrl = url;
    }

    public BaseCall AddErrorListener(Action<int, string> callback)
    {
        mErrListener = callback;
        return this;
    }

    public BaseCall BindTag(string tag)
    {
        this.tag = tag;
        return this;
    }


    public void NoErrorTip(bool noTip)
    {
        mNotTip = noTip;
    }


    public void NoLoading(bool loding)
    {
    }

    public void Execute(Action<bool, Dictionary<string, object>> callback)
    {

        requestTime = UIUtils.CurrentTimeMillis();
        Task.Factory.StartNew(() =>
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requstUrl);

                //Post����ʽ
                request.Method = "GET";
                // ��������
                request.ContentType = "application/x-www-form-urlencoded";
                //request.UserAgent = "";
                // �����Ӧ��
                HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                StreamReader myreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                if (IsCancelRequest())
                {
                    response.Close();
                    myreader.Close();
                    return;
                }
                // �������
                string responseText = myreader.ReadToEnd();

                // �������ݺ�ص���ȥ
                HandleResponseData(responseText, false, callback);
            }
            catch (Exception ex)
            {
                OnError("���粻ͨ��������·������", callback, -1);
                LogHelper.LogInfo("���粻ͨ  requst :" + requstUrl);
            }
        });
    }

    public void ExecuteList<T>(Action<bool, T> callback)
    {
        requestTime = UIUtils.CurrentTimeMillis();
        Task.Factory.StartNew(() =>
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requstUrl);
                //Post����ʽ
                request.Method = "GET";
                // ��������
                request.ContentType = "application/x-www-form-urlencoded";
                // �����Ӧ��
                HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                StreamReader myreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                if (IsCancelRequest())
                {
                    response.Close();
                    myreader.Close();
                    return;
                }
                // �������
                string responseText = myreader.ReadToEnd();

                HandleResponseData(responseText, true, callback, true);
            }
            catch (Exception)
            {
                OnError("���粻ͨ��������·������", callback, -1);
                LogHelper.LogInfo("���粻ͨ  requst :" + requstUrl);
            }
        });

    }

    public void ExecuteJson<T>(Action<bool, T> callback)
    {
        requestTime = UIUtils.CurrentTimeMillis();
        Task.Factory.StartNew(() =>
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requstUrl);
                //Post����ʽ
                request.Method = "GET";
                // ��������
                request.ContentType = "application/x-www-form-urlencoded";

                // �����Ӧ��
                HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                StreamReader myreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                // �������

                if (IsCancelRequest())
                {
                    response.Close();
                    myreader.Close();
                    return;
                }
                string responseText = myreader.ReadToEnd();

                // �������ݺ�ص���ȥ
                HandleResponseData(responseText, true, callback);


                if (TimeUtils.SyncTimeDiff() == 0)
                {
                    // ��ȥ������һ�㣬��÷�������resultCode
                    JObject jo = JsonConvert.DeserializeObject<JObject>(responseText);
                    long sTime = jo.Value<long>("currentTime"); // �����и��ӣ���Щ�������᷵�����ʱ���
                    TimeUtils.SetTimeDiff(sTime);
                }

            }
            catch (Exception)
            {
                OnError("���粻ͨ��������·������", callback, -1);
                LogHelper.LogInfo("���粻ͨ  requst :" + requstUrl);
            }
        });
    }


    /// <summary>
    /// /�õ����������ݺ�ĺ������ݴ���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="responseText"></param>
    /// <param name="isResolve"></param>
    /// <param name="callback"></param>
    private void HandleResponseData<T>(string responseText, bool isResolve, Action<bool, T> callback, bool list = false)
    {
        if (IsCancelRequest())
        {
            return;
        }

        LogUtils.Log("http ��������Ӧ���ݣ� " + responseText);

        if (callback == null && mErrListener == null)
        {    // �ص�����Ϊ�գ������κδ���
            return;
        }

        // ��ȥ������һ�㣬��÷�������resultCode
        JObject jo = JsonConvert.DeserializeObject<JObject>(responseText);
        int code = jo.Value<int>("resultCode");

        if (code == CODE_SUCCESS)
        {
            try
            {
                // û��data�����
                if (!jo.ContainsKey("data") || jo["data"] == null)
                {
                    var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseText);
                    // ����Ҫ����json, ֱ�ӷ���
                    if (list)
                    {

                        OnError("�ӿ����ݽ�������", callback, code);
                    }
                    else
                    {
                        OnSuccess(data, callback);
                    }

                    return;
                }

                // data Ϊ�յ����
                string beanJson = jo["data"].ToString();
                if (string.IsNullOrEmpty(beanJson))
                {
                    if (isResolve)
                    {
                        OnError("�ӿ����ݽ�������", callback, code);
                        LogHelper.LogInfo("�ӿ����ݽ�������  requst :" + requstUrl + "  \n response :" + responseText);
                    }
                    else
                    {
                        var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseText);
                        // ����Ҫ����json, ֱ�ӷ���
                        OnSuccess(data, callback);
                    }
                    return;
                }

                if (isResolve)
                {
                    // ��Ҫ����
                    if (list)
                    {
                        T bean = JsonConvert.DeserializeObject<T>(responseText);
                        OnSuccess(bean, callback);
                    }
                    else
                    {
                        T bean = JsonConvert.DeserializeObject<T>(beanJson);
                        OnSuccess(bean, callback);
                    }
                }
                else
                {
                    // ����Ҫ����json��������������ȷ����data��һ�������ֱ�ӽ������������
                    if (jo["data"].GetType() == typeof(JObject))
                    {
                        var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(beanJson);
                        OnSuccess(data, callback);
                    }
                    else
                    {
                        var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseText);
                        OnSuccess(data, callback);
                    }

                }
            }
            catch (Exception )
            {
                OnError("�ӿ����ݽ�������", callback, code);
                LogHelper.LogInfo("�ӿ����ݽ�������  requst :" + requstUrl + "  \n response :" + responseText);
            }
        }
        else if (code == CODE_TRANSFER_RECEIVED)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseText);
            // ����Ҫ����json, ֱ�ӷ���
            OnSuccess(data, callback);
        }
        else if (code == CODE_TRANSFER_OUTTIME)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseText);
            // ����Ҫ����json, ֱ�ӷ���
            OnSuccess(data, callback);
        }
        else if (code == CODE_READ_OUTTIME)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseText);
            // ����Ҫ����json, ֱ�ӷ���
            OnSuccess(data, callback);
        }
        else if (code == CODE_READ_HAVERECEIVED)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseText);
            // ����Ҫ����json, ֱ�ӷ���
            OnSuccess(data, callback);
        }
        else if (code == CODE_READ_ROOMrECEIVED)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseText);
            // ����Ҫ����json, ֱ�ӷ���
            OnSuccess(data, callback);
        }
        else if (code == CODE_READ_HAVEOPEN)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseText);
            // ����Ҫ����json, ֱ�ӷ���
            OnSuccess(data, callback);
        }
        else if (code == CODE_READ_PACKED)
        {

            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseText);
            // ����Ҫ����json, ֱ�ӷ���
            OnSuccess(data, callback);

        }
        else if (code == CODE_NO_TOKEN)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseText);
            // ����Ҫ����json, ֱ�ӷ���
            OnSuccess(data, callback);
        }
        else if (code == CODE_TOKEN_ERROR)
        {
            // ��������
            Messenger.Default.Send("1030102", MessageActions.RESTART_APP);
        }
        else
        {
            //string msg = jo["resultMsg"].ToString();
            string errmsg = UIUtils.DecodeString(jo, "resultMsg");

            if (UIUtils.IsNull(errmsg))
            {
                errmsg = "��������";
            }

            //OnError("���÷������ӿ�ʧ��,ԭ��:" + errmsg, callback, code);
            OnError(errmsg, callback, code);
            LogHelper.LogInfo("���÷������ӿ�ʧ��  requst :" + requstUrl + "  \n response :" + responseText);
        }
    }

    internal string BuildUrl()
    {
        return requstUrl;
    }

    private void OnError<T>(string msg, Action<bool, T> callback, int code)
    {
        if (IsCancelRequest())
        {
            return;
        }

        try
        {
            if (mErrListener != null)
            {
                HttpUtils.Instance.Invoke(mErrListener, code, msg);
            }
            else
            {
                HttpUtils.Instance.Invoke(callback, false, null);
            }


            if (!mNotTip)
            {
                Action<string> action = new Action<string>(ShowErrBox);
                HttpUtils.Instance.Invoke(action, msg);
            }
        }
        catch (Exception ex)
        {
            LogUtils.Log(ex.Message);
        }
    }

    private void OnSuccess<T, K>(K data, Action<bool, T> callback)
    {
        if (IsCancelRequest())
        {
            return;
        }

        if (callback != null)
        {
            try
            {
                HttpUtils.Instance.Invoke(callback, true, data);
            }
            catch (Exception ex)
            {
                LogUtils.Log("���ھ�������޷��ص����߳�" + ex.Message);
                //callback(true, data);
                throw;
            }

        }
    }




    private bool IsCancelRequest()
    {

        if (!UIUtils.IsNull(tag))
        {
            if (HttpUtils.Instance.CancelPool(tag, requestTime))
            {
                Console.WriteLine("�ӿ�����ȡ���� " + tag);
                return true;
            }
        }

        return false;
    }
    private void ShowErrBox(string err)
    {
        //Messenger.Default.Send(err, FrmMain.NOTIFY_NOTICE);//֪ͨ��ҳ���յ���Ϣ

        HttpUtils.Instance.ShowTip(err);


        //var SnackBar = new WinFrmTalk.Controls.SystemControls.Snackbar();
        //SnackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
        //SnackBar.Location = new System.Drawing.Point(327, 604);
        //SnackBar.Name = "SnackBar";
        //SnackBar.Size = new System.Drawing.Size(185, 36);
        //SnackBar.TabIndex = 57;
        //SnackBar.Text = "snackbar1";
        //HttpUtils.Instance.GetControl().Controls.Add(SnackBar);
        //SnackBar.Enqueue(err);
    }

    // ������ת��Ϣ
    private string ErrCodeToMsg(int code)
    {
        string errmsg = "";
        switch (code)
        {
            case -2:
                errmsg = "�����쳣";
                break;
            case CODE_NET_ERROE:
                errmsg = "�������";
                break;
            case CODE_ARGUMENT_ERROR1:
            case CODE_ARGUMENT_ERROR2:
                errmsg = "ȱ�ٱ���������������";
                break;
            case CODE_INTERNAL_ERROR:
                errmsg = "�ӿ��ڲ��쳣";
                break;
            case CODE_NO_TOKEN:
                errmsg = "ȱ�ٷ�������";
                break;
            case CODE_TOKEN_ERROR:
                errmsg = "�������ƹ��ڻ���Ч";
                break;
            case CODE_ACCOUNT_INEXISTENCE:
                errmsg = "�ʺŲ�����";
                break;
            case CODE_ACCOUNT_ERROE:
                errmsg = "�ʺŻ��������";
                break;
            case CODE_THIRD_NO_PHONE:
                errmsg = "��������¼δ���ֻ�����";
                break;
            case CODE_THIRD_NO_EXISTS:
                errmsg = "��������¼ʱ�˺Ų�����";
                break;
        }

        return errmsg;
    }

    public const int CODE_NET_ERROE = -1;// �������Ӵ���
    public const int CODE_ERROE = 0;// δ֪�Ĵ��� ����ϵͳ�ڲ�����
    public const int CODE_SUCCESS = 1;// ��ȷ��Http���󷵻�״̬��
    public const int CODE_ARGUMENT_ERROR1 = 1010101;// ���������֤ʧ�ܣ�ȱ�ٱ���������������
    public const int CODE_ARGUMENT_ERROR2 = 1010102;// ȱ�����������%1$s

    public const int CODE_INTERNAL_ERROR = 1020101;// �ӿ��ڲ��쳣
    public const int CODE_NO_TOKEN = 1030101;// ȱ�ٷ�������
    public const int CODE_TOKEN_ERROR = 1030102;// �������ƹ��ڻ���Ч

    /* ��½�ӿڵ�Http Result Code */
    public const int CODE_ACCOUNT_INEXISTENCE = 1040101;// �ʺŲ�����
    public const int CODE_ACCOUNT_ERROE = 1040102;// �ʺŻ��������

    // ����ǵ�������¼ʱ��������������˺�û�а󶨵������˺ţ�
    public const int CODE_THIRD_NO_PHONE = 1040305;// ��������¼δ���ֻ�����
    // ����ǰ������˺�ʱ�������IM�˺Ų����ڣ�
    public const int CODE_THIRD_NO_EXISTS = 1040306;// ��������¼ʱ�˺Ų�����

    public const int CODE_READ_OUTTIME = 100101;// �������
    public const int CODE_READ_HAVERECEIVED = 101204;// Ⱥ����Ѿ���ȡ
    public const int CODE_READ_ROOMrECEIVED = 104103;//����ѱ���ȡ
    public const int CODE_READ_HAVEOPEN = 1;// Ⱥ����Կ�����ȡ
    public const int CODE_READ_PACKED = 100102;// ��������¼ʱ�˺Ų�����
    public const int CODE_TRANSFER_RECEIVED = 100302;// ��������¼ʱ�˺Ų�����
    public const int CODE_TRANSFER_OUTTIME = 100301;// ת�˳�ʱ

}
