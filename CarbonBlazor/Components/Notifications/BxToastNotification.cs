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
    /// 这是一个用于 ToastNotification 的 Blazor 组件。  
    /// This is a Blazor component for the ToastNotification.
    /// </summary>
    public partial class BxToastNotification : BxNotificationBase
    {
        /// <summary>
        /// 类型
        /// </summary>
        protected override string Type => "toast";

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
                __builder.AddContent(sequence++, TitleFragment());
                __builder.AddContent(sequence++, SubtitleFragment());

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(CaptionConfig, $"bx--{Type}-notification__caption", $"{Id}-caption"));
                __builder.AddContent(sequence++, Caption);
                __builder.CloseElement();
            }
            __builder.CloseElement();
        };

    }
}
