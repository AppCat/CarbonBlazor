using CarbonBlazor.Abp.Components.Server.BasicTheme.Bundling;
using CarbonBlazor.Abp.Components.Server.Theming;
using CarbonBlazor.Abp.Components.Server.Theming.Bundling;
using CarbonBlazor.Abp.Components.Web.BasicTheme;
using CarbonBlazor.Abp.Components.Web.Theming.Toolbars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;

namespace CarbonBlazor.Abp.Components.Server.BasicTheme
{
    [DependsOn(typeof(CarbonBlazorAbpComponentsWebBasicThemeModule), typeof(CarbonBlazorAbpComponentsServerThemingModule))]
    public class CarbonBlazorAbpComponentsServerBasicThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new BasicThemeToolbarContributor());
            });

            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(BlazorBasicThemeBundles.Styles.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(BlazorStandardBundles.Styles.Global)
                            .AddContributors(typeof(BlazorBasicThemeStyleContributor));
                    });

                options
                    .ScriptBundles
                    .Add(BlazorBasicThemeBundles.Scripts.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(BlazorStandardBundles.Scripts.Global)
                            .AddContributors(typeof(BlazorBasicThemeScriptContributor));
                    });
            });
        }
    }
}
