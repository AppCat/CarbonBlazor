using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CarbonBlazor.Abp.Components.Web.Theming.Toolbars
{
    public interface IToolbarConfigurationContext : IServiceProviderAccessor
    {
        Toolbar Toolbar { get; }

        IAuthorizationService AuthorizationService { get; }

        IStringLocalizerFactory StringLocalizerFactory { get; }

        Task<bool> IsGrantedAsync(string policyName);

        [CanBeNull]
        IStringLocalizer GetDefaultLocalizer();

        [NotNull]
        public IStringLocalizer GetLocalizer<T>();

        [NotNull]
        public IStringLocalizer GetLocalizer(Type resourceType);
    }
}
