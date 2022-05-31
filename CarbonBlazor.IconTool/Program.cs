using Svg;

namespace CarbonBlazor.IconTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("input folderPath: ");
            var folderPath = Console.ReadLine();

            foreach (var svgFile in GetFolderFileName(folderPath))
            {
                var svg = SvgDocument.Open(svgFile.FullName);
                Console.WriteLine(svg.ExternalCSSHref);
            }

        }

        /// <summary>
        /// 获取文件夹文件名
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        static IEnumerable<FileInfo> GetFolderFileName(string folderPath)
        {
            DirectoryInfo root = new DirectoryInfo(folderPath);
            foreach (FileInfo f in root.GetFiles("*.svg"))
            {
                yield return f;
            }
        }
    }
}