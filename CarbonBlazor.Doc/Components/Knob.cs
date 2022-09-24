using Microsoft.AspNetCore.Components;

namespace CarbonBlazor.Doc.Components
{
    /// <summary>
    /// Knob
    /// </summary>
    public class Knob
    {
        /// <summary>
        /// 组件名称
        /// </summary>
        public string? AttributeName { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public RenderFragment? Content { get; set; }
    }
}
