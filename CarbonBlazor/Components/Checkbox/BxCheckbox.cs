using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
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
    public partial class BxCheckbox : BxInuptComponentBase<bool>
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = "bx--form-item bx--checkbox-wrapper";
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

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            // input
            __builder.OpenElement(sequence++, "input");
            __builder.AddConfig(ref sequence, new BxComponentConfig(InputConfig)
                .AddId($"{Id}-input")
                .AddClass("bx--checkbox"));
            __builder.IfAddAttribute(ref sequence, "readonly", true, () => ReadOnly);
            __builder.AddAttribute(sequence++, "value", Checked);
            __builder.AddAttribute(sequence++, "type", "checkbox");
            __builder.AddEvent(ref sequence, "onchange", HandleOnChangeAsync);
            __builder.CloseElement();

            // label
            __builder.OpenElement(sequence++, "label");
            __builder.AddConfig(ref sequence, new BxComponentConfig(LableConfig)
                .AddId($"{Id}-label")
                .AddClass("bx--checkbox-label"));
            __builder.AddAttribute(sequence++, "for", $"{Id}-input");
            __builder.IfAddContent(ref sequence, Label, () => !string.IsNullOrEmpty(Label));
            __builder.CloseElement();

            __builder.CloseComponent();
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
                if (@checked == Checked)
                    return;
                Checked = @checked;
                Value = @checked;
                if (CheckedChanged.HasDelegate)
                {
                    await CheckedChanged.InvokeAsync(Value);
                }
                if (OnCheckedChange.HasDelegate)
                {
                    await OnCheckedChange.InvokeAsync(Value);
                }
            }
        }
    }
}
