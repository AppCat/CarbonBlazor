using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 任何图表通用的基本图表选项
    /// Base chart options common to any chart
    /// </summary>
    public class BaseChartOptions
    {
        /// <summary>
        /// 可选地为图表指定一个标题
        /// Optionally specify a title for the chart
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 布尔值，用于禁用动画(默认启用)  
        /// boolean to disable animations (enabled by default)
        /// </summary>
        public bool Animations { get; set; } = true;

        /// <summary>
        /// 布尔值，以防止容器调整大小
        /// boolean to prevent the container from resizing
        /// </summary>
        public bool? Resizable { get; set; }

        /// <summary>
        /// 可选地为图表指定宽度
        /// Optionally specify a width for the chart
        /// </summary>
        public string? Width { get; set; }

        /// <summary>
        /// 可以选择指定图表的高度
        /// Optionally specify a height for the chart
        /// </summary>
        public string? Height { get; set; }

        ///// <summary>
        ///// 工具提示配置
        ///// tooltip configuration
        ///// </summary>
        //TooltipOptions Tooltip { get; set; }

        ///// <summary>
        ///// 传说配置
        ///// legend configuration
        ///// </summary>
        //LegendOptions Legend { get; set; }

        ///// <summary>
        ///// 工具栏配置
        ///// toolbar configurations
        ///// </summary>
        //ToolbarOptions Toolbar { get; set; }
    }
}
