using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 选择
    /// </summary>
    public interface IBxSelect<TOption, TKey>
        where TOption : class, IBxOption<TKey>
    {
        /// <summary>
        /// 添加选项
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        bool AddOption(TOption option);

        /// <summary>
        /// 聚焦的选项
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        Task FocusOptionAsync(TOption option);

        /// <summary>
        /// 选中的选项
        /// </summary>
        /// <param name="option"></param>
        /// <param name="isClick"></param>
        Task SelectedOptionAsync(TOption option, bool isClick = false);

        /// <summary>
        /// 选项是否选中
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        bool OptionIsSelected(TOption option);

        /// <summary>
        /// 选项是否聚焦
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        bool OptionIsFocus(TOption option);

        /// <summary>
        /// 选项是否过滤
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        bool OptionIsFiltered(TOption option);
    }
    
}
