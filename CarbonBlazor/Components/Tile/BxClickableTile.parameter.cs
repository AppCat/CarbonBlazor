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
    /// ClickableTile 的参数部分
    /// ClickableTile parameter partial
    /// </summary>
    public partial class BxClickableTile
    {
        /// <summary>
        /// 链接的href。
        /// The href for the link.
        /// </summary>
        [Parameter]
        public string? Href { get; set; }

        /// <summary>
        /// 链接的rel属性。
        /// The rel property for the link.
        /// </summary>
        [Parameter]
        public string? Rel { get; set; }
    }
}
