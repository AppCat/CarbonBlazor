using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
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
    {
        private static readonly string _stepAttributeValue = GetStepAttributeValue();

        private static string GetStepAttributeValue()
        {
            // Unwrap Nullable<T>, because InputBase already deals with the Nullable aspect
            // of it for us. We will only get asked to parse the T for nonempty inputs.
            var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
            if (targetType == typeof(int) ||
                targetType == typeof(long) ||
                targetType == typeof(short) ||
                targetType == typeof(float) ||
                targetType == typeof(double) ||
                targetType == typeof(decimal))
            {
                return "any";
            }
            else
            {
                throw new InvalidOperationException($"The type '{targetType}' is not a supported numeric type.");
            }
        }

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
                    if(Step != null)
                    {
                        __builder.OpenElement(sequence++, "button");
                        __builder.AddConfig(ref sequence, new BxComponentConfig(ControlBtnConfig).AddClass($"bx--number__control-btn down-icon").AddId($"{Id}-number-controls-btn"));
                        __builder.AddAttribute(sequence++, "tabindex", "-1");
                        __builder.AddAttribute(sequence++, "type", "button");
                        __builder.IfAddAttribute(ref sequence, "title", DecrementTitle, () => !string.IsNullOrEmpty(DecrementTitle));
                        __builder.IfAddAttribute(ref sequence, "aria-label", DecrementTitle, () => !string.IsNullOrEmpty(DecrementTitle));
                        __builder.AddEvent<MouseEventArgs>(ref sequence, "onclick", this, args => SubtractAsync());
                        __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='down-icon'><path d='M8 15H24V17H8z'></path></svg>"));
                        __builder.CloseElement();

                        __builder.AddContent(sequence++, new MarkupString("<div class='bx--number__rule-divider'></div>"));

                        __builder.OpenElement(sequence++, "button");
                        __builder.AddConfig(ref sequence, new BxComponentConfig(ControlBtnConfig).AddClass($"bx--number__control-btn up-icon").AddId($"{Id}-number-controls-btn"));
                        __builder.AddAttribute(sequence++, "tabindex", "-1");
                        __builder.AddAttribute(sequence++, "type", "button");
                        __builder.IfAddAttribute(ref sequence, "title", IncrementTitle, () => !string.IsNullOrEmpty(IncrementTitle));
                        __builder.IfAddAttribute(ref sequence, "aria-label", IncrementTitle, () => !string.IsNullOrEmpty(IncrementTitle));
                        __builder.AddEvent<MouseEventArgs>(ref sequence, "onclick", this, args => AddAsync());
                        __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='up-icon'><path d='M17 15L17 8 15 8 15 15 8 15 8 17 15 17 15 24 17 24 17 17 24 17 24 15z'></path></svg>"));
                        __builder.CloseElement();

                        __builder.AddContent(sequence++, new MarkupString("<div class='bx--number__rule-divider'></div>"));
                    }
                }
                __builder.CloseElement();
            };

            RenderFragment input = __builder =>
           {
               var sequence = 0;

               __builder.OpenElement(sequence++, "input");
               __builder.AddConfig(ref sequence, new BxComponentConfig(InputConfig)
                   .AddClass($"bx--text-input").AddId($"{Id}-input")
                   .AddIfClass(() => $"bx--text-input--{Size}", () => Size != null))
               ;

               __builder.AddAttribute(sequence++, "type", "number");
               __builder.AddAttribute(sequence++, "pattern", "[0-9]*");
               __builder.IfAddAttribute(ref sequence, "readonly", true, () => ReadOnly);
               __builder.AddAttribute(sequence++, "value", Value);
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


               //__builder.AddAttribute(sequence++, "value", BindConverter.FormatValue(CurrentValueAsString));
               //__builder.AddAttribute(sequence++, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
               //__builder.AddAttribute(1, "step", _stepAttributeValue);

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

        /// <summary>
        /// 变化
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override async Task HandleOnChangeAsync(ChangeEventArgs args)
        {
            var value = args.Value != null ? args.Value.ToString() : string.Empty;

            if (BindConverter.TryConvertTo(value, CultureInfo.CurrentCulture, out TValue parsedValue))
            {
                if (Value.Equals(parsedValue))
                    return;
                Value = parsedValue;
                if (OnValueChange.HasDelegate)
                {
                    await OnValueChange.InvokeAsync(Value);
                }
            }
        }

        /// <summary>
        /// 加
        /// </summary>
        protected virtual async Task AddAsync()
        {
            if(Step != null 
                && decimal.TryParse(Step.ToString(), out decimal step) 
                && decimal.TryParse(string.IsNullOrEmpty(Value.ToString()) ? "0" : Value.ToString(), out decimal value)
                && decimal.TryParse(Max == null ? $"{decimal.MaxValue}" : Max.ToString(), out decimal max))
            {
                value += step;
                if (value > max)
                {
                    value = max;
                }
                await HandleOnChangeAsync(new ChangeEventArgs
                {
                    Value = value,
                });
            }
        }

        /// <summary>
        /// 减
        /// </summary>
        protected virtual async Task SubtractAsync()
        {
            if (Step != null
                && decimal.TryParse(Step.ToString(), out decimal step)
                && decimal.TryParse(string.IsNullOrEmpty(Value.ToString()) ? "0" : Value.ToString(), out decimal value)
                && decimal.TryParse(Min == null ? $"{decimal.MinValue}" : Min.ToString(), out decimal min))
            {
                value -= step;
                if(value < min)
                {
                    value = min;
                }
                await HandleOnChangeAsync(new ChangeEventArgs
                {
                    Value = value,
                });
            }
        }

        private readonly EventHandler<ValidationStateChangedEventArgs> _validationStateChangedHandler;
        private bool _hasInitializedParameters;
        private bool _previousParsingAttemptFailed;
        private ValidationMessageStore? _parsingValidationMessages;
        private Type? _nullableUnderlyingType;

        public TValue CurrentValue { get; set; }

        /// <summary>
        /// Gets or sets the current value of the input, represented as a string.
        /// </summary>
        protected string? CurrentValueAsString
        {
            get => FormatValueAsString(CurrentValue);
            set
            {
                _parsingValidationMessages?.Clear();

                bool parsingFailed;

                if (_nullableUnderlyingType != null && string.IsNullOrEmpty(value))
                {
                    // Assume if it's a nullable type, null/empty inputs should correspond to default(T)
                    // Then all subclasses get nullable support almost automatically (they just have to
                    // not reject Nullable<T> based on the type itself).
                    parsingFailed = false;
                    CurrentValue = default!;
                }
                else if (TryParseValueFromString(value, out var parsedValue, out var validationErrorMessage))
                {
                    parsingFailed = false;
                    CurrentValue = parsedValue!;
                }
                else
                {
                    parsingFailed = true;

                    // EditContext may be null if the input is not a child component of EditForm.
                    if (EditContext is not null)
                    {
                        _parsingValidationMessages ??= new ValidationMessageStore(EditContext);
                        _parsingValidationMessages.Add(FieldIdentifier, validationErrorMessage);

                        // Since we're not writing to CurrentValue, we'll need to notify about modification from here
                        EditContext.NotifyFieldChanged(FieldIdentifier);
                    }
                }

                // We can skip the validation notification if we were previously valid and still are
                if (parsingFailed || _previousParsingAttemptFailed)
                {
                    EditContext?.NotifyValidationStateChanged();
                    _previousParsingAttemptFailed = parsingFailed;
                }
            }
        }

        /// <summary>
        /// Gets or sets the error message used when displaying an a parsing error.
        /// </summary>
        [Parameter] public string ParsingErrorMessage { get; set; } = "The {0} field must be a number.";

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            if (BindConverter.TryConvertTo<TValue>(value, CultureInfo.InvariantCulture, out result))
            {
                validationErrorMessage = null;
                return true;
            }
            else
            {
                validationErrorMessage = string.Format(CultureInfo.InvariantCulture, ParsingErrorMessage, FieldIdentifier.FieldName);
                return false;
            }
        }

        /// <summary>
        /// Formats the value as a string. Derived classes can override this to determine the formatting used for <c>CurrentValueAsString</c>.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>A string representation of the value.</returns>
        protected string? FormatValueAsString(TValue? value)
        {
            // Avoiding a cast to IFormattable to avoid boxing.
            switch (value)
            {
                case null:
                    return null;

                case int @int:
                    return BindConverter.FormatValue(@int, CultureInfo.InvariantCulture);

                case long @long:
                    return BindConverter.FormatValue(@long, CultureInfo.InvariantCulture);

                case short @short:
                    return BindConverter.FormatValue(@short, CultureInfo.InvariantCulture);

                case float @float:
                    return BindConverter.FormatValue(@float, CultureInfo.InvariantCulture);

                case double @double:
                    return BindConverter.FormatValue(@double, CultureInfo.InvariantCulture);

                case decimal @decimal:
                    return BindConverter.FormatValue(@decimal, CultureInfo.InvariantCulture);

                default:
                    throw new InvalidOperationException($"Unsupported type {value.GetType()}");
            }
        }

        #region SDLC



        #endregion
    }
}
