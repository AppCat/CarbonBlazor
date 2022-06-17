using CarbonBlazor.Components;
using CarbonBlazor.Doc.Components;
using Microsoft.AspNetCore.Components;

namespace CarbonBlazor.Doc.Pages
{
    /// <summary>
    /// Checkbox 页
    /// </summary>
    [RouteAttribute("checkbox")]
    public class Checkbox : DemoPageBase
    {
        bool _disabled;
        bool _checked;
        bool _hideLabel;

        /// <summary>
        /// 获取变体
        /// </summary>
        /// <returns></returns>
        protected override Dictionary<string, Variant> GetVariants()
        {
            RenderFragment component(Dictionary<string, Func<object>>? attribute = null) => __builder =>
            {
                var key = Guid.NewGuid();
                var sequence = 0;

                __builder.OpenComponent(sequence++, typeof(BxCheckbox));
                __builder.SetKey(key);
                __builder.AddAttribute(sequence++, nameof(BxCheckbox.LabelText), "Checkbox label");
                foreach (var item in attribute ?? new Dictionary<string, Func<object>>())
                {
                    var value = item.Value.Invoke();
                    __builder.AddAttribute(sequence++, item.Key, value);
                }
                __builder.CloseComponent();

                var treeFrames = __builder.GetFrames().Array;
                int content = 0;
                bool ixx = false;
                var codeBlock = new CodeBlock();
                var componentBlock = new CodeBlock();
                foreach (var treeFrame in treeFrames)
                {
                    if(treeFrame.ComponentKey?.GetHashCode() == key.GetHashCode())
                    {
                        componentBlock.AddOrSetParcel($"<{treeFrame.ComponentType.Name}>", $"</{treeFrame.ComponentType.Name}>");
                        codeBlock.AddCode(componentBlock);
                        content = treeFrame.ComponentSubtreeLength;
                    }

                    if(content > 0)
                    {
                        content--;
                        if(treeFrame.FrameType == Microsoft.AspNetCore.Components.RenderTree.RenderTreeFrameType.Attribute)
                        {
                            componentBlock.AddAttribute(treeFrame.AttributeName, treeFrame.AttributeValue);
                        }
                        ixx = content == 0;
                    }
                    else if(ixx)
                    {
                        Console.WriteLine(codeBlock.Content());
                        ixx = false;
                    }
                }
            };

            var share = new Dictionary<string, Func<object>>
            {
                { nameof(BxCheckbox.Disabled), () => _disabled },
                { nameof(BxCheckbox.Checked), () => _checked },
                { nameof(BxCheckbox.HideLabel), () => _hideLabel },
            };

            var checkbox = new Variant("Checkbox", "Checkbox", typeof(BxCheckbox), component(share));

            var variants = new Dictionary<string, Variant>
            {
                { nameof(checkbox), checkbox },
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
                __builder.AddContent(sequence++, CreateBoolKnob("checked", _checked, __value => _checked = __value).Content);
                __builder.AddContent(sequence++, CreateBoolKnob("disabled", _disabled, __value => _disabled = __value).Content);
                __builder.AddContent(sequence++, CreateBoolKnob("hideLabel", _hideLabel, __value => _hideLabel = __value).Content);
            });

            return new Dictionary<string, Knob>
            {
                { "Modifiers", new Knob
                    {
                        Content = modifiersContent,
                    } 
                }
            };
        }
    }
}
