using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 通过 Web Components 实现的内容组件基础
    /// </summary>
    public abstract class BxPropertieContentComponentBase<TComponent> : BxPropertieComponentBase<TComponent>
    {
        /// <summary>
        /// 子内容
        /// </summary>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }

    /// <summary>
    /// 通过 Web Components 实现的内容组件基础
    /// </summary>
    public abstract class BxPropertieContentComponentBase<TComponent, TContext> : BxPropertieComponentBase<TComponent>
    {
        /// <summary>
        /// 子内容
        /// </summary>
        [Parameter]
        public RenderFragment<TContext>? ChildContent { get; set; }
    }
}
