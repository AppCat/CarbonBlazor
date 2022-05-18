using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Dropdown 的参数部分
    /// Dropdown parameter partial
    /// </summary>
    public partial class BxDropdown
    {
        /// <summary>
        /// dropdown 配置
        /// The dropdown is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? DropdownConfig { get; set; }

        /// <summary>
        /// 行内
        /// inline
        /// </summary>
        [Parameter]
        public bool Inline { get; set; }

        /// <summary>
        /// button 配置
        /// The button is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ButtonConfig { get; set; }

        /// <summary>
        /// text 配置
        /// The text is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TextConfig { get; set; }

        /// <summary>
        /// icon 配置
        /// The icon is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? IconConfig { get; set; }
    }
}
