namespace Demo.RandomProjects.PostfixProcessor.Operators
{
	public class DivisionOperator : IOperator
	{
		public int Operate(int leftValue, int rightValue)
		{
			return leftValue / rightValue;
		}
	}
}