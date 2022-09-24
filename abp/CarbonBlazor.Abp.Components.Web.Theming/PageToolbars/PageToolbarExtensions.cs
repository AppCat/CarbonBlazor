using CarbonBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Localization;

namespace CarbonBlazor.Abp.Components.Web.Theming.PageToolbars;

public static class PageToolbarExtensions
{
    public static PageToolbar AddComponent<TComponent>(
        this PageToolbar toolbar,
        Dictionary<string, object> arguments = null,
        int order = 0,
        string requiredPolicyName = null)
    {
        return toolbar.AddComponent(
            typeof(TComponent),
            arguments,
            order,
            requiredPolicyName
        );
    }

    public static PageToolbar AddComponent(
        this PageToolbar toolbar,
        Type componentType,
        Dictionary<string, object> arguments = null,
        int order = 0,
        string requiredPolicyName = null)
    {
        toolbar.Contributors.Add(
            new SimplePageToolbarContributor(
                componentType,
                arguments,
                order,
                requiredPolicyName
            )
        );

        return toolbar;
    }

    public static PageToolbar AddButton(
        this PageToolbar toolbar,
        string content,
        Func<Task> clicked,
        BxButtonKind kind = BxButtonKind.Primary,
        bool disabled = false,
        int order = 0,
        string requiredPolicyName = null)
    {
        toolbar.AddComponent<BxButton>(
            new Dictionary<string, object>
            {
                { nameof(BxButton.Kind), kind},
                { nameof(BxButton.Content), content},
                { nameof(BxButton.Disabled), disabled},
                { nameof(BxButton.OnClick), new EventCallback<MouseEventArgs>(null, clicked)},
            },
            order,
            requiredPolicyName
        );

        return toolbar;
    }
}
