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
    /// 这是一个用于 OverflowMenuOpitons 的 Blazor 组件。  
    /// This is a Blazor component for the OverflowMenuOpitons.
    /// </summary>
    internal partial class BxOverflowMenuOpitons : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--overflow-menu-options";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .AddEnum(Size, () => $"{fixedClass}--{Size}")
                .If("bx--overflow-menu--open", () => IsOpen)
                .If("bx--overflow-menu--flip", () => Flipped)
                ;           
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.UseElement(ref sequence, "ul", this, __builder =>
            {
                __builder.AddAttribute(sequence++, "tabindex", "-1");
                __builder.AddAttribute(sequence++, "role", "menu");
                __builder.AddAttribute(sequence++, "role", "menu");

            });
        };
    }
}
