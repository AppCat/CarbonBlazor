using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 模态行为配置
    /// </summary>
    public class BxModalActionConfig : IBxComponentConfig
    {
        /// <summary>
        /// 样式
        /// </summary>
        public string? Style { get; set; }

        /// <summary>
        /// 类
        /// </summary>
        public string? Class { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        public Dictionary<string, object>? Attributes { get; set; }

        /// <summary>
        /// 文本
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// 点击
        /// </summary>
        public Func<object, Task<bool>>? OnClick { get; set; }

        /// <summary>
        /// 按钮种类
        /// Button kind.
        /// </summary>
        public EnumMix<BxButtonKind>? Kind { get; set; } = BxButtonKind.Primary;

        /// <summary>
        /// 可选来指定按钮的类型  
        /// Optional prop to specify the type of the Button
        /// </summary>
        public EnumMix<BxButtonType>? Type { get; set; } = BxButtonType.Button;
    }
}
