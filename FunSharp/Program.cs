using System;

namespace FunSharp
{
    using static Functions;

    class Program
    {
        static void Main()
        {
            // 6
            Console.WriteLine(Sum(Span.Create(1, 2, 3)));

            // 1 2 3 4 
            WriteLine(Append(Span.Create(1, 2), Span.Create(3, 4)));

            // 2 4 6 
            WriteLine(Doubleall(Span.Create(1, 2, 3)));

            // 45
            Console.WriteLine(Summatrix(
                Span.Create(
                    Span.Create(1, 2, 3),
                    Span.Create(4, 5, 6),
                    Span.Create(7, 8, 9))));

            IList<ITree<int>> Nil = Nil<ITree<int>>.Instance;

            ITree<int> tree =
                Node(1,
                    Cons(Node(2, Nil),
                        Cons(Node(3,
                            Cons(Node(4, Nil), Nil)),
                            Nil)));

            // 10
            Console.WriteLine(Sumtree(tree));

            // 1 2 3 4 
            WriteLine(Labels(tree));

            // 2 4 6 8 
            WriteLine(Labels(Maptree(Double)(tree)));

            // 32
            Console.WriteLine(Sqrt(a0: 10, eps: double.Epsilon, n: 1024));

            // 32
            Console.WriteLine(Relativesqrt(a0: 10, eps: double.Epsilon, n: 1024));

            // 0.25
            Func<double, double> f = Math.Log;
            Console.WriteLine(Within(double.Epsilon, Differentiate(h0: 1, f, x: 4)));
            Console.WriteLine(Within(double.Epsilon, Improve(Differentiate(h0: 1, f, x: 4))));
            Console.WriteLine(Within(double.Epsilon, Improve(Improve(Improve(Differentiate(h0: 1, f, x: 4))))));
            Console.WriteLine(Within(double.Epsilon, Super(Differentiate(h0: 1, f, x: 4))));
        }

        public static void Write<T>(IList<T> list) => list.Process<object>(
            forNil: () => default,
            forCons: (a, l) =>
            {
                Console.Write($"{a} ");
                Write(l);
                return default;
            });

        public static void WriteLine<T>(IList<T> list)
        {
            Write(list);
            Console.WriteLine();
        }
    }
}
