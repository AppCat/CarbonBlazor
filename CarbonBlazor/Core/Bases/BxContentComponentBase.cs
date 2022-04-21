using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 内容组件基础
    /// </summary>
    public abstract class BxContentComponentBase : BxComponentBase
    {
        /// <summary>
        /// 子内容
        /// </summary>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }

    /// <summary>
    /// 内容组件基础
    /// </summary>
    public abstract class BxContentComponentBase<TContext> : BxComponentBase
    {
        /// <summary>
        /// 子内容
        /// </summary>
        [Parameter]
        public RenderFragment<TContext>? ChildContent { get; set; }
    }
}
