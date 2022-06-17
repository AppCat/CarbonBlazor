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
    public partial class BxFormItemComponentBaseOf<TValue>
    {
        /// <summary>
        /// 提供与控件标签一起使用的文本以获得额外帮助
        /// Provide text that is used alongside the control label for additional help.
        /// </summary>
        [Parameter]
        public string? HelperText { get; set; }

        /// <summary>
        /// 帮助信息 模板。
        /// The helper is template for the item.
        /// </summary>
        [Parameter]
        public RenderFragment? HelperTemplate { get; set; }

        /// <summary>
        /// 指定当前值是否无效。
        /// Specify if the currently value is invalid.
        /// </summary>
        [Parameter]
        public bool Invalid { get; set; }

        /// <summary>
        /// 提供控件处于无效状态时显示的文本 
        /// Provide the text that is displayed when the control is in an invalid state.
        /// </summary>
        [Parameter]
        public string? InvalidText { get; set; }

        /// <summary>
        /// 无效信息 模板。
        /// The invalid is template for the select.
        /// </summary>
        [Parameter]
        public RenderFragment? InvalidTemplate { get; set; }

        /// <summary>
        /// 指定控件当前是否处于警告状态。
        /// Specify whether the control is currently in warning state
        /// </summary>
        [Parameter]
        public bool Warn { get; set; }

        /// <summary>
        /// 提供控件处于警告状态时显示的文本
        /// Provide the text that is displayed when the control is in warning state.
        /// </summary>
        [Parameter]
        public string? WarnText { get; set; }

        /// <summary>
        /// 告警信息 模板。
        /// The warn is template for the select.
        /// </summary>
        [Parameter]
        public RenderFragment? WarnTemplate { get; set; }

        /// <summary>
        /// 指定选择输入的大小。
        /// Specify the size of the Select Input.
        /// </summary>
        [Parameter]
        public EnumMix<BxSize>? Size { get; set; }

        #region Config

        /// <summary>
        /// 需求信息 配置
        /// The requirement is config for the select.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? RequirementConfig { get; set; }

        /// <summary>
        /// 帮助信息 配置
        /// The helper is config for the select.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? HelperConfig { get; set; }

        /// <summary>
        /// input 配置
        /// The input is config for the select.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? InputConfig { get; set; }

        /// <summary>
        /// input__field-wrapper 配置
        /// The input__wrapper is config for the select.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? InputWrapperConfig { get; set; }

        #endregion
    }
}
