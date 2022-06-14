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
    /// 这是一个用于 ExpansionColumn 的 Blazor 组件。  
    /// This is a Blazor component for the ExpansionColumn.
    /// </summary>
    public class BxExpansionColumn<TModel> : BxColumnBase
    {
        /// <summary>
        /// 模型
        /// </summary>
        [CascadingParameter]
        public IExpansionModel? Model { get; set; }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            if (Goal == BxColumGoal.Header)
            {
                __builder.OpenElement(sequence++, "th");
                __builder.AddAttribute(sequence++, "scope", "col");
                __builder.AddConfig(ref sequence, new BxComponentConfig("bx--table-expand", $"{Id}-th-expand"));
            }
            else if (Goal == BxColumGoal.Body)
            {
                __builder.OpenElement(sequence++, "td");
                __builder.AddConfig(ref sequence, new BxComponentConfig(TdConfig ?? this, $"bx--table-expand", $"{Id}-td-expand"));
                __builder.AddAttribute(sequence++, "headers", "expand");
                __builder.IfAddAttribute(ref sequence, "data-previous-value", "collapsed", () => Model is not null && Model.Expanded);
                {
                    __builder.OpenElement(ref sequence, "button", "bx--table-expand__button", $"{Id}-td-button");
                    __builder.AddAttribute(sequence++, "type", "button");
                    __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
                    __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' width='16' height='16' viewBox='0 0 16 16' aria-hidden='true' class='bx--table-expand__svg'><path d='M11 8L6 13 5.3 12.3 9.6 8 5.3 3.7 6 3z'></path></svg>"));
                    __builder.CloseElement();
                }
            }
            __builder.CloseComponent();
        };

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickAsync(MouseEventArgs args)
        {
            if (Table is null || Model is null)
                return;

            if (!Model.Expanded)
            {
                await Table.OpenRowAsync(Model);
            }
            else
            {
                await Table.CloseRowAsync(Model);
            }
        }
    }
}
