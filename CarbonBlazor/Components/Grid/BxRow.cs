using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 Row 的 Blazor 组件。  
    /// This is a Blazor component for the Row.
    /// </summary>
    public partial class BxRow : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--row";

            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--row--condensed", () => Condensed)
                .If("bx--row--narrow", () => Narrow)
                ;
        }

        /// <summary>
        /// 渲染内容
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            __builder.AddContent(sequence++, ChildContent);

            __builder.CloseComponent();
        };
    }
}
