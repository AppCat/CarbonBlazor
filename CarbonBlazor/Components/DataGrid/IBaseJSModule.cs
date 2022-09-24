using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Base contract for all JS modules.
    /// </summary>
    public interface IBaseJSModule
    {
        /// <summary>
        /// Gets the module file name.
        /// </summary>
        string ModuleFileName { get; }

        /// <summary>
        /// Gets the awaitable <see cref="IJSObjectReference"/> task.
        /// </summary>
        Task<IJSObjectReference> Module { get; }
    }
}
