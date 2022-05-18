using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Popover 的参数部分
    /// Popover parameter partial
    /// </summary>
    public partial class BxPopover
    {
        /// <summary>
        /// 指定是否应该呈现插入符号
        /// Specify whether a caret should be rendered.
        /// </summary>
        [Parameter]
        public bool Caret { get; set; } = true; 

        /// <summary>
        /// 指定是否应该在弹出窗口上呈现投影
        /// Specify whether a drop shadow should be rendered on the popover.
        /// </summary>
        [Parameter]
        public bool DropShadow { get; set; } = true;

        /// <summary>
        /// 使用高对比度变体渲染组件
        /// Render the component using the high-contrast variant.
        /// </summary>
        [Parameter]
        public bool HighContrast { get; set; }

        /// <summary>
        /// 指定组件当前是打开的还是关闭的
        /// Specify whether the component is currently open or closed.
        /// </summary>
        [Parameter]
        public bool IsOpen { get; set; }

        /// <summary>
        /// 指定弹窗如何与触发器元素对齐
        /// Specify how the popover should align with the trigger element.
        /// </summary>
        [Parameter]
        public EnumMix<BxPopoverAlign>? Align { get; set; } = BxPopoverAlign.Bottom;

        /// <summary>
        /// 弹出窗口的内容模板。
        /// A content template the popover.
        /// </summary>
        [Parameter]
        public RenderFragment? ContentTemplate { get; set; }

        /// <summary>
        /// 标题弹出窗口。
        /// title the popover.
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// 弹出窗口的详细信息。。
        /// details the popover.
        /// </summary>
        [Parameter]
        public string? Details { get; set; }

        /// <summary>
        /// popover 配置
        /// The popover is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? PopoverConfig { get; set; }

        /// <summary>
        /// content 配置
        /// The content is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ContentConfig { get; set; }

        /// <summary>
        /// title 配置
        /// The popover-title is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TitleConfig { get; set; }

        /// <summary>
        /// details 配置
        /// The popover-details is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? DetailsConfig { get; set; }
    }
}
