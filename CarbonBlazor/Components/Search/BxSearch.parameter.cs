using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Search 的参数部分
    /// Search parameter partial
    /// </summary>
    public partial class BxSearch
    {
        /// <summary>
        /// 提示信息
        /// </summary>         
        [Parameter]
        public string? Placeholder { get; set; }

        /// <summary>
        /// 格式
        /// </summary>
        [Parameter]
        public string? Format { get; set; }

        /// <summary>
        /// 加载
        /// 一个图标输入字段可以显示它正在加载数据
        /// An icon input field can show that it is currently loading data
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }
    }
}
