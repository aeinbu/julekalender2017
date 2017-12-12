using System.Collections.Generic;
using System.Linq;

namespace luke10
{
	static class Extensions
	{
		public static IEnumerable<T> Nth<T>(this IEnumerable<T> collection, int n, int startAt)
		{
			var enumerator = collection.GetEnumerator();
			for (int i = 0; i < startAt; i++)
			{
				if(!enumerator.MoveNext())
				{
					yield break;
				};
			}

			while(enumerator.MoveNext())
			{
				yield return enumerator.Current;
				for (int i = 0; i < n-1; i++)
				{
					if(!enumerator.MoveNext())
					{
						yield break;
					};
				}
			}
		}
	}
}