using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 表格
    /// </summary>
    public interface IBxTable
    {
        /// <summary>
        /// 选中
        /// </summary>
        /// <param name="model"></param>
        Task SelectedRowAsync(object? model);

        /// <summary>
        /// 取消选中
        /// </summary>
        /// <param name="model"></param>
        Task DeselectRowAsync(object? model);

        /// <summary>
        /// 全选
        /// </summary>
        Task SelectedAllRowAsync();

        /// <summary>
        /// 取消全选
        /// </summary>
        Task DeselectAllRowAsync();

        /// <summary>
        /// 打开
        /// </summary>
        /// <param name="model"></param>
        Task OpenRowAsync(object? model);

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="model"></param>
        Task CloseRowAsync(object? model);

        /// <summary>
        /// 全选
        /// </summary>
        bool IsSelectedAll();
    }
}
