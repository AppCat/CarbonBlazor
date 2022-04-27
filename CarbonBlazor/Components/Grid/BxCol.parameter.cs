using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Col 的参数部分
    /// Col parameter partial
    /// </summary>
    public partial class BxCol
    {
        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EnumMix<BxSmall>? Sm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EnumMix<BxMedium>? Md { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EnumMix<BxLarge>? Lg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EnumMix<BxXLarge>? Xlg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EnumMix<BxMax>? Max { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EnumMix<BxSmall>? OffsetSm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EnumMix<BxMedium>? OffsetMd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EnumMix<BxLarge>? OffsetLg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EnumMix<BxXLarge>? OffsetXlg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EnumMix<BxMax>? OffsetMax { get; set; }
    }
}
