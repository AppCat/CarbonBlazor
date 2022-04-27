using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 模态配置
    /// </summary>
    public interface IBxModalConfig : IBxComponentConfig
    {
        /// <summary>
        /// Id
        /// </summary>
        string? Id { get; set; }

        /// <summary>
        /// 指定一个标签，由模态根节点上的屏幕阅读器读取  
        /// Specify a label to be read by screen readers on the modal root node
        /// </summary>
        string? Heading { get; }

        /// <summary>
        /// 指定模式头标题的内容。
        /// Specify the content of the modal header title.
        /// </summary>
        string? Label { get; }

        /// <summary>
        /// 指定一个标签，由模态根节点上的屏幕阅读器读取  
        /// Specify a label to be read by screen readers on the modal root node
        /// </summary>
        RenderFragment<object>? HeadingTemplate { get; }

        /// <summary>
        /// 指定模式头标题的内容。
        /// Specify the content of the modal header title.
        /// </summary>
        RenderFragment<object>? LabelTemplate { get; }

        /// <summary>
        /// 指定模态是否包含滚动内容
        /// Specify whether the modal contains scrolling content
        /// </summary>
        bool HasScrollingContent { get; }

        /// <summary>
        /// 指定模态是否应该是无按钮的
        /// Specify whether the modal should be button-less
        /// </summary>
        bool PassiveModal { get; }

        /// <summary>
        /// 防止在模态外单击关闭
        /// Prevent closing on click outside of modal
        /// </summary>
        bool PreventCloseOnClickOutside { get; }

        /// <summary>
        /// 提供模式的内容。 Or ChildContent
        /// Provide the contents of your Modal Or ChildContent
        /// </summary>
        string? Content { get; }

        /// <summary>
        /// 提供模式的内容。 Or ChildContent
        /// Provide the contents of your Modal Or ChildContent
        /// </summary>
        RenderFragment<object>? ContentTemplate { get; }

        /// <summary>
        /// 提供你的模态的页脚
        /// Provide the footer of your Modal
        /// </summary>
        RenderFragment<object>? FooterTemplate { get; }

        /// <summary>
        /// 指定大小变量
        /// Specify the size variant.
        /// </summary>
        EnumMix<BxModalSize>? Size { get; }

        /// <summary>
        /// 用于传递的模型
        /// A model for delivery
        /// </summary>
        object? Model { get; }

        /// <summary>
        /// 行为
        /// </summary>
        BxModalActionConfig[]? Actions { get; }
    }
}
