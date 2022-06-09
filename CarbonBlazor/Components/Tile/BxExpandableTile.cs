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
    /// 这是一个用于 ExpandableTile 的 Blazor 组件。  
    /// This is a Blazor component for the ExpandableTile.
    /// </summary>
    public partial class BxExpandableTile : OtherTileBase
    {
        /// <summary>
        /// 展开
        /// </summary>
        private bool _expanded { get; set; }

        /// <summary>
        /// 状态变化
        /// </summary>
        private bool _stateHasChanged = true;

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--tile bx--tile--expandable";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--tile--is-expanded", () => Expanded)
                .If("bx--tile--expandable--interactive", () => Interactive)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.UseElement(ref sequence, Interactive ? "div" : "button", this, __builder =>
            {
                if (!Interactive)
                {
                    __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
                    __builder.AddEvent(ref sequence, "onkeydown", HandleOnKeyDownAsync);
                }
                __builder.AddAttribute(sequence++, "aria-expanded", Expanded.ToString());
            },
            __builder =>
            {
                var sequence = 0;
                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(AboveContentConfig, $"bx--tile-content", $"{Id}-tile-content-above"));
                {
                    __builder.OpenElement(sequence++, "div");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(AboveFoldContentConfig, $"bx--tile-content__above-the-fold", $"{Id}-tile-content-above-fold"));
                    __builder.AddContent(sequence++, AboveContentTemplate);
                    __builder.CloseElement();
                }
                __builder.CloseElement();

                if (Interactive)
                {
                    __builder.OpenElement(sequence++, "button");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(ChevronConfig, $"bx--tile__chevron bx--tile__chevron--interactive", $"{Id}-chevron"));
                    __builder.AddAttribute(sequence++, "type", "button");
                    __builder.AddAttribute(sequence++, "aria-expanded", Expanded.ToString());
                    __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
                    __builder.AddEvent(ref sequence, "onkeydown", HandleOnKeyDownAsync);
                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true'><path d='M8 11L3 6 3.7 5.3 8 9.6 12.3 5.3 13 6z'></path></svg>"));
                    __builder.CloseElement();
                }
                else
                {
                    __builder.OpenElement(sequence++, "div");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(ChevronConfig, $"bx--tile__chevron", $"{Id}-chevron"));
                    __builder.AddContent(sequence++, new MarkupString("<span></span>"));
                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true'><path d='M8 11L3 6 3.7 5.3 8 9.6 12.3 5.3 13 6z'></path></svg>"));
                    __builder.CloseElement();
                }

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(BelowContentConfig, $"bx--tile-content", $"{Id}-tile-content-below"));
                {
                    __builder.OpenElement(sequence++, "div");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(BelowFoldContentConfig, $"bx--tile-content__below-the-fold", $"{Id}-tile-content-below-fold"));
                    __builder.IfAddContent(ref sequence, BelowContentTemplate, () => Expanded);
                    __builder.CloseElement();
                }
                __builder.CloseElement();
            });
        };

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override async Task HandleOnClickAsync(MouseEventArgs args)
        {
            await base.HandleOnClickAsync(args);

            _stateHasChanged = false;

            if (Expanded)
            {
                await CloseAsync();
            }
            else
            {
                await OpenAsync();
            }
        }

        /// <summary>
        /// 打开
        /// </summary>
        /// <returns></returns>
        protected virtual async Task OpenAsync()
        {
            if (_expanded)
                return;

            _expanded = true;
            Expanded = _expanded;
            await OnExpandedChange.InvokeAsync(Expanded);
            await ExpandedChanged.InvokeAsync(Expanded);
            await OnOpen.InvokeAsync();
            await InvokeStateHasChangedAsync(_stateHasChanged);
            _stateHasChanged = true;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <returns></returns>
        protected virtual async Task CloseAsync()
        {
            if (!_expanded)
                return;

            _expanded = false;
            Expanded = _expanded;
            await OnExpandedChange.InvokeAsync(Expanded);
            await ExpandedChanged.InvokeAsync(Expanded);
            await OnClose.InvokeAsync();
            await InvokeStateHasChangedAsync(_stateHasChanged);
            _stateHasChanged = true;
        }

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            _expanded = Expanded;
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <returns></returns>
        protected override async Task OnParametersSetAsync()
        {
            if (_expanded != Expanded)
            {
                if (Expanded)
                {
                    await OpenAsync();
                }
                else
                {
                    await CloseAsync();
                }
            }
        }

        #endregion
    }
}
