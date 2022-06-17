using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// TextArea 参数部分
    /// TextArea parameter partial
    /// </summary>
    public partial class BxTextArea
    {
        /// <summary>
        /// textarea 指定底层的cols属性
        /// Specify the cols attribute for the underlying
        /// </summary>
        [Parameter]
        public int? Cols { get; set; } = 50;

        /// <summary>
        /// textarea 行属性
        /// Specify the rows attribute for the textarea
        /// </summary>
        [Parameter]
        public int? Rows { get; set; } = 4;

        /// <summary>
        /// 指定是否显示字符计数器 
        /// Specify whether to display the character counter
        /// </summary>
        [Parameter]
        public bool EnableCounter { get; set; }

        /// <summary>
        /// 文本区域允许的最大字符数。 为了显示enableCounter，这是必需的 
        /// Max character count allowed for the textarea. This is needed in order for enableCounter to display
        /// </summary>
        [Parameter]
        public int? MaxCount { get; set; }

        /// <summary>
        /// text-area__label-wrapper 配置
        /// The text-area__label-wrapper is config for the select.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LabelWrapperConfig { get; set; }

        #region Hide

        /// <summary>
        /// 指定控件当前是否处于警告状态。
        /// Specify whether the control is currently in warning state
        /// </summary>
        new public bool Warn { get; set; }

        /// <summary>
        /// 提供控件处于警告状态时显示的文本
        /// Provide the text that is displayed when the control is in warning state.
        /// </summary>
        new public string? WarnText { get; set; }

        /// <summary>
        /// 告警信息 模板。
        /// The warn is template for the select.
        /// </summary>
        new public RenderFragment? WarnTemplate { get; set; }

        /// <summary>
        /// 指定选择输入的大小。
        /// Specify the size of the Select Input.
        /// </summary>
        new public EnumMix<BxSize>? Size { get; set; }

        /// <summary>
        /// 格式
        /// </summary>
        new public string? Format { get; set; }

        #endregion
    }
}
