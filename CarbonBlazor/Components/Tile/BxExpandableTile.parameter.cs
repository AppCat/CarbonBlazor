using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// ClickableTile 的参数部分
    /// ClickableTile parameter partial
    /// </summary>
    public partial class BxExpandableTile
    {
        /// <summary>
        /// 展开
        /// </summary>
        [Parameter]
        public bool Expanded { get; set; }

        /// <summary>
        /// 互动方式 而不是全部点击
        /// </summary>
        [Parameter]
        public bool Interactive { get; set; }

        /// <summary>
        /// 上内容
        /// </summary>
        [Parameter]
        public RenderFragment? AboveContentTemplate { get; set; }

        /// <summary>
        /// 下内容
        /// </summary>
        [Parameter]
        public RenderFragment? BelowContentTemplate { get; set; }

        /// <summary>
        /// 未展开时的高度。没填写时为 Above 的高度 + 自身高度
        /// Height before expansion. If this parameter is not specified, it is the height of Above + its own height
        /// </summary>
        [Parameter]
        public int? AboveHeight { get; set; }

        #region Event

        /// <summary>
        /// 展开变化
        /// </summary>
        [Parameter]
        public EventCallback<bool> ExpandedChanged { get; set; }

        /// <summary>
        /// 展开变化
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnExpandedChange { get; set; }

        /// <summary>
        /// 打开
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnOpen { get; set; }

        /// <summary>
        /// 关闭
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnClose { get; set; }

        #endregion

        #region Config

        /// <summary>
        /// tile-content 配置
        /// The tile-content is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? AboveContentConfig { get; set; }

        /// <summary>
        /// tile-content__above-the-fold 配置
        /// The tile-content__above-the-fold is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? AboveFoldContentConfig { get; set; }

        /// <summary>
        /// tile__chevron 配置
        /// The tile__chevron is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ChevronConfig { get; set; }

        /// <summary>
        /// tile-content 配置
        /// The tile-content is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? BelowContentConfig { get; set; }

        /// <summary>
        /// tile-content__below-the-fold 配置
        /// The tile-content__below-the-fold is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? BelowFoldContentConfig { get; set; }

        #endregion
    }
}
