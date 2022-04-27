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
    /// 这是一个用于 ActionColumn 的 Blazor 组件。  
    /// This is a Blazor component for the ActionColumn.
    /// </summary>
    public partial class BxActionColumn : BxColumnBase
    {
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
                __builder.AddConfig(ref sequence, new BxComponentConfig(ThConfig).AddId($"{Id}-th"));
                __builder.OpenElement(sequence++, "span");
                __builder.AddAttribute(sequence++, "class", $"bx--table-header-label");
                __builder.EitherOrAddContent(ref sequence, TitleTemplate, (Title ?? string.Empty), () => TitleTemplate != null);
                __builder.CloseComponent();
            }
            else if (Goal == BxColumGoal.Body)
            {
                __builder.OpenElement(sequence++, "td");
                __builder.AddConfig(ref sequence, new BxComponentConfig(TdConfig ?? this).AddId($"{Id}-td"));

                __builder.AddContent(sequence++, ChildContent);
            }

            __builder.CloseComponent();
        };
    }
}
