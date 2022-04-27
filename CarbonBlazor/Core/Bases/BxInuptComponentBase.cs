using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 可选地支持的任何输入控件的基类
    /// </summary>
    public abstract class BxInuptComponentBase<TValue> : BxComponentBase, IControlValueAccessor
    {
        /// <summary>
        /// Gets the <see cref="FieldIdentifier"/> for the bound value.
        /// </summary>
        internal FieldIdentifier FieldIdentifier { get; set; }       

        #region CascadingParameter

        /// <summary>
        /// 编辑上下文
        /// </summary>
        [CascadingParameter]
        protected EditContext? EditContext { get; set; }

        ///// <summary>
        ///// 表单
        ///// </summary>
        //[CascadingParameter]
        //protected IVForm? Form { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        [CascadingParameter(Name = "FieldName")]
        protected string? FieldName { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// 获取或设置值 used with two-way binding.
        /// </summary>
        /// <example>
        /// @bind-Value="model.PropertyName"
        /// </example>
        [Parameter]
        public virtual TValue? Value
        {
            get => _value;
            set
            {
                var hasChanged = !EqualityComparer<TValue>.Default.Equals(value, _value);
                if (hasChanged)
                {
                    _value = value;
                    if (ValueChanged.HasDelegate)
                    {
                        ValueChanged.InvokeAsync(_value).Wait();
                    }
                    if (FieldIdentifier.FieldName != null && FieldIdentifier.Model != null && EditContext != null)
                    {
                        EditContext?.NotifyFieldChanged(FieldIdentifier);
                    }
                }
            }
        }
        private TValue? _value;

        /// <summary>
        /// 第一次值
        /// </summary>
        protected TValue? FirstValue { get; set; }

        /// <summary>
        /// Gets or sets a callback that updates the bound value.
        /// </summary>
        [Parameter]
        public virtual EventCallback<TValue> ValueChanged { get; set; }

        /// <summary>
        /// Gets or sets an expression that identifies the bound value.
        /// </summary>
        [Parameter]
        public Expression<Func<TValue>>? ValueExpression { get; set; }

        /// <summary>
        /// 只读
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; }

        #endregion

        /// <summary>
        /// 重置
        /// </summary>
        public virtual void Reset()
        {
            Value = FirstValue;
            StateHasChanged();
        }

        /// <summary>
        /// 初始化后
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            FirstValue = Value;
            //Form?.AddControl(this);
            if (EditContext != null)
            {
                if (ValueExpression != null)
                    FieldIdentifier = FieldIdentifier.Create(ValueExpression);
                else if (!string.IsNullOrEmpty(FieldName))
                {
                    FieldIdentifier = EditContext.Field(FieldName);
                }
            }
        }
    }
}
