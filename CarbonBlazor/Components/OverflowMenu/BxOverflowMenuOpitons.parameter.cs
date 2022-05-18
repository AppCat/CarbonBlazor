using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// OverflowMenuOpitons 的参数部分
    /// OverflowMenuOpitons parameter partial
    /// </summary>
    internal partial class BxOverflowMenuOpitons
    {
        /// <summary>
        /// 指定OverflowMenu的大小。
        /// Specify the size of the OverflowMenu.
        /// </summary>
        [Parameter]
        public EnumMix<BxSize>? Size { get; set; }

        /// <summary>
        /// 是否打开
        /// </summary>
        [Parameter]
        public bool IsOpen { get; set; }

        /// <summary>
        /// 如果菜单对齐应该翻转，则为True。
        /// true if the menu alignment should be flipped.
        /// </summary>
        [Parameter]
        public bool Flipped { get; set; }
    }
}
