using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarbonBlazor;
using Microsoft.AspNetCore.Components;

namespace CarbonBlazor
{
    /// <summary>
    /// 选项
    /// </summary>
    public interface IBxOption<TKey> : IExternalNotifyStateHasChanged
    {
        /// <summary>
        /// 项Id
        /// </summary>
        string OptionId { get; set; }

        /// <summary>
        /// 键
        /// </summary>
        TKey Key { get; set; }

        /// <summary>
        /// 附加
        /// </summary>
        object Tag { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        bool Disabled { get; }

        /// <summary>
        /// 内容
        /// </summary>
        string? Value { get; set; }

        /// <summary>
        /// 内容模板
        /// </summary>
        RenderFragment<object?>? ValueTemplate { get; set; }
    }
}
