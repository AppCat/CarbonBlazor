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
    /// 这是一个用于 Fieldset 的 Blazor 组件。  
    /// This is a Blazor component for the Fieldset.
    /// </summary>
    public partial class BxFieldset : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--fieldset";

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

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            if(!string.IsNullOrEmpty(LabelText))
            {
                __builder.OpenElement(sequence++, "legend");
                __builder.AddConfig(ref sequence, new BxComponentConfig(LabelConfig, "bx--label", $"{Id}-label"));
                __builder.AddContent(sequence++, LabelText);
                __builder.CloseElement();
            }

            __builder.AddContent(sequence++, ChildContent);

            __builder.CloseComponent();
        };
    }
}
