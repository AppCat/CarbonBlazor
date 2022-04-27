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
        /// <param name="selectedId"></param>
        void SelectedColumn(int? selectedId);

        /// <summary>
        /// 取消选中
        /// </summary>
        /// <param name="selectedId"></param>
        void DeselectColumn(int? selectedId);

        /// <summary>
        /// 全选
        /// </summary>
        void SelectedAll();

        /// <summary>
        /// 取消全选
        /// </summary>
        void DeselectAll();

        /// <summary>
        /// 是否选中
        /// </summary>
        /// <param name="selectedId"></param>
        /// <returns></returns>
        bool IsSelected(int? selectedId);

        /// <summary>
        /// 全选
        /// </summary>
        bool IsSelectedAll();
    }
}
