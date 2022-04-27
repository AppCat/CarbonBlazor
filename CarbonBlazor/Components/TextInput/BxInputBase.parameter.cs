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
    /// input base parameter
    /// </summary>
    public partial class BxInputBase<TValue>
    {
        /// <summary>
        /// 子内容
        /// </summary>
        [Parameter]
        public RenderFragment<TValue>? ChildContent { get; set; }

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
        /// 快速响应
        /// </summary>
        [Parameter]
        public bool QuickResponse { get; set; }

        #region Event

        /// <summary>
        /// 加载事件
        /// </summary>
        [Parameter]
        public EventCallback<bool> LoadingChanged { get; set; }

        /// <summary>
        /// 变化事件
        /// </summary>
        [Parameter]
        public EventCallback<TValue> OnValueChange { get; set; }

        /// <summary>
        /// 按Enter键
        /// </summary>
        [Parameter]
        public EventCallback<KeyboardEventArgs> OnEnter { get; set; }

        /// <summary>
        /// 聚焦
        /// </summary>
        [Parameter]
        public EventCallback<FocusEventArgs> OnFocusin { get; set; }

        #endregion
    }
}
