using CarbonBlazor.Components;
using CarbonBlazor.Doc.Components;
using Microsoft.AspNetCore.Components;

namespace CarbonBlazor.Doc.Pages
{
    /// <summary>
    /// TextInput 页
    /// </summary>
    [RouteAttribute("textInput")]
    public class TextInput : DemoPageBase
    {
        bool _disabled;
        bool _invalid;
        bool _warn;
        string _placeholder = "Placeholder text";
        string _labelText = "Text input label";
        string _helperText = "Optional helper text";
        string _invalidText = "A valid value is required";
        string _warnText = "Optional warn text";
        bool _quickResponse;
        BxSize _size = BxSize.Md;

        /// <summary>
        /// 获取变体
        /// </summary>
        /// <returns></returns>
        protected override Dictionary<string, Variant> GetVariants()
        {
            RenderFragment component(Dictionary<string, Func<object>>? attribute = null, Type? componentType = null) => __builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "div");
                {
                    __builder.OpenComponent(sequence++, componentType ?? typeof(BxTextInput));
                    foreach (var item in attribute ?? new Dictionary<string, Func<object>>())
                    {
                        __builder.AddAttribute(sequence++, item.Key, item.Value.Invoke());
                    }
                    __builder.CloseComponent();
                }
                __builder.CloseElement();
            };

            var area = new Dictionary<string, Func<object>>
            {
                { nameof(BxTextInput.Disabled), () => _disabled },
                { nameof(BxTextInput.Invalid), () => _invalid },
                { nameof(BxTextInput.QuickResponse), () => _quickResponse },
                { nameof(BxTextInput.Placeholder), () => _placeholder },
                { nameof(BxTextInput.LabelText), () => _labelText },
                { nameof(BxTextInput.HelperText), () => _helperText },
                { nameof(BxTextInput.InvalidText), () => _invalidText }
            };

            var input = new Dictionary<string, Func<object>>(area)
            {
                { nameof(BxTextInput.Warn), () => _warn },
                { nameof(BxTextInput.WarnText), () => _warnText },
                { nameof(BxTextInput.Size), () => new EnumMix<BxSize>(_size) }
            };

            var textInput = new Variant("TextInput", "TextInput", typeof(BxTextInput), component(input));

            var password = new Variant("TextInput", "Password input", typeof(BxTextInput), component(new Dictionary<string, Func<object>>(input) { { nameof(BxTextInput.Type), () => new EnumMix<BxTextInputType>(BxTextInputType.Password) } }));

            var textArea = new Variant("TextArea", "Text area", typeof(BxTextArea), component(area, typeof(BxTextArea)));

            var variants = new Dictionary<string, Variant>
            {
                { nameof(textInput), textInput },
                { nameof(password), password },
                { nameof(textArea), textArea }
            };

            return variants;
        }

        /// <summary>
        /// 获取 Konbs
        /// </summary>
        /// <param name="variant"></param>
        /// <returns></returns>
        protected override Dictionary<string, Knob> GetKnobs(Variant variant)
        {
            var modifiersContent = (RenderFragment)(__builder =>
            {
                var sequence = 0;
                __builder.AddContent(sequence++, CreateBoolKnob("disabled", _disabled, __value => _disabled = __value).Content);
                __builder.AddContent(sequence++, CreateBoolKnob("invalid", _invalid, __value => _invalid = __value).Content);
                if (variant.Type != typeof(BxTextArea))
                {
                    __builder.AddContent(sequence++, CreateBoolKnob("warn", _warn, __value => _warn = __value).Content);
                }
                __builder.AddContent(sequence++, CreateBoolKnob("quickResponse", _quickResponse, __value => _quickResponse = __value).Content);
            });

            var area = new Dictionary<string, Knob>
            {
                { "Modifiers", new Knob{ Content = modifiersContent } },
                { "Placeholder", CreateStringKnob(_placeholder, __value => _placeholder = __value!) },
                { "LabelText", CreateStringKnob(_labelText, __value => _labelText = __value!) },
                { "HelperText", CreateStringKnob(_helperText, __value => _helperText = __value!) },
                { "InvalidText", CreateStringKnob(_invalidText, __value => _invalidText = __value!) },
            };

            var input = new Dictionary<string, Knob>(area)
            {
                { "WarnText", CreateStringKnob(_warnText, __value => _warnText = __value!) },
            };

            return variant.Type == typeof(BxTextInput) ? area : input;
        }
    }
}
