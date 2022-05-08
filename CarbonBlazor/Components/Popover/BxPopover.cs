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
    /// 这是一个用于 Popover 的 Blazor 组件。  
    /// This is a Blazor component for the Popover.
    /// </summary>
    public partial class BxPopover : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--popover-container";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .AddEnum(Align)
                .If("bx--popover--caret", () => Caret)
                .If("bx--popover--drop-shadow", () => DropShadow)
                .If("bx--popover--high-contrast", () => HighContrast)
                .If("bx--popover--open", () => Open)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            RenderFragment content = __builder =>
            {
                var sequence = 0;
                __builder.OpenElement(sequence++, "span");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ContentConfig, "bx--popover-content p-3", $"{Id}-content"));

                if (ContentTemplate != null)
                {
                    __builder.AddContent(sequence++, ContentTemplate);
                }
                else
                {
                    __builder.OpenElement(sequence++, "p");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(TitleConfig, "popover-title", $"{Id}-title"));
                    __builder.AddContent(sequence++, Title);
                    __builder.CloseElement();

                    __builder.OpenElement(sequence++, "p");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(DetailsConfig, "popover-details", $"{Id}-details"));
                    __builder.AddContent(sequence++, Details);
                    __builder.CloseElement();
                }

                __builder.CloseElement();
            };

            var sequence = 0;
            __builder.OpenElement(sequence++, "span");
            __builder.AddComponent(ref sequence, this);
            {
                __builder.AddContent(sequence++, ChildContent);

                __builder.OpenElement(sequence++, "span");
                __builder.AddConfig(ref sequence, new BxComponentConfig(PopoverConfig, "bx--popover", $"{Id}-popover"));
                {
                    __builder.AddContent(sequence++, content);

                    if (Caret)
                    {
                        __builder.AddContent(sequence++, new MarkupString("<span class='bx--popover-caret'></span>"));
                    }
                }
                __builder.CloseElement();
            }
            __builder.CloseComponent();
        };
    }
}
