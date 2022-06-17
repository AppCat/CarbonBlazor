using CarbonBlazor.Components;
using CarbonBlazor.Doc.Components;
using Microsoft.AspNetCore.Components;

namespace CarbonBlazor.Doc.Pages
{
    /// <summary>
    /// Dropdown 页
    /// </summary>
    [RouteAttribute("dropdown")]
    public class Dropdown : DemoPageBase
    {
        bool _disabled;
        bool _invalid;
        bool _warn;
        string _labelText = "Dropdown title";
        string _helperText = "Optional helper text";
        string _invalidText = "A valid value is required";
        string _warnText = "Optional warn text";
        string _placeholder = "Placeholder text";
        BxListBoxDirection _direction = BxListBoxDirection.Bottom;

        /// <summary>
        /// 获取变体
        /// </summary>
        /// <returns></returns>
        protected override Dictionary<string, Variant> GetVariants()
        {
            RenderFragment component(Type componentType, RenderFragment? options, Dictionary<string, Func<object>>? attribute = null) => __builder =>
            {
                var sequence = 0;

                __builder.OpenComponent(sequence++, componentType);
                __builder.SetKey(Guid.NewGuid());

                foreach (var item in attribute ?? new Dictionary<string, Func<object>>())
                {
                    __builder.AddAttribute(sequence++, item.Key, item.Value.Invoke());
                }

                if(options is not null)
                {
                    __builder.AddAttribute(sequence++, nameof(BxDropdown.ChildContent), options);
                }

                __builder.CloseComponent();
            };

            var share = new Dictionary<string, Func<object>>
            {
                { nameof(BxDropdown.Disabled), () => _disabled },
                { nameof(BxDropdown.Invalid), () => _invalid },
                { nameof(BxDropdown.Warn), () => _warn },
                { nameof(BxDropdown.LabelText), () => _labelText },
                { nameof(BxDropdown.HelperText), () => _helperText },
                { nameof(BxDropdown.InvalidText), () => _invalidText },
                { nameof(BxDropdown.WarnText), () => _warnText },
                { nameof(BxDropdown.Placeholder), () => _placeholder },
                { nameof(BxDropdown.Direction), () => new EnumMix<BxListBoxDirection>(_direction) },
            };

            var options = new[] { "Option 2", "Option 3", "Option 4", "Option 1" };

            var dropdown = new Variant("Dropdown", "Default", typeof(BxDropdown), component(typeof(BxDropdown), __builder =>
            {
                var sequence = 0;

                foreach (var option in options)
                {
                    __builder.OpenComponent<BxDropdownOption>(sequence++);
                    __builder.AddAttribute(sequence++, nameof(BxDropdownOption.Key), option);
                    __builder.CloseComponent();
                }
            }, share));

            var variants = new Dictionary<string, Variant>
            {
                { nameof(dropdown), dropdown },
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
                __builder.AddContent(sequence++, CreateBoolKnob("warn", _warn, __value => _warn = __value).Content);
            });

            var area = new Dictionary<string, Knob>
            {
                { "Modifiers", new Knob{ Content = modifiersContent } },
                { "Direction", CreateEnumKnob<BxListBoxDirection>(_direction, __value => _direction = __value) },
                { "Placeholder", CreateStringKnob(_placeholder, __value => _placeholder = __value!) },
                { "LabelText", CreateStringKnob(_labelText, __value => _labelText = __value!) },
                { "HelperText", CreateStringKnob(_helperText, __value => _helperText = __value!) },
                { "InvalidText", CreateStringKnob(_invalidText, __value => _invalidText = __value!) },
                { "WarnText", CreateStringKnob(_warnText, __value => _warnText = __value!) },
            };

            return area;
        }
    }
}
