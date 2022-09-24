using CarbonBlazor.Abp.Components;
using CarbonBlazor.Components;
using JetBrains.Annotations;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.TableColumns;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Localization;
using CarbonBlazor.Abp.Components.ObjectExtending;

namespace CarbonBlazor.Abp
{
    public abstract class CarbonBlazorCrudPageBase<
        TAppService,
        TEntityDto,
        TKey>
    : CarbonBlazorCrudPageBase<
        TAppService,
        TEntityDto,
        TKey,
        PagedAndSortedResultRequestDto>
    where TAppService : ICrudAppService<
        TEntityDto,
        TKey>
    where TEntityDto : class, IEntityDto<TKey>, new()
    {
    }

    public abstract class CarbonBlazorCrudPageBase<
            TAppService,
            TEntityDto,
            TKey,
            TGetListInput>
        : CarbonBlazorCrudPageBase<
            TAppService,
            TEntityDto,
            TKey,
            TGetListInput,
            TEntityDto>
        where TAppService : ICrudAppService<
            TEntityDto,
            TKey,
            TGetListInput>
        where TEntityDto : class, IEntityDto<TKey>, new()
        where TGetListInput : new()
    {
    }

    public abstract class CarbonBlazorCrudPageBase<
            TAppService,
            TEntityDto,
            TKey,
            TGetListInput,
            TCreateInput>
        : CarbonBlazorCrudPageBase<
            TAppService,
            TEntityDto,
            TKey,
            TGetListInput,
            TCreateInput,
            TCreateInput>
        where TAppService : ICrudAppService<
            TEntityDto,
            TKey,
            TGetListInput,
            TCreateInput>
        where TEntityDto : IEntityDto<TKey>
        where TCreateInput : class, new()
        where TGetListInput : new()
    {
    }

    public abstract class CarbonBlazorCrudPageBase<
            TAppService,
            TEntityDto,
            TKey,
            TGetListInput,
            TCreateInput,
            TUpdateInput>
        : CarbonBlazorCrudPageBase<
            TAppService,
            TEntityDto,
            TEntityDto,
            TKey,
            TGetListInput,
            TCreateInput,
            TUpdateInput>
        where TAppService : ICrudAppService<
            TEntityDto,
            TKey,
            TGetListInput,
            TCreateInput,
            TUpdateInput>
        where TEntityDto : IEntityDto<TKey>
        where TCreateInput : class, new()
        where TUpdateInput : class, new()
        where TGetListInput : new()
    {
    }

    public abstract class CarbonBlazorCrudPageBase<
            TAppService,
            TGetOutputDto,
            TGetListOutputDto,
            TKey,
            TGetListInput,
            TCreateInput,
            TUpdateInput>
        : CarbonBlazorCrudPageBase<
            TAppService,
            TGetOutputDto,
            TGetListOutputDto,
            TKey,
            TGetListInput,
            TCreateInput,
            TUpdateInput,
            TGetListOutputDto,
            TCreateInput,
            TUpdateInput>
        where TAppService : ICrudAppService<
            TGetOutputDto,
            TGetListOutputDto,
            TKey,
            TGetListInput,
            TCreateInput,
            TUpdateInput>
        where TGetOutputDto : IEntityDto<TKey>
        where TGetListOutputDto : IEntityDto<TKey>
        where TCreateInput : class, new()
        where TUpdateInput : class, new()
        where TGetListInput : new()
    {
    }


