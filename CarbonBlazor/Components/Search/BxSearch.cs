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
    /// 这是一个用于 Search 的 Blazor 组件。  
    /// This is a Blazor component for the Search.
    /// </summary>
    public partial class BxSearch : BxComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--search";
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

            __builder.UseElement(ref sequence, "div", this, 
            __builder =>
            {
                __builder.AddAttribute(sequence++, "aria-labelledby", "search-1-search"); 

            }, 
            __builder =>
            {
                var sequence = 0;

            });

            throw new NotImplementedException();
        };
    }
}
