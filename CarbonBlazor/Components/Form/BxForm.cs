using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 Form 的 Blazor 组件。  
    /// This is a Blazor component for the Form.
    /// </summary>
    public partial class BxForm<TModel> : BxContentComponentBase<TModel>, IBxForm
    {
        /// <summary>
        /// 表单项
        /// </summary>
        private IList<IBxField> Fields = new List<IBxField>();

        /// <summary>
        /// 控制值
        /// </summary>
        protected IList<IControlValueAccessor> Controls = new List<IControlValueAccessor>();

        /// <summary>
        /// 编辑上下文
        /// </summary>
        public EditContext EditContext => _editContext;
        private EditContext _editContext;

        /// <summary>
        /// 模型
        /// </summary>
        object IBxForm.Model => Model;

        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--form";

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

            __builder.OpenComponent<EditForm>(sequence++);
            __builder.AddComponent(ref sequence, this);

            __builder.AddAttribute(sequence++, nameof(EditForm.EditContext), _editContext);

            __builder.AddEvent<EditContext>(ref sequence, nameof(EditForm.OnValidSubmit), this, HandleOnValidSubmit);
            __builder.AddEvent<EditContext>(ref sequence, nameof(EditForm.OnInvalidSubmit), this, HandleOnInvalidSubmit);

            __builder.AddAttribute(sequence++, nameof(EditForm.ChildContent), (RenderFragment<EditContext>)(context => __builder =>
            {
                var sequence = 0;

                __builder.OpenComponent<DataAnnotationsValidator>(sequence++);
                __builder.CloseComponent();

                __builder.OpenComponent<CascadingValue<IBxForm>>(sequence++);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<IBxForm>.Value), this);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<IBxForm>.IsFixed), true);

                __builder.AddAttribute(sequence++, nameof(CascadingValue<IBxForm>.ChildContent), (RenderFragment)(__builder =>
                {
                    var sequence = 0;

                    if (Auto && Model != null)
                    {
                        __builder.AddContent(sequence++, AuotGenerateFields());
                    }

                    if (ChildContent != null && Model != null)
                    {
                        __builder.AddContent(sequence++, ChildContent, Model);
                    }

                }));

                __builder.CloseComponent();
            }));

            __builder.CloseComponent();
        };

        /// <summary>
        /// 自动生成表单项
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment AuotGenerateFields() => __builder =>
        {
            var type = typeof(TModel);
            var properties = type
                .GetProperties()
                .OrderByDescending(propertie => propertie.GetCustomAttribute<DisplayAttribute>()?.GetOrder() ?? 0)
                ;

            RenderFragment field(PropertyInfo property) => __builder =>
            {
                var sequence = 0;

                var value = property.GetValue(Model);
                var name = property.GetCustomAttribute<DisplayAttribute>()?.GetName() ??
                property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? property.Name;
                var required = property.GetCustomAttributes(typeof(RequiredAttribute), true).Any();
                var readOnly = (property.GetCustomAttribute<ReadOnlyAttribute>()?.IsReadOnly ?? false) || !property.CanWrite;
                var underlyingType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                if (underlyingType.IsEnum)
                {
                    var names = underlyingType.GetEnumDisplayNames();

                    __builder.OpenComponent<BxSelect>(sequence++);
                    __builder.AddAttribute(sequence++, nameof(BxSelect.LabelText), name);
                    __builder.AddAttribute(sequence++, nameof(BxSelect.SelectedKeys), new string[] { value?.ToString() });
                    __builder.AddAttribute(sequence++, nameof(BxSelect.Disabled), readOnly);
                    if (property.CanWrite && !readOnly)
                    {
                        __builder.AddEvent<string[]>(ref sequence, nameof(BxSelect.OnSelectedKeysChange), this, keys =>
                        {
                            if (keys?.Any() ?? false)
                            {
                                property.SetValue(Model, Enum.Parse(underlyingType, keys[0]));
                            }
                            else if (underlyingType != property.PropertyType)
                            {
                                property.SetValue(Model, null);
                            }
                        });
                    }

                    __builder.AddAttribute(sequence++, nameof(BxSelect.ChildContent), (RenderFragment)(__builder =>
                    {
                        foreach (var name in names)
                        {
                            __builder.OpenComponent<BxSelectOption>(sequence++);
                            __builder.AddAttribute(sequence++, nameof(BxSelectOption.Key), name.Key);
                            __builder.AddAttribute(sequence++, nameof(BxSelectOption.Value), name.Value);
                            __builder.CloseComponent();
                        }
                    }));

                    __builder.CloseComponent();
                }
                else
                {
                    var isNullable = property.PropertyType == typeof(Nullable<>) || underlyingType != property.PropertyType;
                    var typeCode = Type.GetTypeCode(underlyingType);

                    var numberCodes = new TypeCode[]
                    {
                        TypeCode.Char,
                        TypeCode.SByte,
                        TypeCode.Byte,
                        TypeCode.Int16,
                        TypeCode.UInt16,
                        TypeCode.Int32,
                        TypeCode.UInt32,
                        TypeCode.Int64,
                        TypeCode.UInt64,
                        TypeCode.Single,
                        TypeCode.Double,
                        TypeCode.Decimal
                    };

                    if (numberCodes.Contains(typeCode))
                    {
                        //if (isNullable)
                        //{
                        //    __builder.OpenComponent<BxNumberInput<decimal?>>(sequence++);
                        //}
                        //else
                        //{
                        //    __builder.OpenComponent<BxNumberInput<decimal>>(sequence++);
                        //}

                        __builder.AddAttribute(sequence++, nameof(BxNumberInput<decimal>.ReadOnly), readOnly);
                        __builder.AddAttribute(sequence++, nameof(BxNumberInput<decimal>.LabelText), name);
                        __builder.AddAttribute(sequence++, nameof(BxNumberInput<decimal>.Value), value != null ? Convert.ChangeType(value, typeof(decimal)) : null);

                        if (property.CanWrite && !readOnly)
                        {
                            if (isNullable)
                            {
                                //__builder.AddEvent<decimal>(ref sequence, nameof(BxNumberInput<Nullable<decimal>>.ValueChanged), this, value => property.SetValue(Model, Convert.ChangeType(value, typeCode)));
                            }
                            else
                            {
                                __builder.AddEvent<decimal>(ref sequence, nameof(BxNumberInput<decimal>.ValueChanged), this, value => property.SetValue(Model, Convert.ChangeType(value, typeCode)));
                            }
                        }


                        //__builder.CloseComponent();
                    }
                    else if (typeCode == TypeCode.String)
                    {
                        __builder.OpenComponent<BxTextInput>(sequence++);
                        __builder.AddAttribute(sequence++, nameof(BxTextInput.ReadOnly), readOnly);
                        __builder.AddAttribute(sequence++, nameof(BxTextInput.LabelText), name);
                        __builder.AddAttribute(sequence++, nameof(BxTextInput.Value), value);
                        if (property.CanWrite && !readOnly)
                        {
                            __builder.AddEvent<string>(ref sequence, nameof(BxTextInput.ValueChanged), this, value => property.SetValue(Model, value));
                        }
                        __builder.CloseComponent();
                    }
                    else if (underlyingType == typeof(Guid))
                    {
                        __builder.OpenComponent<BxTextInput>(sequence++);
                        __builder.AddAttribute(sequence++, nameof(BxTextInput.ReadOnly), readOnly);
                        __builder.AddAttribute(sequence++, nameof(BxTextInput.LabelText), name);
                        __builder.AddAttribute(sequence++, nameof(BxTextInput.Value), value?.ToString());
                        if (property.CanWrite && !readOnly)
                        {
                            __builder.AddEvent<string>(ref sequence, nameof(BxTextInput.ValueChanged), this, value => property.SetValue(Model, value == null ? Guid.Empty : Guid.TryParse(value.ToString(), out Guid guid) ? guid : Guid.Empty));
                        }
                        __builder.CloseComponent();
                    }
                    else if (typeCode == TypeCode.Boolean)
                    {
                        __builder.OpenComponent<BxCheckbox>(sequence++);
                        __builder.AddAttribute(sequence++, nameof(BxCheckbox.ReadOnly), readOnly);
                        __builder.AddAttribute(sequence++, nameof(BxCheckbox.LabelText), name);
                        __builder.AddAttribute(sequence++, nameof(BxCheckbox.Value), value ?? false);
                        if (property.CanWrite && !readOnly)
                        {
                            __builder.AddEvent<bool>(ref sequence, nameof(BxCheckbox.ValueChanged), this, value => property.SetValue(Model, value));
                        }
                        __builder.CloseComponent();
                    }
                }
            };

            var sequence = 0;

            __builder.OpenComponent<BxStack>(sequence++);
            __builder.AddAttribute(sequence++, nameof(BxStack.Scale), new EnumMix<BxStackScale>(BxStackScale.Seven));

            __builder.AddAttribute(sequence++, nameof(BxStack.ChildContent), (RenderFragment)(__builder =>
            {
                var sequence = 0;

                foreach (var propertie in properties)
                {
                    if (!propertie.CanRead || !propertie.CanWrite)
                        continue;
                    if (!(propertie.GetCustomAttribute<DisplayAttribute>()?.GetAutoGenerateField() ?? true))
                        continue;

                    __builder.AddContent(sequence++, field(propertie));
                }

            }));

            __builder.CloseComponent();
        };

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            foreach (var control in Controls)
            {
                control.Reset();
            }
            _editContext = new EditContext(Model);
            OnReset.InvokeAsync(_editContext);
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Submit()
        {
            var isValid = Validate();
            if (isValid && OnFinish.HasDelegate)
                OnFinish.InvokeAsync(_editContext);
            else if (OnFailed.HasDelegate)
                OnFailed.InvokeAsync(_editContext);
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return _editContext?.Validate() ?? false;
        }

        /// <summary>
        /// 添加表单项
        /// </summary>
        /// <param name="field"></param>
        void IBxForm.AddFormItem(IBxField field)
        {
            Fields.Add(field);
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="valueAccessor"></param>
        void IBxForm.AddControl(IControlValueAccessor valueAccessor)
        {
            Controls.Add(valueAccessor);
        }

        #region Handle

        /// <summary>
        /// 在有效的提交
        /// </summary>
        /// <param name="editContext"></param>
        /// <returns></returns>
        private async Task HandleOnValidSubmit(EditContext editContext)
        {
            await OnFinish.InvokeAsync(editContext);
        }

        /// <summary>
        /// 在无效的提交
        /// </summary>
        /// <param name="editContext"></param>
        /// <returns></returns>
        private async Task HandleOnInvalidSubmit(EditContext editContext)
        {
            foreach (var messages in editContext.GetValidationMessages())
            {
                Console.WriteLine(messages);
            }
            await OnFailed.InvokeAsync(editContext);
        }

        #endregion

        #region SDLC



        #endregion
    }
}
