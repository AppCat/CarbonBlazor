using CarbonBlazor.Components;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Abp.Components
{
    public class DataGridEntityActionsColumn<TItem> : BxColumn<TItem>
    {
        [Inject]
        public IStringLocalizer<AbpUiResource> UiLocalizer { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await SetDefaultValuesAsync();
        }

        protected virtual ValueTask SetDefaultValuesAsync()
        {
            //Caption = UiLocalizer["Actions"];
            //Width = "150px";
            //Sortable = false;
            //Field = typeof(TItem).GetProperties().First().Name;
            return ValueTask.CompletedTask;
        }
    }
}
