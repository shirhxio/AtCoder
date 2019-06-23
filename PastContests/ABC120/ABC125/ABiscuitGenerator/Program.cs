using System;
using System.Linq;

// https://atcoder.jp/contests/abc125/tasks/abc125_a
namespace ABiscuitGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = inputs[0];
            var b = inputs[1];
            var t = inputs[2];

            var count = b * (t / a);

            // 解答の出力
            Console.WriteLine(count);
        }
    }
}
