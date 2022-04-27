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
    /// 单选框
    /// RadioButton
    /// </summary>
    public partial class BxRadioButton : BxPropertieContentComponentBase<BxRadioButton>
    {
        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            if (Skeleton)
            {
                __builder.OpenElement(sequence++, "bx-radio-button-group-skeleton");
            }
            else
            {
                __builder.OpenElement(sequence++, "bx-radio-button-group");
                __builder.AddEvent<string>(ref sequence, "bx-radio-button-group-changed", this, e => Console.WriteLine(e));
            }
            __builder.AddComponent(ref sequence, this);
            __builder.AddContent(sequence++, ChildContent);

            __builder.CloseComponent();
        };
    }
}
