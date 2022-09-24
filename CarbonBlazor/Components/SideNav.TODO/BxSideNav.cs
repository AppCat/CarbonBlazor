using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 SideNav 的 Blazor 组件。  
    /// This is a Blazor component for the SideNav.
    /// </summary>
    public partial class BxSideNav : BxComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--side-nav";
            ClassMapper
                .Clear()
                .If("bx--tag--disabled", () => Expanded)
                .If("bx--tag--disabled", () => IsFixedNav)
                .If("bx--tag--disabled", () => IsPersistent)
                .If("bx--side-nav--rail", () => IsRail)
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
            __builder.UseElement(ref sequence, "nav", this, __builder =>
            {
                __builder.AddAria(ref sequence, "label", "Side navigation");

            });
        };
    }
}
