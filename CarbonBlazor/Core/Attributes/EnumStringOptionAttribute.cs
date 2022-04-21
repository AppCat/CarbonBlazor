using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 枚举字符串
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class EnumStringOptionAttribute : Attribute
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// 枚举字符串
        /// </summary>
        /// <param name="content"></param>
        public EnumStringOptionAttribute(string content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }
    }
}
