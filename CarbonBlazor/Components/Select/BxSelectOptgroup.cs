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
    /// 这是一个用于 SelectOptgroup 的 Blazor 组件。  
    /// This is a Blazor component for the SelectOptgroup.
    /// </summary>
    public class BxSelectOptgroup : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--select-optgroup";

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

            __builder.OpenElement(sequence++, "optgroup");
            __builder.AddComponent(ref sequence, this);

            __builder.IfAddAttribute(ref sequence, "label", Label, () => !string.IsNullOrWhiteSpace(Label));

            __builder.AddContent(sequence++, ChildContent);

            __builder.CloseComponent();
        };

        /// <summary>
        /// 标签
        /// The label for the select.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
    }
}
