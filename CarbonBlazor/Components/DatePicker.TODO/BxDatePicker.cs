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
    /// 这是一个用于 DatePicker 的 Blazor 组件。  
    /// This is a Blazor component for the DatePicker.
    /// </summary>
    public partial class BxDatePicker : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--date-picker";

            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--date-picker--light", () => Light)
                .If("bx--date-picker--short", () => Short)
                .AddEnum(Type)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddConfig(ref sequence, new BxComponentConfig("bx--form-item", $"{Id}-form-item"));

            __builder.UseElement(ref sequence, "div", this, __builder =>
            {
                __builder.AddContent(sequence++, ChildContent);
            });

            __builder.CloseElement();
        };
    }
}
