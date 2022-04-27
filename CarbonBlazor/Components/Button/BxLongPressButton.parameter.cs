using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// LongPressButton 的参数部分
    /// LongPressButton parameter partial
    /// </summary>
    public partial class BxLongPressButton
    {
        /// <summary>
        /// 按下停止传播
        /// </summary>
        [Parameter]
        public bool OnMousedownStopPropagation { get; set; } = true;

        /// <summary>
        /// 点击松开传播
        /// </summary>
        [Parameter]
        public bool OnMouseupStopPropagation { get; set; } = true;

        /// <summary>
        /// 停止点击
        /// </summary>
        [Parameter]
        public bool OnClickStop { get; set; } = true;

        /// <summary>
        /// 延时
        /// 默认500
        /// </summary>
        [Parameter]
        public int Delay { get; set; } = 500;

        /// <summary>
        /// 延时
        /// </summary>
        [Parameter]
        public TimeSpan? DelayTimeSpan { get; set; }
    }
}
