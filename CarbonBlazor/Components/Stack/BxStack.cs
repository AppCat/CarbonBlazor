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
    /// 这是一个用于 Stack 的 Blazor 组件。  
    /// This is a Blazor component for the Stack.
    /// </summary>
    public partial class BxStack : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            ClassMapper
                .Clear()
                .AddEnum(Orientation ?? BxStackOrientation.Vertical)
                .AddEnum(Scale,() => $"bx--stack-scale-{(int)Scale.Value}")
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

            __builder.AddContent(sequence++, ChildContent);

            __builder.CloseComponent();
        };
    }
}
