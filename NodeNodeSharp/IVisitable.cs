using System;

namespace NodeNodeSharp
{
	public interface IVisitable
	{
		void Accept(Visitor v);
	}
}

