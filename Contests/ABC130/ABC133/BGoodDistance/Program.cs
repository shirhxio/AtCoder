using System;
using System.Linq;

// https://atcoder.jp/contests/abc133/tasks/abc133_b
namespace BGoodDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputs[0], d = inputs[1];

            // 座標の取得
            var points = new int[n][];
            for (var i = 0; i < n; i++)
            {
                points[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            var count = 0;
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    var distance = CalcDistance(points[i], points[j]);
                    if (distance % 1 == 0) count++;
                }
            }

            // 解答の出力
            Console.WriteLine(count);
        }

        static double CalcDistance(int[] pointA, int[] pointB)
        {
            var sum = pointA.Zip(pointB, (a, b) => Math.Pow(a - b, 2)).Sum();
            return Math.Sqrt(sum);
        }
    }
}
