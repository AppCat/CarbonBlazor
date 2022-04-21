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
    /// 操作列
    /// Columns of a table used for action
    /// </summary>
    public partial class BxActionColumn : BxColumnBase
    {
        #region RenderFragment

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
                __builder.AddConfig(ref sequence, new BxComponentConfig(ThConfig).AddId($"{Id}-th"));
                __builder.EitherOrAddContent(ref sequence, TitleTemplate, (Title ?? string.Empty), () => TitleTemplate != null);
            }
            else if (FragmentGoal == BxColumFragmentGoal.Body)
            {
                __builder.OpenElement(sequence++, "td");
                __builder.AddComponent(ref sequence, this);
                __builder.AddConfig(ref sequence, new BxComponentConfig(TdConfig).AddId($"{Id}-td"));

                __builder.AddContent(sequence++, ChildContent);
            }

            __builder.CloseComponent();
        };

        #endregion
    }
}
