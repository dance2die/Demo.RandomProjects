namespace Demo.RandomProjects.PostfixProcessor.Operators
{
	public class SubtractionOperator : IOperator
	{
		public int Operate(int leftValue, int rightValue)
		{
			return leftValue - rightValue;
		}
	}
}