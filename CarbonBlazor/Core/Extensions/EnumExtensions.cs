using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarbonBlazor.Extensions
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取枚举 名称
        /// </summary>
        /// <returns></returns>
        public static KeyValuePair<string, string>[] GetEnumDisplayNames<TEnum>(this TEnum @enum)
            where TEnum : struct, Enum

        {
            var type = typeof(TEnum);

            return type.GetFieldDisplays().Select(kv => KeyValuePair.Create(kv.Key.Name, kv.Value?.Name ?? kv.Key.Name)).ToArray();
        }

        /// <summary>
        /// 获取枚举 名称
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static KeyValuePair<string, string>[] GetEnumDisplayNames(this Type enumType)
        {
            enumType = Nullable.GetUnderlyingType(enumType) ?? enumType;
            return enumType.GetFieldDisplays().Select(kv => KeyValuePair.Create(kv.Key.Name, kv.Value?.Name ?? kv.Key.Name)).ToArray();
        }
    }
}
