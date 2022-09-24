using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// Provider used to get the Blazorise version number.
    /// </summary>
    public interface IVersionProvider
    {
        /// <summary>
        /// Gets the version number.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Gets the milestone version number.
        /// </summary>
        string MilestoneVersion { get; }
    }
}
