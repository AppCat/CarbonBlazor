using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 列
    /// </summary>
    public interface IBxColumn
    {
        /// <summary>
        /// 列号
        /// </summary>
        int ColumnIndex { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// 渲染目标
        /// </summary>
        BxColumFragmentGoal FragmentGoal { get; set; }
    }
}
