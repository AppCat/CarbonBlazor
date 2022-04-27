using CarbonBlazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 模态服务
    /// </summary>
    public class BxModalService
    {
        /// <summary>
        /// 显示消息事件
        /// </summary>
        internal Func<IBxModalConfig, Task>? OnShowModal { get; set; }        

        /// <summary>
        /// 显示模态
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task ShowModalAsync(IBxModalConfig config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            if (OnShowModal != null)
            {
                await OnShowModal.Invoke(config);
            }
        }
    }
}
