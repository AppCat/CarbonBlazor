using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 Header 的 Blazor 组件。  
    /// This is a Blazor component for the Header.
    /// </summary>
    public partial class BxHeader : BxContentComponentBase
    {
        /// <summary>
        /// 是否打开 Menu
        /// </summary>
        protected bool IsOpenMenu = false;

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--header";

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
            RenderFragment menu_toggle = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "button");
                __builder.AddAttribute(sequence++, "type", "button");
                __builder.AddAttribute(sequence++, "title", "Open menu");
                __builder.AddConfig(ref sequence, new BxComponentConfig($"bx--header__action bx--header__menu-trigger bx--header__menu-toggle bx--header__menu-toggle__hidden", $"{Id}-menu-trigger").AddIfClass("bx--header__action--active", () => IsOpenMenu));
                __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
                {
                    if (IsOpenMenu)
                    {
                        __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='20' height='20' viewBox='0 0 32 32' aria-hidden='true'><path d='M24 9.4L22.6 8 16 14.6 9.4 8 8 9.4 14.6 16 8 22.6 9.4 24 16 17.4 22.6 24 24 22.6 17.4 16 24 9.4z'></path></svg>"));
                    }
                    else
                    {
                        __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='20' height='20' viewBox='0 0 20 20' aria-hidden='true'><path d='M2 14.8H18V16H2zM2 11.2H18V12.399999999999999H2zM2 7.6H18V8.799999999999999H2zM2 4H18V5.2H2z'></path></svg>"));
                    }
                }
                __builder.CloseElement();
            };

            RenderFragment header__name = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "a");
                __builder.AddConfig(ref sequence, new BxComponentConfig(NameConfig, $"bx--header__name", $"{Id}-header-name"));
                {
                    __builder.OpenElement(sequence++, "div");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(NamePrefixConfig, $"bx--header__name--prefix", $"{Id}-header-name-prefix"));
                    __builder.AddAttribute(sequence++, "href", Href);

                    __builder.AddContent(sequence++, HeaderNamePrefix);

                    __builder.CloseElement();

                    __builder.EitherOrAddContent(ref sequence, HeaderNameTemplate, HeaderName, () => HeaderNameTemplate != null);
                }
                __builder.CloseElement();
            };

            RenderFragment nav = __builder => 
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "nav");
                __builder.AddConfig(ref sequence, new BxComponentConfig(NavigationConfig, $"bx--header__nav", $"{Id}-header-nav"));
                {
                    __builder.OpenElement(sequence++, "ul");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(NavigationMenuConfig, $"bx--header__menu-bar", $"{Id}-header-menu-bar"));
                    {
                        __builder.AddContent(sequence++, NavigationTemplate);
                    }
                    __builder.CloseElement();
                }
                __builder.CloseElement();
            };

            RenderFragment global = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(GlobalBarConfig, $"bx--header__global", $"{Id}-header-global"));
                {
                    __builder.AddContent(sequence++, GlobalBarTemplate);
                }
                __builder.CloseElement();
            };

            RenderFragment sidenav = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "nav");
                __builder.AddAttribute(sequence++, "aria-label", "Side navigation");
                __builder.AddConfig(ref sequence, new BxComponentConfig(SideNavConfig, $"bx--side-nav__navigation bx--side-nav bx--side-nav--ux", $"{Id}-side-nav")
                    .AddIfClass("bx--side-nav--expanded", () => IsOpenMenu));
                {
                    __builder.AddContent(sequence++, SideNavTemplate);
                }
                __builder.CloseElement();
            };

            RenderFragment overlay = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig($"bx--side-nav__overlay bx--side-nav__overlay-active", $"{Id}-side-nav-overlay"));
                if (Closable)
                {
                    __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
                }
                __builder.CloseElement();
            };

            var sequence = 0;

            __builder.OpenElement(sequence++, "header");
            __builder.AddComponent(ref sequence, this);
            __builder.AddAria(ref sequence, "label", AriaLabel);
            
            __builder.AddContent(sequence++, menu_toggle);
            __builder.AddContent(sequence++, header__name);
            __builder.AddContent(sequence++, nav);
            __builder.AddContent(sequence++, global);
            if (IsOpenMenu)
            {
                __builder.AddContent(sequence++, overlay);
            }
            __builder.AddContent(sequence++, sidenav);
            __builder.AddContent(sequence++, ChildContent);

            __builder.CloseComponent();

        };

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual Task HandleOnClickAsync(MouseEventArgs args)
        {
            IsOpenMenu = !IsOpenMenu;

            return Task.CompletedTask;
        }
    }
}
