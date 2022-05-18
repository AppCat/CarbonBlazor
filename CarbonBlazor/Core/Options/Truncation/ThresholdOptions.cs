using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 阈值的选择
    /// Threshold options
    /// </summary>
    public class TruncationOptions
	{
		/// <summary>
		/// 截断类型
		/// truncation type
		/// </summary>
		public string? Type { get; set; }

		/// <summary>
		/// 截断阈值
		/// truncation threshold
		/// </summary>
		public decimal? Threshold { get; set; }

		/// <summary>
		/// 要显示多少个字符
		/// how many characters to be shown
		/// </summary>
		public decimal? NumCharacter { get; set; }
	}
}
