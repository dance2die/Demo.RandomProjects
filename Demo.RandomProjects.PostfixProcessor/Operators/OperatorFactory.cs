namespace Demo.RandomProjects.PostfixProcessor.Operators
{
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
}