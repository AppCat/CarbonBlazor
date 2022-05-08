using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 通知类型
    /// Notification Kind
    /// </summary>
    public enum BxNotificationKind
    {
        /// <summary>
        /// 错误
        /// </summary>
        Error,
        /// <summary>
        /// 信息
        /// </summary>
        Info,
        /// <summary>
        /// 信息广场
        /// </summary>
        [EnumClass("info-square")]
        InfoSquare,
        /// <summary>
        /// 成功
        /// </summary>
        Success,
        /// <summary>
        /// 警示
        /// </summary>
        Warning,
        /// <summary>
        /// 警示
        /// </summary>
        [EnumClass("warning-alt")]
        WarningAlt
    }
}
