using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 选择对象
    /// </summary>
    public interface ISelectionModel
    {
        /// <summary>
        /// 选中
        /// </summary>
        bool Selected { get; set; }
    }
}
