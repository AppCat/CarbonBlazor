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
    /// 按钮用于初始化一个操作，在背景或前景的体验。  
    /// Buttons are used to initialize an action, either in the background or foreground of an experience.
    /// </summary>
    public partial class BxButton : BxPropertieContentComponentBase<BxButton>
    {
        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;
            //var cssScope = "vb-button";

            if (Skeleton)
            {
                __builder.OpenElement(sequence++, "bx-btn-skeleton");
            }
            else
            {
                __builder.OpenElement(sequence++, "bx-btn");
                __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync, OnClickStopPropagation);
            }

            __builder.AddComponent(ref sequence, this); 

            __builder.EitherOrAddContent(ref sequence, ChildContent, Content, () => ChildContent != null);

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
