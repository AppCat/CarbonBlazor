using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    ///// <summary>
    ///// 这是一个用于 RadioButtonGroup 的 Blazor 组件。  
    ///// This is a Blazor component for the RadioButtonGroup.
    ///// </summary>
    //public class BxRadioButtonGroup<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : BxInputBase<TValue>
    //{
    //    private readonly string _defaultGroupName = Guid.NewGuid().ToString("N");
    //    private BxInputRadioContext? _context;

    //    /// <summary>
    //    /// Gets or sets the child content to be rendering inside the <see cref="InputRadioGroup{TValue}"/>.
    //    /// </summary>
    //    [Parameter] public RenderFragment? ChildContent { get; set; }

    //    /// <summary>
    //    /// Gets or sets the name of the group.
    //    /// </summary>
    //    [Parameter] public string? Name { get; set; }

    //    [CascadingParameter] private BxInputRadioContext? CascadedContext { get; set; }

    //    /// <inheritdoc />
    //    protected override void OnParametersSet()
    //    {
    //        var groupName = !string.IsNullOrEmpty(Name) ? Name : _defaultGroupName;
    //        var fieldClass = EditContext?.FieldCssClass(FieldIdentifier) ?? string.Empty;
    //        var changeEventCallback = EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString);

    //        _context = new InputRadioContext(CascadedContext, groupName, CurrentValue, fieldClass, changeEventCallback);
    //    }

    //    /// <summary>
    //    /// 内容渲染
    //    /// </summary>
    //    /// <returns></returns>
    //    internal override RenderFragment ContentFragment() => __builder =>
    //    {
    //        __builder.OpenComponent<CascadingValue<BxInputRadioContext>>(0);
    //        __builder.SetKey(_context);
    //        __builder.AddAttribute(1, "IsFixed", true);
    //        __builder.AddAttribute(2, "Value", _context);
    //        __builder.AddAttribute(3, "ChildContent", ChildContent);
    //        __builder.CloseComponent();
    //    };

    //    /// <inheritdoc />
    //    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
    //        => this.TryParseSelectableValueFromString(value, out result, out validationErrorMessage);
    //}
}
