using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 类型定义
    /// </summary>
    public static class TypeDefined<TValue>
    {
        /// <summary>
        /// 是否空
        /// </summary>
        public static bool IsNullable { get; }

        /// <summary>
        /// 是泛型类型
        /// </summary>
        public static bool IsGenericType { get; }

        /// <summary>
        /// 可空类型
        /// </summary>
        public static Type NullableType { get; }

        /// <summary>
        /// 构建
        /// </summary>
        static TypeDefined()
        {
            IsNullable = IsNullableType(typeof(TValue));
            NullableType = GetNullableGenericType(typeof(TValue));
            IsGenericType = typeof(TValue).IsGenericType;
        }

        /// <summary>
        /// 是可空类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        /// 是泛型类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static Type GetNullableGenericType(Type type)
        {
            return IsNullableType(type) ? type.GetGenericArguments()[0] : null;
        }
    }
}
