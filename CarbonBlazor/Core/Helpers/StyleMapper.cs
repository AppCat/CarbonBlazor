using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 字典映射
    /// </summary>
    public class StyleMapper
    {
        /// <summary>
        /// 样式映射表
        /// </summary>
        private readonly Dictionary<string, (Func<string> value, Func<bool> allow)> _styleMap = new();

        /// <summary>
        /// 结果
        /// </summary>
        public string Result => AsString();

        /// <summary>
        /// 原始
        /// </summary>
        internal string? Original { get; set; }

        /// <summary>
        /// 映射
        /// </summary>
        /// <param name="styleMap"></param>
        public StyleMapper(Dictionary<string, (Func<string> value, Func<bool> allow)>? styleMap = null)
        {
            Clear();
            _styleMap = styleMap ?? new();
        }

        /// <summary>
        /// 作为字符串
        /// </summary>
        /// <returns></returns>
        public string AsString()
        {
            var styles = _styleMap.Where(i => i.Value.allow()).Select(i => $"{i.Key}:{i.Value.value()};").Distinct();
            return $"{string.Join(" ", styles)}{(!string.IsNullOrEmpty(Original) ? $" {Original}" : "")}";
        }

        /// <summary>
        /// 转字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return AsString();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public StyleMapper Add(string name, string value)
        {
            AddGetIf(name, () => value, () => true);
            return this;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public StyleMapper AddGet(string name, Func<string> value)
        {
            AddGetIf(name, value, () => true);
            return this;    
        }

        /// <summary>
        /// 如果添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="allow"></param>
        /// <returns></returns>
        public StyleMapper AddIf(string name, string value, Func<bool> allow)
        {
            AddGetIf(name, () => value, allow);
            return this;
        }

        /// <summary>
        /// 如果添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="allow"></param>
        /// <returns></returns>
        public StyleMapper AddGetIf(string name, Func<string> value, Func<bool> allow)
        {
            if (!_styleMap.ContainsKey(name))
            {
                _styleMap.Add(name, (value, allow));
            }

            return this;
        }

        /// <summary>
        /// 如果添加或更新
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="allow"></param>
        /// <returns></returns>
        public StyleMapper AddGetOrUpdateIf(string name, Func<string> value, Func<bool> allow)
        {
            if (_styleMap.ContainsKey(name))
            {
                _styleMap[name] = (value, allow);
            }
            else
            {
                _styleMap.Add(name, (value, allow));
            }

            return this;
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public StyleMapper Clear()
        {
            _styleMap.Clear();

            return this;
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public StyleMapper Copy()
        {
            return new StyleMapper(new Dictionary<string, (Func<string> value, Func<bool> allow)>(_styleMap))
            {
                Original = this.Original
            };
        }
    }
}
