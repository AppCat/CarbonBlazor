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
    /// 这是一个用于 InlineNotification 的 Blazor 组件。  
    /// This is a Blazor component for the InlineNotification.
    /// </summary>
    public partial class BxInlineNotification : BxNotificationBase
    {
        /// <summary>
        /// 类型
        /// </summary>
        protected override string Type => "inline";

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;
            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            __builder.AddContent(sequence++, DetailsFragment());
            __builder.AddContent(sequence++, CloseButtonFragment()); 

            __builder.CloseComponent();
        };

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment DetailsFragment() => __builder =>
        {
            var sequence = 0;
            __builder.OpenElement(sequence++, "div");
            __builder.AddConfig(ref sequence, new BxComponentConfig(DetailsConfig, $"bx--{Type}-notification__details", $"{Id}-details"));
            {
                __builder.AddContent(sequence++, IconFragment());

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(DetailsConfig, $"bx--{Type}-notification__text-wrapper", $"{Id}-text-wrapper"));
                {
                    __builder.AddContent(sequence++, TitleFragment());
                    __builder.AddContent(sequence++, SubtitleFragment());
                }
                __builder.CloseElement();
            }
            __builder.CloseElement();
        };
    }
}
