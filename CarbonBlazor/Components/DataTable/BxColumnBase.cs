using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 数据表列基础
    /// The underlying column of a table
    /// </summary>
    public abstract class BxColumnBase : BxContentComponentBase, IBxColumn
    {
        /// <summary>
        /// 渲染目标
        /// </summary>
        [CascadingParameter]
        public BxColumGoal Goal { get; set; }

        /// <summary>
        /// 数据表联级参数
        /// </summary>
        [CascadingParameter]
        public IBxTable? Table { get; set; }

        /// <summary>
        /// 列序号
        /// </summary>
        [Parameter]
        public int ColumnIndex { get; set; }

        /// <summary>+
        /// 标题
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// 标题模板
        /// </summary>
        [Parameter]
        public RenderFragment? TitleTemplate { get; set; }

        /// <summary>
        /// Th 配置
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ThConfig { get; set; }

        /// <summary>
        /// Td 配置
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TdConfig { get; set; }
    }
}
