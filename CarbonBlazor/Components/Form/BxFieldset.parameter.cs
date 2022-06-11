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
        /// 提供要在字段集中呈现的文本 
        /// Provide the text to be rendered inside of the fieldset
        /// </summary>
        [Parameter]
        public string? LegendText { get; set; }

        /// <summary>
        /// 中为消息提供文本 
        /// Provide the text for the message in the
        /// </summary>
        [Parameter]
        public string? MessageText { get; set; }

        /// <summary>
        /// 提供要在字段集中呈现的模板
        /// Provide the template for the message in the
        /// </summary>
        [Parameter]
        public RenderFragment? MessageTemplate { get; set; }

        /// <summary>
        /// label 配置
        /// label is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LegendConfig { get; set; }

        /// <summary>
        /// form__requirements 配置
        /// form__requirements is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? MessageConfig { get; set; }
    }
}
