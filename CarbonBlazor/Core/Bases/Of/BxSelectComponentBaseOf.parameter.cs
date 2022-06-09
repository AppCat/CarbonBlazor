using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 参数部分
    /// </summary>
    public partial class BxSelectComponentBaseOf<TOption, TKey>
    {
        /// <summary>
        /// 默认选中 key
        /// </summary>
        [Parameter]
        public TKey? DefaultSelectedKey { get; set; }

        /// <summary>
        /// 选中的 Key
        /// </summary>
        [Parameter]
        public TKey? SelectedKey { get; set; }

        /// <summary>
        /// 选中的 Key 用于多选
        /// </summary>
        [Parameter]
        public TKey[]? SelectedKeys { get; set; }
        
        /// <summary>
        /// 过滤
        /// </summary>
        [Parameter]
        public Func<TOption?, bool>? Filtered { get; set; }

        /// <summary>
        /// 子内容
        /// </summary>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        /// <summary>
        /// 最大多选
        /// </summary>
        public virtual int? MaxMultiple { get; set; }

        /// <summary>
        /// 多选
        /// allow multiple selections
        /// </summary>
        public virtual bool Multiple { get; set; }

        #region Event

        /// <summary>
        /// 选中的标签页键变化
        /// Gets or sets an changed that identifies the bound value.
        /// </summary>
        [Parameter]
        public EventCallback<TKey[]> SelectedKeysChanged { get; set; }

        /// <summary>
        /// Gets or sets an expression that identifies the bound value.
        /// </summary>
        [Parameter]
        public Expression<Func<TKey[]>>? SelectedKeysExpression { get; set; }

        /// <summary>
        /// 选中的标签页键变化
        /// </summary>
        [Parameter]
        public EventCallback<TKey[]> OnSelectedKeysChange { get; set; }

        /// <summary>
        /// 选中的标签页键变化
        /// Gets or sets an changed that identifies the bound value.
        /// </summary>
        [Parameter]
        public EventCallback<TKey> SelectedKeyChanged { get; set; }

        /// <summary>
        /// Gets or sets an expression that identifies the bound value.
        /// </summary>
        [Parameter]
        public Expression<Func<TKey>>? SelectedKeyExpression { get; set; }

        /// <summary>
        /// 选中的标签页键变化
        /// </summary>
        [Parameter]
        public EventCallback<TKey> OnSelectedKeyChange { get; set; }

        /// <summary>
        /// 聚焦的选项
        /// </summary>
        [Parameter]
        public EventCallback<TOption> OnFocusOption { get; set; }

        /// <summary>
        /// 选中的选项
        /// </summary>
        [Parameter]
        public EventCallback<TOption> OnSelectedOption { get; set; }

        /// <summary>
        /// 点击的选项
        /// </summary>
        [Parameter]
        public EventCallback<TOption> OnClickOption { get; set; }

        #endregion
    }
}
