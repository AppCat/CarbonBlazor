using System.Threading.Tasks;

namespace CarbonBlazor.Abp.Components.Web.Theming.PageToolbars;

public interface IPageToolbarManager
{
    Task<PageToolbarItem[]> GetItemsAsync(PageToolbar toolbar);
}
