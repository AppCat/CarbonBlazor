using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Breadcrumb 的参数部分
    /// Breadcrumb parameter partial
    /// </summary>
    public partial class BxBreadcrumbItem
    {
        /// <summary>
        /// 可选字符串，表示BreadcrumbItem的链接位置
        /// Optional string representing the link location for the BreadcrumbItem
        /// </summary>
        [Parameter]
        public string? Href { get; set; }

        /// <summary>
        /// 提供此breadcrumb项是否表示当前页面    
        /// Provide if this breadcrumb item represents the current page
        /// </summary>
        [Parameter]
        public bool IsCurrentPage { get; set; }

        /// <summary>
        /// link 配置
        /// The link is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LinkConfig { get; set; }
    }
}
