using System;

namespace FunSharp
{
    public interface ITree<T>
    {
        U Process<U>(Func<T, IList<ITree<T>>, U> processor);
    }
}
