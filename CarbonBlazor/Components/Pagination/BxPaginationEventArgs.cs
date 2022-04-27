using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 用于传递页码变化事件的参数
    /// </summary>
    public class BxPaginationEventArgs : EventArgs
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; }

        /// <summary>
        /// 总数
        /// </summary>
        public int PageTotal { get; }

        /// <summary>
        /// 用于传递页码变化事件的参数
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageTotal"></param>
        public BxPaginationEventArgs(int page, int pageTotal)
        {
            Page = page;
            PageTotal = pageTotal;
        }
    }
}
