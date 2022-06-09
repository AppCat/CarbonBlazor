using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CarbonBlazor.Extensions;

namespace CarbonBlazor
{
    /// <summary>
    /// 选择组件基础
    /// </summary>
    public abstract partial class BxSelectComponentBase<TOption, TKey> : BxFormItemComponentBase<TKey>, IBxSelect<TOption, TKey>, IControlValueAccessor
        where TOption : class, IBxOption<TKey>
        where TKey : notnull
    {
        /// <summary>
        /// 选项集合
        /// </summary>
        protected virtual Dictionary<TKey, TOption> Options { get; set; } = new();

        /// <summary>
        /// 当前聚焦选项
        /// </summary>
        protected virtual TOption? FocusOption { get; set; }

        /// <summary>
        /// 当前选中选项
        /// </summary>
        protected virtual TOption? SelectedOption { get; set; }

        /// <summary>
        /// 当前聚焦选项下标
        /// </summary>
        protected int FocusOptionIndex { get; set; }

        /// <summary>
        /// 第一次选中的选项键
        /// </summary>
        protected TKey[]? FirstSelectedKeys { get; set; }

        #region Parameter

        /// <summary>
        /// 默认选择key
        /// </summary>
        [Parameter]
        public TKey? DefaultSelectedKey { get; set; }

        /// <summary>
        /// 选中的选项键
        /// </summary>
        [Parameter]
        public TKey[]? SelectedKeys
        {
            get => _selectedKeys; set
            {
                if (value == _selectedKeys)
                    return;
                var old = _selectedKeys;
                _selectedKeys = value;
                NotifyOptionStateHasChanged(value, old);
            }
        }
        private TKey[]? _selectedKeys;

        /// <summary>
        /// 过滤的选项键
        /// </summary>
        [Parameter]
        public virtual TKey[]? FilteredKeys
        {
            get => _filteredKeys; set
            {
                if (value == _filteredKeys)
                    return;
                var old = _selectedKeys;
                _filteredKeys = value;
                NotifyOptionStateHasChanged(value, old);
            }
        }
        private TKey[]? _filteredKeys;

        /// <summary>
        /// 筛选
        /// </summary>
        [Parameter]
        public virtual string? Filtrate { get; set; }

        /// <summary>
        /// 最大多选
        /// </summary>
        [Parameter]
        public virtual int? MaxMultiple { get; set; }

        /// <summary>
        /// 多选
        /// 一个选择下拉菜单可以允许多个选择。
        /// A selection dropdown can allow multiple selections
        /// </summary>
        [Parameter]
        public virtual bool Multiple { get; set; }

        /// <summary>
        /// 子内容
        /// </summary>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 选中的标签页键变化
        /// </summary>
        [Parameter]
        public EventCallback<TKey[]> SelectedKeysChanged { get; set; }

        /// <summary>
        /// Gets or sets an expression that identifies the bound value.
        /// </summary>
        [Parameter]
        public Expression<Func<TKey[]>>? SelectedKeysExpression { get; set; }

        /// <summary>
        /// 选中的标签页键变化
        /// </summary>
        [Parameter]
        public EventCallback<TKey[]> OnSelectedKeysChange { get; set; }

        /// <summary>
        /// 聚焦的选项
        /// </summary>
        [Parameter]
        public EventCallback<TOption> OnFocusOption { get; set; }

        /// <summary>
        /// 选中的选项
        /// </summary>
        [Parameter]
        public EventCallback<TOption> OnSelectedOption { get; set; }

        /// <summary>
        /// 点击的选项
        /// </summary>
        [Parameter]
        public EventCallback<TOption> OnClickOption { get; set; }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            FirstSelectedKeys = SelectedKeys;
        }

        /// <summary>
        /// 设置属性后
        /// </summary>
        protected override void OnParametersSet()
        {
            //if(!(SelectedKeys?.Any() ?? true) && DefaultSelectedKey != null)
            //{
            //    SelectedKeys = new TKey[] { DefaultSelectedKey };
            //}
            base.OnParametersSet();
            SelectedKeys ??= (DefaultSelectedKey != null) ? new TKey[] { DefaultSelectedKey } : Array.Empty<TKey>();
            FilteredKeys ??= Array.Empty<TKey>();
        }

        #endregion

        /// <summary>
        /// 选择清空
        /// </summary>
        protected virtual void SelectClear()
        {
            FocusOption = null;
        }

        /// <summary>
        /// 通知项目状态变化
        /// </summary>
        /// <param name="newKeys"></param>
        /// <param name="oldKeys"></param>
        protected virtual void NotifyOptionStateHasChanged(TKey[]? newKeys = null, TKey[]? oldKeys = null)
        {
            if (Options == null || Options.Count <= 0)
                return;
            var notifyKeys = (newKeys == null && oldKeys == null) ? Options.Select(kv => kv.Key).ToArray() : Array.Empty<TKey>();
            newKeys ??= Array.Empty<TKey>();
            oldKeys ??= Array.Empty<TKey>();
            notifyKeys = newKeys.Except(oldKeys).Concat(oldKeys.Except(newKeys)).ToArray();
            notifyKeys.Where(nk => nk != null)
                .Where(nk => Options.ContainsKey(nk))
                .Select(nk => Options[nk])
                .ForEach(option => option.NotifyStateHasChanged());
        }

