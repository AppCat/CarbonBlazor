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
    /// 这是一个用于 HeaderMenuItem 的 Blazor 组件。  
    /// This is a Blazor component for the HeaderMenuItem.
    /// </summary>
    public partial class BxHeaderMenuItem : BxContentComponentBase
    {
        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "li");
            __builder.IfAddAttribute(ref sequence, "role", "none", () => FatherComponentContext != null && FatherComponentContext.FatherComponent != null && (FatherComponentContext.FatherComponent is BxHeaderMenu));
            __builder.AddComponent(ref sequence, this);
            {
                __builder.OpenElement(sequence++, "a");
                __builder.AddAttribute(sequence++, "href", Href);
                __builder.AddConfig(ref sequence, new BxComponentConfig(MenuItemConfig, "bx--header__menu-item", $"{Id}-header-menu-item"));
                {
                    __builder.OpenElement(sequence++, "span");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(MenuItemConfig, "bx--text-truncate--end", $"{Id}-text-truncate--end"));

                    __builder.EitherOrAddContent(ref sequence, ChildContent, Title, () => ChildContent != null);

                    __builder.CloseElement();
                }
                __builder.CloseElement();
            }
            __builder.CloseComponent();
        };
    }
}
