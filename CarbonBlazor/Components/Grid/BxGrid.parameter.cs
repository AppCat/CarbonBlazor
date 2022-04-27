using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Grid 的参数部分
    /// Grid parameter partial
    /// </summary>
    public partial class BxGrid
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

        /// <summary>
        /// 移除网格设置的默认最大宽度
        /// Remove the default max width that the grid has set
        /// </summary>
        [Parameter]
        public bool FullWidth { get; set; }
    }
}
