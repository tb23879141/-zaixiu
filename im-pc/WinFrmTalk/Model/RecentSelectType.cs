using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrmTalk.Model
{
    public enum RecentSelectType
    {
        /// <summary>
        /// 未置顶未选中
        /// </summary>
        NotMine,
        /// <summary>
        /// 未置顶选中
        /// </summary>
        IsMine,
        /// <summary>
        /// 置顶未选中
        /// </summary>
        NotMineTop,
        /// <summary>
        /// 置顶选中
        /// </summary>
        IsMineTop
    }
}
