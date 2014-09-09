using System;

namespace NodeNodeSharp
{
	public abstract class Visitor
	{

		public IContext Context { get; private set; }

		protected Visitor() : this(new SimpleContext()) {
		}

		protected Visitor(IContext context) {
			Context = context;
		}

		protected virtual void PreTraverseHook() {
		}

		protected virtual void PostTraverseHook() {
		}

		public void Traverse (Node n)
		{
			PreTraverseHook ();
			n.Accept (this);
			PostTraverseHook ();
		}

		public virtual void Visit (BinaryNode n)
		{
		}

		public virtual void Visit (UnaryNode n)
		{
		}

		public virtual void Visit (IndexNode n)
		{
		}

		public virtual void Visit<T> (Terminal<T> n)
		{
		}

		public virtual void Visit<T> (CastNode<T> n) 
		{
		}
			
	}
}

