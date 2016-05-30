using System;
using System.Collections.Generic;
using Demo.RandomProjects.PostfixProcessor.Operators;

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

			var result = CalculatePostfixString(values);
			Console.WriteLine("{0} => {1}", postfixString, result);
		}

		private static int CalculatePostfixString(string[] values)
		{
			int result = 0;
			var stack = new Stack<int>();
			foreach (string value in values)
			{
				// if value == number
				//	then push to the stack
				if (IsNumeric(value))
				{
					stack.Push(int.Parse(value));
				}
				else if(IsOperator(value))
				{
					// if value == operator
					//	then pop first two values
					//	then $result = operator(second popped value, first popped value)
					//	then push $result to the stack
					var rightValue = stack.Pop();
					var leftValue = stack.Pop();

					var @operator = OperatorFactory.CreateOperator(value);
					result = @operator.Operate(leftValue, rightValue);

					stack.Push(result);
				}

			}

			return result;
		}

		private static bool IsOperator(string value)
		{
			return !(OperatorFactory.CreateOperator(value) is NullOperator);
		}

		private static bool IsNumeric(string value)
		{
			int result;
			return int.TryParse(value, out result);
		}
	}
}
