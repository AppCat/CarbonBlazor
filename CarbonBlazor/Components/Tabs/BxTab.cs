using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                var tabs = FatherComponentContext?.FatherComponent as BxTabs;
                bool allowCloseTab = tabs?.AllowCloseTab ?? false;
                bool contained = tabs?.Contained ?? false;

                StyleMapper
                .AddIf("position", "relative", () => allowCloseTab)
                .AddIf("padding-right", "40px", () => allowCloseTab)
                ;

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

                    if (allowCloseTab)
                    {
                        var buttonConfig = new BxComponentConfig();

                        buttonConfig
                        .SetId($"{contentId}-close")
                        .AddStyle("position", "absolute")
                        .AddStyle("top", contained && Selected ? "2px" : "0px")
                        .AddStyle("right", "0px")
                        .AddIfStyle("height", "46px", () => contained)
                        .AddStyle("border-color", "transparent")
                        .AddStyle("box-shadow", "inset 0 0 0 0px transparent, inset 0 0 0 0px transparent")
                        ;

                        __builder.OpenComponent<BxButton>(sequence++);
                        __builder.AddConfig(ref sequence, buttonConfig);
                        __builder.AddAttribute(sequence++, nameof(BxButton.HasIconOnly), true);
                        __builder.AddAttribute(sequence++, nameof(BxButton.Kind), new EnumMix<BxButtonKind>(BxButtonKind.Ghost));
                        __builder.AddAttribute(sequence++, nameof(BxButton.Size), new EnumMix<BxButtonSize>(BxButtonSize.Md));
                        __builder.AddAttribute(sequence++, nameof(BxButton.Disabled), Disabled);
                        __builder.AddAttribute(sequence++, nameof(BxButton.OnClickStopPropagation), true);
                        __builder.AddAttribute(sequence++, nameof(BxButton.OnClick), EventCallback.Factory.Create<MouseEventArgs>(this, async e =>
                        {
                            await tabs.OnCloseTabAsync(this);
                        }));
                        __builder.AddAttribute(sequence++, nameof(BxButton.ChildContent), (RenderFragment)(__builder =>
                        {
                            var sequence = 0;
                            __builder.AddContent(sequence++, new MarkupString("<svg focusable=\"false\" preserveAspectRatio=\"xMidYMid meet\" xmlns=\"http://www.w3.org/2000/svg\" fill=\"currentColor\" width=\"16\" height=\"16\" viewBox=\"0 0 32 32\" aria-hidden=\"true\"><path d=\"M24 9.4L22.6 8 16 14.6 9.4 8 8 9.4 14.6 16 8 22.6 9.4 24 16 17.4 22.6 24 24 22.6 17.4 16 24 9.4z\"></path></svg>"));
                        }));
                        __builder.CloseComponent();
                    }
                });
            }
            else if (Goal == BxTabsGoal.Content)
            {
                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ContentConfig, "bx--tab-content", contentId)
                    .AddIfClass("bx--tab-content--interactive", () => Interactive));
                __builder.AddAttribute(sequence++, "type", "tabpanel");
                __builder.AddAria(ref sequence, "labelledby", navId);
                if (!Interactive)
                {
                    __builder.AddAttribute(sequence++, "tabindex", Selected ? "0" : "-1");
                }
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
