using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Fieldset 的参数部分
    /// Fieldset parameter partial
    /// </summary>
    public partial class BxFieldset
    {
        /// <summary>
        /// 标签
        /// </summary>
        [Parameter]
        public string? LabelText { get; set; }

        /// <summary>
        /// label 配置
        /// label is config for the comboBox.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LabelConfig { get; set; }
    }
}
