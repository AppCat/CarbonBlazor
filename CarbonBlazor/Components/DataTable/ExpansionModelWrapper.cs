using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 扩展模型包装器
    /// </summary>
    public class ExpansionModelWrapper<TModel> : IExpansionModel
    {
        /// <summary>
        /// 模型
        /// </summary>
        public TModel? Model { get; }

        /// <summary>
        /// 展开
        /// </summary>
        public bool Expanded { get; set; }

        /// <summary>
        /// 扩展内容
        /// </summary>
        public string? ExpansionContent { get; set; }

        /// <summary>
        /// 扩展内容模板
        /// </summary>
        public RenderFragment? ExpansionContentTemplate { get; set; }

        /// <summary>
        /// 扩展模型包装器
        /// </summary>
        /// <param name="model"></param>
        public ExpansionModelWrapper(TModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        /// <summary>
        /// 扩展模型包装器
        /// </summary>
        public ExpansionModelWrapper()
        {
            Model = (TModel)RuntimeHelpers.GetUninitializedObject(typeof(TModel));
        }
    }
}
