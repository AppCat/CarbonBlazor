using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 TileGroup 的 Blazor 组件。  
    /// This is a Blazor component for the TileGroup.
    /// </summary>
    //public partial class BxTileGroup : BxSelectComponentBaseOf<BxRadioTile, string>
    //{
    //    /// <summary>
    //    /// 设置映射
    //    /// </summary>
    //    protected override void OnSetMapper()
    //    {
    //        var fixedClass = $"bx--tile-group";
    //        ClassMapper
    //            .Clear()
    //            .Add(fixedClass)
    //            ;
    //    }

    //    /// <summary>
    //    /// 内容渲染
    //    /// </summary>
    //    /// <returns></returns>
    //    internal override RenderFragment ContentFragment() => __builder =>
    //    {
    //        var sequence = 0;
    //        __builder.UseElement(ref sequence, "fieldset", this, __builder =>
    //        {
    //            var sequence = 0;

    //            __builder.OpenElement(sequence++, "legend");
    //            __builder.AddConfig(ref sequence, new BxComponentConfig(LegendConfig, $"undefined--label", $"{Id}-label"));
    //            __builder.EitherOrAddContent(ref sequence, LegendTemplate, Legend, () => LegendTemplate != null);
    //            __builder.CloseElement();

    //            __builder.OpenElement(sequence++, "div");
    //            __builder.AddContent(sequence++, ChildContent);
    //            __builder.CloseElement();
    //        });
    //    };
    //}
}
