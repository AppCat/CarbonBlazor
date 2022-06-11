using CarbonBlazor.Components;
using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;

namespace CarbonBlazor.Doc.Pages
{
    /// <summary>
    /// Demo 页基础
    /// </summary>
    public class DemoPageBase : ComponentBase
    {
        //protected abstract 

        /// <summary>
        /// 创建 bool 类型的 Knob
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        protected RenderFragment CreateBoolKnob(string name, bool value, Action<bool> set) => __builder =>
        {
            var sequence = 0;

            __builder.OpenComponent(sequence++, typeof(BxCheckbox));
            __builder.SetKey(Guid.NewGuid());
            __builder.AddAttribute(sequence++, nameof(BxCheckbox.Value), value);
            __builder.AddAttribute(sequence++, nameof(BxCheckbox.ValueChanged), EventCallback.Factory.Create<bool>(this, set));
            __builder.AddAttribute(sequence++, nameof(BxCheckbox.LabelText), name);
            __builder.CloseComponent();
        };

        /// <summary>
        /// 创建 enum 类型的 Knob
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="set"></param>
        /// <param name="ignores"></param>
        /// <returns></returns>
        protected RenderFragment CreateEnumKnob<TEnum>(TEnum value, Action<TEnum> set, TEnum[]? ignores = null) => __builder =>
        {
            var sequence = 0;
            var type = typeof(TEnum);


            __builder.OpenElement(ref sequence, "div", "bx--form-item");
            {
                __builder.OpenElement(ref sequence, "fieldset", "bx--radio-button-group bx--radio-button-group--vertical bx--radio-button-group--label-right");
                var enumNames = Enum.GetNames(type);

                foreach (var enumName in enumNames)
                {
                    var @enum = (TEnum)Enum.Parse(type, enumName);
                    if (ignores?.Contains(@enum) ?? false)
                        continue;

                    var id = Guid.NewGuid().ToString("N");
                    __builder.OpenElement(ref sequence, "div", "bx--radio-button-wrapper");
                    {
                        __builder.OpenElement(ref sequence, "input", "bx--radio-button", id);
                        __builder.AddAttribute(sequence++, "name", type.Name);
                        __builder.AddAttribute(sequence++, "type", "radio");
                        __builder.AddAttribute(sequence++, "value", @enum);
                        __builder.AddAttribute(sequence++, "checked", EqualityComparer<TEnum>.Default.Equals(value, @enum));
                        __builder.AddAttribute(sequence++, "onchange", EventCallback.Factory.Create<ChangeEventArgs>(this, __value =>
                        {
                            var @enum = (TEnum)Enum.Parse(typeof(TEnum), __value.Value.ToString());
                            set?.Invoke(@enum);
                        }));
                        __builder.CloseElement();

                        __builder.OpenElement(ref sequence, "label", "bx--radio-button__label");
                        __builder.AddAttribute(sequence++, "for", id);
                        __builder.AddContent(sequence++, new MarkupString($"<span class='bx--radio-button__appearance'></span><span class='' dir='auto'>{enumName}</span>"));
                        __builder.CloseElement();
                    }
                    __builder.CloseElement();
                }

                __builder.CloseElement();
            }
            __builder.CloseElement();
        };
    }
}
