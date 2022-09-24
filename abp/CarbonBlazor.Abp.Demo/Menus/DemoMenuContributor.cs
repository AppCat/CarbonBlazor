using CarbonBlazor.Abp.Demo.Localization;
using Volo.Abp.UI.Navigation;

namespace CarbonBlazor.Abp.Demo.Menus;

public class DemoMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<DemoResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                DemoMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (DemoModule.IsMultiTenant)
        {
            //administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            //administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        return Task.CompletedTask;
    }
}
