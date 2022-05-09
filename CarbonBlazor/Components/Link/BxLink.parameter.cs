using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Link 的参数部分
    /// Link parameter partial
    /// </summary>
    public partial class BxLink
    {
        /// <summary>
        /// 为 a 节点提供 href 属性
        /// Provide the href attribute for the a node
        /// </summary>
        [Parameter]
        public string? Href { get; set; }

        /// <summary>
        /// 指定链路的大小。
        /// Specify the size of the Link.
        /// </summary>
        [Parameter]
        public EnumMix<BxSize>? Size { get; set; } = BxSize.Md;
    }
}
