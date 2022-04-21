using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 按钮种类
    /// Button kind.
    /// </summary>
    public enum BxButtonKind
    {
        /// <summary>
        /// Primary button
        /// </summary>
        [EnumClass("primary")]
        PRIMARY,
        /// <summary>
        /// Secondary button
        /// </summary>
        [EnumClass("secondary")]
        SECONDARY,
        /// <summary>
        /// Tertiary button
        /// </summary>
        [EnumClass("tertiary")]
        TERTIARY,
        /// <summary>
        /// Danger button
        /// </summary>
        [EnumClass("danger")]
        DANGER,
        /// <summary>
        /// Danger tertiary button
        /// </summary>
        [EnumClass("danger-tertiary")]
        DANGER_TERTIARY,
        /// <summary>
        /// Danger ghost button
        /// </summary>
        [EnumClass("danger-ghost")]
        DANGER_GHOST,
        /// <summary>
        /// Ghost button
        /// </summary>
        [EnumClass("ghost")]
        GHOST
    }
}
