using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 元素帮助JS
    /// </summary>
    public class ElementHelpJS
    {
        protected readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        /// <summary>
        /// 元素帮助JS
        /// </summary>
        /// <param name="jsRuntime"></param>
        public ElementHelpJS(IJSRuntime jsRuntime)
        {
            _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/CarbonBlazor/js/elementHelp.js").AsTask());
        }

        /// <summary>
        /// 查找元素属性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="propertys"></param>
        /// <returns></returns>
        public async Task<TValue?> FindElementPropertyByIdAsync<TValue>(string id, params string[] propertys)
        {
            var module = await _moduleTask.Value;
            var result = await module.InvokeAsync<object>("findElementPropertyById", id, propertys);
            if (result == null)
            {
                return default(TValue);
            }
            else
            {
                var value = Convert.ChangeType(result?.ToString(), typeof(TValue));
                return value == null ? default(TValue) : (TValue)value;
            }
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="id"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task SetStyleByIdAsync(string id, string property, string value)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("setStyleByIdAsync", id, property, value);
        }

        /// <summary>
        /// 查找样式
        /// </summary>
        /// <param name="id"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public async Task<string?> FindComputedStyleByIdAsync(string id, string property)
        {
            var module = await _moduleTask.Value;
            var result = await module.InvokeAsync<string>("findComputedStyleById", id, property);
            return result == "_null_" ? null : result;
        }

        /// <summary>
        /// 查找多个样式
        /// </summary>
        /// <param name="id"></param>
        /// <param name="propertys"></param>
        /// <returns></returns>
        public async Task<string[]?> FindComputedStylesByIdAsync(string id, params string[] propertys)
        {
            var module = await _moduleTask.Value;
            var result = await module.InvokeAsync<string[]>("findComputedStylesById", id, propertys);
            return result.Length != propertys.Length ? null : result;
        }
    }
}
