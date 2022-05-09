using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 指定手风琴标题、标题和字形的对齐方式。
    /// Specify the alignment of the accordion heading title and chevron.
    /// </summary>
    public enum BxAccordionAlign
    {
        /// <summary>
        /// 头
        /// </summary>
        [EnumClass("bx--accordion--start")]
        Start,
        /// <summary>
        /// 尾
        /// </summary>
        [EnumClass("bx--accordion--end")]
        End
    }
}
