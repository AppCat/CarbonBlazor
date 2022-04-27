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
    /// 这是一个用于 BxColumn 的 Blazor 组件。  
    /// This is a Blazor component for the BxColumn.
    /// </summary>
    public partial class BxColumn<TField> : BxColumnBase
    {
        /// <summary>
        /// 属性反射器
        /// </summary>
        private PropertyReflector? _propertyReflector { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName => _propertyReflector?.DisplayName ?? string.Empty;

        /// <summary>
        /// 属性名称
        /// </summary>
        public string FieldName => _propertyReflector?.PropertyName ?? string.Empty;

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
                __builder.AddConfig(ref sequence, new BxComponentConfig(ThConfig).AddId($"{Id}-th"));

                __builder.OpenElement(sequence++, "span");
                __builder.AddAttribute(sequence++, "class", $"bx--table-header-label");
                __builder.EitherOrAddContent(ref sequence, TitleTemplate, (Title ?? DisplayName ?? FieldName ?? string.Empty), () => TitleTemplate != null);
                __builder.CloseComponent();

            }
            else if (Goal == BxColumGoal.Body)
            {
                __builder.OpenElement(sequence++, "td");
                __builder.AddConfig(ref sequence, new BxComponentConfig(TdConfig ?? this).AddId($"{Id}-td"));
                __builder.EitherOrAddContent(ref sequence, ChildContent, (string.IsNullOrEmpty(Format) ? (Field?.ToString() ?? string.Empty) : Formatter<TField>.Format(Field, Format)), () => ChildContent != null);
            }

            __builder.CloseComponent();
        };

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (FieldExpression != null && Goal == BxColumGoal.Header)
            {
                _propertyReflector = PropertyReflector.Create(FieldExpression);
            }
        }

        #endregion
    }
}
