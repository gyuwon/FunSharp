using System;

namespace FunSharp
{
    public sealed class Cons<T> : IList<T>
    {
        private readonly T h;
        private readonly Func<IList<T>> t;

        public Cons(T h, Func<IList<T>> t) => (this.h, this.t) = (h, t);

        public U Process<U>(Func<U> forNil, Func<T, IList<T>, U> forCons) => forCons(h, t());
    }
}
