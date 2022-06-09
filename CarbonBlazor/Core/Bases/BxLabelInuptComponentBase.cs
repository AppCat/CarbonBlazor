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
    /// 标签输入组件基础
    /// </summary>
    public abstract partial class BxLabelInuptComponentBase<TValue> : BxInuptComponentBase<TValue>
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
            __builder.AddConfig(ref sequence, new BxComponentConfig(LabelTextConfig, $"bx--label", $"{Id}-label"));
            __builder.AddAttribute(sequence++, "for", $"{Id}-input");
            __builder.EitherOrAddContent(ref sequence, LabelTemplate, HideLabel ? string.Empty : LabelText, () => LabelTemplate != null);
            __builder.CloseElement();
        };
    }
}
