using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// InlineLoading 的参数部分
    /// InlineLoading parameter partial
    /// </summary>
    public partial class BxInlineLoading
    {
        /// <summary>
        /// 指定内联加载文本的描述
        /// Specify the description for the inline loading text
        /// </summary>
        [Parameter]
        public string? Description { get; set; }

        /// <summary>
        /// 指定内联加载文本的描述
        /// Specify the description for the inline loading text
        /// </summary>
        [Parameter]
        public string? IconDescription { get; set; }

        /// <summary>
        /// 指定加载状态。
        /// Specify the loading status.
        /// </summary>
        [Parameter]
        public EnumMix<BxInlineLoadingStatus>? Status { get; set; } = BxInlineLoadingStatus.Active;

        ///// <summary>
        ///// 提供一个可选的处理程序，以便在成功时调用
        ///// Provide an optional handler to be invoked when is successful
        ///// </summary>
        //[Parameter]
        //public EventCallback OnSuccess { get; set; }

        /// <summary>
        /// loading__animation 配置
        /// The loading__animation is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? AnimationConfig { get; set; }

        /// <summary>
        /// loading__text 配置
        /// The loading__text is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TextConfig { get; set; }
    }
}
