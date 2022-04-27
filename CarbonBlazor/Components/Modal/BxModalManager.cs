using CarbonBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 模态管理
    /// Modal manager
    /// </summary>
    public class BxModalManager : BxComponentBase
    {
        /// <summary>
        /// 模态服务
        /// </summary>
        [Inject]
        protected BxModalService? ModalService { get; set; }

        /// <summary>
        /// 当前模态
        /// </summary>
        protected BxModal? CurrentModal { get; set; }

        /// <summary>
        /// 配置队列
        /// </summary>
        protected List<KeyValuePair<string, IBxModalConfig>> ModalConfigs { get; set; } = new List<KeyValuePair<string, IBxModalConfig>>();

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            if (ModalService != null && ModalService.OnShowModal == null)
            {
                ModalService.OnShowModal = HandleOnShowModal;
            }
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal override RenderFragment ContentFragment() => __builder =>
        {
            var config = ModalConfigs.FirstOrDefault().Value;         
                
            var sequence = 0;

            __builder.OpenElement(sequence++, "div");

            if (config != null)
            {
                __builder.OpenComponent<BxModal>(sequence++);
                __builder.AddAttribute(sequence++, nameof(BxModal.Id), config.Id);
                __builder.AddAttribute(sequence++, nameof(BxModal.Style), config.Style);
                __builder.AddAttribute(sequence++, nameof(BxModal.Class), config.Class);
                __builder.AddAttribute(sequence++, nameof(BxModal.Model), config.Model);
                __builder.AddAttribute(sequence++, nameof(BxModal.Label), config.Label);
                __builder.AddAttribute(sequence++, nameof(BxModal.LabelTemplate), config.LabelTemplate);
                __builder.AddAttribute(sequence++, nameof(BxModal.Heading), config.Heading);
                __builder.AddAttribute(sequence++, nameof(BxModal.HeadingTemplate), config.HeadingTemplate);
                __builder.AddAttribute(sequence++, nameof(BxModal.Content), config.Content);
                __builder.AddAttribute(sequence++, nameof(BxModal.ContentTemplate), config.ContentTemplate);
                __builder.AddAttribute(sequence++, nameof(BxModal.FooterTemplate), config.FooterTemplate);
                __builder.AddAttribute(sequence++, nameof(BxModal.Actions), config.Actions);

                //__builder.AddAttribute(sequence++, nameof(BxModal.TitleConfig), config.TitleConfig);
                //__builder.AddAttribute(sequence++, nameof(BxModal.ContentConfig), config.ContentConfig);
                //__builder.AddAttribute(sequence++, nameof(BxModal.FooterConfig), config.FooterConfig);

                __builder.AddAttribute(sequence++, nameof(BxModal.OnClose), EventCallback.Factory.Create(this, () => HandleOnHideModal(config.Id)));
                __builder.AddComponentReferenceCapture(sequence++, component =>
                {
                    if (component is BxModal modal)
                    {
                        CurrentModal = modal;
                    }
                });
                __builder.CloseComponent();
            }

            __builder.CloseComponent();
        };

        /// <summary>
        /// 处理显示 模态
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        protected async Task HandleOnShowModal(IBxModalConfig config)
        {
            if (config == null)
                return;
            config.Id ??= Guid.NewGuid().ToString("N");
            ModalConfigs.Add(KeyValuePair.Create(config.Id, config));
            await InvokeStateHasChangedAsync();
        }

        /// <summary>
        /// 处理隐藏模态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected async Task HandleOnHideModal(string? id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ModalConfigs.RemoveAll(config => config.Key == id);
                await InvokeStateHasChangedAsync();
            }
        }

        /// <summary>
        /// 渲染后
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (CurrentModal != null && ModalConfigs.Count > 0)
            {
                await CurrentModal.ShowAsync();
            }
        }
    }
}
