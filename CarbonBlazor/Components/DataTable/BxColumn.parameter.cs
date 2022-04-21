using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 数据表列的参数部分
    /// Column parameter partial
    /// </summary>
    /// <typeparam name="TField"></typeparam>
    public partial class BxColumn<TField>
    {
        /// <summary>
        /// 内容
        /// </summary>
        [Parameter]
        public TField Field { get; set; }

        /// <summary>
        /// 字符串格式
        /// </summary>
        [Parameter]
        public string Format { get; set; }
        
        /// <summary>
        /// 字段表达式
        /// </summary>
        [Parameter]
        public Expression<Func<TField>> FieldExpression { get; set; }

        /// <summary>
        /// 内容变化
        /// </summary>
        [Parameter]
        public EventCallback<TField> FieldChanged { get; set; }
    }
}
