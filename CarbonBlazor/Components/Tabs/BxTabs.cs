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

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(TabListConfig, "bx--tab--list", $"{Id}-list"));
                __builder.AddAttribute(sequence++, "role", "tablist");

                __builder.AddCascadingValue(ref sequence, BxTabsGoal.Nav, ChildContent);

                __builder.CloseElement();

                //__builder.AddContent(sequence++, new MarkupString("<button aria-hidden='false' aria-label='Scroll right' class='bx--tab--overflow-nav-button bx--tab--overflow-nav-button--next' type='button'><svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true'><path d='M11 8L6 13 5.3 12.3 9.6 8 5.3 3.7 6 3z'></path></svg></button>"));
            });

            __builder.AddCascadingValue(ref sequence, BxTabsGoal.Content, ChildContent);
        };
    }
}
