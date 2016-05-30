namespace Demo.RandomProjects.PostfixProcessor.Operators
{
	public class AdditionOperator : IOperator
	{
		public int Operate(int leftValue, int rightValue)
		{
			return leftValue + rightValue;
		}
	}
}