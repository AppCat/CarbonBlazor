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
    /// 这是一个用于 HeaderMenu 的 Blazor 组件。  
    /// This is a Blazor component for the HeaderMenu.
    /// </summary>
    public partial class BxHeaderMenu : BxMenuComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--header__submenu";

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

            __builder.OpenElement(sequence++, "li");
            __builder.AddComponent(ref sequence, this);
            {
                __builder.OpenElement(sequence++, "a");
                __builder.AddConfig(ref sequence, new BxComponentConfig(MenuTitleConfig, "bx--header__menu-item bx--header__menu-title", $"{Id}-header-menu-title"));
                __builder.AddAttribute(sequence++, "href", "javascript:void(0)");
                __builder.AddAttribute(sequence++, "role", "menuitem");
                __builder.AddAttribute(sequence++, "tabindex", "0");
                __builder.AddAria(ref sequence, "haspopup", "menu");
                __builder.AddAria(ref sequence, "expanded", Expanded);
                __builder.AddAria(ref sequence, "label", AriaLabel);

                __builder.EitherOrAddContent(ref sequence, TitleTemplate, Title, () => TitleTemplate != null);
                __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' width='10' height='6' viewBox='0 0 10 6' aria-hidden='true' class='bx--header__menu-arrow' style='will-change: transform;'><path d='M5 6L0 1 .7.3 5 4.6 9.3.3l.7.7z'></path></svg>"));

                __builder.CloseElement();

                __builder.OpenElement(sequence++, "ul");
                __builder.AddAria(ref sequence, "label", AriaLabel);
                __builder.AddAttribute(sequence++, "role", "menu");
                __builder.AddConfig(ref sequence, new BxComponentConfig(MenuConfig, "bx--header__menu", $"{Id}-header-menu"));

                if (Expanded)
                {
                    __builder.AddContent(sequence++, ChildContent);
                }

                __builder.CloseElement();
            }
            __builder.CloseComponent();
        };
    }
}
