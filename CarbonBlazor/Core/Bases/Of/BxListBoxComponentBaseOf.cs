using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
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
        };

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        protected async Task ShowAsync()
        {
            if (CurrentExpanded)
                return;

            CurrentExpanded = true;
            await ExpandedChanged.InvokeAsync(Expanded);
            await OnExpandedChanged.InvokeAsync(Expanded);
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

            CurrentExpanded = false;
            await ExpandedChanged.InvokeAsync(Expanded);
            await OnExpandedChanged.InvokeAsync(Expanded);
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
    }
}
