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
    /// 这是一个用于 Search 的 Blazor 组件。  
    /// This is a Blazor component for the Search.
    /// </summary>
    public partial class BxSearch : BxInputComponentBaseOf<string>
    {
        /// <summary>
        /// Gets or sets the associated <see cref="ElementReference"/>.
        /// <para>
        /// May be <see langword="null"/> if accessed before the component is rendered.
        /// </para>
        /// </summary>
        [DisallowNull] public ElementReference? Element { get; protected set; }

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--search";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .AddEnum(Size, () => $"{fixedClass}--{Size}")
                .If("bx--search--disabled", () => Disabled)
                .If("bx--toolbar-search-container-persistent", () => (FatherComponentContext?.FatherComponent?.ClassMapper?.Result?.Contains("table-container") ?? false))
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.UseElement(ref sequence, "div", this, 
            __builder =>
            {
                var sequence = 0;
                __builder.AddAria(ref sequence, "labelledby", "search-1-search");
            }, 
            __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(MagnifierConfig, "bx--search-magnifier", $"{Id}-magnifier"));
                __builder.AddContent(sequence++, new MarkupString("<svg focusable=\"false\" preserveAspectRatio=\"xMidYMid meet\" xmlns=\"http://www.w3.org/2000/svg\" fill=\"currentColor\" width=\"16\" height=\"16\" viewBox=\"0 0 16 16\" aria-hidden=\"true\" class=\"bx--search-magnifier-icon\"><path d=\"M15,14.3L10.7,10c1.9-2.3,1.6-5.8-0.7-7.7S4.2,0.7,2.3,3S0.7,8.8,3,10.7c2,1.7,5,1.7,7,0l4.3,4.3L15,14.3z M2,6.5 C2,4,4,2,6.5,2S11,4,11,6.5S9,11,6.5,11S2,9,2,6.5z\"></path></svg>"));
                __builder.CloseElement();

                __builder.OpenElement(sequence++, "label");
                __builder.AddConfig(ref sequence, new BxComponentConfig(LabelConfig, "bx-label", $"{Id}-label"));
                __builder.AddContent(sequence++, LabelText);
                __builder.CloseElement();

                __builder.OpenElement(sequence++, "input");
                __builder.AddConfig(ref sequence, new BxComponentConfig(InputConfig, "bx--search-input", $"{Id}-input"));
                //__builder.AddAttribute(sequence++, "value", BindConverter.FormatValue(CurrentValue));
                __builder.AddAttribute(sequence++, "value", CurrentValueAsString);
                __builder.AddAttribute(sequence++, "oninput", EventCallback.Factory.CreateBinder<string?>(this, async __value => await SetStringValueAsync(__value), CurrentValueAsString));
                __builder.IfAddAttribute(ref sequence, "autocomplete", AutoComplete, () => !string.IsNullOrWhiteSpace(AutoComplete));
                __builder.IfAddAttribute(ref sequence, "placeholder", Placeholder, () => !string.IsNullOrWhiteSpace(Placeholder));
                __builder.IfAddAttribute(ref sequence, "readonly", true, () => ReadOnly);
                __builder.IfAddAttribute(ref sequence, "disabled", () => Disabled);
                __builder.AddAria(ref sequence, "role", Role);
                __builder.AddElementReferenceCapture(sequence++, __inputReference => Element = __inputReference);
                __builder.CloseElement();

                if (!string.IsNullOrEmpty(CurrentValue))
                {
                    __builder.OpenElement(sequence++, "button");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(CloseConfig, "bx--search-close", $"{Id}-close"));
                    __builder.AddEvent(ref sequence, "onclick", HandleCloseAsync, true);
                    __builder.AddAttribute(sequence++, "type", "button");
                    __builder.IfAddAttribute(ref sequence, "title", CloseButtonLabelText, () => !string.IsNullOrWhiteSpace(CloseButtonLabelText));
                    __builder.IfAddAttribute(ref sequence, "aria-label", CloseButtonLabelText, () => !string.IsNullOrWhiteSpace(CloseButtonLabelText));
                    __builder.AddContent(sequence++, new MarkupString("<svg focusable=\"false\" preserveAspectRatio=\"xMidYMid meet\" xmlns=\"http://www.w3.org/2000/svg\" fill=\"currentColor\" width=\"16\" height=\"16\" viewBox=\"0 0 32 32\" aria-hidden=\"true\"><path d=\"M24 9.4L22.6 8 16 14.6 9.4 8 8 9.4 14.6 16 8 22.6 9.4 24 16 17.4 22.6 24 24 22.6 17.4 16 24 9.4z\"></path></svg>"));
                    __builder.CloseElement();
                }
            });
        };

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleCloseAsync(MouseEventArgs args)
        {
            await SetValueAsync(string.Empty);
        }

        /// <summary>
        /// 尝试从字符串中解析值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <param name="validationErrorMessage"></param>
        /// <returns></returns>
        protected override bool TryParseValueFromString(string? value, out string? result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
