namespace CarbonBlazor.Doc.Components
{
    /// <summary>
    /// 代码行
    /// </summary>
    public class CodeLine : ICodeContent
    {
        private string? _line;

        /// <summary>
        /// 代码行
        /// </summary>
        /// <param name="line"></param>
        public CodeLine(string? line = null)
        {
            _line = line ?? string.Empty;
        }

        /// <summary>
        /// 内容
        /// </summary>
        /// <returns></returns>
        public string? Content()
        {
            return _line;
        }
    }
}
