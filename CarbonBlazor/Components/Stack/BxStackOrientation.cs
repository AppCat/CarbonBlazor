using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 指定这些项在堆栈中的方向  
    /// Specify the orientation of them items in the Stack
    /// </summary>
    public enum BxStackOrientation
    {
        [EnumClass("bx--stack-horizontal")]
        Horizontal,
        [EnumClass("bx--stack-vertical")]
        Vertical
    }
}
