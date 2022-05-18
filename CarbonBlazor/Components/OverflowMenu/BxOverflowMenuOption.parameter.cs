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
    /// OverflowMenuOption 的参数部分
    /// OverflowMenuOption parameter partial
    /// </summary>
    public partial class BxOverflowMenuOption
    {
        /// <summary>
        /// 菜单项中的文本.
        /// The text in the menu item.
        /// </summary>
        [Parameter]
        public string? Text { get; set; }

        /// <summary>
        /// 菜单项中的文本模板.
        /// The text of template in the menu item.
        /// </summary>
        [Parameter]
        public RenderFragment? TextTemplate { get; set; }

        /// <summary>
        /// 使该菜单项成为分隔符。
        /// true to make this menu item a divider.
        /// </summary>
        [Parameter]
        public bool HasDivider { get; set; }

        /// <summary>
        /// True使该菜单项成为“危险按钮”。  
        /// true to make this menu item a "danger button".
        /// </summary>
        [Parameter]
        public bool IsDelete { get; set; }

        #region Config

        /// <summary>
        /// overflow-menu-options__btn 配置
        /// The overflow-menu-options__btn is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ButtonConfig { get; set; }

        /// <summary>
        /// overflow-menu-options__option-content 配置
        /// The overflow-menu-options__option-content is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ContentConfig { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// click 事件的事件处理程序。
        /// The event handler for the click event.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// focus 事件的事件处理程序。
        /// The event handler for the focus event.
        [Parameter]
        public EventCallback<FocusEventArgs> OnFocus { get; set; }

        /// <summary>
        /// blur 事件的事件处理程序。
        /// The event handler for the blur event.
        [Parameter]
        public EventCallback<FocusEventArgs> OnBlur { get; set; }

        ///// <summary>
        ///// keydown 事件的事件处理程序。
        ///// The event handler for the keydown event.
        //[Parameter]
        //public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }

        ///// <summary>
        ///// keyup 事件的事件处理程序。
        ///// The event handler for the keyup event.
        //[Parameter]
        //public EventCallback<KeyboardEventArgs> OnKeyUp { get; set; }

        /// <summary>
        /// onmousedown 事件的事件处理程序。
        /// The event handler for the onmousedown event.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        /// <summary>
        /// onmouseup 事件的事件处理程序。
        /// The event handler for the onmouseup event.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseUp { get; set; }

        #endregion
    }
}
