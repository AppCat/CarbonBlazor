using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace CarbonBlazor.Abp.Components.Server.Theming.Bundling
{
    public class BlazorGlobalScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/_framework/blazor.server.js");
            context.Files.AddIfNotContains("/_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/abp.js");
            context.Files.AddIfNotContains("/_content/CarbonBlazor/js/carbonblazor.js");
            context.Files.AddIfNotContains("/_content/CarbonBlazor/js/elementHelp.js");
        }
    }
}
