using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CarbonBlazor.Extensions
{
    /// <summary>
    /// 类型扩展
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// 获取 Field Display
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static KeyValuePair<FieldInfo, DisplayAttribute>[] GetFieldDisplays(this Type type)
        {
            var fields = type.GetFields(BindingFlags.Static | BindingFlags.Public)
            //.Where(field => field.GetCustomAttributes<DisplayAttribute>()?.Any() ?? false)
            .Select(field => KeyValuePair.Create(field, field.GetCustomAttribute<DisplayAttribute>()))
            .ToArray();

            return fields;
        }
    }
}
