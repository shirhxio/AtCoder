using System;
using System.Linq;

namespace DIntegerCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力 N/M, Card の取得
            var inputsNM = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputsNM[0];
            var m = inputsNM[1];

            var cards = Console.ReadLine().Split().Select(long.Parse).ToArray();

            // 操作一覧の取得
            var operations = new CardOperation[m];
            for (var i = 0; i < m; i++)
            {
                var inputsBC = Console.ReadLine().Split().ToArray();
                var b = int.Parse(inputsBC[0]);
                var c = long.Parse(inputsBC[1]);
                operations[i] = new CardOperation(b, c);
            }

            // 操作をカードの値の降順に並び替える
            Array.Sort(operations);
            Array.Reverse(operations);

            // 操作によって手に入るN枚までのカード
            var opCards = operations.SelectMany(op => Enumerable.Repeat(op.Number, op.Count)).Take(n).ToArray();

            // 初期カードと操作のカードを合わせて、大きいものからN枚を合計する
            var sum = cards.Concat(opCards).OrderByDescending(x => x).Take(n).Sum();

            // 解答の出力
            Console.WriteLine(sum);
        }

        class CardOperation : IComparable<CardOperation>
        {
            public readonly int Count;
            public readonly long Number;

            public CardOperation(int b, long c)
            {
                Count = b;
                Number = c;
            }

            public int CompareTo(CardOperation other)
            {
                return this.Number.CompareTo(other.Number);
            }
        }
    }
}
