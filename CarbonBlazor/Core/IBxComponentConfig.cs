using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 组件配置
    /// </summary>
    public interface IBxComponentConfig
    {
        /// <summary>
        /// 类
        /// </summary>
        public string? Class { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        public string? Style { get; set; }

        /// <summary>
        /// 显示部分特性
        /// </summary>
        Dictionary<string, object> Attributes { get; set; }
    }
}
