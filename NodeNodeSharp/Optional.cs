using System;

namespace NodeNodeSharp
{
	public abstract class Optional<T>
	{
		public abstract T Value {get;}

		public abstract Optional<TE> Map<TE> (Func<T, Optional<TE>> mapper);

		public abstract T OrElse (T alternative);

		public Optional<TE> Map<TE> (Func<T, TE> mapper) {
			return Map<TE> (t => Optional<TE>.OfNullable (mapper (t)) );
		}

		public T OrElse(Func<T> alternativeGetter) {
			return OrElse (alternativeGetter ());
		}

		public static Optional<T> OfNullable(T value) {
			if (IsNullable (value)) {
				// Analysis disable once CompareNonConstrainedGenericWithNull
				if (value == null)
					return new OptionalEmpty<T> ();
				return new OptionalValue<T> (value);
			} else {
				return new OptionalValue<T> (value);
			}
		}

		public static Optional<T> Of(T value)
		{
			if (IsNullable (value)) {
				// Analysis disable once CompareNonConstrainedGenericWithNull
				if (value == null) {
					throw new InvalidOperationException ();
				}
			}

			return new OptionalValue<T> (value);
		}

		public static Optional<T> Empty() {
			return new OptionalEmpty<T> ();
		}

		static bool IsNullable(T obj)
		{
			Type type = typeof(T);
			if (!type.IsValueType) return true; // ref-type
			return Nullable.GetUnderlyingType (type) != null; // Nullable<T>
 // value-type
		}
	}

	class OptionalValue<T> : Optional<T>
	{
		readonly T _value;

		public OptionalValue (T value)
		{
			_value = value;
		}

		public override T Value {
			get {
				return _value;
			}
		}

		public override Optional<TE> Map<TE> (Func<T, Optional<TE>> mapper)
		{
			return mapper (_value);
		}

		public override T OrElse (T alternative)
		{
			return _value;
		}
	}

	class OptionalEmpty<T> : Optional<T>
	{

		public override T Value {
			get {
				throw new InvalidOperationException ();
			}
		}

		public override Optional<TE> Map<TE> (Func<T, Optional<TE>> mapper)
		{
			return new OptionalEmpty<TE> ();
		}

		public override T OrElse (T alternative)
		{
			return alternative;
		}

	}
}

