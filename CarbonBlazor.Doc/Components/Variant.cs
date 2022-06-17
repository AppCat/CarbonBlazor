using Microsoft.AspNetCore.Components;

namespace CarbonBlazor.Doc.Components
{
    /// <summary>
    /// Variant 变体
    /// </summary>
    public class Variant
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Nmae { get; }

        /// <summary>
        /// 详情
        /// </summary>
        public string Details { get; }

        /// <summary>
        /// 类型
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// 内容
        /// </summary>
        public RenderFragment? Content { get; set; }

        /// <summary>
        /// Variant 变体
        /// </summary>
        /// <param name="nmae"></param>
        /// <param name="details"></param>
        /// <param name="type"></param>
        /// <param name="content"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Variant(string nmae, string details, Type type, RenderFragment? content = null)
        {
            Nmae = nmae ?? throw new ArgumentNullException(nameof(nmae));
            Details = details ?? throw new ArgumentNullException(nameof(details));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Content = content;
        }
    }
}
