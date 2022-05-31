using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 OverflowMenu 的 Blazor 组件。  
    /// This is a Blazor component for the OverflowMenu.
    /// </summary>
    public partial class BxOverflowMenu : BxContentComponentBase
    {
        /// <summary>
        /// 左
        /// </summary>
        protected decimal Left { get; set; }

        /// <summary>
        /// 顶
        /// </summary>
        protected decimal Top { get; set; }

        /// <summary>
        /// 是否打开
        /// </summary>
        protected bool IsOpen { get; set; }

        /// <summary>
        /// 选择元素
        /// </summary>
        protected ElementReference OptionsElement { get; set; }

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--overflow-menu";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .AddEnum(Size, () => $"{fixedClass}--{Size}")
                .If("bx--overflow-menu--open", () => IsOpen)
                .If("bx--toolbar-action", () => FatherComponentContext?.FatherComponent is BxTableToolbar)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.UseElement(ref sequence, "button", this,
            __builder =>
            {
                __builder.AddAttribute(sequence++, "type", "button");
                __builder.AddAria(ref sequence, "haspopup", true);
                __builder.AddAria(ref sequence, "expanded", IsOpen);
                __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
                __builder.AddEvent(ref sequence, "onfocus", HandleOnFocusAsync);
                __builder.AddEvent(ref sequence, "onkeydown", HandleOnKeyDownAsync);
                __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' aria-label='' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true' class='bx--overflow-menu__icon'><circle cx='16' cy='8' r='2'></circle><circle cx='16' cy='16' r='2'></circle><circle cx='16' cy='24' r='2'></circle></svg>"));
                //__builder.AddCascadingValue<BxOverflowMenuGoal>(ref sequence, BxOverflowMenuGoal.Read, __builder =>
                //{
                //    var sequence = 0;
                //    MenuOptions.Clear();
                //    __builder.AddCascadingValue<List<BxOverflowMenuOption>>(ref sequence, MenuOptions, ChildContent);
                //});
            }, null);

            if (IsOpen)
            {

            }

            __builder.OpenElement(sequence++, "div");
            {
                __builder.AddContent(sequence++, new MarkupString("<span tabindex='0' role='link' class='bx--visually-hidden'>Focus sentinel</span>"));
                __builder.OpenElement(sequence++, "ul");
                __builder.AddConfig(ref sequence, new BxComponentConfig(OptionsConfig, "bx--overflow-menu-options", $"{Id}-options")
                    .AddIfClass("bx--overflow-menu-options--open", () => IsOpen)
                    .AddIfClass("bx--overflow-menu--flip", () => Flipped)
                    .AddIfClass($"bx--overflow-menu-options--{Size}", () => Size != null)
                    .AddStyle("top", $"{Top}px")
                    .AddStyle("position", "absolute")
                    .AddStyle("opacity", "1")
                    .AddStyle("left", $"{Left}px")
                    .AddStyle("right", "auto")
                    );
                __builder.AddAttribute(sequence++, "tabindex", "-1");
                __builder.AddAttribute(sequence++, "role", "menu");
                __builder.AddAttribute(sequence++, "data-floating-menu-direction", $"{Direction ?? BxOverflowMenuDirection.Bottom}");
                __builder.AddContent(sequence++, ChildContent);
                __builder.AddElementReferenceCapture(sequence++, element =>
                {
                    OptionsElement = element;
                });
                __builder.CloseElement();
            }
            __builder.CloseElement();
        };

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickAsync(MouseEventArgs args)
        {
            if (IsOpen)
            {
                await CloseAsync();
            }
            else
            {
                await OpenAsync();
            }

            await OnOnClick.InvokeAsync(args);
        }


        /// <summary>
        /// 处理 OnFocus
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnFocusAsync(FocusEventArgs args)
        {
            await OnFocus.InvokeAsync(args);
        }

        /// <summary>
        /// 处理 OnKeyDown
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnKeyDownAsync(KeyboardEventArgs args)
        {

            await OnKeyDown.InvokeAsync(args);
        }

        /// <summary>
        /// 打开
        /// menu is opened
        /// </summary>
        /// <returns></returns>
        protected virtual async Task OpenAsync()
        {
            if (IsOpen)
                return;

            IsOpen = true;
            await PositionAsync();
            await OnOpen.InvokeAsync();
            await InvokeStateHasChangedAsync();
        }

        /// <summary>
        /// 关闭
        /// menu is closed
        /// </summary>
        /// <returns></returns>
        protected virtual async Task CloseAsync()
        {
            if (!IsOpen)
                return;

            IsOpen = false;
            await OnClose.InvokeAsync();
            await InvokeStateHasChangedAsync();
        }

        /// <summary>
        /// 位置计算
        /// </summary>
        /// <returns></returns>
        protected async Task PositionAsync()
        {
            if (ElementHelp != null && IsOpen)
            {
                var wrapperWidth = 160;
                var childElementCount = await ElementHelp.GetElementPropertyByIdAsync<decimal>($"{Id}-options", "childElementCount");

                var offsetLeft = await ElementHelp.GetElementPropertyByIdAsync<decimal>(Id, "offsetLeft");
                var offsetTop = await ElementHelp.GetElementPropertyByIdAsync<decimal>(Id, "offsetTop");
                var offsetHeight = await ElementHelp.GetElementPropertyByIdAsync<decimal>(Id, "offsetHeight");
                var offsetWidth = await ElementHelp.GetElementPropertyByIdAsync<decimal>(Id, "offsetWidth");

                if (Direction?.Value == BxOverflowMenuDirection.Bottom && Flipped)
                {
                    Left = offsetLeft - wrapperWidth + offsetWidth;
                    Top = offsetTop + offsetHeight;
                }
                else if (Direction?.Value == BxOverflowMenuDirection.Bottom && !Flipped)
                {
                    Left = offsetLeft;
                    Top = offsetTop + offsetHeight;
                }
                else if (Direction?.Value == BxOverflowMenuDirection.Top && Flipped)
                {
                    Left = offsetLeft - wrapperWidth + offsetWidth;
                    Top = offsetTop - (childElementCount * 40);
                }
                else if (Direction?.Value == BxOverflowMenuDirection.Top && !Flipped)
                {
                    Left = offsetLeft;
                    Top = offsetTop - (childElementCount * 40);
                }
            }
        }

        /// <summary>
        /// 处理外部点击
        /// </summary>
        /// <param name="path"></param>
        protected void HandleExternalClick(ClickElement[] path)
        {
            if (path.Any(e => e.Id == $"{Id}-options" || e.Id == $"{Id}")) // 包含自己不隐藏
                return;
            InvokeAsync(() => CloseAsync());
        }

        /// <summary>
        /// 处理窗口变化
        /// </summary>
        /// <param name="args"></param>
        protected async void HandleWindowResizeChange(ResizeEventArgs args)
        {
            if (IsOpen)
            {
                await PositionAsync();
                await InvokeStateHasChangedAsync();
            }
        }

        #region SDLC

        bool alreadyFocus = false;

        /// <summary>
        /// 初始化后
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            OnDocumentClick += HandleExternalClick;
            OnResize += HandleWindowResizeChange;
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            OnDocumentClick -= HandleExternalClick;
            OnResize -= HandleWindowResizeChange;
        }

        /// <summary>
        /// 渲染后
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (IsOpen && !alreadyFocus)
            {
                await OptionsElement.FocusAsync();
                alreadyFocus = true;
            }
            else if (!IsOpen && alreadyFocus)
            {
                alreadyFocus = false;
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        #endregion
    }
}
