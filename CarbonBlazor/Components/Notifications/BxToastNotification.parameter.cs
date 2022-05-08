using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// ToastNotification 的参数部分
    /// ToastNotification parameter partial
    /// </summary>
    public partial class BxToastNotification
    {
        /// <summary>
        /// 通知的说明。
        /// caption the notification.
        /// </summary>
        [Parameter]
        public string? Caption { get; set; }

        #region Config

        /// <summary>
        /// notification__caption 配置
        /// The notification__caption is config for the ProgressBar.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? CaptionConfig { get; set; }

        #endregion
    }
}