        /// <summary>
        /// 当前项目
        /// </summary>
        /// <returns>TOption / Null</returns>
        internal virtual TOption? CurrenTOption()
        {
            if (SelectedKeys != null && SelectedKeys.Length > 0)
            {
                var key = SelectedKeys[SelectedKeys.Length - 1];
                if (Options.TryGetValue(key, out TOption? option))
                {
                    return option;
                }
            }
            return null;
        }

        /// <summary>
        /// 是否有选中项
        /// </summary>
        /// <returns></returns>
        internal virtual bool IsSelected()
        {
            return (SelectedKeys?.Length ?? 0) > 0 && Options.Count > 0;
        }

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public virtual bool AddOption(TOption option)
        {
            if (option == null || option.Key == null)
                return false;

            var key = option.Key;
            if (Options.ContainsKey(key))
            {
                var oldoption = Options[key];
                if (oldoption.OptionId != option.OptionId)
                {
                    option.OptionId = oldoption.OptionId;
                    Options[key] = option;
                }
            }

            var firstAdd = Options.Count <= 0;
            var addResult = Options.TryAdd(key, option);
            if (firstAdd && addResult)
            {
                StateHasChanged();
            }

            return addResult || Options[key] == option;
        }

        /// <summary>
        /// 聚焦的项目
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public virtual async Task FocusOptionAsync(TOption option)
        {
            if (option == null || option.Key == null || option.Disabled || Disabled)
                return;

            var oldKey = FocusOption == null ? default : FocusOption.Key;
            FocusOption = option;
            NotifyOptionStateHasChanged(new[] { oldKey, option.Key });
            await OnFocusOption.InvokeAsync(option);
        }

        /// <summary>
        /// 选中的项目
        /// </summary>
        /// <param name="option"></param>
        /// <param name="isClick"></param>
        public virtual async Task SelectedOptionAsync(TOption option, bool isClick = false)
        {
            if (option == null || option.Key == null || option.Disabled || Disabled)
                return;
            var selectedKeys = SelectedKeys ?? Array.Empty<TKey>();
            var key = option.Key;
            if (selectedKeys?.Contains(key) ?? false)
            {
                var _aks = selectedKeys.ToList();
                _aks.Remove(key);
                selectedKeys = _aks.ToArray();
            }
            else
            {
                if (Multiple && selectedKeys != null)
                {
                    if ((MaxMultiple ?? int.MaxValue) <= selectedKeys.Length)
                    {
                        var _aks = new TKey[selectedKeys.Length];
                        for (int i = 0; i < _aks.Length - 1; i++)
                        {
                            _aks[i] = selectedKeys[i + 1];
                        }
                        _aks[^1] = key;
                        selectedKeys = _aks;
                    }
                    else
                    {
                        var _aks = new TKey[selectedKeys.Length + 1];
                        for (int i = 0; i < selectedKeys.Length; i++)
                        {
                            _aks[i] = selectedKeys[i];
                        }
                        _aks[^1] = key;
                        selectedKeys = _aks;
                    }
                }
                else
                {
                    selectedKeys = new TKey[] { key };
                }
            }

            await SetSelectedKeys(selectedKeys);
            SelectedOption = option;
            await OnSelectedOption.InvokeAsync(SelectedOption);
            if (isClick)
            {
                await OnClickOption.InvokeAsync(option);
            }
            SelectClear();
        }

        /// <summary>
        /// 项目是否选中
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public virtual bool OptionIsSelected(TOption option)
        {
            if (option == null || option.Key == null)
                return false;

            var key = option.Key;
            return SelectedKeys?.Contains(key) ?? false;
        }

        /// <summary>
        /// 项目是否聚焦
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public virtual bool OptionIsFocus(TOption option)
        {
            if (option == null || option.Key == null)
                return false;

            var optionId = option.OptionId;
            //return FocusOption.Key == key;
            return FocusOption?.OptionId == optionId;
        }

        /// <summary>
        /// 项目是否过滤
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public virtual bool OptionIsFiltered(TOption option)
        {
            if (option == null || option.Key == null)
                return false;

            var key = option.Key;
            return FilteredKeys?.Contains(key) ?? false;
        }

        /// <summary>
        /// 清除
        /// </summary>
        public virtual async Task Clear()
        {
            if (SelectedKeys == null || SelectedKeys.Length <= 0)
                return;
            var notifyOptionKeys = SelectedKeys;
            await SetSelectedKeys(Array.Empty<TKey>());
        }

        /// <summary>
        /// 设置 SelectedKeys
        /// </summary>
        /// <param name="selectedKeys"></param>
        /// <returns></returns>
        protected virtual async Task SetSelectedKeys(TKey[] selectedKeys)
        {
            SelectedKeys = selectedKeys ?? Array.Empty<TKey>();
            StateHasChanged();
            await SelectedKeysChanged.InvokeAsync(SelectedKeys);
            await OnSelectedKeysChange.InvokeAsync(SelectedKeys);
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            SelectedKeys = FirstSelectedKeys;
            StateHasChanged();
        }
    }
}
