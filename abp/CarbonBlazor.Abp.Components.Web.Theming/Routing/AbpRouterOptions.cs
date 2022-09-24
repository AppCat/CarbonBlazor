using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Abp.Components.Web.Theming.Routing
{
    public class AbpRouterOptions
    {
        public Assembly AppAssembly { get; set; }

        public RouterAssemblyList AdditionalAssemblies { get; }

        public AbpRouterOptions()
        {
            AdditionalAssemblies = new RouterAssemblyList();
        }
    }
}
