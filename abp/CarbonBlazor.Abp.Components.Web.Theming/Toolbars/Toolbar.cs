using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace CarbonBlazor.Abp.Components.Web.Theming.Toolbars
{
    public class Toolbar
    {
        public string Name { get; }

        public List<ToolbarItem> Items { get; }

        public Toolbar([NotNull] string name)
        {
            Name = Check.NotNull(name, nameof(name));
            Items = new List<ToolbarItem>();
        }
    }
}
