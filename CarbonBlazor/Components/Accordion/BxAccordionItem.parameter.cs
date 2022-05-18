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
    /// AccordionItem 的参数部分
    /// AccordionItem parameter partial
    /// </summary>
    public partial class BxAccordionItem
    {
        /// <summary>
        /// 手风琴标题。
        /// The accordion title.
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// 手风琴标题。
        /// The accordion title.
        /// </summary>
        [Parameter]
        public RenderFragment? TitleTemplate { get; set; }

        /// <summary>
        /// 是否打开
        /// </summary>
        [Parameter]
        public bool IsOpen { get; set; }

        #region Event

        /// <summary>
        /// 点击事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnHeadingClick { get; set; }

        /// <summary>
        /// 打开变化用于 bind
        /// </summary>
        [Parameter]
        public EventCallback<bool> IsOpenChanged { get; set; }

        /// <summary>
        /// 函数在菜单关闭时调用
        /// Function called when menu is closed
        /// </summary>
        [Parameter]
        public EventCallback OnClose { get; set; }

        /// <summary>
        /// 当菜单打开时调用的函数
        /// Function called when menu is opened
        /// </summary>
        [Parameter]
        public EventCallback OnOpen { get; set; }

        #endregion

        #region Config

        /// <summary>
        /// accordion__heading 配置
        /// The accordion__heading is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? HeadingConfig { get; set; }

        /// <summary>
        /// accordion__title 配置
        /// The accordion__title is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TitleConfig { get; set; }

        /// <summary>
        /// accordion__content 配置
        /// The accordion__content is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ContentConfig { get; set; }

        #endregion
    }
}
