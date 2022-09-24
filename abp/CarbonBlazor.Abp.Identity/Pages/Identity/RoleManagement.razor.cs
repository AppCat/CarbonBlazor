using CarbonBlazor.Abp.Components.Web.Theming.PageToolbars;
using CarbonBlazor.Abp.Components.Web.Theming.Toolbars;
using CarbonBlazor.Abp.PermissionManagement.Components;
using CarbonBlazor.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.TableColumns;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;
using Volo.Abp.ObjectExtending;

namespace CarbonBlazor.Abp.Identity.Pages.Identity
{
    public partial class RoleManagement
    {
        protected const string PermissionProviderName = "R";

        protected PermissionManagementModal PermissionManagementModal;
        protected string ManagePermissionsPolicyName;

        protected bool HasManagePermissionsPermission { get; set; }

        protected PageToolbar Toolbar { get; } = new();

        /// <summary>
        /// 模态服务
        /// </summary>
        [Inject]
        protected BxModalService ModalService { get; set; }

        /// <summary>
        /// 角色管理表格列
        /// </summary>
        protected List<TableColumn> RoleManagementTableColumns => TableColumns.Get<RoleManagement>();

        /// <summary>
        /// 角色管理
        /// </summary>
        public RoleManagement()
        {
            ObjectMapperContext = typeof(CarbonBlazorAbpIdentityModule);
            LocalizationResource = typeof(IdentityResource);
                
            CreatePolicyName = IdentityPermissions.Roles.Create;
            UpdatePolicyName = IdentityPermissions.Roles.Update;
            DeletePolicyName = IdentityPermissions.Roles.Delete;
            ManagePermissionsPolicyName = IdentityPermissions.Roles.ManagePermissions;
        }

        protected override ValueTask SetBreadcrumbItemsAsync()
        {
            //BreadcrumbItems.Add(new BlazoriseUI.BreadcrumbItem(L["Menu:IdentityManagement"].Value));
            //BreadcrumbItems.Add(new BlazoriseUI.BreadcrumbItem(L["Roles"].Value));
            return base.SetBreadcrumbItemsAsync();
        }

        protected override async Task DeleteEntityAsync(IdentityRoleDto entity)
        {
            var config = new BxModalConfig()
            {
                Content = GetDeleteConfirmationMessage(entity),
                Actions = new BxModalActionConfig[]
                {
                new BxModalActionConfig
                {
                    Text = "Cancel",
                    Kind = BxButtonKind.Secondary,
                    OnClick = (model => { return Task.FromResult(true); })
                },
                new BxModalActionConfig
                {
                    Text = "Delete",
                    Kind = BxButtonKind.Danger,
                    OnClick = (async model => { await base.DeleteEntityAsync(entity); return true; })
                }
                },
                PreventCloseOnClickOutside = false
            };

            await ModalService.ShowModalAsync(config);
        }

        protected override string GetDeleteConfirmationMessage(IdentityRoleDto entity)
        {
            return string.Format(L["RoleDeletionConfirmationMessage"], entity.Name);
        }

        protected override ValueTask SetEntityActionsAsync()
        {
            EntityActions
                .Get<RoleManagement>()
                .AddRange(new EntityAction[]
                {
                    new EntityAction
                    {
                        Text = L["Edit"],
                        Visible = (data) => HasUpdatePermission,
                        Clicked = async (data) => { await OpenEditModalAsync(data.As<IdentityRoleDto>()); }
                    },
                    new EntityAction
                    {
                        Text = L["Permissions"],
                        Visible = (data) => HasManagePermissionsPermission,
                        Clicked = async (data) =>
                        {
                            await PermissionManagementModal.OpenAsync(PermissionProviderName, data.As<IdentityRoleDto>().Name);
                        }
                    },
                    new EntityAction
                    {
                        Text = L["Delete"],
                        Visible = (data) => HasDeletePermission,
                        Clicked = async (data) => await DeleteEntityAsync(data.As<IdentityRoleDto>()),
                        ConfirmationMessage = (data) => GetDeleteConfirmationMessage(data.As<IdentityRoleDto>())
                    }
                });

            return base.SetEntityActionsAsync();
        }

        protected override ValueTask SetTableColumnsAsync()
        {
            RoleManagementTableColumns
                .AddRange(new TableColumn[]
                {
                    new TableColumn
                    {
                        Title = L["Actions"],
                        Actions = EntityActions.Get<RoleManagement>()
                    },
                    new TableColumn
                    {
                        Title = L["RoleName"],
                        Data = nameof(IdentityRoleDto.Name),
                        Component = typeof(RoleNameComponent)
                    },
                });

            RoleManagementTableColumns.AddRange(GetExtensionTableColumns(IdentityModuleExtensionConsts.ModuleName, IdentityModuleExtensionConsts.EntityNames.Role));

            return base.SetTableColumnsAsync();
        }

        protected override async Task SetPermissionsAsync()
        {
            await base.SetPermissionsAsync();

            HasManagePermissionsPermission = await AuthorizationService.IsGrantedAsync(IdentityPermissions.Roles.ManagePermissions);
        }

        protected override ValueTask SetToolbarItemsAsync()
        {
            Toolbar.AddButton(L["NewRole"], OpenCreateModalAsync, requiredPolicyName: CreatePolicyName);

            return base.SetToolbarItemsAsync();
        }
    }
}
