using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 指定ProgressBar的大小。
    /// Specify the size of the ProgressBar.
    /// </summary>
    public enum BxProgressBarSize
    {
        /// <summary>
        /// 小
        /// </summary>
        [EnumClass("bx--progress-bar--small")]
        Small,
        /// <summary>
        /// 大
        /// </summary>
        [EnumClass("bx--progress-bar--big")]
        Big,
    }
}
