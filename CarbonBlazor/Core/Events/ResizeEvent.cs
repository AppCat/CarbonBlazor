using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 窗口变化事件传递参数
    /// </summary>
    public class ResizeEvent
    {
        /// <summary>
        /// 客户端宽度
        /// </summary>
        public int ClientWidth { get; set; }

        /// <summary>
        /// 客户端高度
        /// </summary>
        public int ClientHeight { get; set; }

        /// <summary>
        /// 内部高度
        /// </summary>
        public int InnerHeight { get; set; }

        /// <summary>
        /// 内部宽度
        /// </summary>
        public int InnerWidth { get; set; }

        /// <summary>
        /// 外部宽度
        /// </summary>
        public int OuterWidth { get; set; }

        /// <summary>
        /// 外部高度
        /// </summary>
        public int OuterHeight { get; set; }
    }
}
