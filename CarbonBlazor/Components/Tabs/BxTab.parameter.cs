using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Tab 的参数部分
    /// Tab parameter partial
    /// </summary>
    public partial class BxTab
    {
        /// <summary>
        /// 子内容
        /// </summary>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        /// <summary>
        /// 交互式
        /// Interactive
        /// </summary>
        [Parameter]
        public bool Interactive { get; set; }

        /// <summary>
        /// tab-content 配置
        /// The tab-content is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ContentConfig { get; set; }
    }
}
