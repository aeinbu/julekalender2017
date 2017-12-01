
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace luke1
{
	public static class Extensions
	{
		public static string NGram(this string s, int n)
		{
			var sb = new StringBuilder();
			for(int i = 0; i <= s.Length - n; i++)
			{
				sb.Append(s.Substring(i, n));
			}

			return sb.ToString();
		}

		public static string Canonicalize(this string s)
		{
			var letters = s.ToCharArray();
			Array.Sort(letters);
			return new string(letters);
		}

	}
}