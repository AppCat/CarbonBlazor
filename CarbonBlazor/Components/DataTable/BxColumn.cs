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
    /// 数据表列
    /// Columns of a table
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
        public string DisplayName => _propertyReflector?.DisplayName;

        /// <summary>
        /// 属性名称
        /// </summary>
        public string FieldName => _propertyReflector?.PropertyName;

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (FieldExpression != null && FragmentGoal == BxColumFragmentGoal.Header)
            {
                _propertyReflector = PropertyReflector.Create(FieldExpression);
            }
        }

        #endregion

        #region RenderFragment

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            if(FragmentGoal == BxColumFragmentGoal.Header)
            {
                __builder.OpenElement(sequence++, "th");
                __builder.AddAttribute(sequence++, "scope", "col");
                __builder.AddConfig(ref sequence, new BxComponentConfig(ThConfig).AddId($"{Id}-th"));
                __builder.EitherOrAddContent(ref sequence, TitleTemplate, (Title ?? DisplayName ?? FieldName ?? string.Empty), () => TitleTemplate != null);
            }
            else if (FragmentGoal == BxColumFragmentGoal.Body)
            {
                __builder.OpenElement(sequence++, "td");
                __builder.AddComponent(ref sequence, this);
                __builder.AddConfig(ref sequence, new BxComponentConfig(TdConfig).AddId($"{Id}-td"));
                __builder.EitherOrAddContent(ref sequence, ChildContent, (string.IsNullOrEmpty(Format) ? (Field?.ToString() ?? string.Empty) : Formatter<TField>.Format(Field, Format)), () => ChildContent != null);
            }

            __builder.CloseComponent();
        };

        #endregion
    }
}
