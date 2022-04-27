using CarbonBlazor.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 应用容器
    /// </summary>
    public class BxAppContainer : BxContentComponentBase
    {
        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenComponent<BxModalManager>(sequence++);
            __builder.CloseComponent();

            __builder.AddContent(sequence++, ChildContent);
        };
    }
}
