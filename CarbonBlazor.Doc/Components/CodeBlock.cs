namespace CarbonBlazor.Doc.Components
{
    /// <summary>
    /// 代码块
    /// </summary>
    public class CodeBlock : ICodeContent
    {
        /// <summary>
        /// 代码行
        /// </summary>
        protected List<ICodeContent> CodeContents { get; }

        /// <summary>
        /// 源码
        /// </summary>
        public CodeBlock()
        {
            CodeContents = new List<ICodeContent>();
        }

        /// <summary>
        /// 添加或者修改包裹
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void AddOrSetParcel(string start, string end)
        {
            var first = CodeContents.FirstOrDefault();
            if(first is not null && first is CodeStart codeStart)
            {
                codeStart.Start = start;
            }
            else
            {
                CodeContents.Insert(0, new CodeStart
                {
                    Start = start,
                });
            }

            var last = CodeContents.LastOrDefault();
            if (last is not null && last is CodeEnd codeEnd)
            {
                codeEnd.End = end;
            }
            else
            {
                CodeContents.Insert(CodeContents.Count, new CodeEnd
                {
                    End = end,
                });
            }
        }

        /// <summary>
        /// 添加 特性
        /// </summary>
        /// <param name="name"></param> 
        /// <param name="value"></param>
        public void AddAttribute(string name, object value)
        {
            var first = CodeContents.FirstOrDefault();
            if (first is not null && first is CodeStart codeStart)
            {
                var valueString = $"=\"{value?.ToString()}\"" ?? string.Empty;

                if (value is bool @bool && !@bool)
                {
                    return;
                }
                else if(value is bool)
                {
                    valueString = string.Empty;
                }

                codeStart.Start = $"{codeStart.Start.Replace(">", " ")}{name}{valueString}>";
            }
        }

        /// <summary>
        /// 添加代码块
        /// </summary>
        /// <param name="codeLines"></param>
        public void AddCode(params string[] codeLines)
        {
            var last = CodeContents.LastOrDefault();
            if (last is not null && last is CodeEnd codeEnd)
            {
                CodeContents.Remove(last);
            }

            if (codeLines != null && codeLines.Any())
            {
                CodeContents.AddRange(codeLines.Select(codeLine => new CodeLine(codeLine)));
            }

            if (last is not null)
            {
                CodeContents.Insert(CodeContents.Count, last);
            }
        }

        /// <summary>
        /// 添加代码块
        /// </summary>
        /// <param name="content"></param>
        public void AddCode(ICodeContent content)
        {
            var last = CodeContents.LastOrDefault();
            if (last is not null && last is CodeEnd)
            {
                CodeContents.Insert(CodeContents.Count - 1, content);
            }
            else
            {
                CodeContents.Add(content);
            }
        }

        /// <summary>
        /// 内容
        /// </summary>
        /// <returns></returns>
        public string? Content()
        {
            return string.Join("\r\n", CodeContents.Select(content => content.Content()));
        }
    }
}
