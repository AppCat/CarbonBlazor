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
    /// OverflowMenu 的参数部分
    /// OverflowMenu parameter partial
    /// </summary>
    public partial class BxOverflowMenu
    {
        /// <summary>
        /// 指定OverflowMenu的大小。
        /// Specify the size of the OverflowMenu.
        /// </summary>
        [Parameter]
        public EnumMix<BxSize>? Size { get; set; }

        /// <summary>
        /// 菜单的方向。
        /// The menu direction.
        /// </summary>
        [Parameter]
        public EnumMix<BxOverflowMenuDirection>? Direction { get; set; } = BxOverflowMenuDirection.Bottom;

        /// <summary>
        /// 如果菜单对齐应该翻转，则为True。
        /// true if the menu alignment should be flipped.
        /// </summary>
        [Parameter]
        public bool Flipped { get; set; }

        /// <summary>
        /// 轻版
        /// true to use the light version.
        /// </summary>
        [Parameter]
        public bool Light { get; set; }

        /// <summary>
        /// overflow-menu-options 配置
        /// The overflow-menu-options is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? OptionsConfig { get; set; }

        /// <summary>
        /// 是否打开
        /// </summary>
        [Parameter]
        public bool Open { get; set; }

        #region Event

        /// <summary>
        /// 打开变化用于
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnOpenChange { get; set; }

        /// <summary>
        /// 打开变化用于 bind
        /// </summary>
        [Parameter]
        public EventCallback<bool> OpenChanged { get; set; }

        /// <summary>
        /// 单击事件的事件处理程序。
        /// The event handler for the click event.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// 焦点事件的事件处理程序。
        /// The event handler for the focus event.
        /// </summary>
        [Parameter]
        public EventCallback<FocusEventArgs> OnFocus { get; set; }

        /// <summary>
        /// keydown事件的事件处理程序。
        /// The event handler for the keydown event.
        /// </summary>
        [Parameter]
        public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }

        /// <summary>
        /// 函数在菜单关闭时调用
        /// Function called when menu is closed
        /// </summary>
        [Parameter]
        public EventCallback OnClose { get; set; }

        /// <summary>
        /// 当菜单打开时调用的函数
        /// Function called when menu is opened
        /// </summary>
        [Parameter]
        public EventCallback OnOpen { get; set; }

        #endregion
    }
}
