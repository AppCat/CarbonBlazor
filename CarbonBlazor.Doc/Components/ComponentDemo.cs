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
        /// 变体型
        /// </summary>
        [Parameter]
        public Type[]? Variants { get; set; }

        /// <summary>
        /// </summary>
        [Parameter]
        public Func<Type, PropertyInfo[]>? Knob { get; set; }

        /// <summary>
        /// 构建渲染树
        /// </summary>
        /// <param name="builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var sequence = 0;


        }
    }
}
