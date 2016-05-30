namespace Demo.RandomProjects.PostfixProcessor.Operators
{
	public class MultiplicationOperator : IOperator
	{
		public int Operate(int leftValue, int rightValue)
		{
			return leftValue * rightValue;
		}
	}
}