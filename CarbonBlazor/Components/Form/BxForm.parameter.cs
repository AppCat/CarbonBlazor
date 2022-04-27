using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Form 的参数部分
    /// Form parameter partial
    /// </summary>
    public partial class BxForm<TModel>
    {
        /// <summary>
        /// 自动
        /// 通过 Model, 自动生成表单
        /// With the Model, the form is automatically generated
        /// </summary>
        [Parameter]
        public bool Auto { get; set; }

        /// <summary>
        /// 模型
        /// </summary>
        [Parameter]
        public TModel? Model
        {
            get { return _model; }
            set
            {
                if (!(_model?.Equals(value) ?? false))
                {
                    _model = value;
                    if (_model != null)
                    {
                        _editContext = new EditContext(_model);
                    }
                }
            }
        }
        private TModel? _model;

        #region Event

        /// <summary>
        /// 成功
        /// </summary>
        [Parameter]
        public EventCallback<EditContext> OnFinish { get; set; }

        /// <summary>
        /// 失败
        /// </summary>
        [Parameter]
        public EventCallback<EditContext> OnFailed { get; set; }

        /// <summary>
        /// 重置
        /// </summary>
        [Parameter]
        public EventCallback<EditContext> OnReset { get; set; }

        #endregion
    }
}
