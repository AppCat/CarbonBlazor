using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 选项基础
    /// </summary>
    public abstract class BxOptionComponentBase<TSelect, TOption, TKey> : BxComponentBase, IBxOption<TKey>
        where TSelect : class, IBxSelect<TOption, TKey>
        where TOption : class, IBxOption<TKey>
        where TKey : notnull
    {
        /// <summary>
        /// 选择
        /// </summary>
        protected bool Selected => FatherSelect?.OptionIsSelected(this as TOption) ?? false;

        /// <summary>
        /// 过滤
        /// </summary>
        protected bool Filtered => FatherSelect?.OptionIsFiltered(this as TOption) ?? false;

        /// <summary>
        /// 活跃
        /// </summary>
        protected bool Focus => FatherSelect?.OptionIsFocus(this as TOption) ?? false;

        /// <summary>
        /// 项Id
        /// </summary>
        public virtual string? OptionId { get; set; }

        #region Parameter        

        /// <summary>
        /// 键
        /// </summary>
        [Parameter]
        public virtual TKey? Key { get; set; }

        /// <summary>
        /// 附加
        /// </summary>
        [Parameter]
        public virtual object? Tag { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Parameter]
        public string? Value { get; set; }

        /// <summary>
        /// 内容模板
        /// </summary>
        [Parameter]
        public RenderFragment<object?>? ValueTemplate { get; set; }

        #endregion

        #region CascadingParameter

        /// <summary>
        /// 夫选择
        /// </summary>
        [CascadingParameter(Name = "FatherSelect")]
        protected IBxSelect<TOption, TKey>? FatherSelect { get; set; }

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
            if (FatherSelect != null)
            {
                await FatherSelect.SelectedOptionAsync(this as TOption, true);
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

            if(Key == null)
            {
                throw new ArgumentNullException(nameof(Key));
            }

            if (string.IsNullOrEmpty(Value))
            {
                Value = Key.ToString();
            }
        }

        /// <summary>
        /// 设置属性后
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            FatherSelect?.AddOption(this as TOption);
        }

        #endregion

        /// <summary>
        /// 通知状态变化
        /// </summary>
        public void NotifyStateHasChanged() => InvokeStateHasChanged();
    }
}
