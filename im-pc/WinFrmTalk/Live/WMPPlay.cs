using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrmTalk.Live
{
    public class WMPPlay
    {
        public string rtmp_url { get; set; }

        public string outFile_url { get; set; }

        public Action action { get; set; }
    }
}
