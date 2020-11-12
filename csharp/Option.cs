using System;
using System.Collections.Generic;
using Unit = System.ValueTuple;

namespace Functional
{
    // SOURCE: https://github.com/la-yumba/functional-csharp-code/blob/master/LaYumba.Functional/Option.cs
    using static F;

    public static partial class F
    {
        public static Option<T> Some<T>(T value) => new Option.Some<T>(value); // wrap the given value into a Some
        // public static Option.None None => Option.None.Default;  // the None value
        public static Option<T> None<T>() => new Option.None<T>();  // the None value
    }

    public struct Option<T> : IEquatable<Option<T>>
    {
        readonly T value;
        readonly bool isSome;
        bool isNone => !isSome;

        private Option(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            this.isSome = true;
            this.value = value;
        }

        public static implicit operator Option<T>(Option.None<T> _) => new Option<T>();
        public static implicit operator Option<T>(Option.Some<T> some) => new Option<T>(some.Value);

        // This operator will cause a test like this to fail:
        //     Assert.NotEqual(Some(1), Some(Some(1)));
        // public static implicit operator Option<T>(T value)
        //    => value == null ? None<T>() : Some(value);

        public R Match<R>(Func<R> None, Func<T, R> Some)
            => isSome ? Some(value) : None();

        public IEnumerable<T> AsEnumerable()
        {
            if (isSome) yield return value;
        }

        public bool Equals(Option<T> other)
           => this.isSome == other.isSome
           && (this.isNone || this.value.Equals(other.value));

        public bool Equals(Option.None<T> _) => isNone;

        public static bool operator ==(Option<T> @this, Option<T> other) => @this.Equals(other);
        public static bool operator !=(Option<T> @this, Option<T> other) => !(@this == other);

        public override string ToString() => isSome ? $"Some({value})" : "None";
    }

    namespace Option
    {
        public struct None<T>
        {
            internal static readonly None<T> Default = new None<T>();
        }

        public struct Some<T>
        {
            internal T Value { get; }

            internal Some(T value)
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value)
                       , "Cannot wrap a null value in a 'Some'; use 'None' instead");
                Value = value;
            }
        }
    }
    public static partial class OptionExt
    {
        // Implement Filter, Map, Bind

        // Filter :: Option<T> -> (T -> bool) -> Option<T>

        // Map :: Option<A> -> (A -> B) -> Option<B>

        // Bind :: Option<A> -> (A -> Option<B>) -> Option<B>
    }
}
