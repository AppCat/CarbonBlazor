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
        /// 可以关闭选项卡
        /// </summary>
        [Parameter]
        public bool AllowCloseTab { get; set; }

        /// <summary>
        /// 关闭选项卡事件
        /// </summary>
        [Parameter]
        public EventCallback<IBxOption<string>> OnCloseTab { get; set; }

        /// <summary>
        /// tab--list 配置
        /// The tab--list is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TabListConfig { get; set; }
    }
}
