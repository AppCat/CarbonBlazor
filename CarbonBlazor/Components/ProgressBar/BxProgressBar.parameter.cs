using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// ProgressBar 的参数部分
    /// ProgressBar parameter partial
    /// </summary>
    public partial class BxProgressBar
    {
        /// <summary>
        /// 不确定
        /// A indeterminate the progress bar.
        /// </summary>
        [Parameter]
        public bool Indeterminate { get; set; }

        /// <summary>
        /// 描述进度条的标签。
        /// A label describing the progress bar.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// 描述进度条的标签模板。
        /// A label template describing the progress bar.
        /// </summary>
        [Parameter]
        public RenderFragment<int>? LabelTemplate { get; set; }

        /// <summary>
        /// 当前的进展作为文本表示。
        /// The current progress as a textual representation.
        /// </summary>
        [Parameter]
        public string? HelperText { get; set; }

        /// <summary>
        /// 将当前进度作为文本模板表示。  
        /// The current progress as a textual template representation.
        /// </summary>
        [Parameter]
        public RenderFragment<int>? HelperTextTemplate { get; set; }

        /// <summary>
        /// 指定ProgressBar的大小。
        /// Specify the size of the ProgressBar.
        /// </summary>
        [Parameter]
        public EnumMix<BxProgressBarSize>? Size { get; set; } = BxProgressBarSize.Big;

        /// <summary>
        /// 定义进度条的对齐变体。  
        /// Defines the alignment variant of the progress bar.
        /// </summary>
        [Parameter]
        public EnumMix<BxProgressBarType>? Type { get; set; } = BxProgressBarType.Default;

        /// <summary>.
        /// 最大值。
        /// The maximum value.
        /// </summary>
        [Parameter]
        public int Max { get; set; } = 100;

        /// <summary>
        /// 当前值。
        /// The current value.
        /// </summary>
        [Parameter]
        public int Value { get; set; }

        /// <summary>
        /// bar__label 配置
        /// The bar__label is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LabelConfig { get; set; }

        /// <summary>
        /// bar__helper-text 配置
        /// The bar__helper-text is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? HelperTextConfig { get; set; }

        /// <summary>
        /// bar__track 配置
        /// The bar__track is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TrackConfig { get; set; }

        /// <summary>
        /// bar__bar 配置
        /// The bar__bar is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? BarConfig { get; set; }
    }
}
