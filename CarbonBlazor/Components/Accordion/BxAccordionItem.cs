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
    /// 这是一个用于 AccordionItem 的 Blazor 组件。  
    /// This is a Blazor component for the AccordionItem.
    /// </summary>
    public partial class BxAccordionItem : BxContentComponentBase
    {
        /// <summary>
        /// 渲染目标
        /// </summary>
        [CascadingParameter(Name = "Skeleton")]
        public bool Skeleton { get; set; }

        /// <summary>
        /// 打开
        /// </summary>
        private bool _open { get; set; }

        /// <summary>
        /// 状态变化
        /// </summary>
        private bool _stateHasChanged = true;

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--accordion__item";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--accordion__item--disabled", () => Disabled)
                .If("bx--accordion__item--active", () => Open)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            var contentId = $"{Id}-content";

            __builder.UseElement(ref sequence, "li", this, __builder =>
            {
                if (Skeleton)
                {
                    __builder.AddContent(sequence++, new MarkupString("<span class='bx--accordion__heading'><svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true' class='bx--accordion__arrow'><path d='M11 8L6 13 5.3 12.3 9.6 8 5.3 3.7 6 3z'></path></svg><p class='bx--skeleton__text bx--accordion__title' style='width: 100%;'></p></span>"));
                    __builder.AddContent(sequence++, new MarkupString("<div class='bx--accordion__content'><p class='bx--skeleton__text' style='width: 90%;'></p><p class='bx--skeleton__text' style='width: 80%;'></p><p class='bx--skeleton__text' style='width: 95%;'></p></div>"));
                    return;
                }

                __builder.OpenElement(sequence++, "button");
                __builder.AddConfig(ref sequence, new BxComponentConfig(HeadingConfig, "bx--accordion__heading", $"{Id}-heading"));
                __builder.AddAttribute(sequence++, "type", "button");
                if (Disabled)
                {
                    __builder.AddAttribute(sequence++, "disabled");
                }
                __builder.AddAria(ref sequence, "expanded", Open);
                __builder.AddAria(ref sequence, "controls", contentId);
                __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
                {
                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true' class='bx--accordion__arrow'><path d='M11 8L6 13 5.3 12.3 9.6 8 5.3 3.7 6 3z'></path></svg>"));

                    __builder.OpenElement(sequence++, "div");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(TitleConfig, "bx--accordion__title", $"{Id}-title"));
                    __builder.AddAttribute(sequence++, "dir", "auto");
                    __builder.EitherOrAddContent(ref sequence, TitleTemplate, Title, () => TitleTemplate != null);
                    __builder.CloseElement();
                }
                __builder.CloseElement();

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ContentConfig, "bx--accordion__content", contentId));
                __builder.AddContent(sequence++, ChildContent);
                __builder.CloseElement();
            });
        };

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickAsync(MouseEventArgs args)
        {
            if (Disabled)
                return;

            _stateHasChanged = false;

            if (!Open)
            {
                await OpenAsync();
            }
            else
            {
                await CloseAsync();
            }

            await OnHeadingClick.InvokeAsync(args);
        }

        /// <summary>
        /// 打开
        /// </summary>
        /// <returns></returns>
        public async Task OpenAsync()
        {
            if (_open)
                return;

            _open = true;
            Open = _open;
            await OnOpen.InvokeAsync();
            await OnOpenChange.InvokeAsync(Open);
            await OpenChanged.InvokeAsync(Open);
            await InvokeStateHasChangedAsync(_stateHasChanged);
            _stateHasChanged = true;
        }

        /// <summary>
        /// 打开
        /// </summary>
        /// <returns></returns>
        public async Task CloseAsync()
        {
            if (!_open)
                return;

            _open = false;
            Open = _open;
            await OnClose.InvokeAsync();
            await OnOpenChange.InvokeAsync(Open);
            await OpenChanged.InvokeAsync(Open);
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
            _open = Open;
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <returns></returns>
        protected override async Task OnParametersSetAsync()
        {
            if (_open != Open)
            {
                if (Open)
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
