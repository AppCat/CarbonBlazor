using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace CarbonBlazor.Abp.Components.Web.Theming
{
    [DependsOn(typeof(CarbonBlazorAbpModule), typeof(AbpUiNavigationModule))]
    public class CarbonBlazorAbpComponentsWebThemingModule : AbpModule
    {

    }
}