    /// <summary>
    /// CarbonBlazor Abp增删改查页基础 
    /// </summary>
    public abstract class CarbonBlazorCrudPageBase<
        TAppService,
        TGetOutputDto,
        TGetListOutputDto,
        TKey,
        TGetListInput,
        TCreateInput,
        TUpdateInput,
        TListViewModel,
        TCreateViewModel,
        TUpdateViewModel>
        : AbpComponentBase
    where TAppService : ICrudAppService<
        TGetOutputDto,
        TGetListOutputDto,
        TKey,
        TGetListInput,
        TCreateInput,
        TUpdateInput>
    where TGetOutputDto : IEntityDto<TKey>
    where TGetListOutputDto : IEntityDto<TKey>
    where TCreateInput : class
    where TUpdateInput : class
    where TGetListInput : new()
    where TListViewModel : IEntityDto<TKey>
    where TCreateViewModel : class, new()
    where TUpdateViewModel : class, new()
    {
        [Inject] protected TAppService AppService { get; set; }
        [Inject] protected IStringLocalizer<AbpUiResource> UiLocalizer { get; set; }
        protected virtual int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;

        protected int CurrentPage = 1;
        protected string CurrentSorting;
        protected int? TotalCount;
        protected TGetListInput GetListInput = new TGetListInput();
        protected IReadOnlyList<TListViewModel> Entities = Array.Empty<TListViewModel>();
        protected TCreateViewModel NewEntity;
        protected TKey EditingEntityId;
        protected TUpdateViewModel EditingEntity;
        protected BxModal CreateModal;
        protected BxModal EditModal;
        //protected Validations CreateValidationsRef;
        //protected Validations EditValidationsRef;
        protected List<BreadcrumbItem> BreadcrumbItems = new List<BreadcrumbItem>(2);
        protected DataGridEntityActionsColumn<TListViewModel> EntityActionsColumn;
        protected EntityActionDictionary EntityActions { get; set; }
        protected TableColumnDictionary TableColumns { get; set; }

        protected string CreatePolicyName { get; set; }
        protected string UpdatePolicyName { get; set; }
        protected string DeletePolicyName { get; set; }

        public bool HasCreatePermission { get; set; }
        public bool HasUpdatePermission { get; set; }
        public bool HasDeletePermission { get; set; }

        protected CarbonBlazorCrudPageBase()
        {
            NewEntity = new TCreateViewModel();
            EditingEntity = new TUpdateViewModel();
            TableColumns = new TableColumnDictionary();
            EntityActions = new EntityActionDictionary();
        }

        protected async override Task OnInitializedAsync()
        {
            await SetPermissionsAsync();
            await SetEntityActionsAsync();
            await SetTableColumnsAsync();
            await GetEntitiesAsync();
            await InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// 设置 许可/权限
        /// </summary>
        /// <returns></returns>
        protected virtual async Task SetPermissionsAsync()
        {
            if (CreatePolicyName != null)
            {
                HasCreatePermission = await AuthorizationService.IsGrantedAsync(CreatePolicyName);
            }

            if (UpdatePolicyName != null)
            {
                HasUpdatePermission = await AuthorizationService.IsGrantedAsync(UpdatePolicyName);
            }

            if (DeletePolicyName != null)
            {
                HasDeletePermission = await AuthorizationService.IsGrantedAsync(DeletePolicyName);
            }
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <returns></returns>
        protected virtual async Task GetEntitiesAsync()
        {
            try
            {
                await UpdateGetListInputAsync();
                var result = await AppService.GetListAsync(GetListInput);
                Entities = MapToListViewModel(result.Items);
                TotalCount = (int?)result.TotalCount;
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        /// <summary>
        /// 搜索实体
        /// </summary>
        /// <returns></returns>
        protected virtual async Task SearchEntitiesAsync()
        {
            CurrentPage = 1;

            await GetEntitiesAsync();

            await InvokeAsync(StateHasChanged);
        }

        //protected virtual async Task OnDataGridReadAsync(DataGridReadDataEventArgs<TListViewModel> e)
        //{
        //    CurrentSorting = e.Columns
        //        .Where(c => c.SortDirection != SortDirection.Default)
        //        .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
        //        .JoinAsString(",");
        //    CurrentPage = e.Page;

        //    await GetEntitiesAsync();

        //    await InvokeAsync(StateHasChanged);
        //}

        /// <summary>
        /// 更新获取列表Input 
        /// </summary>
        /// <returns></returns>
        protected virtual Task UpdateGetListInputAsync()
        {
            if (GetListInput is ISortedResultRequest sortedResultRequestInput)
            {
                sortedResultRequestInput.Sorting = CurrentSorting;
            }

            if (GetListInput is IPagedResultRequest pagedResultRequestInput)
            {
                pagedResultRequestInput.SkipCount = (CurrentPage - 1) * PageSize;
            }

            if (GetListInput is ILimitedResultRequest limitedResultRequestInput)
            {
                limitedResultRequestInput.MaxResultCount = PageSize;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取扩展表列
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="entityType"></param>
        /// <returns></returns>
        protected virtual IEnumerable<TableColumn> GetExtensionTableColumns(string moduleName, string entityType)
        {
            var properties = ModuleExtensionConfigurationHelper.GetPropertyConfigurations(moduleName, entityType);
            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.IsAvailableToClients && propertyInfo.UI.OnTable.IsVisible)
                {
                    if (propertyInfo.Name.EndsWith("_Text"))
                    {
                        var lookupPropertyName = propertyInfo.Name.RemovePostFix("_Text");
                        var lookupPropertyDefinition = properties.SingleOrDefault(t => t.Name == lookupPropertyName);
                        yield return new TableColumn
                        {
                            Title = lookupPropertyDefinition.GetLocalizedDisplayName(StringLocalizerFactory),
                            Data = $"ExtraProperties[{propertyInfo.Name}]"
                        };
                    }
                    else
                    {
                        var column = new TableColumn
                        {
                            Title = propertyInfo.GetLocalizedDisplayName(StringLocalizerFactory),
                            Data = $"ExtraProperties[{propertyInfo.Name}]"
                        };

                        if (propertyInfo.IsDate() || propertyInfo.IsDateTime())
                        {
                            column.DisplayFormat = propertyInfo.GetDateEditInputFormatOrNull();
                        }

                        if (propertyInfo.Type.IsEnum)
                        {
                            column.ValueConverter = (val) =>
                                EnumHelper.GetLocalizedMemberName(propertyInfo.Type, val.As<ExtensibleObject>().ExtraProperties[propertyInfo.Name], StringLocalizerFactory);
                        }

                        yield return column;
                    }
                }
            }
        }

        #region Create

        /// <summary>
        /// 打开创建模态
        /// </summary>
        /// <returns></returns>
        protected virtual async Task OpenCreateModalAsync()
        {
            try
            {
                //if (CreateValidationsRef != null)
                //{
                //    await CreateValidationsRef.ClearAll();
                //}

                await CheckCreatePolicyAsync();

                NewEntity = new TCreateViewModel();

                // Mapper will not notify Blazor that binded values are changed
                // so we need to notify it manually by calling StateHasChanged
                await InvokeAsync(async () =>
                {
                    StateHasChanged();
                    if (CreateModal != null)
                    {
                        await CreateModal.ShowAsync();
                    }

                });
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        /// <summary>
        /// 关闭创建模态
        /// </summary>
        /// <returns></returns>
        protected virtual Task CloseCreateModalAsync()
        {
            NewEntity = new TCreateViewModel();
            return InvokeAsync(CreateModal.CloseAsync);
        }

        /// <summary>
        /// 创建实体
        /// </summary>
        /// <returns></returns>
        protected virtual async Task CreateEntityAsync()
        {
            try
            {
                var validate = true;

                //if (CreateValidationsRef != null)
                //{
                //    validate = await CreateValidationsRef.ValidateAll();
                //}

                if (validate)
                {
                    await OnCreatingEntityAsync();

                    await CheckCreatePolicyAsync();
                    var createInput = MapToCreateInput(NewEntity);
                    await AppService.CreateAsync(createInput);

                    await OnCreatedEntityAsync();
                }
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        /// <summary>
        /// 创建实体中 (前)
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnCreatingEntityAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 创建实体后 (后)
        /// </summary>
        /// <returns></returns>
        protected virtual async Task OnCreatedEntityAsync()
        {
            NewEntity = new TCreateViewModel();
            await GetEntitiesAsync();

            await InvokeAsync(CreateModal.CloseAsync);
        }

        #endregion

        #region Update

        /// <summary>
        /// 打开更新模态
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual async Task OpenEditModalAsync(TListViewModel entity)
        {
            try
            {
                //if (EditValidationsRef != null)
                //{
                //    await EditValidationsRef.ClearAll();
                //}

                await CheckUpdatePolicyAsync();

                var entityDto = await AppService.GetAsync(entity.Id);

                EditingEntityId = entity.Id;
                EditingEntity = MapToEditingEntity(entityDto);

                await InvokeAsync(async () =>
                {
                    StateHasChanged();
                    if (EditModal != null)
                    {
                        await EditModal.ShowAsync();
                    }
                });
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        /// <summary>
        /// 关闭更新模态
        /// </summary>
        /// <returns></returns>
        protected virtual Task CloseEditModalAsync()
        {
            InvokeAsync(EditModal.CloseAsync);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <returns></returns>
        protected virtual async Task UpdateEntityAsync()
        {
            try
            {
                var validate = true;

                //if (EditValidationsRef != null)
                //{
                //    validate = await EditValidationsRef.ValidateAll();
                //}

                if (validate)
                {
                    await OnUpdatingEntityAsync();

                    await CheckUpdatePolicyAsync();
                    var updateInput = MapToUpdateInput(EditingEntity);
                    await AppService.UpdateAsync(EditingEntityId, updateInput);

                    await OnUpdatedEntityAsync();
                }
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        /// <summary>
        /// 更新实体中 (前)
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnUpdatingEntityAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 更新实体后 (后)
        /// </summary>
        /// <returns></returns>
        protected virtual async Task OnUpdatedEntityAsync()
        {
            await GetEntitiesAsync();

            await InvokeAsync(EditModal.CloseAsync);
        }

        #endregion

        #region Delete

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual async Task DeleteEntityAsync(TListViewModel entity)
        {
            try
            {
                await CheckDeletePolicyAsync();
                await OnDeletingEntityAsync();
                await AppService.DeleteAsync(entity.Id);
                await OnDeletedEntityAsync();
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        /// <summary>
        /// 删除实体中 (前)
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnDeletingEntityAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 删除实体后 (后)
        /// </summary>
        /// <returns></returns>
        protected virtual async Task OnDeletedEntityAsync()
        {
            await GetEntitiesAsync();
            await InvokeAsync(StateHasChanged);
            await Notify.Success(L["SuccessfullyDeleted"]);
        }

        /// <summary>
        /// 删除确认消息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual string GetDeleteConfirmationMessage(TListViewModel entity)
        {
            return UiLocalizer["ItemWillBeDeletedMessage"];
        }

        #endregion

        #region Map

        /// <summary>
        /// 列表映射 Dto To View
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        private IReadOnlyList<TListViewModel> MapToListViewModel(IReadOnlyList<TGetListOutputDto> dtos)
        {
            if (typeof(TGetListOutputDto) == typeof(TListViewModel))
            {
                return dtos.As<IReadOnlyList<TListViewModel>>();
            }

            return ObjectMapper.Map<IReadOnlyList<TGetListOutputDto>, List<TListViewModel>>(dtos);
        }

        /// <summary>
        /// 获取映射 Dto To View
        /// </summary>
        /// <param name="entityDto"></param>
        /// <returns></returns>
        protected virtual TUpdateViewModel MapToEditingEntity(TGetOutputDto entityDto)
        {
            return ObjectMapper.Map<TGetOutputDto, TUpdateViewModel>(entityDto);
        }

        /// <summary>
        /// 创建映射 View To Dto
        /// </summary>
        /// <param name="createViewModel"></param>
        /// <returns></returns>
        protected virtual TCreateInput MapToCreateInput(TCreateViewModel createViewModel)
        {
            if (typeof(TCreateInput) == typeof(TCreateViewModel))
            {
                return createViewModel.As<TCreateInput>();
            }

            return ObjectMapper.Map<TCreateViewModel, TCreateInput>(createViewModel);
        }

        /// <summary>
        /// 更新映射 View To Dto
        /// </summary>
        /// <param name="updateViewModel"></param>
        /// <returns></returns>
        protected virtual TUpdateInput MapToUpdateInput(TUpdateViewModel updateViewModel)
        {
            if (typeof(TUpdateInput) == typeof(TUpdateViewModel))
            {
                return updateViewModel.As<TUpdateInput>();
            }

            return ObjectMapper.Map<TUpdateViewModel, TUpdateInput>(updateViewModel);
        }

        #endregion

        #region Check

        /// <summary>
        /// 检查创建策略
        /// </summary>
        /// <returns></returns>
        protected virtual async Task CheckCreatePolicyAsync()
        {
            await CheckPolicyAsync(CreatePolicyName);
        }

        /// <summary>
        /// 检查更新策略
        /// </summary>
        /// <returns></returns>
        protected virtual async Task CheckUpdatePolicyAsync()
        {
            await CheckPolicyAsync(UpdatePolicyName);
        }

        /// <summary>
        /// 检查删除策略
        /// </summary>
        /// <returns></returns>
        protected virtual async Task CheckDeletePolicyAsync()
        {
            await CheckPolicyAsync(DeletePolicyName);
        }

        /// <summary>
        /// Calls IAuthorizationService.CheckAsync for the given <paramref name="policyName"/>.
        /// Throws <see cref="AbpAuthorizationException"/> if given policy was not granted for the current user.
        ///
        /// Does nothing if <paramref name="policyName"/> is null or empty.
        /// </summary>
        /// <param name="policyName">A policy name to check</param>
        protected virtual async Task CheckPolicyAsync([CanBeNull] string policyName)
        {
            if (string.IsNullOrEmpty(policyName))
            {
                return;
            }

            await AuthorizationService.CheckAsync(policyName);
        }

        #endregion

        #region Set

        /// <summary>
        /// 设置导航项目
        /// </summary>
        /// <returns></returns>
        protected virtual ValueTask SetBreadcrumbItemsAsync()
        {
            return ValueTask.CompletedTask;
        }

        /// <summary>
        /// 设置实体的行为
        /// </summary>
        /// <returns></returns>
        protected virtual ValueTask SetEntityActionsAsync()
        {
            return ValueTask.CompletedTask;
        }

        /// <summary>
        /// 设置表列
        /// </summary>
        /// <returns></returns>
        protected virtual ValueTask SetTableColumnsAsync()
        {
            return ValueTask.CompletedTask;
        }

        /// <summary>
        /// 设置工具栏项目
        /// </summary>
        /// <returns></returns>
        protected virtual ValueTask SetToolbarItemsAsync()
        {
            return ValueTask.CompletedTask;
        }

        #endregion
    }
}
