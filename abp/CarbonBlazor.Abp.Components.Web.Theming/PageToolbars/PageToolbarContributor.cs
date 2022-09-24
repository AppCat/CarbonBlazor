using System.Threading.Tasks;

namespace CarbonBlazor.Abp.Components.Web.Theming.PageToolbars;

public abstract class PageToolbarContributor : IPageToolbarContributor
{
    public abstract Task ContributeAsync(PageToolbarContributionContext context);
}
