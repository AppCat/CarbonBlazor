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
    public abstract class BxListBoxComponentBase<TOption> : BxSelectComponentBase<TOption, string>
        where TOption : class, IBxOption<string>
    {
        /// <summary>
        /// 展开
        /// </summary>
        protected bool Expanded { get; set; }

        /// <summary>
        /// 展开方式
        /// </summary>
        protected string ExpandedWay { get; set; } = string.Empty;

        /// <summary>
        /// BoxMenu 渲染
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment BoxMenuFragment() => __builder =>
        {
            var sequence = 0;

            if (Expanded)
            {
                __builder.OpenElement(sequence++, "ul");
                __builder.AddAttribute(sequence++, "role", "listbox");
                __builder.AddConfig(ref sequence, new BxComponentConfig(BoxMenuConfig)
                    .AddClass($"bx--list-box__menu")
                    .AddId($"{Id}-box__menu"));

                __builder.AddContent(sequence++, ChildContent);

                __builder.CloseElement();
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
                if (FocusOption != null)
                {
                    await SelectedOptionAsync(FocusOption);
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
                        var oldKey = FocusOption?.Key;
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
                        if (Options.TryGetValue(focusKey, out var option))
                        {
                            FocusOption = option;
                            NotifyOptionStateHasChanged(new[] { oldKey, option.Key });
                        }
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
            SelectedOption = null;
            Value = string.Empty;
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
            if (option != null)
            {
                Value = option.Key;
            }
            await base.SelectedOptionAsync(option, isClick);

            if (SelectedOption == option)
            {
                await HideAsync();
            }
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
            if (Expanded)
                return;

            Expanded = true;
            await OnExpandedChanged.InvokeAsync(Expanded);
            StateHasChanged();
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        /// <returns></returns>
        protected async Task HideAsync()
        {
            if (!Expanded)
                return;

            Expanded = false;
            await OnExpandedChanged.InvokeAsync(Expanded);
            if (SelectedOption != null)
            {
                Value = SelectedOption.Key;
            }
            else
            {
                Value = string.Empty;
            }
            StateHasChanged();
        }

        /// <summary>
        /// box__menu 配置
        /// The box__menu is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? BoxMenuConfig { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        [Parameter]
        public string? Placeholder { get; set; }

        /// <summary>
        /// 展开
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnExpandedChanged { get; set; }
    }
}
