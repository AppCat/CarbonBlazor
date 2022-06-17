namespace CarbonBlazor.Doc.Components
{
    /// <summary>
    /// 代码开始
    /// </summary>
    public class CodeStart : ICodeContent
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Start { get;set; }
        
        public string? Content()
        {
            return Start;
        }
    }
}
