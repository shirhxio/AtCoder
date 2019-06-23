using System;
using System.Linq;

namespace CTypicalStairs
{
    class Program
    {
        const int LAW = 1000000007;

        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputs[0];
            var m = inputs[1];

            // 壊れている床の一覧を取得
            var brokenStairs = new int[m];
            for (var i = 0; i < m; i++)
            {
                brokenStairs[i] = int.Parse(Console.ReadLine());
            }

            // 連続する壊れていない床の距離を計算
            var distances = new int[m + 1];
            for (var i = 0; i <= m; i++)
            {
                var current = i != m ? brokenStairs[i] : n + 1;
                var prev = i != 0 ? brokenStairs[i - 1] : -1;

                // 壊れた階段が連続していたら、0を出力して終了
                if (current - prev == 1)
                {
                    Console.WriteLine(0);
                    return;
                }

                distances[i] = (current - 1) - (prev + 1);
            }

            // 0 ~ a1 - 1 まで P1 通り、a1 + 1 ~ a2 - 1 まで P2 通り… am + 1 ~ N まで Pm+1 通り
            // 総数は P1 * P2 * … * Pm+1 通り
            var maxDistance = distances.Max();
            var patternMap = CalcPatternMap(maxDistance);

            var patternCount = 1;
            foreach (var distance in distances)
            {
                patternCount = (int)(Math.BigMul(patternCount, patternMap[distance]) % LAW);
            }

            // 解答の出力
            Console.WriteLine(patternCount);
        }

        /// <summary>
        /// 各距離までの経路数 % 1000000007 の一覧を返す
        /// </summary>
        /// <param name="maxDistance"></param>
        /// <returns></returns>
        static int[] CalcPatternMap(int maxDistance)
        {
            if (maxDistance < 1) return new[] { 1 };

            var patternMap = new int[maxDistance + 1];

            patternMap[0] = 1;
            patternMap[1] = 1;
            for (var i = 2; i <= maxDistance; i++)
            {
                patternMap[i] = (patternMap[i - 2] + patternMap[i - 1]) % LAW;
            }

            return patternMap;
        }
    }
}
