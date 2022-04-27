using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 RadioButton 组件的参数部分.
    /// This is a parameter section for the radio component
    /// </summary>
    public partial class BxRadioButton
    {
        /// <summary>
        /// 对于骨架变化
        /// For the skeleton variation, utilize
        /// </summary>
        [Parameter]
        public bool Skeleton { get; set; }

        #region PROPERTIES

        /// <summary>
        /// 用于选择的<input>的name属性。
        /// The name attribute for the <input> for selection.
        /// </summary>
        [Parameter]
        [BxPropertie]
        public string? Name { get; set; }

        #endregion
    }
}
