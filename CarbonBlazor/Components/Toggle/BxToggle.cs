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
    /// 这是一个用于 Toggle 的 Blazor 组件。  
    /// This is a Blazor component for the Toggle.
    /// </summary>
    public partial class BxToggle : BxLabelInuptComponentBase<bool>
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--toggle";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--toggle--disabled", () => Disabled)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var buttonId = $"{Id}-button";

            RenderFragment button = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "button");
                __builder.AddAttribute(sequence++, "role", "switch");
                __builder.AddAttribute(sequence++, "type", "button");
                __builder.AddAria(ref sequence, "checked", Toggled);
                __builder.IfAddAttribute(ref sequence, "disabled", () => Disabled);
                __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync, OnClickStopPropagation);
                __builder.AddConfig(ref sequence, new BxComponentConfig(ButtonConfig, "bx--toggle__button", buttonId));
                __builder.CloseElement();
            };

            RenderFragment labelText = __builder =>
            {
                var sequence = 0;
                __builder.OpenElement(sequence++, "span");
                __builder.AddConfig(ref sequence, new BxComponentConfig(LabelTextConfig, "bx--toggle__label-text", $"{Id}-label-text"));
                __builder.EitherOrAddContent(ref sequence, LabelTemplate, HideLabel ? string.Empty : LabelText, () => LabelTemplate != null);
                __builder.CloseElement();
            };

            RenderFragment @switch = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(LabelTextConfig, "bx--toggle__switch", $"{Id}-switch").AddIfClass("bx--toggle__switch--checked", () => Toggled));
                __builder.CloseElement();
            };

            RenderFragment text = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "span");
                __builder.AddAria(ref sequence, "hidden", true);
                __builder.AddConfig(ref sequence, new BxComponentConfig(LabelTextConfig, "bx--toggle__text", $"{Id}-text"));
                __builder.EitherOrAddContent(ref sequence, LabelB, LabelA, () => Toggled);
                __builder.CloseElement();
            };

            RenderFragment appearance = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(AppearanceConfig, "bx--toggle__appearance", $"{Id}-appearance"));
                __builder.AddContent(sequence++, @switch);
                __builder.AddContent(sequence++, text);
                __builder.CloseElement();
            };

            RenderFragment label = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "label");
                __builder.AddAttribute(sequence++, "for", buttonId);
                __builder.AddConfig(ref sequence, new BxComponentConfig(LabelConfig, "bx--toggle__label", $"{Id}-title"));
                __builder.AddContent(sequence++, labelText);
                __builder.AddContent(sequence++, appearance);
                __builder.CloseElement();
            };

            var sequence = 0;

            __builder.UseElement(ref sequence, "div", this, __builder =>
            {
                __builder.AddContent(sequence++, button);
                __builder.AddContent(sequence++, label);
            }, null);
        };

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickAsync(MouseEventArgs args)
        {
            await Click(args);
        }

        /// <summary>
        /// 点击
        /// </summary>
        /// <returns></returns>
        protected virtual async Task Click(MouseEventArgs args)
        {
            if (Loading || Disabled)
                return;
            Loading = true;
            await LoadingChanged.InvokeAsync(Loading);
            await OnClick.InvokeAsync(args);
            Toggled = !Toggled;
            Value = Toggled;
            if (ToggledChanged.HasDelegate)
            {
                await ToggledChanged.InvokeAsync(Value);
            }
            if (OnToggledChange.HasDelegate)
            {
                await OnToggledChange.InvokeAsync(Value);
            }
            Loading = false;
            await LoadingChanged.InvokeAsync(Loading);
        }
    }
}
