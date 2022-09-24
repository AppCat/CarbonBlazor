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
    /// 这是一个用于 Dropdown 的 Blazor 组件。  
    /// This is a Blazor component for the Dropdown.
    /// </summary>
    public partial class BxDropdown : BxListBoxComponentBaseOf<BxDropdownOption, string>
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--dropdown__wrapper bx--list-box__wrapper";

            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--dropdown__wrapper--inline bx--list-box__wrapper--inline", () => Inline)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            RenderFragment button = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "button");
                __builder.AddEvent(ref sequence, "onclick", HandleOnClickMenuIconAsync, true, true);

                __builder.AddConfig(ref sequence, new BxComponentConfig(ButtonConfig, $"bx--list-box__field", $"{Id}-button"));
                __builder.AddAttribute(sequence++, "type", "button");
                __builder.AddAttribute(sequence++, "aria-haspopup", "true");
                __builder.AddAttribute(sequence++, "aria-expanded", CurrentExpanded);
                {
                    __builder.OpenElement(sequence++, "span");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(TextConfig, $"bx--list-box__label", $"{Id}-text"));

                    if (string.IsNullOrEmpty(SelectedKey) && !string.IsNullOrEmpty(DefaultSelectedKey) && Options.TryGetValue(DefaultSelectedKey, out BxDropdownOption? option))
                    {
                        __builder.AddContent(sequence++, option.Value ?? option.Key);
                    }
                    else if (!string.IsNullOrEmpty(SelectedKey) && Options.TryGetValue(SelectedKey, out BxDropdownOption? selectedOption))
                    {
                        __builder.AddContent(sequence++, selectedOption.Value ?? selectedOption.Key);
                    }
                    else
                    {
                        __builder.AddContent(sequence++, Placeholder);
                    }

                    __builder.CloseElement();

                    __builder.OpenElement(sequence++, "div");
                    __builder.AddEvent(ref sequence, "onclick", HandleOnClickMenuIconAsync, true, true);
                    __builder.AddConfig(ref sequence, new BxComponentConfig(IconConfig)
                        .AddClass($"bx--list-box__menu-icon")
                        .AddIfClass($"bx--list-box__menu-icon--open", () => CurrentExpanded)
                        .SetId($"{Id}-icon"));
                    if (!CurrentExpanded)
                    {
                        __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' name='chevron--down' aria-label='Open menu' width='16' height='16' viewBox='0 0 16 16' role='img'><path d='M8 11L3 6 3.7 5.3 8 9.6 12.3 5.3 13 6z'></path><title>Open menu</title></svg>"));
                    }
                    else
                    {
                        __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' name='chevron--down' aria-label='Close menu' width='16' height='16' viewBox='0 0 16 16' role='img'><path d='M8 11L3 6 3.7 5.3 8 9.6 12.3 5.3 13 6z'></path><title>Close menu</title></svg>"));
                    }
                    __builder.CloseElement();
                }
                __builder.CloseElement();
            };

            RenderFragment dropdown = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(DropdownConfig, $"bx--dropdown bx--list-box", $"{Id}-dropdown")
                    .AddIfClass($"bx--dropdown--light", () => Light)
                    .AddIfClass($"bx--dropdown--invalid", () => Invalid)
                    .AddIfClass($"bx--dropdown--open", () => CurrentExpanded)
                    .AddIfClass($"bx--list-box--expanded", () => CurrentExpanded)
                    .AddIfClass($"bx--list-box--warning", () => Warn)
                    .AddIfClass($"bx--dropdown--disabled", () => Disabled)
                    .AddIfClass($"bx--dropdown--inline", () => Inline)
                    .AddIfClass($"bx--list-box--{Size}", () => Size != null)
                    .AddIfClass($"bx--dropdown--{Size}", () => Size != null)
                    .AddIfClass($"bx--list-box--up", () => Direction?.Value == BxListBoxDirection.Top)
                    );
                __builder.AddAttribute(sequence++, "data-dropdown");
                __builder.AddAttribute(sequence++, "data-value");
                __builder.IfAddAttribute(ref sequence, "data-dropdown-type", "inline", () => Inline);
                __builder.IfAddAttribute(ref sequence, "data-invalid", Invalid, () => Invalid);
                {
                    if (Invalid)
                    {
                        __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' style='will-change: transform;' xmlns='http://www.w3.org/2000/svg' class='bx--dropdown__invalid-icon' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true'><path d='M8,1C4.2,1,1,4.2,1,8s3.2,7,7,7s7-3.1,7-7S11.9,1,8,1z M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2	c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z'></path><path d='M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8	c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z' data-icon-path='inner-path' opacity='0'></path></svg>"));
                    }
                    else if (Warn)
                    {
                        __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='bx--list-box__invalid-icon bx--list-box__invalid-icon--warning'><path fill='none' d='M16,26a1.5,1.5,0,1,1,1.5-1.5A1.5,1.5,0,0,1,16,26Zm-1.125-5h2.25V12h-2.25Z' data-icon-path='inner-path'></path><path d='M16.002,6.1714h-.004L4.6487,27.9966,4.6506,28H27.3494l.0019-.0034ZM14.875,12h2.25v9h-2.25ZM16,26a1.5,1.5,0,1,1,1.5-1.5A1.5,1.5,0,0,1,16,26Z'></path><path d='M29,30H3a1,1,0,0,1-.8872-1.4614l13-25a1,1,0,0,1,1.7744,0l13,25A1,1,0,0,1,29,30ZM4.6507,28H27.3493l.002-.0033L16.002,6.1714h-.004L4.6487,27.9967Z'></path></svg>"));
                    }

                    __builder.AddContent(sequence++, button);
                    __builder.AddContent(sequence++, BoxMenuFragment());
                }
                __builder.CloseElement();
            };

            //RenderFragment dropdown__wrapper = __builder =>
            //{
            //    var sequence = 0;

            //    __builder.OpenElement(sequence++, "div");
            //    __builder.AddConfig(ref sequence, new BxComponentConfig(InputWrapperConfig, "bx--dropdown__wrapper bx--list-box__wrapper", )
            //        .AddClass($"bx--dropdown__wrapper bx--list-box__wrapper")
            //        .AddIfClass($"bx--dropdown__wrapper--inline bx--list-box__wrapper--inline", () => Inline)
            //        .AddId($"{Id}-dropdown__wrapper"));
            //    __builder.IfAddAttribute(ref sequence, "data-invalid", Invalid, () => Invalid);
            //    {
            //        __builder.AddContent(sequence++, LabelFragment());
            //        __builder.AddContent(sequence++, dropdown);
            //        __builder.AddContent(sequence++, HelperFragment());
            //        __builder.AddContent(sequence++, RequirementFragment());
            //    }
            //    __builder.CloseElement();
            //};

            var sequence = 0;

            __builder.UseElement(ref sequence, "div", this, __builder =>
            {
                var sequence = 0;
                __builder.AddContent(sequence++, LabelFragment());
                __builder.AddContent(sequence++, dropdown);
                __builder.AddContent(sequence++, HelperFragment());
                __builder.AddContent(sequence++, RequirementFragment());
            });
        };

        /// <summary>
        /// 处理外部点击
        /// </summary>
        /// <param name="path"></param>
        protected override void HandleExternalClick(ClickElement[] path)
        {
            if (!CurrentExpanded)
                return;
            if (path.Any(e => e.Id == $"{Id}-dropdown")) // 包含自己不隐藏
                return;
            InvokeAsync(() => HideAsync());
        }

        #region SDLC

        /// <summary>
        /// 初始化后
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            OnDocumentClick += HandleExternalClick;
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            OnDocumentClick -= HandleExternalClick;
        }

        #endregion

        /// <summary>
        /// 尝试解析
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <param name="validationErrorMessage"></param>
        /// <returns></returns>
        protected override bool TryParseValueFromString(string? value, [NotNullWhen(false)] out string result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
