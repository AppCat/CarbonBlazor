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
    /// 这是一个用于 Crad 的 Blazor 组件。  
    /// This is a Blazor component for the Crad.
    /// </summary>
    public partial class BxCrad : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"cb--card";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            RenderFragment title = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "span");
                __builder.AddConfig(ref sequence, new BxComponentConfig(TitleConfig, $"cb--card--title", $"{Id}-title"));
                {
                    __builder.OpenElement(sequence++, "div");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(TextConfig, $"cb--card--title--text", $"{Id}-title-text"));
                    __builder.AddContent(sequence++, Title);
                    __builder.CloseElement();

                    if (!string.IsNullOrEmpty(Subtitle))
                    {
                        __builder.OpenElement(sequence++, "div");
                        __builder.AddConfig(ref sequence, new BxComponentConfig(TitleConfig, $"cb--card--subtitle--text", $"{Id}-subtitle-text"));
                        __builder.AddContent(sequence++, Subtitle);
                        __builder.CloseElement();
                    }
                }
                __builder.CloseElement();
            };

            RenderFragment toolbar = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ToolbarConfig, $"cb--card--toolbar", $"{Id}-toolbar"));
                __builder.AddContent(sequence++, ToolbarTemplate);
                __builder.CloseElement();
            };

            RenderFragment header = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(HeaderConfig, $"cb--card--header", $"{Id}-header"));
                {
                    __builder.AddContent(sequence++, title);
                    __builder.AddContent(sequence++, toolbar);
                }
                __builder.CloseElement();
            };

            RenderFragment content = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ContentConfig, $"cb--card--content", $"{Id}-content").AddStyle("--card-content-height", "100%"));
                {
                    if(ChildContent != null)
                    {
                        __builder.AddContent(sequence++, ChildContent);
                    }
                    else
                    {
                        __builder.AddContent(sequence++, ContentTemplate);
                    }
                }
                __builder.CloseElement();
            };

            RenderFragment footer = __builder =>
            {
                var sequence = 0;

                if (FooterTemplate == null)
                    return;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(FooterConfig, $"cb--card--footer", $"{Id}-footer"));
                __builder.AddContent(sequence++, FooterTemplate);
                __builder.CloseElement();
            };

            var sequence = 0;
            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);
            __builder.AddAttribute(sequence++, "role", "presentation");
            __builder.AddAttribute(sequence++, "tabindex", "0");
            __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync, OnClickStopPropagation);

            __builder.AddContent(sequence++, header);
            __builder.AddContent(sequence++, content);
            __builder.AddContent(sequence++, footer);

            __builder.CloseComponent();
        };

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickAsync(MouseEventArgs args)
        {
            await Click(args);
        }

        /// <summary>
        /// 点击
        /// </summary>
        /// <returns></returns>
        protected virtual async Task Click(MouseEventArgs args)
        {
            if (Loading || Disabled)
                return;
            Loading = true;
            await LoadingChanged.InvokeAsync(Loading);
            await OnClick.InvokeAsync(args);
            Loading = false;
            await LoadingChanged.InvokeAsync(Loading);
        }
    }
}
