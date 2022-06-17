using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 参数部分
    /// </summary>
    public abstract partial class BxListBoxComponentBaseOf<TOption, TKey>
    {
        /// <summary>
        /// 展开
        /// </summary>
        [Parameter]
        public bool Expanded { get; set; }

        /// <summary>
        /// box__menu 配置
        /// The box__menu is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? BoxMenuConfig { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        [Parameter]
        public string? Placeholder { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        [Parameter]
        public EnumMix<BxListBoxDirection>? Direction { get; set; }

        #region Event

        /// <summary>
        /// 展开变化用于 bind
        /// </summary>
        [Parameter]
        public EventCallback<bool> ExpandedChanged { get; set; }

        /// <summary>
        /// 展开变化
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnExpandedChanged { get; set; }

        /// <summary>
        /// 显示 菜单
        /// </summary>
        [Parameter]
        public EventCallback OnShowBoxMenu { get; set; }

        /// <summary>
        /// 隐藏 菜单
        /// </summary>
        [Parameter]
        public EventCallback OnHideBoxMenu { get; set; }

        #endregion
    }
}
