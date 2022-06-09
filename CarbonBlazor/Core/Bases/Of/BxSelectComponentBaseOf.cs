using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
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
    public abstract partial class BxSelectComponentBaseOf<TOption, TKey> : BxComponentBase, IBxSelectOf<TOption, TKey>
        where TOption : class, IBxOptionOf<TKey>
        where TKey : notnull
    {
        /// <summary>
        /// 选项集合
        /// </summary>
        protected Dictionary<TKey, TOption> Options { get; set; } = new();

        /// <summary>
        /// 当前聚焦选项键
        /// </summary>
        protected virtual TKey? CurrentFocusKey { get; set; }

        /// <summary>
        /// 当前选中选项键
        /// </summary>
        protected virtual TKey? CurrentSelectedKey { get; set; }

        /// <summary>
        /// 第一次选中的选项键
        /// </summary>
        protected virtual TKey[]? FirstSelectedKeys { get; set; }

        /// <summary>
        /// 第一次选中的选项键
        /// </summary>
        protected virtual TKey? FirstSelectedKey { get; set; }

        /// <summary>
        /// 渲染阶段
        /// </summary>
        public BxRenderPhase RenderPhase { get; protected set; }

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            FirstSelectedKeys = SelectedKeys;
            FirstSelectedKey = SelectedKey;
        }

        #endregion 

        /// <summary>
        /// 登记选项
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool EnrollOption(TOption option)
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
                InvokeStateHasChanged();
            }

            return addResult || Options[key] == option;
        }

        /// <summary>
        /// 聚焦的选项
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public async Task FocusOptionAsync(TOption option)
        {
            if (option == null || option.Key == null || option.Disabled || Disabled)
                return;

            var oldKey = CurrentFocusKey;
            CurrentFocusKey = option.Key;
            if (oldKey != null)
            {
                NotifyOptionStateHasChanged(oldKey, option.Key);
            }
            else
            {
                NotifyOptionStateHasChanged(option.Key);
            }
            await OnFocusOption.InvokeAsync(option);
        }

        /// <summary>
        /// 选中的选项
        /// </summary>
        /// <param name="option"></param>
        /// <param name="isClick"></param>
        /// <returns></returns>
        public async Task SelectedOptionAsync(TOption option, bool isClick = false)
        {
            if (option == null || option.Key == null || option.Disabled || Disabled)
                return;
            var selectedKeys = SelectedKeys ?? Array.Empty<TKey>();
            var key = option.Key;
            if (selectedKeys?.Contains(key) ?? false)
            {
                var aks = selectedKeys.ToList();
                aks.Remove(key);
                selectedKeys = aks.ToArray();
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
            CurrentSelectedKey = key;
            await OnSelectedOption.InvokeAsync(option);
            if (isClick)
            {
                await OnClickOption.InvokeAsync(option);
            }
            FocusClear();
        }

        /// <summary>
        /// 选项是过滤
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool OptionIsInFiltered(TKey key)
        {
            if (key == null)
                return false;

            if (Filtered != null && Options.TryGetValue(key, out TOption? option))
            {
                return Filtered.Invoke(option);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 选项是聚焦
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool OptionIsInFocus(TKey key)
        {
            if (key == null || CurrentFocusKey == null)
                return false;

            return key.Equals(CurrentFocusKey);
        }

        /// <summary>
        /// 选项是选中
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool OptionIsInSelected(TKey key)
        {
            if (key == null || SelectedKeys == null || !SelectedKeys.Any())
                return false;

            return SelectedKeys?.Contains(key) ?? false;
        }

        /// <summary>
        /// 聚焦清空
        /// </summary>
        protected virtual void FocusClear()
        {
            CurrentFocusKey = default(TKey);
        }

        /// <summary>
        /// 通知项目状态变化
        /// </summary>
        /// <param name="newKeys"></param>
        /// <param name="oldKeys"></param>
        protected virtual void NotifyOptionStateHasChanged(TKey[]? newKeys = null, TKey[]? oldKeys = null)
        {
            var notifyKeys = (newKeys == null && oldKeys == null) ? Options.Select(kv => kv.Key).ToArray() : Array.Empty<TKey>();
            newKeys ??= Array.Empty<TKey>();
            oldKeys ??= Array.Empty<TKey>();
            notifyKeys = newKeys
                .Except(oldKeys)
                .Concat(oldKeys
                .Except(newKeys))
                .ToArray();
            NotifyOptionStateHasChanged(notifyKeys);
        }

        /// <summary>
        /// 通知项目状态变化
        /// </summary>
        /// <param name="keys"></param>
        protected virtual void NotifyOptionStateHasChanged(params TKey[]? keys)
        {
            if (Options == null || Options.Count <= 0)
                return;
            var notifyKeys = (keys == null || keys.Length == 0) ? Options.Select(kv => kv.Key).ToArray() : keys;
            notifyKeys
                .Where(nk => nk != null && Options.ContainsKey(nk))
                .Select(nk => Options[nk])
                .ForEach(option => option.NotifyStateHasChanged());
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

            await SelectedKeyChanged.InvokeAsync(SelectedKeys.LastOrDefault());
            await OnSelectedKeyChange.InvokeAsync(SelectedKeys.LastOrDefault());
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
