using System;
using System.Linq;

// https://atcoder.jp/contests/abc130/tasks/abc130_b
namespace BBounding
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputs[0];
            var x = inputs[1];

            var lengths = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var boundCount = 1;
            var position = 0;
            for (var i = 0; i < n; i++)
            {
                position += lengths[i];

                if (position > x) break;
                boundCount++;
            }

            // 解答の出力
            Console.WriteLine(boundCount);
        }
    }
}
