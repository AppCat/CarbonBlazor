using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 外部通知状态变化
    /// </summary>
    public interface IExternalNotifyStateHasChanged
    {
        /// <summary>
        /// 通知变化
        /// </summary>
        void NotifyStateHasChanged();
    }
}
