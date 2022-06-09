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
    /// Input组件
    /// </summary>
    public interface IBxInput<TValue> : IControlValueAccessor
    {
        /// <summary>
        /// 获取或设置输入的值。这应该与双向绑定一起使用。
        /// Gets or sets the value of the input. This should be used with two-way binding.
        /// </summary>
        TValue? Value { get; set; }

        /// <summary>
        /// 获取或设置标识绑定值的表达式。 
        /// Gets or sets an expression that identifies the bound value.
        /// </summary>
        EventCallback<TValue?> ValueChanged { get; set; }

        /// <summary>
        /// 获取或设置标识绑定值的表达式。
        /// Gets or sets an expression that identifies the bound value.
        /// </summary>
        Expression<Func<TValue?>>? ValueExpression { get; set; }
    }
}
