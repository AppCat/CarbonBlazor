using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// RadioTile 的参数部分
    /// RadioTile parameter partial
    /// </summary>
    public partial class BxRadioTile
    {
        /// <summary>
        /// 为True时选择此贴图。
        /// true to select this tile.
        /// </summary>
        [Parameter]
        public bool Selected { get; set; }

        /// <summary>
        /// 变化事件
        /// </summary>
        [Parameter]
        public virtual EventCallback<bool> SelectedChanged { get; set; }

        /// <summary>
        /// 变化事件
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnSelectedChange { get; set; }

        #region Config

        /// <summary>
        /// tile-input 配置
        /// The tile-input is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? InputConfig { get; set; }

        /// <summary>
        /// tile__checkmark 配置
        /// The tile__checkmark is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? CheckmarkConfig { get; set; }

        /// <summary>
        /// tile-content 配置
        /// The tile-content is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ContentConfig { get; set; }

        #endregion
    }
}
