using System;
using System.Collections.Generic;

namespace Demo.RandomProjects.PostfixProcessor
{
	public class Program
	{
		public static void Main(string[] args)
		{
			const string postfixString = "5 1 2 + 4 x + 3 -";

			DisplayResultForPostfixNotation(postfixString);
		}

		private static void DisplayResultForPostfixNotation(string postfixString)
		{
			var values = postfixString.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

			var result = CalculatePostfixString(values);
			Console.WriteLine(result);
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

	public class OperatorFactory
	{
		public static IOperator CreateOperator(string value)
		{
			switch (value)
			{
				case "+":
					return new AdditionOperator();
				case "-":
					return new SubtractionOperator();
				case "*":
				case "x":
				case "X":
					return new MultiplicationOperator();
				case "/":
					return new DivisionOperator();
				default:
					return new NullOperator();
			}
		}
	}

	public class AdditionOperator : IOperator
	{
		public int Operate(int leftValue, int rightValue)
		{
			return leftValue + rightValue;
		}
	}

	public class SubtractionOperator : IOperator
	{
		public int Operate(int leftValue, int rightValue)
		{
			return leftValue - rightValue;
		}
	}

	public class MultiplicationOperator : IOperator
	{
		public int Operate(int leftValue, int rightValue)
		{
			return leftValue * rightValue;
		}
	}

	public class DivisionOperator : IOperator
	{
		public int Operate(int leftValue, int rightValue)
		{
			return leftValue / rightValue;
		}
	}

	public class NullOperator : IOperator
	{
		public int Operate(int leftValue, int rightValue)
		{
			throw new NotImplementedException();
		}
	}

	public interface IOperator
	{
		int Operate(int leftValue, int rightValue);
	}
}
