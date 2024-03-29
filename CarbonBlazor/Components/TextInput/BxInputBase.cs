﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// input base
    /// </summary>
    public abstract partial class BxInputBase<TValue> : BxFormItemComponentBaseOf<TValue>
    {
        /// <summary>
        /// 输入框
        /// </summary>
        protected ElementReference InputElement { get; set; }

        /// <summary>
        /// 键盘按下事件
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnKeyupAsync(KeyboardEventArgs args)
        {
            if (args != null && args.Key == "Enter")
            {
                await OnEnter.InvokeAsync(args);
            }
        }

        /// <summary>
        /// 输入
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnInputAsync(ChangeEventArgs args)
        {
            if (QuickResponse)
            {
                await HandleOnChangeAsync(args);
            }
        }

        /// <summary>
        /// 处理 OnChange
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnChangeAsync(ChangeEventArgs args)
        {
            var value = args.Value?.ToString();
            await SetStringValueAsync(value);
        }

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (typeof(TValue) == typeof(DateTime) && string.IsNullOrEmpty(Format))
            {
                Format = "yyyy-MM-dd HH:mm:ss";
            }
        }

        #endregion
    }
}
