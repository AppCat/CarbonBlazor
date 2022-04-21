using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 通过 Web Components 实现的组件
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    public abstract class BxPropertieComponentBase<TComponent> : BxComponentBase
    {
        /// <summary>
        /// 组件属性缓存
        /// </summary>
        protected static Dictionary<string, IReadOnlyCollection<(string name, Func<TComponent, object?> getValue)>> BxProperties = new Dictionary<string, IReadOnlyCollection<(string name, Func<TComponent, object?> getValue)>>();

        /// <summary>
        /// 属性初始化
        /// </summary>
        internal virtual IReadOnlyCollection<(string name, Func<TComponent, object?> getValue)> GetBxProperties()
        {
            var type = this.GetType();
            var key = type.FullName ?? type.Name;

            var start = DateTime.Now;

            try
            {
                if (!BxProperties.ContainsKey(key))
                {
                    var properties = new List<(string name, Func<TComponent, object?> getValue)>();
                    foreach (var propertie in type.GetProperties().Where(propertie => propertie.GetCustomAttributes(true).Any(attri => attri is BxPropertieAttribute)))
                    {
                        var paramObj = Expression.Parameter(type);



                        var result = Expression.Lambda<Func<TComponent, object>>(Expression.Convert(Expression.Property(paramObj, propertie), typeof(object)), paramObj);
                        var compile = result.Compile();
                        if (propertie.PropertyType.IsGenericType && propertie.PropertyType.GetGenericTypeDefinition() == typeof(EnumMix<>))
                        {
                            properties.Add((propertie.Name.ToLowerInvariant(), t => (compile(t)).ToString()));
                        }
                        else
                        {
                            properties.Add((propertie.Name.ToLowerInvariant(), compile));
                        }
                    }

                    BxProperties.TryAdd(key, properties.AsReadOnly());

                    return GetBxProperties();
                }
                else
                {
                    return BxProperties[key];
                }
            }
            finally
            {
                var end = DateTime.Now;

                Console.WriteLine($"耗时: {(end - start).TotalMilliseconds} ms");
            }
        }
    }
}
