using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Accordion 的参数部分
    /// Accordion parameter partial
    /// </summary>
    public partial class BxAccordion
    {
        /// <summary>
        /// 指定手风琴的大小。
        /// Specify the size of the Accordion.
        /// </summary>
        [Parameter]
        public EnumMix<BxSize>? Size { get; set; } = BxSize.Md;

        /// <summary>
        /// 指定手风琴的大小。
        /// Specify the size of the Accordion.
        /// </summary>
        [Parameter]
        public EnumMix<BxAccordionAlign>? Align { get; set; } = BxAccordionAlign.End;

        /// <summary>
        /// 骨架
        /// Skeleton
        /// </summary>
        [Parameter]
        public bool Skeleton { get; set; }
    }
}
