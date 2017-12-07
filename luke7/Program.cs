using System;
using System.Collections.Generic;
using System.Linq;

namespace luke7
{
	class Program
	{
		static void Main(string[] args)
		{
			var cleartextAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			var cipherAlphabet = new string(cleartextAlphabet.Select(d => Rot(d, CalcRotValue(d))).ToArray());

			var decrypted = new string("OTUJNMQTYOQOVVNEOXQVAOXJEYA".Select(c => cleartextAlphabet[cipherAlphabet.IndexOf(c)]).ToArray());
			System.Console.WriteLine(decrypted);

			Console.WriteLine("\nDone!");
		}

		private static int CalcRotValue(char d) => d*2-'A' + 1;
		private static char Rot(char c, int n)
		{
			int fromPos = c - 'A';
			int toPos = (fromPos + n) % 26;
			while(toPos > 26)
			{
				toPos-=26;
			}
			while(toPos < 0)
			{
				toPos+=26;
			}
			return (char)(toPos + 'A');
		}

		private static char DeRot(char c, int n) => Rot(c, -n);
	}
}
