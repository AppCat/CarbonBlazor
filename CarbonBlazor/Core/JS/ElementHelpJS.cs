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
        /// 获取元素属性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="propertys"></param>
        /// <returns></returns>
        public async Task<TValue?> GetElementPropertyByIdAsync<TValue>(string id, params string[] propertys)
        {
            var module = await _moduleTask.Value;
            var result = await module.InvokeAsync<object>("getElementPropertyById", id, propertys);
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
        /// 获取样式
        /// </summary>
        /// <param name="id"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public async Task<string?> GetComputedStyleByIdAsync(string id, string property)
        {
            var module = await _moduleTask.Value;
            var result = await module.InvokeAsync<string>("getComputedStyleById", id, property);
            return result == "_null_" ? null : result;
        }

        /// <summary>
        /// 获取多个样式
        /// </summary>
        /// <param name="id"></param>
        /// <param name="propertys"></param>
        /// <returns></returns>
        public async Task<string[]?> GetComputedStylesByIdAsync(string id, params string[] propertys)
        {
            var module = await _moduleTask.Value;
            var result = await module.InvokeAsync<string[]>("getComputedStylesById", id, propertys);
            return result.Length != propertys.Length ? null : result;
        }
    }
}
