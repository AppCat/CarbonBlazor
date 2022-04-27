using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Modal 的参数部分
    /// Modal parameter partial
    /// </summary>
    public partial class BxModal : IBxModalConfig
    {
        /// <summary>
        /// 加载中
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 可见度
        /// </summary>
        [Parameter]
        public bool Visible { get; set; }

        /// <summary>
        /// 展开
        /// </summary>
        [Parameter]
        public EventCallback<bool> VisibleChanged { get; set; }

        /// <summary>
        /// 指定一个标签，由模态根节点上的屏幕阅读器读取  
        /// Specify a label to be read by screen readers on the modal root node
        /// </summary>
        [Parameter]
        public string? Heading { get; set; }

        /// <summary>
        /// 指定模式头标题的内容。
        /// Specify the content of the modal header title.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// 指定一个标签，由模态根节点上的屏幕阅读器读取  
        /// Specify a label to be read by screen readers on the modal root node
        /// </summary>
        [Parameter]
        public RenderFragment<object>? HeadingTemplate { get; set; }

        /// <summary>
        /// 指定模式头标题的内容。
        /// Specify the content of the modal header title.
        /// </summary>
        [Parameter]
        public RenderFragment<object>? LabelTemplate { get; set; }

        /// <summary>
        /// 指定模态是否包含滚动内容
        /// Specify whether the modal contains scrolling content
        /// </summary>
        [Parameter]
        public bool HasScrollingContent { get; set; }

        /// <summary>
        /// 指定模态是否应该是无按钮的
        /// Specify whether the modal should be button-less
        /// </summary>
        [Parameter]
        public bool PassiveModal { get; set; }

        /// <summary>
        /// 防止在模态外单击关闭
        /// Prevent closing on click outside of modal
        /// </summary>
        [Parameter]
        public bool PreventCloseOnClickOutside { get; set; }

        /// <summary>
        /// 提供模式的内容。 Or ChildContent
        /// Provide the contents of your Modal Or ChildContent
        /// </summary>
        [Parameter]
        public string? Content { get; set; }

        /// <summary>
        /// 提供模式的内容。 Or ChildContent
        /// Provide the contents of your Modal Or ChildContent
        /// </summary>
        [Parameter]
        public RenderFragment<object>? ContentTemplate { get; set; }

        /// <summary>
        /// 提供你的模态的页脚
        /// Provide the footer of your Modal
        /// </summary>
        [Parameter]
        public RenderFragment<object>? FooterTemplate { get; set; }

        /// <summary>
        /// 指定大小变量
        /// Specify the size variant.
        /// </summary>
        [Parameter]
        public EnumMix<BxModalSize>? Size { get; set; }

        /// <summary>
        /// 用于传递的模型
        /// A model for delivery
        /// </summary>
        [Parameter]
        public object? Model { get; set; }

        /// <summary>
        /// 行为
        /// </summary>
        [Parameter]
        public BxModalActionConfig[]? Actions { get; set; }

        #region Event

        /// <summary>
        /// 在模态显示时调用。
        /// Is called when a modal starts to show.
        /// </summary>
        [Parameter]
        public EventCallback OnShow { get; set; }

        /// <summary>
        /// 在模态关闭后调用。
        /// Is called after a modal has finished hiding animation.
        /// </summary>
        [Parameter]
        public EventCallback OnClose { get; set; }

        /// <summary>
        /// 可见度变化事件
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnVisibleChange { get; set; }

        #endregion

        #region Config

        /// <summary>
        /// modal-container 配置
        /// The modal-container is config for the comboBox.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ContainerConfig { get; set; }

        /// <summary>
        /// modal-header 配置
        /// The modal-header is config for the comboBox.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? HeaderConfig { get; set; }

        /// <summary>
        /// modal-header__label 配置
        /// The modal-header__label is config for the comboBox.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? HeaderLabelConfig { get; set; }

        /// <summary>
        /// modal-header__heading 配置
        /// The modal-header__heading is config for the comboBox.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? HeaderHeadingConfig { get; set; }

        /// <summary>
        /// modal-close 配置
        /// The modal-close is config for the comboBox.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? CloseConfig { get; set; }

        /// <summary>
        /// modal-content 配置
        /// The modal-content is config for the comboBox.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? ContentConfig { get; set; }

        /// <summary>
        /// modal-footer 配置
        /// The modal-footer is config for the comboBox.
        /// </summary>
        [Parameter]
        public IBxComponentConfig? FooterConfig { get; set; }

        #endregion
    }
}
