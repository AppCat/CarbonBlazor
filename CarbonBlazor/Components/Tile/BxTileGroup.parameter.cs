using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// TileGroup 的参数部分
    /// TileGroup parameter partial
    /// </summary>
    public partial class BxTileGroup
    {
        /// <summary>
        /// 为这个组提供一个可选的图例
        /// Provide an optional legend for this group
        /// </summary>
        [Parameter]
        public string? Legend { get; set; }

        /// <summary>
        /// 为这个组提供一个可选的图例的模板
        /// Provide an optional legend of the template for this group
        /// </summary>
        [Parameter]
        public RenderFragment? LegendTemplate { get; set; }

        /// <summary>
        /// undefined--label 配置
        /// The undefined--label is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LegendConfig { get; set; }
    }
}
