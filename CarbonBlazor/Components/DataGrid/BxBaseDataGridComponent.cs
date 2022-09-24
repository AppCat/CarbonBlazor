using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 数据网格组件的最小基类。
    /// Minimal base class for datagrid components.
    /// </summary>
    public abstract class BxBaseDataGridComponent : BxBaseAfterRenderComponent, IAsyncDisposable
    {
        #region Methods

        protected override void OnInitialized()
        {
            if (JSModule is null)
            {
                JSModule = new JSDataGridModule(JSRuntime, VersionProvider);
            }

            base.OnInitialized();

            ElementId ??= IdGenerator.Generate;
        }

        protected override async ValueTask DisposeAsync(bool disposing)
        {
            if (disposing && Rendered)
            {
                await JSModule.SafeDisposeAsync();
            }

            await base.DisposeAsync(disposing);
        }

        #endregion

        #region Properties

        protected JSDataGridModule JSModule { get; private set; }

        /// <summary>
        /// Gets or sets the JS runtime.
        /// </summary>
        [Inject] private IJSRuntime JSRuntime { get; set; }

        /// <summary>
        /// Gets or sets the version provider.
        /// </summary>
        [Inject] private IVersionProvider VersionProvider { get; set; }

        /// <summary>
        /// Gets or sets the classname provider.
        /// </summary>
        [Inject] protected IClassProvider ClassProvider { get; set; }

        /// <summary>
        /// Gets or set the IIdGenerator.
        /// </summary>
        [Inject] protected IIdGenerator IdGenerator { get; set; }

        /// <summary>
        /// Gets or sets the datagrid element id.
        /// </summary>
        [Parameter] public string ElementId { get; set; }

        #endregion
    }
}
