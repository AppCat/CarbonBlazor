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
    /// 数据表容器
    /// </summary>
    public partial class BxDataTableContainer : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--data-table-container";
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
            RenderFragment header = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(HeaderConfig, "bx--data-table-header", $"{Id}-table-header"));
                {
                    if (TitleTemplate != null || !string.IsNullOrWhiteSpace(Title))
                    {
                        __builder.OpenElement(sequence++, "div");
                        __builder.AddConfig(ref sequence, new BxComponentConfig(TitleConfig, "bx--data-table-header__title", $"{Id}-table-header-title"));
                        __builder.EitherOrAddContent(ref sequence, TitleTemplate, Title, () => TitleTemplate != null);
                        __builder.CloseElement();
                    }

                    if (DescriptionTemplate != null || !string.IsNullOrWhiteSpace(Description))
                    {
                        __builder.OpenElement(sequence++, "div");
                        __builder.AddConfig(ref sequence, new BxComponentConfig(DescriptionConfig, "bx--data-table-header__description", $"{Id}-table-header-description"));
                        __builder.EitherOrAddContent(ref sequence, DescriptionTemplate, Description, () => DescriptionTemplate != null);
                        __builder.CloseElement();
                    }
                }
                __builder.CloseElement();
            };

            RenderFragment toolbar = __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ToolbarConfig, "bx--table-toolbar", $"{Id}-table-header"));
                __builder.AddAria(ref sequence, "label", "data table toolbar");
                {
                    __builder.OpenElement(sequence++, "div");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(BatchActionsConfig, "bx--batch-actions", $"{Id}-batch-actions").AddIfClass("bx--batch-actions--active", () => IsShowBatch));
                    __builder.AddAria(ref sequence, "hidden", IsShowBatch);
                    {
                        __builder.OpenElement(sequence++, "div");
                        __builder.AddConfig(ref sequence, new BxComponentConfig(BatchSummaryConfig, "bx--batch-summary", $"{Id}-batch-summary"));
                        {
                            __builder.OpenElement(sequence++, "p");
                            __builder.AddConfig(ref sequence, new BxComponentConfig(BatchSummaryParaConfig, "bx--batch-summary__para", $"{Id}-batch-summary-para"));
                            {
                                if (IsShowBatch && Items != null)
                                {
                                    var paraText = SummaryParaText ?? ((count) => $"{count.Count()} item selected");
                                    __builder.AddContent(sequence++, new MarkupString($"<span dir='auto'>{paraText.Invoke(Items.AsEnumerable())}</span>"));
                                }
                            }
                            __builder.CloseElement();
                        }
                        __builder.CloseElement();

                        __builder.OpenElement(sequence++, "div");
                        __builder.AddConfig(ref sequence, new BxComponentConfig(ToolbarConfig, "bx--action-list", $"{Id}-action-list"));
                        {
                            if (BatchListTemplate != null && Items != null)
                            {
                                __builder.AddContent(sequence++, BatchListTemplate, Items.AsEnumerable());
                            }
                        }
                        __builder.CloseElement();
                    }
                    __builder.CloseElement();

                    if(ToolbarContentTemplate != null)
                    {
                        __builder.OpenElement(sequence++, "div");
                        __builder.AddConfig(ref sequence, new BxComponentConfig(ToolbarContentConfig, "bx--toolbar-content", $"{Id}-table-header"));
                        __builder.AddAria(ref sequence, "hidden", $"{!IsShowBatch}");
                        {
                            __builder.AddContent(sequence++, ToolbarContentTemplate);
                        }
                        __builder.CloseElement();
                    }
                }
                __builder.CloseElement();
            };

            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            __builder.IfAddContent(ref sequence, header, () => DescriptionTemplate != null || !string.IsNullOrWhiteSpace(Description) || TitleTemplate != null || !string.IsNullOrWhiteSpace(Title));
            __builder.AddContent(sequence++, toolbar);

            __builder.OpenElement(sequence++, "div");
            __builder.AddConfig(ref sequence, new BxComponentConfig(ContentConfig, "bx--data-table-content", $"{Id}-table-content"));
            {
                __builder.AddCascadingValue(ref sequence, this, __builder =>
                {
                    var sequence = 0;
                    __builder.AddContent(sequence++, ChildContent);
                });
            }
            __builder.CloseElement();

            __builder.CloseComponent();
        };

        /// <summary>
        /// 是否显示批处理
        /// </summary>
        protected bool IsShowBatch { get; set; }

        /// <summary>
        /// 选项
        /// </summary>
        protected IEnumerable<object>? Items { get; set; }

        /// <summary>
        /// 显示批处理
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        internal async Task ShowBatchAsync(IEnumerable<object>? items)
        {
            if (items is null || !items.Any())
                return;

            IsShowBatch = true;
            Items = items;
            await OnShowBatch.InvokeAsync();
            await InvokeStateHasChangedAsync();
        }

        /// <summary>
        /// 关闭批处理
        /// close batch
        /// </summary>
        /// <returns></returns>
        internal async Task CloseBatchAsync()
        {
            IsShowBatch = false;
            await OnCloseBatch.InvokeAsync();
            await InvokeStateHasChangedAsync();
        }
    }
}
