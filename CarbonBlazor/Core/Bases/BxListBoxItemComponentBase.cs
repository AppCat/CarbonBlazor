using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 用于 list-box__menu-item 的通用组件
    /// </summary>
    public class BxListBoxItemComponentBase<TSelect, TOption> : BxOptionComponentBase<TSelect, TOption, string>
        where TSelect : BxListBoxComponentBase<TOption>
        where TOption : class, IBxOption<string>
    {
        /// <summary>
        /// 元素
        /// </summary>
        protected ElementReference Element { get; set; }        

        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSetMapper()
        {
            base.OnSetMapper();
            var fixedClass = $"bx--list-box__menu-item";

            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If($"bx--list-box__menu-item--active", () => Selected)
                .If($"bx--list-box__menu-item--highlighted", () => Focus)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "li");
            __builder.AddComponent(ref sequence, this); ;
            __builder.IfAddAttribute(ref sequence, "disabled", () => Disabled);
            __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
            {
                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(MenuItemOptionConfig)
                    .AddClass($"bx--list-box__menu-item__option")
                    .AddId($"{Id}-menu-item__option"));
                __builder.AddAttribute(sequence++, "tabindex", 0);
                if (ValueTemplate != null)
                {
                    __builder.AddContent(sequence++, ValueTemplate, Tag);
                }
                else if (!string.IsNullOrWhiteSpace(Value))
                {
                    __builder.AddContent(sequence++, Value);
                }
                __builder.CloseElement();
            }

            __builder.AddElementReferenceCapture(sequence++, element => Element = element);
            //__builder.IfAddAttribute(ref sequence, "aria-current", true, () => Selected);
            //__builder.IfAddAttribute(ref sequence, "aria-selected", true, () => Selected);

            __builder.CloseElement();
        };

        /// <summary>
        /// 渲染后
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (Selected)
            {
                await Element.FocusAsync(true);
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        /// <summary>
        /// menu-item__option 配置
        /// The menu-item__option is config .
        /// </summary>
        [Parameter]
        public IBxComponentConfig? MenuItemOptionConfig { get; set; }
    }
}
