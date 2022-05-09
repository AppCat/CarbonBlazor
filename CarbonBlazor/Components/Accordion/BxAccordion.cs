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
    /// 这是一个用于 Accordion 的 Blazor 组件。  
    /// This is a Blazor component for the Accordion.
    /// </summary>
    public partial class BxAccordion : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--accordion";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .AddEnum(Size, () => $"{fixedClass}--{Size}")
                .If("bx--skeleton", () => Skeleton)
                .AddEnum(Align)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.UseElement(ref sequence, "ul", this, __builder =>
            {
                if (Skeleton)
                {
                    __builder.AddCascadingValue(ref sequence, true, ChildContent, "Skeleton");
                }
                else
                {
                    __builder.AddContent(sequence++, ChildContent);
                }
            });
        };
    }
}
