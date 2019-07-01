using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// https://atcoder.jp/contests/abc123/tasks/abc123_d
namespace DCake123
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int x = inputs[0], y = inputs[1], z = inputs[2], k = inputs[3];

            var tastinessA = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var tastinessB = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var tastinessC = Console.ReadLine().Split().Select(long.Parse).ToArray();

            Array.Sort(tastinessA);
            Array.Reverse(tastinessA);
            Array.Sort(tastinessB);
            Array.Reverse(tastinessB);
            Array.Sort(tastinessC);
            Array.Reverse(tastinessC);

            var sumList = new List<long>();
            for (var i = 1; i <= tastinessA.Length; i++)
            {
                for (var j = 1; j <= tastinessB.Length; j++)
                {
                    for (var l = 1; l <= tastinessC.Length; l++)
                    {
                        if (i * j * l > k) continue;

                        var sum = tastinessA[i - 1] + tastinessB[j - 1] + tastinessC[l - 1];
                        sumList.Add(sum);
                    }
                }
            }
            var answers = sumList.OrderByDescending(sum => sum).Take(k).ToArray();

            // 解答の出力
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
            Console.Out.Flush();
        }
    }
}
