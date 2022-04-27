using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// ComboBox 的参数部分
    /// ComboBox parameter partial
    /// </summary>
    public partial class BxComboBox
    {
        /// <summary>
        /// 展开
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnExpandedChange { get; set; }

        /// <summary>
        /// 指定组合框下拉的方向。 可以是顶部也可以是底部。  
        /// Specify the direction of the combobox dropdown. Can be either top or bottom.
        /// </summary>
        [Parameter]
        public EnumMix<BxComboBoxDirection>? Direction { get; set; }

        /// <summary>
        /// combo-box 配置
        /// The combo-box is config for the comboBox.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ComboBoxConfig { get; set; }

        /// <summary>
        /// list-box 配置
        /// The list-box is config for the comboBox.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ListBoxConfig { get; set; }

        /// <summary>
        /// menu-icon 配置
        /// The menu-icon is config for the comboBox.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? MenuIconConfig { get; set; }

        /// <summary>
        /// box__selection 配置
        /// The box__selection is config for the comboBox.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? SelectionConfig { get; set; }
    }
}
