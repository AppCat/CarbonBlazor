using CarbonBlazor.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.TableColumns;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;
using Volo.Abp.ObjectExtending;

namespace CarbonBlazor.Abp.Identity.Pages.Identity
{
    public partial class RoleNameComponent : ComponentBase
    {
        [Parameter] public object Data { get; set; }
    }
}
