using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 复选框
    /// Checkbox
    /// </summary>
    public partial class BxCheckbox : BxLabelInuptComponentBase<bool>
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
                __builder.AddAttribute(sequence++, "value", Value);
                __builder.AddAttribute(sequence++, "type", "checkbox");
                __builder.IfAddAttribute(ref sequence, "disabled", () => Disabled);
                __builder.AddEvent(ref sequence, "onchange", HandleOnChangeAsync);
                __builder.CloseElement();

                // label
                __builder.OpenElement(sequence++, "label");
                __builder.AddConfig(ref sequence, new BxComponentConfig(LabelTextConfig, "bx--checkbox-label", $"{Id}-label"));
                __builder.AddAttribute(sequence++, "for", $"{Id}-input");
                //__builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
                {
                    __builder.OpenElement(sequence++, "span");
                    __builder.AddConfig(ref sequence, new BxComponentConfig("bx--checkbox-label-text", $"{Id}-label-text"));
                    __builder.IfAddContent(ref sequence, LabelText, () => !string.IsNullOrEmpty(LabelText));
                    __builder.CloseElement();
                }
                __builder.CloseElement();
            });
        };

        /// <summary>
        /// 处理 OnChange
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task HandleOnChangeAsync(ChangeEventArgs args)
        {
            if (args.Value is bool @checked)
            {
                await SetCheckedAsync(@checked);
            }
        }

        /// <summary>
        /// 处理 OnChange
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task HandleOnClickAsync(MouseEventArgs args)
        {
            await SetCheckedAsync(!Value);
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="checked"></param>
        /// <returns></returns>
        protected async Task SetCheckedAsync(bool @checked)
        {
            if (@checked == Value)
                return;
            Value = @checked;
        }
    }
}
