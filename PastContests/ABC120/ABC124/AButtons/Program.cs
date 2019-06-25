using System;
using System.Linq;

// https://atcoder.jp/contests/abc124/tasks/abc124_a
namespace AButtons
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = inputs[0];
            var b = inputs[1];

            var sum = Math.Max(a, b);
            if (a < b) sum += Math.Max(a, b - 1);
            else sum += Math.Max(a - 1, b);

            // 解答の出力
            Console.WriteLine(sum);
        }
    }
}
