using System;
using System.Linq;

namespace CPrison
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力 N/M の取得
            var inputsNM = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputsNM[0];
            var m = inputsNM[1];

            int maxL = 1, minR = n;
            for (var i = 0; i < m; i++)
            {
                var inputsLR = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var l = inputsLR[0];
                var r = inputsLR[1];
                if (maxL < l) maxL = l;
                if (r < minR) minR = r;
            }

            // 1枚だけで全てのゲートを通過できる ID カードの枚数
            var masterKeys = Math.Max(minR - maxL + 1, 0);

            // 解答の出力
            Console.WriteLine(masterKeys);
        }
    }
}
