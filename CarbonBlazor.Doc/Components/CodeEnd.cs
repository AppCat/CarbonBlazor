namespace CarbonBlazor.Doc.Components
{
    /// <summary>
    /// 代码结束
    /// </summary>
    public class CodeEnd : ICodeContent
    {
        /// <summary>
        /// 
        /// </summary>
        public string? End { get; set; }

        public string? Content()
        {
            return End;
        }
    }
}
