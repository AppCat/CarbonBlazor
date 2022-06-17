using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class BxInputText : BxInputComponentBaseOf<string?>
    {
        /// <summary>
        /// Gets or sets the associated <see cref="ElementReference"/>.
        /// <para>
        /// May be <see langword="null"/> if accessed before the component is rendered.
        /// </para>
        /// </summary>
        [DisallowNull] public ElementReference? Element { get; protected set; }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "input");
            //__builder.AddAttribute(sequence++, "value", BindConverter.FormatValue(CurrentValue));
            __builder.AddAttribute(sequence++, "value", CurrentValueAsString);
            __builder.AddAttribute(sequence++, "onchange", EventCallback.Factory.CreateBinder<string?>(this, async __value => await SetStringValueAsync(__value), CurrentValueAsString));
            __builder.AddElementReferenceCapture(sequence++, __inputReference => Element = __inputReference);
            __builder.CloseElement();
        };

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string? value, out string? result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
