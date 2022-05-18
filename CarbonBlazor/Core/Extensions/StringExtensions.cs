using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Extensions
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static  class StringExtensions
    {
        /// <summary>
        /// 转首字母小写
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static string ToInitialLower(this string str)
        {
            return str.Substring(0, 1).ToLowerInvariant() + str[1..];
        }

        /// <summary>
        /// 转首字母大写
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static string ToInitialUpper(this string str)
        {
            return str.Substring(0, 1).ToUpperInvariant() + str[1..];
        }

        /// <summary>
        /// 转选项名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ToOptionName(this string name)
        {
            return name.ToInitialLower();
        }
    }
}
