using CarbonBlazor.Components;
using CarbonBlazor.Doc.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;

namespace CarbonBlazor.Doc.Pages
{
    /// <summary>
    /// 按钮页
    /// </summary>
    [RouteAttribute("button")]
    public class Button : DemoPageBase
    {
        BxButtonKind _kind = BxButtonKind.Primary;
        BxButtonSize _size = BxButtonSize.Md;
        bool _disabled;
        bool _isExpressive;
        bool _loading;
        string content;

        /// <summary>
        /// 获取变体
        /// </summary>
        /// <returns></returns>
        protected override Dictionary<string, Variant> GetVariants()
        {
            RenderFragment buttonFragment(Dictionary<string, Func<object>>? attribute = null, RenderFragment? content = null) => __builder =>
            {
                var key = Guid.NewGuid();
                var sequence = 0;

                __builder.OpenComponent(sequence++, typeof(BxButton));
                __builder.SetKey(key);
                foreach (var item in attribute ?? new Dictionary<string, Func<object>>())
                {
                    __builder.AddAttribute(sequence++, item.Key, item.Value.Invoke());
                }
                __builder.AddAttribute(sequence++, nameof(BxButton.ChildContent), content);
                __builder.CloseComponent();
            };

            var share = new Dictionary<string, Func<object>>
            {
                { nameof(BxButton.Disabled), () => _disabled },
                { nameof(BxButton.IsExpressive), () => _isExpressive },
                { nameof(BxButton.Loading), () => _loading },
                { nameof(BxButton.Size), () => new EnumMix<BxButtonSize>(_size) },
                { nameof(BxButton.Kind), () => new EnumMix<BxButtonKind>(_kind) },
            };

            var button = new Variant("Button", "Button", typeof(BxButton), buttonFragment(share, (__builder =>
            {
                var sequence = 0;
                __builder.AddContent(sequence++, "Button");
            })));

            var buttonWithIcon = new Variant("Button", "Button with icon", typeof(BxButton), buttonFragment(share, (__builder =>
            {
                var sequence = 0;
                __builder.AddContent(sequence++, "Button");
                __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' aria-hidden='true' width='16' height='16' viewBox='0 0 32 32' class='bx--btn__icon'><path d='M17 15L17 8 15 8 15 15 8 15 8 17 15 17 15 24 17 24 17 17 24 17 24 15z'></path></svg>"));
            })));

            var iconOnly = new Variant("Button", "Icon only", typeof(BxButton), buttonFragment(new Dictionary<string, Func<object>>(share) { { nameof(BxButton.HasIconOnly), () => true } }, (__builder =>
            {
                var sequence = 0;
                __builder.AddContent(sequence++, new MarkupString("<svg focusable='false' preserveAspectRatio='xMidYMid meet' xmlns='http://www.w3.org/2000/svg' fill='currentColor' aria-hidden='true' width='16' height='16' viewBox='0 0 32 32' class='bx--btn__icon'><path d='M17 15L17 8 15 8 15 15 8 15 8 17 15 17 15 24 17 24 17 17 24 17 24 15z'></path></svg>"));
            })));

            var variants = new Dictionary<string, Variant>
            {
                { nameof(button), button },
                { nameof(buttonWithIcon), buttonWithIcon },
                { nameof(iconOnly), iconOnly }
            };

            return variants;
        }

        ///// <summary>
        ///// 获取 Konbs
        ///// </summary>
        ///// <param name="variant"></param>
        ///// <returns></returns>
        //protected override Dictionary<string, IList<Knob>> GetKnobs(Variant variant)
        //{
        //    var modifiersContent = (RenderFragment)(__builder =>
        //    {
        //        var sequence = 0;
        //        __builder.AddContent(sequence++, CreateBoolKnob("disabled", _disabled, __value => _disabled = __value).Content);
        //        __builder.AddContent(sequence++, CreateBoolKnob("isExpressive", _isExpressive, __value => _isExpressive = __value).Content);
        //        __builder.AddContent(sequence++, CreateBoolKnob("loading", _loading, __value => _loading = __value).Content);
        //    });

        //    return new Dictionary<string, IList<Knob>>
        //    {
        //        { "Modifiers", new List<Knob>{ new Knob { AttributeName = "Modifiers", Content = modifiersContent },  } },
        //        { "Kind", CreateEnumKnob(_kind, __value => _kind = __value, new[]{ BxButtonKind.DangerGhost, BxButtonKind.DangerTertiary  }) },
        //        { "Size", CreateEnumKnob(_size, __value => _size = __value, new[]{ BxButtonSize.Small, BxButtonSize.Field }) }
        //    };
        //}

        /// <summary>
        /// 获取 Konbs
        /// </summary>
        /// <param name="variant"></param>
        /// <returns></returns>
        protected override Dictionary<string, Knob> GetKnobs(Variant variant)
        {
            return new Dictionary<string, Knob>();
        }
    }
}
