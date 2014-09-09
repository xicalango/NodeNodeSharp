using System;

namespace NodeNodeSharp
{
	public class PrintVisitor : Visitor
	{
		int indent = 0;

		public PrintVisitor () 
		{
		}
		

		public PrintVisitor (IContext context) : base (context)
		{
		}
		

		void PrintWithIndent<T>(T s) {
			Console.Write (new string(' ', indent * 2));
			Console.WriteLine (s);
		}

		protected override void PreTraverseHook ()
		{
			indent++;
		}

		protected override void PostTraverseHook ()
		{
			indent--;
		}


		public override void Visit (BinaryNode n)
		{
			Traverse (n.Left);
			PrintWithIndent (n.Op.ToSymbol ());
			Traverse (n.Right);
		}

		public override void Visit (UnaryNode n)
		{
			PrintWithIndent (n.Op.ToSymbol ());
			Traverse (n.Node);
		}

		public override void Visit (IndexNode n)
		{
			Traverse (n.Node);
			PrintWithIndent ("@");
			Traverse (n.Indexer);
		}

		public override void Visit<T> (Terminal<T> n)
		{
			if (n.HasValue) {
			PrintWithIndent (n.Value);
			} else {
				PrintWithIndent (Context.Get<T> (n).Map<string> (v => v.ToString()).OrElse (() => string.Format("{0}<{1}>", n.Type, n.GetHashCode ())));
			}
		}

		public override void Visit<T> (CastNode<T> n)
		{
			PrintWithIndent ("CAST");
			Traverse (n.Node);
			PrintWithIndent ("TO " + n.Type);
		}

	}



}

