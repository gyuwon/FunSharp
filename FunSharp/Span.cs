using System;
using System.Collections.Generic;

namespace FunSharp
{
    public sealed class Span<T> : IList<T>
    {
        private readonly IReadOnlyList<T> source;
        private readonly int start;

        private Span(IReadOnlyList<T> source, int start = 0)
        {
            this.source = source;
            this.start = start;
        }

        internal static Span<T> Create(params T[] elements) => new Span<T>(elements);

        private bool IsNil => source.Count - start == 0;

        public U Process<U>(Func<U> forNil, Func<T, IList<T>, U> forCons)
            => IsNil
            ? forNil()
            : forCons(source[start], new Span<T>(source, start + 1));
    }

    public static class Span
    {
        public static IList<T> Create<T>(params T[] elements) => Span<T>.Create(elements);
    }
}
