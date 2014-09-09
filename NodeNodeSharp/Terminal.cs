using System;

namespace NodeNodeSharp
{
	public class Terminal<T> : Node
	{

		public Type Type { get { return typeof(T); } }

		public T Value { get; private set; }

		public bool HasValue { get; private set; }

		public Terminal ()
		{
			HasValue = false;
		}

		public Terminal (T value)
		{
			Value = value;
			HasValue = true;
		}
		

		public override void Accept (Visitor v)
		{
			v.Visit (this);
		}

		public override bool IsConst ()
		{
			return HasValue;
		}
	}

	public static class ConstantConvertExtensions {

		public static Terminal<T> Terminal<T>(this T t) {
			return new Terminal<T>(t);
		}

	}


}


