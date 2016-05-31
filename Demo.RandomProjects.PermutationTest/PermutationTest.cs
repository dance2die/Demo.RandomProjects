using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.RandomProjects.PermutationTest
{
	public class PermutationTest : BaseTest
	{
		private readonly Permutation _sut = new Permutation();

		public PermutationTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestIntegerPumutation()
		{
			var expected = new List<IEnumerable<int>>
			{
				new [] {1, 2, 3},
				new [] {1, 3, 2},
				new [] {2, 1, 3},
				new [] {2, 3, 1},
				new [] {3, 1, 2},
				new [] {3, 2, 1}
			};

			var actual = _sut.GetPermutations(Enumerable.Range(1, 3)).ToList();

			Assert.True(IsMultidimensionalArraySequenceEqual(expected, actual));
		}

		//[Fact]
		//public void TestStringPumutation()
		//{
		//	var expected = new List<IEnumerable<string>>
		//	{
		//		new [] {"1", "2", "3"},
		//		new [] {"1", "3", "2"},
		//		new [] {"2", "1", "3"},
		//		new [] {"2", "3", "1"},
		//		new [] {"3", "1", "2"},
		//		new [] {"3", "2", "1"}
		//	};

		//	var actual = _sut.GetPermutations("123".ToArray()).ToList();

		//	Assert.True(IsMultidimensionalArraySequenceEqual(expected, actual));
		//}

		/// <summary>
		/// Compare a List of integer arrays.
		/// </summary>
		//private bool IsMultidimensionalArraySequenceEqual(List<int[]> list1, List<int[]> list2)
		private bool IsMultidimensionalArraySequenceEqual<T>(List<IEnumerable<T>> list1, List<IEnumerable<T>> list2)
		{
			for (int i = 0; i < list1.Count; i++)
			{
				if (!list1[i].SequenceEqual(list2[i]))
					return false;
			}

			return true;
		}
	}

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
