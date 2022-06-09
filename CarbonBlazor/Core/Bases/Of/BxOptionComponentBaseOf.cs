using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 作为选择组件的选项 (Select ListBox)
    /// </summary>
    /// <typeparam name="TOption"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class BxOptionComponentBaseOf<TOption, TKey> : BxComponentBase, IBxOptionOf<TKey>
        where TOption : class, IBxOptionOf<TKey>
        where TKey : notnull
    {
        /// <summary>
        /// 选择
        /// </summary>
        protected bool Selected => FatherSelect?.OptionIsInSelected(Key) ?? false;

        /// <summary>
        /// 过滤
        /// </summary>
        protected bool Filtered => FatherSelect?.OptionIsInFiltered(Key) ?? false;

        /// <summary>
        /// 活跃
        /// </summary>
        protected bool Focus => FatherSelect?.OptionIsInFocus(Key) ?? false;

        /// <summary>
        /// 项Id
        /// </summary>
        public virtual string? OptionId { get; set; }

        #region Parameter        

        /// <summary>
        /// 键
        /// </summary>
        [Parameter]
        public virtual TKey Key { get; set; }

        /// <summary>
        /// 附加
        /// </summary>
        [Parameter]
        public virtual object? Tag { get; set; }

        #endregion

        #region CascadingParameter

        /// <summary>
        /// 夫选择
        /// </summary>
        [CascadingParameter(Name = "FatherSelect")]
        protected IBxSelectOf<TOption, TKey>? FatherSelect { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 点击事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        #endregion

        #region Handle

        /// <summary>
        /// 处理点击
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickAsync(MouseEventArgs args)
        {
            if (Disabled)
                return;

            await OnClick.InvokeAsync(args);
            if (FatherSelect != null && this is TOption option)
            {
                await FatherSelect.SelectedOptionAsync(option, true);
            }
        }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            OptionId ??= Guid.NewGuid().ToString("N");

            if (Key == null)
            {
                throw new ArgumentNullException(nameof(Key));
            }
        }
        
        /// <summary>
        /// 设置属性后
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if(FatherSelect != null && FatherSelect.RenderPhase == BxRenderPhase.Initialize && this is TOption option)
            {
                FatherSelect?.EnrollOption(option);
            }
        }

        /// <summary>
        /// 构建渲染树
        /// </summary>
        /// <param name="__builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {
            if (FatherSelect != null && FatherSelect.RenderPhase == BxRenderPhase.Render)
            {
                base.BuildRenderTree(__builder);
            }
        }

        #endregion

        /// <summary>
        /// 通知状态变化
        /// </summary>
        public void NotifyStateHasChanged() => InvokeStateHasChanged();
    }
}
