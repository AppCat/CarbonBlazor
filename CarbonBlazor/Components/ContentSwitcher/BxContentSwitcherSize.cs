using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Specify the size of the Content Switcher. Currently supports either sm, 'md' (default) or 'lgas an option. TODO V11: removexl` (replaced with lg)
    /// </summary>
    public enum BxContentSwitcherSize
    {
        /// <summary>
        /// Sm
        /// </summary>
        [EnumClass("bx--content-switcher--sm")]
        Sm,
        /// <summary>
        /// Md
        /// </summary>
        [EnumClass("bx--content-switcher--md")]
        Md,
        /// <summary>
        /// Lg
        /// </summary>
        [EnumClass("bx--content-switcher--lg")]
        Lg,
        /// <summary>
        /// Xl
        /// </summary>
        [EnumClass("bx--content-switcher--xl")]
        Xl
    }
}
