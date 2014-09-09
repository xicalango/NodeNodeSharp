using System;

namespace NodeNodeSharp
{
	public interface IContext
	{



		T GetAs<T> (Terminal<T> terminal);
		void PutAs<T> (Terminal<T> terminal, T value);

		bool HasValue<T>(Terminal<T> terminal);
	}

	public static class IContextExtensions
	{
		public static Optional<T> Get<T> (this IContext ctx, Terminal<T> terminal)
		{
			return ctx.HasValue (terminal) ? Optional<T>.Of (ctx.GetAs (terminal)) : Optional<T>.Empty ();
		}
	}
}

