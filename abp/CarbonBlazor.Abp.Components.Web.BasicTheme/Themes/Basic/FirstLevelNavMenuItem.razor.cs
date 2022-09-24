using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace CarbonBlazor.Abp.Components.Web.BasicTheme.Themes.Basic
{
    /// <summary>
    /// 一级菜单
    /// </summary>
    public partial class FirstLevelNavMenuItem : IDisposable
    {
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Parameter]
        public ApplicationMenuItem MenuItem { get; set; }

        public bool IsSubMenuOpen { get; set; }

        protected override void OnInitialized()
        {
            NavigationManager.LocationChanged += OnLocationChanged;
        }

        private void ToggleSubMenu()
        {
            IsSubMenuOpen = !IsSubMenuOpen;
        }

        public void Dispose()
        {
            NavigationManager.LocationChanged -= OnLocationChanged;
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            IsSubMenuOpen = false;
            InvokeAsync(StateHasChanged);
        }
    }
}
