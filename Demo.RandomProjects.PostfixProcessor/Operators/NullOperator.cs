using System;

namespace Demo.RandomProjects.PostfixProcessor.Operators
{
	public class NullOperator : IOperator
	{
		public int Operate(int leftValue, int rightValue)
		{
			throw new NotImplementedException();
		}
	}
}