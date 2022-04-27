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
        Primary,
        /// <summary>
        /// Secondary button
        /// </summary>
        Secondary,
        /// <summary>
        /// Tertiary button
        /// </summary>
        Tertiary,
        /// <summary>
        /// Danger button
        /// </summary>
        Danger,
        /// <summary>
        /// Danger tertiary button
        /// </summary>
        [EnumClass("danger-tertiary")]
        DangerTertiary,
        /// <summary>
        /// Danger ghost button
        /// </summary>
        [EnumClass("danger-ghost")]
        DangerGhost,
        /// <summary>
        /// Ghost button
        /// </summary>
        Ghost
    }
}
