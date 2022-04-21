using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 组件上下文
    /// </summary>
    public class BxComponentContext
    {
        /// <summary>
        /// 父组件
        /// </summary>
        public BxComponentBase FatherComponent { get; }

        /// <summary>
        /// 子组件集
        /// </summary>
        public IDictionary<Type, Dictionary<string, BxComponentBase>> SonsComponents { get; }

        /// <summary>
        /// 组件上下文
        /// </summary>
        /// <param name="fatherComponent"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public BxComponentContext(BxComponentBase fatherComponent)
        {
            FatherComponent = fatherComponent ?? throw new ArgumentNullException(nameof(fatherComponent));
            SonsComponents = new Dictionary<Type, Dictionary<string, BxComponentBase>>();
        }

        /// <summary>
        /// 添加子组件
        /// </summary>
        /// <param name="component"></param>
        public void AddSonComponent(BxComponentBase component)
        {
            if (component == null)
            {
                return;
            }

            var type = component.GetType();
            
            if (!SonsComponents.ContainsKey(type))
            {
                SonsComponents.Add(type, new Dictionary<string, BxComponentBase>());
            }

            if (!SonsComponents[type].ContainsKey(component.Id))
            {
                SonsComponents[type].TryAdd(component.Id, component);
            }
        }
    }
}
