using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 ComboBox 的 Blazor 组件。  
    /// This is a Blazor component for the ComboBox.
    /// </summary>
    public partial class BxComboBox : BxListBoxComponentBase<BxComboBoxOption>
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
            RenderFragment box__selection = __builder =>
            {
                if (SelectedOption == null && string.IsNullOrEmpty(Value))
                    return;

                var sequence = 0;

                __builder.OpenElement(sequence++, "button");
                __builder.AddAttribute(sequence++, "aria-haspopup", "true");
                __builder.AddAttribute(sequence++, "title", "Clear selected item");
                __builder.AddAttribute(sequence++, "aria-label", "Clear selected item");
                __builder.AddConfig(ref sequence, new BxComponentConfig(SelectionConfig)
                    .AddClass($"bx--list-box__selection")
                    .AddId($"{Id}-box__selection"));
                __builder.AddAttribute(sequence++, "type", "button");
                __builder.AddAttribute(sequence++, "role", "button");
                __builder.AddAttribute(sequence++, "tabindex", 0);
                __builder.AddEvent(ref sequence, "onclick", HandleOnClickSelectionAsync, true, true);
                __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' style='will-change: transform;' xmlns='http://www.w3.org/2000/svg' title='Clear all' aria-label='Clear all' width='16' height='16' viewBox='0 0 16 16' role='img'><path d='M12 4.7L11.3 4 8 7.3 4.7 4 4 4.7 7.3 8 4 11.3 4.7 12 8 8.7 11.3 12 12 11.3 8.7 8z'></path></svg>"));
                __builder.CloseElement();
            };

            RenderFragment menu_icon = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "button");
                __builder.AddAttribute(sequence++, "aria-haspopup", "true");
                __builder.AddAttribute(sequence++, "data-toggle", "true");
                __builder.AddAttribute(sequence++, "aria-label", Expanded ? "Open" : "Close");
                __builder.AddAttribute(sequence++, "title", Expanded ? "Open" : "Close");
                __builder.AddConfig(ref sequence, new BxComponentConfig(MenuIconConfig)
                    .AddClass($"bx--list-box__menu-icon")
                    .AddId($"{Id}-menu-icon")
                    .AddIfClass($"bx--list-box__menu-icon--open", () => Expanded));
                __builder.AddAttribute(sequence++, "type", "button");
                __builder.AddEvent(ref sequence, "onclick", HandleOnClickMenuIconAsync, true, true);
                if (!Expanded)
                {
                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' style='will-change: transform;' xmlns='http://www.w3.org/2000/svg' aria-label='Open menu' width='16' height='16' viewBox='0 0 16 16' role='img'><path d='M8 11L3 6 3.7 5.3 8 9.6 12.3 5.3 13 6z'></path></svg>"));
                }
                else
                {
                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' style='will-change: transform;' xmlns='http://www.w3.org/2000/svg' aria-label='Close menu' width='16' height='16' viewBox='0 0 16 16' role='img'><path d='M8 11L3 6 3.7 5.3 8 9.6 12.3 5.3 13 6z'></path></svg>"));
                }
                __builder.CloseElement();
            };

            RenderFragment comboBox = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ComboBoxConfig)
                    .AddClass($"bx--combo-box bx--list-box")
                    .AddIfClass($"bx--list-box--light", () => Light)
                    .AddIfClass($"bx--list-box--invalid", () => Invalid)
                    .AddIfClass($"bx--list-box--expanded", () => Expanded)
                    .AddIfClass($"bx--list-box--disabled", () => Disabled)
                    .AddIfClass($"bx--list-box--up", () => Direction?.Value == BxComboBoxDirection.Top)
                    .AddId($"{Id}-combo-box"));
                __builder.IfAddAttribute(ref sequence, "data-invalid", Invalid, () => Invalid);
                {
                    // box__field
                    __builder.OpenElement(sequence++, "div");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(ListBoxConfig)
                        .AddClass($"bx--list-box__field")
                        .AddId($"{Id}-list-box__field"));
                    __builder.AddAttribute(sequence++, "aria-expanded", Expanded);
                    __builder.AddAttribute(sequence++, "aria-label", Expanded ? "close menu" : "open menu");
                    __builder.AddAttribute(sequence++, "aria-haspopup", "listbox");
                    {
                        __builder.OpenElement(sequence++, "input");
                        __builder.AddConfig(ref sequence, new BxComponentConfig(InputConfig)
                            .AddClass($"bx--text-input")
                            .AddIfClass($"bx--text-input--empty", () => string.IsNullOrEmpty(Value))
                            .AddId($"{Id}-input"));
                        __builder.AddAttribute(sequence++, "aria-expanded", Expanded);
                        __builder.AddAttribute(sequence++, "autocomplete", "off");
                        __builder.AddAttribute(sequence++, "aria-autocomplete", "list");
                        __builder.AddAttribute(sequence++, "aria-haspopup", "listbox");
                        __builder.AddAttribute(sequence++, "aria-owns", $"{Id}-box__menu");
                        __builder.AddAttribute(sequence++, "role", "combobox");
                        __builder.AddAttribute(sequence++, "type", "text");
                        __builder.AddAttribute(sequence++, "value", Value);
                        __builder.IfAddAttribute(ref sequence, "readonly", true, () => ReadOnly);
                        __builder.IfAddAttribute(ref sequence, "placeholder", Placeholder, () => !string.IsNullOrWhiteSpace(Placeholder));
                        __builder.IfAddAttribute(ref sequence, "disabled", () => Disabled);
                        __builder.AddEvent(ref sequence, "onfocus", HandleOnFocusAsync, true, true);
                        __builder.AddEvent(ref sequence, "oninput", HandleOnInputAsync, true, true);
                        __builder.AddEvent(ref sequence, "onkeyup", HandleOnKeyupAsync, true, true);
                        //__builder.AddEvent(ref sequence, "onblur", HandleOnBlurAsync, true, true);
                        //__builder.AddEvent(ref sequence, "onchange", HandleOnChangeAsync);

                        __builder.CloseElement();

                        if (Invalid)
                        {
                            __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true' class='bx--list-box__invalid-icon'><path d='M8,1C4.2,1,1,4.2,1,8s3.2,7,7,7s7-3.1,7-7S11.9,1,8,1z M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2 c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z'></path><path d='M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8 c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z' data-icon-path='inner-path' opacity='0'></path></svg>"));
                        }
                        else if (Warn)
                        {
                            __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='bx--list-box__invalid-icon bx--list-box__invalid-icon--warning'><path fill='none' d='M16,26a1.5,1.5,0,1,1,1.5-1.5A1.5,1.5,0,0,1,16,26Zm-1.125-5h2.25V12h-2.25Z' data-icon-path='inner-path'></path><path d='M16.002,6.1714h-.004L4.6487,27.9966,4.6506,28H27.3494l.0019-.0034ZM14.875,12h2.25v9h-2.25ZM16,26a1.5,1.5,0,1,1,1.5-1.5A1.5,1.5,0,0,1,16,26Z'></path><path d='M29,30H3a1,1,0,0,1-.8872-1.4614l13-25a1,1,0,0,1,1.7744,0l13,25A1,1,0,0,1,29,30ZM4.6507,28H27.3493l.002-.0033L16.002,6.1714h-.004L4.6487,27.9967Z'></path></svg>"));
                        }

                        __builder.AddContent(sequence++, box__selection);
                        __builder.AddContent(sequence++, menu_icon);

                    }
                    __builder.CloseElement();

                    // options 

                    if (Expanded)
                    {
                        __builder.OpenElement(sequence++, "ul");
                        __builder.AddAttribute(sequence++, "role", "listbox");
                        __builder.AddConfig(ref sequence, new BxComponentConfig(BoxMenuConfig)
                            .AddClass($"bx--list-box__menu")
                            .AddId($"{Id}-box__menu"));

                        __builder.AddContent(sequence++, ChildContent);

                        __builder.CloseElement();
                    }
                }
                __builder.CloseElement();
            };

            RenderFragment input__wrapper = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(InputWrapperConfig).AddClass($"bx--list-box__wrapper").AddId($"{Id}-input__wrapper").AddStyle("width", "100%"));
                __builder.IfAddAttribute(ref sequence, "data-invalid", Invalid, () => Invalid);
                {
                    __builder.AddContent(sequence++, LabelFragment());
                    __builder.AddContent(sequence++, comboBox);
                    __builder.AddContent(sequence++, HelperFragment());
                    __builder.AddContent(sequence++, RequirementFragment());
                }
                __builder.CloseElement();
            };

            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            __builder.AddContent(sequence++, input__wrapper);

            __builder.CloseComponent();
        };

        /// <summary>
        /// 输入
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnInputAsync(ChangeEventArgs args)
        {
            var value = args.Value != null ? args.Value.ToString() : string.Empty;
            var keys = Options.Keys;
            if (keys != null)
            {
                var key = keys.FirstOrDefault(key => key.Contains(value));
                if (key != null && Options.TryGetValue(key, out var option))
                {
                    var oldKey = FocusOption == null ? default : FocusOption.Key;
                    FocusOption = option;
                    NotifyOptionStateHasChanged(new[] { oldKey, option.Key });
                }
            }
            if (BindConverter.TryConvertTo(value, CultureInfo.CurrentCulture, out string? parsedValue))
            {
                Value = parsedValue;
            }
            await Task.CompletedTask;
        }

        /// <summary>
        /// 选中项目
        /// </summary>
        /// <param name="option"></param>
        /// <param name="isClick"></param>
        /// <returns></returns>
        public override async Task SelectedOptionAsync(BxComboBoxOption option, bool isClick = false)
        {
            if (option != null)
            {
                Value = option.Key;
            }
            await base.SelectedOptionAsync(option, isClick);

            if (SelectedOption == option)
            {
                await HideAsync();
            }
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
    }
}
