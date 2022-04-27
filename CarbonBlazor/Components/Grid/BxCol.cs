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
    /// 这是一个用于 Col 的 Blazor 组件。  
    /// This is a Blazor component for the Col.
    /// </summary>
    public partial class BxCol : BxContentComponentBase
    {
        /// <summary>
        /// 设置映射
        /// </summary>
        protected override void OnSetMapper()
        {
            var fixedClass = $"bx--col";

            ClassMapper
                .Clear()
                .AddEnum(Sm, () => $"bx--col-sm-{(int)Sm.Value}")
                .AddEnum(Md, () => $"bx--col-md-{(int)Md.Value}")
                .AddEnum(Lg, () => $"bx--col-lg-{(int)Lg.Value}")
                .AddEnum(Xlg, () => $"bx--col-xlg-{(int)Xlg.Value}")
                .AddEnum(Max, () => $"bx--col-max-{(int)Max.Value}")
                .AddEnum(OffsetSm, () => $"bx--offset-sm-{(int)OffsetSm.Value}")
                .AddEnum(OffsetMd, () => $"bx--offset-md-{(int)OffsetMd.Value}")
                .AddEnum(OffsetLg, () => $"bx--offset-lg-{(int)OffsetLg.Value}")
                .AddEnum(OffsetXlg, () => $"bx--offset-xlg-{(int)OffsetXlg.Value}")
                .AddEnum(OffsetMax, () => $"bx--offset-max-{(int)OffsetMax.Value}")
                .If(fixedClass,() => Sm != null && Md != null && Lg != null && Xlg != null && Max != null)
                ;
        }

        /// <summary>
        /// 渲染内容
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            __builder.AddContent(sequence++, ChildContent);

            __builder.CloseComponent();
        };
    }
}
