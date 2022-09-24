using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Search 的参数部分
    /// Search parameter partial
    /// </summary>
    public partial class BxSearch
    {
        /// <summary>
        /// 为下面的 input 上的自动完成属性指定一个可选值，默认为"off"
        /// Specify an optional value for the autocomplete property on the underlying input, defaults to "off"
        /// </summary>
        [Parameter]
        public string AutoComplete { get; set; } = "off";

        /// <summary>
        /// 在“关闭”按钮上指定屏幕阅读器要读取的标签
        /// Specify a label to be read by screen readers on the "close" button
        /// </summary>
        [Parameter]
        public string CloseButtonLabelText { get; set; } = "Clear search input";

        /// <summary>
        /// 为下面的 input 指定角色，默认为搜索框
        /// Specify the role for the underlying input, defaults to searchbox
        /// </summary>
        [Parameter]
        public string Role { get; set; } = "searchbox";

        /// <summary>
        /// 指定搜索的大小
        /// Specify the size of the Search
        /// </summary>
        [Parameter]
        public EnumMix<BxSize> Size { get; set; } = BxSize.Md;

        /// <summary>
        /// 提示信息
        /// </summary>         
        [Parameter]
        public string? Placeholder { get; set; }

        /// <summary>
        /// 格式
        /// </summary>
        [Parameter]
        public string? Format { get; set; }

        /// <summary>
        /// 加载
        /// 一个图标输入字段可以显示它正在加载数据
        /// An icon input field can show that it is currently loading data
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 为Search图标提供标签文本
        /// Provide the label text for the Search icon
        /// </summary>
        [Parameter]
        public string? LabelText { get; set; }

        #region Event

        /// <summary>
        /// 清除搜索值时调用的可选回调。
        /// Optional callback called when the search value is cleared.
        /// </summary>
        [Parameter]
        public EventCallback<string> OnClear { get; set; }

        /// <summary>
        /// 变化事件
        /// </summary>
        [Parameter]
        public EventCallback OnExpand { get; set; }

        #endregion

        #region Config

        /// <summary>
        /// search-magnifier 配置
        /// The search-magnifier is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? MagnifierConfig { get; set; }

        /// <summary>
        /// search-label 配置
        /// The search-label is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LabelConfig { get; set; }

        /// <summary>
        /// search-input 配置
        /// The search-input is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? InputConfig { get; set; }

        /// <summary>
        /// search-close 配置
        /// The search-close is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? CloseConfig { get; set; }

        #endregion
    }
}
