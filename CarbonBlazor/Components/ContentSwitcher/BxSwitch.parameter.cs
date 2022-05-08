using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Switch 的参数部分
    /// Switch parameter partial
    /// </summary>
    public partial class BxSwitch
    {
        /// <summary>
        /// switcher__label 配置
        /// The switcher__label is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LabelConfig { get; set; }
    }
}
