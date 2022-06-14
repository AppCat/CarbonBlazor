using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 扩展模型
    /// </summary>
    public interface IExpansionModel
    {
        /// <summary>
        /// 展开
        /// </summary>
        bool Expanded { get; set; }

        /// <summary>
        /// 扩展内容
        /// </summary>
        string? ExpansionContent { get; set; }

        /// <summary>
        /// 扩展内容模板
        /// </summary>
        RenderFragment? ExpansionContentTemplate { get; set; }
    }
}
