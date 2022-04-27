using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于Checkbox组件的参数部分.
    /// This is a parameter section for the checkbox component
    /// </summary>
    public partial class BxCheckbox
    {
        /// <summary>
        /// 标签
        /// </summary>
        [Parameter]
        public string? LabelText { get; set; }

        /// <summary>
        /// 检查
        /// </summary>
        [Parameter]
        public bool Checked { get; set; }

        /// <summary>
        /// 变化事件
        /// </summary>
        [Parameter]
        public virtual EventCallback<bool> CheckedChanged { get; set; }

        /// <summary>
        /// 变化事件
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnCheckedChange { get; set; }

        /// <summary>
        /// Label 配置
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LabelConfig { get; set; }

        /// <summary>
        /// Input 配置
        /// </summary>
        [Parameter]
        public IBxComponentConfig? InputConfig { get; set; }
    }
}
