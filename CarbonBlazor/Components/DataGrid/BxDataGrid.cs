using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 这是一个用于 DataGrid 的 Blazor 组件。  
    /// This is a Blazor component for the DataGrid.
    /// </summary>
    public partial class BxDataGrid<TItem> : BxContentComponentBase<TItem>
        where TItem : class
    {
        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal override RenderFragment ContentFragment()
        {
            throw new NotImplementedException();
        }
    }
}
