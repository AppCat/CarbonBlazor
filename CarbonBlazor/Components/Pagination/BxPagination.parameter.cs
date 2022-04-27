using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 分页的参数部分
    /// pagination parameter partial
    /// </summary>
    public partial class BxPagination
    {
        /// <summary>
        /// 该函数返回一个可翻译的文本，以项目范围的方式显示当前页面的位置。
        /// The function returning a translatable text showing where the current page is, in a manner of the range of items.
        /// (min, max, total)
        /// </summary>
        [Parameter]
        public Func<int, int, int, string>? ItemRangeText { get; set; }

        /// <summary>
        /// itemRangeText的变体，用于项目总数未知的情况。 
        /// A variant of itemRangeText, used if the total number of items is unknown. 
        /// (min, max)
        /// </summary>
        [Parameter]
        public Func<int, int, string>? ItemText { get; set; }

        /// <summary>
        /// 表示每页条目数的可翻译文本。  
        /// The translatable text indicating the number of items per page.
        /// </summary>
        [Parameter]
        public string? ItemsPerPageText { get; set; }

        /// <summary>
        /// 当前页面。
        /// The current page.
        /// </summary>
        [Parameter]
        public int Page { get; set; } = 1;

        /// <summary>
        /// 如果更改页面的选择框应禁用，则为True。
        /// true if the select box to change the page should be disabled.
        /// </summary>
        [Parameter]
        public bool PageInputDisabled { get; set; }

        /// <summary>
        /// 返回显示当前页面位置的PII的函数。  
        /// A function returning PII showing where the current page is.
        /// (page, max)
        /// </summary>
        [Parameter]
        public Func<int, int, string>? PageRangeText { get; set; }

        /// <summary>
        /// 显示当前页面的可翻译文本。  
        /// The translatable text showing the current page.
        /// (page, max)
        /// </summary>
        [Parameter]
        public Func<int, string>? PageText { get; set; }

        /// <summary>
        /// 规定一页包含多少项的数字。
        /// The number dictating how many items a page contains.
        /// </summary>
        [Parameter]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 如果更改每页项目的选择框被禁用，则为True。  
        /// true if the select box to change the items per page should be disabled.
        /// </summary>
        [Parameter]
        public bool PageSizeInputDisabled { get; set; }

        /// <summary>
        /// 如果项目总数未知，则为True。  
        /// true if the total number of items is unknown.
        /// </summary>
        [Parameter]
        public bool PagesUnknown { get; set; }

        /// <summary>
        /// 指定分页的大小。
        /// Specify the size of the Pagination.
        /// </summary>
        [Parameter]
        public EnumMix<BxSize>? Size { get; set; }

        /// <summary>
        /// 项目的总数。
        /// The total number of items.
        /// </summary>
        [Parameter]
        public int? TotalItems { get; set; } = 1;

        /// <summary>
        /// 页面大小的选择。
        /// </summary>
        [Parameter]
        public int[]? PageSizes { get; set; }

        #region Event

        /// <summary>
        /// 绑定 PageSize
        /// bind PageSize
        /// </summary>
        [Parameter]
        public EventCallback<int> PageSizeChanged { get; set; }

        /// <summary>
        /// 绑定 Page
        /// bind Page
        /// </summary>
        [Parameter]
        public EventCallback<int> PageChanged { get; set; }

        /// <summary>
        /// 页码变化事件
        /// </summary>
        [Parameter]
        public EventCallback<BxPaginationEventArgs> OnPageChange { get; set; }

        #endregion

        #region Config

        /// <summary>
        /// 配置
        /// The pagination__left is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? PaginationLeftConfig { get; set; }

        /// <summary>
        /// 配置
        /// The pagination__right is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? PaginationPightConfig { get; set; }

        /// <summary>
        /// 配置
        /// The pagination__text is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? PaginationTextConfig { get; set; }

        /// <summary>
        /// control-buttons 配置
        /// The control-buttons is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ControlButtonsConfig { get; set; }

        /// <summary>
        /// button--backward 配置
        /// The button--backward is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ButtonBackwardConfig { get; set; }

        /// <summary>
        /// button--forward 配置
        /// The button--forward is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ButtonForwardConfig { get; set; }
        #endregion
    }
}
