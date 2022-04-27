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
    /// 这是一个用于 Loading 的 Blazor 组件。  
    /// This is a Blazor component for the Loading.
    /// </summary>
    public partial class BxLoading : BxComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--loading-overlay";

            ClassMapper
                .Clear()
                .Add(fixedClass)
                //.If($"bx--loading--small", () => Small)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            RenderFragment loading = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(LoadingConfig).AddClass($"bx--loading")
                    .AddId($"{Id}-loading")
                    .AddIfClass($"bx--loading--small", () => Small));
                __builder.AddAttribute(sequence++, "data-loading");

                __builder.AddContent(sequence++, new MarkupString("<svg class='bx--loading__svg' viewBox='-75 -75 150 150'><title>Loading</title><circle class='bx--loading__stroke' cx='0' cy='0' r='37.5' /></svg>"));

                __builder.CloseComponent();
            };

            var sequence = 0;

            if (WithOverlay)
            {
                __builder.OpenElement(sequence++, "div");
                __builder.AddComponent(ref sequence, this);

                __builder.AddContent(sequence++, loading);

                __builder.CloseComponent();
            }
            else
            {
                __builder.AddContent(sequence++, loading);
            }
        };
    }
}
