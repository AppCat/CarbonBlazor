using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 TextArea 的 Blazor 组件。  
    /// This is a Blazor component for the TextArea.
    /// </summary>
    public partial class BxTextArea : BxInputBase<string>
    {
        /// <summary>
        /// 输入框内容
        /// </summary>
        protected string InputValue => string.IsNullOrEmpty(Format) ? CurrentValueAsString ?? string.Empty : Formatter<string>.Format(CurrentValueAsString ?? string.Empty, Format);

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--form-item bx--text-input-wrapper";

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
            RenderFragment text_area__wrapper = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(InputWrapperConfig, $"bx--text-area__wrapper", $"{Id}-wrapper"));
                __builder.IfAddAttribute(ref sequence, "data-invalid", "true", () => Invalid);
                {
                    if (Invalid)
                    {
                        __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true' class='bx--text-area__invalid-icon'><path d='M8,1C4.2,1,1,4.2,1,8s3.2,7,7,7s7-3.1,7-7S11.9,1,8,1z M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2 c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z'></path><path d='M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8 c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z' data-icon-path='inner-path' opacity='0'></path></svg>"));
                    }

                    __builder.OpenElement(sequence++, "textarea");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(InputConfig, "bx--text-area", $"{Id}-input")
                    .AddIfClass($"bx--text-area--invalid", () => Invalid));

                    __builder.IfAddAttribute(ref sequence, "readonly", true, () => ReadOnly);
                    //__builder.IfAddAttribute(ref sequence, "value", InputValue, () => !string.IsNullOrWhiteSpace(InputValue));
                    __builder.IfAddAttribute(ref sequence, "value", CurrentValueAsString, () => !string.IsNullOrWhiteSpace(CurrentValueAsString));
                    __builder.IfAddAttribute(ref sequence, "placeholder", Placeholder, () => !string.IsNullOrWhiteSpace(Placeholder));
                    __builder.IfAddAttribute(ref sequence, "title", Placeholder, () => !string.IsNullOrWhiteSpace(Placeholder));
                    __builder.IfAddAttribute(ref sequence, "disabled", () => Disabled);
                    __builder.IfAddAttribute(ref sequence, "data-invalid", "true", () => Invalid);
                    __builder.IfAddAttribute(ref sequence, "aria-invalid", "true", () => Invalid);
                    __builder.IfAddAttribute(ref sequence, "aria-describedby", $"{Id}-requirement", () => Invalid);
                    __builder.IfAddAttribute(ref sequence, "cols", Cols, () => Cols is not null);
                    __builder.IfAddAttribute(ref sequence, "rows", Rows, () => Rows is not null);

                    __builder.AddEvent(ref sequence, "onchange", HandleOnChangeAsync);
                    __builder.AddEvent(ref sequence, "onkeyup", HandleOnKeyupAsync);
                    __builder.AddEvent(ref sequence, "oninput", HandleOnInputAsync);
                    __builder.AddEvent(ref sequence, "onfocusin", OnFocusin);

                    if (ChildContent != null && Value != null)
                    {
                        __builder.AddContent(sequence++, ChildContent, Value);
                    }

                    __builder.CloseElement();
                }
                __builder.CloseElement();
            };

            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);
            {
                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(LabelWrapperConfig, $"bx--text-area__label-wrapper", $"{Id}-label-wrapper"));
                {
                    __builder.AddContent(sequence++, LabelFragment());
                    if(EnableCounter && MaxCount is not null && MaxCount > 0)
                    {
                        __builder.AddContent(sequence++, new MarkupString($"<div class='bx--label'>{CurrentValueAsString?.Length ?? 0}/{MaxCount}</div>"));
                    }
                }
                __builder.CloseElement();

                __builder.AddContent(sequence++, text_area__wrapper);
                __builder.AddContent(sequence++, HelperFragment());
                __builder.AddContent(sequence++, RequirementFragment());
            }
            __builder.CloseComponent();
        };

        /// <summary>
        /// 尝试从字符串解析值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <param name="validationErrorMessage"></param>
        /// <returns></returns>
        protected override bool TryParseValueFromString(string? value, out string result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = value ?? string.Empty;
            validationErrorMessage = null;
            return true;
        }
    }
}
