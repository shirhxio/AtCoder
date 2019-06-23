using System;
using System.Linq;

namespace BBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var n = int.Parse(Console.ReadLine());
            var weights = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // 重さの和の最小の差を計算
            var minDiff = int.MaxValue;
            for (var i = 1; i < n; i++)
            {
                var sum1 = weights.Take(i).Sum();
                var sum2 = weights.Skip(i).Sum();

                var diff = Math.Abs(sum2 - sum1);
                if (diff < minDiff) minDiff = diff;
            }
            
            // 解答の出力
            Console.WriteLine(minDiff);
        }
    }
}
