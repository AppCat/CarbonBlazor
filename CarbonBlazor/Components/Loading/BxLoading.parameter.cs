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
        public bool Small { get; set; }

        /// <summary>
        /// 指定是否希望加载器与覆盖一起应用 
        /// Specify whether you want the loader to be applied with an overlay
        /// </summary>
        public bool WithOverlay { get; set; } = true;

        /// <summary>
        /// Loading 配置
        /// The icon is config for the loading.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LoadingConfig { get; set; } 
    }
}
