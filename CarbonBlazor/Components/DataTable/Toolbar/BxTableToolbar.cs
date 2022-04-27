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
    /// BxTableToolbar
    /// </summary>
    public partial class BxTableToolbar : BxComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--table-toolbar";
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

            __builder.OpenElement(sequence++, "section");
            __builder.AddComponent(ref sequence, this);

            if(BatchActions != null)
            {
                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(BatchActionsConfig)
                    .AddClass($"bx--batch-actions")
                    .AddIfClass($"bx--batch-actions--active", () => IsShowBatch));
                __builder.AddAttribute(sequence++, "data-active", IsShowBatch);
                __builder.AddAttribute(sequence++, "tabindex", IsShowBatch ? 0 : -1);
                __builder.AddContent(sequence++, BatchActions);
                __builder.CloseComponent();
            }

            if(ToolbarContent != null)
            {
                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ToolbarContentConfig)
                    .AddClass($"bx--toolbar-content"));
                __builder.AddContent(sequence++, ToolbarContent);
                __builder.CloseComponent();
            }

            __builder.CloseComponent();
        };

        /// <summary>
        /// 显示 batch
        /// show batch
        /// </summary>
        /// <returns></returns>
        public async Task ShowBatchAsync()
        {
            IsShowBatch = true;
            await IsShowBatchChanged.InvokeAsync(IsShowBatch);
        }

        /// <summary>
        /// 隐藏 batch
        /// hide batch
        /// </summary>
        /// <returns></returns>
        public async Task HideBatchAsync()
        {
            IsShowBatch = false;
            await IsShowBatchChanged.InvokeAsync(IsShowBatch);
        }
    }
}
