using CarbonBlazor.Abp.Components.Web.Theming;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace CarbonBlazor.Abp.PermissionManagement
{
    [DependsOn(typeof(CarbonBlazorAbpComponentsWebThemingModule), typeof(AbpAutoMapperModule), typeof(AbpPermissionManagementApplicationContractsModule))]
    public class CarbonBlazorAbpPermissionManagementModule : AbpModule
    {

    }
}
