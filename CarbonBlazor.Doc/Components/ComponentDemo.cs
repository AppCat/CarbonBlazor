using CarbonBlazor.Components;
using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Reflection;

namespace CarbonBlazor.Doc.Components
{
    /// <summary>
    /// 组件 Demo
    /// </summary>
    public class ComponentDemo : ComponentBase
    {
        /// <summary>
        /// 主题
        /// </summary>
        [Parameter]
        public Dictionary<string, string> Themes { get; set; } = new Dictionary<string, string>
        {
            { "bx--white", "White" },
            { "bx--g10", "Gray 10" },
            { "bx--g90", "Gray 90" },
            { "bx--g100", "Gray 100" }
        };

        /// <summary>
        /// 变体型
        /// </summary>
        [Parameter]
        public Dictionary<string, (Type type, string value, RenderFragment? renderFragment)>? Variants { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public Func<Type, Dictionary<string, RenderFragment>>? Knob { get; set; }

        /// <summary>
        /// 当前主题
        /// </summary>
        protected string? CurrentTheme { get; set; }

        /// <summary>
        /// 默认变体型
        /// </summary>
        protected string? CurrentVariant { get; set; }

        /// <summary>
        /// 构建渲染树
        /// </summary>
        /// <param name="builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var sequence = 0;

            builder.OpenElement(sequence++, "div");
            {
                // dropdownRow Start
                builder.OpenElement(ref sequence, "div", "bx--row component-demo-module--dropdownRow");
                {
                    // Theme selector Start
                    builder.OpenComponent<BxDropdown>(sequence++);
                    builder.AddAttribute(sequence++, nameof(BxDropdown.Size), new EnumMix<BxSize>(BxSize.Lg));
                    builder.AddAttribute(sequence++, nameof(BxDropdown.LabelText), "Theme selector");
                    builder.AddAttribute(sequence++, nameof(BxDropdown.SelectedKey), BindConverter.FormatValue(CurrentTheme));
                    builder.AddAttribute(sequence++, nameof(BxDropdown.SelectedKeyChanged), EventCallback.Factory.Create<string>(this, __value => CurrentTheme = __value));
                    builder.AddAttribute(sequence++, nameof(BxDropdown.ChildContent), (RenderFragment)(__builder =>
                    {
                        var sequence = 0;

                        foreach (var theme in Themes)
                        {
                            __builder.OpenComponent<BxDropdownOption>(sequence++);
                            __builder.AddAttribute(sequence++, nameof(BxDropdownOption.Key), theme.Key);
                            __builder.AddAttribute(sequence++, nameof(BxDropdownOption.Value), theme.Value);
                            __builder.CloseComponent();
                        }
                    }));
                    builder.CloseComponent();
                    // Theme selector End

                    // Variant selector Start
                    builder.OpenComponent<BxDropdown>(sequence++);
                    builder.AddAttribute(sequence++, nameof(BxDropdown.Size), new EnumMix<BxSize>(BxSize.Lg));
                    builder.AddAttribute(sequence++, nameof(BxDropdown.LabelText), "Variant selector");
                    builder.AddAttribute(sequence++, nameof(BxDropdown.Class), "component-demo-module--variantDropdown");
                    builder.AddAttribute(sequence++, nameof(BxDropdown.SelectedKey), BindConverter.FormatValue(CurrentVariant));
                    builder.AddAttribute(sequence++, nameof(BxDropdown.SelectedKeyChanged), EventCallback.Factory.Create<string>(this, __value => CurrentVariant = __value));
                    builder.AddAttribute(sequence++, nameof(BxDropdown.ChildContent), (RenderFragment)(__builder =>
                    {
                        var sequence = 0;

                        foreach (var variant in Variants ?? new Dictionary<string, (Type type, string value, RenderFragment? renderFragment)>())
                        {
                            __builder.OpenComponent<BxDropdownOption>(sequence++);
                            __builder.AddAttribute(sequence++, nameof(BxDropdownOption.Key), variant.Key);
                            __builder.AddAttribute(sequence++, nameof(BxDropdownOption.Value), variant.Value.Item2);
                            __builder.CloseComponent();
                        }
                    }));
                    builder.CloseComponent();
                    // Variant selector End
                }
                builder.CloseElement();
                // dropdownRow End

                builder.OpenElement(ref sequence, "div", "bx--row");
                builder.AddAttribute(sequence++, "style", "background-color: var(--bx-field);");
                {
                    // container Start
                    builder.OpenElement(ref sequence, "div", "component-demo-module--container");
                    {
                        if (!string.IsNullOrEmpty(CurrentVariant) && (Variants?.Any() ?? false) && Variants.TryGetValue(CurrentVariant, out (Type type, string value, RenderFragment? renderFragment) variant))
                        {
                            var propertys = Knob?.Invoke(variant.type) ?? new Dictionary<string, RenderFragment>();

                            // preview Start
                            builder.OpenElement(ref sequence, "div", string.IsNullOrEmpty(CurrentTheme) ? "component-demo-module--preview-container" : $"component-demo-module--preview-container {CurrentTheme}");
                            {
                                if(variant.renderFragment != null)
                                {
                                    builder.AddContent(sequence++, variant.renderFragment);
                                }
                            }
                            builder.CloseElement();
                            // preview End

                            // container Start
                            builder.OpenElement(ref sequence, "form", "bx--form component-demo-module--knob-container");
                            {
                                builder.OpenElement(ref sequence, "div", "component-demo-module--knob-title");
                                builder.AddContent(sequence++, variant.type.Name);
                                builder.CloseElement();

                                // container Start
                                builder.OpenElement(ref sequence, "div", "component-demo-module--knob-wrapper");
                                {
                                    foreach (var property in propertys)
                                    {
                                        builder.OpenElement(ref sequence, "fieldset", "bx--fieldset component-demo-module--form-group");
                                        {
                                            builder.OpenElement(ref sequence, "legend", "bx--label");
                                            builder.AddContent(sequence++, property.Key);
                                            builder.CloseElement();

                                            builder.AddContent(sequence++, property.Value);
                                        }
                                        builder.CloseElement();
                                    }
                                }
                                builder.CloseElement();
                                // container End
                            }
                            builder.CloseElement();
                            // container End
                        }
                    }
                    builder.CloseElement();
                    // container End
                }
                builder.CloseElement();
            }
            builder.CloseComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnInitialized()
        {
            if (string.IsNullOrEmpty(CurrentTheme) && (Themes?.Any() ?? false))
            {
                CurrentTheme = Themes.Keys.First();
            }

            if (string.IsNullOrEmpty(CurrentVariant) && (Variants?.Any() ?? false))
            {
                CurrentVariant = Variants.Keys.First();
            }

            base.OnInitialized();
        }
    }
}
