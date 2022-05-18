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
    /// 这是一个用于 OverflowMenuOpiton 的 Blazor 组件。  
    /// This is a Blazor component for the OverflowMenuOpiton.
    /// </summary>
    public partial class BxOverflowMenuOption : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--overflow-menu-options__option";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--overflow-menu--divider", () => HasDivider)
                .If("bx--overflow-menu-options__option--danger", () => IsDelete)
                .If("bx--overflow-menu-options__option--disabled", () => Disabled)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.UseElement(ref sequence, "li", this, __builder =>
            {
                __builder.AddAttribute(sequence++, "role", "none");

                __builder.OpenElement(sequence++, "button");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ButtonConfig, "bx--overflow-menu-options__btn", $"{Id}-button"));
                __builder.IfAddAttribute(ref sequence, "disabled", () => Disabled);
                __builder.AddAttribute(sequence++, "role", "none");
                __builder.AddAttribute(sequence++, "tabindex", "-1");
                if (!Disabled)
                {
                    __builder.AddEvent(ref sequence, "onclick", OnClick);
                    __builder.AddEvent(ref sequence, "onmousedown", OnMouseDown);
                    __builder.AddEvent(ref sequence, "onmouseup", OnMouseUp);
                }
                __builder.AddEvent(ref sequence, "onfocus", OnFocus);
                __builder.AddEvent(ref sequence, "onblur", OnBlur);
                {
                    __builder.OpenElement(sequence++, "div");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(ContentConfig, "bx--overflow-menu-options__option-content", $"{Id}-content"));
                    __builder.EitherOrAddContent(ref sequence, TextTemplate, Text, () => TextTemplate != null);
                    __builder.CloseElement();
                }
                __builder.CloseElement();

            }, null);
        };
    }
}
