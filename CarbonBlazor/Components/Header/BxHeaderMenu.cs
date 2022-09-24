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
    /// 这是一个用于 HeaderMenu 的 Blazor 组件。  
    /// This is a Blazor component for the HeaderMenu.
    /// </summary>
    public partial class BxHeaderMenu : BxMenuComponentBase
    {
        /// <summary>
        /// 触摸展开
        /// </summary>
        protected bool TouchExpanded { get; set; }

        /// <summary>
        /// 触摸
        /// </summary>
        protected bool Touch { get; set; }

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--header__submenu";

            ClassMapper
                .Clear()
                .Add(fixedClass)
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
            __builder.AddComponent(ref sequence, this);
            {
                __builder.OpenElement(sequence++, "a");
                __builder.AddConfig(ref sequence, new BxComponentConfig(MenuTitleConfig, "bx--header__menu-item bx--header__menu-title", $"{Id}-header-menu-title"));
                __builder.AddAttribute(sequence++, "href", "javascript:void(0)");
                __builder.AddAttribute(sequence++, "role", "menuitem");
                __builder.AddAttribute(sequence++, "tabindex", "0");
                __builder.AddAria(ref sequence, "haspopup", "menu");
                __builder.AddAria(ref sequence, "expanded", (Expanded || TouchExpanded).ToString().ToLower());
                __builder.AddAria(ref sequence, "label", AriaLabel);
                __builder.AddEvent(ref sequence, "onclick", HandleOnClick);
                //__builder.AddEvent(ref sequence, "onmouseout", HandleOnMouseout);
                //__builder.AddEvent(ref sequence, "onmouseover", HandleOnMouseover);
                //__builder.AddEvent(ref sequence, "onmousemove", HandleOnMouseover);

                __builder.EitherOrAddContent(ref sequence, TitleTemplate, Title, () => TitleTemplate != null);
                __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' width='10' height='6' viewBox='0 0 10 6' aria-hidden='true' class='bx--header__menu-arrow' style='will-change: transform;'><path d='M5 6L0 1 .7.3 5 4.6 9.3.3l.7.7z'></path></svg>"));

                __builder.CloseElement();

                __builder.OpenElement(sequence++, "ul");
                __builder.AddAria(ref sequence, "label", AriaLabel);
                __builder.AddAttribute(sequence++, "role", "menu");
                __builder.AddConfig(ref sequence, new BxComponentConfig(MenuConfig, "bx--header__menu", $"{Id}-header-menu"));

                __builder.AddContent(sequence++, ChildContent);

                __builder.CloseElement();
            }
            __builder.CloseComponent();
        };

        /// <summary>
        /// 处理鼠标移进
        /// </summary>
        /// <param name="args"></param>
        internal virtual void HandleOnMouseover(MouseEventArgs args)
        {
            TouchExpanded = true;
        }

        /// <summary>
        /// 处理鼠标移动
        /// </summary>
        /// <param name="args"></param>
        internal virtual void HandleOnMousemove(MouseEventArgs args)
        {
            Touch = true;
        }

        /// <summary>
        /// 处理鼠标移出
        /// </summary>
        /// <param name="args"></param>
        internal virtual void HandleOnMouseout(MouseEventArgs args)
        {
            Task.Run(async () =>
            {
                await Task.Delay(50);

                if (ComponentContext?.SonsComponents.TryGetValue(typeof(BxHeaderMenuItem), out var components) ?? false)
                {
                    var items = components.Values.Select(x => (BxHeaderMenuItem)x);
                    var touch = items.Any(x => x.Touch);
                    if (!touch && !Touch)
                    {
                        TouchExpanded = false;
                    }
                }
                else
                {
                    if (TouchExpanded)
                    {
                        TouchExpanded = false;
                    }
                }
                InvokeStateHasChanged();
            });
            Touch = false;
        }

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual void HandleOnClick(MouseEventArgs args)
        {
            Expanded = !Expanded;
        }

        /// <summary>
        /// 处理外部点击
        /// </summary>
        /// <param name="path"></param>
        protected void HandleExternalClick(ClickElement[] path)
        {
            if (!Expanded)
                return;
            if (path.Any(e => e.Id == Id)) // 包含自己不隐藏
                return;
            InvokeAsync(() =>
            {
                Expanded = false;
                StateHasChanged();
            });
        }

        #region SDLC

        /// <summary>
        /// 初始化后
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            OnDocumentClick += HandleExternalClick;
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            OnDocumentClick -= HandleExternalClick;
        }

        #endregion
    }
}
