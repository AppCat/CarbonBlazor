using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 Switch 的 Blazor 组件。  
    /// This is a Blazor component for the Switch.
    /// </summary>
    public partial class BxSwitch : BxOptionComponentBase<BxContentSwitcher, BxSwitch, string>
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--content-switcher-btn";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--content-switcher--selected", () => Selected)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.UseElement(ref sequence, "button", this,
            __builder =>
            {
                __builder.AddAttribute(sequence++, "type", "button");
                __builder.AddAttribute(sequence++, "role", "tab");
                __builder.AddAttribute(sequence++, "tabindex", Selected ? "0" : "-1");
                __builder.AddAria(ref sequence, "selected", Selected);
                __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
            },
            __builder =>
            {
                __builder.OpenElement(sequence++, "span");
                __builder.AddConfig(ref sequence, new BxComponentConfig(LabelConfig, "bx--content-switcher__label", $"{Id}-label"));
                if (ValueTemplate != null)
                {
                    __builder.AddContent(sequence++, ValueTemplate, Tag);
                }
                else if (!string.IsNullOrWhiteSpace(Value))
                {
                    __builder.AddContent(sequence++, Value);
                }
                __builder.CloseElement();
            });
        };

        /// <summary>
        /// 处理点击
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override async Task HandleOnClickAsync(MouseEventArgs args)
        {
            if (Selected)
                return;

            await base.HandleOnClickAsync(args);
        }
    }
}
