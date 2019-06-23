using System;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var n = int.Parse(Console.ReadLine());

            var balls = new Position[n];
            for (var i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                balls[i] = new Position(inputs[0], inputs[1]);
            }

            // ボールの数が１の時はコスト１確定
            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }

            // 各ボール間の距離を計算
            var differences = new Position[n][];
            for (var i = 0; i < n; i++)
            {
                differences[i] = new Position[n];
                for (var j = 0; j < n; j++)
                {
                    differences[i][j] = balls[i].Difference(balls[j]);
                }
            }

            // 距離が同じものの数の最大値を取得
            var maxSameDiffs = differences.SelectMany(diffs => diffs)
                .GroupBy(diff => diff)
                .Where(kvp => kvp.Key.X != 0 || kvp.Key.Y != 0)
                .Max(kvp => kvp.Count());

            var cost = n - maxSameDiffs;

            // 解答の出力
            Console.WriteLine(cost);
        }

        struct Position
        {
            public int X, Y;
            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Position Difference(Position other)
            {
                return new Position(X - other.X, Y - other.Y);
            }
        }
    }
}
