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
    /// 这是一个用于 HeaderMenuItem 的 Blazor 组件。  
    /// This is a Blazor component for the HeaderMenuItem.
    /// </summary>
    public partial class BxHeaderMenuItem : BxContentComponentBase
    {
        /// <summary>
        /// 触摸
        /// </summary>
        internal bool Touch { get; set; }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "li");
            __builder.IfAddAttribute(ref sequence, "role", "none", () => FatherComponentContext != null && FatherComponentContext.FatherComponent != null && (FatherComponentContext.FatherComponent is BxHeaderMenu));
            __builder.AddComponent(ref sequence, this);
            {
                if(ChildContent == null)
                {
                    __builder.OpenElement(sequence++, "a");
                    __builder.AddAttribute(sequence++, "href", Href);
                    __builder.AddConfig(ref sequence, new BxComponentConfig(MenuItemConfig, "bx--header__menu-item", $"{Id}-header-menu-item"));
                    __builder.AddEvent(ref sequence, "onmouseout", HandleOnMouseout);
                    __builder.AddEvent(ref sequence, "onmouseover", HandleOnMouseover);
                    {
                        __builder.OpenElement(sequence++, "span");
                        __builder.AddConfig(ref sequence, new BxComponentConfig(MenuItemConfig, "bx--text-truncate--end", $"{Id}-text-truncate--end"));

                        __builder.AddContent(sequence++, Title);

                        __builder.CloseElement();
                    }
                    __builder.CloseElement();
                }
                else
                {
                    __builder.AddContent(sequence++, ChildContent);
                }
            }
            __builder.CloseComponent();
        };

        /// <summary>
        /// 处理鼠标移进
        /// </summary>
        /// <param name="args"></param>
        internal virtual void HandleOnMouseover(MouseEventArgs args)
        {
            if (!Touch)
            {
                Touch = true;
            }

            if(FatherComponentContext?.FatherComponent is BxHeaderMenu menu)
            {
                menu.HandleOnMouseover(args);
            }
            else if (FatherComponentContext?.FatherComponent is BxHeaderMenuItem menuItem)
            {
                menuItem.HandleOnMouseover(args);
            }
        }

        /// <summary>
        /// 处理鼠标移出
        /// </summary>
        /// <param name="args"></param>
        internal virtual void HandleOnMouseout(MouseEventArgs args)
        {
            if (Touch)
            {
                Touch = false;
            }

            if (FatherComponentContext?.FatherComponent is BxHeaderMenu menu)
            {
                menu.HandleOnMouseout(args);
            }
            else if (FatherComponentContext?.FatherComponent is BxHeaderMenuItem menuItem)
            {
                menuItem.HandleOnMouseout(args);
            }
        }
    }
}
