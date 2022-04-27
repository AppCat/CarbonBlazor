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
    public class BxModalConfig : IBxModalConfig
    {
        /// <summary>
        /// 指定一个标签，由模态根节点上的屏幕阅读器读取  
        /// Specify a label to be read by screen readers on the modal root node
        /// </summary>
        public string? Heading { get; set; }

        /// <summary>
        /// 指定模式头标题的内容。
        /// Specify the content of the modal header title.
        /// </summary>
        public string? Label { get; set; }

        /// <summary>
        /// 指定一个标签，由模态根节点上的屏幕阅读器读取  
        /// Specify a label to be read by screen readers on the modal root node
        /// </summary>
        public RenderFragment<object>? HeadingTemplate { get; set; }

        /// <summary>
        /// 指定模式头标题的内容。
        /// Specify the content of the modal header title.
        /// </summary>
        public RenderFragment<object>? LabelTemplate { get; set; }

        /// <summary>
        /// 指定模态是否包含滚动内容
        /// Specify whether the modal contains scrolling content
        /// </summary>
        public bool HasScrollingContent { get; set; }

        /// <summary>
        /// 指定模态是否应该是无按钮的
        /// Specify whether the modal should be button-less
        /// </summary>
        public bool PassiveModal { get; set; }

        /// <summary>
        /// 防止在模态外单击关闭
        /// Prevent closing on click outside of modal
        /// </summary>
        public bool PreventCloseOnClickOutside { get; set; }

        /// <summary>
        /// 提供模式的内容。 Or ChildContent
        /// Provide the contents of your Modal Or ChildContent
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// 提供模式的内容。 Or ChildContent
        /// Provide the contents of your Modal Or ChildContent
        /// </summary>
        public RenderFragment<object>? ContentTemplate { get; set; }

        /// <summary>
        /// 提供你的模态的页脚
        /// Provide the footer of your Modal
        /// </summary>
        public RenderFragment<object>? FooterTemplate { get; set; }

        /// <summary>
        /// 指定大小变量
        /// Specify the size variant.
        /// </summary>
        public EnumMix<BxModalSize>? Size { get; set; }

        /// <summary>
        /// 用于传递的模型
        /// A model for delivery
        /// </summary>
        public object? Model { get; set; }

        /// <summary>
        /// 行为
        /// </summary>
        public BxModalActionConfig[]? Actions { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        public string? Style { get; set; }

        /// <summary>
        /// 类
        /// </summary>
        public string? Class { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        public Dictionary<string, object>? Attributes { get; set; }
    }
}
