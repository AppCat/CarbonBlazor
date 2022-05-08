using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 指定弹窗如何与触发器元素对齐  
    /// Specify how the popover should align with the trigger element
    /// </summary>
    public enum BxPopoverAlign
    {
        /// <summary>
        /// 顶部
        /// </summary>
        [EnumClass("bx--popover--top")]
        Top,
        /// <summary>
        /// 上左
        /// </summary>
        [EnumClass("bx--popover--top-left")]
        TopLeft,
        /// <summary>
        /// 上右
        /// </summary>
        [EnumClass("bx--popover--top-right")]
        TopRight,
        /// <summary>
        /// 底部
        /// </summary>
        [EnumClass("bx--popover--bottom")]
        Bottom,
        /// <summary>
        /// 下左
        /// </summary>
        [EnumClass("bx--popover--bottom-left")]
        BottomLeft,
        /// <summary>
        /// 下右
        /// </summary>
        [EnumClass("bx--popover--bottom-right")]
        BottomRight,
        /// <summary>
        /// 左
        /// </summary>
        [EnumClass("bx--popover--left")]
        Left,
        /// <summary>
        /// 左下
        /// </summary>
        [EnumClass("bx--popover--left-bottom")]
        LeftBottom,
        /// <summary>
        /// 左上
        /// </summary>
        [EnumClass("bx--popover--left-top")]
        LeftTop,
        /// <summary>
        /// 右
        /// </summary>
        [EnumClass("bx--popover--right")]
        Right,
        /// <summary>
        /// 右下
        /// </summary>
        [EnumClass("bx--popover--right-bottom")]
        RightBottom,
        /// <summary>
        /// 右上
        /// </summary>
        [EnumClass("bx--popover--right-top")]
        RightTop,
    }
}
