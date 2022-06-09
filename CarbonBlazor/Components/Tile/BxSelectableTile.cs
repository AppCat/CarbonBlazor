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
    /// 这是一个用于 SelectableTile 的 Blazor 组件。  
    /// This is a Blazor component for the SelectableTile.
    /// </summary>
    public partial class BxSelectableTile : BxContentComponentBase
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
            __builder.AddAttribute(sequence++, "type", "checkbox");
            __builder.AddConfig(ref sequence, new BxComponentConfig(InputConfig, $"bx--tile-input", $"{Id}-input").AddIfClass("bx--tile-input--checked", () => Selected));
            __builder.CloseElement();

            __builder.UseElement(ref sequence, "label", this, __builder =>
            {
                __builder.OpenElement(sequence++, "span");
                __builder.AddConfig(ref sequence, new BxComponentConfig(CheckmarkConfig, $"bx--tile__checkmark bx--tile__checkmark--persistent", $"{Id}-checkmark"));
                if (Selected)
                {
                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true'><path d='M26,4H6A2,2,0,0,0,4,6V26a2,2,0,0,0,2,2H26a2,2,0,0,0,2-2V6A2,2,0,0,0,26,4ZM14,21.5,9,16.5427,10.5908,15,14,18.3456,21.4087,11l1.5918,1.5772Z'></path><path fill='none' d='M14,21.5,9,16.5427,10.5908,15,14,18.3456,21.4087,11l1.5918,1.5772Z' data-icon-path='inner-path'></path></svg>"));
                }
                else
                {
                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true'><path d='M26,4H6A2,2,0,0,0,4,6V26a2,2,0,0,0,2,2H26a2,2,0,0,0,2-2V6A2,2,0,0,0,26,4ZM6,26V6H26V26Z'></path></svg>"));
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
