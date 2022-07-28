using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.View
{
    public partial class FrmvoiceTest : FrmBase
    {

        public FrmvoiceTest()
        {
            InitializeComponent();
        }


        public void SetData(Model.MessageObject msg)
        {

            userVoiceplayer1.VidoShowList(msg);
        }

        public void SetAutoClose()
        {
            userVoiceplayer1.OnPlayCompte += VoiceplayerOnPlayCompte;
        }

        private void VoiceplayerOnPlayCompte(string url)
        {
            this.Close();
            this.Dispose();
        }




        /// <summary>
        /// 获取是否有录音设备
        /// </summary>
        public bool GetDevicde()
        {
            if (UIUtils.IsNull(GetAudioDeviceName()))
            {
                return false;

            }
            return true;
        }

        public string GetAudioDeviceName()
        {
            ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity  WHERE (PNPClass = 'AudioEndpoint')");
            //ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("select * from Win32_PnPEntity");
            foreach (var device in VoiceDeviceSearcher.Get())//循环遍历WMI实例中的每一个对象
            {
                try
                {
                    if (device.ToString().IndexOf("{0.0.1.00000000}") > 0)
                    {
                        //Console.WriteLine("PNPClass: " + device["PNPClass"] + "  Caption: " + device["Caption"]);
                        string device_name = device["Caption"].ToString();
                        return device_name;
                    }
                }
                catch { continue; }
            }
            return "";
        }
    }
}
