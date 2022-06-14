using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 数据表容器参数部分
    /// DataTableContainer table parameter partial
    /// </summary>
    public partial class BxDataTableContainer
    {
        /// <summary>
        /// 容器的标题。
        /// The title for the container.
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// 容器的标题的模板。  
        /// The title is template for the container.
        /// </summary>
        [Parameter]
        public RenderFragment? TitleTemplate { get; set; }

        /// <summary>
        /// 容器的描述。
        /// The description for the container.
        /// </summary>
        [Parameter]
        public string? Description { get; set; }

        /// <summary>
        /// 容器的描述的模板。  
        /// The description is template for the container.
        /// </summary>
        [Parameter]
        public RenderFragment? DescriptionTemplate { get; set; }

        /// <summary>
        /// 批处理操作的模板。
        /// The action-list is template for the container.
        /// </summary>
        [Parameter]
        public RenderFragment<IEnumerable<object>>? BatchListTemplate { get; set; }

        /// <summary>
        /// 返回选定项的函数。
        /// A function returning the selected item.
        /// </summary>
        [Parameter]
        public Func<IEnumerable<object>, string>? SummaryParaText { get; set; }

        /// <summary>
        /// 工具栏内容的模板
        /// The toolbar-content is template for the container.
        /// </summary>
        [Parameter]
        public RenderFragment? ToolbarContentTemplate { get; set; }

        #region Event

        /// <summary>
        /// 显示批处理
        /// </summary>
        [Parameter]
        public EventCallback OnShowBatch { get; set; }

        /// <summary>
        /// 关闭批处理
        /// </summary>
        [Parameter]
        public EventCallback OnCloseBatch { get; set; }

        #endregion

        #region Config

        /// <summary>
        /// header 配置
        /// The header is config for the container.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? HeaderConfig { get; set; }

        /// <summary>
        /// title 配置
        /// The title is config for the container.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TitleConfig { get; set; }

        /// <summary>
        /// description 配置
        /// The description is config for the container.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? DescriptionConfig { get; set; }

        /// <summary>
        /// toolbar 配置
        /// The toolbar is config for the container.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ToolbarConfig { get; set; }

        /// <summary>
        /// toolbar-content 配置
        /// The toolbar-content is config for the container.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ToolbarContentConfig { get; set; }

        /// <summary>
        /// batch-actions 配置
        /// The batch-actions is config for the container.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? BatchActionsConfig { get; set; }

        /// <summary>
        /// batch-summary 配置
        /// The batch-summary is config for the container.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? BatchSummaryConfig { get; set; }

        /// <summary>
        /// batch-summary__para 配置
        /// The batch-summary__para is config for the container.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? BatchSummaryParaConfig { get; set; }

        /// <summary>
        /// batch-list 配置
        /// The batch-list is config for the container.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? BatchListParaConfig { get; set; }

        /// <summary>
        /// data-table-content 配置
        /// The data-table-content is config for the container.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ContentConfig { get; set; }

        #endregion
    }
}
