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
    /// SideNav 的参数部分
    /// Tag parameter partial
    /// </summary>
    public partial class BxSideNav
    {
        /// <summary>
        /// 指定是否添加聚焦和模糊侦听器。它们是默认的。
        /// Specify whether focus and blur listeners are added. They are by default.
        /// </summary>
        public bool AddFocusListeners { get; set; } = true;

        /// <summary>
        /// 指定是否添加鼠标进入/退出侦听器。它们是默认的。
        /// Specify whether mouse entry/exit listeners are added. They are by default.
        /// </summary>
        public bool AddMouseListeners { get; set; } = true;

        /// <summary>
        /// 如果为真，SideNav将被扩充，否则将被瓦解。使用这个道具会使SideNav成为一个受控组件。
        /// If true, the SideNav will be expanded, otherwise it will be collapsed. Using this prop causes SideNav to become a controled component.
        /// </summary>
        [Parameter]
        public bool Expanded { get; set; }

        /// <summary>
        /// 可选地提供一个自定义类来应用于底层 li 节点
        /// Optionally provide a custom class to apply to the underlying li node
        /// </summary>
        [Parameter]
        public bool IsChildOfHeader { get; set; }

        /// <summary>
        /// 指定sideNav是否是独立的
        /// Specify if sideNav is standalone
        /// </summary>
        [Parameter]
        public bool IsFixedNav { get; set; }

        /// <summary>
        /// 指定sideNav是否在lg断点之上持久存在
        /// Specify if the sideNav will be persistent above the lg breakpoint
        /// </summary>
        [Parameter]
        public bool IsPersistent { get; set; }

        /// <summary>
        /// 可选道具显示侧导航轨道。
        /// Optional prop to display the side nav rail.
        /// </summary>
        [Parameter]
        public bool IsRail { get; set; }
    }
}
