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
    public partial class BxBreadcrumb
    {
        /// <summary>
        /// 可选的prop来省略面包屑路径的末尾斜杠  
        /// Optional prop to omit the trailing slash for the breadcrumbs
        /// </summary>
        [Parameter]
        public bool NoTrailingSlash { get; set; }

        /// <summary>
        /// 骨架
        /// Skeleton
        /// </summary>
        [Parameter]
        public bool Skeleton { get; set; }
    }
}
