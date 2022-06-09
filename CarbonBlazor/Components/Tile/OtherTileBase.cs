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
    /// 用于其他 Tile 组件的基础
    /// The basis for other Tile components
    /// </summary>
    public abstract class OtherTileBase : BxContentComponentBase
    {
        /// <summary>
        /// 指定在单击ClickableTile时运行的函数
        /// Specify the function to run when the ClickableTile is clicked
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// 指定当ClickableTile通过键盘进行交互时运行的函数。
        /// Specify the function to run when the ClickableTile is interacted with via a keyboard
        /// </summary>
        [Parameter]
        public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickAsync(MouseEventArgs args)
        {
            await OnClick.InvokeAsync(args);
        }

        /// <summary>
        /// 处理 OnKeyDown
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnKeyDownAsync(KeyboardEventArgs args)
        {
            await OnKeyDown.InvokeAsync(args);
        }
    }
}
