using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 标签类型
    /// </summary>
    public enum BxTagType
    {
        /// <summary>
        /// 红色
        /// </summary>
        Red,
        /// <summary>
        /// 洋红色
        /// </summary>
        Magenta,
        /// <summary>
        /// 紫色的
        /// </summary>
        Purple,
        /// <summary>
        /// 蓝色的
        /// </summary>
        Blue,
        /// <summary>
        /// 青色
        /// </summary>
        Cyan,
        /// <summary>
        /// 水鸭色
        /// </summary>
        Teal,
        /// <summary>
        /// 绿色
        /// </summary>
        Green,
        /// <summary>
        /// 灰色的
        /// </summary>
        Gray,
        /// <summary>
        /// 灰色
        /// </summary>
        [EnumClass("cool-gray")]
        CoolGray,
        /// <summary>
        /// 温暖的灰色
        /// </summary>
        [EnumClass("warm-gray")]
        WarmGray,
        /// <summary>
        /// 高对比
        /// </summary>
        [EnumClass("high-contrast")]
        HighContrast,
        /// <summary>
        /// 轮廓
        /// </summary>
        Outline
    }
}
