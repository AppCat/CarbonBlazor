using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// NotificationBase 的参数部分
    /// NotificationBase parameter partial
    /// </summary>
    public abstract partial class BxNotificationBase
    {
        /// <summary>
        /// 指定是否隐藏关闭按钮。
        /// Specify whether a hide close button.
        /// </summary>
        [Parameter]
        public bool HideCloseButton { get; set; }

        /// <summary>
        /// 使用低对比度变体渲染组件。  
        /// Render the component using the low-contrast variant.
        /// </summary>
        [Parameter]
        public bool LowContrast { get; set; }

        /// <summary>
        /// 指定通知应该种类
        /// Specify the notification should kind.
        /// </summary>
        [Parameter]
        public EnumMix<BxNotificationKind>? Kind { get; set; } = BxNotificationKind.Info;

        /// <summary>
        /// 关闭事件
        /// </summary>
        [Parameter]
        public EventCallback OnClose { get; set; }

        /// <summary>
        /// 通知的标题。
        /// title the notification.
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// 通知的副标题。
        /// subtitle the notification.
        /// </summary>
        [Parameter]
        public string? Subtitle { get; set; }

        /// <summary>
        /// 是否延时关闭
        /// </summary>
        [Parameter]
        public bool IsDelayClose { get; set; }

        /// <summary>
        /// 延时
        /// 默认500
        /// </summary>
        [Parameter]
        public int Delay { get; set; } = 500;

        /// <summary>
        /// 延时
        /// </summary>
        [Parameter]
        public TimeSpan? DelayTimeSpan { get; set; }

        #region Config

        /// <summary>
        /// notification__details 配置
        /// The notification__details is config for the Notification.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? DetailsConfig { get; set; }

        /// <summary>
        /// notification__close-button 配置
        /// The notification__close-button is config for the Notification.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? CloseButtonConfig { get; set; }

        /// <summary>
        /// notification__title 配置
        /// The notification__title is config for the Notification.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TitleConfig { get; set; }

        /// <summary>
        /// notification__subtitle 配置
        /// The notification__subtitle is config for the Notification.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? SubtitleConfig { get; set; }

        /// <summary>
        /// progress 配置
        /// The progress config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ProgressConfig { get; set; }

        #endregion
    }
}
