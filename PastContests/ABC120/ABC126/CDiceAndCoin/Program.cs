using System;
using System.Linq;

namespace CDiceAndCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputs[0];
            var k = inputs[1];

            // 各数字の小さい方から加算
            double probSum = 0;
            for (var i = 1; i <= n; i++)
            {
                var shiftCount = 0;
                while (i << shiftCount < k) shiftCount++;

                probSum += 1 / (n * Math.Pow(2, shiftCount));
            }

            // 解答の出力
            Console.WriteLine(probSum);
        }
    }
}
