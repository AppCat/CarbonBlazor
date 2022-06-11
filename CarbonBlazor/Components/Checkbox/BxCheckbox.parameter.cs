using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
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
        /// 获取或设置输入的值。这应该与双向绑定一起使用。
        /// Gets or sets the checked of the input. This should be used with two-way binding.
        /// </summary>
        [Parameter]
        public bool Checked { get; set; }

        /// <summary>
        /// 获取或设置标识绑定值的表达式。 
        /// Gets or sets an expression that identifies the bound checked.
        /// </summary>
        [Parameter]
        public EventCallback<bool> CheckedChanged { get; set; }

        /// <summary>
        /// 获取或设置标识绑定值的表达式。
        /// Gets or sets an expression that identifies the bound checked.
        /// </summary>
        [Parameter]
        public Expression<Func<bool>>? CheckedExpression { get; set; }

        /// <summary>
        /// Input 配置
        /// </summary>
        [Parameter]
        public IBxComponentConfig? InputConfig { get; set; }
    }
}
