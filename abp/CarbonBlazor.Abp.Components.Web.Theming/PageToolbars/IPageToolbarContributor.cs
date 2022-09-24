using System.Threading.Tasks;

namespace CarbonBlazor.Abp.Components.Web.Theming.PageToolbars;

public interface IPageToolbarContributor
{
    Task ContributeAsync(PageToolbarContributionContext context);
}
