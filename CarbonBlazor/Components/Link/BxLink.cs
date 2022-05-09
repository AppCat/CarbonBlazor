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
    /// 这是一个用于 Link 的 Blazor 组件。  
    /// This is a Blazor component for the Link.
    /// </summary>
    public partial class BxLink : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--link";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .AddEnum(Size, () => $"{fixedClass}--{Size}")
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.UseElement(ref sequence, "a", this, __builder =>
            {
                __builder.AddAttribute(sequence++, "href", Href ?? ("javascript:;"));
                __builder.AddContent(sequence++, ChildContent);
            });
        };
    }
}
