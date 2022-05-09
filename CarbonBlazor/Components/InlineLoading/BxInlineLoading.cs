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
    /// 这是一个用于 InlineLoading 的 Blazor 组件。  
    /// This is a Blazor component for the InlineLoading.
    /// </summary>
    public partial class BxInlineLoading : BxComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--inline-loading";

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
            var sequence = 0;

            RenderFragment loading(bool stop = false) => __builder =>
            {
                var sequence = 0;
                __builder.OpenComponent<BxLoading>(sequence++);
                __builder.AddAttribute(sequence++, nameof(BxLoading.Small), true);
                __builder.AddAttribute(sequence++, nameof(BxLoading.WithOverlay), false);
                __builder.AddAttribute(sequence++, nameof(BxLoading.Stop), stop);
                __builder.AddAttribute(sequence++, nameof(BxLoading.Description), IconDescription);
                __builder.CloseComponent();
            };

            __builder.UseElement(ref sequence, "ul", this, __builder =>
            {
                __builder.AddAria(ref sequence, "live", "assertive");

            },
            __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(AnimationConfig, "bx--inline-loading__animation", $"{Id}-animation"));

                switch (Status?.Value)
                {
                    case BxInlineLoadingStatus.Inactive:
                        __builder.AddContent(sequence++, loading(true));
                        break;
                    case BxInlineLoadingStatus.Active:
                        __builder.AddContent(sequence++, loading());
                        break;
                    case BxInlineLoadingStatus.Finished:
                        __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true' class='bx--inline-loading__checkmark-container'><path d='M8,1C4.1,1,1,4.1,1,8c0,3.9,3.1,7,7,7s7-3.1,7-7C15,4.1,11.9,1,8,1z M7,11L4.3,8.3l0.9-0.8L7,9.3l4-3.9l0.9,0.8L7,11z'></path><path d='M7,11L4.3,8.3l0.9-0.8L7,9.3l4-3.9l0.9,0.8L7,11z' data-icon-path='inner-path' opacity='0'></path><title></title></svg>"));
                        break;
                    case BxInlineLoadingStatus.Error:
                        __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true' class='bx--inline-loading--error'><path d='M8,1C4.1,1,1,4.1,1,8s3.1,7,7,7s7-3.1,7-7S11.9,1,8,1z M10.7,11.5L4.5,5.3l0.8-0.8l6.2,6.2L10.7,11.5z'></path><path fill='none' d='M10.7,11.5L4.5,5.3l0.8-0.8l6.2,6.2L10.7,11.5z' data-icon-path='inner-path' opacity='0'></path><title></title></svg>"));
                        break;
                    default:
                        __builder.AddContent(sequence++, loading());
                        break;
                }

                __builder.CloseElement();

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(TextConfig, "bx--inline-loading__text", $"{Id}-animation"));
                __builder.AddContent(sequence++, Description);
                __builder.CloseElement();
            });
        };
    }
}
