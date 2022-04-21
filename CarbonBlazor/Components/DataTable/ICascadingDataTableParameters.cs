using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 数据表联级参数
    /// </summary>
    public interface ICascadingDataTableParameters
    {
        /// <summary>
        /// 可选择
        /// With selection
        /// </summary>
        bool WithSelection { get; }
    }
}
