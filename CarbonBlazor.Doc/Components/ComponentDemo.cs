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
        public Dictionary<string, Variant>? Variants { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public Func<Variant, Dictionary<string, Knob>>? OnKnobs { get; set; }

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
                    if(Variants != null && Variants.Count == 1)
                    {
                        CurrentVariant = Variants.FirstOrDefault().Key;
                    }
                    else
                    {
                        builder.OpenComponent<BxDropdown>(sequence++);
                        builder.AddAttribute(sequence++, nameof(BxDropdown.Size), new EnumMix<BxSize>(BxSize.Lg));
                        builder.AddAttribute(sequence++, nameof(BxDropdown.LabelText), "Variant selector");
                        builder.AddAttribute(sequence++, nameof(BxDropdown.Class), "component-demo-module--variantDropdown");
                        builder.AddAttribute(sequence++, nameof(BxDropdown.SelectedKey), BindConverter.FormatValue(CurrentVariant));
                        builder.AddAttribute(sequence++, nameof(BxDropdown.SelectedKeyChanged), EventCallback.Factory.Create<string>(this, __value => CurrentVariant = __value));
                        builder.AddAttribute(sequence++, nameof(BxDropdown.ChildContent), (RenderFragment)(__builder =>
                        {
                            var sequence = 0;

                            foreach (var variant in Variants ?? new Dictionary<string, Variant>())
                            {
                                __builder.OpenComponent<BxDropdownOption>(sequence++);
                                __builder.AddAttribute(sequence++, nameof(BxDropdownOption.Key), variant.Key);
                                __builder.AddAttribute(sequence++, nameof(BxDropdownOption.Value), variant.Value.Details);
                                __builder.CloseComponent();
                            }
                        }));
                        builder.CloseComponent();
                    }
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
                        if (!string.IsNullOrEmpty(CurrentVariant) && (Variants?.Any() ?? false) && Variants.TryGetValue(CurrentVariant, out Variant? variant) && variant is not null)
                        {
                            var propertys = OnKnobs?.Invoke(variant) ?? new Dictionary<string, Knob>();

                            // preview container Start
                            builder.OpenElement(ref sequence, "div", string.IsNullOrEmpty(CurrentTheme) ? "component-demo-module--preview-container" : $"component-demo-module--preview-container {CurrentTheme}");
                            {
                                if(variant.Content != null)
                                {
                                    builder.AddContent(sequence++, variant.Content);
                                }
                            }
                            builder.CloseElement();
                            // preview container End

                            // codeRow Start
                            builder.OpenElement(ref sequence, "div", "code-module--row component-demo-module--codeRow");
                            {
                                builder.OpenElement(ref sequence, "div", "code-module--container");
                                {
                                    builder.OpenElement(ref sequence, "div", "component-demo-module--editor-container");
                                    builder.AddAttribute(sequence++, "style", "overflow-x:auto;white-space:pre;min-height: 200px;");
                                    {
                                        builder.OpenElement(ref sequence, "pre");
                                        {
                                            builder.OpenElement(ref sequence, "code", "language-razor");
                                            builder.AddContent(sequence++, "<BxCheckbox Disabled Checked></BxCheckbox>");
                                            builder.CloseElement();
                                        }
                                        builder.CloseElement();
                                    }
                                    builder.CloseElement();
                                }
                                builder.CloseElement();
                            }
                            builder.CloseElement();
                            // codeRow End

                            // knob container Start
                            builder.OpenElement(ref sequence, "form", "bx--form component-demo-module--knob-container");
                            {
                                builder.OpenElement(ref sequence, "div", "component-demo-module--knob-title");
                                builder.AddContent(sequence++, variant.Nmae ?? variant.Type.Name);
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

                                            builder.AddContent(sequence++, property.Value.Content);
                                        }
                                        builder.CloseElement();
                                    }
                                }
                                builder.CloseElement();
                                // container End
                            }
                            builder.CloseElement();
                            // knob container End

                            // zamboni Start
                            builder.AddContent(sequence++, new MarkupString("<span class='component-demo-module--zamboni'></span>"));
                            // zamboni End
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
