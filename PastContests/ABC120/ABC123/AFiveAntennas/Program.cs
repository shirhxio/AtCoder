using System;
using System.Linq;

// https://atcoder.jp/contests/abc123/tasks/abc123_a
namespace AFiveAntennas
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            const int AntennaCount = 5;
            var positions = new int[AntennaCount];
            for (var i = 0; i < AntennaCount; i++)
            {
                positions[i] = int.Parse(Console.ReadLine());
            }
            var k = int.Parse(Console.ReadLine());

            // a < b < c < d < e なので、もっとも離れているのは a/e 間の距離
            var maxDistance = positions.Last() - positions.First();

            // 解答の出力
            var answer = maxDistance <= k ? "Yay!" : ":(";
            Console.WriteLine(answer);
        }
    }
}
