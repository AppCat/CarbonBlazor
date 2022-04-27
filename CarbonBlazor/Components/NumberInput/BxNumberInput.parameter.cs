using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// NumberInput 的参数部分
    /// NumberInput parameter partial
    /// </summary>
    public partial class BxNumberInput<TValue>
    {
        /// <summary>
        /// 最大值。
        /// The maximum value.
        /// </summary>
        [Parameter]
        public TValue? Max { get; set; }

        /// <summary>
        /// 最小值。
        /// The minimum value.
        /// </summary>
        [Parameter]
        public TValue? Min { get; set; }

        /// <summary>
        /// 指定在点击上/下按钮时数值应该增加/减少多少。
        /// Specify how much the values should increase/decrease upon clicking on up/down button
        /// </summary>
        [Parameter]
        public TValue? Step { get; set; }

        /// <summary>
        /// The title of the increment
        /// </summary>
        public string? IncrementTitle { get; set; } = "Increment number";

        /// <summary>
        /// The title of the decrement
        /// </summary>
        public string? DecrementTitle { get; set; } = "Decrement number";

        #region Config

        /// <summary>
        /// number 配置
        /// The number is config for the select.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? NumberConfig { get; set; }

        /// <summary>
        /// number__controls 配置
        /// The number__controls is config for the select.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ControlsConfig { get; set; }

        /// <summary>
        /// number__control-btn 配置
        /// The number__control-btn is config for the select.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ControlBtnConfig { get; set; }

        #endregion

    }
}
