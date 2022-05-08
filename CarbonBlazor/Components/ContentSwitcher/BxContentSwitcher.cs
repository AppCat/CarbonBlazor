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
    /// 这是一个用于 ContentSwitcher 的 Blazor 组件。  
    /// This is a Blazor component for the ContentSwitcher.
    /// </summary>
    public partial class BxContentSwitcher : BxSelectComponentBase<BxSwitch, string>
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--content-switcher";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .GetIf(() => $"bx--content-switcher--{Size}", () => Size != null)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.UseElement(ref sequence, "div", this, @continue: __builder =>
            {
                __builder.AddAttribute(sequence++, "role", "tablist");
            }, ChildContent);
        };
    }
}
