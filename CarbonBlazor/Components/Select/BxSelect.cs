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
    /// 这是一个用于 Select 的 Blazor 组件。  
    /// This is a Blazor component for the Select.
    /// </summary>
    public partial class BxSelect : BxSelectComponentBase<BxSelectOption, string>
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--select";

            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If($"bx--select--inline", () => Inline)
                .If($"bx--select--invalid", () => Invalid)
                .If($"bx--select--warning", () => Warn)
                .If($"bx--select--light", () => Light)
                .If($"bx--select--disabled", () => Disabled)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            RenderFragment select = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "select");
                __builder.AddConfig(ref sequence, new BxComponentConfig(InputConfig).AddClass($"bx--select-input")
                    .SetId($"{Id}-select")
                    .AddIfClass(() => $"bx--select-input--{Size}", () => Size != null));
                __builder.IfAddAttribute(ref sequence, "data-invalid", Invalid, () => Invalid);

                if (!Disabled)
                {
                    __builder.AddEvent<ChangeEventArgs>(ref sequence, "onchange", this, async args =>
                    {
                        if (args != null && args.Value != null)
                        {
                            var key = args.Value.ToString(); 
                            if (!string.IsNullOrEmpty(key) && Options.ContainsKey(key))
                            {
                                await SelectedOptionAsync(Options[key], true);
                            }
                        }
                    });
                }

                if (!string.IsNullOrWhiteSpace(Placeholder))
                {
                    __builder.OpenComponent<BxSelectOption>(sequence++);

                    __builder.AddAttribute(sequence++, nameof(BxSelectOption.Key), nameof(Placeholder));
                    __builder.AddAttribute(sequence++, nameof(BxSelectOption.Value), Placeholder);
                    __builder.AddAttribute(sequence++, nameof(BxSelectOption.Disabled), true);
                    __builder.AddAttribute(sequence++, nameof(BxSelectOption.Attributes), new Dictionary<string, object> { { "selected", true }, { "hidden", true } });

                    __builder.CloseComponent();
                }

                __builder.AddContent(sequence++, ChildContent);
                __builder.CloseElement();


                if (Invalid)
                {
                    __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' style='will-change: transform;' xmlns='http://www.w3.org/2000/svg' class='bx--select__arrow' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true'><path d='M8 11L3 6 3.7 5.3 8 9.6 12.3 5.3 13 6z'></path></svg><svg focusable='false' preserveAspectRatio='xMidYMid meet' style='will-change: transform;' xmlns='http://www.w3.org/2000/svg' class='bx--select__invalid-icon' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true'><path d='M8,1C4.2,1,1,4.2,1,8s3.2,7,7,7s7-3.1,7-7S11.9,1,8,1z M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2	c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z'></path><path d='M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z' data-icon-path='inner-path' opacity='0'></path></svg>"));
                }
                else if (Warn)
                {
                    __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true' class='bx--select__arrow'><path d='M8 11L3 6 3.7 5.3 8 9.6 12.3 5.3 13 6z'></path></svg><svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='bx--select__invalid-icon bx--select__invalid-icon--warning'><path fill='none' d='M16,26a1.5,1.5,0,1,1,1.5-1.5A1.5,1.5,0,0,1,16,26Zm-1.125-5h2.25V12h-2.25Z' data-icon-path='inner-path'></path><path d='M16.002,6.1714h-.004L4.6487,27.9966,4.6506,28H27.3494l.0019-.0034ZM14.875,12h2.25v9h-2.25ZM16,26a1.5,1.5,0,1,1,1.5-1.5A1.5,1.5,0,0,1,16,26Z'></path><path d='M29,30H3a1,1,0,0,1-.8872-1.4614l13-25a1,1,0,0,1,1.7744,0l13,25A1,1,0,0,1,29,30ZM4.6507,28H27.3493l.002-.0033L16.002,6.1714h-.004L4.6487,27.9967Z'></path></svg>"));
                }
                else
                {
                    __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' style='will-change: transform;' xmlns='http://www.w3.org/2000/svg' class='bx--select__arrow' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true'><path d='M8 11L3 6 3.7 5.3 8 9.6 12.3 5.3 13 6z'></path></svg>"));
                }
            };

            RenderFragment input__wrapper = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(InputWrapperConfig).AddClass($"bx--select-input__wrapper").SetId($"{Id}-input__wrapper"));
                __builder.IfAddAttribute(ref sequence, "data-invalid", Invalid, () => Invalid);
                {
                    __builder.AddContent(sequence++, select);
                }
                __builder.CloseElement();
            };

            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            if (Simplicity)
            {
                __builder.AddContent(sequence++, select);
            }
            else
            {
                __builder.AddContent(sequence++, LabelFragment());
                __builder.AddContent(sequence++, input__wrapper);
                __builder.AddContent(sequence++, HelperFragment());
                __builder.AddContent(sequence++, RequirementFragment());
            }
            __builder.CloseComponent();

            
        };
    }
}
