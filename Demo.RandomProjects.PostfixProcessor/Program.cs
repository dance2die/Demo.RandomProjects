using System;

namespace Demo.RandomProjects.PostfixProcessor
{
	public class Program
	{
		public static void Main(string[] args)
		{
			DisplayResultForPostfixNotation("5 1 2 + 4 x + 3 -");
			DisplayResultForPostfixNotation("5 7 + 6 2 -  *");
			DisplayResultForPostfixNotation("4 2 3 5 1 - + * +");
		}

		private static void DisplayResultForPostfixNotation(string postfixString)
		{
			var values = postfixString.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

			var result = new PostfixProcessor().CalculatePostfixString(values);
			Console.WriteLine("{0} => {1}", postfixString, result);
		}
	}
}
