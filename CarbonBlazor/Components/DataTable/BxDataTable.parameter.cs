using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 数据表参数部分
    /// Data table parameter partial
    /// </summary>
    public partial class BxDataTable<TModel>
    {
        /// <summary>
        /// 单元格过滤器
        /// </summary>
        //[Parameter]
        //public Func<TModel, bool>? RowFilter { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        [Parameter]
        public IEnumerable<TModel>? DataSource { get; set; }        

        /// <summary>
        /// 隐藏表头
        /// </summary>
        [Parameter]
        public bool HideHeader { get; set; }

        /// <summary>
        /// 空模板
        /// </summary>
        [Parameter]
        public RenderFragment? EmptyTemplate { get; set; }

        /// <summary>
        /// 数据表尺寸
        /// The table size.
        /// </summary>
        [Parameter]
        public EnumMix<BxSize>? Size { get; set; }

        /// <summary>
        /// 加斑马条纹
        /// true to add zebra striping.
        /// </summary>
        [Parameter]
        public bool Zebra { get; set; }

        /// <summary>
        /// 如果为真，将使用'auto'宽度而不是100%
        /// false If true, will use a width of 'auto' instead of 100%
        /// </summary>
        [Parameter]
        public bool Static { get; set; }

        /// <summary>
        /// 指定标题是否应该是粘着的。仍处于实验阶段:可能不适用于每一种组合
        /// Specify whether the header should be sticky. Still experimental: may not work with every combination of table props
        /// </summary>
        [Parameter]
        public bool StickyHeader { get; set; }

        /// <summary>
        /// 指定表是否可以按其头进行排序
        /// Specify whether the table should be able to be sorted by its headers
        /// </summary>
        [Parameter]
        public bool IsSortable { get; set; }

        #region Event

        /// <summary>
        /// 选中变化事件
        /// </summary>
        [Parameter]
        public EventCallback<IEnumerable<TModel>> OnSelectedChange { get; set; }

        /// <summary>
        /// 打开行
        /// </summary>
        [Parameter]
        public EventCallback<TModel> OnOpenRow { get; set; }

        /// <summary>
        /// 关闭行
        /// </summary>
        [Parameter]
        public EventCallback<TModel> OnCloseRow { get; set; }

        #endregion

        #region Config

        /// <summary>
        /// Th 配置
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TbodyConfig { get; set; }

        /// <summary>
        /// Td 配置
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TheadConfig { get; set; }

        /// <summary>
        /// Td 配置
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TrConfig { get; set; }

        #endregion
    }
}
