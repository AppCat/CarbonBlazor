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
    /// 这是一个用于 Modal 的 Blazor 组件。  
    /// This is a Blazor component for the Modal.
    /// </summary>
    public partial class BxModal : BxContentComponentBase
    {
        /// <summary>
        /// 关闭元素
        /// </summary>
        protected ElementReference CloseElement { get; set; }

        /// <summary>
        /// 是否聚焦
        /// </summary>
        protected bool IsFocus { get; set; }

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--modal";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("is-visible", () => Visible)
                ;
            Tabindex = -1;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var labelledby = $"{Id}-modal-header__label";
            var describedby = $"{Id}-modal-header__heading";

            RenderFragment label = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "p");
                __builder.AddConfig(ref sequence, new BxComponentConfig(HeaderLabelConfig)
                    .AddClass($"bx--modal-header__label bx--type-delta")
                    .AddId(labelledby));

                if (LabelTemplate != null)
                {
                    __builder.AddContent(sequence++, LabelTemplate, Model ?? this);
                }
                else if (!string.IsNullOrEmpty(Label))
                {
                    __builder.AddContent(sequence++, Label);
                }

                __builder.CloseElement();
            };

            RenderFragment heading = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "p");
                __builder.AddConfig(ref sequence, new BxComponentConfig(HeaderHeadingConfig)
                    .AddClass($"bx--modal-header__heading bx--type-delta")
                    .AddId(describedby));

                if (HeadingTemplate != null)
                {
                    __builder.AddContent(sequence++, HeadingTemplate, Model ?? this);
                }
                else if (!string.IsNullOrEmpty(Heading))
                {
                    __builder.AddContent(sequence++, Heading);
                }

                __builder.CloseElement();
            };

            RenderFragment close = __builder =>
            {
                if (PassiveModal)
                    return;

                var sequence = 0;

                __builder.OpenElement(sequence++, "button");
                __builder.AddConfig(ref sequence, new BxComponentConfig(CloseConfig)
                    .AddClass($"bx--modal-close")
                    .AddId($"{Id}-modal-close"));
                __builder.AddEvent(ref sequence, "onclick", HandleOnClickCloseAsync, true, true);
                //__builder.AddAttribute(sequence++, "data-modal-close");
                __builder.AddAttribute(sequence++, "data-modal-primary-focus");
                __builder.AddAttribute(sequence++, "type", "button");
                __builder.AddAttribute(sequence++, "aria-label", "close modal");
                __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' style='will-change: transform;' xmlns='http://www.w3.org/2000/svg' class='bx--modal-close__icon' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true'><path d='M12 4.7L11.3 4 8 7.3 4.7 4 4 4.7 7.3 8 4 11.3 4.7 12 8 8.7 11.3 12 12 11.3 8.7 8z'></path></svg>"));
                __builder.AddElementReferenceCapture(sequence++, element => CloseElement = element);
                __builder.CloseElement();
            };

            RenderFragment header = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(HeaderConfig)
                    .AddClass($"bx--modal-header")
                    .AddId($"{Id}-modal-header"));

                __builder.AddContent(sequence++, label);
                __builder.AddContent(sequence++, heading);
                __builder.AddContent(sequence++, close);

                __builder.CloseElement();
            };

            RenderFragment content = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ContentConfig)
                    .AddClass($"bx--modal-content")
                    .AddId($"{Id}-content"));
                __builder.AddAttribute(sequence++, "aria-labelledby", labelledby);
                __builder.IfAddAttribute(ref sequence, "tabindex", 0, () => HasScrollingContent);

                if (ContentTemplate != null)
                {
                    __builder.AddContent(sequence++, ContentTemplate, Model ?? this);
                }
                else if (ChildContent != null)
                {
                    __builder.AddContent(sequence++, ChildContent);
                }
                else if (!string.IsNullOrEmpty(Content))
                {
                    __builder.OpenElement(sequence++, "p");
                    __builder.AddContent(sequence++, Content);
                    __builder.CloseElement();
                }

                if (Loading)
                {
                    __builder.AddContent(sequence++, (RenderFragment)(__builder =>
                    {
                        var sequence = 0;

                        __builder.OpenComponent<BxLoading>(sequence++);
                        __builder.CloseComponent();
                    }));
                }

                __builder.CloseElement();
            };

            RenderFragment footer = __builder =>
            {
                if (FooterTemplate == null && Actions == null)
                    return;

                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(FooterConfig)
                    .AddClass($"bx--modal-footer bx--btn-set")
                    .AddId($"{Id}-modal-footer"));

                if (FooterTemplate != null)
                {
                    __builder.AddContent(sequence++, FooterTemplate, Model ?? this);
                }
                else if (Actions?.Any() ?? false)
                {
                    foreach (var action in Actions)
                    {
                        __builder.AddContent(sequence++, ActionButtonFragment(action));
                    }
                }

                __builder.CloseElement();
            };

            RenderFragment container = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ContainerConfig)
                    .AddClass($"bx--modal-container")
                    .AddId($"{Id}-modal-container")
                    .AddIfClass($"bx--modal-container--{Size}", () => Size != null));
                __builder.AddAttribute(sequence++, "role", "dialog");
                __builder.AddAttribute(sequence++, "aria-modal", "true");
                __builder.AddAttribute(sequence++, "tabindex", "-1");
                __builder.AddAttribute(sequence++, "aria-label", Label ?? String.Empty);

                __builder.AddContent(sequence++, header);
                __builder.AddContent(sequence++, content);
                __builder.AddContent(sequence++, footer);

                __builder.CloseElement();
            };

            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);
            __builder.AddAttribute(sequence++, "role", "dialog");
            //__builder.AddAttribute(sequence++, "data-modal", "");
            __builder.AddAttribute(sequence++, "aria-modal", "true");
            __builder.AddAttribute(sequence++, "aria-labelledby", labelledby);
            __builder.AddAttribute(sequence++, "aria-describedby", describedby);
            __builder.AddEvent(ref sequence, "onkeyup", HandleOnKeyupAsync, true, true);

            __builder.AddContent(sequence++, container);

            __builder.CloseComponent();
        };

        /// <summary>
        /// 行为按钮渲染
        /// </summary>
        /// <param name="config"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        protected RenderFragment ActionButtonFragment(BxModalActionConfig config) => __builder =>
        {
            if (config == null)
                return;

            var sequence = 0;

            __builder.OpenComponent<BxButton>(sequence++);
            __builder.AddConfig(ref sequence, config);
            __builder.AddAttribute(sequence++, nameof(BxButton.Kind), config.Kind);
            __builder.AddAttribute(sequence++, nameof(BxButton.Type), config.Type);
            __builder.AddAttribute(sequence++, nameof(BxButton.Content), config.Text);
            __builder.IfAddAttribute(ref sequence, "OnClick", EventCallback.Factory.Create<MouseEventArgs>(this, async e =>
            {
                if (config.OnClick != null)
                {
                    var isHide = await config.OnClick.Invoke(Model);

                    if (isHide)
                    {
                        await CloseAsync();
                    }
                }

            }), () => config.OnClick != null);

            __builder.CloseComponent();
        };

        /// <summary>
        /// 处理 ClickClose
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickCloseAsync(MouseEventArgs args)
        {
            await CloseAsync();
        }

        /// <summary>
        /// 键盘按下事件
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnKeyupAsync(KeyboardEventArgs args)
        {
            if (args != null && args.Key == "Escape")
            {
                await CloseAsync();
            }
        }

        /// <summary>
        /// 处理外部点击
        /// </summary>
        protected void HandleExternalClick(ClickElement[] path)
        {
            if (!Visible || PreventCloseOnClickOutside || Loading)
                return;
            if (path.Any(e => e.Id?.Contains($"{Id}-modal-container") ?? false)) // 包含自己不隐藏
                return;
            InvokeAsync(() => CloseAsync());
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public async Task ShowAsync()
        {
            if (Visible)
                return;

            Visible = true;
            await VisibleChanged.InvokeAsync(Visible);
            await OnVisibleChange.InvokeAsync(Visible);
            IsFocus = true;
            StateHasChanged();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <returns></returns>
        public async Task CloseAsync()
        {
            if (!Visible)
                return;

            Visible = false;
            await VisibleChanged.InvokeAsync(Visible);
            await OnVisibleChange.InvokeAsync(Visible);
            StateHasChanged();
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

        /// <summary>
        /// 渲染后
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (Visible)
            {
                if (IsFocus)
                {
                    await CloseElement.FocusAsync();
                    IsFocus = false;
                }
                await OnShow.InvokeAsync();
            }
            else
            {
                await OnClose.InvokeAsync();
            }
        }

        #endregion
    }
}
