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
    /// 这是一个用于 LongPressButton 的 Blazor 组件。  
    /// This is a Blazor component for the LongPressButton.
    /// </summary>
    public partial class BxLongPressButton : BxButton
    {
        /// <summary>
        /// 目标时间
        /// </summary>
        protected DateTime Terminus { get; set; }

        /// <summary>
        /// 计时Task
        /// </summary>
        protected Task? TimeTask { get; set; }

        /// <summary>
        /// 计时Task 取消源
        /// </summary>
        protected CancellationTokenSource? TokenSource { get; set; }

        /// <summary>
        /// 是否上台
        /// </summary>
        protected bool IsMouseup { get; set; } = false;

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
            }
            else
            {
                __builder.OpenElement(sequence++, "button");
            }

            if (!Skeleton)
            {
                __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync, OnClickStopPropagation);
                __builder.AddEvent(ref sequence, "onmouseout", HandleOnMouseoutAsync, true, true);
                __builder.AddEvent(ref sequence, "onmousedown", HandleOnMousedownAsync, OnMousedownStopPropagation, true);
                __builder.AddEvent(ref sequence, "onmouseup", HandleOnMouseupAsync, OnMouseupStopPropagation, true);
            }

            __builder.AddComponent(ref sequence, this);
            __builder.AddAttribute(sequence++, "type", Type?.ToString() ?? "button");
            __builder.IfAddAttribute(ref sequence, "disabled", () => Loading);
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
            else
            {
                __builder.AddContent(sequence++, Progress());
            }

            //__builder.EitherOrAddContent(ref sequence, ChildContent, Content, () => ChildContent != null);

            __builder.CloseComponent();
        };

        /// <summary>
        /// 进度条
        /// </summary>
        /// <returns></returns>
        protected RenderFragment Progress() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "dvi");
            __builder.AddConfig(ref sequence, new BxComponentConfig("bx--progress-bar bx--progress-bar--small bx--progress-bar--default", $"{Id}-progress-bar")
                .AddStyle("width", "100%")
                .AddStyle("position", "absolute")
                .AddStyle("height", "3px")
                .AddStyle("bottom", "0")
                .AddStyle("left", "0"));
            {
                __builder.OpenElement(sequence++, "dvi");
                __builder.AddConfig(ref sequence, new BxComponentConfig("bx--progress-bar__track", $"{Id}-progress-bar-track").AddStyle("background-color", "transparent"));
                {
                    __builder.OpenElement(sequence++, "dvi");
                    __builder.AddConfig(ref sequence, new BxComponentConfig("bx--progress-bar__bar", $"{Id}-progress-bar-bar")
                        .AddStyle("transform", "scaleX(1)")
                        .AddIfStyle("transition", $"width {((double)Delay + (double)Delay / 30) / 1000}s", () => !IsMouseup)       
                        .AddIfStyle("background-color", "var(--cds-button-secondary,#393939)", () => Kind == null || Kind.Value != BxButtonKind.Secondary)
                        .AddStyle("width", "5%")
                        .AddIfStyle("WIDTH", $"100%", () => !IsMouseup && TokenSource != null));
                    __builder.CloseElement();
                }
                __builder.CloseElement();
            }
            __builder.CloseElement();
        };

        #region Handle

        /// <summary>
        /// 处理点击
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override Task HandleOnClickAsync(MouseEventArgs args)
        {
            if (!OnClickStop)
                return base.HandleOnClickAsync(args);
            else
                return Task.CompletedTask;
        }

        /// <summary>
        /// 处理鼠标按钮被按下。
        /// </summary>
        /// <param name="args"></param>
        private async Task HandleOnMousedownAsync(MouseEventArgs args)
        {
            await Run(args);
        }

        /// <summary>
        /// 处理鼠标按键被松开。
        /// </summary>
        /// <param name="args"></param>
        private async Task HandleOnMouseupAsync(MouseEventArgs args)
        {
            await Cancel();
        }

        /// <summary>
        /// 处理鼠标移走
        /// </summary>
        /// <param name="args"></param>
        protected async Task HandleOnMouseoutAsync(FocusEventArgs args)
        {
            await Cancel();
        }

        #endregion

        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="args"></param>
        protected virtual async Task Run(MouseEventArgs args)
        {
            if (Loading)
                return;
            IsMouseup = false;
            await InvokeStateHasChangedAsync();
            var delay = DelayTimeSpan ?? TimeSpan.FromMilliseconds(Delay);
            Terminus = DateTime.Now.Add(delay);
            TokenSource = new CancellationTokenSource(delay);
            var totalMilliseconds = delay.TotalMilliseconds;
            TimeTask?.Dispose();
            TimeTask = Task.Run(async () =>
            {
                while (DateTime.Now < Terminus && !TokenSource.IsCancellationRequested)
                {
                    await Task.Delay(1);
                }
                if (!IsMouseup)
                {
                    await InvokeStateHasChangedAsync();
                    await Click(args);
                    await Cancel();
                }
            }, TokenSource.Token);
            await Task.CompletedTask;
        }

        /// <summary>
        /// 取消
        /// </summary>
        protected virtual async Task Cancel()
        {
            if (Loading)
                return;
            IsMouseup = true;
            TokenSource?.Cancel();
            TokenSource = null;
            Terminus = DateTime.MinValue;
            await InvokeStateHasChangedAsync();
        }
    }
}
