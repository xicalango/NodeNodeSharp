using System;


namespace NodeNodeSharp
{
	public enum UnaryOperation {
		PLUS,
		MINUS,
		NOT,
		INVERT,
		INCREMENT,
		DECREMENT,
		CAST
	}

	public static class UnaryOperationExtensions {
		public static string ToSymbol(this UnaryOperation op) {
			switch (op) {
			case UnaryOperation.PLUS:
				return "+";
			case UnaryOperation.MINUS:
				return "-";
			case UnaryOperation.NOT:
				return "!";
			case UnaryOperation.INVERT:
				return "~";
			case UnaryOperation.INCREMENT:
				return "++";
			case UnaryOperation.DECREMENT:
				return "--";
			case UnaryOperation.CAST:
				return "CAST";
			default:
				throw new ArgumentOutOfRangeException ();
			}
		}
	}

	public enum BinaryOperation {
		PLUS,
		MINUS,
		MUL,
		DIV,
		MOD,
		AND,
		OR,
		XOR,
		LEFTSHIFT,
		RIGHTSHIFT,
		EQ,
		NEQ,
		LT,
		GT,
		LEQ,
		GEQ,
		ASSIGN
	}

	public static class BinaryOperationExtensions {
		public static string ToSymbol(this BinaryOperation op) {
			switch (op) {
			case BinaryOperation.PLUS:
				return "+";
			case BinaryOperation.MINUS:
				return "-";
			case BinaryOperation.MUL:
				return "*";
			case BinaryOperation.DIV:
				return "/";
			case BinaryOperation.MOD:
				return "%";
			case BinaryOperation.AND:
				return "&";
			case BinaryOperation.OR:
				return "|";
			case BinaryOperation.XOR:
				return "^";
			case BinaryOperation.LEFTSHIFT:
				return "<<";
			case BinaryOperation.RIGHTSHIFT:
				return ">>";
			case BinaryOperation.EQ:
				return "==";
			case BinaryOperation.NEQ:
				return "!=";
			case BinaryOperation.LT:
				return "<";
			case BinaryOperation.GT:
				return ">";
			case BinaryOperation.LEQ:
				return "<=";
			case BinaryOperation.GEQ:
				return ">=";
			case BinaryOperation.ASSIGN:
				return "=";
			default:
				throw new ArgumentOutOfRangeException ();
			}
		}
	}

	public class UnaryNode : Node
	{
		public UnaryOperation Op {get;set;}

		public Node Node { get; set; }

		public override bool IsConst ()
		{
			return Node.IsConst ();
		}

		public override void Accept (Visitor v)
		{
			v.Visit (this);
		}
	}

	public class BinaryNode : Node
	{
		public BinaryOperation Op { get; set; }
	
		public Node Left { get; set; }

		public Node Right { get; set; }

		public override bool IsConst ()
		{
			return Left.IsConst () && Right.IsConst ();
		}

		public override void Accept (Visitor v)
		{
			v.Visit (this);
		}
	}

	public class IndexNode : Node
	{

		public Node Node { get; set; }

		public Node Indexer { get; set; }

		public override bool IsConst ()
		{
			return Node.IsConst () && Indexer.IsConst ();
		}
			
		public override void Accept (Visitor v)
		{
			v.Visit (this);
		}
	}

	public class CastNode<T> : Node
	{
		public Node Node { get; set;}

		public Type Type { get { return typeof(T); } }

		public override void Accept (Visitor v)
		{
			v.Visit (this);
		}

		public override bool IsConst ()
		{
			return Node.IsConst ();
		}
	}
}

