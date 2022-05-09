using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// DatePicker 的参数部分
    /// DatePicker parameter partial
    /// </summary>
    public partial class BxDatePicker
    {
        /// <summary>
        /// 真要用轻版。
        /// true to use the light version.
        /// </summary>
        [Parameter]
        public bool Light { get; set; }

        /// <summary>
        /// 真要用短的版本。
        /// true to use the short version.
        /// </summary>
        [Parameter]
        public bool Short { get; set; }

        /// <summary>
        /// 日期选择器的类型。
        /// The type of the date picker
        /// </summary>
        [Parameter]
        public EnumMix<DatePickerType>? Type { get; set; }

        /// <summary>
        /// date-picker 配置
        /// The date-picker is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? PickerConfig { get; set; }
    }
}
