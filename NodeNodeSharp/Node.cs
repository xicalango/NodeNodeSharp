using System;

namespace NodeNodeSharp
{
	public abstract class Node : IVisitable
	{

		public abstract void Accept (Visitor v);

		public abstract bool IsConst ();

		public CastNode<T> Cast<T>() {
			return new CastNode<T>{Node = this};
		}

		public IndexNode this [Node n] {
			get {
				return new IndexNode{ Node = this, Indexer = n };
			}
		}

		#region Unary Operations
		public static UnaryNode operator! (Node n) {
			return new UnaryNode{ Node = n, Op=UnaryOperation.NOT };
		}

		public static UnaryNode operator+ (Node n) {
			return new UnaryNode{ Node = n, Op=UnaryOperation.PLUS };
		}

		public static UnaryNode operator- (Node n) {
			return new UnaryNode{ Node = n, Op=UnaryOperation.MINUS };
		}

		public static UnaryNode operator~ (Node n) {
			return new UnaryNode{ Node = n, Op=UnaryOperation.INVERT };
		}

		public static UnaryNode operator++ (Node n) {
			return new UnaryNode{ Node = n, Op=UnaryOperation.INCREMENT };
		}

		public static UnaryNode operator-- (Node n) {
			return new UnaryNode{ Node = n, Op=UnaryOperation.DECREMENT };
		}
		#endregion
		
		#region Binary Operations
		public BinaryNode Assign(Node n) {
			return new BinaryNode{ Left = this, Right = n, Op=BinaryOperation.ASSIGN };
		}

		public static BinaryNode operator+ (Node n1, Node n2) {
			return new BinaryNode{ Left = n1, Right = n2, Op = BinaryOperation.PLUS };
		}

		public static BinaryNode operator- (Node n1, Node n2) {
			return new BinaryNode{ Left = n1, Right = n2, Op = BinaryOperation.MINUS };
		}

		public static BinaryNode operator* (Node n1, Node n2) {
			return new BinaryNode{ Left = n1, Right = n2, Op = BinaryOperation.MUL };
		}

		public static BinaryNode operator/ (Node n1, Node n2) {
			return new BinaryNode{ Left = n1, Right = n2, Op = BinaryOperation.DIV };
		}

		public static BinaryNode operator% (Node n1, Node n2) {
			return new BinaryNode{ Left = n1, Right = n2, Op = BinaryOperation.MOD };
		}

		public static BinaryNode operator== (Node n1, Node n2) {
			return new BinaryNode{ Left = n1, Right = n2, Op = BinaryOperation.EQ };
		}

		public static BinaryNode operator!= (Node n1, Node n2) {
			return new BinaryNode{ Left = n1, Right = n2, Op = BinaryOperation.NEQ };
		}

		public static BinaryNode operator< (Node n1, Node n2) {
			return new BinaryNode{ Left = n1, Right = n2, Op = BinaryOperation.LT };
		}

		public static BinaryNode operator> (Node n1, Node n2) {
			return new BinaryNode{ Left = n1, Right = n2, Op = BinaryOperation.GT };
		}

		public static BinaryNode operator<= (Node n1, Node n2) {
			return new BinaryNode{ Left = n1, Right = n2, Op = BinaryOperation.LEQ };
		}

		public static BinaryNode operator>= (Node n1, Node n2) {
			return new BinaryNode{ Left = n1, Right = n2, Op = BinaryOperation.GEQ };
		}

		public static BinaryNode operator&(Node n1, Node n2) {
			return new BinaryNode{ Left = n1, Right = n2, Op=BinaryOperation.AND };
		}

		public static BinaryNode operator|(Node n1, Node n2) {
			return new BinaryNode{ Left = n1, Right = n2, Op=BinaryOperation.OR };
		}

		public static BinaryNode operator<<(Node n1, int n) {
			return new BinaryNode{ Left = n1, Right = n.Terminal(), Op=BinaryOperation.LEFTSHIFT };
		}

		public static BinaryNode operator>>(Node n1, int n) {
			return new BinaryNode{ Left = n1, Right = n.Terminal(), Op=BinaryOperation.RIGHTSHIFT };
		}

		#endregion


	}
}

