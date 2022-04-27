using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// Menu Base
    /// </summary>
    public abstract class BxMenuComponentBase : BxContentComponentBase
    {
        /// <summary>
        /// 展开
        /// </summary>
        protected bool Expanded { get; set; }

        /// <summary>
        /// 展开变换事件
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnExpandedChanged { get; set; }

        /// <summary>
        /// 打开事件
        /// </summary>
        [Parameter]
        public EventCallback OnOpen { get; set; }

        /// <summary>
        /// 关闭事件
        /// </summary>
        [Parameter]
        public EventCallback OnClose { get; set; }

        /// <summary>
        /// 打开
        /// </summary>
        /// <returns></returns>
        public async Task OpenAsync()
        {
            if (Expanded)
                return;

            Expanded = true;

            await OnExpandedChanged.InvokeAsync(Expanded);
            await OnOpen.InvokeAsync();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <returns></returns>
        public async Task CloseAsync()
        {
            if (!Expanded)
                return;

            Expanded = false;

            await OnExpandedChanged.InvokeAsync(Expanded);
            await OnClose.InvokeAsync();
        }
    }
}
