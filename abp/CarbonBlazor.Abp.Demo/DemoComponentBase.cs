using CarbonBlazor.Abp.Demo.Localization;
using Volo.Abp.AspNetCore.Components;

namespace CarbonBlazor.Abp.Demo;

public abstract class DemoComponentBase : AbpComponentBase
{
    protected DemoComponentBase()
    {
        LocalizationResource = typeof(DemoResource);
    }
}
