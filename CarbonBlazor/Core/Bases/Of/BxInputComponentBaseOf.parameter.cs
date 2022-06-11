using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class BxInputComponentBaseOf<TValue> : IBxInput<TValue>
    {
        /// <summary>
        /// 获取或设置输入的值。这应该与双向绑定一起使用。
        /// Gets or sets the value of the input. This should be used with two-way binding.
        /// </summary>
        [Parameter]
        public TValue? Value { get; set; }

        /// <summary>
        /// 获取或设置标识绑定值的表达式。 
        /// Gets or sets an expression that identifies the bound value.
        /// </summary>
        [Parameter]
        public EventCallback<TValue?> ValueChanged { get; set; }

        /// <summary>
        /// 获取或设置标识绑定值的表达式。
        /// Gets or sets an expression that identifies the bound value.
        /// </summary>
        [Parameter]
        public Expression<Func<TValue?>>? ValueExpression { get; set; }

        /// <summary>
        /// 只读
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; }
    }
}
