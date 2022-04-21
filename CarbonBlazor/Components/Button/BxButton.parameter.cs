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

        #region PROPERTIES

        /// <summary>
        /// true 页面加载时按钮是否应该有输入焦点。  
        /// if the button should have input focus when the page loads.
        /// </summary>
        [Parameter]
        [BxPropertie]
        public bool Autofocus { get; set; } = false;

        /// <summary>
        /// 默认文件名，当此按钮呈现为<a>时使用。
        /// The default file name, used if this button is rendered as <a>.
        /// </summary>
        [Parameter]
        [BxPropertie]
        public string? Download { get; set; }

        /// <summary>
        /// href链接。 如果存在，此按钮将呈现为<a>。
        /// Link href. If present, this button is rendered as <a>.
        /// </summary>
        [Parameter]
        [BxPropertie]
        public string? Href { get; set; }

        /// <summary>
        /// 如果该按钮呈现为<a>，则href所指向的语言。  
        /// The language of what href points to, if this button is rendered as <a>.
        /// </summary>
        [Parameter]
        [BxPropertie]
        public string? Hreflang { get; set; }

        /// <summary>
        /// true 如果表达主题启用。
        /// if expressive theme enabled.
        /// </summary>
        [Parameter]
        [BxPropertie]
        public bool IsExpressive { get; set; }

        /// <summary>
        /// 按钮种类
        /// Button kind. 
        /// </summary>
        [Parameter]
        [BxPropertie]
        public EnumMix<BxButtonKind>? Kind { get; set; } = BxButtonKind.PRIMARY;

        /// <summary>
        /// ping的url，如果这个按钮被呈现为<a>。
        /// URLs to ping, if this button is rendered as <a>.
        /// </summary>
        [Parameter]
        [BxPropertie]
        public string? Ping { get; set; }

        /// <summary>
        /// 链接类型，如果此按钮呈现为<a>。  
        /// The link type, if this button is rendered as <a>.
        /// </summary>
        [Parameter]
        [BxPropertie]
        public string? Rel { get; set; }

        /// <summary>
        /// 按钮大小
        /// Button size.
        /// </summary>
        [Parameter]
        [BxPropertie]
        public EnumMix<BxButtonSize>? Size { get; set; } = BxButtonSize.REGULAR;

        /// <summary>
        /// 如果此按钮呈现为<a>，则链接目标。
        /// The link target, if this button is rendered as <a>.
        /// </summary>
        [Parameter]
        [BxPropertie]
        public string? Target { get; set; }

        /// <summary>
        /// 如果按钮呈现为<button>，则默认行为。 targetif按钮的MIME类型被呈现为<a>。
        /// The link type, if this button is rendered as <a>.
        /// </summary>
        [Parameter]
        [BxPropertie]
        public string? Type { get; set; }

        /// <summary>
        /// 按钮图标布局。
        /// Button icon layout.
        /// </summary>
        [Parameter]
        [BxPropertie]
        public EnumMix<BxButtonIconLayout>? IconLayout { get; set; } = BxButtonIconLayout.REGULAR;

        /// <summary>
        /// <a>的a11y角色。
        /// The a11y role for <a>.
        /// </summary>
        [Parameter]
        [BxPropertie]
        public string? LinkRole { get; set; }

        #endregion

        #region ATTRIBUTES



        #endregion

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
    }
}
