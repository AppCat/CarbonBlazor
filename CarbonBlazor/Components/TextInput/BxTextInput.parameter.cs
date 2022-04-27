using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 文本输入框的参数部分
    /// text input parameter partial
    /// </summary>
    public partial class BxTextInput
    {
        /// <summary>
        /// 指定 input 的类型
        /// Specify the type of the input
        /// </summary>
        [Parameter]
        public EnumMix<BxTextInputType> Type { get; set; } = BxTextInputType.Text;
    }
}
