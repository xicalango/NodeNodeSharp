using System;

namespace NodeNodeSharp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var _1 = new Terminal<int> (1);
			var _3 = new Terminal<string> ();

			Node test = _1 [3.Terminal () + _1 * 2.Terminal()].Assign(_3);

			IContext simpleContext = new SimpleContext ();
			simpleContext.PutAs (_3, "asd");

			new PrintVisitor (simpleContext).Traverse (test);

			Console.ReadKey ();
		}
	}
}
