using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 类特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]   
    public class EnumClassAttribute : Attribute
    {
        /// <summary>
        /// 类
        /// </summary>
        public string Class { get; }

        /// <summary>
        /// 类特性
        /// </summary>
        /// <param name="class"></param>
        public EnumClassAttribute(string @class)
        {
            Class = @class ?? throw new ArgumentNullException(nameof(@class));
        }
    }

    /// <summary>
    /// 扩展
    /// </summary>
    public static class EnumClassAttributeExtension
    {
        /// <summary>
        /// 枚举 => 类
        /// </summary>
        private static ConcurrentDictionary<string, string> _enumClass = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// 转类
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string ToClass(this Enum @enum)
        {
            var type = @enum.GetType();
            var name = Enum.GetName(type, @enum);
            var key = $"{type}-{name}";
            if (_enumClass.TryGetValue(key, out string @class))
            {
                return @class;
            }
            else
            {
                var field = type.GetField(name);
                if (field == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                var abe = Attribute.GetCustomAttribute(field, typeof(EnumClassAttribute), true) ?? new EnumClassAttribute(name.ToLowerInvariant());
                @class = (abe as EnumClassAttribute).Class;
                _enumClass.TryAdd(key, @class);
                return _enumClass[key];
            }
        }

        /// <summary>
        /// 转类
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumMix"></param>
        /// <returns></returns>
        public static string ToClass<TEnum>(this EnumMix<TEnum> enumMix)
            where TEnum : Enum
        {
            if(enumMix == null)
            {
                throw new ArgumentNullException(nameof(enumMix));
            }

            return enumMix.Value.ToClass();
        }
    }
}
