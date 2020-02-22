﻿using System;

namespace FunSharp
{
    public static class Functions
    {
        public static IList<T> Cons<T>(T h, IList<T> t) => new Cons<T>(h, t);

        public static U Foldr<T, U>(Func<T, U, U> f, U x, IList<T> list) => list.Process(
            forNil: () => x,
            forCons: (a, l) => f(a, Foldr(f, x, l)));

        public static Func<int, int, int> Add => (x, y) => x + y;

        public static Func<IList<int>, int> Sum => l => Foldr(Add, 0, l);

        public static IList<T> Append<T>(IList<T> a, IList<T> b) => Foldr(Cons, b, a);

        public static Func<T1, T3, R> Compose<T1, T2, T3, R>(Func<T2, T3, R> f, Func<T1, T2> g)
            => (t1, t3) => f(g(t1), t3);

        public static Func<T1, R> Compose<T1, T2, T3, R>(Func<T2, R> f, Func<T1, T2> g)
            => t1 => f(g(t1));

        public static Func<int, int> Double => n => 2 * n;

        public static Func<IList<T>, IList<U>> Map<T, U>(Func<T, U> f)
            => list => Foldr(Compose<T, U, IList<U>, IList<U>>(Cons, f), Nil<U>.Instance, list);

        public static Func<IList<int>, IList<int>> DoubleAll => Map(Double);

        public static Func<IList<IList<int>>, int> Summatrix
            => Compose<IList<IList<int>>, IList<int>, int, int>(Sum, Map(Sum));

        public static ITree<T> Node<T>(T label, IList<ITree<T>> subtrees) => new Tree<T>(label, subtrees);

        public static V Foldtree<T, U, V>(Func<T, U, V> f, Func<V, U, U> g, U a, ITree<T> tree)
            => tree.Process((label, subtrees) => f(label, Foldtree(f, g, a, subtrees)));

        public static U Foldtree<T, U, V>(Func<T, U, V> f, Func<V, U, U> g, U a, IList<ITree<T>> subtrees) => subtrees.Process(
            forNil: () => a,
            forCons: (subtree, rest) => g(Foldtree(f, g, a, subtree), Foldtree(f, g, a, rest)));

        public static Func<ITree<int>, int> Sumtree => tree => Foldtree(Add, Add, 0, tree);

        public static IList<T> Labels<T>(ITree<T> tree) => Foldtree(Cons, Append, Nil<T>.Instance, tree);

        public static Func<ITree<T>, ITree<U>> Maptree<T, U>(Func<T, U> f)
            => tree => Foldtree(Compose<T, U, IList<ITree<U>>, ITree<U>>(Node, f), Cons, Nil<ITree<U>>.Instance, tree);
    }
}