using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 参数
    /// </summary>
    public partial class BxInuptComponentBase<TValue>
    {
        /// <summary>
        /// 光
        /// The light for the select.
        /// </summary>
        [Parameter]
        public bool Light { get; set; }

        /// <summary>
        /// 标签文本
        /// The label for the select.
        /// </summary>
        [Parameter]
        public string? LabelText { get; set; }

        /// <summary>
        /// 标签 模板。
        /// The label is template for the select.
        /// </summary>
        [Parameter]
        public RenderFragment? LabelTemplate { get; set; }

        /// <summary>
        /// 指定标签是否应该隐藏  
        /// Specify whether the label should be hidden, or not
        /// </summary>
        [Parameter]
        public bool HideLabel { get; set; }

        /// <summary>
        /// 标签 配置
        /// The label is config for the select.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LabelTextConfig { get; set; }
    }
}
