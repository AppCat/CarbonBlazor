using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 点击路径
    /// </summary>
    public class ClickElement
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string? LocalName { get; set; }
        
        /// <summary>
        /// 类名
        /// </summary>
        public string? ClassName { get; set; }
    }
}
