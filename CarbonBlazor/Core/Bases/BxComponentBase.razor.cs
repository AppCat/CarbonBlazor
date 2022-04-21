﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Linq.Expressions;

namespace CarbonBlazor
{
    /// <summary>
    /// 组件基础
    /// </summary>
    public abstract partial class BxComponentBase: ComponentBase, IAsyncDisposable, IBxComponentConfig
    {
        /// <summary>
        /// 组件上下文
        /// </summary>
        protected BxComponentContext? ComponentContext { get; private set; }

        /// <summary>
        /// 组件上下文
        /// </summary>
        [CascadingParameter(Name = "FatherComponentContext")]
        protected BxComponentContext? FatherComponentContext { get; set; }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        internal abstract RenderFragment ContentFragment();

        /// <summary>
        /// Js运行时
        /// </summary>
        [Inject]
        protected IJSRuntime? JSRuntime { get; set; }

        #region Parameter

        /// <summary>
        /// Id
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// 类
        /// </summary>
        [Parameter]
        public string Class
        {
            get => _class;
            set
            {
                _class = value;
                ClassMapper.Original = value;
            }
        }
        private string _class;

        /// <summary>
        /// 样式
        /// </summary>
        [Parameter]
        public string Style
        {
            get => _style;
            set
            {
                _style = value;
                StyleMapper.Original = value;
                this.StateHasChanged();
            }
        }
        private string _style;

        /// <summary>
        /// 禁用
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        [Parameter]
        public int? Tabindex { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        #endregion

        /// <summary>
        /// 类映射
        /// </summary>
        internal ClassMapper ClassMapper { get; set; } = new ClassMapper();

        /// <summary>
        /// 样式映射
        /// </summary>
        internal StyleMapper StyleMapper { get; set; } = new StyleMapper();

        /// <summary>
        /// 是否释放
        /// </summary>
        protected bool IsDisposed { get; private set; }

        /// <summary>
        /// 设置映射
        /// </summary>
        protected virtual void OnSetMapper() { }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Id ??= $"cb-{Guid.NewGuid().ToString("N")}";
            ComponentContext = new BxComponentContext(this);
            OnSetMapper();
            FatherComponentContext?.AddSonComponent(this);
        }

        /// <summary>
        /// 释放
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            IsDisposed = true;
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <returns></returns>
        public ValueTask DisposeAsync()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            return ValueTask.CompletedTask;
        }
    }
}