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
    /// 这是一个用于 RadioTile 的 Blazor 组件。  
    /// This is a Blazor component for the RadioTile.
    /// </summary>
    public partial class BxRadioTile : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--tile bx--tile--selectable";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--tile--is-selected", () => Selected)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "input");
            __builder.AddAttribute(sequence++, "type", "radio");
            __builder.AddConfig(ref sequence, new BxComponentConfig(InputConfig, $"bx--tile-input", $"{Id}-input")); 
            __builder.CloseElement();

            __builder.UseElement(ref sequence, "label", this, __builder =>
            {
                __builder.OpenElement(sequence++, "span");
                __builder.AddConfig(ref sequence, new BxComponentConfig(CheckmarkConfig, $"bx--tile__checkmark", $"{Id}-checkmark"));
                if (Selected)
                {
                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true'><path d='M8,1C4.1,1,1,4.1,1,8c0,3.9,3.1,7,7,7s7-3.1,7-7C15,4.1,11.9,1,8,1z M7,11L4.3,8.3l0.9-0.8L7,9.3l4-3.9l0.9,0.8L7,11z'></path><path d='M7,11L4.3,8.3l0.9-0.8L7,9.3l4-3.9l0.9,0.8L7,11z' data-icon-path='inner-path' opacity='0'></path></svg>"));
                }
                else
                {
                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true'><path d='M8,1C4.1,1,1,4.1,1,8c0,3.9,3.1,7,7,7s7-3.1,7-7C15,4.1,11.9,1,8,1z M7,11L4.3,8.3l0.9-0.8L7,9.3l4-3.9l0.9,0.8L7,11z'></path><path d='M7,11L4.3,8.3l0.9-0.8L7,9.3l4-3.9l0.9,0.8L7,11z' data-icon-path='inner-path' opacity='0'></path></svg>"));
                }
                __builder.CloseElement();

                __builder.OpenElement(sequence++, "span");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ContentConfig, $"bx--tile-content", $"{Id}-content"));
                __builder.AddContent(sequence++, ChildContent);
                __builder.CloseElement();
            });
        };

    }


}
