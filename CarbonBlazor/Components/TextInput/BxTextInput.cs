using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 TextInput 的 Blazor 组件。  
    /// This is a Blazor component for the TextInput.
    /// </summary>
    public partial class BxTextInput : BxInputBase<string>
    {
        /// <summary>
        /// 输入框内容
        /// </summary>
        protected string InputValue => string.IsNullOrEmpty(Format) ? CurrentValueAsString ?? string.Empty : Formatter<string>.Format(CurrentValueAsString ?? string.Empty, Format);

        /// <summary>
        /// 显示密码
        /// </summary>
        protected bool ShowPassword { get; set; }

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--form-item bx--text-input-wrapper";

            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If($"bx--password-input-wrapper", () => Type.Value == BxTextInputType.Password)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            RenderFragment input__field_wrapper = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(InputWrapperConfig, $"bx--text-input__field-wrapper", $"{Id}-wrapper")
                .AddIfClass($"bx--text-input__field-wrapper--warning", () => Warn));
                __builder.IfAddAttribute(ref sequence, "data-invalid", "true", () => Invalid);
                {
                    if (Invalid)
                    {
                        __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true' class='bx--text-input__invalid-icon'><path d='M8,1C4.2,1,1,4.2,1,8s3.2,7,7,7s7-3.1,7-7S11.9,1,8,1z M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2 c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z'></path><path d='M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8 c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z' data-icon-path='inner-path' opacity='0'></path></svg>"));
                    }
                    else if (Warn)
                    {
                        __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='bx--text-input__invalid-icon bx--text-input__invalid-icon--warning'><path fill='none' d='M16,26a1.5,1.5,0,1,1,1.5-1.5A1.5,1.5,0,0,1,16,26Zm-1.125-5h2.25V12h-2.25Z' data-icon-path='inner-path'></path><path d='M16.002,6.1714h-.004L4.6487,27.9966,4.6506,28H27.3494l.0019-.0034ZM14.875,12h2.25v9h-2.25ZM16,26a1.5,1.5,0,1,1,1.5-1.5A1.5,1.5,0,0,1,16,26Z'></path><path d='M29,30H3a1,1,0,0,1-.8872-1.4614l13-25a1,1,0,0,1,1.7744,0l13,25A1,1,0,0,1,29,30ZM4.6507,28H27.3493l.002-.0033L16.002,6.1714h-.004L4.6487,27.9967Z'></path></svg>"));
                    }

                    __builder.OpenElement(sequence++, "input");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(InputConfig)
                        .AddClass($"bx--text-input").AddId($"{Id}-input")
                        .AddIfClass($"bx--text-input--invalid", () => Invalid)
                        .AddIfClass($"bx--text-input--warning", () => Warn)
                        .AddIfClass($"bx--text-input--light", () => Light)
                        .AddIfClass($"bx--password-input", () => Type.Value == BxTextInputType.Password)
                        .AddIfClass(() => $"bx--text-input--{Size}", () => Size != null));

                    __builder.AddAttribute(sequence++, "type", ShowPassword ? "text" : Type.ToString());

                    __builder.IfAddAttribute(ref sequence, "readonly", true, () => ReadOnly);
                    __builder.IfAddAttribute(ref sequence, "value", InputValue, () => !string.IsNullOrWhiteSpace(InputValue));
                    __builder.IfAddAttribute(ref sequence, "placeholder", Placeholder, () => !string.IsNullOrWhiteSpace(Placeholder));
                    __builder.IfAddAttribute(ref sequence, "title", Placeholder, () => !string.IsNullOrWhiteSpace(Placeholder));
                    __builder.IfAddAttribute(ref sequence, "disabled", () => Disabled);
                    __builder.IfAddAttribute(ref sequence, "data-invalid", "true", () => Invalid);
                    __builder.IfAddAttribute(ref sequence, "aria-invalid", "true", () => Invalid);
                    //__builder.IfAddAttribute(ref sequence, "aria-describedby", "true", () => Invalid);

                    __builder.AddEvent(ref sequence, "onchange", HandleOnChangeAsync);
                    __builder.AddEvent(ref sequence, "onkeyup", HandleOnKeyupAsync);
                    __builder.AddEvent(ref sequence, "oninput", HandleOnInputAsync);
                    __builder.AddEvent(ref sequence, "onfocusin", OnFocusin);

                    if (ChildContent != null && Value != null)
                    {
                        __builder.AddContent(sequence++, ChildContent, Value);
                    }

                    __builder.CloseElement();

                    if (Type.Value == BxTextInputType.Password)
                    {
                        // Start ButtonForward
                        __builder.OpenElement(sequence++, "button");
                        __builder.AddEvent(ref sequence, "onclick", HandleOnClickPasswordAsync, true);
                        __builder.AddConfig(ref sequence, new BxComponentConfig()
                            .AddClass($"bx--btn bx--text-input--password__visibility__toggle bx--tooltip__trigger bx--tooltip--a11y bx--tooltip--bottom bx--tooltip--align-center")
                            .AddId($"{Id}-button--password"));
                        __builder.AddContent(sequence++, new MarkupString($"<span class='bx--assistive-text'>{(ShowPassword ? "Show password" : "Hide password")}</span>"));

                        if (ShowPassword)
                        {
                            __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' style='will-change: transform;' xmlns='http://www.w3.org/2000/svg' class='bx--icon--visibility-off' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true'><path d='M2.6,11.3l0.7-0.7C2.6,9.8,1.9,9,1.5,8c1-2.5,3.8-4.5,6.5-4.5c0.7,0,1.4,0.1,2,0.4l0.8-0.8C9.9,2.7,9,2.5,8,2.5	C4.7,2.6,1.7,4.7,0.5,7.8c0,0.1,0,0.2,0,0.3C1,9.3,1.7,10.4,2.6,11.3z'></path><path d='M6 7.9c.1-1 .9-1.8 1.8-1.8l.9-.9C7.2 4.7 5.5 5.6 5.1 7.2 5 7.7 5 8.3 5.1 8.8L6 7.9zM15.5 7.8c-.6-1.5-1.6-2.8-2.9-3.7L15 1.7 14.3 1 1 14.3 1.7 15l2.6-2.6c1.1.7 2.4 1 3.7 1.1 3.3-.1 6.3-2.2 7.5-5.3C15.5 8.1 15.5 7.9 15.5 7.8zM10 8c0 1.1-.9 2-2 2-.3 0-.7-.1-1-.3L9.7 7C9.9 7.3 10 7.6 10 8zM8 12.5c-1 0-2.1-.3-3-.8l1.3-1.3c1.4.9 3.2.6 4.2-.8.7-1 .7-2.4 0-3.4l1.4-1.4c1.1.8 2 1.9 2.6 3.2C13.4 10.5 10.6 12.5 8 12.5z'></path></svg>"));
                        }
                        else
                        {
                            __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' style='will-change: transform;' xmlns='http://www.w3.org/2000/svg' class='bx--icon--visibility-on' width='16' height='16' viewBox='0 0 16 16'><path d='M15.5,7.8C14.3,4.7,11.3,2.6,8,2.5C4.7,2.6,1.7,4.7,0.5,7.8c0,0.1,0,0.2,0,0.3c1.2,3.1,4.1,5.2,7.5,5.3	c3.3-0.1,6.3-2.2,7.5-5.3C15.5,8.1,15.5,7.9,15.5,7.8z M8,12.5c-2.7,0-5.4-2-6.5-4.5c1-2.5,3.8-4.5,6.5-4.5s5.4,2,6.5,4.5	C13.4,10.5,10.6,12.5,8,12.5z'></path><path d='M8,5C6.3,5,5,6.3,5,8s1.3,3,3,3s3-1.3,3-3S9.7,5,8,5z M8,10c-1.1,0-2-0.9-2-2s0.9-2,2-2s2,0.9,2,2S9.1,10,8,10z'></path></svg>"));
                        }

                        __builder.CloseElement();
                        // End ButtonForward
                    }
                }
                __builder.CloseElement();
            };

            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);
            {
                __builder.AddContent(sequence++, LabelFragment());

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(InputOuterWrapperConfig, $"bx--text-input__field-outer-wrapper", $"{Id}-outer-wrapper"));
                {
                    __builder.AddContent(sequence++, input__field_wrapper);
                    __builder.AddContent(sequence++, HelperFragment());
                    __builder.AddContent(sequence++, RequirementFragment());
                }
                __builder.CloseElement();
            }
            __builder.CloseComponent();
        };

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickPasswordAsync(MouseEventArgs args)
        {
            ShowPassword = !ShowPassword;
            await Task.CompletedTask;
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string? value, out string result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = value ?? string.Empty;
            validationErrorMessage = null;
            return true;
        }
    }
}
