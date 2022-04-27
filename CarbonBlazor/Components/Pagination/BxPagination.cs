using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 Pagination 的 Blazor 组件。  
    /// This is a Blazor component for the Pagination.
    /// </summary>
    public partial class BxPagination : BxComponentBase
    {
        /// <summary>
        /// 最小项
        /// </summary>
        protected int Min { get; set; }

        /// <summary>
        /// 最大项
        /// </summary>
        protected int Max { get; set; }

        /// <summary>
        /// 最大页码
        /// </summary>
        protected int PageTotal { get; set; } = 1;

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--pagination";

            ClassMapper
                .Clear()
                .Add(fixedClass)
                .AddEnum(Size, () => $"bx--pagination--{Size}")
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            Calculate();

            var start = DateTime.Now;

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            RenderFragment left = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(PaginationLeftConfig).AddClass($"bx--pagination__left").AddId($"{Id}-label-pagination__left"));
                {
                    // Start Label
                    __builder.OpenElement(sequence++, "label");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(PaginationTextConfig).AddClass($"bx--pagination__text").AddId($"{Id}-pagination__text"));
                    __builder.AddContent(sequence++, string.IsNullOrWhiteSpace(ItemsPerPageText) ? "Items per page:" : ItemsPerPageText);
                    __builder.CloseElement();
                    // End Label

                    // Start Select TODO
                    __builder.OpenComponent<BxSelect>(sequence++);

                    __builder.AddAttribute(sequence++, nameof(BxSelect.Inline), true);
                    __builder.AddAttribute(sequence++, nameof(BxSelect.Simplicity), true);
                    __builder.AddAttribute(sequence++, nameof(BxSelect.Disabled), PageSizeInputDisabled || Disabled);
                    __builder.AddAttribute(sequence++, nameof(BxSelect.Class), $"bx--select__item-count");
                    __builder.AddAttribute(sequence++, nameof(BxSelect.Size), Size);
                    __builder.AddAttribute(sequence++, nameof(BxSelect.ChildContent), (RenderFragment)(__builder =>
                    {
                        var size = PageSize <= 0 ? 1 : PageSize;
                        var pageSizes = PageSizes ?? new[] { size, 20, 30, 40, 50 };

                        foreach (var pageSize in pageSizes)
                        {
                            __builder.OpenComponent<BxSelectOption>(sequence++);
                            __builder.AddAttribute(sequence++, nameof(BxSelectOption.Key), pageSize.ToString());
                            __builder.AddAttribute(sequence++, nameof(BxSelectOption.Value), pageSize.ToString());
                            __builder.CloseComponent();
                        }

                    }));

                    __builder.AddEvent<BxSelectOption>(ref sequence, nameof(BxSelect.OnSelectedOption), this, async option =>
                    {
                        PageSize = int.Parse(option.Key);
                        await PageSizeChanged.InvokeAsync(PageSize);
                    });

                    __builder.CloseComponent();
                    // End Select

                    //__builder.OpenElement(sequence++, "div");
                    //__builder.AddConfig(ref sequence, new BxComponentConfig().AddClass($"bx--form-item bx--select__item-count").AddId($"{Id}-select__item-count"));
                    //{

                    //}

                    //__builder.CloseElement();

                    // Start Span
                    __builder.OpenElement(sequence++, "span");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(PaginationTextConfig).AddClass($"bx--pagination__text").AddId($"{Id}-pagination__text"));

                    if (PagesUnknown)
                    {
                        var itemText = ItemText ?? ((min, max) => $"{min} – {max} items");
                        __builder.AddContent(sequence++, itemText.Invoke(Min, Max));
                    }
                    else
                    {
                        var itemRangeText = ItemRangeText ?? ((min, max, total) => $"{min} – {max} of {total} items");
                        __builder.AddContent(sequence++, itemRangeText.Invoke(Min, Max, (int)(TotalItems ?? 1)));
                    }

                    __builder.CloseElement();
                    // End Span
                }
                __builder.CloseElement();
            };

            RenderFragment right = async __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(PaginationPightConfig).AddClass($"bx--pagination__right").AddId($"{Id}-pagination__right"));
                {
                    // Start Select
                    __builder.OpenComponent<BxSelect>(sequence++);

                    __builder.AddAttribute(sequence++, nameof(BxSelect.Inline), true);
                    __builder.AddAttribute(sequence++, nameof(BxSelect.Simplicity), true);
                    __builder.AddAttribute(sequence++, nameof(BxSelect.Disabled), PageInputDisabled || Disabled);
                    __builder.AddAttribute(sequence++, nameof(BxSelect.Class), $"bx--select__page-number");
                    __builder.AddAttribute(sequence++, nameof(BxSelect.Size), Size);
                    __builder.AddAttribute(sequence++, nameof(BxSelect.ChildContent), (RenderFragment)(__builder =>
                    {
                        var pages = Enumerable.Range(1, PageTotal);

                        foreach (var page in pages)
                        {
                            __builder.OpenComponent<BxSelectOption>(sequence++);
                            __builder.AddAttribute(sequence++, nameof(BxSelectOption.Key), page.ToString());
                            __builder.AddAttribute(sequence++, nameof(BxSelectOption.Value), page.ToString());
                            __builder.CloseComponent();
                        }

                    }));

                    __builder.AddEvent<BxSelectOption>(ref sequence, nameof(BxSelect.OnSelectedOption), this, async option =>
                    {
                        await HandlePageAsync(int.Parse(option.Key));
                    });

                    __builder.CloseComponent();
                    // End Select

                    // Start PaginationText
                    __builder.OpenElement(sequence++, "span");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(PaginationTextConfig).AddClass($"bx--pagination__text").AddId($"{Id}-pagination__text"));

                    if (PagesUnknown)
                    {
                        var pageText = PageText ?? ((current) => $"page {current}");
                        __builder.AddContent(sequence++, pageText.Invoke(Page));
                    }
                    else
                    {
                        var pageRangeText = PageRangeText ?? ((current, total) => $"of { total } {(total == 1 ? "page" : "pages")}");
                        __builder.AddContent(sequence++, pageRangeText.Invoke(Page, PageTotal));
                    }

                    __builder.CloseElement();
                    // End PaginationText

                    // Start Buttons
                    __builder.OpenElement(sequence++, "div");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(ControlButtonsConfig, $"bx--pagination__control-buttons", $"{Id}-pagination-control-buttons"));
                    {
                        // Start ButtonBackward
                        __builder.OpenElement(sequence++, "button");
                        __builder.AddAttribute(sequence++, "style", $"padding: 0;");
                        __builder.AddEvent(ref sequence, "onclick", HandleOnClickBackwardAsync, true);
                        __builder.AddConfig(ref sequence, new BxComponentConfig(ButtonBackwardConfig, $"bx--pagination__button bx--pagination__button--backward bx--btn bx--btn--md bx--btn--ghost", $"{Id}pagination-button-backward"));
                        __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' style='will-change: transform;' xmlns='http://www.w3.org/2000/svg' class='bx--pagination__nav-arrow' width='20' height='20' viewBox='0 0 32 32' aria-hidden='true'><path d='M19 23L11 16 19 9 19 23z'></path></svg>"));
                        __builder.CloseElement();
                        // End ButtonBackward

                        // Start ButtonForward
                        __builder.OpenElement(sequence++, "button");
                        __builder.AddAttribute(sequence++, "style", $"padding: 0;");
                        __builder.AddEvent(ref sequence, "onclick", HandleOnClickForwardAsync, true);
                        __builder.AddConfig(ref sequence, new BxComponentConfig(ButtonBackwardConfig, $"bx--pagination__button bx--pagination__button--forward bx--btn bx--btn--md bx--btn--ghost", $"{Id}pagination-button-forward"));
                        __builder.AddContent(sequence++, new MarkupString($"<svg focusable='false' preserveAspectRatio='xMidYMid meet' style='will-change: transform;' xmlns='http://www.w3.org/2000/svg' class='bx--pagination__nav-arrow' width='20' height='20' viewBox='0 0 32 32' aria-hidden='true'><path d='M13 9L21 16 13 23 13 9z'></path></svg>"));
                        __builder.CloseElement();
                        // End ButtonForward
                    }
                    __builder.CloseElement();
                    // Start Buttons
                }
                __builder.CloseElement();
            };

            __builder.AddContent(sequence++, left);
            __builder.AddContent(sequence++, right);

            __builder.CloseComponent();

            var end = DateTime.Now;
            Console.WriteLine($"{this.GetType().FullName} {Id} 渲染耗时 : {(end - start).TotalMilliseconds} ms");
        };

        /// <summary>
        /// 计算
        /// </summary>
        private void Calculate()
        {
            var pageSize = PageSize <= 0 ? 1 : PageSize;
            var page = Page <= 0 ? 1 : Page;
            var total = TotalItems == null || TotalItems.Value <= 0 ? 1 : TotalItems.Value;

            if (TotalItems != null)
            {
                PageTotal = (int)Math.Ceiling(total / (double)pageSize);
            }
            Min = pageSize * (page - 1) + 1;
            Max = pageSize * page;
        }

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickBackwardAsync(MouseEventArgs args)
        {
           await HandlePageAsync(Page - 1);
        }

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickForwardAsync(MouseEventArgs args)
        {
            await HandlePageAsync(Page + 1);
        }

        /// <summary>
        /// 点击页码项
        /// </summary>
        /// <returns></returns>
        private async Task HandlePageAsync(int page)
        {
            if (Disabled)
                return;
            if (page < 1)
                Page = 1;
            else if (page > PageTotal)
                Page = PageTotal;
            else
                Page = page;
                await PageChanged.InvokeAsync(Page);
                await OnPageChange.InvokeAsync(new BxPaginationEventArgs(Page, PageTotal));
        }
    }
}
