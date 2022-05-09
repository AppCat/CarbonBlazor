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
    /// 这是一个用于 Header 的 Blazor 组件。  
    /// This is a Blazor component for the Header.
    /// </summary>
    public partial class BxHeader : BxContentComponentBase
    {
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

            var sequence = 0;

            __builder.OpenElement(sequence++, "header");
            __builder.AddComponent(ref sequence, this);
            __builder.AddAria(ref sequence, "label", AriaLabel);

            __builder.AddContent(sequence++, header__name);
            __builder.AddContent(sequence++, nav);
            __builder.AddContent(sequence++, global);
            __builder.AddContent(sequence++, ChildContent);

            __builder.CloseComponent();

        };
    }
}
