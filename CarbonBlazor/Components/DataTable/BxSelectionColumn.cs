using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 选择列
    /// </summary>
    public class BxSelectionColumn : BxColumnBase
    {
        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            var withSelection = false;

            if (CascadingDataTableParameters != null)
            {
                withSelection = CascadingDataTableParameters.WithSelection;
            }

            if (FragmentGoal == BxColumFragmentGoal.Header)
            {
                __builder.OpenElement(sequence++, "th");
                __builder.AddAttribute(sequence++, "scope", "col");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ThConfig).AddClass("bx--table-column-checkbox").AddId($"{Id}-th"));
                __builder.OpenComponent<BxCheckbox>(sequence++);
                __builder.CloseComponent();
            }
            else if (FragmentGoal == BxColumFragmentGoal.Body)
            {
                __builder.OpenElement(sequence++, "td");
                __builder.AddComponent(ref sequence, this);
                __builder.AddConfig(ref sequence, new BxComponentConfig(TdConfig).AddClass("bx--table-column-checkbox").AddId($"{Id}-td"));
                __builder.OpenComponent<BxCheckbox>(sequence++);
                __builder.CloseComponent();
            }

            __builder.CloseComponent();
        };

        /// <summary>
        /// 模型哈希
        /// </summary>
        internal string? ModelHas { get; set; }
    }
}
