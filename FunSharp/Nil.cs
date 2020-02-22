using System;

namespace FunSharp
{
    public sealed class Nil<T> : IList<T>
    {
        public U Process<U>(Func<U> forNil, Func<T, IList<T>, U> forCons) => forNil();

        internal static IList<T> Instance = new Nil<T>();
    }
}
