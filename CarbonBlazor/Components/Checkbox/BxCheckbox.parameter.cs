using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于Checkbox组件的参数部分.
    /// This is a parameter section for the checkbox component
    /// </summary>
    public partial class BxCheckbox
    {
        /// <summary>
        /// Input 配置
        /// </summary>
        [Parameter]
        public IBxComponentConfig? InputConfig { get; set; }
    }
}
