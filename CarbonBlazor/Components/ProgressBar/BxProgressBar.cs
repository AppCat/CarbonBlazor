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
    /// 这是一个用于 ProgressBar 的 Blazor 组件。  
    /// This is a Blazor component for the ProgressBar.
    /// </summary>
    public partial class BxProgressBar : BxComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--progress-bar";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .AddEnum(Size)
                .AddEnum(Type)
                .If("bx--progress-bar--indeterminate", () => Indeterminate)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var labelId = $"{Id}-bar__label";
            var helperId = $"{Id}-bar__helper-text";

            RenderFragment label = __builder =>
            {
                if (string.IsNullOrEmpty(Label) && LabelTemplate == null)
                    return;

                var sequence = 0;
                __builder.OpenElement(sequence++, "span");
                __builder.AddConfig(ref sequence, new BxComponentConfig(LabelConfig, "bx--progress-bar__label", labelId));

                if (LabelTemplate != null)
                {
                    __builder.AddContent(sequence++, LabelTemplate, Value);
                }
                else
                {
                    __builder.AddContent(sequence++, Label);
                }

                __builder.CloseElement();
            };

            RenderFragment track = __builder =>
            {
                var sequence = 0;
                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(LabelConfig, "bx--progress-bar__track", $"{Id}-bar__track"));
                __builder.AddAttribute(sequence++, "role", "progressbar");
                __builder.AddAria(ref sequence, "labelledby", labelId);
                __builder.AddAria(ref sequence, "describedby", helperId);
                __builder.AddAria(ref sequence, "valuemin", 0);
                __builder.AddAria(ref sequence, "valuemax", Max);
                __builder.AddAria(ref sequence, "valuenow", Value);

                if (!Indeterminate)
                {
                    __builder.OpenElement(sequence++, "div");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(LabelConfig, "bx--progress-bar__bar", $"{Id}-bar__bar")
                        .AddStyle("transform", () => $"scaleX({(double)Value / (double)Max})"));
                }

                __builder.CloseElement();

                __builder.CloseElement();
            };

            RenderFragment helper = __builder =>
            {
                if (string.IsNullOrEmpty(HelperText) && HelperTextTemplate == null)
                    return;

                var sequence = 0;
                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(LabelConfig, "bx--progress-bar__helper-text", helperId));

                if (LabelTemplate != null)
                {
                    __builder.AddContent(sequence++, HelperTextTemplate, Value);
                }
                else
                {
                    __builder.AddContent(sequence++, HelperText);
                }

                __builder.CloseElement();
            };

            var sequence = 0;
            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            __builder.AddContent(sequence++, label);
            __builder.AddContent(sequence++, track);
            __builder.AddContent(sequence++, helper);

            __builder.CloseComponent();
        };


    }
}
