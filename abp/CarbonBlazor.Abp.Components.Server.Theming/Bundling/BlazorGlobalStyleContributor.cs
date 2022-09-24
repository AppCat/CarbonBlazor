using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace CarbonBlazor.Abp.Components.Server.Theming.Bundling
{
    public class BlazorGlobalStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/_content/CarbonBlazor/css/carbonblazor.css");
            context.Files.AddIfNotContains("/_content/CarbonBlazor/css/carbonblazor_extension.css"); 
        }
    }
}
