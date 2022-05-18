using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Header 的参数部分
    /// Header parameter partial
    /// </summary>
    public partial class BxHeader
    {
        /// <summary>
        /// 指定要添加到标题中的可选名称  
        /// Specify an optional Name to be added to your Header
        /// </summary>
        [Parameter]
        public string? HeaderName { get; set; }

        /// <summary>
        /// 指定要添加到标题中的可选名称  
        /// Specify an optional Name to be added to your Header
        /// </summary>
        [Parameter]
        public RenderFragment? HeaderNameTemplate { get; set; }

        /// <summary>
        /// 指定一个可选的前缀添加到头部 
        /// Specify an optional Prefix to be added to your Header
        /// </summary>
        [Parameter]
        public string? HeaderNamePrefix { get; set; }

        /// <summary>
        /// 可选地为 HeaderName 指定href
        /// Optionally specify an href for your
        /// </summary>
        [Parameter]
        public string? Href { get; set; } = "#";

        /// <summary>
        /// 用于 header 的导航  
        /// Navigation for headers
        /// </summary>
        [Parameter]
        public RenderFragment? NavigationTemplate { get; set; }       

        /// <summary>
        /// 用于 header 的 GlobalBar  
        /// GlobalBar for headers
        /// </summary>
        [Parameter]
        public RenderFragment? GlobalBarTemplate { get; set; }

        /// <summary>
        /// 用于 header 的 Side 
        /// Side for headers
        /// </summary>
        [Parameter]
        public RenderFragment? SideNavTemplate { get; set; }

        /// <summary>
        /// 可以选择指定一个aria-label
        /// Optionally specify an aria-label
        /// </summary>
        [Parameter]
        public string? AriaLabel { get; set; }

        /// <summary>
        /// 可以选择指定导航的aria-label
        /// Optionally specify an aria-label of navigation
        /// </summary>
        [Parameter]
        public string? NavigationAriaLabel { get; set; }

        #region Config

        /// <summary>
        /// header__name 配置
        /// The header__name is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? NameConfig { get; set; }

        /// <summary>
        /// header__name--prefix 配置
        /// The header__name--prefix is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? NamePrefixConfig { get; set; }

        /// <summary>
        /// header__nav 配置
        /// The header__nav is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? NavigationConfig { get; set; }

        /// <summary>
        /// header__menu-bar 配置
        /// The header__menu-bar is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? NavigationMenuConfig { get; set; }

        /// <summary>
        /// header__global 配置
        /// The header__global is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? GlobalBarConfig { get; set; }

        /// <summary>
        /// side-nav__navigation 配置
        /// The side-nav__navigation is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? SideNavConfig { get; set; }

        #endregion
    }
}
