using System.Collections.Generic;
using System.Linq;
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

		[Fact]
		public void TestStringPumutation()
		{
			var expected = new List<IEnumerable<char>>
			{
				new [] {'1', '2', '3'},
				new [] {'1', '3', '2'},
				new [] {'2', '1', '3'},
				new [] {'2', '3', '1'},
				new [] {'3', '1', '2'},
				new [] {'3', '2', '1'}
			};

			var actual = _sut.GetPermutations("123".ToCharArray()).ToList();

			Assert.True(IsMultidimensionalArraySequenceEqual(expected, actual));
		}

		[Fact]
		public void TestStringPumutation2()
		{
			var expected = new List<IEnumerable<char>>
			{
				new [] {'a', 'b'},
				new [] {'b', 'a'},
			};

			var actual = _sut.GetPermutations("ab".ToCharArray()).ToList();

			Assert.True(IsMultidimensionalArraySequenceEqual(expected, actual));
		}

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
}
