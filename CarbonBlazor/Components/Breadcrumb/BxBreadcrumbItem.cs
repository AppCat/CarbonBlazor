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
    /// 这是一个用于 Breadcrumb 的 Blazor 组件。  
    /// This is a Blazor component for the Breadcrumb.
    /// </summary>
    public partial class BxBreadcrumbItem : BxContentComponentBase
    {
        /// <summary>
        /// 渲染目标
        /// </summary>
        [CascadingParameter(Name = "Skeleton")]
        public bool Skeleton { get; set; }

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--breadcrumb-item";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--breadcrumb-item--current", () => IsCurrentPage)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.UseElement(ref sequence, (Skeleton ? "div" : "li"), this, __builder =>
            {
                if (Skeleton)
                {
                    __builder.AddContent(sequence++, new MarkupString("<span class='bx--link'>&nbsp;</span>"));
                    return;
                }
                __builder.OpenElement(sequence++, "a");
                __builder.AddConfig(ref sequence, new BxComponentConfig(LinkConfig, "bx--link", $"{Id}-link"));
                __builder.AddAttribute(sequence++, "href", Href ?? ("javascript:;"));
                __builder.AddContent(sequence++, ChildContent);
                __builder.CloseElement();
            });
        };
    }
}
