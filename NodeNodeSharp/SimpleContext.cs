using System;
using System.Collections.Generic;

namespace NodeNodeSharp
{
	public class SimpleContext : IContext
	{

		readonly IDictionary<Object, Object> dictionary = new Dictionary<Object, Object>();

		#region IContext implementation

		public T GetAs<T> (Terminal<T> terminal)
		{
			return (T)dictionary [terminal];
		}

		public void PutAs<T> (Terminal<T> terminal, T value)
		{
			dictionary [terminal] = value;
		}

		public bool HasValue<T> (Terminal<T> terminal)
		{
			return dictionary.ContainsKey (terminal);
		}



		#endregion


	}
}

