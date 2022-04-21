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
    /// 数据表
    /// Data table
    /// </summary>
    public partial class BxDataTable<TModel> : BxContentComponentBase<TModel>
    {
        /// <summary>
        /// 模型
        /// </summary>
        protected static readonly TModel Model = (TModel)RuntimeHelpers.GetUninitializedObject(typeof(TModel));

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = "bx--data-table";
            ClassMapper
                .Clear()
                .Add(fixedClass)
                .If("bx--data-table--zebra", () => Zebra)
                .If("bx--data-table--static", () => Static)
                .If("bx--data-table--sticky-header", () => StickyHeader)
                .AddEnum(Size)
                ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "table");
            __builder.AddComponent(ref sequence, this);

            __builder.AddContent(sequence++, THeaderFragment());
            __builder.AddContent(sequence++, TBodyFragment());

            __builder.CloseComponent();
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

            __builder.OpenComponent<CascadingValue<ICascadingDataTableParameters>>(sequence++);
            __builder.AddAttribute(sequence++, nameof(CascadingValue<ICascadingDataTableParameters>.IsFixed), true);
            __builder.AddAttribute(sequence++, nameof(CascadingValue<ICascadingDataTableParameters>.Value), this);
            __builder.AddAttribute(sequence++, nameof(CascadingValue<ICascadingDataTableParameters>.ChildContent), (RenderFragment)(__builder =>
            {
                var sequence = 0;

                __builder.OpenComponent<CascadingValue<BxColumFragmentGoal>>(sequence++);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<BxColumFragmentGoal>.IsFixed), true);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<BxColumFragmentGoal>.Value), BxColumFragmentGoal.Header);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<BxColumFragmentGoal>.ChildContent), (RenderFragment)(__builder =>
                {
                    var sequence = 0;

                    __builder.OpenElement(sequence++, "thead");
                    {
                        __builder.OpenElement(sequence++, "tr");

                        __builder.AddContent(sequence++, (RenderFragment<TModel>)(context => __builder =>
                        {
                            var sequence = 0;

                            if(WithSelection)
                            {
                                __builder.OpenComponent<BxSelectionColumn>(sequence++);
                                __builder.CloseComponent();
                            }
                            
                            __builder.AddContent(sequence++, ChildContent, context);
                        }), Model);

                        __builder.CloseElement();
                    }

                    __builder.CloseElement();
                }));

                __builder.CloseComponent();
            }));

            __builder.CloseComponent();
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
                __builder.OpenComponent<CascadingValue<BxColumFragmentGoal>>(sequence++);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<BxColumFragmentGoal>.IsFixed), true);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<BxColumFragmentGoal>.Value), BxColumFragmentGoal.Body);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<BxColumFragmentGoal>.ChildContent), (RenderFragment)(__builder =>
                {
                    var sequence = 0;
                    __builder.OpenElement(sequence++, "tbody");

                    if (ChildContent != null && DataSource != null && DataSource.Any())
                    {
                        foreach (var data in DataSource)
                        {
                            __builder.OpenElement(sequence++, "tr");

                            __builder.AddContent(sequence++, (context => __builder =>
                            {
                                var sequence = 0;

                                if (WithSelection)
                                {
                                    if (WithSelection)
                                    {
                                        __builder.OpenComponent<BxSelectionColumn>(sequence++);
                                        __builder.CloseComponent();
                                    }
                                }
                                __builder.AddContent(sequence++, ChildContent, context);
                            }), data);

                            __builder.CloseElement();

                            //__builder.OpenElement(sequence++, "tr");
                            //__builder.AddContent(sequence++, ChildContent, data);
                            //__builder.CloseElement();
                        }
                    }

                    __builder.CloseElement();
                }));

                __builder.CloseComponent();
            }
        };
    }
}
