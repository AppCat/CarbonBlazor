using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace CarbonBlazor.Abp.Components.Web.Theming.Toolbars
{
    public class ToolbarItem
    {
        public Type ComponentType
        {
            get => _componentType;
            set => _componentType = Check.NotNull(value, nameof(value));
        }
        private Type _componentType;

        public int Order { get; set; }

        public ToolbarItem([NotNull] Type componentType, int order = 0)
        {
            Order = order;
            ComponentType = Check.NotNull(componentType, nameof(componentType));
        }
    }
}
