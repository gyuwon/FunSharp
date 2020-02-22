using System;

namespace FunSharp
{
    public interface IList<T>
    {
        U Process<U>(Func<U> forNil, Func<T, IList<T>, U> forCons);
    }
}
