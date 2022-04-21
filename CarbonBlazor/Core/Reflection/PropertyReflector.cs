using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 字段反射器
    /// </summary>
    public struct PropertyReflector
    {
        /// <summary>
        /// 属性信息
        /// </summary>
        public PropertyInfo PropertyInfo { get; }

        /// <summary>
        /// 必须
        /// </summary>
        public RequiredAttribute RequiredAttribute { get; set; }

        /// <summary>
        /// 显示
        /// </summary>
        public DisplayAttribute DisplayAttribute { get; set; }

        /// <summary>
        /// 只读
        /// </summary>
        public ReadOnlyAttribute ReadOnlyAttribute { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 字段反射器
        /// </summary>
        /// <param name="propertyInfo"></param>
        private PropertyReflector(PropertyInfo propertyInfo)
        {
            this.PropertyInfo = propertyInfo;
            this.RequiredAttribute = propertyInfo.GetCustomAttribute<RequiredAttribute>(true);
            this.DisplayAttribute = propertyInfo.GetCustomAttribute<DisplayAttribute>(true);
            this.ReadOnlyAttribute = propertyInfo.GetCustomAttribute<ReadOnlyAttribute>(true);
            this.DisplayName = 
                propertyInfo.GetCustomAttribute<DisplayNameAttribute>(true)?.DisplayName ??
                propertyInfo.GetCustomAttribute<DisplayAttribute>(true)?.GetName() ??
                propertyInfo.Name;
            this.PropertyName = PropertyInfo.Name;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="accessor"></param>
        /// <returns></returns>
        public static PropertyReflector Create<TField>(Expression<Func<TField>> accessor)
        {
            if (accessor == null)
            {
                throw new ArgumentNullException(nameof(accessor));
            }

            var accessorBody = accessor.Body;

            if (accessorBody is UnaryExpression unaryExpression
               && unaryExpression.NodeType == ExpressionType.Convert
               && unaryExpression.Type == typeof(object))
            {
                accessorBody = unaryExpression.Operand;
            }

            if (!(accessorBody is MemberExpression memberExpression))
            {
                throw new ArgumentException($"The provided expression contains a {accessorBody.GetType().Name} which is not supported. {nameof(PropertyReflector)} only supports simple member accessors (fields, properties) of an object.");
            }

            var property = memberExpression.Member as PropertyInfo;

            return new PropertyReflector(property);
        }
    }
}
