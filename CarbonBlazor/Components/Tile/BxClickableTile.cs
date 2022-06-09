using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 ClickableTile 的 Blazor 组件。  
    /// This is a Blazor component for the ClickableTile.
    /// </summary>
    public partial class BxClickableTile : OtherTileBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--tile bx--tile--clickable bx--link";
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

            __builder.UseElement(ref sequence, "a", this, __builder =>
            {
                __builder.IfAddAttribute(ref sequence, "rel", Rel, () => !string.IsNullOrEmpty(Rel));
                __builder.IfAddAttribute(ref sequence, "href", Href, () => !string.IsNullOrEmpty(Href));
                __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
                __builder.AddEvent(ref sequence, "onkeydown", HandleOnKeyDownAsync);
            }, ChildContent);
        };
    }
}
