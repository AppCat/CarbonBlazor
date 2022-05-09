using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Loading 的参数部分
    /// Loading parameter partial
    /// </summary>
    public partial class BxLoading
    {
        /// <summary>
        /// 指定是否需要的小变体
        /// Specify whether you would like the small variant of
        /// </summary>
        [Parameter]
        public bool Small { get; set; }

        /// <summary>
        /// 指定是否希望加载器与覆盖一起应用 
        /// Specify whether you want the loader to be applied with an overlay
        /// </summary>
        [Parameter]
        public bool WithOverlay { get; set; } = true;

        /// <summary>
        /// Loading 配置
        /// The icon is config for the loading.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LoadingConfig { get; set; }

        /// <summary>
        /// 指定一个描述，用来最好地描述加载状态  
        /// Specify a description that would be used to best describe the loading state
        /// </summary>
        [Parameter]
        public string? Description { get; set; }

        /// <summary>
        /// 停止
        /// </summary>
        [Parameter]
        public bool Stop { get; set; }
    }
}
