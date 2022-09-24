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
        where TModel : class
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
                __builder.AddConfig(ref sequence, new BxComponentConfig(TheadConfig).SetId($"{Id}-thead"));
                {
                    __builder.OpenElement(sequence++, "tr");
                    __builder.AddConfig(ref sequence, new BxComponentConfig(TrConfig).SetId($"{Id}-tr-thead"));

                    __builder.AddContent(sequence++, (RenderFragment<TModel>)(context => __builder =>
                    {
                        var sequence = 0;

                        // 选择列
                        if (Model is ISelectionModel)
                        {
                            __builder.OpenComponent<BxSelectionColumn<TModel>>(sequence++);
                            __builder.CloseComponent();
                        }

                        // 选择列
                        if (Model is IExpansionModel)
                        {
                            __builder.OpenComponent<BxExpansionColumn<TModel>>(sequence++);
                            __builder.CloseComponent();
                        }

                        var types = context.GetType().GetGenericArguments();

                        if (types.Any() && typeof(SelectionModelWrapper<>).MakeGenericType(types).IsInstanceOfType(context))
                        {
                            var constructorInfo = typeof(SelectionModelWrapper<>).MakeGenericType(types).GetConstructor(new Type[0]);
                            constructorInfo!.Invoke(context, null);
                        }
                        else if (types.Any() && typeof(ExpansionModelWrapper<>).MakeGenericType(types).IsInstanceOfType(context))
                        {
                            var constructorInfo = typeof(ExpansionModelWrapper<>).MakeGenericType(types).GetConstructor(new Type[0]);
                            constructorInfo!.Invoke(context, null);
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
                    __builder.AddConfig(ref sequence, new BxComponentConfig(TbodyConfig).SetId($"{Id}-tbody"));

                    if (ChildContent != null && DataSource != null && DataSource.Any())
                    {
                        int row = 0;
                        AfterDatas.Clear();
                        foreach (var data in DataSource)
                        {
                            AfterDatas.Add(data);
                            row++;

                            __builder.OpenElement(sequence++, "tr");
                            __builder.AddConfig(ref sequence, new BxComponentConfig(TrConfig).SetId($"{Id}-tr-{row}")
                            .AddIfClass($"bx--data-table--selected", () => data is ISelectionModel selection && selection.Selected)
                            .AddIfClass($"bx--parent-row", () => data is IExpansionModel)
                            .AddIfClass($"bx--expandable-row", () => data is IExpansionModel expansion && expansion.Expanded));
                            __builder.IfAddAttribute(ref sequence, "data-parent-row", "true", () => data is IExpansionModel expansion);

                            //选择
                            //if (data is ISelectionModel selection)
                            //{
                            //    __builder.IfAddAttribute(ref sequence, "class", $"bx--data-table--selected", () => selection.Selected);
                            //}

                            __builder.AddContent(sequence++, (context => __builder =>
                            {
                                var sequence = 0;

                                // 选择列
                                if (data is ISelectionModel)
                                {
                                    __builder.AddCascadingValue(ref sequence, (ISelectionModel)data, __builder =>
                                    {
                                        __builder.OpenComponent<BxSelectionColumn<TModel>>(0);
                                        __builder.CloseComponent();
                                    });
                                }

                                // 扩展列
                                if (data is IExpansionModel)
                                {
                                    __builder.AddCascadingValue(ref sequence, (IExpansionModel)data, __builder =>
                                    {
                                        __builder.OpenComponent<BxExpansionColumn<TModel>>(0);
                                        __builder.CloseComponent();
                                    });
                                }

                                __builder.AddContent(sequence++, ChildContent, context);
                            }), data);

                            __builder.CloseElement();


                            if (data is IExpansionModel expansion)
                            {
                                __builder.OpenElement(sequence++, "tr");
                                __builder.AddConfig(ref sequence, new BxComponentConfig(TrConfig, $"bx--expandable-row demo-expanded-td", $"{Id}-tr-expandable-{row}"));
                                __builder.AddAttribute(sequence++, "data-child-row", "true");
                                {
                                    __builder.OpenElement(sequence++, "td");
                                    __builder.AddAttribute(sequence++, "colspan", "7");
                                    {
                                        __builder.OpenElement(sequence++, "div");
                                        __builder.AddAttribute(sequence++, "class", "bx--child-row-inner-container");
                                        __builder.EitherOrAddContent(ref sequence, expansion.ExpansionContentTemplate, expansion.ExpansionContent, () => expansion.ExpansionContentTemplate != null);
                                        __builder.CloseElement();
                                    }
                                    __builder.CloseElement();
                                }
                                __builder.CloseElement();
                            }
                        }
                    }

                    __builder.CloseElement();
                });
            }
        };

        /// <summary>
        /// 选定
        /// </summary>
        /// <param name="model"></param>
        public async Task SelectedRowAsync(object? model)
        {
            if (model is not null && model is TModel item && DataSource is not null && DataSource.Any())
            {
                if (item is ISelectionModel selection && !selection.Selected)
                {
                    selection.Selected = true;
                }

                var items = DataSource.Where(item => item is ISelectionModel selection && selection.Selected).AsEnumerable();
                await OnSelectedChange.InvokeAsync(items);
                if (TableContainer is not null)
                {
                    await TableContainer.ShowBatchAsync(items.Select(item => (object)item));
                }
                await InvokeStateHasChangedAsync();
            }
        }

        /// <summary>
        /// 取消选定
        /// </summary>
        /// <param name="model"></param>
        public async Task DeselectRowAsync(object? model)
        {
            if (model is not null && model is TModel item && DataSource is not null && DataSource.Any())
            {
                if (item is ISelectionModel selection && selection.Selected)
                {
                    selection.Selected = false;
                }

                var items = DataSource.Where(item => item is ISelectionModel selection && selection.Selected).AsEnumerable();
                await OnSelectedChange.InvokeAsync(items);
                if (items.Count() <= 0 && TableContainer is not null)
                {
                    await TableContainer.CloseBatchAsync();
                }
                await InvokeStateHasChangedAsync();
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        public async Task SelectedAllRowAsync()
        {
            if (DataSource is not null && DataSource.Any())
            {
                foreach (var item in DataSource)
                {
                    if (item is ISelectionModel selection && !selection.Selected)
                    {
                        selection.Selected = true;
                    }
                }

                var items = DataSource.Where(item => item is ISelectionModel selection && selection.Selected).AsEnumerable();
                await OnSelectedChange.InvokeAsync(items);
                if (TableContainer is not null)
                {
                    await TableContainer.ShowBatchAsync(items.Select(item => (object)item));
                }
                await InvokeStateHasChangedAsync();
            }
        }

        /// <summary>
        /// 取消全选
        /// </summary>
        public async Task DeselectAllRowAsync()
        {
            if (DataSource is not null && DataSource.Any())
            {
                foreach (var item in DataSource)
                {
                    if (item is ISelectionModel selection && selection.Selected)
                    {
                        selection.Selected = false;
                    }
                }

                var items = DataSource.Where(item => item is ISelectionModel selection && selection.Selected).AsEnumerable();
                if (TableContainer is not null)
                {
                    await TableContainer.CloseBatchAsync();
                }
                await InvokeStateHasChangedAsync();
            }
        }

        /// <summary>
        /// 打开行
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task OpenRowAsync(object? model)
        {
            if (model is not null && model is TModel item)
            {
                if (item is IExpansionModel expansion && !expansion.Expanded)
                {
                    expansion.Expanded = true;
                }
                await OnOpenRow.InvokeAsync(item);
                await InvokeStateHasChangedAsync();
            }
        }

        /// <summary>
        /// 打开列
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CloseRowAsync(object? model)
        {
            if (model is not null && model is TModel item)
            {
                if (item is IExpansionModel expansion && expansion.Expanded)
                {
                    expansion.Expanded = false;
                }
                await OnCloseRow.InvokeAsync(item);
                await InvokeStateHasChangedAsync();
            }
        }

        /// <summary>
        /// 是否全选
        /// </summary>
        /// <returns></returns>
        public bool IsSelectedAll()
        {
            if (typeof(ISelectionModel).IsAssignableFrom(typeof(TModel)) && DataSource is not null && DataSource.Any())
            {
                return DataSource.Count() <= DataSource.Where(item => item is ISelectionModel selection && selection.Selected).Count();
            }
            return false;
        }
    }
}
