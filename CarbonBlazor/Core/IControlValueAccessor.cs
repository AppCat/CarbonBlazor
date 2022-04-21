using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 控制值
    /// </summary>
    public interface IControlValueAccessor
    {
        /// <summary>
        /// 重置
        /// </summary>
        void Reset();
    }
}
