using System;
using System.Linq;

// https://atcoder.jp/contests/abc133/tasks/abc133_c
namespace CRemainderMinimization2019
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long l = inputs[0], r = inputs[1];

            // 2019 は素因数分解すると 3 * 673 となる
            // r 以下の 673 の倍数と 3 の倍数は下記の通り
            var multiple673 = (r / 673) * 673;
            var multiple3 = (r / 3) * 3;

            var minMod = int.MaxValue;
            if (l <= multiple673 && l <= multiple3)
            {
                minMod = 0;
            }
            else
            {
                // 673 の倍数を含まない場合、r - l + 1 は高々 672 なので TLE しないはず
                for (var i = l; i <= r - 1; i++)
                {
                    for (var j = l + 1; j <= r; j++)
                    {
                        var mod = i * j % 2019;
                        if (mod < minMod) minMod = (int)mod;
                    }
                }
            }

            // 解答の出力
            Console.WriteLine(minMod);
        }
    }
}
