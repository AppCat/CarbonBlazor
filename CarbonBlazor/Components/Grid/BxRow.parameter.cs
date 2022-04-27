using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Row 的参数部分
    /// Row parameter partial
    /// </summary>
    public partial class BxRow
    {
        /// <summary>
        /// 将gutter折叠为1px。 适用于流体布局。 行之间有1px的边距以匹配gutter。  
        /// Collapse the gutter to 1px. Useful for fluid layouts. Rows have 1px of margin between them to match gutter.
        /// </summary>
        [Parameter]
        public bool Condensed { get; set; }

        /// <summary>
        /// 容器挂在排水沟16px。 适用于有或没有容器的排版对齐。  
        /// Container hangs 16px into the gutter. Useful for typographic alignment with and without containers.
        /// </summary>
        [Parameter]
        public bool Narrow { get; set; }
    }
}
