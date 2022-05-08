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
    /// 这是一个用于 Tag 的 Blazor 组件。  
    /// This is a Blazor component for the Tag.
    /// </summary>
    public partial class BxTag : BxComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--tag";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--tag--disabled", () => Disabled)
                .If("bx--tag--filter", () => Filter)
                .AddEnum(Size)
                .GetIf(() => $"bx--tag--{Type}", () => Type != null)
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
            __builder.AddComponent(ref sequence, this);
            {
                if (!string.IsNullOrEmpty(Title))
                {
                    __builder.OpenElement(sequence++, "span");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(LabelConfig, "bx--tag__label", $"{Id}-label"));
                    __builder.AddAttribute(sequence++, "title", Title);

                    __builder.AddContent(sequence++, Title);

                    __builder.CloseElement();
                }

                if (Filter)
                {
                    __builder.OpenElement(sequence++, "button");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(CloseIconConfig, "bx--tag__close-icon", $"{Id}-close-icon"));
                    __builder.AddAria(ref sequence, "labelledby", Id);
                    __builder.AddAttribute(sequence++, "title", "Clear Filter");
                    __builder.AddEvent(ref sequence, "onclick", OnCloseClick);

                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 32 32' aria-hidden='true'><path d='M24 9.4L22.6 8 16 14.6 9.4 8 8 9.4 14.6 16 8 22.6 9.4 24 16 17.4 22.6 24 24 22.6 17.4 16 24 9.4z'></path></svg>"));

                    __builder.CloseElement();
                }
            }
            __builder.CloseComponent();
        };
    }
}
