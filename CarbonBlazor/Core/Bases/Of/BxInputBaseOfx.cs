using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class BxInputBaseOfx<TValue> : BxComponentBase
    {
        private bool _hasInitializedParameters;
        private bool _previousParsingAttemptFailed;
        private Type? _nullableUnderlyingType;
        private readonly EventHandler<ValidationStateChangedEventArgs> _validationStateChangedHandler;

        /// <summary>
        /// Constructs an instance of <see cref="InputBase{TValue}"/>.
        /// </summary>
        protected BxInputBaseOfx()
        {
            _validationStateChangedHandler = OnValidateStateChanged;
        }

        /// <summary>
        /// Gets the associated <see cref="Forms.EditContext"/>.
        /// This property is uninitialized if the input does not have a parent <see cref="EditForm"/>.
        /// </summary>
        protected EditContext EditContext { get; set; } = default!;

        /// <summary>
        /// Gets the <see cref="FieldIdentifier"/> for the bound value.
        /// </summary>
        protected internal FieldIdentifier FieldIdentifier { get; set; }

        /// <summary>
        /// 第一次值
        /// </summary>
        protected TValue? FirstValue { get; set; }

        /// <summary>
        /// 当前值
        /// </summary>
        protected TValue? CurrentValue { get; set; }

        #region CascadingParameter

        /// <summary>
        /// 联级 EditContext
        /// </summary>
        [CascadingParameter]
        private EditContext? CascadedEditContext { get; set; }

        #endregion

        /// <summary>
        /// 获取输入的当前值(以字符串形式表示)。
        /// Gets the current value of the input, represented as a string.
        /// </summary>
        protected string? CurrentValueAsString => FormatValueAsString(CurrentValue);

        /// <summary>
        /// Formats the value as a string. Derived classes can override this to determine the formating used for <see cref="CurrentValueAsString"/>.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>A string representation of the value.</returns>
        protected virtual string? FormatValueAsString(TValue? value) => value?.ToString();

        /// <summary>
        /// Parses a string to create an instance of <typeparamref name="TValue"/>. Derived classes can override this to change how
        /// <see cref="CurrentValueAsString"/> interprets incoming values.
        /// </summary>
        /// <param name="value">The string value to be parsed.</param>
        /// <param name="result">An instance of <typeparamref name="TValue"/>.</param>
        /// <param name="validationErrorMessage">If the value could not be parsed, provides a validation error message.</param>
        /// <returns>True if the value could be parsed; otherwise false.</returns>
        protected abstract bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage);

        /// <summary>
        /// 设置字符串内容
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual async Task SetStringValueAsync(string value)
        {
            bool parsingFailed;

            if (_nullableUnderlyingType != null && string.IsNullOrEmpty(value))
            {
                // Assume if it's a nullable type, null/empty inputs should correspond to default(T)
                // Then all subclasses get nullable support almost automatically (they just have to
                // not reject Nullable<T> based on the type itself).
                parsingFailed = false;
                await SetValueAsync(default);
            }
            else if (TryParseValueFromString(value, out var parsedValue, out var validationErrorMessage))
            {
                parsingFailed = false;
                await SetValueAsync(parsedValue!);
            }
            else
            {
                parsingFailed = true;

                // EditContext may be null if the input is not a child component of EditForm.
                if (EditContext is not null)
                {
                    //_parsingValidationMessages ??= new ValidationMessageStore(EditContext);
                    //_parsingValidationMessages.Add(FieldIdentifier, validationErrorMessage);

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

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private async Task SetValueAsync(TValue? value)
        {
            CurrentValue = value;
            var hasChanged = !EqualityComparer<TValue>.Default.Equals(CurrentValue, Value);
            if (hasChanged)
            {
                Value = CurrentValue;
                await ValueChanged.InvokeAsync(Value);
            }

        }

        /// <summary>
        /// 重置
        /// </summary>
        public async void Reset()
        {
            await SetValueAsync(FirstValue);
        }

        #region SDLC

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            if (!_hasInitializedParameters)
            {
                // This is the first run
                // Could put this logic in OnInit, but its nice to avoid forcing people who override OnInit to call base.OnInit()

                if (ValueExpression == null)
                {
                    throw new InvalidOperationException(
                        $"{GetType()} requires a value for the 'ValueExpression' " + 
                        $"parameter. Normally this is provided automatically when using 'bind-Value'.");
                }

                FieldIdentifier = FieldIdentifier.Create(ValueExpression);

                if (CascadedEditContext != null)
                {
                    EditContext = CascadedEditContext;
                    EditContext.OnValidationStateChanged += _validationStateChangedHandler;
                }

                _nullableUnderlyingType = Nullable.GetUnderlyingType(typeof(TValue));
                _hasInitializedParameters = true;
            }
            else if (CascadedEditContext != EditContext)
            {
                // Not the first run

                // We don't support changing EditContext because it's messy to be clearing up state and event
                // handlers for the previous one, and there's no strong use case. If a strong use case
                // emerges, we can consider changing this.
                throw new InvalidOperationException($"{GetType()} does not support changing the " +
                    $"{nameof(EditContext)} dynamically.");
            }

            return base.SetParametersAsync(ParameterView.Empty);
        }

        #endregion

        private void OnValidateStateChanged(object? sender, ValidationStateChangedEventArgs eventArgs)
        {
            StateHasChanged();
        }
    }
}
