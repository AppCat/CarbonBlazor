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
    /// 这是一个用于 SelectionColumn 的 Blazor 组件。  
    /// This is a Blazor component for the SelectionColumn.
    /// </summary>
    public class BxSelectionColumn : BxColumnBase
    {
        /// <summary>
        /// 行Id哈希
        /// </summary>
        [CascadingParameter(Name = "RowIdHash")]
        public int? RowIdHash { get; set; }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            if (Goal == BxColumGoal.Header)
            {
                __builder.OpenElement(sequence++, "th");
                __builder.AddAttribute(sequence++, "scope", "col");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ThConfig).AddClass($"bx--table-column-checkbox").AddId($"{Id}-th"));
                __builder.OpenComponent<BxCheckbox>(sequence++);
                __builder.AddAttribute(sequence++, nameof(BxCheckbox.Value), Table?.IsSelectedAll() ?? false);
                __builder.AddEvent<bool>(ref sequence, nameof(BxCheckbox.ValueChanged), this, check =>
                {
                    if (check)
                    {
                        Table?.SelectedAll();
                    }
                    else
                    {
                        Table?.DeselectAll();
                    }
                });
                __builder.CloseComponent();
            }
            else if (Goal == BxColumGoal.Body)
            {
                var rowIdHash = RowIdHash;
                __builder.OpenElement(sequence++, "td");
                __builder.AddConfig(ref sequence, new BxComponentConfig(TdConfig ?? this).AddClass($"bx--table-column-checkbox").AddId($"{Id}-td"));
                __builder.OpenComponent<BxCheckbox>(sequence++);
                __builder.AddAttribute(sequence++, nameof(BxCheckbox.Value), Table?.IsSelected(rowIdHash) ?? false);
                __builder.AddEvent<bool>(ref sequence, nameof(BxCheckbox.ValueChanged), this, check =>
                {
                    if (check)
                    {
                        Table?.SelectedColumn(rowIdHash);
                    }
                    else
                    {
                        Table?.DeselectColumn(rowIdHash);
                    }
                });
                __builder.CloseComponent();
            }

            __builder.CloseComponent();
        };
    }
}
