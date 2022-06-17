using CarbonBlazor.Components;
using CarbonBlazor.Doc.Components;
using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace CarbonBlazor.Doc.Pages
{
    /// <summary>
    /// Demo 页基础
    /// </summary>
    public abstract class DemoPageBase : ComponentBase
    {
        /// <summary>
        /// 获取 Knobs
        /// </summary>
        /// <param name="variant"></param>
        protected abstract Dictionary<string, Knob> GetKnobs(Variant variant);

        /// <summary>
        /// 获取 变体
        /// </summary>
        /// <returns></returns>
        protected abstract Dictionary<string, Variant> GetVariants();

        /// <summary>
        /// 创建 bool 类型的 Knob
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        protected Knob CreateBoolKnob(string name, bool value, Action<bool> set)
        {
            RenderFragment content = __builder =>
            {
                var sequence = 0;

                __builder.OpenComponent(sequence++, typeof(BxCheckbox));
                __builder.SetKey(Guid.NewGuid());
                __builder.AddAttribute(sequence++, nameof(BxCheckbox.Value), value);
                __builder.AddAttribute(sequence++, nameof(BxCheckbox.ValueChanged), EventCallback.Factory.Create<bool>(this, set));
                __builder.AddAttribute(sequence++, nameof(BxCheckbox.LabelText), name);
                __builder.CloseComponent();
            };

            return new Knob
            {
                Content = content
            };
        }

        /// <summary>
        /// 创建 enum 类型的 Knob
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="set"></param>
        /// <param name="ignores"></param>
        /// <returns></returns>
        protected Knob CreateEnumKnob<TEnum>(TEnum value, Action<TEnum> set, TEnum[]? ignores = null)
        {
            RenderFragment content = __builder =>
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
                                var value = __value?.Value?.ToString();
                                if (string.IsNullOrEmpty(value))
                                    return;
                                var @enum = (TEnum)Enum.Parse(typeof(TEnum), value);
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

            return new Knob
            {
                Content = content
            };
        }

        /// <summary>
        /// 创建 string 类型 Knob
        /// </summary>
        /// <param name="value"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        protected Knob CreateStringKnob(string? value, Action<string?> set)
        {
            RenderFragment content = __builder =>
            {
                var sequence = 0;

                __builder.OpenComponent(sequence++, typeof(BxTextInput));
                __builder.SetKey(Guid.NewGuid());
                __builder.AddAttribute(sequence++, nameof(BxTextInput.Value), value);
                //__builder.AddAttribute(sequence++, nameof(BxTextInput.QuickResponse), true);
                __builder.AddAttribute(sequence++, nameof(BxTextInput.ValueChanged), EventCallback.Factory.Create<string>(this, set));
                __builder.CloseComponent();
            };

            return new Knob
            {
                Content = content
            };
        }

        /// <summary>
        /// 渲染树
        /// </summary>
        /// <param name="builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var sequence = 0;

            builder.OpenElement(sequence++, "div");
            builder.AddAttribute(sequence++, "style", "max-width: 1300px;");
            {
                builder.OpenComponent<ComponentDemo>(sequence++);
                builder.AddAttribute(sequence++, nameof(ComponentDemo.Variants), GetVariants());
                builder.AddAttribute(sequence++, nameof(ComponentDemo.OnKnobs), GetKnobs);
                builder.CloseComponent();
            }
            builder.CloseElement();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
