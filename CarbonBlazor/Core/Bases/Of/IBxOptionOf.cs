using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 作为选择组件的选项 (Select ListBox)
    /// </summary>
    public interface IBxOptionOf<TKey> : IExternalNotifyStateHasChanged
        where TKey : notnull
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
        /// 内容
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// 附加
        /// </summary>
        object Tag { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        bool Disabled { get; }
    }
}
