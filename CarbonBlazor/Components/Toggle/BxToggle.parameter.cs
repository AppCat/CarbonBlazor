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
    /// Toggle 的参数部分
    /// Toggle parameter partial
    /// </summary>
    public partial class BxToggle
    {
        /// <summary>
        /// 指定 Toggle 的大小。
        /// Specify the size of the Toggle.
        /// </summary>
        [Parameter]
        public EnumMix<BxSize>? Size { get; set; }

        /// <summary>
        /// 将标签指定为“关闭”位置
        /// Specify the label for the "off" position
        /// </summary>
        [Parameter]
        public string? LabelA { get; set; } = "Off";

        /// <summary>
        /// 将标签指定为“on”位置
        /// Specify the label for the "on" position
        /// </summary>
        [Parameter]
        public string? LabelB { get; set; } = "On";

        /// <summary>
        /// 切换
        /// </summary>
        [Parameter]
        public bool Toggled { get; set; }

        /// <summary>
        /// 点击停止传播
        /// </summary>
        [Parameter]
        public bool? OnClickStopPropagation { get; set; } = true;

        /// <summary>
        /// 加载中
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 处理事件用于 Bind。
        /// Loading event use for bind.
        /// </summary>
        [Parameter]
        public EventCallback<bool> LoadingChanged { get; set; }

        /// <summary>
        /// 变化事件
        /// </summary>
        [Parameter]
        public virtual EventCallback<bool> ToggledChanged { get; set; }

        /// <summary>
        /// 变化事件
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnToggledChange { get; set; }

        /// <summary>
        /// 点击事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        #region Config

        /// <summary>
        /// toggle__button 配置
        /// The toggle__button is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ButtonConfig { get; set; }

        /// <summary>
        /// toggle__label 配置
        /// The toggle__label is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? LabelConfig { get; set; }

        /// <summary>
        /// toggle__appearance 配置
        /// The toggle__appearance is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? AppearanceConfig { get; set; }

        /// <summary>
        /// toggle__switch 配置
        /// The toggle__switch is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? SwitchConfig { get; set; }

        /// <summary>
        /// toggle__text 配置
        /// The toggle__text is config.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? TextConfig { get; set; }
        #endregion
    }
}
