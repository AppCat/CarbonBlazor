using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Tabs 的参数部分
    /// Tabs parameter partial
    /// </summary>
    public partial class BxTabs
    {
        /// <summary>
        /// Contained
        /// </summary>
        [Parameter]
        public bool Contained { get; set; }

        /// <summary>
        /// 骨架
        /// Skeleton
        /// </summary>
        [Parameter]
        public bool Skeleton { get; set; }

        /// <summary>
        /// tab--list 配置
        /// The tab--list is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TabListConfig { get; set; }
    }
}
