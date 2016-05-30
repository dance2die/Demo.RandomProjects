using System;
using System.Collections.Generic;

namespace Demo.RandomProjects.Anagram
{
	public class Program
	{
		public static void Main()
		{
			const string word = "iceman";
			IEnumerable<char[]> permutations = GetStringPermutations(word.ToCharArray());

			foreach (char[] characters in permutations)
			{
				var anagram = new string(characters);
				Console.WriteLine(anagram);
			}
		}

		private static IEnumerable<char[]> GetStringPermutations(char[] characters)
		{
			return GetStringPermutations(characters, 0, characters.Length - 1);
		}

		// http://stackoverflow.com/a/756083/4035
		private static IEnumerable<char[]> GetStringPermutations(char[] characters, int start, int length)
		{
			if (start == length)
			{
				yield return characters;
			}
			else
			{
				for (int i = start; i <= length; i++)
				{
					Swap(ref characters[start], ref characters[i]);

					char[] charactersCopy = new string(characters).ToCharArray();
					foreach (var stringPermutation in GetStringPermutations(charactersCopy, start + 1, length))
					{
						yield return stringPermutation;
					}

					Swap(ref characters[start], ref characters[i]);
				}
			}
		}

		private static void Swap(ref char c1, ref char c2)
		{
			if (c1 == c2) return;

			var temp = c1;
			c1 = c2;
			c2 = temp;
		}
	}
}
