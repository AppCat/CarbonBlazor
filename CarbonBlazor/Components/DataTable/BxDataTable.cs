using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 DataTable 的 Blazor 组件。  
    /// This is a Blazor component for the DataTable.
    /// </summary>
    public partial class BxDataTable<TModel> : BxContentComponentBase<TModel>, IBxTable
    {
        /// <summary>
        /// 模型
        /// </summary>
        protected static readonly TModel Model = (TModel)RuntimeHelpers.GetUninitializedObject(typeof(TModel));

        /// <summary>
        /// 渲染后的数据
        /// </summary>
        protected List<TModel> AfterDatas = new List<TModel>();

        /// <summary>
        /// 数据表联级参数
        /// </summary>
        [CascadingParameter]
        public BxDataTableContainer? TableContainer { get; set; }

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--data-table";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If($"bx--data-table--zebra", () => Zebra)
                .If($"bx--data-table--static", () => Static)
                .If($"bx--data-table--sticky-header", () => StickyHeader)
                .If($"bx--data-table--{Size}", () => Size != null)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.UseElement(ref sequence, "table", this, __builder =>
            {
                __builder.AddCascadingValue<IBxTable>(ref sequence, this, __builder =>
                {
                    var sequence = 0;

                    __builder.AddContent(sequence++, THeaderFragment());
                    __builder.AddContent(sequence++, TBodyFragment());
                });
            });
        };

        /// <summary>
        /// 头渲染
        /// </summary>
        /// <returns></returns>
        private RenderFragment THeaderFragment() => __builder =>
        {
            var sequence = 0;

            if (ChildContent == null || HideHeader)
            {
                return;
            }

            __builder.AddCascadingValue(ref sequence, BxColumGoal.Header, __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "thead");
                __builder.AddConfig(ref sequence, new BxComponentConfig(TheadConfig).AddId($"{Id}-thead"));
                {
                    __builder.OpenElement(sequence++, "tr");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(TrConfig).AddId($"{Id}-tr-thead"));

                    __builder.AddContent(sequence++, (RenderFragment<TModel>)(context => __builder =>
                    {
                        var sequence = 0;

                        // 选择列
                        if (IsCanSelected && IdExpression != null)
                        {
                            __builder.OpenComponent<BxSelectionColumn>(sequence++);
                            __builder.CloseComponent();
                        }

                        __builder.AddContent(sequence++, ChildContent, context);
                    }), Model);

                    __builder.CloseElement();
                }

                __builder.CloseElement();
            });
        };

        /// <summary>
        /// 身体渲染
        /// </summary>
        /// <returns></returns>
        private RenderFragment TBodyFragment() => __builder =>
        {
            var sequence = 0;

            if ((DataSource == null || !(DataSource?.Any() ?? false)) && EmptyTemplate != null)
            {
                __builder.AddContent(sequence++, EmptyTemplate);
            }
            else
            {
                __builder.AddCascadingValue(ref sequence, BxColumGoal.Body, __builder =>
                {
                    var sequence = 0;
                    __builder.OpenElement(sequence++, "tbody");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(TbodyConfig).AddId($"{Id}-tbody"));

                    if (ChildContent != null && DataSource != null && DataSource.Any())
                    {
                        int row = 0;
                        AfterDatas.Clear();
                        foreach (var data in DataSource)
                        {
                            AfterDatas.Add(data);
                            row++;
                            var id = IdExpression?.Compile()?.Invoke(data);
                            var rowIdHash = id?.GetHashCode();

                            __builder.OpenElement(sequence++, "tr");
                            __builder.AddConfig(ref sequence, new BxComponentConfig(TrConfig).AddId($"{Id}-tr-{row}"));

                            // 选择头
                            if (IsCanSelected && IdExpression != null)
                            {
                                __builder.IfAddAttribute(ref sequence, "class", $"bx--data-table--selected", () => SelectedIds.Contains(rowIdHash));
                            }

                            __builder.AddContent(sequence++, (context => __builder =>
                            {
                                var sequence = 0;

                                // 选择列
                                if (IsCanSelected && IdExpression != null)
                                {
                                    __builder.AddCascadingValue(ref sequence, id?.GetHashCode(), __builder =>
                                    {
                                        var sequence = 0;
                                        __builder.OpenComponent<BxSelectionColumn>(sequence++);
                                        __builder.CloseComponent();
                                    }, "RowIdHash");
                                }

                                __builder.AddContent(sequence++, ChildContent, context);
                            }), data);

                            __builder.CloseElement();
                        }
                    }

                    __builder.CloseElement();
                });
            }
        };

        /// <summary>
        /// 选中
        /// </summary>
        protected List<int?> SelectedIds = new List<int?>();

        /// <summary>
        /// 选定
        /// </summary>
        /// <param name="selectedId"></param>
        public void SelectedColumn(int? selectedId)
        {
            if (selectedId != null && IdExpression != null && !SelectedIds.Contains(selectedId))
            {
                SelectedIds.Add(selectedId);
                var items = AfterDatas.Where(data => SelectedIds.Contains(IdExpression.Compile()(data).GetHashCode()));
                OnSelectedChange.InvokeAsync(items);
                TableContainer?.ShowBatchAsync(items.Select(item => (object)item));
                InvokeStateHasChanged();
            }
        }

        /// <summary>
        /// 取消选定
        /// </summary>
        /// <param name="selectedId"></param>
        public void DeselectColumn(int? selectedId)
        {
            if (selectedId != null && IdExpression != null && SelectedIds.Contains(selectedId))
            {
                SelectedIds.Remove(selectedId);
                var items = AfterDatas.Where(data => SelectedIds.Contains(IdExpression.Compile()(data).GetHashCode()));
                OnSelectedChange.InvokeAsync(items);
                if(items.Count() <= 0)
                {
                    TableContainer.CloseBatchAsync();
                }
                InvokeStateHasChanged();
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        public void SelectedAll()
        {
            if (IsCanSelected && IdExpression != null)
            {
                SelectedIds.Clear();
                SelectedIds.AddRange(AfterDatas.Select(data => IdExpression?.Compile()(data)?.GetHashCode()));
                var items = AfterDatas.Where(data => SelectedIds.Contains(IdExpression.Compile()(data).GetHashCode()));
                OnSelectedChange.InvokeAsync(items);
                TableContainer?.ShowBatchAsync(items.Select(item => (object)item));
                InvokeStateHasChanged();
            }
        }

        /// <summary>
        /// 取消全选
        /// </summary>
        public void DeselectAll()
        {
            if (SelectedIds.Any() && IdExpression != null)
            {
                SelectedIds.Clear();
                OnSelectedChange.InvokeAsync(AfterDatas.Where(data => SelectedIds.Contains(IdExpression.Compile()(data).GetHashCode())));
                TableContainer.CloseBatchAsync();
                InvokeStateHasChanged();
            }
        }

        /// <summary>
        /// 是否选中
        /// </summary>
        /// <param name="selectedId"></param>
        /// <returns></returns>
        public bool IsSelected(int? selectedId)
        {
            return selectedId != null && SelectedIds.Contains(selectedId);
        }

        /// <summary>
        /// 是否全选
        /// </summary>
        /// <returns></returns>
        public bool IsSelectedAll()
        {
            if (IsCanSelected)
            {
                return AfterDatas.Count() <= SelectedIds.Count;
            }
            return false;
        }
    }
}
