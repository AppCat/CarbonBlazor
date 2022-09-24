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
    /// 这是一个用于 Button 的 Blazor 组件。  
    /// This is a Blazor component for the Button.
    /// </summary>
    public partial class BxButton : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--btn";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .AddEnum(Size, () => $"{fixedClass}--{Size}")
                .AddEnum(Kind, () => $"{fixedClass}--{Kind}")
                .If($"bx--btn--disabled", () => Disabled)
                .If($"bx--btn--icon-only", () => HasIconOnly)
                .If($"bx--btn--expressive", () => IsExpressive)
                .If($"bx--skeleton", () => Skeleton)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;
            if (!string.IsNullOrWhiteSpace(Href))
            {
                __builder.OpenElement(sequence++, "a");
                __builder.AddAttribute(sequence++, "href", Href);
            }
            else
            {
                __builder.OpenElement(sequence++, "button");
            }

            if (!Skeleton)
            {
                __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync, OnClickStopPropagation);
                __builder.AddEvent(ref sequence, "onmousedown", OnMouseDown);
                __builder.AddEvent(ref sequence, "onmouseup", OnMouseUp);
            }

            __builder.AddComponent(ref sequence, this);
            __builder.AddAttribute(sequence++, "type", Type?.ToString() ?? "button");
            __builder.IfAddAttribute(ref sequence, "disabled", () => Loading || Disabled);
            __builder.IfAddAttribute(ref sequence, "role", Role, () => !string.IsNullOrWhiteSpace(Role));

            if (ChildContent != null)
            {
                if (Loading)
                {
                    __builder.OpenElement(sequence++, "span");
                    __builder.AddAttribute(sequence++, "style", "opacity: 0;");
                    __builder.AddContent(sequence++, ChildContent);
                    __builder.CloseElement();
                }
                else
                {
                    __builder.AddContent(sequence++, ChildContent);
                }
            }
            else
            {
                if (Loading)
                {
                    __builder.AddContent(sequence++, new MarkupString($"<span style='opacity: 0;'>{Content}</span>"));
                }
                else
                {
                    __builder.AddContent(sequence++, Content);
                }
            }

            if (Loading)
            {
                __builder.AddContent(sequence++, new MarkupString("<div data-loading class='bx--loading bx--loading--small' style='position: absolute;'><svg class='bx--loading__svg' viewBox='-75 -75 150 150'><title>Loading</title><circle class='bx--loading__background' cx='0' cy='0' r='26.8125' /><circle class='bx--loading__stroke' cx='0' cy='0' r='26.8125' /></svg></div>"));
            }

            __builder.CloseComponent();
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
            Loading = false;
            await LoadingChanged.InvokeAsync(Loading);
        }
    }
}
