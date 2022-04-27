using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// form-item 组件基础
    /// </summary>
    public abstract partial class BxFormItemComponentBase<TValue> : BxInuptComponentBase<TValue> 
    {
        /// <summary>
        /// 标签渲染
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment LabelFragment() => __builder =>
        {
            if (LabelTemplate == null && string.IsNullOrEmpty(LabelText))
                return;

            var sequence = 0;

            __builder.OpenElement(sequence++, "label");
            __builder.AddConfig(ref sequence, new BxComponentConfig(LabelConfig).AddClass($"bx--label").AddId($"{Id}-label"));
            __builder.AddAttribute(sequence++, "for", $"{Id}-input");
            __builder.EitherOrAddContent(ref sequence, LabelTemplate, HideLabel ? string.Empty : LabelText, () => LabelTemplate != null);
            __builder.CloseElement();
        };

        /// <summary>
        /// 标签渲染
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment HelperFragment() => __builder =>
        {
            if ((HelperTemplate == null && string.IsNullOrEmpty(HelperText)) || Invalid || Warn)
                return;

            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddConfig(ref sequence, new BxComponentConfig(HelperConfig).AddClass($"bx--form__helper-text").AddId($"{Id}-helper"));
            __builder.EitherOrAddContent(ref sequence, HelperTemplate, HelperText, () => HelperTemplate != null);
            __builder.CloseElement();
        };

        /// <summary>
        /// 标签渲染
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment RequirementFragment() => __builder =>
        {
            if (!Invalid && !Warn)
                return;

            if ((InvalidTemplate == null && string.IsNullOrEmpty(InvalidText)) && (WarnTemplate == null && string.IsNullOrEmpty(WarnText)))
                return;

            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddConfig(ref sequence, new BxComponentConfig(RequirementConfig).AddClass($"bx--form-requirement").AddId($"{Id}-requirement"));

            if (Invalid)
            {
                __builder.EitherOrAddContent(ref sequence, InvalidTemplate, InvalidText, () => InvalidTemplate != null);
            }
            else
            {
                __builder.EitherOrAddContent(ref sequence, WarnTemplate, WarnText, () => WarnTemplate != null);
            }

            __builder.CloseElement();
        };
    }
}
