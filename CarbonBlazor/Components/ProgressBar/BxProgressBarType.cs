using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 定义进度条的对齐变体。  
    /// Defines the alignment variant of the progress bar.
    /// </summary>
    public enum BxProgressBarType
    {
        /// <summary>
        /// 默认
        /// </summary>
        [EnumClass("bx--progress-bar--default")]
        Default,
        /// <summary>
        /// 内联
        /// </summary>
        [EnumClass("bx--progress-bar--inline")]
        Inline,
        /// <summary>
        /// 
        /// </summary>
        [EnumClass("bx--progress-bar--indented")]
        Indented
    }
}
