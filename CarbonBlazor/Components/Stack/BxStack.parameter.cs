using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Stack 的参数部分
    /// Stack parameter partial
    /// </summary>
    public partial class BxStack
    {
        /// <summary>
        /// 简单的
        /// </summary>
        [Parameter]
        public bool Simplicity { get; set; }

        /// <summary>
        /// 提供一个自定义值或间距比例的一个步骤，以用作布局中的间隙  
        /// Provide either a custom value or a step from the spacing scale to be used as the gap in the layout
        /// </summary>
        [Parameter]
        public EnumMix<BxStackScale>? Scale { get; set; }

        /// <summary>
        /// 指定这些项在堆栈中的方向
        /// Specify the orientation of them items in the Stack
        /// </summary>
        [Parameter]
        public EnumMix<BxStackOrientation>? Orientation { get; set; }
    }
}
