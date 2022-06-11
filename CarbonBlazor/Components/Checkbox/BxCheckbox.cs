using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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
    /// 复选框
    /// Checkbox
    /// </summary>
    public partial class BxCheckbox : BxLabelInuptComponentBaseOf<bool>
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--form-item bx--checkbox-wrapper";
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
            var sequence = 0;

            __builder.UseElement(ref sequence, "div", this, __builder =>
            {
                var sequence = 0;

                // input
                __builder.OpenElement(sequence++, "input");
                __builder.AddConfig(ref sequence, new BxComponentConfig(InputConfig, "bx--checkbox", $"{Id}-input"));
                __builder.IfAddAttribute(ref sequence, "readonly", true, () => ReadOnly);
                //__builder.AddAttribute(sequence++, "checked", CurrentValue);
                __builder.AddAttribute(sequence++, "value", BindConverter.FormatValue(CurrentValue));
                __builder.AddAttribute(sequence++, "checked", BindConverter.FormatValue(CurrentValue));
                __builder.AddAttribute(sequence++, "onchange", EventCallback.Factory.CreateBinder<bool>(this, async __value => await SetValueAsync(__value), CurrentValue));
                __builder.AddAttribute(sequence++, "type", "checkbox");
                __builder.IfAddAttribute(ref sequence, "disabled", () => Disabled);

                // Old
                //__builder.AddAttribute(sequence++, "value", Value);
                //__builder.AddEvent(ref sequence, "onchange", HandleOnChangeAsync);

                __builder.CloseElement();

                // label
                __builder.OpenElement(sequence++, "label");
                __builder.AddConfig(ref sequence, new BxComponentConfig(LabelTextConfig, "bx--checkbox-label", $"{Id}-label"));
                __builder.AddAttribute(sequence++, "for", $"{Id}-input");
                //__builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
                {
                    __builder.OpenElement(sequence++, "span");
                    __builder.AddConfig(ref sequence, new BxComponentConfig("bx--checkbox-label-text", $"{Id}-label-text").AddIfClass("bx--visually-hidden", () => HideLabel));
                    __builder.IfAddContent(ref sequence, LabelText, () => !string.IsNullOrEmpty(LabelText));
                    __builder.CloseElement();
                }
                __builder.CloseElement();
            });
        };

        /// <summary>
        /// 尝试解析
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <param name="validationErrorMessage"></param>
        /// <returns></returns>
        protected override bool TryParseValueFromString(string? value, [NotNullWhen(false)] out bool result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            validationErrorMessage = null;
            result = false;
            if (bool.TryParse(value, out bool _bool))
            {
                result = _bool;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override async Task SetValueAsync(bool value)
        {
            await base.SetValueAsync(value);
            var hasChanged = !EqualityComparer<bool>.Default.Equals(CurrentValue, Checked);
            if (hasChanged)
            {
                Checked = CurrentValue;
                await CheckedChanged.InvokeAsync(Checked);
            }
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        protected override FieldIdentifier CreateFieldIdentifier()
        {
            if (CheckedExpression != null)
            {
                return FieldIdentifier.Create(CheckedExpression);
            }
            else
            {
                return base.CreateFieldIdentifier();
            }
        }

        /// <summary>
        /// 设置参数后
        /// </summary>
        protected override void OnParametersSet()
        {
            var hasChanged = !EqualityComparer<bool>.Default.Equals(Checked, CurrentValue);
            if (hasChanged)
            {
                CurrentValue = Checked;
            }
            if (ValueChanged.HasDelegate)
            {
                base.OnParametersSet();
            }
        }
    }
}
