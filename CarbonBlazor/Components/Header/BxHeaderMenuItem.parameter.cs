using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components   
{
    /// <summary>
    /// HeaderMenuItem 的参数部分
    /// HeaderMenuItem parameter partial
    /// </summary>
    public partial class BxHeaderMenuItem
    {
        /// <summary>
        /// 可选地为指定href
        /// Optionally specify an href
        /// </summary>
        [Parameter]
        public string? Href { get; set; } = "#";

        /// <summary>
        /// 可以选择指定一个标题
        /// Optionally specify an title
        /// </summary>
        [Parameter]
        public string ? Title { get; set; }

        #region Config

        /// <summary>
        /// header__menu-item 配置
        /// The header__menu-item is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? MenuItemConfig { get; set; }

        /// <summary>
        /// text-truncate--end 配置
        /// The text-truncate--end is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TextConfig { get; set; }

        #endregion
    }
}
