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
    /// 按钮的参数部分
    /// Button parameter partial
    /// </summary>
    public partial class BxButton
    {
        /// <summary>
        /// 内容
        /// </summary>
        [Parameter]
        public string? Content { get; set; }

        /// <summary>
        /// 加载中
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 对于骨架变化
        /// For the skeleton variation, utilize
        /// </summary>
        [Parameter]
        public bool Skeleton { get; set; }

        /// <summary>
        /// href链接。 如果存在，此按钮将呈现为<a>。
        /// Link href. If present, this button is rendered as a.
        /// </summary>
        [Parameter]
        public string? Href { get; set; }

        /// <summary>
        /// true 如果表达主题启用。
        /// if expressive theme enabled.
        /// </summary>
        [Parameter]
        public bool IsExpressive { get; set; }

        /// <summary>
        /// 按钮种类
        /// Button kind. 
        /// </summary>
        [Parameter]
        public EnumMix<BxButtonKind>? Kind { get; set; } = BxButtonKind.Primary;

        /// <summary>
        /// 按钮大小
        /// Button size.
        /// </summary>
        [Parameter]
        public EnumMix<BxButtonSize>? Size { get; set; }

        /// <summary>
        /// 可选来指定按钮的类型
        /// Optional prop to specify the type of the Button
        /// </summary>
        [Parameter]
        public EnumMix<BxButtonType> Type { get; set; } = BxButtonType.Button;

        /// <summary>
        /// 指定该按钮是否是一个图标按钮
        /// Specify if the button is an icon-only button
        /// </summary>
        [Parameter]
        public bool HasIconOnly { get; set; }

        /// <summary>
        /// 可选道具来指定按钮的角色  
        /// Optional prop to specify the role of the Button
        /// </summary>
        [Parameter]
        public string? Role { get; set; }

        /// <summary>
        /// 处理事件用于 Bind。
        /// Loading event use for bind.
        /// </summary>
        [Parameter]
        public EventCallback<bool> LoadingChanged { get; set; }

        /// <summary>
        /// 点击事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// 点击停止传播
        /// </summary>
        [Parameter]
        public bool? OnClickStopPropagation { get; set; } = true;

        /// <summary>
        /// onmousedown 事件的事件处理程序。
        /// The event handler for the onmousedown event.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        /// <summary>
        /// onmouseup 事件的事件处理程序。
        /// The event handler for the onmouseup event.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseUp { get; set; }
    }
}
