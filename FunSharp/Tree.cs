using System;

namespace FunSharp
{
    public sealed class Tree<T> : ITree<T>
    {
        private readonly T label;
        private readonly IList<ITree<T>> subtrees;

        public Tree(T label, IList<ITree<T>> subtrees)
        {
            this.label = label;
            this.subtrees = subtrees;
        }

        public U Process<U>(Func<T, IList<ITree<T>>, U> processor) => processor(label, subtrees);
    }
}
