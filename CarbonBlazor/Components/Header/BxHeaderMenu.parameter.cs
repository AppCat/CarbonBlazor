using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// HeaderMenu 的参数部分
    /// HeaderMenu parameter partial
    /// </summary>
    public partial class BxHeaderMenu
    {
        /// <summary>
        /// 可以选择指定一个aria-label
        /// Optionally specify an aria-label
        /// </summary>
        [Parameter]
        public string? AriaLabel { get; set; }

        /// <summary>
        /// 可以选择指定一个 title
        /// Optionally specify an title
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// 可以选择指定一个 title template
        /// Optionally specify an title template
        /// </summary>
        [Parameter]
        public RenderFragment? TitleTemplate { get; set; }

        #region Config

        /// <summary>
        /// header__menu-title 配置
        /// The header__menu-title is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? MenuTitleConfig { get; set; }

        /// <summary>
        /// header__menu 配置
        /// The header__menu is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? MenuConfig { get; set; }

        #endregion
    }
}
