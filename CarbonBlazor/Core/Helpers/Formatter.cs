using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 格式化程序
    /// </summary>
    public static class Formatter<TValue>
    {
        /// <summary>
        /// 格式函数
        /// </summary>
        private static readonly Lazy<Func<TValue, string, string>> _formatFunc = new Lazy<Func<TValue, string, string>>(GetFormatLambda, true);

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="source"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string Format(TValue source, string format)
        {
            return _formatFunc.Value.Invoke(source, format);
        }

        /// <summary>
        /// 获取格式 Lambda
        /// </summary>
        /// <returns></returns>
        private static Func<TValue, string, string> GetFormatLambda()
        {
            var sourceType = typeof(TValue);
            var sourceProperty = Expression.Parameter(typeof(TValue));
            var formatString = Expression.Parameter(typeof(string));

            Expression variable = sourceProperty;
            Expression body = Expression.Call(sourceProperty, typeof(object).GetMethod(nameof(ToString)));
            Expression hasValueExpression = sourceType.IsValueType ? (Expression)Expression.Constant(true) : Expression.NotEqual(sourceProperty, Expression.Default(sourceType));
            Expression parsedFormatString = formatString;

            if (sourceType == typeof(TimeSpan))
            {
                parsedFormatString = Expression.Call(typeof(Formatter<TimeSpan>).GetMethod(nameof(ParseSpanTimeFormatString), BindingFlags.NonPublic | BindingFlags.Static), formatString);
            }

            if (TypeDefined<TValue>.IsNullable)
            {
                sourceType = TypeDefined<TValue>.NullableType;
                hasValueExpression = Expression.Equal(Expression.Property(sourceProperty, "HasValue"), Expression.Constant(true));
                variable = Expression.Condition(hasValueExpression, Expression.Property(sourceProperty, "Value"), Expression.Default(sourceType));
            }

            if (sourceType.IsSubclassOf(typeof(IFormattable)))
            {
                var method = sourceType.GetMethod(nameof(ToString), new[] { typeof(string), typeof(IFormatProvider) });
                body = Expression.Call(Expression.Convert(variable, sourceType), method, parsedFormatString, Expression.Constant(null));
            }
            else
            {
                var method = sourceType.GetMethod(nameof(ToString), new[] { typeof(string) });
                if (method != null)
                {
                    body = Expression.Call(Expression.Convert(variable, sourceType), method, parsedFormatString);
                }
            }

            var condition = Expression.Condition(hasValueExpression, body, Expression.Constant(string.Empty));
            return Expression.Lambda<Func<TValue, string, string>>(condition, sourceProperty, formatString).Compile();
        }

        /// <summary>
        /// parse other characters in format string.
        /// </summary>
        /// <remarks>refer to https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-timespan-format-strings#other-characters</remarks>
        /// <param name="format"></param>
        /// <returns></returns>
        private static string ParseSpanTimeFormatString(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                return format;
            }
            return Regex.Replace(format, "[^d|^h|^m|^s|^f|^F]+", "'$0'");
        }
    }
}
