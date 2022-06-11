using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 有展开的选择组件基础
    /// </summary>
    public abstract partial class BxListBoxComponentBaseOf<TOption, TKey> : BxSelectComponentBaseOf<TOption, TKey>
        where TOption : class, IBxOptionOf<TKey>
        where TKey : notnull
    {
        /// <summary>
        /// 当前展开
        /// </summary>
        protected bool CurrentExpanded { get; set; }

        /// <summary>
        /// 展开方式
        /// </summary>
        protected string ExpandedWay { get; set; }

        /// <summary>
        /// 是否渲染
        /// </summary>
        public override bool IsRender => CurrentExpanded;

        /// <summary>
        /// BoxMenu 渲染
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment BoxMenuFragment() => __builder =>
        {
            var sequence = 0;

            if (CurrentExpanded)
            {
                __builder.OpenElement(sequence++, "ul");
                __builder.AddAttribute(sequence++, "role", "listbox");
                __builder.AddConfig(ref sequence, new BxComponentConfig(BoxMenuConfig)
                    .AddClass($"bx--list-box__menu")
                    .AddId($"{Id}-box__menu"));

                __builder.AddContent(sequence++, ChildContent);

                __builder.CloseElement();
            }
            else
            {
                __builder.AddContent(sequence++, ChildContent);
            }
        };

        /// <summary>
        /// 键盘按下事件
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnKeyupAsync(KeyboardEventArgs args)
        {
            if (args != null && args.Key == "Enter")
            {
                if (FirstSelectedKey is not null && Options.TryGetValue(FirstSelectedKey, out TOption? focusOption))
                {
                    await SelectedOptionAsync(focusOption);
                    await HideAsync();
                }
            }
            else if (args?.Key == "Escape")
            {
                await HideAsync();
            }
            else
            {
                await ShowAsync();
                if (args?.Key == "ArrowUp" || args?.Key == "ArrowDown")
                {
                    var keys = Options.Keys.ToArray();
                    if (keys.Any())
                    {
                        var oldKey = FirstSelectedKey;
                        var focusKey = oldKey ?? keys.FirstOrDefault();
                        var index = Array.IndexOf(keys, focusKey);
                        if (args?.Key == "ArrowUp")
                        {
                            index -= 1;
                        }
                        else if (args?.Key == "ArrowDown")
                        {
                            index += 1;
                        }
                        var focusIndex = (Math.Abs(index)) % keys.Length;
                        focusKey = keys[focusIndex];
                        FirstSelectedKey = focusKey;
                        NotifyOptionStateHasChanged(new[] { oldKey, focusKey });
                    }
                }
            }
        }

        /// <summary>
        /// 聚焦
        /// </summary>
        /// <returns></returns>
        protected virtual async Task HandleOnFocusAsync()
        {
            ExpandedWay = "input";
            await ShowAsync();
        }

        /// <summary>
        /// 失去焦点
        /// </summary>
        /// <returns></returns>
        protected virtual async Task HandleOnBlurAsync()
        {
            if (ExpandedWay == "input")
            {
                await HideAsync();
            }
        }

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickMenuIconAsync(MouseEventArgs args)
        {
            ExpandedWay = "button";
            if (Expanded)
            {
                await HideAsync();
            }
            else
            {
                await ShowAsync();
            }
        }

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickSelectionAsync(MouseEventArgs args)
        {
            //SelectedOption = null;
            //Value = string.Empty;
            await HideAsync();
        }

        /// <summary>
        /// 选中项目
        /// </summary>
        /// <param name="option"></param>
        /// <param name="isClick"></param>
        /// <returns></returns>
        public override async Task SelectedOptionAsync(TOption option, bool isClick = false)
        {
            await base.SelectedOptionAsync(option, isClick);
            await HideAsync();
        }

        /// <summary>
        /// 处理外部点击
        /// </summary>
        protected virtual void HandleExternalClick(ClickElement[] path)
        {
            if (!Expanded)
                return;
            if (path.Any(e => e.Id == $"{Id}-combo-box")) // 包含自己不隐藏
                return;
            InvokeAsync(() => HideAsync());
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        protected async Task ShowAsync()
        {
            if (CurrentExpanded)
                return;

            await SetExpandedAsync(true);
            await OnShowBoxMenu.InvokeAsync();
            await InvokeStateHasChangedAsync();
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        /// <returns></returns>
        protected async Task HideAsync()
        {
            if (!CurrentExpanded)
                return;

            await SetExpandedAsync(false);
            await OnHideBoxMenu.InvokeAsync();

            //if (SelectedOption != null)
            //{
            //    Value = SelectedOption.Key;
            //}
            //else
            //{
            //    Value = string.Empty;
            //}

            await InvokeStateHasChangedAsync();
        }

        /// <summary>
        /// 设置 Expanded
        /// </summary>
        /// <param name="expanded"></param>
        /// <returns></returns>
        protected async Task SetExpandedAsync(bool expanded)
        {
            CurrentExpanded = expanded;

            if (expanded != Expanded)
            {
                Expanded = expanded;
                await ExpandedChanged.InvokeAsync(Expanded);
                await OnExpandedChanged.InvokeAsync(Expanded);
            }
        }

        #region SDLC

        /// <summary>
        /// 设置参数后
        /// </summary>
        protected override async Task OnParametersSetAsync()
        {
            if (CurrentExpanded != Expanded)
            {
                if (Expanded)
                {
                    await ShowAsync();
                }
                else
                {
                    await HideAsync();
                }
            }
            await base.OnParametersSetAsync();
        }

        #endregion 
    }
}
