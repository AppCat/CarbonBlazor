using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 Notification 的 Blazor 组件基础。  
    /// This is a Blazor componentBase for the Notification.
    /// </summary>
    public abstract partial class BxNotificationBase : BxComponentBase
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        protected abstract string Type { get; }

        /// <summary>
        /// 当前延迟
        /// </summary>
        protected TimeSpan CurrentDelay { get; set; }

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
        /// 第一次渲染后
        /// </summary>
        protected bool FirstRenderAfter { get; set; }

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--{Type}-notification";
            ClassMapper
                .Clear()
                .GetIf(() => $"bx--{Type}-notification--{Kind}", () => Kind != null)
                .Add(fixedClass)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;
            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            __builder.AddContent(sequence++, IconFragment());
            __builder.AddContent(sequence++, DetailsFragment());
            __builder.AddContent(sequence++, CloseButtonFragment());

            __builder.CloseComponent();
        };

        /// <summary>
        /// 细节渲染
        /// </summary>
        /// <returns></returns>
        protected abstract RenderFragment DetailsFragment();

        /// <summary>
        /// 图标渲染
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment IconFragment() => __builder =>
        {
            var sequence = 0;
            switch (Kind?.Value)
            {
                case BxNotificationKind.Error:
                    __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true' class='bx--{Type}-notification__icon'><path d='M8,1C4.1,1,1,4.1,1,8s3.1,7,7,7s7-3.1,7-7S11.9,1,8,1z M10.7,11.5L4.5,5.3l0.8-0.8l6.2,6.2L10.7,11.5z'></path><path fill='none' d='M10.7,11.5L4.5,5.3l0.8-0.8l6.2,6.2L10.7,11.5z' data-icon-path='inner-path' opacity='0'></path><title>notification</title></svg>"));
                    break;
                case BxNotificationKind.Info:
                    __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='bx--{Type}-notification__icon'><path fill='none' d='M16,8a1.5,1.5,0,1,1-1.5,1.5A1.5,1.5,0,0,1,16,8Zm4,13.875H17.125v-8H13v2.25h1.875v5.75H12v2.25h8Z' data-icon-path='inner-path'></path><path d='M16,2A14,14,0,1,0,30,16,14,14,0,0,0,16,2Zm0,6a1.5,1.5,0,1,1-1.5,1.5A1.5,1.5,0,0,1,16,8Zm4,16.125H12v-2.25h2.875v-5.75H13v-2.25h4.125v8H20Z'></path><title>notification</title></svg>"));
                    break;
                case BxNotificationKind.InfoSquare:
                    __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='bx--{Type}-notification__icon'><path fill='none' d='M16,8a1.5,1.5,0,1,1-1.5,1.5A1.5,1.5,0,0,1,16,8Zm4,13.875H17.125v-8H13v2.25h1.875v5.75H12v2.25h8Z' data-icon-path='inner-path'></path><path d='M26,4H6A2,2,0,0,0,4,6V26a2,2,0,0,0,2,2H26a2,2,0,0,0,2-2V6A2,2,0,0,0,26,4ZM16,8a1.5,1.5,0,1,1-1.5,1.5A1.5,1.5,0,0,1,16,8Zm4,16.125H12v-2.25h2.875v-5.75H13v-2.25h4.125v8H20Z'></path><title>notification</title></svg>"));
                    break;
                case BxNotificationKind.Success:
                    __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true' class='bx--{Type}-notification__icon'><path d='M8,1C4.1,1,1,4.1,1,8c0,3.9,3.1,7,7,7s7-3.1,7-7C15,4.1,11.9,1,8,1z M7,11L4.3,8.3l0.9-0.8L7,9.3l4-3.9l0.9,0.8L7,11z'></path><path d='M7,11L4.3,8.3l0.9-0.8L7,9.3l4-3.9l0.9,0.8L7,11z' data-icon-path='inner-path' opacity='0'></path><title>notification</title></svg>"));
                    break;
                case BxNotificationKind.Warning:
                    __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true' class='bx--{Type}-notification__icon'><path d='M8,1C4.2,1,1,4.2,1,8s3.2,7,7,7s7-3.1,7-7S11.9,1,8,1z M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2 c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z'></path><path d='M7.5,4h1v5h-1C7.5,9,7.5,4,7.5,4z M8,12.2c-0.4,0-0.8-0.4-0.8-0.8s0.3-0.8,0.8-0.8 c0.4,0,0.8,0.4,0.8,0.8S8.4,12.2,8,12.2z' data-icon-path='inner-path' opacity='0'></path><title>notification</title></svg>"));
                    break;
                case BxNotificationKind.WarningAlt:
                    __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='bx--{Type}-notification__icon'><path fill='none' d='M16,26a1.5,1.5,0,1,1,1.5-1.5A1.5,1.5,0,0,1,16,26Zm-1.125-5h2.25V12h-2.25Z' data-icon-path='inner-path'></path><path d='M16.002,6.1714h-.004L4.6487,27.9966,4.6506,28H27.3494l.0019-.0034ZM14.875,12h2.25v9h-2.25ZM16,26a1.5,1.5,0,1,1,1.5-1.5A1.5,1.5,0,0,1,16,26Z'></path><path d='M29,30H3a1,1,0,0,1-.8872-1.4614l13-25a1,1,0,0,1,1.7744,0l13,25A1,1,0,0,1,29,30ZM4.6507,28H27.3493l.002-.0033L16.002,6.1714h-.004L4.6487,27.9967Z'></path><title>notification</title></svg>"));
                    break;
                default:
                    break;
            }
        };

        /// <summary>
        /// 关闭按钮渲染
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment CloseButtonFragment() => __builder =>
        {
            if (HideCloseButton)
                return;

            var sequence = 0;
            __builder.OpenElement(sequence++, "button");
            __builder.AddConfig(ref sequence, new BxComponentConfig(CloseButtonConfig, $"bx--{Type}-notification__close-button", $"{Id}-close-button"));
            __builder.AddAttribute(sequence++, "type", "button");
            __builder.AddAttribute(sequence++, "tabindex", "-1");
            __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);

            __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='bx--{Type}-notification__close-icon'><path d='M24 9.4L22.6 8 16 14.6 9.4 8 8 9.4 14.6 16 8 22.6 9.4 24 16 17.4 22.6 24 24 22.6 17.4 16 24 9.4z'></path></svg>"));

            __builder.CloseElement();
        };

        /// <summary>
        /// 标题渲染
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment TitleFragment() => __builder =>
        {
            var sequence = 0;
            __builder.OpenElement(sequence++, "div");
            __builder.AddConfig(ref sequence, new BxComponentConfig(TitleConfig, $"bx--{Type}-notification__title", $"{Id}-title"));
            __builder.AddContent(sequence++, Title);
            __builder.CloseElement();
        };

        /// <summary>
        /// 副标题渲染
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment SubtitleFragment() => __builder =>
        {
            var sequence = 0;
            __builder.OpenElement(sequence++, "div");
            __builder.AddConfig(ref sequence, new BxComponentConfig(SubtitleConfig, $"bx--{Type}-notification__subtitle", $"{Id}-subtitle"));
            __builder.AddContent(sequence++, Subtitle);
            __builder.CloseElement();
        };

        /// <summary>
        /// 进度条渲染
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment ProgressFragment() => __builder =>
        {
            if (!IsDelayClose)
                return;

            var delay = CurrentDelay.TotalMilliseconds;

            var sequence = 0;
            __builder.OpenElement(sequence++, "div");
            __builder.AddConfig(ref sequence, new BxComponentConfig(ProgressConfig, $"bx--{Type}-notification__progress", $"{Id}-progress")
                .AddStyle("position", "absolute")
                .AddStyle("background-color", "var(--bx-support-error-inverse,#fa4d56)")
                .AddStyle("transition", $"width {((double)delay + (double)delay / 30) / 1000}s")
                .AddStyle("height", "3px")
                .AddStyle("width", "1%")
                //.AddIfStyle("WIDTH", "100%", () => FirstRenderAfter)
                .AddStyle("top", "0px"));
            __builder.CloseElement();
        };

        /// <summary>
        /// 运行
        /// </summary>
        protected virtual async Task Run()
        {
            if (!IsDelayClose)
                return;

            await InvokeStateHasChangedAsync();
            Terminus = DateTime.Now.Add(CurrentDelay);
            TokenSource = new CancellationTokenSource(CurrentDelay);
            var totalMilliseconds = CurrentDelay.TotalMilliseconds;
            TimeTask = Task.Run(async () =>
            {
                while (DateTime.Now < Terminus && !TokenSource.IsCancellationRequested)
                {
                    await Task.Delay(1);
                }

                if (!TokenSource.IsCancellationRequested)
                {
                    await InvokeStateHasChangedAsync();
                    await OnClose.InvokeAsync();
                    await Cancel();
                }
            }, TokenSource.Token);
            await Task.CompletedTask;
        }

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickAsync(MouseEventArgs args)
        {
            await OnClose.InvokeAsync();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            CurrentDelay = DelayTimeSpan ?? TimeSpan.FromMilliseconds(Delay);
            await Run();
        }

        /// <summary>
        /// 渲染完成
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if(firstRender && IsDelayClose)
            {
                FirstRenderAfter = true;
                StateHasChanged();
                var delay = CurrentDelay.TotalMilliseconds;
                await Task.Run(async () =>
                {
                    await Task.Delay(10);
                    await JSRuntime!.SetStyleByIdAsync($"{Id}-progress", "width", "100%");
                });
            }
        }

        /// <summary>
        /// 呈现渲染
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldRender()
        {
            var render = base.ShouldRender();

            return render;
        }

        /// <summary>
        /// 取消
        /// </summary>
        protected virtual async Task Cancel()
        {
            if (TokenSource == null || TokenSource.IsCancellationRequested)
                return;

            TokenSource?.Cancel();
            TokenSource?.Dispose();
            if (TimeTask?.IsCompleted ?? false)
            {
                TimeTask?.Dispose();
            }
            Terminus = DateTime.MinValue;
            await InvokeStateHasChangedAsync();
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <returns></returns>
        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await Cancel();
        }
    }
}
