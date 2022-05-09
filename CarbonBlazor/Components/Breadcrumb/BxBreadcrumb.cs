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
    public partial class BxBreadcrumb : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--breadcrumb";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--breadcrumb--no-trailing-slash", () => NoTrailingSlash)
                .If("bx--skeleton", () => Skeleton)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.UseElement(ref sequence, "ol", this, __builder =>
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
