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
    /// Crad 的参数部分
    /// Crad parameter partial
    /// </summary>
    public partial class BxCrad
    {
        /// <summary>
        /// 指定卡头标题的内容。。
        /// Specify the content of the crad header title.
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// 指定卡头副标题的内容。。
        /// Specify the content of the crad header subtitle.
        /// </summary>
        [Parameter]
        public string? Subtitle { get; set; }

        /// <summary>
        /// 提供卡的内容
        /// Provide the toolbar of your Crad
        /// </summary>
        [Parameter]
        public RenderFragment? ToolbarTemplate { get; set; }

        /// <summary>
        /// 提供卡的内容
        /// Provide the contents of your Crad
        /// </summary>
        [Parameter]
        public RenderFragment? ContentTemplate { get; set; }

        /// <summary>
        /// 提供你的卡的页脚
        /// Provide the footer of your Crad
        /// </summary>
        [Parameter]
        public RenderFragment? FooterTemplate { get; set; }

        /// <summary>
        /// 加载中
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 处理事件用于 Bind。
        /// Loading event use for bind.
        /// </summary>
        [Parameter]
        public EventCallback<bool> LoadingChanged { get; set; }

        /// <summary>
        /// 点击事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// 点击停止传播
        /// </summary>
        [Parameter]
        public bool? OnClickStopPropagation { get; set; } = true;

        #region Config

        /// <summary>
        /// card--content 配置
        /// The card--content is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ContentConfig { get; set; }

        /// <summary>
        /// card--title 配置
        /// The card--title is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TitleConfig { get; set; }

        /// <summary>
        /// card--text 配置
        /// The card--text is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TextConfig { get; set; }

        /// <summary>
        /// card--toolbar 配置
        /// The card--toolbar is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ToolbarConfig { get; set; }

        /// <summary>
        /// card--header 配置
        /// The card--header is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? HeaderConfig { get; set; }

        /// <summary>
        /// card--footer--wrapper 配置
        /// The card--footer--wrapper is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? FooterConfig { get; set; }

        #endregion
    }
}
