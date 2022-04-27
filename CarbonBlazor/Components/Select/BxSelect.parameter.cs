using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 选择的参数部分
    /// select parameter partial
    /// </summary>
    public partial class BxSelect
    {
        /// <summary>
        /// 简单的
        /// </summary>
        [Parameter]
        public bool Simplicity { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        [Parameter]
        public string? Placeholder { get; set; }

        /// <summary>
        /// 指定是否需要此控件的内联版本  
        /// Specify whether you want the inline version of this control
        /// </summary>
        [Parameter]
        public bool Inline { get; set; } 
    }
}
