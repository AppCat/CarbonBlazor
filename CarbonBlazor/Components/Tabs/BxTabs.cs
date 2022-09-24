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
    /// 这是一个用于 Tabs 的 Blazor 组件。  
    /// This is a Blazor component for the Tabs.
    /// </summary>
    public partial class BxTabs : BxSelectComponentBase<BxTab, string>
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--tabs";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--tabs--contained", () => Contained)
                .If("bx--skeleton", () => Skeleton)
                ;
        }

        /// <summary>   
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            if (Skeleton)
            {
                __builder.UseElement(ref sequence, "div", this, __builder =>
                {
                    __builder.OpenElement(sequence++, "ul");
                    __builder.AddConfig(ref sequence, new BxComponentConfig("bx--tabs__nav", $"{Id}-nav"));
                    __builder.AddCascadingValue(ref sequence, BxTabsGoal.Skeleton, ChildContent);
                    __builder.CloseElement();
                });
                return;
            }

            __builder.UseElement(ref sequence, "div", this, __builder =>
            {
                var sequence = 0;

                // 还不知道怎么实现
                __builder.OpenElement(sequence++, "button");
                __builder.AddAria(ref sequence, "hidden", "true");
                __builder.AddAria(ref sequence, "label", "Scroll left");
                __builder.AddAttribute(sequence++, "type", "button");
                __builder.AddConfig(ref sequence, new BxComponentConfig(null, "bx--tab--overflow-nav-button bx--tab--overflow-nav-button--previous bx--tab--overflow-nav-button--hidden", $"{Id}-list-scroll-left"));
                __builder.AddContent(sequence++, new MarkupString("<svg focusable=\"false\" preserveAspectRatio=\"xMidYMid meet\" xmlns=\"http://www.w3.org/2000/svg\" fill=\"currentColor\" width=\"16\" height=\"16\" viewBox=\"0 0 16 16\" aria-hidden=\"true\"><path d=\"M5 8L10 3 10.7 3.7 6.4 8 10.7 12.3 10 13z\"></path></svg>"));
                __builder.CloseElement();


                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(TabListConfig, "bx--tab--list", $"{Id}-list"));
                __builder.AddAttribute(sequence++, "role", "tablist");

                __builder.AddCascadingValue(ref sequence, BxTabsGoal.Nav, ChildContent);

                __builder.CloseElement();

                // 还不知道怎么实现
                __builder.OpenElement(sequence++, "button");
                __builder.AddAria(ref sequence, "hidden", "true");
                __builder.AddAria(ref sequence, "label", "Scroll right");
                __builder.AddAttribute(sequence++, "type", "button");
                __builder.AddConfig(ref sequence, new BxComponentConfig(null, "bx--tab--overflow-nav-button bx--tab--overflow-nav-button--next bx--tab--overflow-nav-button--hidden", $"{Id}-list-scroll-right"));
                __builder.AddContent(sequence++, new MarkupString("<svg focusable=\"false\" preserveAspectRatio=\"xMidYMid meet\" xmlns=\"http://www.w3.org/2000/svg\" fill=\"currentColor\" width=\"16\" height=\"16\" viewBox=\"0 0 16 16\" aria-hidden=\"true\"><path d=\"M11 8L6 13 5.3 12.3 9.6 8 5.3 3.7 6 3z\"></path></svg>"));
                __builder.CloseElement();
            });

            __builder.AddCascadingValue(ref sequence, BxTabsGoal.Content, ChildContent);
        };

        /// <summary>
        /// 关闭选项卡
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        internal async Task OnCloseTabAsync(BxTab tab)
        {
            if (OnCloseTab.HasDelegate && !Disabled)
            {
                await OnCloseTab.InvokeAsync(tab);
            }
        }
    }
}
