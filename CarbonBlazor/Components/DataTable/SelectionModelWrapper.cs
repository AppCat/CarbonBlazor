using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 选择模型包装器
    /// </summary>
    public class SelectionModelWrapper<TModel> : ISelectionModel
    {
        /// <summary>
        /// 模型
        /// </summary>
        public TModel? Model { get; }

        /// <summary>
        /// 选中
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// 选择模型包装器
        /// </summary>
        /// <param name="model"></param>
        public SelectionModelWrapper(TModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        /// <summary>
        /// 选择模型包装器
        /// </summary>
        public SelectionModelWrapper()
        {
            Model = (TModel)RuntimeHelpers.GetUninitializedObject(typeof(TModel));
        }
    }
}
