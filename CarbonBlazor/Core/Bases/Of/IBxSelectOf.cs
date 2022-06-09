using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 具有选择的组件 (Select ListBox)
    /// </summary>
    public interface IBxSelectOf<TOption, TKey>
        where TOption : class, IBxOptionOf<TKey>
    {
        /// <summary>
        /// 渲染阶段
        /// </summary>
        BxRenderPhase RenderPhase { get; }

        /// <summary>
        /// 登记选项
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        bool EnrollOption(TOption option);

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
        /// 选项是选中
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool OptionIsInSelected(TKey key);

        /// <summary>
        /// 选项是聚焦
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool OptionIsInFocus(TKey key);

        /// <summary>
        /// 选项是过滤
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool OptionIsInFiltered(TKey key);
    }
    
}
