using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 数据表工具栏
    /// Table Toolbar
    /// </summary>
    public partial class BxTableToolbar
    {
        /// <summary>
        /// Batch Actions
        /// </summary>
        [Parameter]
        public RenderFragment? BatchActions { get; set; }

        /// <summary>
        /// BatchActions 配置
        /// The batchActions is config for the container.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? BatchActionsConfig { get; set; }

        /// <summary>
        /// Toolbar Content
        /// </summary>
        [Parameter]
        public RenderFragment? ToolbarContent { get; set; }

        /// <summary>
        /// ToolbarContent 配置
        /// The toolbarContent is config for the container.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ToolbarContentConfig { get; set; }

        /// <summary>
        /// 是否显示Batch
        /// </summary>
        [Parameter]
        public bool IsShowBatch { get; set; }

        /// <summary>
        /// 变化事件
        /// </summary>
        [Parameter]
        public virtual EventCallback<bool> IsShowBatchChanged { get; set; }
    }
}
