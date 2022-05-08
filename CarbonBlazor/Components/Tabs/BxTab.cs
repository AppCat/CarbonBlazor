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
    /// 这是一个用于 Tab 的 Blazor 组件。  
    /// This is a Blazor component for the Tab.
    /// </summary>
    public partial class BxTab : BxOptionComponentBase<BxTabs, BxTab, string>
    {
        /// <summary>
        /// 渲染目标
        /// </summary>
        [CascadingParameter]
        public BxTabsGoal Goal { get; set; }

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--tabs__nav-item bx--tabs__nav-link";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--tabs__nav-item--selected", () => Selected)
                .If("bx--tabs__nav-item--disabled", () => Disabled)
                ;
        }

        /// <summary>
        /// 渲染内容
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;
            var navId = $"{Id}-nav";
            var contentId = $"{Id}-content";

            if (Goal == BxTabsGoal.Nav)
            {
                __builder.UseElement(ref sequence, "button", this,
                __builder =>
                {
                    __builder.AddAttribute(sequence++, "id", navId);
                    __builder.AddAttribute(sequence++, "type", "button");
                    __builder.AddAttribute(sequence++, "role", "tab");
                    __builder.AddAttribute(sequence++, "tabindex", Selected ? "0" : "-1");
                    __builder.AddAria(ref sequence, "controls", contentId);
                    __builder.AddAria(ref sequence, "selected", Selected);
                    __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
                },
                __builder =>
                {
                    if (ValueTemplate != null)
                    {
                        __builder.AddContent(sequence++, ValueTemplate, Tag);
                    }
                    else if (!string.IsNullOrWhiteSpace(Value))
                    {
                        __builder.AddContent(sequence++, Value);
                    }
                });
            }
            else if (Goal == BxTabsGoal.Content)
            {
                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ContentConfig, "bx--tab-content", contentId));
                __builder.AddAttribute(sequence++, "type", "tabpanel");
                __builder.AddAria(ref sequence, "labelledby", navId);
                __builder.AddAttribute(sequence++, "tabindex", Selected ? "0" : "-1");
                if (!Selected)
                {
                    __builder.AddAttribute(sequence++, "hidden");
                }
                __builder.AddContent(sequence++, ChildContent);
                __builder.CloseElement();
            }
            else
            {
                __builder.AddContent(sequence++, new MarkupString("<li class='bx--tabs__nav-item'><div class='bx--tabs__nav-link'><span></span></div></li>"));
            }
        };

        /// <summary>
        /// 处理点击
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override async Task HandleOnClickAsync(MouseEventArgs args)
        {
            if (Selected)
                return;

            await base.HandleOnClickAsync(args);
        }
    }
}
