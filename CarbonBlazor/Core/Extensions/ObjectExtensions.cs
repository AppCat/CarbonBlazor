using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Extensions
{
    /// <summary>
    /// 对象扩展
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// 转整理后的对象
        /// </summary>
        /// <returns></returns>
        public static object ToTrimObject(this object option)
        {
            if (option == null)
            {
                throw new ArgumentNullException(nameof(option));
            }
            return option.ToTrimObject(option.GetType());
        }

        /// <summary>
        /// 转整理后的对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static object ToTrimObject(this object obj, Type currentType = null)
        {
            if (obj == default)
                return default;
            var type = currentType ?? obj.GetType();
            try
            {
                 if (obj is string srt)
                {
                    return srt;
                }
                else if (obj is System.Collections.IEnumerable enumerable)
                {
                    return enumerable.ToTrimObject();
                }
                else if (type.IsClass || type.IsInterface)
                {
                    var dic = type.GetProperties().ToTrimObject(obj);
                    return dic;
                }
                else if (type.IsEnum)
                {
                    var name = Enum.GetName(type, obj);
                    var field = type.GetField(name);
                    var abe = Attribute.GetCustomAttribute(field, typeof(EnumStringOptionAttribute), true) ?? new EnumStringOptionAttribute(name.ToLower());
                    var content = (abe as EnumStringOptionAttribute).Content;
                    return content;
                }
                else if (type.IsValueType)
                {
                    return obj;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"error: {e.Message}/{e.StackTrace} {type.Name}");
                return default;
            }
            finally
            {
            }
            return default;
        }

        /// <summary>
        /// 转整理后的对象
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="obj"></param>
        /// <param name="old"></param>
        /// <returns></returns>
        private static IDictionary<string, object> ToTrimObject(this PropertyInfo[] properties, object obj, IDictionary<string, object> old = null)
        {
            var dic = old ?? new Dictionary<string, object>();
            foreach (var propertie in properties)
            {
                var pn = propertie.Name.ToOptionName();
                if (propertie.GetCustomAttributes(typeof(NotOptionAttribute), true).Any())
                    continue;
                if (propertie.GetCustomAttributes(typeof(UnrealizedOptionAttribute), true).Any())
                    continue;
                var value = propertie.GetValue(obj);
                if (value != default)
                {
                    var ov = value.ToTrimObject();
                    if (ov != default)
                        dic.Add(pn, ov);
                }
            }
            return dic;
        }

        /// <summary>
        /// 转整理后的对象
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        private static object ToTrimObject(this System.Collections.IEnumerable enumerable)
        {
            var list = new List<object>();
            foreach (var item in enumerable)
            {
                var ov = item.ToTrimObject();
                if (ov != default)
                    list.Add(ov);
            }
            return list;
        }
    }
}
