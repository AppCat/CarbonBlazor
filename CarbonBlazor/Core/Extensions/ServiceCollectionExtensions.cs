using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Extensions
{
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddCarbonBlazor(this IServiceCollection services)
        {
            // Service
            services.AddSingleton<BxModalService>();

            //// JS
            //services.AddSingleton<ElementHelpJS>();

            return services;
        }
    }
}
