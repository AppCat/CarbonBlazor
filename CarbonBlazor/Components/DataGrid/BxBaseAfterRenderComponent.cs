using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor.Components
{
    /// <summary>
    /// 实现呈现队列逻辑的基本呈现组件。
    /// Base render component that implements render-queue logic.
    /// </summary>
    public abstract class BxBaseAfterRenderComponent : BxComponentBase
    {
        #region Members

        /// <summary>
        /// A stack of functions to execute after the rendering.
        /// </summary>
        private Queue<Func<Task>> _executeAfterRenderQueue;

        #endregion

        #region Methods

        /// <summary>
        /// Pushes an action to the stack to be executed after the rendering is done.
        /// </summary>
        /// <param name="action"></param>
        protected void ExecuteAfterRender(Func<Task> action)
        {
            _executeAfterRenderQueue ??= new();

            _executeAfterRenderQueue.Enqueue(action);
        }

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Rendered = true;

            if (_executeAfterRenderQueue?.Count > 0)
            {
                while (_executeAfterRenderQueue.Count > 0)
                {
                    var action = _executeAfterRenderQueue.Dequeue();

                    await action();
                }
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="BaseComponent"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">True if the component is in the disposing process.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                Disposed = true;

                if (disposing)
                {
                    _executeAfterRenderQueue?.Clear();
                }
            }
        }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);

            Dispose(false);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="BaseComponent"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">True if the component is in the disposing process.</param>
        protected virtual ValueTask DisposeAsync(bool disposing)
        {
            try
            {
                if (!AsyncDisposed)
                {
                    AsyncDisposed = true;

                    if (disposing)
                    {
                        _executeAfterRenderQueue?.Clear();
                    }
                }

                return default;
            }
            catch (Exception exc)
            {
                return new(Task.FromException(exc));
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Indicates if the component is already fully disposed.
        /// </summary>
        protected bool Disposed { get; private set; }

        /// <summary>
        /// Indicates if the component is already fully disposed (asynchronously).
        /// </summary>
        protected bool AsyncDisposed { get; private set; }

        /// <summary>
        /// Indicates if component has been rendered in the browser.
        /// </summary>
        protected bool Rendered { get; private set; }

        #endregion
    }
}
