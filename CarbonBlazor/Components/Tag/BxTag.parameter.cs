using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Tag 的参数部分
    /// Tag parameter partial
    /// </summary>
    public partial class BxTag
    {
        /// <summary>
        /// 筛选
        /// </summary>
        [Parameter]
        public bool Filter { get; set; }

        /// <summary>
        /// Specify the size of the Tag. Currently supports either sm or 'md' (default) sizes.
        /// </summary>
        [Parameter]
        public EnumMix<BxTagSize>? Size { get; set; } = BxTagSize.Sm;

        /// <summary>
        /// 类型
        /// </summary>
        [Parameter]
        public EnumMix<BxTagType>? Type { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// close-icon 配置
        /// The close-icon is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? CloseIconConfig { get; set; }

        /// <summary>
        /// tag__label 配置
        /// The tag__label is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LabelConfig { get; set; }

        /// <summary>
        /// 点击关闭事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnCloseClick { get; set; }
    }
}
