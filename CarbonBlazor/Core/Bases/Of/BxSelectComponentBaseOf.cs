using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 具有选择的组件 (Select ListBox)
    /// </summary>
    public abstract partial class BxSelectComponentBaseOf<TOption, TKey> : BxFormItemComponentBaseOf<TKey>, IBxSelectOf<TOption, TKey>
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
        /// 当前选中选项键
        /// </summary>
        protected virtual TKey[]? CurrentSelectedKeys { get; set; }

        /// <summary>
        /// 第一次选中的选项键
        /// </summary>
        protected virtual TKey[]? FirstSelectedKeys { get; set; }

        /// <summary>
        /// 第一次选中的选项键
        /// </summary>
        protected virtual TKey? FirstSelectedKey { get; set; }

        /// <summary>
        /// 是否渲染
        /// </summary>
        public virtual bool IsRender { get; } = true;

        /// <summary>
        /// 渲染树
        /// </summary>
        /// <param name="__builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {
            var sequence = 0;

            __builder.AddCascadingValue(ref sequence, ComponentContext, __builder =>
            {
                var sequence = 0;
                __builder.AddCascadingValue<IBxSelectOf<TOption, TKey>>(ref sequence, this, ContentFragment(), "FatherSelect", true);

            }, "FatherComponentContext", true);
        }

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

        /// <summary>
        /// 设置参数后
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        #endregion 

        /// <summary>
        /// 登记选项
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public virtual bool EnrollOption(TOption option)
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
        public virtual async Task FocusOptionAsync(TOption option)
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
        public virtual async Task SelectedOptionAsync(TOption option, bool isClick = false)
        {
            if (option == null || option.Key == null || option.Disabled || Disabled)
                return;
            var selectedKeys = CurrentSelectedKeys ?? Array.Empty<TKey>();
            var keys = new TKey[selectedKeys.Length];
            selectedKeys.CopyTo(keys, 0);

            var key = option.Key;
            if (keys?.Contains(key) ?? false)
            {
                if (SelectedCancel)
                {
                    var aks = keys.ToList();
                    aks.Remove(key);
                    keys = aks.ToArray();
                }
            }
            else
            {
                if (Multiple && keys != null)
                {
                    if ((MaxMultiple ?? int.MaxValue) <= keys.Length)
                    {
                        var _aks = new TKey[keys.Length];
                        for (int i = 0; i < _aks.Length - 1; i++)
                        {
                            _aks[i] = keys[i + 1];
                        }
                        _aks[^1] = key;
                        keys = _aks;
                    }
                    else
                    {
                        var _aks = new TKey[keys.Length + 1];
                        for (int i = 0; i < keys.Length; i++)
                        {
                            _aks[i] = keys[i];
                        }
                        _aks[^1] = key;
                        keys = _aks;
                    }
                }
                else
                {
                    keys = new TKey[] { key };
                }
            }

            await SetSelectedKeys(keys);
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
        public virtual bool OptionIsInFiltered(TKey key)
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
        public virtual bool OptionIsInFocus(TKey? key)
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
        public virtual bool OptionIsInSelected(TKey? key)
        {
            if (key == null)
                return false;

            //if (Multiple)
            //{
            //    if(CurrentSelectedKeys == null || !CurrentSelectedKeys.Any())
            //        return false;
            //    return CurrentSelectedKeys?.Contains(key) ?? false;
            //}
            //else
            //{
            //    return EqualityComparer<TKey>.Default.Equals(CurrentSelectedKey, key);
            //}

            if (CurrentSelectedKeys == null || !CurrentSelectedKeys.Any())
                return false;

            return CurrentSelectedKeys?.Contains(key) ?? false;
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
            await SetSelectedKeys(Array.Empty<TKey>());
        }

        /// <summary>
        /// 设置 SelectedKeys
        /// </summary>
        /// <param name="selectedKeys"></param>
        /// <returns></returns>
        protected virtual async Task SetSelectedKeys(TKey[]? selectedKeys)
        {
            selectedKeys ??= Array.Empty<TKey>();
            var oldSelectedKeys = CurrentSelectedKeys;

            CurrentSelectedKeys = selectedKeys;
            CurrentSelectedKey = CurrentSelectedKeys.FirstOrDefault();

            var key = selectedKeys.LastOrDefault();
            var hasChanged = !EqualityComparer<TKey>.Default.Equals(key, SelectedKey);
            if (hasChanged)
            {
                SelectedKey = key;
                await SelectedKeyChanged.InvokeAsync(SelectedKey);
                await OnSelectedKeyChange.InvokeAsync(SelectedKey);
            }

            hasChanged = !EqualityComparer<TKey[]>.Default.Equals(selectedKeys, SelectedKeys);

            if (hasChanged)
            {
                SelectedKeys = selectedKeys;
                await SelectedKeysChanged.InvokeAsync(SelectedKeys);
                await OnSelectedKeysChange.InvokeAsync(SelectedKeys);
            }

            await SetValueAsync(key);

            NotifyOptionStateHasChanged(CurrentSelectedKeys, oldSelectedKeys);

            await InvokeStateHasChangedAsync();
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            SelectedKeys = FirstSelectedKeys;
            InvokeStateHasChanged();
        }
    }
}
