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
    /// 这是一个用于 NumberInput 的 Blazor 组件。  
    /// This is a Blazor component for the NumberInput.
    /// </summary>
    public partial class BxNumberInput<TValue> : BxInputBase<TValue>
        where TValue : struct
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--form-item";

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
            RenderFragment number__controls = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ControlsConfig).AddClass($"bx--number__controls").AddId($"{Id}-number-controls"));
                {
                    __builder.OpenElement(sequence++, "button");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(ControlBtnConfig).AddClass($"bx--number__control-btn down-icon").AddId($"{Id}-number-controls-btn"));
                    __builder.AddAttribute(sequence++, "tabindex", "-1");
                    __builder.AddAttribute(sequence++, "type", "button");
                    __builder.IfAddAttribute(ref sequence, "title", DecrementTitle, () => !string.IsNullOrEmpty(DecrementTitle));
                    __builder.IfAddAttribute(ref sequence, "aria-label", DecrementTitle, () => !string.IsNullOrEmpty(DecrementTitle));

                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='down-icon'><path d='M8 15H24V17H8z'></path></svg>"));

                    __builder.CloseElement();

                    __builder.AddContent(sequence++, new MarkupString("<div class='bx--number__rule-divider'></div>"));

                    __builder.OpenElement(sequence++, "button");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(ControlBtnConfig).AddClass($"bx--number__control-btn up-icon").AddId($"{Id}-number-controls-btn"));
                    __builder.AddAttribute(sequence++, "tabindex", "-1");
                    __builder.AddAttribute(sequence++, "type", "button");
                    __builder.IfAddAttribute(ref sequence, "title", IncrementTitle, () => !string.IsNullOrEmpty(IncrementTitle));
                    __builder.IfAddAttribute(ref sequence, "aria-label", IncrementTitle, () => !string.IsNullOrEmpty(IncrementTitle));

                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='up-icon'><path d='M17 15L17 8 15 8 15 15 8 15 8 17 15 17 15 24 17 24 17 17 24 17 24 15z'></path></svg>"));

                    __builder.CloseElement();

                    __builder.AddContent(sequence++, new MarkupString("<div class='bx--number__rule-divider'></div>"));
                }
                __builder.CloseElement();
            };

            RenderFragment input = __builder =>
           {
               var sequence = 0;

               __builder.OpenElement(sequence++, "input");
               __builder.AddConfig(ref sequence, new BxComponentConfig(InputConfig)
                   .AddClass($"bx--text-input").AddId($"{Id}-input")
                   .AddIfClass(() => $"bx--text-input--{Size}", () => Size != null));

               __builder.AddAttribute(sequence++, "type", "number");
               __builder.AddAttribute(sequence++, "value", Value);
               __builder.AddAttribute(sequence++, "pattern", "[0-9]*");
               __builder.IfAddAttribute(ref sequence, "readonly", true, () => ReadOnly);
               //__builder.IfAddAttribute(ref sequence, "value", InputValue, () => !string.IsNullOrWhiteSpace(InputValue));
               __builder.IfAddAttribute(ref sequence, "disabled", () => Disabled);
               __builder.IfAddAttribute(ref sequence, "data-invalid", Invalid, () => Invalid);
               __builder.IfAddAttribute(ref sequence, "aria-invalid", Invalid, () => Invalid);
               __builder.IfAddAttribute(ref sequence, "aria-describedby", $"{Id}-requirement", () => Invalid);
               __builder.IfAddAttribute(ref sequence, "max", Max, () => Max != null);
               __builder.IfAddAttribute(ref sequence, "min", Min, () => Min != null);
               __builder.IfAddAttribute(ref sequence, "step", Step, () => Step != null);
               __builder.IfAddAttribute(ref sequence, "placeholder", Placeholder, () => !string.IsNullOrWhiteSpace(Placeholder));

               __builder.AddEvent(ref sequence, "onchange", HandleOnChangeAsync);
               __builder.AddEvent(ref sequence, "onkeyup", HandleOnKeyupAsync);
               __builder.AddEvent(ref sequence, "oninput", HandleOnInputAsync);
               __builder.AddEvent(ref sequence, "onfocusin", OnFocusin);

               if (ChildContent != null)
               {
                   __builder.AddContent(sequence++, ChildContent, Value);
               }

               __builder.CloseElement();
           };

            RenderFragment number__input_wrapper = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(InputWrapperConfig).AddClass($"bx--number__input-wrapper").AddId($"{Id}-input-wrapper"));

                __builder.AddContent(sequence++, input);

                if (Invalid)
                {
                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true' class='bx--number__invalid'><path d='M8,1C4.2,1,1,4.2,1,8s3.2,7,7,7s7-3.1,7-7S11.9,1,8,1z M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2 c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z'></path><path d='M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8 c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z' data-icon-path='inner-path' opacity='0'></path></svg>"));
                }
                else if (Warn)
                {
                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='bx--number__invalid bx--number__invalid--warning'><path fill='none' d='M16,26a1.5,1.5,0,1,1,1.5-1.5A1.5,1.5,0,0,1,16,26Zm-1.125-5h2.25V12h-2.25Z' data-icon-path='inner-path'></path><path d='M16.002,6.1714h-.004L4.6487,27.9966,4.6506,28H27.3494l.0019-.0034ZM14.875,12h2.25v9h-2.25ZM16,26a1.5,1.5,0,1,1,1.5-1.5A1.5,1.5,0,0,1,16,26Z'></path><path d='M29,30H3a1,1,0,0,1-.8872-1.4614l13-25a1,1,0,0,1,1.7744,0l13,25A1,1,0,0,1,29,30ZM4.6507,28H27.3493l.002-.0033L16.002,6.1714h-.004L4.6487,27.9967Z'></path></svg>"));
                }

                __builder.AddContent(sequence++, number__controls);

                __builder.CloseElement();
            };

            RenderFragment number = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(NumberConfig).AddClass($"bx--number")
                    .AddId($"{Id}-input-wrapper")
                    .AddIfClass($"bx--dropdown--invalid", () => Invalid));
                __builder.IfAddAttribute(ref sequence, "data-invalid", Invalid, () => Invalid);
                __builder.AddContent(sequence++, LabelFragment());
                __builder.AddContent(sequence++, number__input_wrapper);
                __builder.AddContent(sequence++, HelperFragment());
                __builder.AddContent(sequence++, RequirementFragment());

                __builder.CloseElement();
            };

            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            __builder.AddContent(sequence++, number);

            __builder.CloseComponent();
        };
    }
}
