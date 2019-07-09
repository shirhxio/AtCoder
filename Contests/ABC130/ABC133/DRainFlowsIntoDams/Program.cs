using System;
using System.Linq;

// https://atcoder.jp/contests/abc133/tasks/abc133_d
namespace DRainFlowsIntoDams
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var n = int.Parse(Console.ReadLine());
            var impoundments = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rainfalls = new int[n];

            rainfalls[0] = impoundments.Select((x, i) => i % 2 == 0 ? x : -x).Sum();
            for (var i = 1; i < n; i++)
            {
                rainfalls[i] = (impoundments[i - 1] - rainfalls[i - 1] / 2) * 2;
            }

            // 解答の出力
            Console.WriteLine(string.Join(" ", rainfalls));
        }
    }
}
