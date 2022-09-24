# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of solutions
$solutions = (
    "abp"
)

# List of projects
$projects = (

    # abp
    "abp/CarbonBlazor.Abp",
    "abp/CarbonBlazor.Abp.Components.Server.BasicTheme",
    "abp/CarbonBlazor.Abp.Components.Server.Theming",
    "abp/CarbonBlazor.Abp.Components.Web.BasicTheme",
    "abp/CarbonBlazor.Abp.Components.Web.Theming",
    "abp/CarbonBlazor.Abp.Identity",
    "abp/CarbonBlazor.Abp.PermissionManagement",
    "abp/CarbonBlazor.Abp.SettingManagement"
)