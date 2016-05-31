using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.RandomProjects.PermutationTest
{
	public class Permutation
	{
		public List<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> enumerable)
		{
			List<T> list = enumerable.ToList();

			return GetPermutations(list, 0, list.Count - 1).ToList();
		}

		private IEnumerable<IEnumerable<T>> GetPermutations<T>(
			IEnumerable<T> enumerable, int startCount, int permutationCount)
		{
			var list = enumerable.ToList();

			if (startCount == permutationCount)
				yield return list;

			for (int i = startCount; i <= permutationCount; i++)
			{
				Swap(list, startCount, i);

				foreach (var permutation in GetPermutations(list.ToArray(), startCount + 1, permutationCount))
					yield return permutation;
			}
		}

		private void Swap<T>(IList<T> list, int listIndex1, int listIndex2)
		{
			try
			{
				var temp = list[listIndex1];
				list[listIndex1] = list[listIndex2];
				list[listIndex2] = temp;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}