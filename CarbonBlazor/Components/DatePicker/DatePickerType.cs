using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 日期选择器的类型
    /// The type of the date picker
    /// </summary>
    public enum DatePickerType
    {
        /// <summary>
        /// 没有下拉日历。
        /// Without calendar dropdown.
        /// </summary>
        [EnumClass("bx--date-picker--simple")]
        simple,
        /// <summary>
        /// 与日历下拉菜单和单一日期。
        /// With calendar dropdown and single date.
        /// </summary>
        [EnumClass("bx--date-picker--single")]
        single,
        /// <summary>
        /// 带有日历下拉框和日期范围。
        /// With calendar dropdown and a date range.
        /// </summary>
        [EnumClass("bx--date-picker--range")]
        range
    }
}
