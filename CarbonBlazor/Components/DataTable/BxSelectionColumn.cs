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
    public class BxSelectionColumn<TModel> : BxColumnBase
    {
        /// <summary>
        /// 模型
        /// </summary>
        [CascadingParameter]
        public ISelectionModel? Model { get; set; }

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
                __builder.AddEvent<bool>(ref sequence, nameof(BxCheckbox.ValueChanged), this, async check =>
                {
                    if (Table == null)
                        return;

                    if (check)
                    {
                        await Table.SelectedAllRowAsync();
                    }
                    else
                    {
                        await Table.DeselectAllRowAsync();
                    }
                });
                __builder.CloseComponent();
            }
            else if (Goal == BxColumGoal.Body)
            {
                __builder.OpenElement(sequence++, "td");
                __builder.AddConfig(ref sequence, new BxComponentConfig(TdConfig ?? this).AddClass($"bx--table-column-checkbox").AddId($"{Id}-td"));
                __builder.OpenComponent<BxCheckbox>(sequence++);
                __builder.AddAttribute(sequence++, nameof(BxCheckbox.Value), Model?.Selected ?? false);
                __builder.AddEvent<bool>(ref sequence, nameof(BxCheckbox.ValueChanged), this, async check =>
                {
                    if (Table == null)
                        return;

                    if (check)
                    {
                        await Table.SelectedRowAsync(Model);
                    }
                    else
                    {
                        await Table.DeselectRowAsync(Model);
                    }
                });
                __builder.CloseComponent();
            }

            __builder.CloseComponent();
        };
    }
}
