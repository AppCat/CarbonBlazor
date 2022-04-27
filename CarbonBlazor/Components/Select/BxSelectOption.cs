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
    /// 这是一个用于 SelectOption 的 Blazor 组件。  
    /// This is a Blazor component for the SelectOption.
    /// </summary>
    public class BxSelectOption : BxOptionComponentBase<BxSelect, BxSelectOption, string>
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--select-option";

            ClassMapper
                .Clear()
                .Add(fixedClass)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "option");
            __builder.AddComponent(ref sequence, this);
            __builder.AddAttribute(sequence++, "value", Key);

            if (Selected)
            {
                __builder.AddAttribute(sequence++, "selected");
            }

            if (Disabled)
            {
                __builder.AddAttribute(sequence++, "disabled");
            }

            __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
            //__builder.AddEvent(ref sequence, "onmouseover", HandleOnMouseoverAsync);

            if (ValueTemplate != null)
            {
                __builder.AddContent(sequence++, ValueTemplate, Tag);
            }
            else if (!string.IsNullOrWhiteSpace(Value))
            {
                __builder.AddContent(sequence++, Value);
            }

            __builder.CloseComponent();
        };
    }
}
