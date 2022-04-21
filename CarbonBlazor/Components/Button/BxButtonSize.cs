using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 按钮大小
    /// Button size.
    /// </summary>
    public enum BxButtonSize
    {
        /// <summary>
        /// 标准尺寸
        /// Regular size.
        /// </summary>
        [EnumClass("")]
        REGULAR,
        /// <summary>
        /// 小尺寸
        /// Small size.
        /// </summary>
        [EnumClass("sm")]
        SMALL,
        /// <summary>
        /// 超大号尺寸
        /// X-Large size.
        /// </summary>
        [EnumClass("xl")]
        EXTRA_LARGE,
        /// <summary>
        /// 表单字段的尺寸
        /// Size for form field.
        /// </summary>
        [EnumClass("field")]
        FIELD
    }
}
